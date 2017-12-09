using SendEmails.Core.Models;

namespace SendEmails.Api.Services
{
    public interface ISendEmailService
    {
        string SendEmailMessage(EmailMessage message);
    }
}