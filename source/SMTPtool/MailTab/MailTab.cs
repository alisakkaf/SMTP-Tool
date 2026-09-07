using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using SMTPtool;
using SMTPtool.Models;

namespace SMTPtool
{
    public class MailTab
    {
        private Main _linkToMain;
        private List<Attachment> attachmentList = new List<Attachment>();
        private List<string> attachmentPaths = new List<string>();
        public System.Timers.Timer mySendTimer;
        public int numberOfMessagesSent = 0;
        public int numberOfMessagesToSend = 0;
        public DateTime sendStart;

        public MailTab(Main linkToMain)
        {
            this._linkToMain = linkToMain;
        }

        public void btnSendClicked()
        {
            SMTPsender.CancellationRequested = false;
            _linkToMain.btnSend.Enabled = false;
            _linkToMain.btnStopSend.Enabled = true;
            _linkToMain.btnPing.Enabled = false;
            _linkToMain.btnSend.Text = "Sending...";

            mySendTimer = new System.Timers.Timer();
            mySendTimer.Elapsed += new ElapsedEventHandler(OnSendTimedEvent);
            mySendTimer.Interval = 300;
            mySendTimer.Enabled = true;

            string server = _linkToMain.cbxServer.Text.Trim();
            if (string.IsNullOrEmpty(server))
            {
                server = "127.0.0.1";
                _linkToMain.cbxServer.Text = server;
            }
            _linkToMain.addServerToList(server);

            int port;
            if (!int.TryParse(_linkToMain.txtPort.Text.Trim(), out port) || port <= 0 || port > 65535)
            {
                port = 25;
                _linkToMain.txtPort.Text = "25";
            }

            string fromAddress = _linkToMain.cbxFrom.Text.Trim();
            if (string.IsNullOrEmpty(fromAddress))
            {
                fromAddress = "tester@example.com";
                _linkToMain.cbxFrom.Text = fromAddress;
            }
            _linkToMain.addMailFromtoList(fromAddress);

            string toAddress = _linkToMain.cbxTo.Text.Trim();
            if (string.IsNullOrEmpty(toAddress))
            {
                toAddress = "recipient@example.com";
                _linkToMain.cbxTo.Text = toAddress;
            }
            _linkToMain.addRcptToToList(toAddress);

            string fromName = _linkToMain.txtFromName.Text.Trim();
            string replyTo = _linkToMain.txtReplyTo.Text.Trim();
            string cc = _linkToMain.txtCc.Text.Trim();
            string bcc = _linkToMain.txtBcc.Text.Trim();
            bool isHtml = _linkToMain.chbIsHtml.Checked;
            bool readReceipt = _linkToMain.chbReadReceipt.Checked;
            bool openTracking = _linkToMain.chbOpenTracking.Checked;
            bool clickTracking = _linkToMain.chbClickTracking.Checked;
            SslSecurityMode secMode = _linkToMain.GetSelectedSecurityMode();
            bool requiresAuth = _linkToMain.chbRequiresAuth.Checked;
            string username = _linkToMain.txtUsername.Text.Trim();
            string password = _linkToMain.txtPassword.Text;

            addLogMessage($"Connecting to SMTP Host {server}:{port} (Security: {secMode}, Auth: {(requiresAuth ? "Yes" : "No")})");

            numberOfMessagesToSend = Convert.ToInt32(_linkToMain.nrcCount.Value) * Convert.ToInt32(_linkToMain.nrcThreadCount.Value);
            numberOfMessagesSent = 0;
            sendStart = DateTime.Now;

            int threadCount = Convert.ToInt32(_linkToMain.nrcThreadCount.Value);
            int countPerThread = Convert.ToInt32(_linkToMain.nrcCount.Value);

            int globalCounter = 1;
            for (int t = 1; t <= threadCount; t++)
            {
                SMTPsender senderWorker = new SMTPsender();
                senderWorker.Init(server, port, secMode, requiresAuth, username, password, _linkToMain);
                senderWorker.SetTrackingOptions(readReceipt, openTracking, clickTracking);

                List<MailMessage> messagesForThread = new List<MailMessage>();

                for (int m = 1; m <= countPerThread; m++)
                {
                    MailMessage msg = new MailMessage();

                    try
                    {
                        msg.From = string.IsNullOrEmpty(fromName) ? new MailAddress(fromAddress) : new MailAddress(fromAddress, fromName);
                    }
                    catch
                    {
                        msg.From = new MailAddress("tester@example.com", "SMTP Tool");
                    }

                    try
                    {
                        msg.To.Add(new MailAddress(toAddress));
                    }
                    catch
                    {
                        msg.To.Add(new MailAddress("recipient@example.com"));
                    }

                    if (!string.IsNullOrEmpty(replyTo))
                    {
                        try { msg.ReplyToList.Add(new MailAddress(replyTo)); } catch { }
                    }

                    if (!string.IsNullOrEmpty(cc))
                    {
                        try { msg.CC.Add(new MailAddress(cc)); } catch { }
                    }

                    if (!string.IsNullOrEmpty(bcc))
                    {
                        try { msg.Bcc.Add(new MailAddress(bcc)); } catch { }
                    }

                    string baseSubject = _linkToMain.txtSubject.Text;
                    msg.Subject = numberOfMessagesToSend > 1 ? $"{baseSubject} [#{globalCounter}]" : baseSubject;

                    string messageId = Guid.NewGuid().ToString("N").Substring(0, 8);
                    msg.Headers.Add("X-Message-ID", messageId);

                    string openUrl = _linkToMain.trackingServer != null ? _linkToMain.trackingServer.GetOpenTrackingUrl(messageId) : $"http://127.0.0.1:8085/track/open/{messageId}";
                    string clickUrl = _linkToMain.trackingServer != null ? _linkToMain.trackingServer.GetClickTrackingUrl(messageId, "https://alisakkaf.com") : $"http://127.0.0.1:8085/track/click/{messageId}?url=https%3A%2F%2Falisakkaf.com";

                    msg.Headers.Add("X-Open-Tracking-Url", openUrl);
                    msg.Headers.Add("X-Click-Tracking-Url", clickUrl);

                    string bodyText = _linkToMain.txtBody.Text;
                    if (isHtml)
                    {
                        msg.IsBodyHtml = true;
                        if (openTracking)
                        {
                            string trackingPixel = $"<img src=\"{openUrl}\" width=\"1\" height=\"1\" alt=\"\" style=\"display:none;\" />";
                            bodyText += "\r\n" + trackingPixel;
                        }
                        if (clickTracking)
                        {
                            string trackedLink = $"<p style=\"margin-top:25px;padding:12px;background:#f8fafc;border:1px solid #e2e8f0;border-radius:6px;font-size:13px;color:#475569;\"><strong>Simulated Engagement:</strong> <a href=\"{clickUrl}\" target=\"_blank\" style=\"color:#2563eb;font-weight:bold;text-decoration:underline;\">Click here to verify email interaction</a></p>";
                            bodyText += "\r\n" + trackedLink;
                        }
                    }
                    else
                    {
                        msg.IsBodyHtml = false;
                        if (clickTracking)
                        {
                            bodyText += $"\r\n\r\n[Tracked Link: {clickUrl}]";
                        }
                    }
                    msg.Body = bodyText;

                    msg.Priority = _linkToMain.GetSelectedPriority();

                    if (readReceipt)
                    {
                        msg.Headers.Add("Disposition-Notification-To", fromAddress);
                        msg.Headers.Add("Return-Receipt-To", fromAddress);
                        try
                        {
                            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.OnFailure;
                        }
                        catch { }
                    }

                    if (attachmentList.Count > 0)
                    {
                        foreach (var att in attachmentList)
                        {
                            try
                            {
                                msg.Attachments.Add(new Attachment(att.ContentStream, att.Name, att.ContentType.MediaType));
                            }
                            catch { }
                        }
                    }

                    messagesForThread.Add(msg);
                    globalCounter++;
                }

                senderWorker.AddMailList(messagesForThread);
                Thread workerThread = new Thread(new ThreadStart(senderWorker.Run))
                {
                    IsBackground = true,
                    Name = $"SMTP_Sender_Thread_{t}"
                };
                workerThread.Start();
            }

            try
            {
                _linkToMain.myParser.writeXML();
            }
            catch { }
        }

        private void OnSendTimedEvent(object source, ElapsedEventArgs e)
        {
            _linkToMain.Invoke((MethodInvoker)delegate
            {
                switch (_linkToMain.btnSend.Text)
                {
                    case "Sending...":
                        _linkToMain.btnSend.Text = "Sending";
                        break;
                    case "Sending":
                        _linkToMain.btnSend.Text = "Sending.";
                        break;
                    case "Sending.":
                        _linkToMain.btnSend.Text = "Sending..";
                        break;
                    case "Sending..":
                        _linkToMain.btnSend.Text = "Sending...";
                        break;
                }
            });
        }

        public void btnAttachClicked()
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                RestoreDirectory = true,
                Multiselect = true,
                Title = "Select Attachment Files"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileLoc in ofd.FileNames)
                    {
                        if (File.Exists(fileLoc))
                        {
                            addAttachment(fileLoc);
                        }
                    }
                }
            }
        }

        public void addAttachment(string fileName)
        {
            try
            {
                FileInfo fi = new FileInfo(fileName);
                attachmentList.Add(new Attachment(fileName));
                string displayStr = $"{fi.Name} ({FormatBytes(fi.Length)})";
                attachmentPaths.Add(displayStr);

                _linkToMain.lbAttachments.DataSource = null;
                _linkToMain.lbAttachments.DataSource = attachmentPaths;
                _linkToMain.btnDelAttachment.Enabled = true;
                _linkToMain.btnDelAttachmentAll.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding attachment: " + ex.Message, "Attachment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void btnDelAttachmentClicked()
        {
            try
            {
                int index = _linkToMain.lbAttachments.SelectedIndex;
                if (index >= 0 && index < attachmentList.Count)
                {
                    attachmentList.RemoveAt(index);
                    attachmentPaths.RemoveAt(index);
                }
            }
            catch { }

            _linkToMain.lbAttachments.DataSource = null;
            _linkToMain.lbAttachments.DataSource = attachmentPaths;
            if (attachmentPaths.Count == 0)
            {
                _linkToMain.btnDelAttachment.Enabled = false;
                _linkToMain.btnDelAttachmentAll.Enabled = false;
            }
        }

        public void btnDelAttachmentAllClicked()
        {
            attachmentList.Clear();
            attachmentPaths.Clear();
            _linkToMain.lbAttachments.DataSource = null;
            _linkToMain.lbAttachments.DataSource = attachmentPaths;
            _linkToMain.btnDelAttachment.Enabled = false;
            _linkToMain.btnDelAttachmentAll.Enabled = false;
        }

        private static string FormatBytes(long bytes)
        {
            if (bytes < 1024) return bytes + " B";
            if (bytes < 1024 * 1024) return (bytes / 1024.0).ToString("F1") + " KB";
            return (bytes / (1024.0 * 1024.0)).ToString("F2") + " MB";
        }

        public void addLogMessage(string logMessage, Color? color = null)
        {
            string timeStamp = DateTime.Now.ToString("HH:mm:ss");
            if (_linkToMain.txtLog.InvokeRequired)
            {
                _linkToMain.Invoke((MethodInvoker)delegate
                {
                    InternalAppendLog(timeStamp, logMessage, color);
                });
            }
            else
            {
                InternalAppendLog(timeStamp, logMessage, color);
            }
        }

        private void InternalAppendLog(string timeStamp, string logMessage, Color? color = null)
        {
            _linkToMain.txtLog.SelectionStart = _linkToMain.txtLog.TextLength;
            _linkToMain.txtLog.SelectionLength = 0;
            _linkToMain.txtLog.SelectionColor = Color.Gray;
            _linkToMain.txtLog.AppendText($"[{timeStamp}] ");

            _linkToMain.txtLog.SelectionColor = color ?? Color.FromArgb(230, 235, 240);
            _linkToMain.txtLog.AppendText(logMessage + "\r\n");
            _linkToMain.txtLog.ScrollToCaret();
        }

        public void btnPingClicked()
        {
            _linkToMain.btnPing.Enabled = false;
            _linkToMain.btnSend.Enabled = false;
            _linkToMain.btnPing.Text = "Testing...";

            string server = _linkToMain.cbxServer.Text.Trim();
            if (string.IsNullOrEmpty(server))
            {
                server = "127.0.0.1";
            }

            int port = 25;
            int.TryParse(_linkToMain.txtPort.Text.Trim(), out port);

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate
            {
                addLogMessage($"Initiating connectivity check to {server} (ICMP Ping + TCP Port {port})...");

                try
                {
                    Ping ping = new Ping();
                    PingReply reply = ping.Send(server, 3000);
                    if (reply != null && reply.Status == IPStatus.Success)
                    {
                        addLogMessage($"[ICMP Ping] Success! Address: {reply.Address}, Roundtrip Time: {reply.RoundtripTime} ms", Color.LightGreen);
                    }
                    else
                    {
                        addLogMessage($"[ICMP Ping] Notice: {reply?.Status} (May be blocked by firewall)", Color.Orange);
                    }
                }
                catch (Exception ex)
                {
                    addLogMessage($"[ICMP Ping] Ping exception: {ex.Message}", Color.Orange);
                }

                try
                {
                    using (System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient())
                    {
                        var connectTask = tcp.ConnectAsync(server, port);
                        if (connectTask.Wait(4000))
                        {
                            addLogMessage($"[TCP Port {port}] Connection Successful! Remote server is listening.", Color.LightGreen);
                        }
                        else
                        {
                            addLogMessage($"[TCP Port {port}] Connection Timeout! Remote port did not respond within 4s.", Color.Crimson);
                        }
                    }
                }
                catch (Exception tcpEx)
                {
                    addLogMessage($"[TCP Port {port}] Port connection error: {tcpEx.Message}", Color.Crimson);
                }

                _linkToMain.Invoke((MethodInvoker)delegate
                {
                    _linkToMain.btnPing.Enabled = true;
                    _linkToMain.btnSend.Enabled = true;
                    _linkToMain.btnPing.Text = "Test Connection (Ping)";
                });
            };
            bw.RunWorkerAsync();
        }

        public void StopSending()
        {
            SMTPsender.CancellationRequested = true;
            if (mySendTimer != null) mySendTimer.Enabled = false;

            if (_linkToMain.InvokeRequired)
            {
                _linkToMain.Invoke((MethodInvoker)delegate
                {
                    _linkToMain.btnSend.Enabled = true;
                    _linkToMain.btnPing.Enabled = true;
                    _linkToMain.btnSend.Text = "Send Test Email";
                    _linkToMain.btnStopSend.Enabled = false;
                });
            }
            else
            {
                _linkToMain.btnSend.Enabled = true;
                _linkToMain.btnPing.Enabled = true;
                _linkToMain.btnSend.Text = "Send Test Email";
                _linkToMain.btnStopSend.Enabled = false;
            }

            addLogMessage("[STOPPING] Transmission cancellation requested by user.", Color.OrangeRed);
        }
    }
}
