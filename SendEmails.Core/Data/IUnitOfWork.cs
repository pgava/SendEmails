using SendEmails.Core.Models;

namespace SendEmails.Core.Data
{
    public interface IUnitOfWork
    {
        IRepository<Email> Emails { get; }
        IRepository<EmailProvider> EmailProviders { get; }
        IRepository<EmailProviderParam> EmailProviderParams { get; }

        void Commit();
    }
}
