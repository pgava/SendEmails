using System.Data.Entity;
using SendEmails.Core.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SendEmails.Infrastructure.EF
{
    public class DataEntities : DbContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailProvider> EmailProviders { get; set; }
        public DbSet<EmailProviderParam> EmailProviderParams { get; set; }

        public DataEntities() : base("SendEmails")
        {
            //Database.SetInitializer<DataEntities>(new DropCreateDatabaseAlways<DataEntities>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataEntities>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
