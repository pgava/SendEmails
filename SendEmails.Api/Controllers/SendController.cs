using System.Web.Http;
using SendEmails.Api.Services;
using SendEmails.Core.Models;

namespace SendEmails.Api.Controllers
{
    public class SendController : ApiController
    {
        private readonly ISendEmailService _sendEmailService;

        public SendController(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }
        // POST api/send
        public IHttpActionResult Post([FromBody]EmailMessage message)
        {
            var result = _sendEmailService.SendEmailMessage(message);

            if (result != SendEmailService.SentOk)
            {
                return BadRequest(SendEmailService.SentError);
            }

            return Ok();
        }

    }
}
