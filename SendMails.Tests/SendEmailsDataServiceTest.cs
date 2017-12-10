using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SendEmails.Infrastructure.Fake;
using SendEmails.Infrastructure.Services;
using System.Linq;

namespace SendMails.Tests
{
    [TestClass]
    public class SendEmailsDataServiceTest
    {
        [TestMethod]
        public void ShouldBeAbleToGetProviders()
        {
            var sut = new SendEmailDataService(new InMemoryUnitOfWork());
            var providers = sut.GetProviders();

            providers.Should().NotBeNull();
            providers.Count().Should().Be(2);
        }

        [TestMethod]
        public void ShouldBeAbleToGetProviderParameters()
        {
            var sut = new SendEmailDataService(new InMemoryUnitOfWork());
            var parameters = sut.GetParamsForProvider(1);

            parameters.Should().NotBeNull();
            parameters.Count().Should().Be(1);
        }
    }
}
