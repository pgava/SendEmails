using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using SendEmails.Core.Models;

namespace SendEmails.Api.Services
{
    public class Mailgun : IMailProvider
    {
        private readonly List<EmailProviderParam> _parameters;
        private Dictionary<string, string> _hashedParameters;

        public Mailgun(List<EmailProviderParam> parameters)
        {
            _parameters = parameters;
            FormatParameters();
        }

        private void FormatParameters()
        {
            _hashedParameters = new Dictionary<string, string>();
            foreach (var parameter in _parameters)
            {
                _hashedParameters.Add(parameter.Name, parameter.Value);
            }
        }
        public IRestResponse SendMessage(EmailMessage message)
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri(_hashedParameters["BaseUrl"]),
                Authenticator = new HttpBasicAuthenticator("api", _hashedParameters["Api"])
            };

            RestRequest request = new RestRequest();
            request.AddParameter("domain", _hashedParameters["domain"], ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", _hashedParameters["from"]);
            request.AddParameter("to", message.EmailTo);
            request.AddParameter("subject", message.Subject);
            request.AddParameter("text", message.Body);

            request.Method = Method.POST;

            return client.Execute(request);
        }
    }
}