# SendEmails
The solution has the following projects:
1. Api -> This project has the Api to send emails
2. Core -> This project defines the models
3. Infrastructure -> This project has the code to integrate with database
4. Web -> This is the web application
5. Tests -> Project for tests

Before you can run the application you need to set your configuration in the database. 
The table "EmailProviderParam" holds the configuration parameters.

Api: The key given to you when you registered with the email provider

domain: Domain for email address (mailgun)

from: Email address used when email is sent.


To run the application start the Api project then you can send email with the Web project.

Frameworks used in the solution:
Autofac, bootstrap, Entityframework, FluentAssertions, JQuery, ASP.Net MVC 5, Web API 2, Restsharp
