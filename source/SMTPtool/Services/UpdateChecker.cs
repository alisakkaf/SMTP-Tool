using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMTPtool.Services
{
    public class UpdateInfo
    {
        public bool IsNewVersionAvailable { get; set; }
        public string CurrentVersion { get; set; } = "v1.0";
        public string LatestVersion { get; set; } = "v1.0";
        public string ReleaseUrl { get; set; } = "https://github.com/alisakkaf/SMTP-Tool/releases";
        public string ReleaseNotes { get; set; } = "";
        public string AuthorName { get; set; } = "AliSakkaF";
        public string AuthorUrl { get; set; } = "https://alisakkaf.com";
        public string Message { get; set; } = "";
    }

    public class UpdateChecker
    {
        public static string CurrentVersion => "v" + Main.CURRENT_VERSION;
        private const string GITHUB_API_URL = "https://api.github.com/repos/alisakkaf/SMTP-Tool/releases/latest";
        private const string GITHUB_REPO_URL = "https://github.com/alisakkaf/SMTP-Tool";

        public static async Task<UpdateInfo> CheckForUpdatesAsync()
        {
            string localVer = CurrentVersion;
            var info = new UpdateInfo
            {
                CurrentVersion = localVer,
                LatestVersion = localVer,
                ReleaseUrl = GITHUB_REPO_URL
            };

            await Task.Run(() =>
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GITHUB_API_URL);
                    request.UserAgent = "SMTP-Tool-Client-" + localVer;
                    request.Timeout = 5000;
                    request.ReadWriteTimeout = 5000;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        Match match = Regex.Match(json, "\"tag_name\"\\s*:\\s*\"([^\"]+)\"");
                        if (match.Success)
                        {
                            string rawTag = match.Groups[1].Value.Trim();
                            string normalizedTag = rawTag.StartsWith("v", StringComparison.OrdinalIgnoreCase)
                                ? "v" + rawTag.Substring(1).Trim()
                                : "v" + rawTag;

                            info.LatestVersion = normalizedTag;

                            Match urlMatch = Regex.Match(json, "\"html_url\"\\s*:\\s*\"([^\"]+)\"");
                            if (urlMatch.Success)
                            {
                                info.ReleaseUrl = urlMatch.Groups[1].Value;
                            }

                            if (IsVersionHigher(normalizedTag, localVer))
                            {
                                info.IsNewVersionAvailable = true;
                                info.Message = "New version " + normalizedTag + " is available on GitHub!";
                            }
                            else
                            {
                                info.IsNewVersionAvailable = false;
                                info.Message = "SMTP Tool " + localVer + " is up to date.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    info.IsNewVersionAvailable = false;
                    info.Message = "SMTP Tool " + localVer + " | AliSakkaF (alisakkaf.com)";
                    info.ReleaseNotes = ex.Message;
                }
            });

            return info;
        }

        private static bool IsVersionHigher(string candidate, string current)
        {
            try
            {
                string[] candParts = candidate.Trim().TrimStart('v', 'V').Split('.');
                string[] currParts = current.Trim().TrimStart('v', 'V').Split('.');

                int candMajor = candParts.Length > 0 && int.TryParse(candParts[0], out int cMaj) ? cMaj : 0;
                int candMinor = candParts.Length > 1 && int.TryParse(candParts[1], out int cMin) ? cMin : 0;
                int currMajor = currParts.Length > 0 && int.TryParse(currParts[0], out int rMaj) ? rMaj : 0;
                int currMinor = currParts.Length > 1 && int.TryParse(currParts[1], out int rMin) ? rMin : 0;

                if (candMajor > currMajor) return true;
                if (candMajor == currMajor && candMinor > currMinor) return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
