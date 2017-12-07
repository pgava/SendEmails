using System.Data.Entity;
using SendEmails.Core.Models;

namespace SendEmails.Infrastructure.EF
{
    public class DataEntities : DbContext
    {
        public DbSet<Email> Emails { get; set; }

        public DataEntities() : base("TestEFDb")
        {
            //Database.SetInitializer<DataEntities>(new DropCreateDatabaseAlways<DataEntities>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataEntities>());
        }
    }
}
