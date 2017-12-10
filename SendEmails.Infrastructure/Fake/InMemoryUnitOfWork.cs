using System;
using System.Collections.Generic;
using System.Linq;
using SendEmails.Core.Data;
using SendEmails.Core.Models;

namespace SendEmails.Infrastructure.Fake
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {

        public bool Committed { get; set; }

        public InMemoryUnitOfWork()
        {
            Committed = false;

            var emails = new InMemoryRepository<Email>(EmailRepository());
            var providers = new InMemoryRepository<EmailProvider>(ProviderRepository());
            var parameters = new InMemoryRepository<EmailProviderParam>(ParameterRepository());

            Emails = emails;
            EmailProviders = providers;
            EmailProviderParams = parameters;

            Commit();
        }

        public IRepository<Email> Emails
        {
            get;
            set;
        }

        public IRepository<EmailProvider> EmailProviders
        {
            get;
            set;
        }

        public IRepository<EmailProviderParam> EmailProviderParams
        {
            get;
            set;
        }

        public void Commit()
        {
            

            Committed = true;
        }

        private List<Email> EmailRepository()
        {
            return new List<Email>();

        }

        private List<EmailProvider> ProviderRepository()
        {
            return new List<EmailProvider>
            {
                new EmailProvider
                {
                    Id = 1,
                    Type = "mailgun"
                },
                new EmailProvider
                {
                    Id = 2,
                    Type = "Sendgrid"
                }
            };

        }

        private List<EmailProviderParam> ParameterRepository()
        {
            return new List<EmailProviderParam>
            {
                new EmailProviderParam
                {
                    EmailProviderId = 1,
                    Name = "Api",
                    Value = "val1"
                },
                new EmailProviderParam
                {
                    EmailProviderId = 2,
                    Name = "Api",
                    Value = "val2"
                }
            };

        }
    }
}
