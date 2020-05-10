using System.Collections.Generic;

namespace ChurchSMS.Models
{
    public class SmsOutgoingMessage
    {
        public string id { get; set; }
        public string to { get; set; }
        public string message { get; set; }
        public int? priority { get; set; }
        public string type { get; set; }
    }

    public class SmsEventSend
    {
        public string @event { get; set; }
        public ICollection<SmsOutgoingMessage> messages { get; set; }
    }

    public class SMSEvents
    {
        public ICollection<SmsEventSend> events { get; set; }
    }
}