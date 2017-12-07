namespace SendEmails.Web.Models
{
    public class Email
    {
        public string EmailTo { get; set; }
        public string EmailCc { get; set; }
        public string EmailBcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}