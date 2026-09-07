using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SMTPtool.Models;

namespace SMTPtool.Forms
{
    public partial class MessageDetailsForm : Form
    {
        private DeliveryHistoryItem item;

        public MessageDetailsForm(DeliveryHistoryItem historyItem)
        {
            InitializeComponent();
            try { this.Icon = Properties.Resources.mailIcon; } catch { }
            this.item = historyItem;
            PopulateData();
        }

        private void PopulateData()
        {
            if (item == null) return;

            // Status
            lblStatusValue.Text = item.Success ? "Delivered (Success)" : "Failed";
            lblStatusValue.ForeColor = item.IsClicked ? Color.FromArgb(37, 99, 235) : (item.IsOpened ? Color.FromArgb(22, 163, 74) : (item.Success ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38)));

            // Duration & Tracking
            lblDurationValue.Text = $"{item.DurationSeconds:F2}s";
            lblTrackingValue.Text = !string.IsNullOrEmpty(item.TrackingSummary) && item.TrackingSummary != "None" ? item.TrackingSummary : "None";
            lblTrackingValue.ForeColor = item.IsClicked ? Color.FromArgb(37, 99, 235) : (item.IsOpened ? Color.FromArgb(22, 163, 74) : Color.FromArgb(100, 116, 139));

            // Connection & Envelope Details
            lblServerValue.Text = $"{item.Server}:{item.Port}";
            lblFromValue.Text = item.FromAddress;
            lblToValue.Text = item.ToAddress;
            lblSubjectValue.Text = item.Subject;

            // Body Content: HTML Preview vs Plain Text Source
            string body = item.BodyContent ?? "";
            txtBodyPreview.Text = body;

            bool isHtml = IsHtmlContent(body) || (!string.IsNullOrEmpty(item.RawMimeContent) && item.RawMimeContent.IndexOf("text/html", StringComparison.OrdinalIgnoreCase) >= 0);
            if (isHtml)
            {
                wbHtmlPreview.DocumentText = body;
                tabBodyViewer.SelectedTab = tabHtmlView;
            }
            else
            {
                wbHtmlPreview.DocumentText = $"<html><body style='font-family:Segoe UI,sans-serif;white-space:pre-wrap;padding:15px;color:#1e293b;background:#f8fafc;'>{System.Net.WebUtility.HtmlEncode(body)}</body></html>";
                tabBodyViewer.SelectedTab = tabSourceView;
            }

            // Raw MIME & Structured Headers Table
            txtRawMime.Text = item.RawMimeContent ?? "";
            PopulateHeadersGrid(item.RawMimeContent);

            // Handshake transcript
            var sbLog = new System.Text.StringBuilder(item.LogTranscript ?? "");
            if (item.OpenTrackingEnabled)
            {
                sbLog.AppendLine();
                sbLog.AppendLine("----------------- OPEN TRACKING STATUS -----------------");
                sbLog.AppendLine($"Tracking Pixel URL: {item.OpenTrackingUrl}");
                if (item.IsOpened)
                    sbLog.AppendLine($"Status: 🟢 OPENED by recipient at {item.OpenedTimestamp:yyyy-MM-dd HH:mm:ss} (IP: {item.OpenedIp})");
                else
                    sbLog.AppendLine("Status: ⏳ PENDING (Message has not been opened yet)");
            }
            if (item.ClickTrackingEnabled)
            {
                sbLog.AppendLine();
                sbLog.AppendLine("----------------- CLICK TRACKING STATUS -----------------");
                sbLog.AppendLine($"Tracked Link URL: {item.ClickTrackingUrl}");
                if (item.IsClicked)
                    sbLog.AppendLine($"Status: 🔵 CLICKED by recipient at {item.ClickedTimestamp:yyyy-MM-dd HH:mm:ss} (IP: {item.ClickedIp})");
                else
                    sbLog.AppendLine("Status: ⏳ PENDING (Link has not been clicked yet)");
            }

            txtHandshakeLog.Text = sbLog.ToString();
            this.Text = $"Message Inspector - {item.Subject} ({item.Id})";
        }

        private bool IsHtmlContent(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            string trimmed = input.Trim();
            if (trimmed.StartsWith("<!DOCTYPE", StringComparison.OrdinalIgnoreCase) ||
                trimmed.StartsWith("<html", StringComparison.OrdinalIgnoreCase))
                return true;

            string[] markers = new[] { "<div", "<p>", "<p ", "<table", "<body", "<span", "<a href", "</html" };
            int count = 0;
            foreach (var m in markers)
            {
                if (input.IndexOf(m, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    count++;
                    if (count >= 2) return true;
                }
            }
            return false;
        }

        private void PopulateHeadersGrid(string rawMime)
        {
            dgvHeaders.Rows.Clear();
            if (string.IsNullOrWhiteSpace(rawMime))
            {
                // Fallback default envelope headers
                if (item != null)
                {
                    dgvHeaders.Rows.Add("Date", item.Timestamp.ToString("r"));
                    dgvHeaders.Rows.Add("From", item.FromAddress);
                    dgvHeaders.Rows.Add("To", item.ToAddress);
                    dgvHeaders.Rows.Add("Subject", item.Subject);
                    dgvHeaders.Rows.Add("X-Mailer", "SMTP Tool by AliSakkaF (v1.0)");
                    if (!string.IsNullOrEmpty(item.OpenTrackingUrl)) dgvHeaders.Rows.Add("X-Open-Tracking-Url", item.OpenTrackingUrl);
                    if (!string.IsNullOrEmpty(item.ClickTrackingUrl)) dgvHeaders.Rows.Add("X-Click-Tracking-Url", item.ClickTrackingUrl);
                }
                return;
            }

            try
            {
                using (StringReader reader = new StringReader(rawMime))
                {
                    string line;
                    string currentKey = null;
                    string currentValue = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            // Empty line marks end of MIME headers
                            break;
                        }

                        // Header continuation (folding) starts with space or tab
                        if ((line.StartsWith(" ") || line.StartsWith("\t")) && currentKey != null)
                        {
                            currentValue += " " + line.Trim();
                            continue;
                        }

                        // Flush previous header
                        if (currentKey != null)
                        {
                            dgvHeaders.Rows.Add(currentKey, currentValue);
                            currentKey = null;
                            currentValue = "";
                        }

                        int colonIdx = line.IndexOf(':');
                        if (colonIdx > 0)
                        {
                            currentKey = line.Substring(0, colonIdx).Trim();
                            currentValue = line.Substring(colonIdx + 1).Trim();
                        }
                    }

                    if (currentKey != null)
                    {
                        dgvHeaders.Rows.Add(currentKey, currentValue);
                    }
                }
            }
            catch
            {
                // In case of parsing exception, fallback safely
                if (item != null)
                {
                    dgvHeaders.Rows.Add("From", item.FromAddress);
                    dgvHeaders.Rows.Add("To", item.ToAddress);
                    dgvHeaders.Rows.Add("Subject", item.Subject);
                }
            }
        }

        private void btnExportEml_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "EML Email Files (*.eml)|*.eml|All Files (*.*)|*.*";
                sfd.FileName = $"Message_{item.Id}.eml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, item.RawMimeContent ?? item.BodyContent, System.Text.Encoding.UTF8);
                        MessageBox.Show("Message exported successfully as .EML", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving EML file: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCopyMime_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRawMime.Text))
            {
                Clipboard.SetText(txtRawMime.Text);
                MessageBox.Show("Raw MIME content copied to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
