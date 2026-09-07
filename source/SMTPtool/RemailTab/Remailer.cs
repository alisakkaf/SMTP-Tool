using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SMTPtool.helper;

namespace SMTPtool
{
    public class Remailer
    {
        private string serverIP;
        private int serverPort;
        private string mailFrom;
        private string rcptTo;
        private string username = "";
        private string password = "";
        private bool useStartTls = false;

        private TcpClient clientSocket;
        private Stream activeStream;
        private Thread ctThread;
        private volatile bool cancellationRequested = false;

        private DateTime sendStart;
        private DateTime sendEnd;

        public Main _linkToMain;
        public bool sendSingle;
        public string fullMailBody;

        private static readonly Color ColorCommand = Color.FromArgb(100, 181, 246);
        private static readonly Color ColorResponse = Color.FromArgb(129, 199, 132);
        private static readonly Color ColorInfo = Color.FromArgb(255, 213, 79);
        private static readonly Color ColorSuccess = Color.FromArgb(102, 187, 106);
        private static readonly Color ColorError = Color.FromArgb(239, 83, 80);

        public Remailer(Main _linkToMain)
        {
            this._linkToMain = _linkToMain;
        }

        public void Cancel()
        {
            cancellationRequested = true;
            try
            {
                activeStream?.Close();
                clientSocket?.Close();
            }
            catch { }
            Log(">> [STOPPED] Transmission aborted by user.\r\n", ColorInfo);
            ResetUi();
        }

        public void connect()
        {
            cancellationRequested = false;
            _linkToMain.btnRemail.Enabled = false;
            _linkToMain.btnStopRemail.Enabled = true;

            if (string.IsNullOrWhiteSpace(_linkToMain.cbxRemailIP.Text))
            {
                _linkToMain.cbxRemailIP.Text = !string.IsNullOrWhiteSpace(_linkToMain.cbxServer.Text) ? _linkToMain.cbxServer.Text : "127.0.0.1";
            }
            serverIP = _linkToMain.cbxRemailIP.Text.Trim();
            _linkToMain.addServerToList(serverIP);

            try
            {
                serverPort = int.Parse(_linkToMain.txtRemailPort.Text.Trim());
            }
            catch
            {
                serverPort = 25;
                _linkToMain.txtRemailPort.Text = "25";
            }

            mailFrom = _linkToMain.cbxRemailFrom.Text.Trim();
            if (string.IsNullOrEmpty(mailFrom))
            {
                mailFrom = _linkToMain.cbxFrom.Text.Trim();
                if (string.IsNullOrEmpty(mailFrom)) mailFrom = "tester@localhost";
                _linkToMain.cbxRemailFrom.Text = mailFrom;
            }
            _linkToMain.addMailFromtoList(mailFrom);

            rcptTo = _linkToMain.cbxRemailTo.Text.Trim();
            if (string.IsNullOrEmpty(rcptTo))
            {
                rcptTo = _linkToMain.cbxTo.Text.Trim();
                if (string.IsNullOrEmpty(rcptTo)) rcptTo = "recipient@localhost";
                _linkToMain.cbxRemailTo.Text = rcptTo;
            }
            _linkToMain.addRcptToToList(rcptTo);

            // Import credentials and security mode from Main
            username = _linkToMain.txtUsername?.Text?.Trim() ?? "";
            password = _linkToMain.txtPassword?.Text ?? "";
            string securityMode = _linkToMain.cbxSecurityMode?.SelectedItem?.ToString() ?? "";
            useStartTls = (serverPort == 587 || securityMode.IndexOf("STARTTLS", StringComparison.OrdinalIgnoreCase) >= 0);

            ctThread = new Thread(WorkerRun)
            {
                IsBackground = true,
                Name = "RemailerWorker"
            };
            ctThread.Start();
        }

        private void WorkerRun()
        {
            try
            {
                sendStart = DateTime.Now;
                Log($">> Connecting to {serverIP}:{serverPort} (STARTTLS: {(useStartTls ? "Enabled" : "Disabled")})...\r\n", ColorInfo);

                clientSocket = new TcpClient();
                var connectTask = clientSocket.ConnectAsync(serverIP, serverPort);
                if (!connectTask.Wait(10000))
                {
                    throw new TimeoutException($"Connection to {serverIP}:{serverPort} timed out (10s).");
                }

                if (cancellationRequested) return;

                activeStream = clientSocket.GetStream();

                // 1. Read Greeting (220)
                string greeting = ReadSmtpResponse();
                if (string.IsNullOrEmpty(greeting) || !greeting.StartsWith("220"))
                {
                    throw new Exception($"Unexpected greeting from server: {greeting}");
                }

                if (cancellationRequested) return;

                // 2. Send EHLO
                string localHost = System.Net.Dns.GetHostName();
                string ehloResp = SendCommand($"EHLO {localHost}");

                // Fallback to HELO if EHLO not recognized
                if (ehloResp.StartsWith("500") || ehloResp.StartsWith("502"))
                {
                    ehloResp = SendCommand($"HELO {localHost}");
                }

                if (cancellationRequested) return;

                // 3. STARTTLS Upgrade if applicable
                bool supportsStartTls = ehloResp.IndexOf("STARTTLS", StringComparison.OrdinalIgnoreCase) >= 0;
                if ((useStartTls || serverPort == 587) && supportsStartTls)
                {
                    string tlsResp = SendCommand("STARTTLS");
                    if (tlsResp.StartsWith("220"))
                    {
                        Log(">> Negotiating TLS cryptographic layer...\r\n", ColorInfo);
                        var sslStream = new SslStream(activeStream, false, (sender, certificate, chain, sslPolicyErrors) => true);
                        sslStream.AuthenticateAsClient(serverIP);
                        activeStream = sslStream;
                        Log(">> TLS Established successfully.\r\n", ColorSuccess);

                        // Re-issue EHLO over TLS
                        ehloResp = SendCommand($"EHLO {localHost}");
                    }
                }

                if (cancellationRequested) return;

                // 4. AUTH LOGIN if credentials provided
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    Log(">> Authenticating with server via AUTH LOGIN...\r\n", ColorInfo);
                    string authResp = SendCommand("AUTH LOGIN");
                    if (authResp.StartsWith("334"))
                    {
                        string userB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(username));
                        string userResp = SendCommand(userB64);
                        if (userResp.StartsWith("334"))
                        {
                            string passB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
                            string passResp = SendCommand(passB64);
                            if (!passResp.StartsWith("235") && !passResp.StartsWith("250"))
                            {
                                throw new Exception($"Authentication failed: {passResp}");
                            }
                            Log(">> Authentication successful.\r\n", ColorSuccess);
                        }
                        else
                        {
                            throw new Exception($"Unexpected username prompt response: {userResp}");
                        }
                    }
                }

                if (cancellationRequested) return;

                // 5. MAIL FROM
                string mailFromResp = SendCommand($"MAIL FROM:<{mailFrom}>");
                if (!mailFromResp.StartsWith("250"))
                {
                    throw new Exception($"MAIL FROM rejected: {mailFromResp}");
                }

                if (cancellationRequested) return;

                // 6. RCPT TO
                string rcptToResp = SendCommand($"RCPT TO:<{rcptTo}>");
                if (!rcptToResp.StartsWith("250"))
                {
                    throw new Exception($"RCPT TO rejected: {rcptToResp}");
                }

                if (cancellationRequested) return;

                // 7. DATA
                string dataResp = SendCommand("DATA");
                if (!dataResp.StartsWith("354"))
                {
                    throw new Exception($"DATA rejected: {dataResp}");
                }

                if (cancellationRequested) return;

                // 8. Send message content
                if (fullMailBody == null)
                {
                    fullMailBody = !string.IsNullOrEmpty(_linkToMain.remailTab?.currentRawMime)
                        ? _linkToMain.remailTab.currentRawMime
                        : _linkToMain.txtMailView.Text;
                }

                Log(">> Transmitting message payload...\r\n", ColorInfo);
                SendRawPayload(fullMailBody);

                // End with CRLF . CRLF
                string endResp = SendCommand(".");
                if (!endResp.StartsWith("250"))
                {
                    throw new Exception($"Message transmission error: {endResp}");
                }

                sendEnd = DateTime.Now;
                TimeSpan duration = sendEnd - sendStart;
                Log($">> Message Sent Successfully in {duration.TotalSeconds:0.00}s\r\n", ColorSuccess);

                // 9. QUIT
                try { SendCommand("QUIT"); } catch { }
            }
            catch (Exception ex)
            {
                if (!cancellationRequested)
                {
                    Log($">> Error: {ex.Message}\r\n", ColorError);
                }
            }
            finally
            {
                try { activeStream?.Close(); } catch { }
                try { clientSocket?.Close(); } catch { }
                ResetUi();
            }
        }

        private string SendCommand(string command)
        {
            if (cancellationRequested) return "";

            byte[] bytes = Encoding.UTF8.GetBytes(command + "\r\n");
            activeStream.Write(bytes, 0, bytes.Length);
            activeStream.Flush();

            if (sendSingle)
            {
                // Mask base64 password in UI log
                string displayCmd = command;
                if (!string.IsNullOrEmpty(password) && command == Convert.ToBase64String(Encoding.UTF8.GetBytes(password)))
                {
                    displayCmd = "******** [BASE64_PASSWORD]";
                }
                Log($">> {displayCmd}\r\n", ColorCommand);
            }

            return ReadSmtpResponse();
        }

        private void SendRawPayload(string payload)
        {
            using (StringReader reader = new StringReader(payload ?? ""))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (cancellationRequested) return;

                    // Dot stuffing
                    if (line.StartsWith(".")) line = "." + line;
                    byte[] lineBytes = Encoding.UTF8.GetBytes(line + "\r\n");
                    activeStream.Write(lineBytes, 0, lineBytes.Length);
                }
            }
            activeStream.Flush();
        }

        private string ReadSmtpResponse()
        {
            if (cancellationRequested) return null;

            byte[] buffer = new byte[8192];
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                int read = activeStream.Read(buffer, 0, buffer.Length);
                if (read <= 0) break;

                string chunk = Encoding.UTF8.GetString(buffer, 0, read);
                sb.Append(chunk);

                string current = sb.ToString();
                // SMTP responses complete when a line has 3 digits followed by space (or single line with CRLF)
                if (IsCompleteSmtpResponse(current))
                {
                    break;
                }
            }

            string result = sb.ToString();
            if (sendSingle && !string.IsNullOrEmpty(result))
            {
                Log($"<< {result}", ColorResponse);
            }
            return result;
        }

        private bool IsCompleteSmtpResponse(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            string[] lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0) return false;
            string last = lines[lines.Length - 1].Trim();
            return last.Length >= 3 && char.IsDigit(last[0]) && char.IsDigit(last[1]) && char.IsDigit(last[2]) &&
                   (last.Length == 3 || last[3] == ' ');
        }

        private void Log(string text, Color color)
        {
            try
            {
                if (_linkToMain.IsDisposed || !_linkToMain.IsHandleCreated) return;
                _linkToMain.BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {
                        _linkToMain.txtRemailOutput.AppendText(text, color);
                        _linkToMain.txtRemailOutput.SelectionStart = _linkToMain.txtRemailOutput.Text.Length;
                        _linkToMain.txtRemailOutput.ScrollToCaret();
                    }
                    catch { }
                });
            }
            catch { }
        }

        private void ResetUi()
        {
            try
            {
                if (_linkToMain.IsDisposed || !_linkToMain.IsHandleCreated) return;
                _linkToMain.BeginInvoke((MethodInvoker)delegate
                {
                    _linkToMain.btnRemail.Enabled = true;
                    _linkToMain.btnStopRemail.Enabled = false;
                });
            }
            catch { }
        }
    }
}
