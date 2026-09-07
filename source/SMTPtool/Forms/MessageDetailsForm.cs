using System;
using System.Drawing;
using System.IO;
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

            string statusStr = item.Success ? "Delivered (Success)" : "Failed";
            if (!string.IsNullOrEmpty(item.TrackingSummary) && item.TrackingSummary != "None")
            {
                statusStr += $"  [{item.TrackingSummary}]";
            }
            lblStatusValue.Text = statusStr;
            lblStatusValue.ForeColor = item.IsClicked ? Color.DeepSkyBlue : (item.IsOpened ? Color.LimeGreen : (item.Success ? Color.ForestGreen : Color.Crimson));

            lblServerValue.Text = $"{item.Server}:{item.Port}";
            lblFromValue.Text = item.FromAddress;
            lblToValue.Text = item.ToAddress;
            lblSubjectValue.Text = item.Subject;
            lblDurationValue.Text = $"{item.DurationSeconds:F2}s";

            txtBodyPreview.Text = item.BodyContent;
            txtRawMime.Text = item.RawMimeContent;

            var sbLog = new System.Text.StringBuilder(item.LogTranscript ?? "");
            if (item.OpenTrackingEnabled)
            {
                sbLog.AppendLine();
                sbLog.AppendLine("----------------- OPEN TRACKING STATUS -----------------");
                sbLog.AppendLine($"Tracking Pixel URL: {item.OpenTrackingUrl}");
                if (item.IsOpened)
                    sbLog.AppendLine($"Status: OPENED by recipient at {item.OpenedTimestamp:yyyy-MM-dd HH:mm:ss} (IP: {item.OpenedIp})");
                else
                    sbLog.AppendLine("Status: PENDING (Message has not been opened yet)");
            }
            if (item.ClickTrackingEnabled)
            {
                sbLog.AppendLine();
                sbLog.AppendLine("----------------- CLICK TRACKING STATUS -----------------");
                sbLog.AppendLine($"Tracked Link URL: {item.ClickTrackingUrl}");
                if (item.IsClicked)
                    sbLog.AppendLine($"Status: CLICKED by recipient at {item.ClickedTimestamp:yyyy-MM-dd HH:mm:ss} (IP: {item.ClickedIp})");
                else
                    sbLog.AppendLine("Status: PENDING (Link has not been clicked yet)");
            }

            txtHandshakeLog.Text = sbLog.ToString();

            this.Text = $"Message Inspector - {item.Subject} ({item.Id})";
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
                        File.WriteAllText(sfd.FileName, item.RawMimeContent, System.Text.Encoding.UTF8);
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
