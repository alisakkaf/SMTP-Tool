namespace SMTPtool.Forms
{
    partial class MessageDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabRawMime;
        private System.Windows.Forms.TabPage tabHandshake;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblServerTitle;
        private System.Windows.Forms.Label lblServerValue;
        private System.Windows.Forms.Label lblFromTitle;
        private System.Windows.Forms.Label lblFromValue;
        private System.Windows.Forms.Label lblToTitle;
        private System.Windows.Forms.Label lblToValue;
        private System.Windows.Forms.Label lblSubjectTitle;
        private System.Windows.Forms.Label lblSubjectValue;
        private System.Windows.Forms.Label lblDurationTitle;
        private System.Windows.Forms.Label lblDurationValue;
        private System.Windows.Forms.TextBox txtBodyPreview;
        private System.Windows.Forms.TextBox txtRawMime;
        private System.Windows.Forms.RichTextBox txtHandshakeLog;
        private System.Windows.Forms.Button btnExportEml;
        private System.Windows.Forms.Button btnCopyMime;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.txtBodyPreview = new System.Windows.Forms.TextBox();
            this.lblDurationValue = new System.Windows.Forms.Label();
            this.lblDurationTitle = new System.Windows.Forms.Label();
            this.lblSubjectValue = new System.Windows.Forms.Label();
            this.lblSubjectTitle = new System.Windows.Forms.Label();
            this.lblToValue = new System.Windows.Forms.Label();
            this.lblToTitle = new System.Windows.Forms.Label();
            this.lblFromValue = new System.Windows.Forms.Label();
            this.lblFromTitle = new System.Windows.Forms.Label();
            this.lblServerValue = new System.Windows.Forms.Label();
            this.lblServerTitle = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.tabRawMime = new System.Windows.Forms.TabPage();
            this.txtRawMime = new System.Windows.Forms.TextBox();
            this.tabHandshake = new System.Windows.Forms.TabPage();
            this.txtHandshakeLog = new System.Windows.Forms.RichTextBox();
            this.btnExportEml = new System.Windows.Forms.Button();
            this.btnCopyMime = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.tabRawMime.SuspendLayout();
            this.tabHandshake.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabOverview);
            this.tabControl.Controls.Add(this.tabRawMime);
            this.tabControl.Controls.Add(this.tabHandshake);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 480);
            this.tabControl.TabIndex = 0;
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.txtBodyPreview);
            this.tabOverview.Controls.Add(this.lblDurationValue);
            this.tabOverview.Controls.Add(this.lblDurationTitle);
            this.tabOverview.Controls.Add(this.lblSubjectValue);
            this.tabOverview.Controls.Add(this.lblSubjectTitle);
            this.tabOverview.Controls.Add(this.lblToValue);
            this.tabOverview.Controls.Add(this.lblToTitle);
            this.tabOverview.Controls.Add(this.lblFromValue);
            this.tabOverview.Controls.Add(this.lblFromTitle);
            this.tabOverview.Controls.Add(this.lblServerValue);
            this.tabOverview.Controls.Add(this.lblServerTitle);
            this.tabOverview.Controls.Add(this.lblStatusValue);
            this.tabOverview.Controls.Add(this.lblStatusTitle);
            this.tabOverview.Location = new System.Drawing.Point(4, 24);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(12);
            this.tabOverview.Size = new System.Drawing.Size(752, 452);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Message Overview";
            this.tabOverview.UseVisualStyleBackColor = true;
            // 
            // txtBodyPreview
            // 
            this.txtBodyPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBodyPreview.BackColor = System.Drawing.Color.White;
            this.txtBodyPreview.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBodyPreview.Location = new System.Drawing.Point(16, 175);
            this.txtBodyPreview.Multiline = true;
            this.txtBodyPreview.Name = "txtBodyPreview";
            this.txtBodyPreview.ReadOnly = true;
            this.txtBodyPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBodyPreview.Size = new System.Drawing.Size(720, 260);
            this.txtBodyPreview.TabIndex = 12;
            // 
            // lblDurationValue
            // 
            this.lblDurationValue.AutoSize = true;
            this.lblDurationValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDurationValue.Location = new System.Drawing.Point(420, 15);
            this.lblDurationValue.Name = "lblDurationValue";
            this.lblDurationValue.Size = new System.Drawing.Size(37, 15);
            this.lblDurationValue.TabIndex = 11;
            this.lblDurationValue.Text = "0.00s";
            // 
            // lblDurationTitle
            // 
            this.lblDurationTitle.AutoSize = true;
            this.lblDurationTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblDurationTitle.Location = new System.Drawing.Point(340, 15);
            this.lblDurationTitle.Name = "lblDurationTitle";
            this.lblDurationTitle.Size = new System.Drawing.Size(56, 15);
            this.lblDurationTitle.TabIndex = 10;
            this.lblDurationTitle.Text = "Duration:";
            // 
            // lblSubjectValue
            // 
            this.lblSubjectValue.AutoSize = true;
            this.lblSubjectValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubjectValue.Location = new System.Drawing.Point(100, 140);
            this.lblSubjectValue.Name = "lblSubjectValue";
            this.lblSubjectValue.Size = new System.Drawing.Size(49, 15);
            this.lblSubjectValue.TabIndex = 9;
            this.lblSubjectValue.Text = "Subject";
            // 
            // lblSubjectTitle
            // 
            this.lblSubjectTitle.AutoSize = true;
            this.lblSubjectTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubjectTitle.Location = new System.Drawing.Point(16, 140);
            this.lblSubjectTitle.Name = "lblSubjectTitle";
            this.lblSubjectTitle.Size = new System.Drawing.Size(49, 15);
            this.lblSubjectTitle.TabIndex = 8;
            this.lblSubjectTitle.Text = "Subject:";
            // 
            // lblToValue
            // 
            this.lblToValue.AutoSize = true;
            this.lblToValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblToValue.Location = new System.Drawing.Point(100, 108);
            this.lblToValue.Name = "lblToValue";
            this.lblToValue.Size = new System.Drawing.Size(89, 15);
            this.lblToValue.TabIndex = 7;
            this.lblToValue.Text = "to@domain.xyz";
            // 
            // lblToTitle
            // 
            this.lblToTitle.AutoSize = true;
            this.lblToTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblToTitle.Location = new System.Drawing.Point(16, 108);
            this.lblToTitle.Name = "lblToTitle";
            this.lblToTitle.Size = new System.Drawing.Size(24, 15);
            this.lblToTitle.TabIndex = 6;
            this.lblToTitle.Text = "To:";
            // 
            // lblFromValue
            // 
            this.lblFromValue.AutoSize = true;
            this.lblFromValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFromValue.Location = new System.Drawing.Point(100, 76);
            this.lblFromValue.Name = "lblFromValue";
            this.lblFromValue.Size = new System.Drawing.Size(104, 15);
            this.lblFromValue.TabIndex = 5;
            this.lblFromValue.Text = "from@domain.xyz";
            // 
            // lblFromTitle
            // 
            this.lblFromTitle.AutoSize = true;
            this.lblFromTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblFromTitle.Location = new System.Drawing.Point(16, 76);
            this.lblFromTitle.Name = "lblFromTitle";
            this.lblFromTitle.Size = new System.Drawing.Size(38, 15);
            this.lblFromTitle.TabIndex = 4;
            this.lblFromTitle.Text = "From:";
            // 
            // lblServerValue
            // 
            this.lblServerValue.AutoSize = true;
            this.lblServerValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblServerValue.Location = new System.Drawing.Point(100, 44);
            this.lblServerValue.Name = "lblServerValue";
            this.lblServerValue.Size = new System.Drawing.Size(95, 15);
            this.lblServerValue.TabIndex = 3;
            this.lblServerValue.Text = "smtp.server:25";
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.AutoSize = true;
            this.lblServerTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblServerTitle.Location = new System.Drawing.Point(16, 44);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Size = new System.Drawing.Size(76, 15);
            this.lblServerTitle.TabIndex = 2;
            this.lblServerTitle.Text = "SMTP Server:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusValue.ForeColor = System.Drawing.Color.Green;
            this.lblStatusValue.Location = new System.Drawing.Point(100, 13);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(126, 17);
            this.lblStatusValue.TabIndex = 1;
            this.lblStatusValue.Text = "Delivered (250 OK)";
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblStatusTitle.Location = new System.Drawing.Point(16, 15);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(42, 15);
            this.lblStatusTitle.TabIndex = 0;
            this.lblStatusTitle.Text = "Status:";
            // 
            // tabRawMime
            // 
            this.tabRawMime.Controls.Add(this.txtRawMime);
            this.tabRawMime.Location = new System.Drawing.Point(4, 24);
            this.tabRawMime.Name = "tabRawMime";
            this.tabRawMime.Padding = new System.Windows.Forms.Padding(12);
            this.tabRawMime.Size = new System.Drawing.Size(752, 452);
            this.tabRawMime.TabIndex = 1;
            this.tabRawMime.Text = "Raw MIME & Headers";
            this.tabRawMime.UseVisualStyleBackColor = true;
            // 
            // txtRawMime
            // 
            this.txtRawMime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtRawMime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRawMime.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRawMime.Location = new System.Drawing.Point(12, 12);
            this.txtRawMime.Multiline = true;
            this.txtRawMime.Name = "txtRawMime";
            this.txtRawMime.ReadOnly = true;
            this.txtRawMime.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRawMime.Size = new System.Drawing.Size(728, 428);
            this.txtRawMime.TabIndex = 0;
            this.txtRawMime.WordWrap = false;
            // 
            // tabHandshake
            // 
            this.tabHandshake.Controls.Add(this.txtHandshakeLog);
            this.tabHandshake.Location = new System.Drawing.Point(4, 24);
            this.tabHandshake.Name = "tabHandshake";
            this.tabHandshake.Padding = new System.Windows.Forms.Padding(12);
            this.tabHandshake.Size = new System.Drawing.Size(752, 452);
            this.tabHandshake.TabIndex = 2;
            this.tabHandshake.Text = "SMTP Handshake Transcript";
            this.tabHandshake.UseVisualStyleBackColor = true;
            // 
            // txtHandshakeLog
            // 
            this.txtHandshakeLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(30)))));
            this.txtHandshakeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHandshakeLog.Font = new System.Drawing.Font("Consolas", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHandshakeLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.txtHandshakeLog.Location = new System.Drawing.Point(12, 12);
            this.txtHandshakeLog.Name = "txtHandshakeLog";
            this.txtHandshakeLog.ReadOnly = true;
            this.txtHandshakeLog.Size = new System.Drawing.Size(728, 428);
            this.txtHandshakeLog.TabIndex = 0;
            this.txtHandshakeLog.Text = "";
            // 
            // btnExportEml
            // 
            this.btnExportEml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportEml.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportEml.Location = new System.Drawing.Point(12, 502);
            this.btnExportEml.Name = "btnExportEml";
            this.btnExportEml.Size = new System.Drawing.Size(120, 30);
            this.btnExportEml.TabIndex = 1;
            this.btnExportEml.Text = "Export As .EML";
            this.btnExportEml.UseVisualStyleBackColor = true;
            this.btnExportEml.Click += new System.EventHandler(this.btnExportEml_Click);
            // 
            // btnCopyMime
            // 
            this.btnCopyMime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyMime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCopyMime.Location = new System.Drawing.Point(140, 502);
            this.btnCopyMime.Name = "btnCopyMime";
            this.btnCopyMime.Size = new System.Drawing.Size(120, 30);
            this.btnCopyMime.TabIndex = 2;
            this.btnCopyMime.Text = "Copy Raw MIME";
            this.btnCopyMime.UseVisualStyleBackColor = true;
            this.btnCopyMime.Click += new System.EventHandler(this.btnCopyMime_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(672, 502);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MessageDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 544);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCopyMime);
            this.Controls.Add(this.btnExportEml);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MessageDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Inspector & Diagnostic Details";
            this.tabControl.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.tabOverview.PerformLayout();
            this.tabRawMime.ResumeLayout(false);
            this.tabRawMime.PerformLayout();
            this.tabHandshake.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
