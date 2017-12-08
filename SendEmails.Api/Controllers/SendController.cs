using System.Web.Http;
using SendEmails.Api.Services;
using SendEmails.Core.Models;

namespace SendEmails.Api.Controllers
{
    public class SendController : ApiController
    {

        // POST api/send
        public IHttpActionResult Post([FromBody]EmailMessage message)
        {
            var service = new SendEmailService();
            var result = service.SendEmailMessage(message);

            if (result != SendEmailService.SentOk)
            {
                return BadRequest(SendEmailService.SentError);
            }

            return Ok();
        }

    }
}
