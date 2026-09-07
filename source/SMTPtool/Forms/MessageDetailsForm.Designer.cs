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
        private System.Windows.Forms.Label lblTrackingTitle;
        private System.Windows.Forms.Label lblTrackingValue;
        private System.Windows.Forms.TabControl tabBodyViewer;
        private System.Windows.Forms.TabPage tabHtmlView;
        private System.Windows.Forms.TabPage tabSourceView;
        private System.Windows.Forms.WebBrowser wbHtmlPreview;
        private System.Windows.Forms.TextBox txtBodyPreview;
        private System.Windows.Forms.SplitContainer splitHeaders;
        private System.Windows.Forms.DataGridView dgvHeaders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderValue;
        private System.Windows.Forms.Label lblHeadersGridTitle;
        private System.Windows.Forms.Label lblRawMimeTitle;
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.tabBodyViewer = new System.Windows.Forms.TabControl();
            this.tabHtmlView = new System.Windows.Forms.TabPage();
            this.wbHtmlPreview = new System.Windows.Forms.WebBrowser();
            this.tabSourceView = new System.Windows.Forms.TabPage();
            this.txtBodyPreview = new System.Windows.Forms.TextBox();
            this.lblTrackingValue = new System.Windows.Forms.Label();
            this.lblTrackingTitle = new System.Windows.Forms.Label();
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
            this.splitHeaders = new System.Windows.Forms.SplitContainer();
            this.lblHeadersGridTitle = new System.Windows.Forms.Label();
            this.dgvHeaders = new System.Windows.Forms.DataGridView();
            this.colHeaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeaderValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRawMimeTitle = new System.Windows.Forms.Label();
            this.txtRawMime = new System.Windows.Forms.TextBox();
            this.tabHandshake = new System.Windows.Forms.TabPage();
            this.txtHandshakeLog = new System.Windows.Forms.RichTextBox();
            this.btnExportEml = new System.Windows.Forms.Button();
            this.btnCopyMime = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.tabBodyViewer.SuspendLayout();
            this.tabHtmlView.SuspendLayout();
            this.tabSourceView.SuspendLayout();
            this.tabRawMime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitHeaders)).BeginInit();
            this.splitHeaders.Panel1.SuspendLayout();
            this.splitHeaders.Panel2.SuspendLayout();
            this.splitHeaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaders)).BeginInit();
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
            this.tabControl.Size = new System.Drawing.Size(810, 520);
            this.tabControl.TabIndex = 0;
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.tabBodyViewer);
            this.tabOverview.Controls.Add(this.lblTrackingValue);
            this.tabOverview.Controls.Add(this.lblTrackingTitle);
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
            this.tabOverview.Size = new System.Drawing.Size(802, 492);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Message Overview";
            this.tabOverview.UseVisualStyleBackColor = true;
            // 
            // tabBodyViewer
            // 
            this.tabBodyViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBodyViewer.Controls.Add(this.tabHtmlView);
            this.tabBodyViewer.Controls.Add(this.tabSourceView);
            this.tabBodyViewer.Location = new System.Drawing.Point(16, 160);
            this.tabBodyViewer.Name = "tabBodyViewer";
            this.tabBodyViewer.SelectedIndex = 0;
            this.tabBodyViewer.Size = new System.Drawing.Size(770, 318);
            this.tabBodyViewer.TabIndex = 14;
            // 
            // tabHtmlView
            // 
            this.tabHtmlView.Controls.Add(this.wbHtmlPreview);
            this.tabHtmlView.Location = new System.Drawing.Point(4, 24);
            this.tabHtmlView.Name = "tabHtmlView";
            this.tabHtmlView.Padding = new System.Windows.Forms.Padding(3);
            this.tabHtmlView.Size = new System.Drawing.Size(762, 290);
            this.tabHtmlView.TabIndex = 0;
            this.tabHtmlView.Text = "🌐 Rendered HTML Preview";
            this.tabHtmlView.UseVisualStyleBackColor = true;
            // 
            // wbHtmlPreview
            // 
            this.wbHtmlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHtmlPreview.Location = new System.Drawing.Point(3, 3);
            this.wbHtmlPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHtmlPreview.Name = "wbHtmlPreview";
            this.wbHtmlPreview.Size = new System.Drawing.Size(756, 284);
            this.wbHtmlPreview.TabIndex = 0;
            // 
            // tabSourceView
            // 
            this.tabSourceView.Controls.Add(this.txtBodyPreview);
            this.tabSourceView.Location = new System.Drawing.Point(4, 24);
            this.tabSourceView.Name = "tabSourceView";
            this.tabSourceView.Padding = new System.Windows.Forms.Padding(3);
            this.tabSourceView.Size = new System.Drawing.Size(762, 290);
            this.tabSourceView.TabIndex = 1;
            this.tabSourceView.Text = "📄 Plain Text / Raw Source";
            this.tabSourceView.UseVisualStyleBackColor = true;
            // 
            // txtBodyPreview
            // 
            this.txtBodyPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtBodyPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBodyPreview.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtBodyPreview.Location = new System.Drawing.Point(3, 3);
            this.txtBodyPreview.Multiline = true;
            this.txtBodyPreview.Name = "txtBodyPreview";
            this.txtBodyPreview.ReadOnly = true;
            this.txtBodyPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBodyPreview.Size = new System.Drawing.Size(756, 284);
            this.txtBodyPreview.TabIndex = 12;
            // 
            // lblTrackingValue
            // 
            this.lblTrackingValue.AutoSize = true;
            this.lblTrackingValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrackingValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTrackingValue.Location = new System.Drawing.Point(540, 42);
            this.lblTrackingValue.Name = "lblTrackingValue";
            this.lblTrackingValue.Size = new System.Drawing.Size(37, 15);
            this.lblTrackingValue.TabIndex = 13;
            this.lblTrackingValue.Text = "None";
            // 
            // lblTrackingTitle
            // 
            this.lblTrackingTitle.AutoSize = true;
            this.lblTrackingTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackingTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTrackingTitle.Location = new System.Drawing.Point(465, 42);
            this.lblTrackingTitle.Name = "lblTrackingTitle";
            this.lblTrackingTitle.Size = new System.Drawing.Size(55, 15);
            this.lblTrackingTitle.TabIndex = 12;
            this.lblTrackingTitle.Text = "Tracking:";
            // 
            // lblDurationValue
            // 
            this.lblDurationValue.AutoSize = true;
            this.lblDurationValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDurationValue.Location = new System.Drawing.Point(540, 15);
            this.lblDurationValue.Name = "lblDurationValue";
            this.lblDurationValue.Size = new System.Drawing.Size(37, 15);
            this.lblDurationValue.TabIndex = 11;
            this.lblDurationValue.Text = "0.00s";
            // 
            // lblDurationTitle
            // 
            this.lblDurationTitle.AutoSize = true;
            this.lblDurationTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurationTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblDurationTitle.Location = new System.Drawing.Point(465, 15);
            this.lblDurationTitle.Name = "lblDurationTitle";
            this.lblDurationTitle.Size = new System.Drawing.Size(56, 15);
            this.lblDurationTitle.TabIndex = 10;
            this.lblDurationTitle.Text = "Duration:";
            // 
            // lblSubjectValue
            // 
            this.lblSubjectValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubjectValue.AutoEllipsis = true;
            this.lblSubjectValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubjectValue.Location = new System.Drawing.Point(85, 126);
            this.lblSubjectValue.Name = "lblSubjectValue";
            this.lblSubjectValue.Size = new System.Drawing.Size(700, 20);
            this.lblSubjectValue.TabIndex = 9;
            this.lblSubjectValue.Text = "Subject";
            // 
            // lblSubjectTitle
            // 
            this.lblSubjectTitle.AutoSize = true;
            this.lblSubjectTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubjectTitle.Location = new System.Drawing.Point(16, 126);
            this.lblSubjectTitle.Name = "lblSubjectTitle";
            this.lblSubjectTitle.Size = new System.Drawing.Size(49, 15);
            this.lblSubjectTitle.TabIndex = 8;
            this.lblSubjectTitle.Text = "Subject:";
            // 
            // lblToValue
            // 
            this.lblToValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToValue.AutoEllipsis = true;
            this.lblToValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblToValue.Location = new System.Drawing.Point(85, 98);
            this.lblToValue.Name = "lblToValue";
            this.lblToValue.Size = new System.Drawing.Size(700, 20);
            this.lblToValue.TabIndex = 7;
            this.lblToValue.Text = "recipient@example.com";
            // 
            // lblToTitle
            // 
            this.lblToTitle.AutoSize = true;
            this.lblToTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblToTitle.Location = new System.Drawing.Point(16, 98);
            this.lblToTitle.Name = "lblToTitle";
            this.lblToTitle.Size = new System.Drawing.Size(24, 15);
            this.lblToTitle.TabIndex = 6;
            this.lblToTitle.Text = "To:";
            // 
            // lblFromValue
            // 
            this.lblFromValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromValue.AutoEllipsis = true;
            this.lblFromValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFromValue.Location = new System.Drawing.Point(85, 70);
            this.lblFromValue.Name = "lblFromValue";
            this.lblFromValue.Size = new System.Drawing.Size(700, 20);
            this.lblFromValue.TabIndex = 5;
            this.lblFromValue.Text = "sender@example.com";
            // 
            // lblFromTitle
            // 
            this.lblFromTitle.AutoSize = true;
            this.lblFromTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblFromTitle.Location = new System.Drawing.Point(16, 70);
            this.lblFromTitle.Name = "lblFromTitle";
            this.lblFromTitle.Size = new System.Drawing.Size(38, 15);
            this.lblFromTitle.TabIndex = 4;
            this.lblFromTitle.Text = "From:";
            // 
            // lblServerValue
            // 
            this.lblServerValue.AutoSize = true;
            this.lblServerValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblServerValue.Location = new System.Drawing.Point(85, 42);
            this.lblServerValue.Name = "lblServerValue";
            this.lblServerValue.Size = new System.Drawing.Size(64, 15);
            this.lblServerValue.TabIndex = 3;
            this.lblServerValue.Text = "127.0.0.1:25";
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.AutoSize = true;
            this.lblServerTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblServerTitle.Location = new System.Drawing.Point(16, 42);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Size = new System.Drawing.Size(42, 15);
            this.lblServerTitle.TabIndex = 2;
            this.lblServerTitle.Text = "Server:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStatusValue.Location = new System.Drawing.Point(85, 14);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(126, 17);
            this.lblStatusValue.TabIndex = 1;
            this.lblStatusValue.Text = "Delivered (Success)";
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
            this.tabRawMime.Controls.Add(this.splitHeaders);
            this.tabRawMime.Location = new System.Drawing.Point(4, 24);
            this.tabRawMime.Name = "tabRawMime";
            this.tabRawMime.Padding = new System.Windows.Forms.Padding(12);
            this.tabRawMime.Size = new System.Drawing.Size(802, 492);
            this.tabRawMime.TabIndex = 1;
            this.tabRawMime.Text = "Headers Table & Raw MIME";
            this.tabRawMime.UseVisualStyleBackColor = true;
            // 
            // splitHeaders
            // 
            this.splitHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHeaders.Location = new System.Drawing.Point(12, 12);
            this.splitHeaders.Name = "splitHeaders";
            this.splitHeaders.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitHeaders.Panel1
            // 
            this.splitHeaders.Panel1.Controls.Add(this.lblHeadersGridTitle);
            this.splitHeaders.Panel1.Controls.Add(this.dgvHeaders);
            // 
            // splitHeaders.Panel2
            // 
            this.splitHeaders.Panel2.Controls.Add(this.lblRawMimeTitle);
            this.splitHeaders.Panel2.Controls.Add(this.txtRawMime);
            this.splitHeaders.Size = new System.Drawing.Size(778, 468);
            this.splitHeaders.SplitterDistance = 210;
            this.splitHeaders.TabIndex = 1;
            // 
            // lblHeadersGridTitle
            // 
            this.lblHeadersGridTitle.AutoSize = true;
            this.lblHeadersGridTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeadersGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblHeadersGridTitle.Location = new System.Drawing.Point(3, 4);
            this.lblHeadersGridTitle.Name = "lblHeadersGridTitle";
            this.lblHeadersGridTitle.Size = new System.Drawing.Size(201, 15);
            this.lblHeadersGridTitle.TabIndex = 1;
            this.lblHeadersGridTitle.Text = "📋 Parsed MIME Headers (Structured)";
            // 
            // dgvHeaders
            // 
            this.dgvHeaders.AllowUserToAddRows = false;
            this.dgvHeaders.AllowUserToDeleteRows = false;
            this.dgvHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHeaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHeaders.BackgroundColor = System.Drawing.Color.White;
            this.dgvHeaders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHeaderName,
            this.colHeaderValue});
            this.dgvHeaders.Location = new System.Drawing.Point(0, 24);
            this.dgvHeaders.Name = "dgvHeaders";
            this.dgvHeaders.ReadOnly = true;
            this.dgvHeaders.RowHeadersVisible = false;
            this.dgvHeaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeaders.Size = new System.Drawing.Size(778, 183);
            this.dgvHeaders.TabIndex = 0;
            // 
            // colHeaderName
            // 
            this.colHeaderName.FillWeight = 35F;
            this.colHeaderName.HeaderText = "Header Field";
            this.colHeaderName.Name = "colHeaderName";
            this.colHeaderName.ReadOnly = true;
            // 
            // colHeaderValue
            // 
            this.colHeaderValue.FillWeight = 65F;
            this.colHeaderValue.HeaderText = "Value";
            this.colHeaderValue.Name = "colHeaderValue";
            this.colHeaderValue.ReadOnly = true;
            // 
            // lblRawMimeTitle
            // 
            this.lblRawMimeTitle.AutoSize = true;
            this.lblRawMimeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRawMimeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblRawMimeTitle.Location = new System.Drawing.Point(3, 4);
            this.lblRawMimeTitle.Name = "lblRawMimeTitle";
            this.lblRawMimeTitle.Size = new System.Drawing.Size(193, 15);
            this.lblRawMimeTitle.TabIndex = 2;
            this.lblRawMimeTitle.Text = "📝 Complete Raw RFC 5322 MIME";
            // 
            // txtRawMime
            // 
            this.txtRawMime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRawMime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtRawMime.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtRawMime.Location = new System.Drawing.Point(0, 24);
            this.txtRawMime.Multiline = true;
            this.txtRawMime.Name = "txtRawMime";
            this.txtRawMime.ReadOnly = true;
            this.txtRawMime.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRawMime.Size = new System.Drawing.Size(778, 230);
            this.txtRawMime.TabIndex = 0;
            // 
            // tabHandshake
            // 
            this.tabHandshake.Controls.Add(this.txtHandshakeLog);
            this.tabHandshake.Location = new System.Drawing.Point(4, 24);
            this.tabHandshake.Name = "tabHandshake";
            this.tabHandshake.Padding = new System.Windows.Forms.Padding(12);
            this.tabHandshake.Size = new System.Drawing.Size(802, 492);
            this.tabHandshake.TabIndex = 2;
            this.tabHandshake.Text = "SMTP Handshake Transcript";
            this.tabHandshake.UseVisualStyleBackColor = true;
            // 
            // txtHandshakeLog
            // 
            this.txtHandshakeLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.txtHandshakeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHandshakeLog.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtHandshakeLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.txtHandshakeLog.Location = new System.Drawing.Point(12, 12);
            this.txtHandshakeLog.Name = "txtHandshakeLog";
            this.txtHandshakeLog.ReadOnly = true;
            this.txtHandshakeLog.Size = new System.Drawing.Size(778, 468);
            this.txtHandshakeLog.TabIndex = 0;
            this.txtHandshakeLog.Text = "";
            // 
            // btnExportEml
            // 
            this.btnExportEml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportEml.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportEml.Location = new System.Drawing.Point(16, 540);
            this.btnExportEml.Name = "btnExportEml";
            this.btnExportEml.Size = new System.Drawing.Size(125, 30);
            this.btnExportEml.TabIndex = 1;
            this.btnExportEml.Text = "Export As .EML";
            this.btnExportEml.UseVisualStyleBackColor = true;
            this.btnExportEml.Click += new System.EventHandler(this.btnExportEml_Click);
            // 
            // btnCopyMime
            // 
            this.btnCopyMime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyMime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCopyMime.Location = new System.Drawing.Point(150, 540);
            this.btnCopyMime.Name = "btnCopyMime";
            this.btnCopyMime.Size = new System.Drawing.Size(125, 30);
            this.btnCopyMime.TabIndex = 2;
            this.btnCopyMime.Text = "Copy Raw MIME";
            this.btnCopyMime.UseVisualStyleBackColor = true;
            this.btnCopyMime.Click += new System.EventHandler(this.btnCopyMime_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(717, 540);
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
            this.ClientSize = new System.Drawing.Size(834, 582);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCopyMime);
            this.Controls.Add(this.btnExportEml);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 520);
            this.Name = "MessageDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Inspector";
            this.tabControl.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.tabOverview.PerformLayout();
            this.tabBodyViewer.ResumeLayout(false);
            this.tabHtmlView.ResumeLayout(false);
            this.tabSourceView.ResumeLayout(false);
            this.tabSourceView.PerformLayout();
            this.tabRawMime.ResumeLayout(false);
            this.splitHeaders.Panel1.ResumeLayout(false);
            this.splitHeaders.Panel1.PerformLayout();
            this.splitHeaders.Panel2.ResumeLayout(false);
            this.splitHeaders.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitHeaders)).EndInit();
            this.splitHeaders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaders)).EndInit();
            this.tabHandshake.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
