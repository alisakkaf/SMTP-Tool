using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using SMTPtool.Models;

namespace SMTPtool.Services
{
    public class ProfileManager
    {
        private static readonly string ProfilesFilePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetEntryAssembly() != null ? Assembly.GetEntryAssembly().Location : AppDomain.CurrentDomain.BaseDirectory),
            "profiles.xml"
        );

        public List<ServerProfile> Profiles { get; private set; } = new List<ServerProfile>();

        public ProfileManager()
        {
            LoadProfiles();
        }

        public void LoadProfiles()
        {
            Profiles = new List<ServerProfile>();

            Profiles.Add(new ServerProfile
            {
                ProfileName = "Custom Server (Custom)",
                ServerHost = "127.0.0.1",
                Port = 25,
                SecurityMode = SslSecurityMode.Auto,
                RequiresAuthentication = false,
                Username = "",
                Password = "",
                FromEmail = "sender@example.com",
                FromName = "Custom Sender",
                ToEmail = "recipient@example.com",
                Subject = "SMTP Tool - Custom Server Test"
            });

            Profiles.Add(new ServerProfile
            {
                ProfileName = "Gmail (smtp.gmail.com)",
                ServerHost = "smtp.gmail.com",
                Port = 587,
                SecurityMode = SslSecurityMode.StartTls,
                RequiresAuthentication = true,
                Username = "user@gmail.com",
                FromEmail = "user@gmail.com",
                FromName = "Gmail User",
                Subject = "SMTP Tool - Gmail Test"
            });

            Profiles.Add(new ServerProfile
            {
                ProfileName = "Outlook / Office 365",
                ServerHost = "smtp.office365.com",
                Port = 587,
                SecurityMode = SslSecurityMode.StartTls,
                RequiresAuthentication = true,
                Username = "user@outlook.com",
                FromEmail = "user@outlook.com",
                FromName = "Outlook User",
                Subject = "SMTP Tool - Outlook 365 Test"
            });

            Profiles.Add(new ServerProfile
            {
                ProfileName = "Amazon SES",
                ServerHost = "email-smtp.us-east-1.amazonaws.com",
                Port = 587,
                SecurityMode = SslSecurityMode.StartTls,
                RequiresAuthentication = true,
                Username = "SES_ACCESS_KEY_ID",
                FromEmail = "verified-sender@example.com",
                FromName = "AWS SES Sender",
                Subject = "SMTP Tool - Amazon SES Test"
            });

            Profiles.Add(new ServerProfile
            {
                ProfileName = "Yahoo Mail",
                ServerHost = "smtp.mail.yahoo.com",
                Port = 465,
                SecurityMode = SslSecurityMode.SslTls,
                RequiresAuthentication = true,
                Username = "user@yahoo.com",
                FromEmail = "user@yahoo.com",
                FromName = "Yahoo User",
                Subject = "SMTP Tool - Yahoo Mail Test"
            });

            Profiles.Add(new ServerProfile
            {
                ProfileName = "Localhost Postfix / MailHog",
                ServerHost = "127.0.0.1",
                Port = 25,
                SecurityMode = SslSecurityMode.None,
                RequiresAuthentication = false,
                Username = "",
                FromEmail = "tester@localhost",
                FromName = "Localhost Tester",
                Subject = "SMTP Tool - Localhost Test"
            });

            if (File.Exists(ProfilesFilePath))
            {
                try
                {
                    XDocument doc = XDocument.Load(ProfilesFilePath);
                    foreach (var elem in doc.Root.Elements("profile"))
                    {
                        var p = new ServerProfile
                        {
                            ProfileName = elem.Attribute("name") != null ? elem.Attribute("name").Value : "Custom Profile",
                            ServerHost = elem.Element("host") != null ? elem.Element("host").Value : "127.0.0.1",
                            Port = elem.Element("port") != null ? int.Parse(elem.Element("port").Value) : 25,
                            SecurityMode = elem.Element("sslMode") != null ? (SslSecurityMode)Enum.Parse(typeof(SslSecurityMode), elem.Element("sslMode").Value) : SslSecurityMode.Auto,
                            RequiresAuthentication = elem.Element("auth") != null && bool.Parse(elem.Element("auth").Value),
                            Username = elem.Element("user") != null ? elem.Element("user").Value : "",
                            Password = elem.Element("pass") != null ? DecodeSecret(elem.Element("pass").Value) : "",
                            FromEmail = elem.Element("from") != null ? elem.Element("from").Value : "sender@example.com",
                            FromName = elem.Element("fromName") != null ? elem.Element("fromName").Value : "SMTP Tool",
                            ReplyTo = elem.Element("replyTo") != null ? elem.Element("replyTo").Value : "",
                            ToEmail = elem.Element("to") != null ? elem.Element("to").Value : "recipient@example.com",
                            Subject = elem.Element("subject") != null ? elem.Element("subject").Value : "SMTP Tool Test",
                            Body = elem.Element("body") != null ? elem.Element("body").Value : "",
                            IsHtml = elem.Element("isHtml") != null && bool.Parse(elem.Element("isHtml").Value)
                        };
                        Profiles.Add(p);
                    }
                }
                catch
                {
                }
            }
        }

        public void SaveCustomProfiles()
        {
            try
            {
                var customProfiles = Profiles.Skip(6).ToList();
                XElement root = new XElement("profiles");

                foreach (var p in customProfiles)
                {
                    XElement elem = new XElement("profile",
                        new XAttribute("name", p.ProfileName),
                        new XElement("host", p.ServerHost),
                        new XElement("port", p.Port),
                        new XElement("sslMode", p.SecurityMode.ToString()),
                        new XElement("auth", p.RequiresAuthentication),
                        new XElement("user", p.Username ?? ""),
                        new XElement("pass", EncodeSecret(p.Password ?? "")),
                        new XElement("from", p.FromEmail ?? ""),
                        new XElement("fromName", p.FromName ?? ""),
                        new XElement("replyTo", p.ReplyTo ?? ""),
                        new XElement("to", p.ToEmail ?? ""),
                        new XElement("subject", p.Subject ?? ""),
                        new XElement("body", p.Body ?? ""),
                        new XElement("isHtml", p.IsHtml)
                    );
                    root.Add(elem);
                }

                XDocument doc = new XDocument(root);
                doc.Save(ProfilesFilePath);
            }
            catch
            {
            }
        }

        public void AddOrUpdateProfile(ServerProfile profile)
        {
            var existing = Profiles.FirstOrDefault(x => x.ProfileName.Equals(profile.ProfileName, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                int index = Profiles.IndexOf(existing);
                Profiles[index] = profile;
            }
            else
            {
                Profiles.Add(profile);
            }
            SaveCustomProfiles();
        }

        public void DeleteProfile(string profileName)
        {
            var existing = Profiles.Skip(6).FirstOrDefault(x => x.ProfileName.Equals(profileName, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                Profiles.Remove(existing);
                SaveCustomProfiles();
            }
        }

        private static string EncodeSecret(string plain)
        {
            if (string.IsNullOrEmpty(plain)) return "";
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plain));
        }

        private static string DecodeSecret(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return "";
            try
            {
                return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            }
            catch
            {
                return "";
            }
        }
    }
}
