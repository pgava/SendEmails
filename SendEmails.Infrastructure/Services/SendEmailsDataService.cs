using System.Collections.Generic;
using System.Linq;
using SendEmails.Core.Data;
using SendEmails.Core.Models;

namespace SendEmails.Infrastructure.Services
{
    public class SendEmailDataService : ISendEmailsService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public SendEmailDataService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<EmailProvider> GetProviders()
        {
            return UnitOfWork.EmailProviders.GetAll().ToList();
        }

        public IEnumerable<EmailProviderParam> GetParamsForProvider(int id)
        {
            return UnitOfWork.EmailProviderParams.Find(p => p.EmailProviderId == id).ToList();
        }

    }
}
