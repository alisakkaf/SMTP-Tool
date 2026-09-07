using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SMTPtool.Properties;
using SMTPtool.Services;

namespace SMTPtool.Forms
{
    public enum UpdateAction
    {
        Download,
        Later,
        Skip
    }

    public class UpdateNotificationForm : Form
    {
        public UpdateAction ResultAction { get; private set; } = UpdateAction.Later;
        private readonly UpdateInfo updateInfo;

        public UpdateNotificationForm(UpdateInfo info)
        {
            this.updateInfo = info ?? new UpdateInfo();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Update Available - SMTP Tool";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(500, 240);
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            try
            {
                if (Properties.Resources.mailIcon != null)
                {
                    this.Icon = Properties.Resources.mailIcon;
                }
                else if (Main.ActiveForm != null && Main.ActiveForm.Icon != null)
                {
                    this.Icon = Main.ActiveForm.Icon;
                }
            }
            catch { }

            // Icon picture
            PictureBox picIcon = new PictureBox
            {
                Location = new Point(24, 24),
                Size = new Size(48, 48),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            try
            {
                if (this.Icon != null)
                {
                    picIcon.Image = this.Icon.ToBitmap();
                }
            }
            catch { }

            // Title Label
            Label lblHeader = new Label
            {
                Location = new Point(88, 20),
                Size = new Size(390, 26),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Text = "New Update Available!"
            };

            // Version Comparison Box
            Panel pnlVersion = new Panel
            {
                Location = new Point(88, 52),
                Size = new Size(385, 34),
                BackColor = Color.FromArgb(241, 245, 249),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblVersion = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Padding = new Padding(8, 0, 0, 0),
                Text = $"Current: {updateInfo.CurrentVersion}   ➔   Latest: {updateInfo.LatestVersion}"
            };
            pnlVersion.Controls.Add(lblVersion);

            // Description Label
            Label lblDesc = new Label
            {
                Location = new Point(88, 96),
                Size = new Size(385, 60),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(71, 85, 105),
                Text = "A new version of SMTP Tool is available on GitHub with enhanced features, performance improvements, and bug fixes.\n\nWould you like to open the release page to download it?"
            };

            // Bottom action panel
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.FromArgb(241, 245, 249)
            };

            Button btnDownload = new Button
            {
                Text = "Yes, Download",
                Location = new Point(140, 14),
                Size = new Size(115, 32),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.Click += (s, e) =>
            {
                ResultAction = UpdateAction.Download;
                try
                {
                    string targetUrl = !string.IsNullOrEmpty(updateInfo.ReleaseUrl) ? updateInfo.ReleaseUrl : "https://github.com/alisakkaf/SMTP-Tool/releases";
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = targetUrl,
                        UseShellExecute = true
                    });
                }
                catch { }
                this.Close();
            };

            Button btnLater = new Button
            {
                Text = "No, Later",
                Location = new Point(265, 14),
                Size = new Size(95, 32),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLater.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnLater.Click += (s, e) =>
            {
                ResultAction = UpdateAction.Later;
                this.Close();
            };

            Button btnSkip = new Button
            {
                Text = "Skip Version",
                Location = new Point(370, 14),
                Size = new Size(105, 32),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(100, 116, 139),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSkip.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnSkip.Click += (s, e) =>
            {
                ResultAction = UpdateAction.Skip;
                this.Close();
            };

            pnlActions.Controls.Add(btnDownload);
            pnlActions.Controls.Add(btnLater);
            pnlActions.Controls.Add(btnSkip);

            this.Controls.Add(picIcon);
            this.Controls.Add(lblHeader);
            this.Controls.Add(pnlVersion);
            this.Controls.Add(lblDesc);
            this.Controls.Add(pnlActions);

            this.AcceptButton = btnDownload;
            this.CancelButton = btnLater;
        }
    }
}
