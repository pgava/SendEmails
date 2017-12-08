using System.Collections.Generic;
using RestSharp;
using SendEmails.Core.Models;

namespace SendEmails.Api.Services
{
    public interface IMailProvider
    {
        IRestResponse SendMessage(EmailMessage message);
    }
}