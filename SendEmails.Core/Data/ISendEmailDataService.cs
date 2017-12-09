using System.Collections.Generic;
using SendEmails.Core.Models;

namespace SendEmails.Core.Data
{
    public interface ISendEmailDataService
    {
        IEnumerable<EmailProvider> GetProviders();
        IEnumerable<EmailProviderParam> GetParamsForProvider(int id);
        void SetEmailLog(Email email);
    }
}
