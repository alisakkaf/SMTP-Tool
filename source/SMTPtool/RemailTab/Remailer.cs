using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using SMTPtool.helper;

namespace SMTPtool
{
    public class Remailer
    {
        private string serverIP;
        private int serverPort;
        private string commandToSend;
        private string lastCommand = "none";
        private string mailFrom;
        private string rcptTo;

        TcpClient clientSocket;

        private DateTime sendStart;
        private DateTime sendEnd;
        private bool messageSent = false;
        private bool mailFromSent = false;

        public Main _linkToMain;
        public bool sendSingle;
        public string fullMailBody;
        private int chunkSize = 0;

        Thread ctThread;

        public Remailer(Main _linkToMain)
        {
            this._linkToMain = _linkToMain;
        }

        public void connect()
        {
            _linkToMain.btnRemail.Enabled = false;
            if (_linkToMain.cbxRemailIP.Text.Equals(""))
            {
                _linkToMain.cbxRemailIP.Text = "192.168.0.1";
            }
            serverIP = _linkToMain.cbxRemailIP.Text;
            _linkToMain.addServerToList(serverIP);

            try { int.Parse(_linkToMain.txtRemailPort.Text); }
            catch { _linkToMain.txtRemailPort.Text = "25"; }
            serverPort = int.Parse(_linkToMain.txtRemailPort.Text);

            try
            {
                var addr = new System.Net.Mail.MailAddress(_linkToMain.cbxRemailFrom.Text);
                mailFrom = _linkToMain.cbxRemailFrom.Text;
            }
            catch
            {
                _linkToMain.cbxRemailFrom.Text = "";
                mailFrom = _linkToMain.cbxRemailFrom.Text;
            }
            _linkToMain.addMailFromtoList(mailFrom);

            try
            {
                var addr = new System.Net.Mail.MailAddress(_linkToMain.cbxRemailTo.Text);
                rcptTo = _linkToMain.cbxRemailTo.Text;
            }
            catch
            {
                _linkToMain.cbxRemailTo.Text = "default@test.test";
                rcptTo = _linkToMain.cbxRemailTo.Text;
            }
            _linkToMain.addRcptToToList(rcptTo);

            try
            {
                clientSocket = new TcpClient();
                clientSocket.Connect(serverIP, serverPort);

                ctThread = new Thread(new ThreadStart(run));
                ctThread.IsBackground = true;
                ctThread.Start();
                sendStart = DateTime.Now;
            }
            catch (Exception exception)
            {
                _linkToMain.txtRemailOutput.AppendText(">> Connection Error: " + exception.Message + "\r\n", Color.Red);
                scrollDownOutput();
                _linkToMain.btnRemail.Enabled = true;
            }
        }

        public void run()
        {
            while (true)
            {
                string strMessage = read();

                if (strMessage == null)
                {
                    _linkToMain.Invoke((MethodInvoker)delegate()
                    {
                        if (!messageSent)
                        {
                            _linkToMain.txtRemailOutput.AppendText(">> Error: Connection lost or server reset connection\r\n", Color.Red);
                            scrollDownOutput();
                        }
                        clientSocket.Close();
                        ctThread.Abort();
                        _linkToMain.btnRemail.Enabled = true;
                    });
                    break;
                }
                else if (strMessage.StartsWith("220") && lastCommand.Equals("none"))
                {
                    string hostname = strMessage.Split(' ', ' ')[1];
                    commandToSend = "HELO " + hostname;
                    lastCommand = "helo";
                    write();
                }
                else if ((strMessage.StartsWith("250") && mailFromSent == false) && lastCommand.Equals("helo"))
                {
                    commandToSend = "mail from: <" + mailFrom + ">";
                    mailFromSent = true;
                    lastCommand = "mailFrom";
                    write();
                }
                else if ((strMessage.StartsWith("250 2.1.0") || strMessage.StartsWith("250 " + mailFrom) || strMessage.StartsWith("250 Go ahead")) && lastCommand.Equals("mailFrom"))
                {
                    commandToSend = "rcpt to: <" + rcptTo + ">";
                    lastCommand = "rcpt";
                    write();
                }
                else if ((strMessage.StartsWith("250 2.1.5") || strMessage.StartsWith("250 " + rcptTo) || strMessage.StartsWith("250 Go ahead")) && lastCommand.Equals("rcpt"))
                {
                    commandToSend = "data";
                    lastCommand = "data";
                    write();
                }
                else if (strMessage.StartsWith("354") && lastCommand.Equals("data"))
                {
                    if (fullMailBody == null)
                    {
                        fullMailBody = !string.IsNullOrEmpty(_linkToMain.remailTab?.currentRawMime)
                            ? _linkToMain.remailTab.currentRawMime
                            : _linkToMain.txtMailView.Text;
                    }

                    using (StringReader sr = new StringReader(fullMailBody))
                    {
                        string line;
                        string singleChunk = "";
                        List<string> messageChunks = new List<string>();
                        int currentLine = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (chunkSize == 0)
                            {
                                singleChunk = singleChunk + line + "\r\n";
                            }
                            else
                            {
                                if (currentLine < chunkSize)
                                {
                                    if (currentLine == chunkSize + 1)
                                    {
                                        singleChunk = singleChunk + line;
                                    }
                                    else
                                    {
                                        singleChunk = singleChunk + line + "\r\n";
                                    }
                                    currentLine++;
                                }
                                else
                                {
                                    messageChunks.Add(singleChunk);
                                    singleChunk = "";
                                    singleChunk = singleChunk + line + "\r\n";
                                    currentLine = 0;
                                }
                            }
                        }
                        if (!singleChunk.Equals(""))
                        {
                            messageChunks.Add(singleChunk);
                        }

                        foreach (string chunk in messageChunks)
                        {
                            commandToSend = chunk;
                            writeChunk();
                        }
                    }
                    commandToSend = ".";
                    lastCommand = "content";
                    write();
                }
                else if (strMessage.StartsWith("250") && lastCommand.Equals("content"))
                {
                    messageSent = true;
                    sendEnd = DateTime.Now;
                    commandToSend = "quit";
                    write();
                }
                else
                {
                    _linkToMain.Invoke((MethodInvoker)delegate()
                    {
                        if (messageSent)
                        {
                            _linkToMain.txtRemailOutput.AppendText(">> Message Sent Successfully\r\n", Color.DarkGreen);
                            TimeSpan duration = sendEnd - sendStart;
                            _linkToMain.txtRemailOutput.AppendText(">> Duration: " + duration.TotalSeconds.ToString("0.00") + "s\r\n", Color.DarkGreen);
                            scrollDownOutput();
                            _linkToMain.btnRemail.Enabled = true;
                            lastCommand = "none";
                            mailFromSent = false;
                            messageSent = false;
                            clientSocket.Close();
                            ctThread.Abort();
                        }
                        else
                        {
                            _linkToMain.txtRemailOutput.AppendText(">> Unexpected server response: " + strMessage + "\r\n", Color.Red);
                            scrollDownOutput();
                            _linkToMain.btnRemail.Enabled = true;
                            clientSocket.Close();
                            ctThread.Abort();
                        }
                    });
                    break;
                }
            }
        }

        public string read()
        {
            try
            {
                byte[] messageBytes = new byte[8192];
                int bytesRead = 0;
                NetworkStream clientStream = clientSocket.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                bytesRead = clientStream.Read(messageBytes, 0, 8192);
                string strMessage = encoder.GetString(messageBytes, 0, bytesRead);

                if (strMessage.Equals(""))
                {
                    return null;
                }

                if (sendSingle)
                {
                    _linkToMain.Invoke((MethodInvoker)delegate()
                    {
                        _linkToMain.txtRemailOutput.AppendText("<< " + strMessage, Color.DarkBlue);
                        scrollDownOutput();
                    });
                }

                return strMessage;
            }
            catch (Exception)
            {
                scrollDownOutput();
                clientSocket.Close();
                return null;
            }
        }

        public void write()
        {
            if (clientSocket.Connected)
            {
                if (sendSingle)
                {
                    scrollDownOutput();
                }
                NetworkStream clientStream = clientSocket.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(commandToSend + "\r\n");

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

                if (sendSingle)
                {
                    _linkToMain.txtRemailOutput.AppendText(">> " + commandToSend + "\r\n", Color.Green);
                    scrollDownOutput();
                }

                commandToSend = "";
            }
        }

        public string getTimeStamp()
        {
            return DateTime.Now.ToString("MMM dd HH:mm:ss");
        }

        public void writeChunk()
        {
            if (clientSocket.Connected)
            {
                scrollDownOutput();
                NetworkStream clientStream = clientSocket.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(commandToSend);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

                if (sendSingle)
                {
                    _linkToMain.txtRemailOutput.AppendText(">> \r\n" + commandToSend, Color.Green);
                    scrollDownOutput();
                }

                commandToSend = "";
            }
        }

        private void scrollDownOutput()
        {
            try
            {
                _linkToMain.Invoke((MethodInvoker)delegate()
                {
                    _linkToMain.txtRemailOutput.SelectionStart = _linkToMain.txtRemailOutput.Text.Length;
                    _linkToMain.txtRemailOutput.ScrollToCaret();
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Data);
            }
        }
    }
}
