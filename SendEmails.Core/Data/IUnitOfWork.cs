using SendEmails.Core.Models;

namespace SendEmails.Core.Data
{
    public interface IUnitOfWork
    {
        IRepository<Email> Emails { get; }
        void Commit();
    }
}
