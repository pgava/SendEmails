using SendEmails.Core.Models;

namespace SendEmails.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF.DataEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.EmailProviders.AddOrUpdate(ep => ep.Id,
                new EmailProvider() {Id = 1, Type = "mailgun"},
                new EmailProvider() {Id = 2, Type = "sendgrid"}
            );

            context.EmailProviderParams.AddOrUpdate(epp => epp.Id,
                new EmailProviderParam() {Id = 1, EmailProviderId = 1, Name = "BaseUrl", Value = "https://api.mailgun.net/v3" },
                new EmailProviderParam() { Id = 2, EmailProviderId = 1, Name = "Api", Value = "" },
                new EmailProviderParam() { Id = 3, EmailProviderId = 1, Name = "domain", Value = "" },
                new EmailProviderParam() { Id = 4, EmailProviderId = 1, Name = "from", Value = "" },
                new EmailProviderParam() { Id = 5, EmailProviderId = 2, Name = "BaseUrl", Value = "https://api.sendgrid.com/v3" },
                new EmailProviderParam() { Id = 6, EmailProviderId = 2, Name = "Api", Value = "" },
                new EmailProviderParam() { Id = 7, EmailProviderId = 2, Name = "from", Value = "" }
            );

        }
    }
}
