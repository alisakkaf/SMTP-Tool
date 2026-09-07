namespace SMTPtool
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

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
            this.smtpTabPage = new System.Windows.Forms.TabControl();
            this.mailTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxProfile = new System.Windows.Forms.ComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.cbxServer = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnPort25 = new System.Windows.Forms.Button();
            this.btnPort465 = new System.Windows.Forms.Button();
            this.btnPort587 = new System.Windows.Forms.Button();
            this.btnPort2525 = new System.Windows.Forms.Button();
            this.lblSecurity = new System.Windows.Forms.Label();
            this.cbxSecurityMode = new System.Windows.Forms.ComboBox();
            this.chbRequiresAuth = new System.Windows.Forms.CheckBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chbShowPassword = new System.Windows.Forms.CheckBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cbxFrom = new System.Windows.Forms.ComboBox();
            this.lblFromName = new System.Windows.Forms.Label();
            this.txtFromName = new System.Windows.Forms.TextBox();
            this.lblReplyTo = new System.Windows.Forms.Label();
            this.txtReplyTo = new System.Windows.Forms.TextBox();
            this.lvlTo = new System.Windows.Forms.Label();
            this.cbxTo = new System.Windows.Forms.ComboBox();
            this.lblCc = new System.Windows.Forms.Label();
            this.txtCc = new System.Windows.Forms.TextBox();
            this.lblBcc = new System.Windows.Forms.Label();
            this.txtBcc = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cbxPriority = new System.Windows.Forms.ComboBox();
            this.chbIsHtml = new System.Windows.Forms.CheckBox();
            this.chbOpenTracking = new System.Windows.Forms.CheckBox();
            this.chbClickTracking = new System.Windows.Forms.CheckBox();
            this.chbReadReceipt = new System.Windows.Forms.CheckBox();
            this.chbSaveInOutbox = new System.Windows.Forms.CheckBox();
            this.groupBoxBody = new System.Windows.Forms.GroupBox();
            this.tabBodyControl = new System.Windows.Forms.TabControl();
            this.tabBodyText = new System.Windows.Forms.TabPage();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.tabBodyPreview = new System.Windows.Forms.TabPage();
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.lbAttachments = new System.Windows.Forms.ListBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnDelAttachment = new System.Windows.Forms.Button();
            this.btnDelAttachmentAll = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.nrcCount = new System.Windows.Forms.NumericUpDown();
            this.lblThreadCount = new System.Windows.Forms.Label();
            this.nrcThreadCount = new System.Windows.Forms.NumericUpDown();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnStopSend = new System.Windows.Forms.Button();
            this.btnLogMaximizePreview = new System.Windows.Forms.Button();
            this.btnLogReset = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkShowFullLog = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTracking = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInspectHistory = new System.Windows.Forms.Button();
            this.btnExportHistory = new System.Windows.Forms.Button();
            this.btnRefreshHistory = new System.Windows.Forms.Button();
            this.lblTrackingHost = new System.Windows.Forms.Label();
            this.txtTrackingHost = new System.Windows.Forms.TextBox();
            this.btnDetectPublicIp = new System.Windows.Forms.Button();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.RemailTabPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRemailIP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemailPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxRemailFrom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxRemailTo = new System.Windows.Forms.ComboBox();
            this.btnRemail = new System.Windows.Forms.Button();
            this.btnStopRemail = new System.Windows.Forms.Button();
            this.btnSyncRemail = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.treeViewMails = new System.Windows.Forms.TreeView();
            this.txtMailView = new System.Windows.Forms.TextBox();
            this.txtRemailOutput = new System.Windows.Forms.RichTextBox();
            this.btnRemailSaveMail = new System.Windows.Forms.Button();
            this.chkFormatTemplateView = new System.Windows.Forms.CheckBox();
            this.lblRemailSize = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSessionServer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxSessionPort = new System.Windows.Forms.TextBox();
            this.btnSessionConnect = new System.Windows.Forms.Button();
            this.btnSessionDisconnect = new System.Windows.Forms.Button();
            this.btnSessionSync = new System.Windows.Forms.Button();
            this.btnSessionOpenNewWindow = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnSessionHelo = new System.Windows.Forms.Button();
            this.btnSessionStartTls = new System.Windows.Forms.Button();
            this.btnSessionAuth = new System.Windows.Forms.Button();
            this.btnSessionFrom = new System.Windows.Forms.Button();
            this.btnSessionRcpt = new System.Windows.Forms.Button();
            this.btnSessionData = new System.Windows.Forms.Button();
            this.btnSessionDot = new System.Windows.Forms.Button();
            this.btnSessionReset = new System.Windows.Forms.Button();
            this.btnSessionQuit = new System.Windows.Forms.Button();
            this.cbxSessionFrom = new System.Windows.Forms.ComboBox();
            this.cbxSessionTo = new System.Windows.Forms.ComboBox();
            this.txtSessionEhlo = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lbxSessionHistory = new System.Windows.Forms.ListBox();
            this.btnSessionResend = new System.Windows.Forms.Button();
            this.btnSessionClearCommand = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtSessionOutput = new System.Windows.Forms.RichTextBox();
            this.txtSessionCommand = new System.Windows.Forms.TextBox();
            this.btnSessionSendLine = new System.Windows.Forms.Button();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelAuthorInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelMail = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelUpdateInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipUpdateStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCheckUpdates = new System.Windows.Forms.ToolStripStatusLabel();
            this.smtpTabPage.SuspendLayout();
            this.mailTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxBody.SuspendLayout();
            this.tabBodyControl.SuspendLayout();
            this.tabBodyText.SuspendLayout();
            this.tabBodyPreview.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrcCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrcThreadCount)).BeginInit();
            this.tabHistory.SuspendLayout();
            this.RemailTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // smtpTabPage
            // 
            this.smtpTabPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smtpTabPage.Controls.Add(this.mailTabPage);
            this.smtpTabPage.Controls.Add(this.tabHistory);
            this.smtpTabPage.Controls.Add(this.RemailTabPage);
            this.smtpTabPage.Controls.Add(this.tabPage1);
            this.smtpTabPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpTabPage.ItemSize = new System.Drawing.Size(140, 26);
            this.smtpTabPage.Location = new System.Drawing.Point(8, 8);
            this.smtpTabPage.Name = "smtpTabPage";
            this.smtpTabPage.SelectedIndex = 0;
            this.smtpTabPage.Size = new System.Drawing.Size(968, 694);
            this.smtpTabPage.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.smtpTabPage.TabIndex = 0;
            // 
            // mailTabPage
            // 
            this.mailTabPage.AutoScroll = true;
            this.mailTabPage.Controls.Add(this.groupBox1);
            this.mailTabPage.Controls.Add(this.groupBox2);
            this.mailTabPage.Controls.Add(this.groupBoxBody);
            this.mailTabPage.Controls.Add(this.groupBox3);
            this.mailTabPage.Location = new System.Drawing.Point(4, 30);
            this.mailTabPage.Name = "mailTabPage";
            this.mailTabPage.Padding = new System.Windows.Forms.Padding(6);
            this.mailTabPage.Size = new System.Drawing.Size(960, 660);
            this.mailTabPage.TabIndex = 0;
            this.mailTabPage.Text = "Send & Test Email";
            this.mailTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbxProfile);
            this.groupBox1.Controls.Add(this.lblProfile);
            this.groupBox1.Controls.Add(this.btnSaveProfile);
            this.groupBox1.Controls.Add(this.btnDeleteProfile);
            this.groupBox1.Controls.Add(this.lblServer);
            this.groupBox1.Controls.Add(this.cbxServer);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.btnPort25);
            this.groupBox1.Controls.Add(this.btnPort465);
            this.groupBox1.Controls.Add(this.btnPort587);
            this.groupBox1.Controls.Add(this.btnPort2525);
            this.groupBox1.Controls.Add(this.lblSecurity);
            this.groupBox1.Controls.Add(this.cbxSecurityMode);
            this.groupBox1.Controls.Add(this.chbRequiresAuth);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.lblPass);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.chbShowPassword);
            this.groupBox1.Controls.Add(this.btnPing);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(938, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server & Connection Settings";
            // 
            // cbxProfile
            // 
            this.cbxProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxProfile.FormattingEnabled = true;
            this.cbxProfile.Location = new System.Drawing.Point(90, 22);
            this.cbxProfile.Name = "cbxProfile";
            this.cbxProfile.Size = new System.Drawing.Size(200, 23);
            this.cbxProfile.TabIndex = 1;
            this.cbxProfile.SelectedIndexChanged += new System.EventHandler(this.cbxProfile_SelectedIndexChanged);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfile.Location = new System.Drawing.Point(12, 25);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(74, 15);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.Text = "Server Preset:";
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSaveProfile.Location = new System.Drawing.Point(296, 21);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(85, 25);
            this.btnSaveProfile.TabIndex = 2;
            this.btnSaveProfile.Text = "Save Profile";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDeleteProfile.Location = new System.Drawing.Point(385, 21);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(90, 25);
            this.btnDeleteProfile.TabIndex = 3;
            this.btnDeleteProfile.Text = "Delete Profile";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServer.Location = new System.Drawing.Point(12, 55);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(75, 15);
            this.lblServer.TabIndex = 4;
            this.lblServer.Text = "SMTP Server:";
            // 
            // cbxServer
            // 
            this.cbxServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxServer.FormattingEnabled = true;
            this.cbxServer.Location = new System.Drawing.Point(90, 52);
            this.cbxServer.Name = "cbxServer";
            this.cbxServer.Size = new System.Drawing.Size(200, 23);
            this.cbxServer.TabIndex = 5;
            this.cbxServer.Text = "127.0.0.1";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPort.Location = new System.Drawing.Point(298, 55);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 15);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPort.Location = new System.Drawing.Point(334, 52);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(46, 23);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "25";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPort25
            // 
            this.btnPort25.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPort25.Location = new System.Drawing.Point(385, 51);
            this.btnPort25.Name = "btnPort25";
            this.btnPort25.Size = new System.Drawing.Size(60, 25);
            this.btnPort25.TabIndex = 8;
            this.btnPort25.Text = "25 SMTP";
            this.btnPort25.UseVisualStyleBackColor = true;
            this.btnPort25.Click += new System.EventHandler(this.btnPortQuick_Click);
            // 
            // btnPort465
            // 
            this.btnPort465.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPort465.Location = new System.Drawing.Point(448, 51);
            this.btnPort465.Name = "btnPort465";
            this.btnPort465.Size = new System.Drawing.Size(58, 25);
            this.btnPort465.TabIndex = 9;
            this.btnPort465.Text = "465 SSL";
            this.btnPort465.UseVisualStyleBackColor = true;
            this.btnPort465.Click += new System.EventHandler(this.btnPortQuick_Click);
            // 
            // btnPort587
            // 
            this.btnPort587.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPort587.Location = new System.Drawing.Point(509, 51);
            this.btnPort587.Name = "btnPort587";
            this.btnPort587.Size = new System.Drawing.Size(76, 25);
            this.btnPort587.TabIndex = 10;
            this.btnPort587.Text = "587 TLS";
            this.btnPort587.UseVisualStyleBackColor = true;
            this.btnPort587.Click += new System.EventHandler(this.btnPortQuick_Click);
            // 
            // btnPort2525
            // 
            this.btnPort2525.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPort2525.Location = new System.Drawing.Point(588, 51);
            this.btnPort2525.Name = "btnPort2525";
            this.btnPort2525.Size = new System.Drawing.Size(62, 25);
            this.btnPort2525.TabIndex = 11;
            this.btnPort2525.Text = "2525 Alt";
            this.btnPort2525.UseVisualStyleBackColor = true;
            this.btnPort2525.Click += new System.EventHandler(this.btnPortQuick_Click);
            // 
            // lblSecurity
            // 
            this.lblSecurity.AutoSize = true;
            this.lblSecurity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSecurity.Location = new System.Drawing.Point(658, 55);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(52, 15);
            this.lblSecurity.TabIndex = 12;
            this.lblSecurity.Text = "Security:";
            // 
            // cbxSecurityMode
            // 
            this.cbxSecurityMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecurityMode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxSecurityMode.FormattingEnabled = true;
            this.cbxSecurityMode.Items.AddRange(new object[] {
            "Auto Detect",
            "None (Plain)",
            "SSL / TLS (Implicit)",
            "STARTTLS (Explicit)"});
            this.cbxSecurityMode.Location = new System.Drawing.Point(716, 52);
            this.cbxSecurityMode.Name = "cbxSecurityMode";
            this.cbxSecurityMode.Size = new System.Drawing.Size(140, 23);
            this.cbxSecurityMode.TabIndex = 13;
            // 
            // chbRequiresAuth
            // 
            this.chbRequiresAuth.AutoSize = true;
            this.chbRequiresAuth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chbRequiresAuth.Location = new System.Drawing.Point(14, 88);
            this.chbRequiresAuth.Name = "chbRequiresAuth";
            this.chbRequiresAuth.Size = new System.Drawing.Size(143, 19);
            this.chbRequiresAuth.TabIndex = 14;
            this.chbRequiresAuth.Text = "Enable Authentication";
            this.chbRequiresAuth.UseVisualStyleBackColor = true;
            this.chbRequiresAuth.CheckedChanged += new System.EventHandler(this.chbRequiresAuth_CheckedChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUser.Location = new System.Drawing.Point(170, 89);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(63, 15);
            this.lblUser.TabIndex = 15;
            this.lblUser.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Location = new System.Drawing.Point(238, 86);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(170, 23);
            this.txtUsername.TabIndex = 16;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPass.Location = new System.Drawing.Point(420, 89);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(60, 15);
            this.lblPass.TabIndex = 17;
            this.lblPass.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(484, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(160, 23);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // chbShowPassword
            // 
            this.chbShowPassword.AutoSize = true;
            this.chbShowPassword.Enabled = false;
            this.chbShowPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chbShowPassword.Location = new System.Drawing.Point(650, 88);
            this.chbShowPassword.Name = "chbShowPassword";
            this.chbShowPassword.Size = new System.Drawing.Size(55, 19);
            this.chbShowPassword.TabIndex = 19;
            this.chbShowPassword.Text = "Show";
            this.chbShowPassword.UseVisualStyleBackColor = true;
            this.chbShowPassword.CheckedChanged += new System.EventHandler(this.chbShowPassword_CheckedChanged);
            // 
            // btnPing
            // 
            this.btnPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPing.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnPing.Location = new System.Drawing.Point(768, 83);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(155, 28);
            this.btnPing.TabIndex = 20;
            this.btnPing.Text = "Test Connection (Ping)";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.cbxFrom);
            this.groupBox2.Controls.Add(this.lblFromName);
            this.groupBox2.Controls.Add(this.txtFromName);
            this.groupBox2.Controls.Add(this.lblReplyTo);
            this.groupBox2.Controls.Add(this.txtReplyTo);
            this.groupBox2.Controls.Add(this.lvlTo);
            this.groupBox2.Controls.Add(this.cbxTo);
            this.groupBox2.Controls.Add(this.lblCc);
            this.groupBox2.Controls.Add(this.txtCc);
            this.groupBox2.Controls.Add(this.lblBcc);
            this.groupBox2.Controls.Add(this.txtBcc);
            this.groupBox2.Controls.Add(this.lblSubject);
            this.groupBox2.Controls.Add(this.txtSubject);
            this.groupBox2.Controls.Add(this.lblPriority);
            this.groupBox2.Controls.Add(this.cbxPriority);
            this.groupBox2.Controls.Add(this.chbIsHtml);
            this.groupBox2.Controls.Add(this.chbReadReceipt);
            this.groupBox2.Controls.Add(this.chbOpenTracking);
            this.groupBox2.Controls.Add(this.chbClickTracking);
            this.groupBox2.Controls.Add(this.chbSaveInOutbox);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(10, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(938, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message Headers & Delivery Options";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrom.Location = new System.Drawing.Point(12, 23);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(69, 15);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From Email:";
            // 
            // cbxFrom
            // 
            this.cbxFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxFrom.FormattingEnabled = true;
            this.cbxFrom.Location = new System.Drawing.Point(90, 20);
            this.cbxFrom.Name = "cbxFrom";
            this.cbxFrom.Size = new System.Drawing.Size(200, 23);
            this.cbxFrom.TabIndex = 1;
            this.cbxFrom.Text = "sender@example.com";
            // 
            // lblFromName
            // 
            this.lblFromName.AutoSize = true;
            this.lblFromName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFromName.Location = new System.Drawing.Point(300, 23);
            this.lblFromName.Name = "lblFromName";
            this.lblFromName.Size = new System.Drawing.Size(73, 15);
            this.lblFromName.TabIndex = 2;
            this.lblFromName.Text = "From Name:";
            // 
            // txtFromName
            // 
            this.txtFromName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFromName.Location = new System.Drawing.Point(378, 20);
            this.txtFromName.Name = "txtFromName";
            this.txtFromName.Size = new System.Drawing.Size(160, 23);
            this.txtFromName.TabIndex = 3;
            this.txtFromName.Text = "SMTP Tool";
            // 
            // lblReplyTo
            // 
            this.lblReplyTo.AutoSize = true;
            this.lblReplyTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReplyTo.Location = new System.Drawing.Point(550, 23);
            this.lblReplyTo.Name = "lblReplyTo";
            this.lblReplyTo.Size = new System.Drawing.Size(57, 15);
            this.lblReplyTo.TabIndex = 4;
            this.lblReplyTo.Text = "Reply-To:";
            // 
            // txtReplyTo
            // 
            this.txtReplyTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReplyTo.Location = new System.Drawing.Point(612, 20);
            this.txtReplyTo.Name = "txtReplyTo";
            this.txtReplyTo.Size = new System.Drawing.Size(170, 23);
            this.txtReplyTo.TabIndex = 5;
            // 
            // lvlTo
            // 
            this.lvlTo.AutoSize = true;
            this.lvlTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvlTo.Location = new System.Drawing.Point(12, 53);
            this.lvlTo.Name = "lvlTo";
            this.lvlTo.Size = new System.Drawing.Size(55, 15);
            this.lvlTo.TabIndex = 6;
            this.lvlTo.Text = "To Email:";
            // 
            // cbxTo
            // 
            this.cbxTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxTo.FormattingEnabled = true;
            this.cbxTo.Location = new System.Drawing.Point(90, 50);
            this.cbxTo.Name = "cbxTo";
            this.cbxTo.Size = new System.Drawing.Size(200, 23);
            this.cbxTo.TabIndex = 7;
            this.cbxTo.Text = "recipient@example.com";
            // 
            // lblCc
            // 
            this.lblCc.AutoSize = true;
            this.lblCc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCc.Location = new System.Drawing.Point(300, 53);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(24, 15);
            this.lblCc.TabIndex = 8;
            this.lblCc.Text = "Cc:";
            // 
            // txtCc
            // 
            this.txtCc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCc.Location = new System.Drawing.Point(334, 50);
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(204, 23);
            this.txtCc.TabIndex = 9;
            // 
            // lblBcc
            // 
            this.lblBcc.AutoSize = true;
            this.lblBcc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBcc.Location = new System.Drawing.Point(550, 53);
            this.lblBcc.Name = "lblBcc";
            this.lblBcc.Size = new System.Drawing.Size(29, 15);
            this.lblBcc.TabIndex = 10;
            this.lblBcc.Text = "Bcc:";
            // 
            // txtBcc
            // 
            this.txtBcc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBcc.Location = new System.Drawing.Point(612, 50);
            this.txtBcc.Name = "txtBcc";
            this.txtBcc.Size = new System.Drawing.Size(170, 23);
            this.txtBcc.TabIndex = 11;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubject.Location = new System.Drawing.Point(12, 82);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(49, 15);
            this.lblSubject.TabIndex = 12;
            this.lblSubject.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSubject.Location = new System.Drawing.Point(90, 79);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(640, 23);
            this.txtSubject.TabIndex = 13;
            this.txtSubject.Text = "SMTP Tool - Test Message";
            // 
            // lblPriority
            // 
            this.lblPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPriority.Location = new System.Drawing.Point(740, 82);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(48, 15);
            this.lblPriority.TabIndex = 14;
            this.lblPriority.Text = "Priority:";
            // 
            // cbxPriority
            // 
            this.cbxPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPriority.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxPriority.FormattingEnabled = true;
            this.cbxPriority.Items.AddRange(new object[] {
            "Normal",
            "High",
            "Low"});
            this.cbxPriority.Location = new System.Drawing.Point(792, 79);
            this.cbxPriority.Name = "cbxPriority";
            this.cbxPriority.Size = new System.Drawing.Size(130, 23);
            this.cbxPriority.TabIndex = 15;
            // 
            // chbIsHtml
            // 
            this.chbIsHtml.AutoSize = true;
            this.chbIsHtml.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chbIsHtml.Location = new System.Drawing.Point(90, 110);
            this.chbIsHtml.Name = "chbIsHtml";
            this.chbIsHtml.Size = new System.Drawing.Size(95, 19);
            this.chbIsHtml.TabIndex = 16;
            this.chbIsHtml.Text = "HTML Format";
            this.chbIsHtml.UseVisualStyleBackColor = true;
            this.chbIsHtml.CheckedChanged += new System.EventHandler(this.chbIsHtml_CheckedChanged);
            // 
            // chbReadReceipt
            // 
            this.chbReadReceipt.AutoSize = true;
            this.chbReadReceipt.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chbReadReceipt.Location = new System.Drawing.Point(190, 110);
            this.chbReadReceipt.Name = "chbReadReceipt";
            this.chbReadReceipt.Size = new System.Drawing.Size(170, 19);
            this.chbReadReceipt.TabIndex = 17;
            this.chbReadReceipt.Text = "Delivery Receipt (Delivered)";
            this.chbReadReceipt.UseVisualStyleBackColor = true;
            // 
            // chbOpenTracking
            // 
            this.chbOpenTracking.AutoSize = true;
            this.chbOpenTracking.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chbOpenTracking.Location = new System.Drawing.Point(365, 110);
            this.chbOpenTracking.Name = "chbOpenTracking";
            this.chbOpenTracking.Size = new System.Drawing.Size(155, 19);
            this.chbOpenTracking.TabIndex = 18;
            this.chbOpenTracking.Text = "Open Tracking (Opened)";
            this.chbOpenTracking.UseVisualStyleBackColor = true;
            // 
            // chbClickTracking
            // 
            this.chbClickTracking.AutoSize = true;
            this.chbClickTracking.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chbClickTracking.Location = new System.Drawing.Point(525, 110);
            this.chbClickTracking.Name = "chbClickTracking";
            this.chbClickTracking.Size = new System.Drawing.Size(152, 19);
            this.chbClickTracking.TabIndex = 19;
            this.chbClickTracking.Text = "Click Tracking (Clicked)";
            this.chbClickTracking.UseVisualStyleBackColor = true;
            // 
            // chbSaveInOutbox
            // 
            this.chbSaveInOutbox.AutoSize = true;
            this.chbSaveInOutbox.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chbSaveInOutbox.Location = new System.Drawing.Point(685, 110);
            this.chbSaveInOutbox.Name = "chbSaveInOutbox";
            this.chbSaveInOutbox.Size = new System.Drawing.Size(135, 19);
            this.chbSaveInOutbox.TabIndex = 20;
            this.chbSaveInOutbox.Text = "Save Copy in Outbox";
            this.chbSaveInOutbox.UseVisualStyleBackColor = true;
            this.chbSaveInOutbox.CheckedChanged += new System.EventHandler(this.chbSaveInOutbox_CheckedChanged);
            // 
            // groupBoxBody
            // 
            this.groupBoxBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBody.Controls.Add(this.tabBodyControl);
            this.groupBoxBody.Controls.Add(this.lblAttachments);
            this.groupBoxBody.Controls.Add(this.lbAttachments);
            this.groupBoxBody.Controls.Add(this.btnAttach);
            this.groupBoxBody.Controls.Add(this.btnDelAttachment);
            this.groupBoxBody.Controls.Add(this.btnDelAttachmentAll);
            this.groupBoxBody.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxBody.Location = new System.Drawing.Point(10, 280);
            this.groupBoxBody.Name = "groupBoxBody";
            this.groupBoxBody.Size = new System.Drawing.Size(938, 200);
            this.groupBoxBody.TabIndex = 2;
            this.groupBoxBody.TabStop = false;
            this.groupBoxBody.Text = "Message Body & Attachments";
            // 
            // tabBodyControl
            // 
            this.tabBodyControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBodyControl.Controls.Add(this.tabBodyText);
            this.tabBodyControl.Controls.Add(this.tabBodyPreview);
            this.tabBodyControl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.tabBodyControl.Location = new System.Drawing.Point(12, 22);
            this.tabBodyControl.Name = "tabBodyControl";
            this.tabBodyControl.SelectedIndex = 0;
            this.tabBodyControl.Size = new System.Drawing.Size(650, 168);
            this.tabBodyControl.TabIndex = 0;
            this.tabBodyControl.SelectedIndexChanged += new System.EventHandler(this.tabBodyControl_SelectedIndexChanged);
            // 
            // tabBodyText
            // 
            this.tabBodyText.Controls.Add(this.txtBody);
            this.tabBodyText.Location = new System.Drawing.Point(4, 22);
            this.tabBodyText.Name = "tabBodyText";
            this.tabBodyText.Padding = new System.Windows.Forms.Padding(3);
            this.tabBodyText.Size = new System.Drawing.Size(642, 142);
            this.tabBodyText.TabIndex = 0;
            this.tabBodyText.Text = "Message Editor (Plain / HTML)";
            this.tabBodyText.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtBody.Location = new System.Drawing.Point(3, 3);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(636, 136);
            this.txtBody.TabIndex = 0;
            this.txtBody.Text = "Hello,\r\n\r\nThis is a test email sent using SMTP Tool v1.0 by AliSakkaF.\r\nEverythi" +
    "ng is operating smoothly!\r\n\r\nBest regards,\r\nSMTP Tool Team";
            // 
            // tabBodyPreview
            // 
            this.tabBodyPreview.Controls.Add(this.wbPreview);
            this.tabBodyPreview.Location = new System.Drawing.Point(4, 22);
            this.tabBodyPreview.Name = "tabBodyPreview";
            this.tabBodyPreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabBodyPreview.Size = new System.Drawing.Size(642, 142);
            this.tabBodyPreview.TabIndex = 1;
            this.tabBodyPreview.Text = "Live HTML Preview";
            this.tabBodyPreview.UseVisualStyleBackColor = true;
            // 
            // wbPreview
            // 
            this.wbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPreview.Location = new System.Drawing.Point(3, 3);
            this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.Size = new System.Drawing.Size(636, 136);
            this.wbPreview.TabIndex = 0;
            // 
            // lblAttachments
            // 
            this.lblAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAttachments.Location = new System.Drawing.Point(672, 22);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(78, 15);
            this.lblAttachments.TabIndex = 1;
            this.lblAttachments.Text = "Attachments:";
            // 
            // lbAttachments
            // 
            this.lbAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAttachments.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lbAttachments.FormattingEnabled = true;
            this.lbAttachments.ItemHeight = 13;
            this.lbAttachments.Location = new System.Drawing.Point(675, 42);
            this.lbAttachments.Name = "lbAttachments";
            this.lbAttachments.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAttachments.Size = new System.Drawing.Size(250, 108);
            this.lbAttachments.TabIndex = 2;
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttach.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAttach.Location = new System.Drawing.Point(675, 160);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(78, 26);
            this.btnAttach.TabIndex = 3;
            this.btnAttach.Text = "Add File";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnDelAttachment
            // 
            this.btnDelAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelAttachment.Enabled = false;
            this.btnDelAttachment.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDelAttachment.Location = new System.Drawing.Point(757, 160);
            this.btnDelAttachment.Name = "btnDelAttachment";
            this.btnDelAttachment.Size = new System.Drawing.Size(82, 26);
            this.btnDelAttachment.TabIndex = 4;
            this.btnDelAttachment.Text = "Remove";
            this.btnDelAttachment.UseVisualStyleBackColor = true;
            this.btnDelAttachment.Click += new System.EventHandler(this.btnDelAttachment_Click);
            // 
            // btnDelAttachmentAll
            // 
            this.btnDelAttachmentAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelAttachmentAll.Enabled = false;
            this.btnDelAttachmentAll.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDelAttachmentAll.Location = new System.Drawing.Point(843, 160);
            this.btnDelAttachmentAll.Name = "btnDelAttachmentAll";
            this.btnDelAttachmentAll.Size = new System.Drawing.Size(82, 26);
            this.btnDelAttachmentAll.TabIndex = 5;
            this.btnDelAttachmentAll.Text = "Clear All";
            this.btnDelAttachmentAll.UseVisualStyleBackColor = true;
            this.btnDelAttachmentAll.Click += new System.EventHandler(this.btnDelAttachmentAll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblCount);
            this.groupBox3.Controls.Add(this.nrcCount);
            this.groupBox3.Controls.Add(this.lblThreadCount);
            this.groupBox3.Controls.Add(this.nrcThreadCount);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.btnStopSend);
            this.groupBox3.Controls.Add(this.btnLogMaximizePreview);
            this.groupBox3.Controls.Add(this.btnLogReset);
            this.groupBox3.Controls.Add(this.chkShowFullLog);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(10, 486);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(938, 168);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bulk Testing & Diagnostic Transmission Log";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.Location = new System.Drawing.Point(12, 24);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(62, 15);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Messages:";
            // 
            // nrcCount
            // 
            this.nrcCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nrcCount.Location = new System.Drawing.Point(78, 21);
            this.nrcCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nrcCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nrcCount.Name = "nrcCount";
            this.nrcCount.Size = new System.Drawing.Size(55, 23);
            this.nrcCount.TabIndex = 1;
            this.nrcCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblThreadCount
            // 
            this.lblThreadCount.AutoSize = true;
            this.lblThreadCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThreadCount.Location = new System.Drawing.Point(145, 24);
            this.lblThreadCount.Name = "lblThreadCount";
            this.lblThreadCount.Size = new System.Drawing.Size(51, 15);
            this.lblThreadCount.TabIndex = 2;
            this.lblThreadCount.Text = "Threads:";
            // 
            // nrcThreadCount
            // 
            this.nrcThreadCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nrcThreadCount.Location = new System.Drawing.Point(200, 21);
            this.nrcThreadCount.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nrcThreadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nrcThreadCount.Name = "nrcThreadCount";
            this.nrcThreadCount.Size = new System.Drawing.Size(50, 23);
            this.nrcThreadCount.TabIndex = 3;
            this.nrcThreadCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.Location = new System.Drawing.Point(265, 17);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(130, 29);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send Test Email";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnStopSend
            // 
            this.btnStopSend.Enabled = false;
            this.btnStopSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStopSend.ForeColor = System.Drawing.Color.Crimson;
            this.btnStopSend.Location = new System.Drawing.Point(403, 17);
            this.btnStopSend.Name = "btnStopSend";
            this.btnStopSend.Size = new System.Drawing.Size(110, 29);
            this.btnStopSend.TabIndex = 5;
            this.btnStopSend.Text = "Stop Sending";
            this.btnStopSend.UseVisualStyleBackColor = true;
            this.btnStopSend.Click += new System.EventHandler(this.btnStopSend_Click);
            // 
            // btnLogMaximizePreview
            // 
            this.btnLogMaximizePreview.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLogMaximizePreview.Location = new System.Drawing.Point(520, 17);
            this.btnLogMaximizePreview.Name = "btnLogMaximizePreview";
            this.btnLogMaximizePreview.Size = new System.Drawing.Size(100, 29);
            this.btnLogMaximizePreview.TabIndex = 6;
            this.btnLogMaximizePreview.Text = "▲ Max Preview";
            this.btnLogMaximizePreview.UseVisualStyleBackColor = true;
            this.btnLogMaximizePreview.Click += new System.EventHandler(this.btnLogMaximizePreview_Click);
            // 
            // btnLogReset
            // 
            this.btnLogReset.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLogReset.Location = new System.Drawing.Point(625, 17);
            this.btnLogReset.Name = "btnLogReset";
            this.btnLogReset.Size = new System.Drawing.Size(95, 29);
            this.btnLogReset.TabIndex = 7;
            this.btnLogReset.Text = "▼ Reset Log";
            this.btnLogReset.UseVisualStyleBackColor = true;
            this.btnLogReset.Click += new System.EventHandler(this.btnLogReset_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnClear.Location = new System.Drawing.Point(843, 17);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 28);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear Log";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkShowFullLog
            // 
            this.chkShowFullLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowFullLog.AutoSize = true;
            this.chkShowFullLog.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkShowFullLog.Location = new System.Drawing.Point(735, 22);
            this.chkShowFullLog.Name = "chkShowFullLog";
            this.chkShowFullLog.Size = new System.Drawing.Size(100, 19);
            this.chkShowFullLog.TabIndex = 6;
            this.chkShowFullLog.Text = "Show Full Log";
            this.chkShowFullLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.txtLog.Location = new System.Drawing.Point(12, 52);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(915, 105);
            this.txtLog.TabIndex = 6;
            this.txtLog.Text = "";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.lvHistory);
            this.tabHistory.Controls.Add(this.btnInspectHistory);
            this.tabHistory.Controls.Add(this.btnExportHistory);
            this.tabHistory.Controls.Add(this.btnRefreshHistory);
            this.tabHistory.Controls.Add(this.lblTrackingHost);
            this.tabHistory.Controls.Add(this.txtTrackingHost);
            this.tabHistory.Controls.Add(this.btnDetectPublicIp);
            this.tabHistory.Controls.Add(this.btnClearHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 30);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(10);
            this.tabHistory.Size = new System.Drawing.Size(960, 660);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "Delivery History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // lvHistory
            // 
            this.lvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStatus,
            this.colTime,
            this.colTo,
            this.colFrom,
            this.colSubject,
            this.colServer,
            this.colDuration,
            this.colTracking,
            this.colMessage});
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(10, 10);
            this.lvHistory.MultiSelect = false;
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(940, 595);
            this.lvHistory.TabIndex = 0;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.DoubleClick += new System.EventHandler(this.lvHistory_DoubleClick);
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 85;
            // 
            // colTime
            // 
            this.colTime.Text = "Sent Time";
            this.colTime.Width = 140;
            // 
            // colTo
            // 
            this.colTo.Text = "Recipient (To)";
            this.colTo.Width = 160;
            // 
            // colFrom
            // 
            this.colFrom.Text = "Sender (From)";
            this.colFrom.Width = 160;
            // 
            // colSubject
            // 
            this.colSubject.Text = "Subject";
            this.colSubject.Width = 180;
            // 
            // colServer
            // 
            this.colServer.Text = "Server : Port";
            this.colServer.Width = 130;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Duration";
            this.colDuration.Width = 75;
            // 
            // colTracking
            // 
            this.colTracking.Text = "Tracking";
            this.colTracking.Width = 120;
            // 
            // colMessage
            // 
            this.colMessage.Text = "Server Response";
            this.colMessage.Width = 240;
            // 
            // btnInspectHistory
            // 
            this.btnInspectHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInspectHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInspectHistory.Location = new System.Drawing.Point(10, 615);
            this.btnInspectHistory.Name = "btnInspectHistory";
            this.btnInspectHistory.Size = new System.Drawing.Size(200, 32);
            this.btnInspectHistory.TabIndex = 1;
            this.btnInspectHistory.Text = "Inspect Message (Double-Click)";
            this.btnInspectHistory.UseVisualStyleBackColor = true;
            this.btnInspectHistory.Click += new System.EventHandler(this.btnInspectHistory_Click);
            // 
            // btnExportHistory
            // 
            this.btnExportHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportHistory.Location = new System.Drawing.Point(220, 615);
            this.btnExportHistory.Name = "btnExportHistory";
            this.btnExportHistory.Size = new System.Drawing.Size(140, 32);
            this.btnExportHistory.TabIndex = 2;
            this.btnExportHistory.Text = "Export As CSV";
            this.btnExportHistory.UseVisualStyleBackColor = true;
            this.btnExportHistory.Click += new System.EventHandler(this.btnExportHistory_Click);
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshHistory.Location = new System.Drawing.Point(370, 615);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.Size = new System.Drawing.Size(140, 32);
            this.btnRefreshHistory.TabIndex = 3;
            this.btnRefreshHistory.Text = "🔄 Refresh Tracking";
            this.btnRefreshHistory.UseVisualStyleBackColor = true;
            this.btnRefreshHistory.Click += new System.EventHandler(this.btnRefreshHistory_Click);
            // 
            // lblTrackingHost
            // 
            this.lblTrackingHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrackingHost.AutoSize = true;
            this.lblTrackingHost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrackingHost.Location = new System.Drawing.Point(518, 622);
            this.lblTrackingHost.Name = "lblTrackingHost";
            this.lblTrackingHost.Size = new System.Drawing.Size(58, 15);
            this.lblTrackingHost.TabIndex = 4;
            this.lblTrackingHost.Text = "Host / IP:";
            // 
            // txtTrackingHost
            // 
            this.txtTrackingHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTrackingHost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTrackingHost.Location = new System.Drawing.Point(580, 619);
            this.txtTrackingHost.Name = "txtTrackingHost";
            this.txtTrackingHost.Size = new System.Drawing.Size(140, 23);
            this.txtTrackingHost.TabIndex = 5;
            this.txtTrackingHost.TextChanged += new System.EventHandler(this.txtTrackingHost_TextChanged);
            // 
            // btnDetectPublicIp
            // 
            this.btnDetectPublicIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetectPublicIp.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDetectPublicIp.Location = new System.Drawing.Point(725, 615);
            this.btnDetectPublicIp.Name = "btnDetectPublicIp";
            this.btnDetectPublicIp.Size = new System.Drawing.Size(85, 32);
            this.btnDetectPublicIp.TabIndex = 6;
            this.btnDetectPublicIp.Text = "Detect IP";
            this.btnDetectPublicIp.UseVisualStyleBackColor = true;
            this.btnDetectPublicIp.Click += new System.EventHandler(this.btnDetectPublicIp_Click);
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearHistory.Location = new System.Drawing.Point(820, 615);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(130, 32);
            this.btnClearHistory.TabIndex = 3;
            this.btnClearHistory.Text = "Clear History";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // RemailTabPage
            // 
            this.RemailTabPage.Controls.Add(this.groupBox4);
            this.RemailTabPage.Controls.Add(this.groupBox5);
            this.RemailTabPage.Location = new System.Drawing.Point(4, 30);
            this.RemailTabPage.Name = "RemailTabPage";
            this.RemailTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.RemailTabPage.Size = new System.Drawing.Size(960, 660);
            this.RemailTabPage.TabIndex = 2;
            this.RemailTabPage.Text = "Templates & Remailer";
            this.RemailTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbxRemailIP);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtRemailPort);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cbxRemailFrom);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cbxRemailTo);
            this.groupBox4.Controls.Add(this.btnRemail);
            this.groupBox4.Controls.Add(this.btnStopRemail);
            this.groupBox4.Controls.Add(this.btnSyncRemail);
            this.groupBox4.Controls.Add(this.btnOpenFolder);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(944, 90);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Template Dispatch Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP Server:";
            // 
            // cbxRemailIP
            // 
            this.cbxRemailIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxRemailIP.FormattingEnabled = true;
            this.cbxRemailIP.Location = new System.Drawing.Point(90, 22);
            this.cbxRemailIP.Name = "cbxRemailIP";
            this.cbxRemailIP.Size = new System.Drawing.Size(180, 23);
            this.cbxRemailIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(280, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // txtRemailPort
            // 
            this.txtRemailPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemailPort.Location = new System.Drawing.Point(315, 22);
            this.txtRemailPort.Name = "txtRemailPort";
            this.txtRemailPort.Size = new System.Drawing.Size(50, 23);
            this.txtRemailPort.TabIndex = 3;
            this.txtRemailPort.Text = "25";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "From Email:";
            // 
            // cbxRemailFrom
            // 
            this.cbxRemailFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxRemailFrom.FormattingEnabled = true;
            this.cbxRemailFrom.Location = new System.Drawing.Point(90, 52);
            this.cbxRemailFrom.Name = "cbxRemailFrom";
            this.cbxRemailFrom.Size = new System.Drawing.Size(180, 23);
            this.cbxRemailFrom.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(280, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "To Email:";
            // 
            // cbxRemailTo
            // 
            this.cbxRemailTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxRemailTo.FormattingEnabled = true;
            this.cbxRemailTo.Location = new System.Drawing.Point(340, 52);
            this.cbxRemailTo.Name = "cbxRemailTo";
            this.cbxRemailTo.Size = new System.Drawing.Size(180, 23);
            this.cbxRemailTo.TabIndex = 7;
            // 
            // btnRemail
            // 
            this.btnRemail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemail.Location = new System.Drawing.Point(535, 18);
            this.btnRemail.Name = "btnRemail";
            this.btnRemail.Size = new System.Drawing.Size(145, 30);
            this.btnRemail.TabIndex = 8;
            this.btnRemail.Text = "Send Selected Email";
            this.btnRemail.UseVisualStyleBackColor = true;
            this.btnRemail.Click += new System.EventHandler(this.btnRemail_Click);
            // 
            // btnStopRemail
            // 
            this.btnStopRemail.Enabled = false;
            this.btnStopRemail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStopRemail.ForeColor = System.Drawing.Color.Crimson;
            this.btnStopRemail.Location = new System.Drawing.Point(535, 52);
            this.btnStopRemail.Name = "btnStopRemail";
            this.btnStopRemail.Size = new System.Drawing.Size(145, 30);
            this.btnStopRemail.TabIndex = 9;
            this.btnStopRemail.Text = "Stop Sending";
            this.btnStopRemail.UseVisualStyleBackColor = true;
            this.btnStopRemail.Click += new System.EventHandler(this.btnStopRemail_Click);
            // 
            // btnSyncRemail
            // 
            this.btnSyncRemail.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSyncRemail.Location = new System.Drawing.Point(688, 18);
            this.btnSyncRemail.Name = "btnSyncRemail";
            this.btnSyncRemail.Size = new System.Drawing.Size(145, 30);
            this.btnSyncRemail.TabIndex = 10;
            this.btnSyncRemail.Text = "🔄 Sync from Main";
            this.btnSyncRemail.UseVisualStyleBackColor = true;
            this.btnSyncRemail.Click += new System.EventHandler(this.btnSyncRemail_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnOpenFolder.Location = new System.Drawing.Point(838, 18);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(95, 64);
            this.btnOpenFolder.TabIndex = 11;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.treeViewMails);
            this.groupBox5.Controls.Add(this.txtMailView);
            this.groupBox5.Controls.Add(this.txtRemailOutput);
            this.groupBox5.Controls.Add(this.btnRemailSaveMail);
            this.groupBox5.Controls.Add(this.chkFormatTemplateView);
            this.groupBox5.Controls.Add(this.lblRemailSize);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(8, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(944, 546);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Template Explorer & Raw Content Inspector";
            // 
            // treeViewMails
            // 
            this.treeViewMails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewMails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeViewMails.Location = new System.Drawing.Point(12, 24);
            this.treeViewMails.Name = "treeViewMails";
            this.treeViewMails.Size = new System.Drawing.Size(260, 476);
            this.treeViewMails.TabIndex = 0;
            // 
            // txtMailView
            // 
            this.txtMailView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMailView.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtMailView.Location = new System.Drawing.Point(280, 24);
            this.txtMailView.Multiline = true;
            this.txtMailView.Name = "txtMailView";
            this.txtMailView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMailView.Size = new System.Drawing.Size(650, 360);
            this.txtMailView.TabIndex = 1;
            // 
            // txtRemailOutput
            // 
            this.txtRemailOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemailOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.txtRemailOutput.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.txtRemailOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.txtRemailOutput.Location = new System.Drawing.Point(280, 392);
            this.txtRemailOutput.Name = "txtRemailOutput";
            this.txtRemailOutput.ReadOnly = true;
            this.txtRemailOutput.Size = new System.Drawing.Size(650, 108);
            this.txtRemailOutput.TabIndex = 2;
            this.txtRemailOutput.Text = "";
            // 
            // btnRemailSaveMail
            // 
            this.btnRemailSaveMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemailSaveMail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemailSaveMail.Location = new System.Drawing.Point(12, 508);
            this.btnRemailSaveMail.Name = "btnRemailSaveMail";
            this.btnRemailSaveMail.Size = new System.Drawing.Size(140, 28);
            this.btnRemailSaveMail.TabIndex = 3;
            this.btnRemailSaveMail.Text = "Save Template";
            this.btnRemailSaveMail.UseVisualStyleBackColor = true;
            this.btnRemailSaveMail.Click += new System.EventHandler(this.btnRemailSaveMail_Click);
            // 
            // chkFormatTemplateView
            // 
            this.chkFormatTemplateView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFormatTemplateView.AutoSize = true;
            this.chkFormatTemplateView.Checked = true;
            this.chkFormatTemplateView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormatTemplateView.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkFormatTemplateView.Location = new System.Drawing.Point(165, 513);
            this.chkFormatTemplateView.Name = "chkFormatTemplateView";
            this.chkFormatTemplateView.Size = new System.Drawing.Size(145, 19);
            this.chkFormatTemplateView.TabIndex = 5;
            this.chkFormatTemplateView.Text = "Clean Formatted View";
            this.chkFormatTemplateView.UseVisualStyleBackColor = true;
            this.chkFormatTemplateView.CheckedChanged += new System.EventHandler(this.chkFormatTemplateView_CheckedChanged);
            // 
            // lblRemailSize
            // 
            this.lblRemailSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemailSize.AutoSize = true;
            this.lblRemailSize.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRemailSize.ForeColor = System.Drawing.Color.Gray;
            this.lblRemailSize.Location = new System.Drawing.Point(780, 515);
            this.lblRemailSize.Name = "lblRemailSize";
            this.lblRemailSize.Size = new System.Drawing.Size(43, 15);
            this.lblRemailSize.TabIndex = 4;
            this.lblRemailSize.Text = "Size: - ";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(8);
            this.tabPage1.Size = new System.Drawing.Size(960, 660);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Interactive Terminal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.cbxSessionServer);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.cbxSessionPort);
            this.groupBox6.Controls.Add(this.btnSessionConnect);
            this.groupBox6.Controls.Add(this.btnSessionDisconnect);
            this.groupBox6.Controls.Add(this.btnSessionSync);
            this.groupBox6.Controls.Add(this.btnSessionOpenNewWindow);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox6.Location = new System.Drawing.Point(8, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(944, 65);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Interactive Connection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(12, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "SMTP Server:";
            // 
            // cbxSessionServer
            // 
            this.cbxSessionServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxSessionServer.FormattingEnabled = true;
            this.cbxSessionServer.Location = new System.Drawing.Point(90, 25);
            this.cbxSessionServer.Name = "cbxSessionServer";
            this.cbxSessionServer.Size = new System.Drawing.Size(200, 23);
            this.cbxSessionServer.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(300, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Port:";
            // 
            // cbxSessionPort
            // 
            this.cbxSessionPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbxSessionPort.Location = new System.Drawing.Point(335, 25);
            this.cbxSessionPort.Name = "cbxSessionPort";
            this.cbxSessionPort.Size = new System.Drawing.Size(50, 23);
            this.cbxSessionPort.TabIndex = 3;
            this.cbxSessionPort.Text = "25";
            // 
            // btnSessionConnect
            // 
            this.btnSessionConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSessionConnect.Location = new System.Drawing.Point(400, 23);
            this.btnSessionConnect.Name = "btnSessionConnect";
            this.btnSessionConnect.Size = new System.Drawing.Size(85, 27);
            this.btnSessionConnect.TabIndex = 4;
            this.btnSessionConnect.Text = "Connect";
            this.btnSessionConnect.UseVisualStyleBackColor = true;
            this.btnSessionConnect.Click += new System.EventHandler(this.btnSessionConnect_Click);
            // 
            // btnSessionDisconnect
            // 
            this.btnSessionDisconnect.Enabled = false;
            this.btnSessionDisconnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSessionDisconnect.ForeColor = System.Drawing.Color.Crimson;
            this.btnSessionDisconnect.Location = new System.Drawing.Point(490, 23);
            this.btnSessionDisconnect.Name = "btnSessionDisconnect";
            this.btnSessionDisconnect.Size = new System.Drawing.Size(110, 27);
            this.btnSessionDisconnect.TabIndex = 5;
            this.btnSessionDisconnect.Text = "Stop / Disconnect";
            this.btnSessionDisconnect.UseVisualStyleBackColor = true;
            this.btnSessionDisconnect.Click += new System.EventHandler(this.btnSessionDisconnect_Click);
            // 
            // btnSessionSync
            // 
            this.btnSessionSync.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionSync.Location = new System.Drawing.Point(605, 23);
            this.btnSessionSync.Name = "btnSessionSync";
            this.btnSessionSync.Size = new System.Drawing.Size(120, 27);
            this.btnSessionSync.TabIndex = 6;
            this.btnSessionSync.Text = "🔄 Sync from Main";
            this.btnSessionSync.UseVisualStyleBackColor = true;
            this.btnSessionSync.Click += new System.EventHandler(this.btnSessionSync_Click);
            // 
            // btnSessionOpenNewWindow
            // 
            this.btnSessionOpenNewWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSessionOpenNewWindow.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionOpenNewWindow.Location = new System.Drawing.Point(800, 23);
            this.btnSessionOpenNewWindow.Name = "btnSessionOpenNewWindow";
            this.btnSessionOpenNewWindow.Size = new System.Drawing.Size(130, 27);
            this.btnSessionOpenNewWindow.TabIndex = 5;
            this.btnSessionOpenNewWindow.Text = "Open In Window";
            this.btnSessionOpenNewWindow.UseVisualStyleBackColor = true;
            this.btnSessionOpenNewWindow.Click += new System.EventHandler(this.btnSessionOpenNewWindow_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnSessionHelo);
            this.groupBox7.Controls.Add(this.btnSessionStartTls);
            this.groupBox7.Controls.Add(this.btnSessionAuth);
            this.groupBox7.Controls.Add(this.btnSessionFrom);
            this.groupBox7.Controls.Add(this.btnSessionRcpt);
            this.groupBox7.Controls.Add(this.btnSessionData);
            this.groupBox7.Controls.Add(this.btnSessionDot);
            this.groupBox7.Controls.Add(this.btnSessionReset);
            this.groupBox7.Controls.Add(this.btnSessionQuit);
            this.groupBox7.Controls.Add(this.cbxSessionFrom);
            this.groupBox7.Controls.Add(this.cbxSessionTo);
            this.groupBox7.Controls.Add(this.txtSessionEhlo);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox7.Location = new System.Drawing.Point(8, 76);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(944, 95);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Standard SMTP Handshake Shortcuts";
            // 
            // btnSessionHelo
            // 
            this.btnSessionHelo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionHelo.Location = new System.Drawing.Point(12, 22);
            this.btnSessionHelo.Name = "btnSessionHelo";
            this.btnSessionHelo.Size = new System.Drawing.Size(90, 26);
            this.btnSessionHelo.TabIndex = 0;
            this.btnSessionHelo.Text = "EHLO / HELO";
            this.btnSessionHelo.UseVisualStyleBackColor = true;
            this.btnSessionHelo.Click += new System.EventHandler(this.btnSessionHelo_Click);
            // 
            // btnSessionStartTls
            // 
            this.btnSessionStartTls.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionStartTls.Location = new System.Drawing.Point(108, 22);
            this.btnSessionStartTls.Name = "btnSessionStartTls";
            this.btnSessionStartTls.Size = new System.Drawing.Size(80, 26);
            this.btnSessionStartTls.TabIndex = 1;
            this.btnSessionStartTls.Text = "STARTTLS";
            this.btnSessionStartTls.UseVisualStyleBackColor = true;
            this.btnSessionStartTls.Click += new System.EventHandler(this.btnSessionStartTls_Click);
            // 
            // btnSessionAuth
            // 
            this.btnSessionAuth.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionAuth.Location = new System.Drawing.Point(194, 22);
            this.btnSessionAuth.Name = "btnSessionAuth";
            this.btnSessionAuth.Size = new System.Drawing.Size(95, 26);
            this.btnSessionAuth.TabIndex = 2;
            this.btnSessionAuth.Text = "AUTH LOGIN";
            this.btnSessionAuth.UseVisualStyleBackColor = true;
            this.btnSessionAuth.Click += new System.EventHandler(this.btnSessionAuth_Click);
            // 
            // btnSessionFrom
            // 
            this.btnSessionFrom.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionFrom.Location = new System.Drawing.Point(295, 22);
            this.btnSessionFrom.Name = "btnSessionFrom";
            this.btnSessionFrom.Size = new System.Drawing.Size(90, 26);
            this.btnSessionFrom.TabIndex = 3;
            this.btnSessionFrom.Text = "MAIL FROM";
            this.btnSessionFrom.UseVisualStyleBackColor = true;
            this.btnSessionFrom.Click += new System.EventHandler(this.btnSessionFrom_Click);
            // 
            // btnSessionRcpt
            // 
            this.btnSessionRcpt.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionRcpt.Location = new System.Drawing.Point(391, 22);
            this.btnSessionRcpt.Name = "btnSessionRcpt";
            this.btnSessionRcpt.Size = new System.Drawing.Size(80, 26);
            this.btnSessionRcpt.TabIndex = 4;
            this.btnSessionRcpt.Text = "RCPT TO";
            this.btnSessionRcpt.UseVisualStyleBackColor = true;
            this.btnSessionRcpt.Click += new System.EventHandler(this.btnSessionRcpt_Click);
            // 
            // btnSessionData
            // 
            this.btnSessionData.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionData.Location = new System.Drawing.Point(477, 22);
            this.btnSessionData.Name = "btnSessionData";
            this.btnSessionData.Size = new System.Drawing.Size(65, 26);
            this.btnSessionData.TabIndex = 5;
            this.btnSessionData.Text = "DATA";
            this.btnSessionData.UseVisualStyleBackColor = true;
            this.btnSessionData.Click += new System.EventHandler(this.btnSessionData_Click);
            // 
            // btnSessionDot
            // 
            this.btnSessionDot.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionDot.Location = new System.Drawing.Point(548, 22);
            this.btnSessionDot.Name = "btnSessionDot";
            this.btnSessionDot.Size = new System.Drawing.Size(80, 26);
            this.btnSessionDot.TabIndex = 6;
            this.btnSessionDot.Text = "End Data (.)";
            this.btnSessionDot.UseVisualStyleBackColor = true;
            this.btnSessionDot.Click += new System.EventHandler(this.btnSessionDot_Click);
            // 
            // btnSessionReset
            // 
            this.btnSessionReset.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionReset.Location = new System.Drawing.Point(634, 22);
            this.btnSessionReset.Name = "btnSessionReset";
            this.btnSessionReset.Size = new System.Drawing.Size(65, 26);
            this.btnSessionReset.TabIndex = 7;
            this.btnSessionReset.Text = "RSET";
            this.btnSessionReset.UseVisualStyleBackColor = true;
            this.btnSessionReset.Click += new System.EventHandler(this.btnSessionReset_Click);
            // 
            // btnSessionQuit
            // 
            this.btnSessionQuit.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionQuit.Location = new System.Drawing.Point(705, 22);
            this.btnSessionQuit.Name = "btnSessionQuit";
            this.btnSessionQuit.Size = new System.Drawing.Size(65, 26);
            this.btnSessionQuit.TabIndex = 8;
            this.btnSessionQuit.Text = "QUIT";
            this.btnSessionQuit.UseVisualStyleBackColor = true;
            this.btnSessionQuit.Click += new System.EventHandler(this.btnSessionQuit_Click);
            // 
            // cbxSessionFrom
            // 
            this.cbxSessionFrom.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cbxSessionFrom.FormattingEnabled = true;
            this.cbxSessionFrom.Location = new System.Drawing.Point(295, 55);
            this.cbxSessionFrom.Name = "cbxSessionFrom";
            this.cbxSessionFrom.Size = new System.Drawing.Size(180, 21);
            this.cbxSessionFrom.TabIndex = 9;
            // 
            // cbxSessionTo
            // 
            this.cbxSessionTo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cbxSessionTo.FormattingEnabled = true;
            this.cbxSessionTo.Location = new System.Drawing.Point(485, 55);
            this.cbxSessionTo.Name = "cbxSessionTo";
            this.cbxSessionTo.Size = new System.Drawing.Size(180, 21);
            this.cbxSessionTo.TabIndex = 10;
            // 
            // txtSessionEhlo
            // 
            this.txtSessionEhlo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtSessionEhlo.Location = new System.Drawing.Point(12, 55);
            this.txtSessionEhlo.Name = "txtSessionEhlo";
            this.txtSessionEhlo.Size = new System.Drawing.Size(176, 23);
            this.txtSessionEhlo.TabIndex = 11;
            this.txtSessionEhlo.Text = "localhost";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.lbxSessionHistory);
            this.groupBox8.Controls.Add(this.btnSessionResend);
            this.groupBox8.Controls.Add(this.btnSessionClearCommand);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox8.Location = new System.Drawing.Point(700, 175);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(252, 475);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Command History";
            // 
            // lbxSessionHistory
            // 
            this.lbxSessionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxSessionHistory.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lbxSessionHistory.FormattingEnabled = true;
            this.lbxSessionHistory.ItemHeight = 13;
            this.lbxSessionHistory.Location = new System.Drawing.Point(10, 22);
            this.lbxSessionHistory.Name = "lbxSessionHistory";
            this.lbxSessionHistory.Size = new System.Drawing.Size(232, 407);
            this.lbxSessionHistory.TabIndex = 0;
            this.lbxSessionHistory.DoubleClick += new System.EventHandler(this.btnSessionResend_Click);
            // 
            // btnSessionResend
            // 
            this.btnSessionResend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSessionResend.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionResend.Location = new System.Drawing.Point(10, 439);
            this.btnSessionResend.Name = "btnSessionResend";
            this.btnSessionResend.Size = new System.Drawing.Size(100, 26);
            this.btnSessionResend.TabIndex = 1;
            this.btnSessionResend.Text = "Resend";
            this.btnSessionResend.UseVisualStyleBackColor = true;
            this.btnSessionResend.Click += new System.EventHandler(this.btnSessionResend_Click);
            // 
            // btnSessionClearCommand
            // 
            this.btnSessionClearCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSessionClearCommand.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSessionClearCommand.Location = new System.Drawing.Point(142, 439);
            this.btnSessionClearCommand.Name = "btnSessionClearCommand";
            this.btnSessionClearCommand.Size = new System.Drawing.Size(100, 26);
            this.btnSessionClearCommand.TabIndex = 2;
            this.btnSessionClearCommand.Text = "Clear History";
            this.btnSessionClearCommand.UseVisualStyleBackColor = true;
            this.btnSessionClearCommand.Click += new System.EventHandler(this.btnSessionClearCommand_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.txtSessionOutput);
            this.groupBox9.Controls.Add(this.txtSessionCommand);
            this.groupBox9.Controls.Add(this.btnSessionSendLine);
            this.groupBox9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox9.Location = new System.Drawing.Point(8, 175);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(684, 475);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Live SMTP Terminal Console";
            // 
            // txtSessionOutput
            // 
            this.txtSessionOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSessionOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(30)))));
            this.txtSessionOutput.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.txtSessionOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.txtSessionOutput.Location = new System.Drawing.Point(12, 22);
            this.txtSessionOutput.Name = "txtSessionOutput";
            this.txtSessionOutput.ReadOnly = true;
            this.txtSessionOutput.Size = new System.Drawing.Size(660, 410);
            this.txtSessionOutput.TabIndex = 0;
            this.txtSessionOutput.Text = "";
            // 
            // txtSessionCommand
            // 
            this.txtSessionCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSessionCommand.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtSessionCommand.Location = new System.Drawing.Point(12, 442);
            this.txtSessionCommand.Name = "txtSessionCommand";
            this.txtSessionCommand.Size = new System.Drawing.Size(530, 22);
            this.txtSessionCommand.TabIndex = 1;
            // 
            // btnSessionSendLine
            // 
            this.btnSessionSendLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSessionSendLine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSessionSendLine.Location = new System.Drawing.Point(550, 440);
            this.btnSessionSendLine.Name = "btnSessionSendLine";
            this.btnSessionSendLine.Size = new System.Drawing.Size(122, 26);
            this.btnSessionSendLine.TabIndex = 2;
            this.btnSessionSendLine.Text = "Send Command";
            this.btnSessionSendLine.UseVisualStyleBackColor = true;
            this.btnSessionSendLine.Click += new System.EventHandler(this.btnSessionSendLine_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusLabelAuthorInfo,
            this.statusLabelMail,
            this.statusLabelUpdateInfo,
            this.statusLabelLink,
            this.toolTipUpdateStatus,
            this.btnCheckUpdates});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 706);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(984, 25);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(155, 20);
            this.statusLabel.Text = "SMTP Tool v1.0 | Up To Date";
            // 
            // statusLabelAuthorInfo
            // 
            this.statusLabelAuthorInfo.Name = "statusLabelAuthorInfo";
            this.statusLabelAuthorInfo.Size = new System.Drawing.Size(53, 20);
            this.statusLabelAuthorInfo.Text = " | Author:";
            // 
            // statusLabelMail
            // 
            this.statusLabelMail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.statusLabelMail.ForeColor = System.Drawing.Color.RoyalBlue;
            this.statusLabelMail.IsLink = true;
            this.statusLabelMail.Name = "statusLabelMail";
            this.statusLabelMail.Size = new System.Drawing.Size(59, 20);
            this.statusLabelMail.Text = "AliSakkaF";
            this.statusLabelMail.Click += new System.EventHandler(this.statusLabelMail_Click);
            // 
            // statusLabelUpdateInfo
            // 
            this.statusLabelUpdateInfo.Name = "statusLabelUpdateInfo";
            this.statusLabelUpdateInfo.Size = new System.Drawing.Size(58, 20);
            this.statusLabelUpdateInfo.Text = " | Website:";
            // 
            // statusLabelLink
            // 
            this.statusLabelLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.statusLabelLink.ForeColor = System.Drawing.Color.RoyalBlue;
            this.statusLabelLink.IsLink = true;
            this.statusLabelLink.Name = "statusLabelLink";
            this.statusLabelLink.Size = new System.Drawing.Size(76, 20);
            this.statusLabelLink.Text = "alisakkaf.com";
            this.statusLabelLink.Click += new System.EventHandler(this.statusLabelLink_Click);
            // 
            // toolTipUpdateStatus
            // 
            this.toolTipUpdateStatus.Name = "toolTipUpdateStatus";
            this.toolTipUpdateStatus.Size = new System.Drawing.Size(0, 20);
            // 
            // btnCheckUpdates
            // 
            this.btnCheckUpdates.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Underline);
            this.btnCheckUpdates.ForeColor = System.Drawing.Color.DimGray;
            this.btnCheckUpdates.IsLink = true;
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.Size = new System.Drawing.Size(126, 20);
            this.btnCheckUpdates.Text = "[ Check For Updates ]";
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 731);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.smtpTabPage);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTP Tool - Professional Email Testing Suite (v1.0) | AliSakkaF";
            this.Load += new System.EventHandler(this.Main_Load);
            this.smtpTabPage.ResumeLayout(false);
            this.mailTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxBody.ResumeLayout(false);
            this.groupBoxBody.PerformLayout();
            this.tabBodyControl.ResumeLayout(false);
            this.tabBodyText.ResumeLayout(false);
            this.tabBodyText.PerformLayout();
            this.tabBodyPreview.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrcCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrcThreadCount)).EndInit();
            this.tabHistory.ResumeLayout(false);
            this.RemailTabPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Controls
        public System.Windows.Forms.TabControl smtpTabPage;
        public System.Windows.Forms.TabPage mailTabPage;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox cbxProfile;
        public System.Windows.Forms.Label lblProfile;
        public System.Windows.Forms.Button btnSaveProfile;
        public System.Windows.Forms.Button btnDeleteProfile;
        public System.Windows.Forms.Label lblServer;
        public System.Windows.Forms.ComboBox cbxServer;
        public System.Windows.Forms.Label lblPort;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.Button btnPort25;
        public System.Windows.Forms.Button btnPort465;
        public System.Windows.Forms.Button btnPort587;
        public System.Windows.Forms.Button btnPort2525;
        public System.Windows.Forms.Label lblSecurity;
        public System.Windows.Forms.ComboBox cbxSecurityMode;
        public System.Windows.Forms.CheckBox chbRequiresAuth;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.Label lblPass;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.CheckBox chbShowPassword;
        public System.Windows.Forms.Button btnPing;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label lblFrom;
        public System.Windows.Forms.ComboBox cbxFrom;
        public System.Windows.Forms.Label lblFromName;
        public System.Windows.Forms.TextBox txtFromName;
        public System.Windows.Forms.Label lblReplyTo;
        public System.Windows.Forms.TextBox txtReplyTo;
        public System.Windows.Forms.Label lvlTo;
        public System.Windows.Forms.ComboBox cbxTo;
        public System.Windows.Forms.Label lblCc;
        public System.Windows.Forms.TextBox txtCc;
        public System.Windows.Forms.Label lblBcc;
        public System.Windows.Forms.TextBox txtBcc;
        public System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.TextBox txtSubject;
        public System.Windows.Forms.Label lblPriority;
        public System.Windows.Forms.ComboBox cbxPriority;
        public System.Windows.Forms.CheckBox chbIsHtml;
        public System.Windows.Forms.CheckBox chbOpenTracking;
        public System.Windows.Forms.CheckBox chbClickTracking;
        public System.Windows.Forms.CheckBox chbReadReceipt;
        public System.Windows.Forms.CheckBox chbSaveInOutbox;
        public System.Windows.Forms.GroupBox groupBoxBody;
        public System.Windows.Forms.TabControl tabBodyControl;
        public System.Windows.Forms.TabPage tabBodyText;
        public System.Windows.Forms.TextBox txtBody;
        public System.Windows.Forms.TabPage tabBodyPreview;
        public System.Windows.Forms.WebBrowser wbPreview;
        public System.Windows.Forms.Label lblAttachments;
        public System.Windows.Forms.ListBox lbAttachments;
        public System.Windows.Forms.Button btnAttach;
        public System.Windows.Forms.Button btnDelAttachment;
        public System.Windows.Forms.Button btnDelAttachmentAll;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label lblCount;
        public System.Windows.Forms.NumericUpDown nrcCount;
        public System.Windows.Forms.Label lblThreadCount;
        public System.Windows.Forms.NumericUpDown nrcThreadCount;
        public System.Windows.Forms.Button btnSend;
        public System.Windows.Forms.Button btnStopSend;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnLogMaximizePreview;
        public System.Windows.Forms.Button btnLogReset;
        public System.Windows.Forms.CheckBox chkShowFullLog;
        public System.Windows.Forms.RichTextBox txtLog;
        public System.Windows.Forms.TabPage tabHistory;
        public System.Windows.Forms.ListView lvHistory;
        public System.Windows.Forms.ColumnHeader colStatus;
        public System.Windows.Forms.ColumnHeader colTime;
        public System.Windows.Forms.ColumnHeader colTo;
        public System.Windows.Forms.ColumnHeader colFrom;
        public System.Windows.Forms.ColumnHeader colSubject;
        public System.Windows.Forms.ColumnHeader colServer;
        public System.Windows.Forms.ColumnHeader colDuration;
        public System.Windows.Forms.ColumnHeader colTracking;
        public System.Windows.Forms.ColumnHeader colMessage;
        public System.Windows.Forms.Button btnInspectHistory;
        public System.Windows.Forms.Button btnExportHistory;
        public System.Windows.Forms.Button btnRefreshHistory;
        public System.Windows.Forms.Label lblTrackingHost;
        public System.Windows.Forms.TextBox txtTrackingHost;
        public System.Windows.Forms.Button btnDetectPublicIp;
        public System.Windows.Forms.Button btnClearHistory;
        public System.Windows.Forms.TabPage RemailTabPage;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbxRemailIP;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRemailPort;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbxRemailFrom;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbxRemailTo;
        public System.Windows.Forms.Button btnRemail;
        public System.Windows.Forms.Button btnStopRemail;
        public System.Windows.Forms.Button btnSyncRemail;
        public System.Windows.Forms.Button btnOpenFolder;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.TreeView treeViewMails;
        public System.Windows.Forms.TextBox txtMailView;
        public System.Windows.Forms.RichTextBox txtRemailOutput;
        public System.Windows.Forms.Button btnRemailSaveMail;
        public System.Windows.Forms.CheckBox chkFormatTemplateView;
        public System.Windows.Forms.Label lblRemailSize;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbxSessionServer;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox cbxSessionPort;
        public System.Windows.Forms.Button btnSessionConnect;
        public System.Windows.Forms.Button btnSessionDisconnect;
        public System.Windows.Forms.Button btnSessionSync;
        public System.Windows.Forms.Button btnSessionOpenNewWindow;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Button btnSessionHelo;
        public System.Windows.Forms.Button btnSessionStartTls;
        public System.Windows.Forms.Button btnSessionAuth;
        public System.Windows.Forms.Button btnSessionFrom;
        public System.Windows.Forms.Button btnSessionRcpt;
        public System.Windows.Forms.Button btnSessionData;
        public System.Windows.Forms.Button btnSessionDot;
        public System.Windows.Forms.Button btnSessionReset;
        public System.Windows.Forms.Button btnSessionQuit;
        public System.Windows.Forms.ComboBox cbxSessionFrom;
        public System.Windows.Forms.ComboBox cbxSessionTo;
        public System.Windows.Forms.TextBox txtSessionEhlo;
        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.ListBox lbxSessionHistory;
        public System.Windows.Forms.Button btnSessionResend;
        public System.Windows.Forms.Button btnSessionClearCommand;
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.RichTextBox txtSessionOutput;
        public System.Windows.Forms.TextBox txtSessionCommand;
        public System.Windows.Forms.Button btnSessionSendLine;
        public System.Windows.Forms.StatusStrip mainStatusStrip;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel;
        public System.Windows.Forms.ToolStripStatusLabel statusLabelAuthorInfo;
        public System.Windows.Forms.ToolStripStatusLabel statusLabelMail;
        public System.Windows.Forms.ToolStripStatusLabel statusLabelUpdateInfo;
        public System.Windows.Forms.ToolStripStatusLabel statusLabelLink;
        public System.Windows.Forms.ToolStripStatusLabel toolTipUpdateStatus;
        public System.Windows.Forms.ToolStripStatusLabel btnCheckUpdates;
    }
}
