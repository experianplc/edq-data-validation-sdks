using DVSClient.Exceptions;
using DVSClient.Phone.Validate;
using DVSClientTests;
using NUnit.Framework;

namespace DVSClient.Phone.Tests
{
    [TestFixture]
    public class PhoneClientTests
    {
        [Test]
        public void Authentication_TokenNotSupplied_Throws()
        {
            var ex = Assert.Throws<InvalidConfigurationException>(() => Configuration.NewBuilder("").Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token.");

            ex = Assert.Throws<InvalidConfigurationException>(() => Configuration.NewBuilder(null).Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token.");
        }

        [Test]
        public void Authentication_InvalidTokenSupplied_Throws()
        {
            var token = "ThisIsNotAValidToken";
            var configuration = Configuration.NewBuilder(token).Build();
            var client = ExperianDataValidation.GetPhoneClient(configuration);

            var ex = Assert.Throws<UnauthorizedException>(() => client.ValidateAsync("+44123456767").GetAwaiter().GetResult());
            Assert.That(ex?.Message == "The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
        }

        [Test]
        public void Validate_PhoneNumber_WithOutputFormat()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenPhone)
                .SetTransactionId(new Guid().ToString())
                .UseOutputFormat("NATIONAL")
                .Build();
            var client = ExperianDataValidation.GetPhoneClient(configuration);
            var result = client.ValidateAsync("+442074987788").GetAwaiter().GetResult();

            Assert.That(result.Confidence, Is.EqualTo(Confidence.NoCoverage));
            Assert.That(result.PhoneType, Is.EqualTo(PhoneType.Landline));
            Assert.That(result.FormattedPhoneNumber, Is.EqualTo("020 7498 7788"));
        }

        [Test]
        public void Validate_PhoneNumber_WithMetadata()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenPhone)
                .SetTransactionId(new Guid().ToString())
                .IncludeMetadata()
                .Build();
            var client = ExperianDataValidation.GetPhoneClient(configuration);
            var result = client.ValidateAsync("+442074987788").GetAwaiter().GetResult();

            Assert.That(result.Confidence, Is.EqualTo(Confidence.NoCoverage));
            Assert.That(result.PhoneType, Is.EqualTo(PhoneType.Landline));
            Assert.That(result.Metadata, Is.Not.Null);
            Assert.That(result.Metadata?.PhoneDetail, Is.Not.Null);
            Assert.That(result.Metadata?.PhoneDetail?.OriginalOperatorName, Is.EqualTo("BT"));
        }
    }
}