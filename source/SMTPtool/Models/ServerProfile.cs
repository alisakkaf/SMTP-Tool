using System;

namespace SMTPtool.Models
{
    public enum SslSecurityMode
    {
        Auto = 0,
        None = 1,
        SslTls = 2,
        StartTls = 3
    }

    [Serializable]
    public class ServerProfile
    {
        public string ProfileName { get; set; } = "Custom Server";
        public string ServerHost { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 25;
        public SslSecurityMode SecurityMode { get; set; } = SslSecurityMode.Auto;
        public bool RequiresAuthentication { get; set; } = false;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FromEmail { get; set; } = "sender@example.com";
        public string FromName { get; set; } = "SMTP Tool";
        public string ReplyTo { get; set; } = "";
        public string ToEmail { get; set; } = "recipient@example.com";
        public string CcEmail { get; set; } = "";
        public string BccEmail { get; set; } = "";
        public string Subject { get; set; } = "SMTP Tool - Test Message";
        public string Body { get; set; } = "Hello,\r\n\r\nThis is a test email sent using SMTP Tool v1.0 by AliSakkaF.\r\nDiagnostics and delivery test completed successfully.\r\n\r\nRegards,\r\nSMTP Tool";
        public bool IsHtml { get; set; } = false;

        public override string ToString()
        {
            return ProfileName;
        }
    }
}
