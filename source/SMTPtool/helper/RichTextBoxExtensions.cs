using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SMTPtool
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this System.Windows.Forms.RichTextBox box, string text, Color color)
        {
            box.Invoke((MethodInvoker)delegate()
            {
                if (text.Length > 1000)
                {
                                IEnumerable<String> myChunks = Split(text, 100);
                                foreach(String chunk in myChunks){
                                    box.SelectionStart = box.TextLength;
                                    box.SelectionLength = 0;

                                    box.SelectionColor = color;
                                    box.AppendText(chunk);
                                    box.SelectionColor = box.ForeColor;

                                }
                            }
                            else {
                                box.SelectionStart = box.TextLength;
                                box.SelectionLength = 0;

                                box.SelectionColor = color;
                                box.AppendText(text);
                                box.SelectionColor = box.ForeColor;
                            }

                        });

        }

        static IEnumerable<String> Split(String str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
