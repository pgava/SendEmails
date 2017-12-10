using System.Collections.Generic;
using SendEmails.Core.Models;

namespace SendEmails.Api.Services
{
    public interface IMailProviderFactory
    {
        IMailProvider CreatMailProvider(string providerType, List<EmailProviderParam> parameters);
    }
}