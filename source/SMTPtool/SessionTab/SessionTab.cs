using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMTPtool;
using System.Windows.Forms;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Net.Sockets;

namespace SMTPtool
{
    public class SessionTab
    {
        Main _linkToMain;
        Telnet mySessionForm;
        Thread ctThread;

        public Boolean isConnected = false;

        private String serverIP = "";
        private int serverPort;

        private String commandToSend = "";

        private List<string> hisItems = new List<string>();

        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        public SessionTab(Main _linkToMain)
        {
            this._linkToMain = _linkToMain;
            this._linkToMain.txtSessionCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
        }

        private static readonly Color ColorCommand = Color.FromArgb(100, 181, 246);
        private static readonly Color ColorResponse = Color.FromArgb(129, 199, 132);
        private static readonly Color ColorInfo = Color.FromArgb(255, 213, 79);
        private static readonly Color ColorSuccess = Color.FromArgb(102, 187, 106);
        private static readonly Color ColorError = Color.FromArgb(239, 83, 80);

        public void syncFromMain()
        {
            if (_linkToMain == null) return;
            if (!string.IsNullOrWhiteSpace(_linkToMain.cbxServer.Text))
                _linkToMain.cbxSessionServer.Text = _linkToMain.cbxServer.Text;
            if (!string.IsNullOrWhiteSpace(_linkToMain.txtPort.Text))
                _linkToMain.cbxSessionPort.Text = _linkToMain.txtPort.Text;
            if (!string.IsNullOrWhiteSpace(_linkToMain.cbxFrom.Text))
                _linkToMain.cbxSessionFrom.Text = _linkToMain.cbxFrom.Text;
            if (!string.IsNullOrWhiteSpace(_linkToMain.cbxTo.Text))
                _linkToMain.cbxSessionTo.Text = _linkToMain.cbxTo.Text;
            _linkToMain.txtSessionOutput.AppendText(">> Synchronized configuration from Main Tab.\r\n", ColorInfo);
            scrollDownOutput();
        }

        public void disconnect()
        {
            try
            {
                clientSocket?.Close();
                ctThread?.Abort();
            }
            catch { }
            isConnected = false;
            _linkToMain.Invoke((MethodInvoker)delegate
            {
                _linkToMain.txtSessionOutput.AppendText(">> Disconnected from server.\r\n", ColorError);
                _linkToMain.btnSessionConnect.Enabled = true;
                _linkToMain.btnSessionDisconnect.Enabled = false;
                _linkToMain.btnSessionSendLine.Enabled = false;
                _linkToMain.txtSessionCommand.ReadOnly = true;
                scrollDownOutput();
            });
        }

        public void connect()
        {
            start();
        }

        public void start()
        {
            _linkToMain.Invoke((MethodInvoker)delegate()
            {
                if (string.IsNullOrWhiteSpace(_linkToMain.cbxSessionServer.Text))
                {
                    _linkToMain.cbxSessionServer.Text = !string.IsNullOrWhiteSpace(_linkToMain.cbxServer.Text) ? _linkToMain.cbxServer.Text : "127.0.0.1";
                }
                serverIP = _linkToMain.cbxSessionServer.Text.Trim();

                try
                {
                    serverPort = int.Parse(_linkToMain.cbxSessionPort.Text.Trim());
                }
                catch
                {
                    serverPort = 25;
                    _linkToMain.cbxSessionPort.Text = "25";
                }

                _linkToMain.btnSessionConnect.Enabled = false;
                _linkToMain.btnSessionDisconnect.Enabled = true;
                _linkToMain.txtSessionOutput.AppendText($">> Connecting to {serverIP}:{serverPort}...\r\n", ColorInfo);
                scrollDownOutput();
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    clientSocket = new System.Net.Sockets.TcpClient();
                    var connectTask = clientSocket.ConnectAsync(serverIP, serverPort);
                    if (!connectTask.Wait(10000))
                    {
                        throw new TimeoutException("Connection attempt timed out (10s).");
                    }

                    isConnected = true;
                    _linkToMain.Invoke((MethodInvoker)delegate()
                    {
                        _linkToMain.txtSessionOutput.AppendText(">> Connected successfully!\r\n", ColorSuccess);
                        _linkToMain.btnSessionSendLine.Enabled = true;
                        _linkToMain.txtSessionCommand.ReadOnly = false;
                        scrollDownOutput();
                    });

                    ctThread = new System.Threading.Thread(new ThreadStart(Run))
                    {
                        IsBackground = true,
                        Name = "SessionWorker"
                    };
                    ctThread.Start();
                }
                catch (Exception ex)
                {
                    isConnected = false;
                    _linkToMain.Invoke((MethodInvoker)delegate()
                    {
                        _linkToMain.txtSessionOutput.AppendText($">> Connection Error: {ex.Message}\r\n", ColorError);
                        _linkToMain.btnSessionConnect.Enabled = true;
                        _linkToMain.btnSessionDisconnect.Enabled = false;
                        scrollDownOutput();
                    });
                }
            });
        }

        public void reconnect()
        {
            disconnect();
            start();
        }

        public void Run()
        {
            String strMessage;

            while (isConnected)
            {
                try
                {
                    strMessage = Read();
                    if (strMessage == null || strMessage.Equals(""))
                    {
                        _linkToMain.Invoke((MethodInvoker)delegate()
                        {
                            _linkToMain.txtSessionOutput.AppendText(">> Connection closed by remote host.\r\n", ColorError);
                            scrollDownOutput();
                            clientSocket.Close();
                            _linkToMain.btnSessionConnect.Enabled = true;
                            _linkToMain.btnSessionDisconnect.Enabled = false;
                            _linkToMain.btnSessionSendLine.Enabled = false;
                            _linkToMain.txtSessionCommand.ReadOnly = true;
                        });
                        break;
                    }
                    _linkToMain.Invoke((MethodInvoker)delegate()
                    {
                        _linkToMain.txtSessionOutput.AppendText("<< " + strMessage, ColorResponse);
                        scrollDownOutput();
                    });
                }
                catch (Exception exception)
                {
                    _linkToMain.Invoke((MethodInvoker)delegate()
                    {
                        _linkToMain.txtSessionOutput.AppendText("\r\n>> Error: Connection terminated (" + exception.Message + ")\r\n", ColorError);
                        scrollDownOutput();
                        _linkToMain.btnSessionConnect.Enabled = true;
                        _linkToMain.btnSessionDisconnect.Enabled = false;
                        _linkToMain.btnSessionSendLine.Enabled = false;
                        _linkToMain.txtSessionCommand.ReadOnly = true;
                    });
                    try { clientSocket.Close(); } catch { }
                    break;
                }
            }
        }

        private void scrollDownHist()
        {
            int visibleItems = _linkToMain.lbxSessionHistory.ClientSize.Height / _linkToMain.lbxSessionHistory.ItemHeight;
            _linkToMain.lbxSessionHistory.TopIndex = Math.Max(_linkToMain.lbxSessionHistory.Items.Count - visibleItems + 1, 0);
        }

        private void scrollDownOutput()
        {
            _linkToMain.txtSessionOutput.SelectionStart = _linkToMain.txtSessionOutput.Text.Length;
            _linkToMain.txtSessionOutput.ScrollToCaret();
        }

        private void input_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Debug.WriteLine("RETURN PRESS");

                hisItems.Add(_linkToMain.txtSessionCommand.Text);
                _linkToMain.lbxSessionHistory.DataSource = null;
                _linkToMain.lbxSessionHistory.DataSource = hisItems;
                _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);

                commandToSend = _linkToMain.txtSessionCommand.Text;
                _linkToMain.txtSessionCommand.Text = "";
                Write();
                scrollDownHist();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private String Read()
        {
            try
            {
                byte[] messageBytes = new byte[8192];
                int bytesRead = 0;
                NetworkStream clientStream = clientSocket.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                bytesRead = clientStream.Read(messageBytes, 0, 8192);
                string strMessage = encoder.GetString(messageBytes, 0, bytesRead);
                return strMessage;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("EEEEEEEEEEEEEEERRROR: READ " + exception.Message);
                _linkToMain.txtSessionOutput.AppendText("\r\nError - Connection closed\r\n", Color.Red);
                scrollDownOutput();
                clientSocket.Close();
                return null;
            }
        }

        private void Write()
        {
            if (clientSocket.Connected)
            {
                scrollDownOutput();

                NetworkStream clientStream = clientSocket.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(commandToSend + "\r\n");

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

                _linkToMain.txtSessionOutput.AppendText(">> " + commandToSend + "\r\n", ColorCommand);
                scrollDownOutput();
                commandToSend = "";
            }
        }

        public void btnSendLine_Click()
        {
            hisItems.Add(_linkToMain.txtSessionCommand.Text);
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);
            commandToSend = _linkToMain.txtSessionCommand.Text;
            _linkToMain.txtSessionCommand.Text = "";
            Write();
            scrollDownHist();
        }

        internal void startSessionInNewWindow()
        {

            mySessionForm = new Telnet();

            String serverIP = "";
            String serverPort = "";
            String from = "";
            String to = "";

            _linkToMain.Invoke((MethodInvoker)delegate()
            {
                if (_linkToMain.cbxServer.Text.Equals(""))
                {
                    _linkToMain.cbxSessionServer.Text = "192.168.0.1";
                }

                serverIP = _linkToMain.cbxSessionServer.Text;
                mySessionForm.setIP(serverIP);
                _linkToMain.addServerToList(_linkToMain.cbxSessionServer.Text);

                try
                {
                    int.Parse(_linkToMain.cbxSessionPort.Text);
                }
                catch (Exception)
                {
                    _linkToMain.cbxSessionPort.Text = "25";
                }
                serverPort = _linkToMain.cbxSessionPort.Text;

                from = _linkToMain.cbxSessionFrom.Text;
                to = _linkToMain.cbxSessionTo.Text;
            });

            mySessionForm.Text = "SMTP session to " + serverIP + " on port " + serverPort;
            mySessionForm.Show();

            mySessionForm.setPort(int.Parse(serverPort));
            mySessionForm.setFrom(_linkToMain.mailFromList);
            mySessionForm.setTo(_linkToMain.mailToList);

            mySessionForm.connect();

            _linkToMain.myParser.writeXML();

        }

        #region historyCommands
        public void btnResend_Click()
        {
            if (_linkToMain.lbxSessionHistory.SelectedIndex != -1)
            {
                commandToSend = _linkToMain.lbxSessionHistory.GetItemText(_linkToMain.lbxSessionHistory.SelectedItem);
                Write();

                if (_linkToMain.lbxSessionHistory.SelectedIndex != hisItems.Count - 1)
                {
                    _linkToMain.lbxSessionHistory.SetSelected(_linkToMain.lbxSessionHistory.SelectedIndex + 1, true);
                }
            }
        }

        public void btnClearCommand_Click()
        {
            int selectedIndex = _linkToMain.lbxSessionHistory.SelectedIndex;
            if (_linkToMain.lbxSessionHistory.SelectedIndex != -1)
            {
                hisItems.RemoveAt(_linkToMain.lbxSessionHistory.SelectedIndex);
                _linkToMain.lbxSessionHistory.DataSource = null;
                _linkToMain.lbxSessionHistory.DataSource = hisItems;
                if (selectedIndex == 0)
                {
                    if (hisItems.Count > 0)
                    {
                        _linkToMain.lbxSessionHistory.SetSelected(0, true);
                    }
                    else
                    {
                        _linkToMain.lbxSessionHistory.ClearSelected();
                    }
                }
                else
                {
                    _linkToMain.lbxSessionHistory.SetSelected(selectedIndex - 1, true);
                }
            }
        }
        #endregion

        #region quickCommands

        public void btnFrom_Click()
        {
            hisItems.Add("mail from: " + _linkToMain.cbxSessionFrom.Text);
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);

            commandToSend = "mail from:" + _linkToMain.cbxSessionFrom.Text;
            Write();
            scrollDownHist();
        }

        public void btnRcpt_Click()
        {
            hisItems.Add("rcpt to:" + _linkToMain.cbxSessionTo.Text);
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);

            commandToSend = "rcpt to:" + _linkToMain.cbxSessionTo.Text;
            Write();
            scrollDownHist();
        }

        public void btnData_Click()
        {
            hisItems.Add("data");
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);

            commandToSend = "data";
            Write();
            scrollDownHist();
        }

        public void btnHelo_Click()
        {
            hisItems.Add("ehlo " + _linkToMain.txtSessionEhlo.Text);
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);
            commandToSend = "ehlo " + _linkToMain.txtSessionEhlo.Text;
            Write();
            scrollDownHist();
        }

        public void btnQuit_Click()
        {
            hisItems.Add("quit");
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);

            commandToSend = "quit";
            Write();
            scrollDownHist();
        }

        public void btnDot_Click()
        {
            hisItems.Add(".");
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);

            commandToSend = ".";
            Write();
            scrollDownHist();
        }

        public void btnReset_Click()
        {
            hisItems.Add("rset");
            _linkToMain.lbxSessionHistory.DataSource = null;
            _linkToMain.lbxSessionHistory.DataSource = hisItems;
            _linkToMain.lbxSessionHistory.SetSelected(hisItems.Count - 1, true);

            commandToSend = "rset";
            Write();
            scrollDownHist();
        }
        #endregion

    }
}
