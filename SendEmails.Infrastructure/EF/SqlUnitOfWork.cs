using System.Data.Entity.Core.Objects;
using SendEmails.Core.Data;
using SendEmails.Core.Models;

namespace SendEmails.Infrastructure.EF
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private ObjectContext _context;
        private IRepository<Email> _emails;
        private IRepository<EmailProvider> _emailProviders;
        private IRepository<EmailProviderParam> _emailProviderParams;
        private DataEntities _contextEntities;

        public SqlUnitOfWork()
        {
            _contextEntities = new DataEntities();
            _context = _contextEntities.GetObjectContext();
            _context.ContextOptions.LazyLoadingEnabled = true;
        }

        public IRepository<Email> Emails
        {
            get { return _emails ?? (_emails = new SqlRepository<Email>(_context)); }
        }

        public IRepository<EmailProvider> EmailProviders
        {
            get { return _emailProviders ?? (_emailProviders = new SqlRepository<EmailProvider>(_context)); }
        }

        public IRepository<EmailProviderParam> EmailProviderParams
        {
            get { return _emailProviderParams ?? (_emailProviderParams = new SqlRepository<EmailProviderParam>(_context)); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
