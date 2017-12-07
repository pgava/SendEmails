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

            var emails = new InMemoryRepository<Email>(GateRepository());

            Emails = emails;
            Commit();
        }

        public IRepository<Email> Emails
        {
            get;
            set;
        }

        

        public void Commit()
        {
            

            Committed = true;
        }

        private List<Email> GateRepository()
        {
            return new List<Email>();

        }

        
    }
}
