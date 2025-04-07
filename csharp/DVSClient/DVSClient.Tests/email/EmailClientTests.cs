using DVSClient.Email.Validate;
using DVSClient.Exceptions;
using DVSClientTests;
using NUnit.Framework;

namespace DVSClient.Email.Tests
{
    [TestFixture]
    public class EmailClientTests
    {
        [Test]
        public void Authentication_TokenNotSupplied_Throws()
        {
            var ex = Assert.Throws<InvalidConfigurationException>(() => Configuration.NewBuilder("").Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token");

            ex = Assert.Throws<InvalidConfigurationException>(() => Configuration.NewBuilder(null).Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token");
        }

        [Test]
        public void Authentication_InvalidTokenSupplied_Throws()
        {
            var token = "ThisIsNotAValidToken";
            var configuration = Configuration.NewBuilder(token).Build();
            var client = ExperianDataValidation.GetEmailClient(configuration);

            var ex = Assert.Throws<UnauthorizedException>(() => client.ValidateAsync("support@experian.com").GetAwaiter().GetResult());
            Assert.That(ex?.Message == "The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
        }

        [Test]
        public void Validate_Email()
        {
            var configuration = Configuration.NewBuilder(Setup.ValidTokenEmail)
                .SetTransactionId(new Guid().ToString())
                .IncludeMetadata()
                .Build();
            var emailClient = ExperianDataValidation.GetEmailClient(configuration);
            var result = emailClient.ValidateAsync("support@experian.com").GetAwaiter().GetResult();

            Assert.That(result.Error, Is.Null);
            Assert.That(result.DidYouMean, Is.Empty);
            Assert.That(result.Confidence, Is.EqualTo(Confidence.Illegitimate));
            Assert.That(result.VerboseOutput, Is.EqualTo(VerboseOutput.RoleAccount));
            Assert.That(result.DomainType, Is.EqualTo(DomainType.Business));
        }
    }
}