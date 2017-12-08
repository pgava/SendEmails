using System.Collections.Generic;
using System.Linq;
using SendEmails.Core.Models;
using SendEmails.Infrastructure.EF;
using SendEmails.Infrastructure.Services;

namespace SendEmails.Api.Services
{
    public class SendEmailService
    {
        public const string SentOk = "Email sent";
        public const string SentError = "We couldn't send email, please try again later";

        public string SendEmailMessage(EmailMessage message)
        {
            var uof = new SqlUnitOfWork();
            var dataService = new SendEmailDataService(uof);

            var providers = dataService.GetProviders();

            var factory = new MailProviderFactory();

            var emailSent = true;
            foreach (var provider in providers)
            {
                var parameters = dataService.GetParamsForProvider(provider.Id).ToList();

                var mailProvider = factory.CreatMailProvider(provider.Type, parameters);

                var response = mailProvider.SendMessage(message);

                if (response.IsSuccessful)
                {
                    break;
                }
            }

            return emailSent ? SentOk : SentError;
        }
    }
}