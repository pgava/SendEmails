using SendEmails.Core.Data;

namespace SendEmails.Infrastructure.Services
{
    public class FlightDataService : ISendEmailsService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public FlightDataService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

    }
}
