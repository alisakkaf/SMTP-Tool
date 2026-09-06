using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMTPtool;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mail;
using HLIB.MailFormats;
using System.Threading;
using System.ComponentModel;
using Microsoft.Win32;

namespace SMTPtool
{
    public class RemailTab
    {
        Main _linkToMain;

        public List<string> serverList = new List<string>();
        public List<string> mailFromList = new List<string>();
        public List<string> mailToList = new List<string>();

        public String mailPath;

        public Remailer myRemailer;

        ContextMenuStrip mnRemailFile;
        ContextMenuStrip mnRemailFolder;

        private String fileToCopy;
        private ToolStripMenuItem mnRemailFilePaste;
        private ToolStripMenuItem mnRemailFolderPaste;

        String mailboxPath;
        static ImageList _imageList;
        public TreeNode previousSelectedNode = null;

        public Boolean txtMailViewIsDirty = false;
        public Boolean txtMailViewCanBeDirty = false;
        public string currentRawMime = "";

        public Boolean sendNext;

        public RemailTab(Main _linkToMain)
        {
            this._linkToMain = _linkToMain;

            createDirectories();
            string baseDir = Path.GetDirectoryName(Assembly.GetEntryAssembly() != null ? Assembly.GetEntryAssembly().Location : AppDomain.CurrentDomain.BaseDirectory);
            mailboxPath = Path.Combine(baseDir, "mailbox");

            _linkToMain.treeViewMails.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _linkToMain.treeViewMails.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            _linkToMain.treeViewMails.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeClicked);
            _linkToMain.treeViewMails.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewItemExpanded);
            _linkToMain.treeViewMails.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewItemCollapsed);
            _linkToMain.treeViewMails.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewItemDoubleClicked);
            _linkToMain.treeViewMails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewKeyDown);

            mnRemailFile = new ContextMenuStrip();
            mnRemailFile.Items.Add(new ToolStripMenuItem("Open", null, new System.EventHandler(this.mnuSessionFileOpen_Click), "openMail"));
            mnRemailFile.Items.Add(new ToolStripMenuItem("Copy", null, new System.EventHandler(this.mnuSessionFileCopy_Click), "copyMail"));
            mnRemailFilePaste = new ToolStripMenuItem("Paste", null, new System.EventHandler(this.mnuSessionFilePaste_Click), "pasteMail");
            mnRemailFilePaste.Enabled = false;
            mnRemailFile.Items.Add(mnRemailFilePaste);
            mnRemailFile.Items.Add(new ToolStripMenuItem("Delete", null, new System.EventHandler(this.mnuSessionFileDelete_Click), "deleteMail"));
            mnRemailFile.Items.Add(new ToolStripMenuItem("Rename", null, new System.EventHandler(this.mnuSessionFileRename_Click), "renameMail"));

            mnRemailFolder = new ContextMenuStrip();
            mnRemailFolder.Items.Add(new ToolStripMenuItem("Open directory", null, new System.EventHandler(this.mnuSessionFolderOpen_Click), "openDirectory"));
            mnRemailFolder.Items.Add(new ToolStripMenuItem("Delete", null, new System.EventHandler(this.mnuSessionFolderDelete_Click), "deleteFolder"));
            mnRemailFolderPaste = new ToolStripMenuItem("Paste", null, new System.EventHandler(this.mnuSessionFilePaste_Click), "pasteMail");
            mnRemailFolderPaste.Enabled = false;
            mnRemailFolder.Items.Add(mnRemailFolderPaste);

            buildMailTreeView(_linkToMain.treeViewMails, mailboxPath);
            _linkToMain.treeViewMails.ExpandAll();

            convertMessages();

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = mailboxPath;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;

            _linkToMain.txtMailView.TextChanged += new System.EventHandler(TextChanged);

        }

        public void triggerTreeViewRebuild()
        {
            buildMailTreeView(_linkToMain.treeViewMails, mailboxPath);
        }

        private void buildMailTreeView(TreeView treeView, string path)
        {
            createDirectories();
            if (!File.Exists(fileToCopy))
            {
                mnRemailFilePaste.Enabled = false;
                mnRemailFolderPaste.Enabled = false;
            }

            Dictionary<String, Boolean> directoryNodes = new Dictionary<String, Boolean>();
            foreach (TreeNode currentNode in treeView.Nodes)
            {
                directoryNodes.Add(currentNode.Tag.ToString(), currentNode.IsExpanded);
            }

            String selectedNode = "";
            if (!(treeView.SelectedNode == null)) selectedNode = treeView.SelectedNode.Tag.ToString();

            treeView.Nodes.Clear();
            treeView.ImageList = RemailTab.ImageList;
            var rootDirectory = new DirectoryInfo(path);
            foreach (var directory in rootDirectory.GetDirectories())
            {

                var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory.FullName };
                childDirectoryNode.ImageKey = "folder";
                childDirectoryNode.SelectedImageKey = "folder";
                String currentPath = directory.FullName;

                foreach (var file in Directory.GetFiles(currentPath, "*.eml", SearchOption.AllDirectories))
                {
                    try
                    {
                        TreeNode mailNode = new TreeNode(Path.GetFileName(file)) { Tag = file };
                        mailNode.ImageKey = "mail";
                        mailNode.SelectedImageKey = "mail";
                        childDirectoryNode.Nodes.Add(mailNode);

                    }
                    catch (Exception excpection)
                    {
                        MessageBox.Show(excpection.Message, "Attachment I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                treeView.Nodes.Add(childDirectoryNode);
            }

            foreach (TreeNode currentNode in treeView.Nodes)
            {
                if (currentNode.Tag.ToString().Equals(selectedNode))
                {
                    treeView.SelectedNode = currentNode;

                }
                if (directoryNodes.ContainsKey(currentNode.Tag.ToString()))
                {

                    if (directoryNodes[currentNode.Tag.ToString()])
                    {
                        currentNode.Expand();
                    }
                }

                foreach (TreeNode childNode in currentNode.Nodes)
                {
                    if (childNode.Tag.ToString().Equals(selectedNode))
                    {
                        treeView.SelectedNode = childNode;
                        break;
                    }
                }
            }
        }

        private void readFileAsync()
        {
            try
            {
                StreamReader streamReader = new StreamReader(mailPath, Encoding.UTF8);

                String text = streamReader.ReadToEnd();
                currentRawMime = text;
                _linkToMain.Invoke((MethodInvoker)delegate ()
                {
                    if (_linkToMain.chkFormatTemplateView.Checked)
                    {
                        _linkToMain.txtMailView.Text = FormatMimeOrHtmlForDisplay(text);
                    }
                    else
                    {
                        _linkToMain.txtMailView.Text = text;
                    }
                    txtMailViewCanBeDirty = true;
                    _linkToMain.txtMailView.ReadOnly = false;
                });

                streamReader.Close();
            }
            catch (Exception excpection)
            {
                MessageBox.Show(excpection.Message, "Attachment I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Debug.WriteLine("Filewatcher triggered");
            createDirectories();
            _linkToMain.Invoke((MethodInvoker)delegate ()
            {
                _linkToMain.txtMailView.Text = "";
                buildMailTreeView(_linkToMain.treeViewMails, mailboxPath);
            });
            convertMessages();
        }

        private void convertMessages()
        {
            createDirectories();
        }

        #region actions

        private void renameFile(String pathToFolder)
        {
            String input = Microsoft.VisualBasic.Interaction.InputBox("Type in new name for " + Path.GetFileName(mailPath), "Rename message", Path.GetFileName(mailPath), -1, -1);
            Debug.WriteLine(Path.GetExtension(input));

            if (!input.Equals(""))
            {
                if (!Path.GetExtension(input).Equals(".eml"))
                {
                    Debug.WriteLine("OIOIOI NO extension");
                    input = input + ".eml";
                }

                if (File.Exists(Path.GetDirectoryName(mailPath) + "\\" + input))
                {
                    MessageBox.Show("The name already exists \r\n\r\n " + input, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Debug.WriteLine("FILE MOVED TO: " + Path.GetDirectoryName(mailPath) + "\\" + input);
                    System.IO.File.Move(mailPath, Path.GetDirectoryName(mailPath) + "\\" + input);
                    _linkToMain.lblRemailSize.Text = "";
                    _linkToMain.btnRemail.Enabled = false;
                }
            }
        }

        private void TextChanged(object Sender, EventArgs e)
        {

            if (txtMailViewCanBeDirty)
            {
                if (txtMailViewIsDirty)
                {
                    _linkToMain.btnRemailSaveMail.Enabled = true;
                }
                else
                {
                    txtMailViewIsDirty = true;
                    _linkToMain.btnRemailSaveMail.Enabled = true;
                }
            }
        }

        private void deleteFolder(String pathToFolder)
        {
            if (pathToFolder.Equals(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\mailbox\\Import") ||
                pathToFolder.Equals(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\mailbox\\Outbox") ||
                pathToFolder.Equals(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\mailbox\\Inbox"))
            {
                MessageBox.Show("The folders Import, Inbox and Outbox are system mailboxes and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(pathToFolder);

                if (MessageBox.Show("Are you sure you want to delete the folder \r\n\r\n" + System.IO.Path.GetFileName(pathToFolder), "Delete folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    di.Delete(true);
                    triggerTreeViewRebuild();
                    _linkToMain.btnRemail.Enabled = false;
                }
            }
        }

        private void deleteFile(String pathToFile)
        {
            if (MessageBox.Show("Are you sure you want to delete \r\n\r\n" + System.IO.Path.GetFileName(pathToFile), "Delete mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                _linkToMain.txtMailView.Text = "";
                System.IO.File.Delete(pathToFile);
                buildMailTreeView(_linkToMain.treeViewMails, mailboxPath);
                _linkToMain.btnRemail.Enabled = false;
                _linkToMain.btnRemailSaveMail.Enabled = false;
                _linkToMain.lblRemailSize.Text = "";

            }
        }

        private void openFile(String pathToFile)
        {
            Process.Start(pathToFile);
        }

        private void openFolder(String pathToFolder)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo { Arguments = pathToFolder, FileName = "explorer.exe" };
            Process.Start(startInfo);
        }

        private void copyFile(String sourcePath, String target)
        {
            if (File.Exists(sourcePath))
            {
                String sourceFileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                String sourceFileName = Path.GetFileName(sourcePath);

                String targetDirectory;
                String finalTargetPath;

                FileAttributes attr = File.GetAttributes(@"" + target);

                if (attr.HasFlag(FileAttributes.Directory))
                {
                    targetDirectory = target;
                }
                else
                {
                    targetDirectory = Path.GetDirectoryName(target);
                }

                if (File.Exists(targetDirectory + "\\" + sourceFileName))
                {
                    if (File.Exists(targetDirectory + "\\" + sourceFileNameWithoutExt + " - Copy.eml"))
                    {
                        String fullTargetPath = targetDirectory + "\\" + sourceFileNameWithoutExt + " - Copy.eml";
                        int counter = 2;
                        while (File.Exists(fullTargetPath))
                        {
                            fullTargetPath = targetDirectory + "\\" + sourceFileNameWithoutExt + " - Copy" + counter + ".eml";
                            counter++;
                        }
                        finalTargetPath = fullTargetPath;
                    }
                    else
                    {
                        finalTargetPath = targetDirectory + "\\" + sourceFileNameWithoutExt + " - Copy.eml";
                    }
                }
                else
                {
                    finalTargetPath = targetDirectory + "\\" + sourceFileName;
                }
                File.Copy(sourcePath, finalTargetPath);

                triggerTreeViewRebuild();

                foreach (TreeNode currentNode in _linkToMain.treeViewMails.Nodes)
                {
                    if (currentNode.Tag.ToString().Equals(finalTargetPath))
                    {
                        _linkToMain.treeViewMails.SelectedNode = currentNode;
                        break;
                    }
                    foreach (TreeNode childNode in currentNode.Nodes)
                    {
                        if (childNode.Tag.ToString().Equals(finalTargetPath))
                        {
                            _linkToMain.treeViewMails.SelectedNode = childNode;
                            break;
                        }
                    }
                }
                _linkToMain.btnRemail.Enabled = true;
                txtMailViewCanBeDirty = false;
                txtMailViewIsDirty = false;
                _linkToMain.btnRemailSaveMail.Enabled = false;
                _linkToMain.lblRemailSize.Text = "";
            }
        }

        #endregion

        #region mouseClicks

        private void nodeClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                txtMailViewCanBeDirty = false;
                _linkToMain.txtMailView.Text = "";
                txtMailViewIsDirty = false;
                _linkToMain.txtMailView.ReadOnly = true;
                _linkToMain.btnRemailSaveMail.Enabled = false;
                _linkToMain.lblRemailSize.Text = "";

                FileAttributes attr = File.GetAttributes(@"" + e.Node.Tag);

                if (e.Button == MouseButtons.Right)
                {

                    Point p = new Point(e.X, e.Y);

                    TreeNode node = _linkToMain.treeViewMails.GetNodeAt(p);

                    if (node != null)
                    {

                        _linkToMain.treeViewMails.SelectedNode = node;
                        mnRemailFile.Show(_linkToMain.treeViewMails, p);

                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            mnRemailFolder.Show(_linkToMain.treeViewMails, p);
                        }
                        else
                        {
                            mnRemailFile.Show(_linkToMain.treeViewMails, p);
                        }
                    }
                }

                if (attr.HasFlag(FileAttributes.Directory))
                {

                    _linkToMain.txtMailView.Text = "Click Remail to send all messages in the selected folder.";

                    _linkToMain.btnRemail.Enabled = true;
                }
                else
                {

                    this.mailPath = e.Node.Tag.ToString();
                    long lengthInKB = new System.IO.FileInfo(this.mailPath).Length / 100 / 8;

                    if (lengthInKB < 20000)
                    {
                        Thread LoadThread = new Thread(new ThreadStart(readFileAsync));
                        LoadThread.Start();

                        _linkToMain.btnRemail.Enabled = true;
                        if (lengthInKB == 0)
                        {
                            lengthInKB = 1;
                        }
                        _linkToMain.lblRemailSize.Text = "Size: " + lengthInKB + " KB";
                    }
                    else
                    {
                        _linkToMain.Invoke((MethodInvoker)delegate ()
                        {
                            _linkToMain.txtMailView.Text = lengthInKB + " KB - Maximum file size exceeded for displaying the content. Maximum supported file size 20000 KB";
                        });
                    }
                }
            }
            catch (Exception)
            {
                triggerTreeViewRebuild();

            }
        }

        private void mnuSessionFolderDelete_Click(object sender, EventArgs e)
        {
            deleteFolder(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }
        private void mnuSessionFolderOpen_Click(object sender, EventArgs e)
        {
            openFolder(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }
        private void mnuSessionFileDelete_Click(object sender, EventArgs e)
        {
            deleteFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }
        private void mnuSessionFileOpen_Click(object sender, EventArgs e)
        {
            openFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }
        private void mnuSessionFileCopy_Click(object sender, EventArgs e)
        {
            fileToCopy = _linkToMain.treeViewMails.SelectedNode.Tag.ToString();
            mnRemailFolderPaste.Enabled = true;
            mnRemailFilePaste.Enabled = true;
        }
        private void mnuSessionFilePaste_Click(object sender, EventArgs e)
        {
            copyFile(fileToCopy, _linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }
        private void mnuSessionFileRename_Click(object sender, EventArgs e)
        {
            renameFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }

        public void treeViewItemDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            FileAttributes attr = File.GetAttributes(@"" + e.Node.Tag);
            if (!attr.HasFlag(FileAttributes.Directory))
            {
                openFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
            }
        }

        public void treeViewItemExpanded(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "Openfolder";
            e.Node.SelectedImageKey = "Openfolder";
        }
        public void treeViewItemCollapsed(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "folder";
            e.Node.SelectedImageKey = "folder";
        }

        #endregion

        #region KeyPress

        private void treeViewKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            String path = "";
            FileAttributes attr;
            if (!(_linkToMain.treeViewMails.SelectedNode == null))
            {
                path = _linkToMain.treeViewMails.SelectedNode.Tag.ToString();
                attr = File.GetAttributes(path);
                if (e.KeyCode == Keys.Enter)
                {
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        openFolder(path);
                    }
                }
                if (e.KeyData == (Keys.V | Keys.Control))
                {
                    Debug.WriteLine("CONTROL + V pressed");
                    copyFile(fileToCopy, _linkToMain.treeViewMails.SelectedNode.Tag.ToString());
                }
                if (e.KeyData == (Keys.C | Keys.Control))
                {
                    Debug.WriteLine("CONTROL + C pressed");
                    fileToCopy = _linkToMain.treeViewMails.SelectedNode.Tag.ToString();
                    mnRemailFolderPaste.Enabled = true;
                    mnRemailFilePaste.Enabled = true;
                }
                if (e.KeyCode == Keys.Delete)
                {
                    Debug.WriteLine("DELETE pressed");

                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        deleteFolder(path);
                    }
                    else
                    {
                        deleteFile(path);
                    }
                }
                if (e.KeyCode == Keys.F2)
                {
                    Debug.WriteLine("F2 pressed");
                    renameFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
                }

            }

            e.SuppressKeyPress = true;

        }
        #endregion

        #region Buttons

        public void btnOpenMailClicked()
        {
            openFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }

        public void btnDeleteMailClicked()
        {
            deleteFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }

        public void btnRemailClicked()
        {
            FileAttributes attr = File.GetAttributes(@"" + _linkToMain.treeViewMails.SelectedNode.Tag);
            if (attr.HasFlag(FileAttributes.Directory))
            {

                _linkToMain.txtMailView.Text = "Click Remail to send all messages in the selected folder.";

                if (_linkToMain.treeViewMails.SelectedNode.Nodes.Count > 0)
                {
                    _linkToMain.btnRemail.Enabled = true;

                    if (_linkToMain.cbxRemailIP.Text.Equals(""))
                    {
                        _linkToMain.cbxRemailIP.Text = "192.168.0.1";
                    }

                    try { int.Parse(_linkToMain.txtRemailPort.Text); }
                    catch { _linkToMain.txtRemailPort.Text = "25"; }

                    _linkToMain.txtRemailOutput.AppendText(DateTime.Now.ToString("MMM dd HH:mm:ss") + " - Connecting to " + _linkToMain.cbxRemailIP.Text + " on port" + int.Parse(_linkToMain.txtRemailPort.Text) + "\r\n", Color.Red);

                    foreach (TreeNode myNode in _linkToMain.treeViewMails.SelectedNode.Nodes)
                    {
                        String mailPath = myNode.Tag.ToString();
                        StreamReader streamReader = new StreamReader(mailPath, Encoding.UTF8);
                        String text = streamReader.ReadToEnd();
                        streamReader.Close();
                        myRemailer = new Remailer(_linkToMain);
                        myRemailer.sendSingle = false;
                        myRemailer.fullMailBody = text;

                        myRemailer.connect();
                    }
                }
                else
                {
                    _linkToMain.btnRemail.Enabled = false;
                }

            }
            else

            {
                String mailPath = _linkToMain.treeViewMails.SelectedNode.Tag.ToString();
                myRemailer = new Remailer(_linkToMain);
                myRemailer.sendSingle = true;
                myRemailer.connect();
            }

        }

        internal void btnRenameClicked()
        {
            renameFile(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }

        internal void btnNewFolderClicked()
        {
            String folderName = Microsoft.VisualBasic.Interaction.InputBox("Type in folder name " + Path.GetFileName(mailPath), "New folder", "new folder", -1, -1);
            System.IO.Directory.CreateDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\mailbox\\" + folderName);
            triggerTreeViewRebuild();
        }

        public void btnSaveClicked()
        {
            if (_linkToMain.treeViewMails.SelectedNode != null && _linkToMain.treeViewMails.SelectedNode.Tag != null)
            {
                string targetFile = _linkToMain.treeViewMails.SelectedNode.Tag.ToString();
                File.WriteAllText(targetFile, _linkToMain.txtMailView.Text, Encoding.UTF8);
                currentRawMime = _linkToMain.txtMailView.Text;
                _linkToMain.btnRemailSaveMail.Enabled = false;
                txtMailViewIsDirty = false;
            }
        }

        public void ToggleTemplateFormatting(bool cleanView)
        {
            if (string.IsNullOrEmpty(currentRawMime)) return;

            if (cleanView)
            {
                _linkToMain.txtMailView.Text = FormatMimeOrHtmlForDisplay(currentRawMime);
            }
            else
            {
                _linkToMain.txtMailView.Text = currentRawMime;
            }
        }

        public static string FormatMimeOrHtmlForDisplay(string rawContent)
        {
            if (string.IsNullOrWhiteSpace(rawContent)) return "";

            string subject = "";
            string from = "";
            string to = "";
            string date = "";
            string body = "";

            using (StringReader reader = new StringReader(rawContent))
            {
                string line;
                bool readingHeaders = true;
                StringBuilder bodySb = new StringBuilder();

                while ((line = reader.ReadLine()) != null)
                {
                    if (readingHeaders)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            readingHeaders = false;
                            continue;
                        }

                        if (line.StartsWith("Subject:", StringComparison.OrdinalIgnoreCase))
                            subject = line.Substring(8).Trim();
                        else if (line.StartsWith("From:", StringComparison.OrdinalIgnoreCase))
                            from = line.Substring(5).Trim();
                        else if (line.StartsWith("To:", StringComparison.OrdinalIgnoreCase))
                            to = line.Substring(3).Trim();
                        else if (line.StartsWith("Date:", StringComparison.OrdinalIgnoreCase))
                            date = line.Substring(5).Trim();
                    }
                    else
                    {
                        bodySb.AppendLine(line);
                    }
                }

                body = bodySb.ToString();
            }

            if (string.IsNullOrEmpty(subject) && string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to) && string.IsNullOrEmpty(date))
            {
                body = rawContent;
            }

            string cleanBody = StripAndFormatHtml(body);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("======================================================================");
            if (!string.IsNullOrEmpty(subject)) sb.AppendLine($"  SUBJECT : {subject}");
            if (!string.IsNullOrEmpty(from))    sb.AppendLine($"  FROM    : {from}");
            if (!string.IsNullOrEmpty(to))      sb.AppendLine($"  TO      : {to}");
            if (!string.IsNullOrEmpty(date))    sb.AppendLine($"  DATE    : {date}");
            sb.AppendLine("======================================================================");
            sb.AppendLine();
            sb.AppendLine(cleanBody.Trim());

            return sb.ToString();
        }

        public static string StripAndFormatHtml(string html)
        {
            if (string.IsNullOrEmpty(html)) return "";

            string text = System.Text.RegularExpressions.Regex.Replace(html, @"<(script|style)[^>]*>[\s\S]*?</\1>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            text = System.Text.RegularExpressions.Regex.Replace(text, @"<(br|p|div|h[1-6]|li|tr)[^>]*>", "\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            text = System.Text.RegularExpressions.Regex.Replace(text, @"<hr[^>]*>", "\r\n----------------------------------------------------------------------\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            text = System.Text.RegularExpressions.Regex.Replace(text, @"<a\s+[^>]*href=[""'](?<url>[^""']+)[""'][^>]*>(?<text>[\s\S]*?)</a>", m =>
            {
                string linkText = System.Text.RegularExpressions.Regex.Replace(m.Groups["text"].Value, @"<[^>]+>", "").Trim();
                string url = m.Groups["url"].Value.Trim();
                if (string.IsNullOrEmpty(linkText) || linkText.Equals(url, StringComparison.OrdinalIgnoreCase))
                    return url;
                return $"[{linkText}] ({url})";
            }, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            text = System.Text.RegularExpressions.Regex.Replace(text, @"<[^>]+>", "");
            text = System.Net.WebUtility.HtmlDecode(text);
            text = System.Text.RegularExpressions.Regex.Replace(text, @"(\r?\n){3,}", "\r\n\r\n");

            return text.Trim();
        }

        internal void btnOpenFolderClicked()
        {
            openFolder(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }

        internal void btnDeleteFolderClicked()
        {
            deleteFolder(_linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }

        internal void btnCopyMailClicked()
        {
            copyFile(fileToCopy, _linkToMain.treeViewMails.SelectedNode.Tag.ToString());
        }

        #endregion

        #region "helper"

        public void createDirectories()
        {
            string baseDir = Path.GetDirectoryName(Assembly.GetEntryAssembly() != null ? Assembly.GetEntryAssembly().Location : AppDomain.CurrentDomain.BaseDirectory);
            System.IO.Directory.CreateDirectory(Path.Combine(baseDir, "mailbox"));
            System.IO.Directory.CreateDirectory(Path.Combine(baseDir, "mailbox", "Import"));
            System.IO.Directory.CreateDirectory(Path.Combine(baseDir, "mailbox", "Inbox"));
            System.IO.Directory.CreateDirectory(Path.Combine(baseDir, "mailbox", "Outbox"));
        }

        public static Encoding GetEncoding(string filename)
        {

            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode;
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode;
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }

        public static ImageList ImageList
        {
            get
            {
                if (_imageList == null)
                {
                    _imageList = new ImageList();
                    _imageList.Images.Add("mail", Properties.Resources.mailIcon);
                    _imageList.Images.Add("winFolder", Properties.Resources.windowsFolderIcon);
                    _imageList.Images.Add("openFolder", Properties.Resources.openFolder);
                    _imageList.Images.Add("folder", Properties.Resources.folder);
                    _imageList.Images.Add("mainSymbol", Properties.Resources.mail);
                }
                return _imageList;
            }
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

            if (e.Node == null) return;

            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            if (selected && unfocused)
            {
                Debug.WriteLine("TREE VIEW DRAW NOTE TRIGGERED");
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }

        }
        #endregion

    }
}
