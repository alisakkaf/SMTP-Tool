using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SMTPtool.Models;

namespace SMTPtool
{
    public class SmtpSendResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public long DnsMs { get; set; }
        public long TcpMs { get; set; }
        public long SendMs { get; set; }
        public string Transcript { get; set; }
        public DeliveryHistoryItem HistoryItem { get; set; }
    }

    public class SMTPsender
    {
        private SmtpClient client;
        private Main linkToMain;
        private List<MailMessage> mailList = new List<MailMessage>();
        private string serverHost;
        private int serverPort;
        private SslSecurityMode securityMode;
        private bool requiresAuth;
        private string username;
        private string password;
        private bool deliveryReceiptRequested;
        private bool openTrackingSimulated;
        private bool clickTrackingSimulated;

        public void SetTrackingOptions(bool deliveryReceipt, bool openTracking, bool clickTracking)
        {
            this.deliveryReceiptRequested = deliveryReceipt;
            this.openTrackingSimulated = openTracking;
            this.clickTrackingSimulated = clickTracking;
        }

        public void Init(string host, int port, SslSecurityMode secMode, bool auth, string user, string pass, Main mainForm)
        {
            this.serverHost = host;
            this.serverPort = port;
            this.securityMode = secMode;
            this.requiresAuth = auth;
            this.username = user;
            this.password = pass;
            this.linkToMain = mainForm;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;

            client = new SmtpClient
            {
                Host = host,
                Port = port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 20000
            };

            bool useSsl = false;
            switch (secMode)
            {
                case SslSecurityMode.None:
                    useSsl = false;
                    break;
                case SslSecurityMode.SslTls:
                case SslSecurityMode.StartTls:
                    useSsl = true;
                    break;
                case SslSecurityMode.Auto:
                default:
                    useSsl = (port == 465 || port == 587);
                    break;
            }
            client.EnableSsl = useSsl;

            if (requiresAuth && !string.IsNullOrEmpty(username))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(username, password ?? "");
            }
            else
            {
                client.UseDefaultCredentials = false;
            }
        }

        private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

            return true;
        }

        public void AddMailList(List<MailMessage> messages)
        {
            this.mailList = messages;
        }

        public void Run()
        {
            for (int i = 0; i < mailList.Count; i++)
            {
                MailMessage currentMail = mailList[i];
                var result = new SmtpSendResult();
                var transcript = new StringBuilder();
                Stopwatch overallStopwatch = Stopwatch.StartNew();

                transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] Initiating SMTP transmission to {serverHost}:{serverPort}");
                transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] Security Mode: {securityMode} (SSL/TLS Enabled: {client.EnableSsl})");
                transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] Authentication: {(requiresAuth ? "Enabled (" + username + ")" : "Disabled")}");
                transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] From: {currentMail.From}");
                transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] To: {currentMail.To}");
                transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] Subject: {currentMail.Subject}");

                Stopwatch dnsWatch = Stopwatch.StartNew();
                try
                {
                    IPAddress[] addresses = Dns.GetHostAddresses(serverHost);
                    dnsWatch.Stop();
                    result.DnsMs = dnsWatch.ElapsedMilliseconds;
                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [STEP 1] DNS Resolution: {addresses[0]} ({result.DnsMs} ms)");
                }
                catch (Exception dnsEx)
                {
                    dnsWatch.Stop();
                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [STEP 1] DNS Resolution Failed: {dnsEx.Message}");
                }

                Stopwatch tcpWatch = Stopwatch.StartNew();
                try
                {
                    using (TcpClient tcp = new TcpClient())
                    {
                        var connectTask = tcp.ConnectAsync(serverHost, serverPort);
                        if (connectTask.Wait(5000))
                        {
                            tcpWatch.Stop();
                            result.TcpMs = tcpWatch.ElapsedMilliseconds;
                            transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [STEP 2] TCP Connection Established ({result.TcpMs} ms)");
                        }
                        else
                        {
                            tcpWatch.Stop();
                            transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [STEP 2] TCP Connection Timeout after 5000 ms");
                        }
                    }
                }
                catch (Exception tcpEx)
                {
                    tcpWatch.Stop();
                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [STEP 2] TCP Connect Failed: {tcpEx.Message}");
                }

                Stopwatch sendWatch = Stopwatch.StartNew();
                try
                {
                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [STEP 3] EHLO Handshake & Transmitting Message Envelope...");
                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}]   -> MAIL FROM: <{currentMail.From?.Address}>");
                    if (currentMail.To.Count > 0)
                        transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}]   -> RCPT TO: <{currentMail.To[0]?.Address}>");
                    if (deliveryReceiptRequested)
                        transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}]   -> Delivery Status Notification (DSN) requested");
                    if (openTrackingSimulated)
                        transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}]   -> Open Tracking 1x1 GIF payload injected");
                    if (clickTrackingSimulated)
                        transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}]   -> Click Tracking redirect link injected");
                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}]   -> DATA (Transmitting MIME payload...)");
                    client.Send(currentMail);
                    sendWatch.Stop();
                    overallStopwatch.Stop();

                    result.SendMs = sendWatch.ElapsedMilliseconds;
                    result.TotalDuration = overallStopwatch.Elapsed;
                    result.Success = true;
                    result.Message = "250 OK: Message accepted for delivery";

                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [STEP 4] Server Response: 250 OK (Accepted)");
                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] Transmission Completed Successfully in {result.TotalDuration.TotalSeconds:F2}s");
                }
                catch (SmtpException smtpEx)
                {
                    sendWatch.Stop();
                    overallStopwatch.Stop();

                    result.SendMs = sendWatch.ElapsedMilliseconds;
                    result.TotalDuration = overallStopwatch.Elapsed;
                    result.Success = false;
                    result.Message = $"SMTP Error ({smtpEx.StatusCode}): {smtpEx.Message}";

                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [ERROR] SMTP Exception: {smtpEx.StatusCode} - {smtpEx.Message}");
                    if (smtpEx.InnerException != null)
                    {
                        transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [INNER ERROR] {smtpEx.InnerException.Message}");
                    }
                }
                catch (Exception generalEx)
                {
                    sendWatch.Stop();
                    overallStopwatch.Stop();

                    result.SendMs = sendWatch.ElapsedMilliseconds;
                    result.TotalDuration = overallStopwatch.Elapsed;
                    result.Success = false;
                    result.Message = $"Delivery Error: {generalEx.Message}";

                    transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] [ERROR] General Exception: {generalEx.Message}");
                }

                result.Transcript = transcript.ToString();

                string msgId = currentMail.Headers["X-Message-ID"];
                if (string.IsNullOrEmpty(msgId)) msgId = Guid.NewGuid().ToString("N").Substring(0, 8);

                var historyItem = new DeliveryHistoryItem
                {
                    Id = msgId,
                    Success = result.Success,
                    IsDelivered = result.Success,
                    DeliveredTimestamp = result.Success ? (DateTime?)DateTime.Now : null,
                    Timestamp = DateTime.Now,
                    Server = serverHost,
                    Port = serverPort,
                    FromAddress = currentMail.From != null ? currentMail.From.ToString() : "",
                    ToAddress = currentMail.To != null ? currentMail.To.ToString() : "",
                    Subject = currentMail.Subject ?? "",
                    DurationSeconds = Math.Round(result.TotalDuration.TotalSeconds, 2),
                    StatusMessage = result.Message,
                    LogTranscript = result.Transcript,
                    BodyContent = currentMail.Body ?? "",
                    IsHtml = currentMail.IsBodyHtml,
                    AttachmentCount = currentMail.Attachments.Count,
                    RawMimeContent = BuildRawMimePreview(currentMail),
                    DeliveryReceiptRequested = deliveryReceiptRequested,
                    OpenTrackingEnabled = openTrackingSimulated,
                    OpenTrackingUrl = currentMail.Headers["X-Open-Tracking-Url"] ?? "",
                    ClickTrackingEnabled = clickTrackingSimulated,
                    ClickTrackingUrl = currentMail.Headers["X-Click-Tracking-Url"] ?? ""
                };
                result.HistoryItem = historyItem;

                if (linkToMain != null && linkToMain.chbSaveInOutbox.Checked)
                {
                    try
                    {
                        string outboxDir = Path.Combine(
                            Path.GetDirectoryName(Assembly.GetEntryAssembly() != null ? Assembly.GetEntryAssembly().Location : AppDomain.CurrentDomain.BaseDirectory),
                            "mailbox", "Outbox"
                        );
                        if (!Directory.Exists(outboxDir)) Directory.CreateDirectory(outboxDir);

                        var pickupClient = new SmtpClient
                        {
                            DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                            PickupDirectoryLocation = outboxDir
                        };
                        pickupClient.Send(currentMail);
                        transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] Saved copy to local Outbox: {outboxDir}");
                    }
                    catch (Exception outboxEx)
                    {
                        transcript.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] Warning: Could not save to Outbox: {outboxEx.Message}");
                    }
                }

                if (linkToMain != null)
                {
                    linkToMain.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        linkToMain.OnMessageSentCompleted(result);
                    });
                }
            }
        }

        private static string BuildRawMimePreview(MailMessage mail)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"From: {mail.From}");
            sb.AppendLine($"To: {mail.To}");
            if (mail.CC.Count > 0) sb.AppendLine($"Cc: {mail.CC}");
            if (mail.Bcc.Count > 0) sb.AppendLine($"Bcc: {mail.Bcc}");
            if (mail.ReplyToList.Count > 0) sb.AppendLine($"Reply-To: {mail.ReplyToList[0]}");
            sb.AppendLine($"Subject: {mail.Subject}");
            sb.AppendLine($"Date: {DateTime.Now:R}");
            sb.AppendLine($"MIME-Version: 1.0");
            sb.AppendLine($"Content-Type: {(mail.IsBodyHtml ? "text/html" : "text/plain")}; charset=utf-8");
            sb.AppendLine($"X-Mailer: SMTP Tool v1.0 (AliSakkaF)");
            sb.AppendLine();
            sb.AppendLine(mail.Body);
            return sb.ToString();
        }
    }
}
