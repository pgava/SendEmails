using System;
using System.Linq;
using SendEmails.Core.Data;
using SendEmails.Core.Models;

namespace SendEmails.Api.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly ISendEmailDataService _sendEmailDataService;
        private readonly IMailProviderFactory _mailProviderFactory;
        public const string SentOk = "Email sent";
        public const string SentError = "We couldn't send email, please try again later";

        public SendEmailService(ISendEmailDataService sendEmailDataService, IMailProviderFactory mailProviderFactory)
        {
            _sendEmailDataService = sendEmailDataService;
            _mailProviderFactory = mailProviderFactory;
        }

        public string SendEmailMessage(EmailMessage message)
        {
            var providers = _sendEmailDataService.GetProviders();

            var emailSent = false;
            foreach (var provider in providers)
            {
                var parameters = _sendEmailDataService.GetParamsForProvider(provider.Id).ToList();

                var mailProvider = _mailProviderFactory.CreatMailProvider(provider.Type, parameters);

                var response = mailProvider.SendMessage(message);

                if (response.IsSuccessful)
                {
                    emailSent = true;
                    var email = new Email
                    {
                        EmailTo = message.EmailTo,
                        EmailCc = message.EmailCc,
                        EmailBcc = message.EmailBcc,
                        EmailProvider = provider,
                        SendDateTime = DateTime.Now
                    };
                    _sendEmailDataService.SetEmailLog(email);
                    break;
                }
            }

            return emailSent ? SentOk : SentError;
        }
    }
}