using System;
using SendEmails.Core.Data;

namespace SendEmails.Core.Models
{
    public class EmailProviderParam : IEntity
    {
        public int Id { get; set; }
        public int EmailProviderId { get; set; }
        public virtual EmailProvider EmailProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
