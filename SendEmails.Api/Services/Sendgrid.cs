using RestSharp;
using System;
using System.Collections.Generic;
using SendEmails.Core.Models;

namespace SendEmails.Api.Services
{
    public class Sendgrid : IMailProvider
    {
        private readonly List<EmailProviderParam> _parameters;
        private Dictionary<string, string> _hashedParameters;

        public Sendgrid(List<EmailProviderParam> parameters)
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

            };

            RestRequest request = new RestRequest();
            request.Resource = "mail/send";

            var personalzations = BuildSendGridData(message, _hashedParameters);

            request.AddJsonBody(personalzations);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {_hashedParameters["Api"]}");
           
            request.Method = Method.POST;

            return client.Execute(request);
        }

        private static SendGridData BuildSendGridData(EmailMessage message, Dictionary<string, string> parameters)
        {
            var to = message.EmailTo.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
            var tos = new List<EmailFormat>();
            foreach (var e in to)
            {
                tos.Add(new EmailFormat
                {
                    Email = e
                });
            }
            var personalzations = new SendGridData
            {
                Personalizations = new PersonalizationFormat[]
                {
                    new PersonalizationFormat
                    {
                        To = tos.ToArray()
                    }
                },
                From = new EmailFormat
                {
                    Email = parameters["from"]
                },
                Content = new ContentFormat[]
                {
                    new ContentFormat
                    {
                        Type = "text/plain",
                        Value = message.Body
                    }
                },
                Subject = message.Subject
            };
            return personalzations;
        }
    }

    public class SendGridData
    {
        public PersonalizationFormat[] Personalizations { get; set; }
        //public string[] Cc { get; set; }
        //public string[] Bcc { get; set; }
        public EmailFormat From { get; set; }
        public string Subject { get; set; }
        public ContentFormat[] Content { get; set; }
    }

    public class PersonalizationFormat
    {
        public EmailFormat[] To { get; set; }
    }

    public class EmailFormat
    {
        public string Email { get; set; }
    }
    public class ContentFormat
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}