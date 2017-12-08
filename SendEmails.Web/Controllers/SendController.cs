using System;
using System.Web.Http;
using RestSharp;
using SendEmails.Core.Models;

namespace SendEmails.Web.Controllers
{
    public class SendController : ApiController
    {
        // POST api/values
        public IHttpActionResult Post([FromBody]EmailMessage email)
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("http://localhost:11749")
            };

            RestRequest request = new RestRequest();
            request.Resource = "api/send";
            request.AddJsonBody(email);

            request.Method = Method.POST;

            var result = client.Execute(request);

            if (!result.IsSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
