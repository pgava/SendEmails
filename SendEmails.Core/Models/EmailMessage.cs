using System;

namespace SendEmails.Core.Models
{
    public class EmailMessage
    {
        public string EmailTo { get; set; }
        public string EmailCc { get; set; }
        public string EmailBcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
