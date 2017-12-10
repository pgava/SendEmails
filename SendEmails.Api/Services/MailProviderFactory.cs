using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendEmails.Core.Models;

namespace SendEmails.Api.Services
{
    public class MailProviderFactory : IMailProviderFactory
    {
        public IMailProvider CreatMailProvider(string providerType, List<EmailProviderParam> parameters)
        {
            switch (providerType)
            {
                case "mailgun":
                    return new Mailgun(parameters);
                    break;
                case "sendgrid":
                    return new Sendgrid(parameters);
                    break;
                default:
                    throw new ArgumentException("unknown provider");
            }
        }
    }
}