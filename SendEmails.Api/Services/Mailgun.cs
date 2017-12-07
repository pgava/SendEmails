using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendEmails.Api.Services
{
    public class Mailgun
    {
        public static IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
            new HttpBasicAuthenticator("api", "");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox8a6724b0dd5647bcb61bbc0edc25f752.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox8a6724b0dd5647bcb61bbc0edc25f752.mailgun.org>");
            request.AddParameter("to", "Paolo <paolo_gava@hotmail.com>");
            request.AddParameter("subject", "Hello Paolo");
            request.AddParameter("text", "Congratulations Paolo, you just sent an email with Mailgun!  You are truly awesome!");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}