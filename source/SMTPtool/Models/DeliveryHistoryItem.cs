using System;
using System.Collections.Generic;

namespace SMTPtool.Models
{
    public class DeliveryHistoryItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 8);
        public bool Success { get; set; } = true;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Server { get; set; } = "";
        public int Port { get; set; } = 25;
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string Subject { get; set; } = "";
        public double DurationSeconds { get; set; } = 0.0;
        public string StatusMessage { get; set; } = "";
        public string LogTranscript { get; set; } = "";
        public string RawMimeContent { get; set; } = "";
        public string BodyContent { get; set; } = "";
        public bool IsHtml { get; set; } = false;
        public int AttachmentCount { get; set; } = 0;

        public bool DeliveryReceiptRequested { get; set; } = false;
        public bool IsDelivered { get; set; } = false;
        public DateTime? DeliveredTimestamp { get; set; }

        public bool OpenTrackingEnabled { get; set; } = false;
        public bool IsOpened { get; set; } = false;
        public DateTime? OpenedTimestamp { get; set; }
        public string OpenedIp { get; set; } = "";
        public string OpenTrackingUrl { get; set; } = "";

        public bool ClickTrackingEnabled { get; set; } = false;
        public bool IsClicked { get; set; } = false;
        public DateTime? ClickedTimestamp { get; set; }
        public string ClickedIp { get; set; } = "";
        public string ClickTrackingUrl { get; set; } = "";

        public string TrackingSummary
        {
            get
            {
                var list = new List<string>();
                if (IsDelivered)
                    list.Add("Delivered");
                else if (DeliveryReceiptRequested)
                    list.Add("Pending Delivery");

                if (OpenTrackingEnabled)
                {
                    if (IsOpened)
                        list.Add(OpenedTimestamp.HasValue ? $"Opened ({OpenedTimestamp.Value:HH:mm:ss})" : "Opened");
                    else
                        list.Add("Pending Open");
                }

                if (ClickTrackingEnabled)
                {
                    if (IsClicked)
                        list.Add(ClickedTimestamp.HasValue ? $"Clicked ({ClickedTimestamp.Value:HH:mm:ss})" : "Clicked");
                    else
                        list.Add("Pending Click");
                }

                return list.Count > 0 ? string.Join(" | ", list) : (Success ? "Delivered" : "Failed");
            }
        }
    }
}
