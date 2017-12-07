using System;
using SendEmails.Core.Data;

namespace SendEmails.Core.Models
{
    public class EmailProvider : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
