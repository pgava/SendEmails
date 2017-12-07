using System.Data.Entity.Core.Objects;
using SendEmails.Core.Data;
using SendEmails.Core.Models;

namespace SendEmails.Infrastructure.EF
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private ObjectContext _context;
        private IRepository<Email> _emails;
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

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
