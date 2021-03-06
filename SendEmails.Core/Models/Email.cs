﻿using System;
using SendEmails.Core.Data;

namespace SendEmails.Core.Models
{
    public class Email : IEntity
    {
        public int Id { get; set; }
        public int EmailProviderId { get; set; }
        public virtual EmailProvider EmailProvider { get; set; }
        public string EmailTo { get; set; }
        public string EmailCc { get; set; }
        public string EmailBcc { get; set; }
        public DateTime SendDateTime { get; set; }
    }
}
