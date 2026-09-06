using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMTPtool.Forms;
using SMTPtool.helper;
using SMTPtool.Models;
using SMTPtool.Services;
using System.Xml.Linq;

namespace SMTPtool
{
    public partial class Main : Form
    {
        public static string CURRENT_VERSION = "1.0";
        public const string AUTHOR_NAME = "AliSakkaF";
        public const string AUTHOR_WEBSITE = "https://alisakkaf.com";
        public const string AUTHOR_FACEBOOK = "https://www.facebook.com/AliSakkaf.Dev";
        public const string GITHUB_REPO_URL = "https://github.com/alisakkaf/SMTP-Tool";

        public XMLparser myParser;
        public MailTab mailTab;
        public RemailTab remailTab;
        public SessionTab sessionTab;
        public ProfileManager profileManager;
        public TrackingServer trackingServer;
        private ContextMenuStrip cmsHistory;

        public int histSize = 15;
        public List<string> serverList = new List<string>();
        public List<string> mailFromList = new List<string>();
        public List<string> mailToList = new List<string>();
        public List<DeliveryHistoryItem> historyList = new List<DeliveryHistoryItem>();

        public Main()
        {
            InitializeComponent();

            this.Text = "SMTP Tool - Professional Email Testing Suite (v1.0) | AliSakkaF";

            profileManager = new ProfileManager();
            trackingServer = new TrackingServer();
            trackingServer.MessageOpened += OnMessageOpened;
            trackingServer.MessageClicked += OnMessageClicked;

            mailTab = new MailTab(this);
            remailTab = new RemailTab(this);
            sessionTab = new SessionTab(this);

            myParser = new XMLparser(this);
            myParser.loadMainXML();

            PopulateProfilesDropdown();
            InitHistoryContextMenu();

            if (cbxSecurityMode.SelectedIndex < 0) cbxSecurityMode.SelectedIndex = 0;
            if (cbxPriority.SelectedIndex < 0) cbxPriority.SelectedIndex = 0;

            Task.Run(async () => await PerformUpdateCheckAsync());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadDeliveryHistory();
            trackingServer.Start();
            mailTab.addLogMessage($"SMTP Tool v{CURRENT_VERSION} initialized successfully. Ready for diagnostics.", Color.LightSkyBlue);
            if (trackingServer.IsRunning)
            {
                mailTab.addLogMessage($"[LIVE TRACKING] Tracking listener active on port {trackingServer.Port} (Host: {trackingServer.GetEffectiveHost()})", Color.SpringGreen);
            }
            mailTab.addLogMessage($"Author: {AUTHOR_NAME} | Website: {AUTHOR_WEBSITE} | GitHub: {GITHUB_REPO_URL}", Color.DarkGray);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            trackingServer?.Stop();
            SaveDeliveryHistory();
        }

        #region Profile Management

        private void PopulateProfilesDropdown()
        {
            cbxProfile.Items.Clear();
            foreach (var p in profileManager.Profiles)
            {
                cbxProfile.Items.Add(p);
            }
            if (cbxProfile.Items.Count > 0)
            {
                cbxProfile.SelectedIndex = 0;
            }
        }

        private void cbxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbxProfile.SelectedItem as ServerProfile;
            if (selected == null) return;

            cbxServer.Text = selected.ServerHost;
            txtPort.Text = selected.Port.ToString();
            cbxSecurityMode.SelectedIndex = (int)selected.SecurityMode;
            chbRequiresAuth.Checked = selected.RequiresAuthentication;
            txtUsername.Text = selected.Username ?? "";
            txtPassword.Text = selected.Password ?? "";

            if (!string.IsNullOrEmpty(selected.FromEmail)) cbxFrom.Text = selected.FromEmail;
            if (!string.IsNullOrEmpty(selected.FromName)) txtFromName.Text = selected.FromName;
            if (!string.IsNullOrEmpty(selected.ReplyTo)) txtReplyTo.Text = selected.ReplyTo;
            if (!string.IsNullOrEmpty(selected.ToEmail)) cbxTo.Text = selected.ToEmail;
            if (!string.IsNullOrEmpty(selected.Subject)) txtSubject.Text = selected.Subject;
            if (!string.IsNullOrEmpty(selected.Body)) txtBody.Text = selected.Body;
            chbIsHtml.Checked = selected.IsHtml;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string profileName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter a name for this server profile:",
                "Save Server Profile",
                cbxProfile.Text
            );

            if (string.IsNullOrWhiteSpace(profileName)) return;

            int port;
            if (!int.TryParse(txtPort.Text.Trim(), out port)) port = 25;

            var profile = new ServerProfile
            {
                ProfileName = profileName.Trim(),
                ServerHost = cbxServer.Text.Trim(),
                Port = port,
                SecurityMode = GetSelectedSecurityMode(),
                RequiresAuthentication = chbRequiresAuth.Checked,
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                FromEmail = cbxFrom.Text.Trim(),
                FromName = txtFromName.Text.Trim(),
                ReplyTo = txtReplyTo.Text.Trim(),
                ToEmail = cbxTo.Text.Trim(),
                CcEmail = txtCc.Text.Trim(),
                BccEmail = txtBcc.Text.Trim(),
                Subject = txtSubject.Text,
                Body = txtBody.Text,
                IsHtml = chbIsHtml.Checked
            };

            profileManager.AddOrUpdateProfile(profile);
            PopulateProfilesDropdown();

            for (int i = 0; i < cbxProfile.Items.Count; i++)
            {
                var p = cbxProfile.Items[i] as ServerProfile;
                if (p != null && p.ProfileName.Equals(profile.ProfileName, StringComparison.OrdinalIgnoreCase))
                {
                    cbxProfile.SelectedIndex = i;
                    break;
                }
            }

            MessageBox.Show($"Profile '{profileName}' saved successfully!", "Profile Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            var selected = cbxProfile.SelectedItem as ServerProfile;
            if (selected == null) return;

            if (cbxProfile.SelectedIndex < 5)
            {
                MessageBox.Show("Built-in standard server presets cannot be deleted.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete profile '{selected.ProfileName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                profileManager.DeleteProfile(selected.ProfileName);
                PopulateProfilesDropdown();
            }
        }

        #endregion

        #region Port & Security Helpers

        private void btnPortQuick_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (btn == btnPort25)
            {
                txtPort.Text = "25";
                cbxSecurityMode.SelectedIndex = (int)SslSecurityMode.None;
            }
            else if (btn == btnPort465)
            {
                txtPort.Text = "465";
                cbxSecurityMode.SelectedIndex = (int)SslSecurityMode.SslTls;
            }
            else if (btn == btnPort587)
            {
                txtPort.Text = "587";
                cbxSecurityMode.SelectedIndex = (int)SslSecurityMode.StartTls;
            }
            else if (btn == btnPort2525)
            {
                txtPort.Text = "2525";
                cbxSecurityMode.SelectedIndex = (int)SslSecurityMode.Auto;
            }
        }

        public SslSecurityMode GetSelectedSecurityMode()
        {
            int idx = cbxSecurityMode.SelectedIndex;
            if (idx < 0 || idx > 3) return SslSecurityMode.Auto;
            return (SslSecurityMode)idx;
        }

        public MailPriority GetSelectedPriority()
        {
            switch (cbxPriority.Text)
            {
                case "High": return MailPriority.High;
                case "Low": return MailPriority.Low;
                default: return MailPriority.Normal;
            }
        }

        private void chbRequiresAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = chbRequiresAuth.Checked;
            txtPassword.Enabled = chbRequiresAuth.Checked;
            chbShowPassword.Enabled = chbRequiresAuth.Checked;
        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chbShowPassword.Checked;
        }

        private void chbIsHtml_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIsHtml.Checked && tabBodyControl.SelectedTab == tabBodyPreview)
            {
                wbPreview.DocumentText = txtBody.Text;
            }
        }

        private void tabBodyControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabBodyControl.SelectedTab == tabBodyPreview)
            {
                wbPreview.DocumentText = txtBody.Text;
            }
        }

        #endregion

        #region Send & Transmission Callbacks

        private void btnSend_Click(object sender, EventArgs e)
        {
            mailTab.btnSendClicked();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            mailTab.btnPingClicked();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            mailTab.btnAttachClicked();
        }

        private void btnDelAttachment_Click(object sender, EventArgs e)
        {
            mailTab.btnDelAttachmentClicked();
        }

        private void btnDelAttachmentAll_Click(object sender, EventArgs e)
        {
            mailTab.btnDelAttachmentAllClicked();
        }

        private void chbSaveInOutbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSaveInOutbox.Checked)
            {
                nrcCount.Value = 1;
                nrcThreadCount.Value = 1;
                nrcCount.Enabled = false;
                nrcThreadCount.Enabled = false;
            }
            else
            {
                nrcCount.Enabled = true;
                nrcThreadCount.Enabled = true;
            }
        }

        public void OnMessageSentCompleted(SmtpSendResult result)
        {

            if (result.Success)
            {
                mailTab.addLogMessage($"[SUCCESS] Message sent in {result.TotalDuration.TotalSeconds:F2}s - {result.Message}", Color.LightGreen);
            }
            else
            {
                mailTab.addLogMessage($"[FAILED] {result.Message}", Color.Crimson);
            }

            if (chkShowFullLog.Checked && !string.IsNullOrEmpty(result.Transcript))
            {
                mailTab.addLogMessage("----------------- SMTP PROTOCOL TRANSCRIPT -----------------", Color.Cyan);
                string[] lines = result.Transcript.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    Color lineCol = Color.WhiteSmoke;
                    if (line.Contains("[ERROR]") || line.Contains("Failed")) lineCol = Color.Crimson;
                    else if (line.Contains("[STEP") || line.Contains("250 OK") || line.Contains("Successfully")) lineCol = Color.LightGreen;
                    else if (line.Contains("Initiating") || line.Contains("Security") || line.Contains("Auth")) lineCol = Color.SkyBlue;
                    mailTab.addLogMessage("  " + line, lineCol);
                }
                mailTab.addLogMessage("------------------------------------------------------------", Color.Cyan);
            }

            if (result.HistoryItem != null)
            {
                historyList.Insert(0, result.HistoryItem);

                ListViewItem lvi = new ListViewItem(result.HistoryItem.Success ? "Delivered" : "Failed");
                lvi.ForeColor = result.HistoryItem.Success ? Color.ForestGreen : Color.Crimson;
                lvi.Tag = result.HistoryItem;
                lvi.SubItems.Add(result.HistoryItem.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi.SubItems.Add(result.HistoryItem.ToAddress);
                lvi.SubItems.Add(result.HistoryItem.FromAddress);
                lvi.SubItems.Add(result.HistoryItem.Subject);
                lvi.SubItems.Add($"{result.HistoryItem.Server}:{result.HistoryItem.Port}");
                lvi.SubItems.Add($"{result.HistoryItem.DurationSeconds:F2}s");
                lvi.SubItems.Add(result.HistoryItem.TrackingSummary);
                lvi.SubItems.Add(result.HistoryItem.StatusMessage);

                lvHistory.Items.Insert(0, lvi);
                SaveDeliveryHistory();
            }

            mailTab.numberOfMessagesSent++;
            if (mailTab.numberOfMessagesSent >= mailTab.numberOfMessagesToSend)
            {
                btnPing.Enabled = true;
                btnSend.Enabled = true;
                btnSend.Text = "Send Test Email";
                if (mailTab.mySendTimer != null) mailTab.mySendTimer.Enabled = false;
            }
        }

        public void notifyAboutSentMessage(string result, TimeSpan duration)
        {
            if (result.Equals("success", StringComparison.OrdinalIgnoreCase))
            {
                mailTab.addLogMessage($"Message sent successfully in {Math.Round(duration.TotalSeconds, 2)} seconds.", Color.LightGreen);
            }
            else
            {
                mailTab.addLogMessage(result, Color.Crimson);
            }

            mailTab.numberOfMessagesSent++;
            if (mailTab.numberOfMessagesSent >= mailTab.numberOfMessagesToSend)
            {
                btnPing.Enabled = true;
                btnSend.Enabled = true;
                btnSend.Text = "Send Test Email";
                if (mailTab.mySendTimer != null) mailTab.mySendTimer.Enabled = false;
            }
        }

        #endregion

        #region Delivery History Handlers

        private void lvHistory_DoubleClick(object sender, EventArgs e)
        {
            InspectSelectedHistoryItem();
        }

        private void btnInspectHistory_Click(object sender, EventArgs e)
        {
            InspectSelectedHistoryItem();
        }

        private void InspectSelectedHistoryItem()
        {
            if (lvHistory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a message from the history list to inspect.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = lvHistory.SelectedItems[0].Tag as DeliveryHistoryItem;
            if (item != null)
            {
                using (var dlg = new MessageDetailsForm(item))
                {
                    dlg.ShowDialog(this);
                }
            }
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all message delivery history?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                historyList.Clear();
                lvHistory.Items.Clear();
                SaveDeliveryHistory();
            }
        }

        private void btnExportHistory_Click(object sender, EventArgs e)
        {
            if (historyList.Count == 0)
            {
                MessageBox.Show("No message history available to export.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                FileName = $"SMTPTool_History_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("ID,Status,Timestamp,Server,Port,From,To,Subject,DurationSeconds,Response");
                        foreach (var item in historyList)
                        {
                            sb.AppendLine($"\"{item.Id}\",\"{(item.Success ? "Success" : "Failed")}\",\"{item.Timestamp:yyyy-MM-dd HH:mm:ss}\",\"{item.Server}\",{item.Port},\"{item.FromAddress}\",\"{item.ToAddress}\",\"{item.Subject.Replace("\"", "\"\"")}\",{item.DurationSeconds},\"{item.StatusMessage.Replace("\"", "\"\"")}\"");
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Delivery history exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting CSV: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static readonly string HistoryFilePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetEntryAssembly() != null ? Assembly.GetEntryAssembly().Location : AppDomain.CurrentDomain.BaseDirectory),
            "delivery_history.xml"
        );

        public void SaveDeliveryHistory()
        {
            try
            {
                XElement root = new XElement("history");
                foreach (var item in historyList)
                {
                    XElement elem = new XElement("item",
                        new XAttribute("id", item.Id ?? ""),
                        new XElement("success", item.Success),
                        new XElement("timestamp", item.Timestamp.ToString("o")),
                        new XElement("server", item.Server ?? ""),
                        new XElement("port", item.Port),
                        new XElement("from", item.FromAddress ?? ""),
                        new XElement("to", item.ToAddress ?? ""),
                        new XElement("subject", item.Subject ?? ""),
                        new XElement("duration", item.DurationSeconds),
                        new XElement("status", item.StatusMessage ?? ""),
                        new XElement("receipt", item.DeliveryReceiptRequested),
                        new XElement("isDelivered", item.IsDelivered),
                        new XElement("deliveredAt", item.DeliveredTimestamp.HasValue ? item.DeliveredTimestamp.Value.ToString("o") : ""),
                        new XElement("openEnabled", item.OpenTrackingEnabled),
                        new XElement("isOpened", item.IsOpened),
                        new XElement("openedAt", item.OpenedTimestamp.HasValue ? item.OpenedTimestamp.Value.ToString("o") : ""),
                        new XElement("openedIp", item.OpenedIp ?? ""),
                        new XElement("openUrl", item.OpenTrackingUrl ?? ""),
                        new XElement("clickEnabled", item.ClickTrackingEnabled),
                        new XElement("isClicked", item.IsClicked),
                        new XElement("clickedAt", item.ClickedTimestamp.HasValue ? item.ClickedTimestamp.Value.ToString("o") : ""),
                        new XElement("clickedIp", item.ClickedIp ?? ""),
                        new XElement("clickUrl", item.ClickTrackingUrl ?? ""),
                        new XElement("isHtml", item.IsHtml),
                        new XElement("attachments", item.AttachmentCount),
                        new XElement("log", item.LogTranscript ?? ""),
                        new XElement("body", item.BodyContent ?? ""),
                        new XElement("mime", item.RawMimeContent ?? "")
                    );
                    root.Add(elem);
                }
                XDocument doc = new XDocument(root);
                doc.Save(HistoryFilePath);
            }
            catch { }
        }

        public void LoadDeliveryHistory()
        {
            try
            {
                if (!File.Exists(HistoryFilePath)) return;
                XDocument doc = XDocument.Load(HistoryFilePath);
                if (doc.Root == null) return;

                historyList.Clear();
                lvHistory.Items.Clear();

                foreach (var elem in doc.Root.Elements("item"))
                {
                    var item = new DeliveryHistoryItem
                    {
                        Id = elem.Attribute("id") != null ? elem.Attribute("id").Value : Guid.NewGuid().ToString("N").Substring(0, 8),
                        Success = elem.Element("success") != null && bool.Parse(elem.Element("success").Value),
                        Timestamp = elem.Element("timestamp") != null ? DateTime.Parse(elem.Element("timestamp").Value) : DateTime.Now,
                        Server = elem.Element("server") != null ? elem.Element("server").Value : "",
                        Port = elem.Element("port") != null ? int.Parse(elem.Element("port").Value) : 25,
                        FromAddress = elem.Element("from") != null ? elem.Element("from").Value : "",
                        ToAddress = elem.Element("to") != null ? elem.Element("to").Value : "",
                        Subject = elem.Element("subject") != null ? elem.Element("subject").Value : "",
                        DurationSeconds = elem.Element("duration") != null ? double.Parse(elem.Element("duration").Value) : 0.0,
                        StatusMessage = elem.Element("status") != null ? elem.Element("status").Value : "",
                        DeliveryReceiptRequested = elem.Element("receipt") != null && bool.Parse(elem.Element("receipt").Value),
                        IsDelivered = elem.Element("isDelivered") != null ? bool.Parse(elem.Element("isDelivered").Value) : (elem.Element("success") != null && bool.Parse(elem.Element("success").Value)),
                        DeliveredTimestamp = elem.Element("deliveredAt") != null && !string.IsNullOrEmpty(elem.Element("deliveredAt").Value) ? (DateTime?)DateTime.Parse(elem.Element("deliveredAt").Value) : null,
                        OpenTrackingEnabled = elem.Element("openEnabled") != null ? bool.Parse(elem.Element("openEnabled").Value) : (elem.Element("openTrack") != null && bool.Parse(elem.Element("openTrack").Value)),
                        IsOpened = elem.Element("isOpened") != null && bool.Parse(elem.Element("isOpened").Value),
                        OpenedTimestamp = elem.Element("openedAt") != null && !string.IsNullOrEmpty(elem.Element("openedAt").Value) ? (DateTime?)DateTime.Parse(elem.Element("openedAt").Value) : null,
                        OpenedIp = elem.Element("openedIp") != null ? elem.Element("openedIp").Value : "",
                        OpenTrackingUrl = elem.Element("openUrl") != null ? elem.Element("openUrl").Value : "",
                        ClickTrackingEnabled = elem.Element("clickEnabled") != null ? bool.Parse(elem.Element("clickEnabled").Value) : (elem.Element("clickTrack") != null && bool.Parse(elem.Element("clickTrack").Value)),
                        IsClicked = elem.Element("isClicked") != null && bool.Parse(elem.Element("isClicked").Value),
                        ClickedTimestamp = elem.Element("clickedAt") != null && !string.IsNullOrEmpty(elem.Element("clickedAt").Value) ? (DateTime?)DateTime.Parse(elem.Element("clickedAt").Value) : null,
                        ClickedIp = elem.Element("clickedIp") != null ? elem.Element("clickedIp").Value : "",
                        ClickTrackingUrl = elem.Element("clickUrl") != null ? elem.Element("clickUrl").Value : "",
                        IsHtml = elem.Element("isHtml") != null && bool.Parse(elem.Element("isHtml").Value),
                        AttachmentCount = elem.Element("attachments") != null ? int.Parse(elem.Element("attachments").Value) : 0,
                        LogTranscript = elem.Element("log") != null ? elem.Element("log").Value : "",
                        BodyContent = elem.Element("body") != null ? elem.Element("body").Value : "",
                        RawMimeContent = elem.Element("mime") != null ? elem.Element("mime").Value : ""
                    };

                    historyList.Add(item);

                    ListViewItem lvi = new ListViewItem(item.Success ? "Delivered" : "Failed");
                    if (item.IsClicked)
                        lvi.ForeColor = Color.DeepSkyBlue;
                    else if (item.IsOpened)
                        lvi.ForeColor = Color.LimeGreen;
                    else if (item.Success)
                        lvi.ForeColor = Color.ForestGreen;
                    else
                        lvi.ForeColor = Color.Crimson;

                    lvi.Tag = item;
                    lvi.SubItems.Add(item.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.SubItems.Add(item.ToAddress);
                    lvi.SubItems.Add(item.FromAddress);
                    lvi.SubItems.Add(item.Subject);
                    lvi.SubItems.Add($"{item.Server}:{item.Port}");
                    lvi.SubItems.Add($"{item.DurationSeconds:F2}s");
                    lvi.SubItems.Add(item.TrackingSummary);
                    lvi.SubItems.Add(item.StatusMessage);

                    lvHistory.Items.Add(lvi);
                }
            }
            catch { }
        }

        private void OnMessageOpened(string messageId, string clientIp, DateTime timestamp)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate { OnMessageOpened(messageId, clientIp, timestamp); });
                return;
            }

            var item = historyList.FirstOrDefault(x => x.Id.Equals(messageId, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.IsOpened = true;
                item.OpenedTimestamp = timestamp;
                item.OpenedIp = clientIp;

                UpdateHistoryListViewItem(item);
                SaveDeliveryHistory();

                mailTab.addLogMessage($"[LIVE TRACKING] Email '{item.Subject}' was OPENED by recipient ({item.ToAddress}) at {timestamp:HH:mm:ss} from IP {clientIp}!", Color.LimeGreen);
            }
        }

        private void OnMessageClicked(string messageId, string clientIp, DateTime timestamp, string targetUrl)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate { OnMessageClicked(messageId, clientIp, timestamp, targetUrl); });
                return;
            }

            var item = historyList.FirstOrDefault(x => x.Id.Equals(messageId, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.IsClicked = true;
                item.ClickedTimestamp = timestamp;
                item.ClickedIp = clientIp;

                UpdateHistoryListViewItem(item);
                SaveDeliveryHistory();

                mailTab.addLogMessage($"[LIVE TRACKING] Link in email '{item.Subject}' was CLICKED by recipient ({item.ToAddress}) at {timestamp:HH:mm:ss} from IP {clientIp}! (Destination: {targetUrl})", Color.DeepSkyBlue);
            }
        }

        public void UpdateHistoryListViewItem(DeliveryHistoryItem item)
        {
            foreach (ListViewItem lvi in lvHistory.Items)
            {
                if (lvi.Tag == item || (lvi.Tag is DeliveryHistoryItem d && d.Id == item.Id))
                {
                    if (lvi.SubItems.Count > 7)
                    {
                        lvi.SubItems[7].Text = item.TrackingSummary;
                    }
                    if (item.IsClicked)
                    {
                        lvi.ForeColor = Color.DeepSkyBlue;
                    }
                    else if (item.IsOpened)
                    {
                        lvi.ForeColor = Color.LimeGreen;
                    }
                    else if (item.Success)
                    {
                        lvi.ForeColor = Color.ForestGreen;
                    }
                    else
                    {
                        lvi.ForeColor = Color.Crimson;
                    }
                    break;
                }
            }
        }

        private void InitHistoryContextMenu()
        {
            cmsHistory = new ContextMenuStrip();

            var miSimulateOpen = new ToolStripMenuItem("Simulate \"Message Opened\"", null, (s, e) =>
            {
                if (lvHistory.SelectedItems.Count > 0 && lvHistory.SelectedItems[0].Tag is DeliveryHistoryItem item)
                {
                    OnMessageOpened(item.Id, "127.0.0.1 (Manual Test)", DateTime.Now);
                }
            });

            var miSimulateClick = new ToolStripMenuItem("Simulate \"Link Clicked\"", null, (s, e) =>
            {
                if (lvHistory.SelectedItems.Count > 0 && lvHistory.SelectedItems[0].Tag is DeliveryHistoryItem item)
                {
                    OnMessageClicked(item.Id, "127.0.0.1 (Manual Test)", DateTime.Now, "https://alisakkaf.com");
                }
            });

            var miOpenPixelInBrowser = new ToolStripMenuItem("Open Tracking Pixel in Browser", null, (s, e) =>
            {
                if (lvHistory.SelectedItems.Count > 0 && lvHistory.SelectedItems[0].Tag is DeliveryHistoryItem item && !string.IsNullOrEmpty(item.OpenTrackingUrl))
                {
                    try { Process.Start(item.OpenTrackingUrl); } catch (Exception ex) { MessageBox.Show("Error opening browser: " + ex.Message); }
                }
            });

            var miOpenClickInBrowser = new ToolStripMenuItem("Open Click Link in Browser", null, (s, e) =>
            {
                if (lvHistory.SelectedItems.Count > 0 && lvHistory.SelectedItems[0].Tag is DeliveryHistoryItem item && !string.IsNullOrEmpty(item.ClickTrackingUrl))
                {
                    try { Process.Start(item.ClickTrackingUrl); } catch (Exception ex) { MessageBox.Show("Error opening browser: " + ex.Message); }
                }
            });

            var miCopyPixel = new ToolStripMenuItem("Copy Tracking Pixel URL", null, (s, e) =>
            {
                if (lvHistory.SelectedItems.Count > 0 && lvHistory.SelectedItems[0].Tag is DeliveryHistoryItem item && !string.IsNullOrEmpty(item.OpenTrackingUrl))
                {
                    Clipboard.SetText(item.OpenTrackingUrl);
                    MessageBox.Show("Open tracking pixel URL copied to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });

            var miCopyClick = new ToolStripMenuItem("Copy Click URL", null, (s, e) =>
            {
                if (lvHistory.SelectedItems.Count > 0 && lvHistory.SelectedItems[0].Tag is DeliveryHistoryItem item && !string.IsNullOrEmpty(item.ClickTrackingUrl))
                {
                    Clipboard.SetText(item.ClickTrackingUrl);
                    MessageBox.Show("Click tracking URL copied to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });

            var miInspect = new ToolStripMenuItem("Inspect Details...", null, (s, e) =>
            {
                InspectSelectedHistoryItem();
            });

            var miResend = new ToolStripMenuItem("Resend This Message", null, (s, e) =>
            {
                if (lvHistory.SelectedItems.Count > 0 && lvHistory.SelectedItems[0].Tag is DeliveryHistoryItem item)
                {
                    cbxServer.Text = item.Server;
                    txtPort.Text = item.Port.ToString();
                    cbxFrom.Text = item.FromAddress;
                    cbxTo.Text = item.ToAddress;
                    txtSubject.Text = item.Subject;
                    txtBody.Text = item.BodyContent;
                    chbIsHtml.Checked = item.IsHtml;
                    tabBodyControl.SelectedTab = tabBodyText;
                    smtpTabPage.SelectedTab = mailTabPage;
                }
            });

            cmsHistory.Items.Add(miSimulateOpen);
            cmsHistory.Items.Add(miSimulateClick);
            cmsHistory.Items.Add(new ToolStripSeparator());
            cmsHistory.Items.Add(miOpenPixelInBrowser);
            cmsHistory.Items.Add(miOpenClickInBrowser);
            cmsHistory.Items.Add(new ToolStripSeparator());
            cmsHistory.Items.Add(miCopyPixel);
            cmsHistory.Items.Add(miCopyClick);
            cmsHistory.Items.Add(new ToolStripSeparator());
            cmsHistory.Items.Add(miInspect);
            cmsHistory.Items.Add(miResend);

            lvHistory.ContextMenuStrip = cmsHistory;
        }

        #endregion

        #region Remailer & Templates Handlers

        private void btnRemail_Click(object sender, EventArgs e)
        {
            remailTab.btnRemailClicked();
        }

        private void btnRemailSaveMail_Click(object sender, EventArgs e)
        {
            remailTab.btnSaveClicked();
        }

        private void chkFormatTemplateView_CheckedChanged(object sender, EventArgs e)
        {
            remailTab?.ToggleTemplateFormatting(chkFormatTemplateView.Checked);
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            remailTab.btnOpenFolderClicked();
        }

        #endregion

        #region Interactive Session Handlers

        private void btnSessionConnect_Click(object sender, EventArgs e)
        {
            if (sessionTab.isConnected)
            {
                sessionTab.reconnect();
            }
            else
            {
                sessionTab.connect();
                sessionTab.isConnected = true;
            }
        }

        private void btnSessionOpenNewWindow_Click(object sender, EventArgs e)
        {
            sessionTab.startSessionInNewWindow();
        }

        private void btnSessionSendLine_Click(object sender, EventArgs e)
        {
            sessionTab.btnSendLine_Click();
        }

        private void btnSessionHelo_Click(object sender, EventArgs e)
        {
            sessionTab.btnHelo_Click();
        }

        private void btnSessionStartTls_Click(object sender, EventArgs e)
        {
            txtSessionCommand.Text = "STARTTLS";
            sessionTab.btnSendLine_Click();
        }

        private void btnSessionAuth_Click(object sender, EventArgs e)
        {
            txtSessionCommand.Text = "AUTH LOGIN";
            sessionTab.btnSendLine_Click();
        }

        private void btnSessionFrom_Click(object sender, EventArgs e)
        {
            sessionTab.btnFrom_Click();
        }

        private void btnSessionRcpt_Click(object sender, EventArgs e)
        {
            sessionTab.btnRcpt_Click();
        }

        private void btnSessionData_Click(object sender, EventArgs e)
        {
            sessionTab.btnData_Click();
        }

        private void btnSessionDot_Click(object sender, EventArgs e)
        {
            sessionTab.btnDot_Click();
        }

        private void btnSessionReset_Click(object sender, EventArgs e)
        {
            sessionTab.btnReset_Click();
        }

        private void btnSessionQuit_Click(object sender, EventArgs e)
        {
            sessionTab.btnQuit_Click();
        }

        private void btnSessionResend_Click(object sender, EventArgs e)
        {
            sessionTab.btnResend_Click();
        }

        private void btnSessionClearCommand_Click(object sender, EventArgs e)
        {
            sessionTab.btnClearCommand_Click();
        }

        #endregion

        #region Status Strip & Updates

        private async Task PerformUpdateCheckAsync()
        {
            var update = await UpdateChecker.CheckForUpdatesAsync();
            this.Invoke((MethodInvoker)delegate
            {
                if (update.IsNewVersionAvailable)
                {
                    statusLabel.Text = $"Update Available: v{update.LatestVersion}!";
                    statusLabel.ForeColor = Color.Crimson;
                    btnCheckUpdates.Text = "[ Download v" + update.LatestVersion + " ]";
                    btnCheckUpdates.ForeColor = Color.Crimson;
                }
                else
                {
                    statusLabel.Text = $"SMTP Tool v{CURRENT_VERSION} | Up To Date";
                    statusLabel.ForeColor = Color.ForestGreen;
                    btnCheckUpdates.Text = "[ Check For Updates ]";
                }
            });
        }

        private async void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            btnCheckUpdates.Text = "[ Checking... ]";
            var update = await UpdateChecker.CheckForUpdatesAsync();
            if (update.IsNewVersionAvailable)
            {
                if (MessageBox.Show($"A new version (v{update.LatestVersion}) of SMTP Tool is available!\n\nWould you like to open GitHub releases to download it?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start(update.ReleaseUrl);
                }
            }
            else
            {
                MessageBox.Show($"You are using the latest version of SMTP Tool (v{CURRENT_VERSION}).", "Up To Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnCheckUpdates.Text = "[ Check For Updates ]";
        }

        private void statusLabelMail_Click(object sender, EventArgs e)
        {
            try { Process.Start(AUTHOR_FACEBOOK); } catch { }
        }

        private void statusLabelLink_Click(object sender, EventArgs e)
        {
            try { Process.Start(AUTHOR_WEBSITE); } catch { }
        }

        #endregion

        #region History Dropdown Management

        public void addServerToList(string server)
        {
            if (string.IsNullOrEmpty(server)) return;
            serverList.Remove(server);
            serverList.Insert(0, server);
            if (serverList.Count > histSize) serverList.RemoveAt(histSize);

            cbxServer.DataSource = null;
            cbxServer.DataSource = serverList;
            cbxServer.Text = server;

            cbxRemailIP.DataSource = null;
            cbxRemailIP.DataSource = serverList;

            cbxSessionServer.DataSource = null;
            cbxSessionServer.DataSource = serverList;
        }

        public void addMailFromtoList(string mailFrom)
        {
            if (string.IsNullOrEmpty(mailFrom)) return;
            mailFromList.Remove(mailFrom);
            mailFromList.Insert(0, mailFrom);
            if (mailFromList.Count > histSize) mailFromList.RemoveAt(histSize);

            cbxFrom.DataSource = null;
            cbxFrom.DataSource = mailFromList;
            cbxFrom.Text = mailFrom;

            cbxRemailFrom.DataSource = null;
            cbxRemailFrom.DataSource = mailFromList;

            cbxSessionFrom.DataSource = null;
            cbxSessionFrom.DataSource = mailFromList;
        }

        public void addRcptToToList(string rcptTo)
        {
            if (string.IsNullOrEmpty(rcptTo)) return;
            mailToList.Remove(rcptTo);
            mailToList.Insert(0, rcptTo);
            if (mailToList.Count > histSize) mailToList.RemoveAt(histSize);

            cbxTo.DataSource = null;
            cbxTo.DataSource = mailToList;
            cbxTo.Text = rcptTo;

            cbxRemailTo.DataSource = null;
            cbxRemailTo.DataSource = mailToList;

            cbxSessionTo.DataSource = null;
            cbxSessionTo.DataSource = mailToList;
        }

        #endregion
    }
}
