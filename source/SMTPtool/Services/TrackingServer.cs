using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMTPtool.Services
{
    public class TrackingServer : IDisposable
    {
        private HttpListener listener;
        private CancellationTokenSource cts;
        public int Port { get; private set; } = 8085;
        public string CustomHost { get; set; } = "";
        public bool IsRunning { get; private set; } = false;

        public event Action<string, string, DateTime> MessageOpened;
        public event Action<string, string, DateTime, string> MessageClicked;

        private static readonly byte[] TransparentGifBytes = new byte[]
        {
            0x47, 0x49, 0x46, 0x38, 0x39, 0x61, 0x01, 0x00, 0x01, 0x00, 0x80, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x21, 0xf9, 0x04, 0x01, 0x00, 0x00, 0x00,
            0x00, 0x2c, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x02, 0x02,
            0x44, 0x01, 0x00, 0x3b
        };

        public void Start(int preferredPort = 8085)
        {
            if (IsRunning) return;

            int port = preferredPort;
            bool started = false;

            for (int attempt = 0; attempt < 10; attempt++)
            {
                try
                {
                    listener = new HttpListener();

                    string localIp = GetLocalIpAddress();
                    bool registeredAny = false;

                    try
                    {
                        listener.Prefixes.Add($"http://*:{port}/track/");
                        registeredAny = true;
                    }
                    catch
                    {
                        listener.Prefixes.Clear();
                    }

                    if (!registeredAny)
                    {
                        listener.Prefixes.Add($"http://localhost:{port}/track/");
                        listener.Prefixes.Add($"http://127.0.0.1:{port}/track/");
                        if (!string.IsNullOrEmpty(localIp) && localIp != "127.0.0.1")
                        {
                            try
                            {
                                listener.Prefixes.Add($"http://{localIp}:{port}/track/");
                            }
                            catch { }
                        }
                    }

                    listener.Start();
                    Port = port;
                    started = true;
                    break;
                }
                catch
                {
                    try { listener?.Close(); } catch { }
                    port++;
                }
            }

            if (!started)
            {
                IsRunning = false;
                return;
            }

            IsRunning = true;
            cts = new CancellationTokenSource();
            Task.Run(() => ListenLoop(cts.Token));
        }

        private async Task ListenLoop(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested && listener != null && listener.IsListening)
            {
                try
                {
                    var context = await listener.GetContextAsync();
                    _ = Task.Run(() => HandleRequest(context));
                }
                catch
                {
                    if (ct.IsCancellationRequested) break;
                }
            }
        }

        private void HandleRequest(HttpListenerContext context)
        {
            try
            {
                var req = context.Request;
                var res = context.Response;
                string rawUrl = req.RawUrl ?? "";
                string clientIp = req.RemoteEndPoint?.Address?.ToString() ?? "Unknown";

                if (rawUrl.StartsWith("/track/open/", StringComparison.OrdinalIgnoreCase))
                {
                    string messageId = rawUrl.Substring("/track/open/".Length);
                    int queryIdx = messageId.IndexOf('?');
                    if (queryIdx >= 0) messageId = messageId.Substring(0, queryIdx);
                    messageId = messageId.TrimEnd('/').Trim();

                    res.ContentType = "image/gif";
                    res.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate, max-age=0");
                    res.Headers.Add("Pragma", "no-cache");
                    res.Headers.Add("Expires", "0");
                    res.StatusCode = 200;
                    res.ContentLength64 = TransparentGifBytes.Length;
                    res.OutputStream.Write(TransparentGifBytes, 0, TransparentGifBytes.Length);
                    res.OutputStream.Flush();
                    res.Close();

                    if (!string.IsNullOrEmpty(messageId))
                    {
                        MessageOpened?.Invoke(messageId, clientIp, DateTime.Now);
                    }
                    return;
                }
                else if (rawUrl.StartsWith("/track/click/", StringComparison.OrdinalIgnoreCase))
                {
                    string messageId = rawUrl.Substring("/track/click/".Length);
                    int queryIdx = messageId.IndexOf('?');
                    string queryString = "";
                    if (queryIdx >= 0)
                    {
                        queryString = messageId.Substring(queryIdx + 1);
                        messageId = messageId.Substring(0, queryIdx);
                    }
                    messageId = messageId.TrimEnd('/').Trim();

                    string destinationUrl = "https://alisakkaf.com";
                    string customUrl = req.QueryString["url"] ?? req.QueryString["dest"] ?? req.QueryString["target"];
                    if (!string.IsNullOrEmpty(customUrl))
                    {
                        destinationUrl = customUrl;
                    }

                    res.StatusCode = 302;
                    res.RedirectLocation = destinationUrl;
                    byte[] redirectBody = Encoding.UTF8.GetBytes($"<html><body>Redirecting to <a href=\"{destinationUrl}\">{destinationUrl}</a>...</body></html>");
                    res.ContentType = "text/html; charset=utf-8";
                    res.ContentLength64 = redirectBody.Length;
                    res.OutputStream.Write(redirectBody, 0, redirectBody.Length);
                    res.OutputStream.Flush();
                    res.Close();

                    if (!string.IsNullOrEmpty(messageId))
                    {
                        MessageClicked?.Invoke(messageId, clientIp, DateTime.Now, destinationUrl);
                    }
                    return;
                }
                else
                {
                    byte[] statusBytes = Encoding.UTF8.GetBytes("SMTP Tool Tracking Server is active.");
                    res.StatusCode = 200;
                    res.ContentType = "text/plain";
                    res.ContentLength64 = statusBytes.Length;
                    res.OutputStream.Write(statusBytes, 0, statusBytes.Length);
                    res.OutputStream.Flush();
                    res.Close();
                }
            }
            catch { }
        }

        public string GetOpenTrackingUrl(string messageId)
        {
            string host = GetEffectiveHost();
            return $"http://{host}:{Port}/track/open/{messageId}";
        }

        public string GetClickTrackingUrl(string messageId, string targetUrl = "https://alisakkaf.com")
        {
            string host = GetEffectiveHost();
            string encodedTarget = Uri.EscapeDataString(targetUrl);
            return $"http://{host}:{Port}/track/click/{messageId}?url={encodedTarget}";
        }

        public string GetEffectiveHost()
        {
            if (!string.IsNullOrWhiteSpace(CustomHost))
                return CustomHost.Trim();

            string localIp = GetLocalIpAddress();
            if (!string.IsNullOrEmpty(localIp) && localIp != "127.0.0.1")
                return localIp;

            return "127.0.0.1";
        }

        public static string GetLocalIpAddress()
        {
            try
            {
                foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (netInterface.OperationalStatus == OperationalStatus.Up &&
                        netInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        netInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                    {
                        var ipProps = netInterface.GetIPProperties();
                        foreach (var addr in ipProps.UnicastAddresses)
                        {
                            if (addr.Address.AddressFamily == AddressFamily.InterNetwork &&
                                !IPAddress.IsLoopback(addr.Address))
                            {
                                return addr.Address.ToString();
                            }
                        }
                    }
                }
            }
            catch { }
            return "127.0.0.1";
        }

        public void Stop()
        {
            try
            {
                cts?.Cancel();
                listener?.Stop();
                listener?.Close();
            }
            catch { }
            finally
            {
                IsRunning = false;
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
