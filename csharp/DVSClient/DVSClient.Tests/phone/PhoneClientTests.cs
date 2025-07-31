using DVSClient.Exceptions;
using DVSClient.Phone.Validate;
using DVSClientTests;
using NUnit.Framework;

namespace DVSClient.Phone.Tests
{
    [TestFixture]
    public class PhoneClientTests
    {
        [OneTimeSetUp]
        public void TestSetup()
        {
            Setup.LoadEnv();
        }
        
        [Test]
        public void Authentication_TokenNotSupplied_Throws()
        {
            var ex = Assert.Throws<InvalidConfigurationException>(() => PhoneConfiguration.NewBuilder("").Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token.");

            ex = Assert.Throws<InvalidConfigurationException>(() => PhoneConfiguration.NewBuilder(null).Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token.");
        }

        [Test]
        public void Authentication_InvalidTokenSupplied_Throws()
        {
            var token = "ThisIsNotAValidToken";
            var configuration = PhoneConfiguration.NewBuilder(token).Build();
            var client = ExperianDataValidation.GetPhoneClient(configuration);

            var ex = Assert.Throws<UnauthorizedException>(() => client.ValidateAsync("+44123456767", Setup.GetUniqueReferenceId()).GetAwaiter().GetResult());
            Assert.That(ex?.Message == "The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
        }

        [Test]
        public void Validate_PhoneNumber_WithOutputFormat()
        {
            var configuration = PhoneConfiguration
                .NewBuilder(Setup.ValidTokenPhone)
                .UseOutputFormat("NATIONAL")
                .Build();
            var client = ExperianDataValidation.GetPhoneClient(configuration);
            var result = client.ValidateAsync("+442074987788", Setup.GetUniqueReferenceId()).GetAwaiter().GetResult();

            Assert.That(result.Confidence, Is.EqualTo(PhoneConfidence.NoCoverage));
            Assert.That(result.PhoneType, Is.EqualTo(PhoneType.Landline));
            Assert.That(result.FormattedPhoneNumber, Is.EqualTo("020 7498 7788"));
        }

        [Test]
        public void Validate_PhoneNumber_WithMetadata()
        {
            var configuration = PhoneConfiguration
                .NewBuilder(Setup.ValidTokenPhone)
                .IncludeMetadata()
                .Build();
            var client = ExperianDataValidation.GetPhoneClient(configuration);
            var result = client.ValidateAsync("+442074987788", Setup.GetUniqueReferenceId()).GetAwaiter().GetResult();

            Assert.That(result.Confidence, Is.EqualTo(PhoneConfidence.NoCoverage));
            Assert.That(result.PhoneType, Is.EqualTo(PhoneType.Landline));
            Assert.That(result.Metadata, Is.Not.Null);
            Assert.That(result.Metadata?.PhoneDetail, Is.Not.Null);
            Assert.That(result.Metadata?.PhoneDetail?.OriginalOperatorName, Is.EqualTo("BT"));
        }

        [Test]
        public void ReferenceId_OnBuilderStillWorks()
        {
            // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
            var configuration = PhoneConfiguration.NewBuilder(Setup.ValidTokenPhone)
                .SetTransactionId(Setup.StaticReferenceId)
                .Build();
            var emailClient = ExperianDataValidation.GetPhoneClient(configuration);
            var result = emailClient.ValidateAsync("+442074987788").GetAwaiter().GetResult();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_OnMethodTakesPrecedence()
        {
            // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
            // Setting the reference ID on the method should take precedence
            var configuration = PhoneConfiguration.NewBuilder(Setup.ValidTokenPhone)
                .SetTransactionId(Setup.GetUniqueReferenceId())
                .Build();
            var emailClient = ExperianDataValidation.GetPhoneClient(configuration);
            var result = emailClient.ValidateAsync("+442074987788", Setup.StaticReferenceId).GetAwaiter().GetResult();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_OnMethod()
        {
            var configuration = PhoneConfiguration.NewBuilder(Setup.ValidTokenPhone)
                .Build();
            var emailClient = ExperianDataValidation.GetPhoneClient(configuration);
            var result = emailClient.ValidateAsync("+442074987788", Setup.StaticReferenceId).GetAwaiter().GetResult();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_NotValueSpecified_UsesRandomValue()
        {
            var configuration = PhoneConfiguration.NewBuilder(Setup.ValidTokenPhone)
                 .Build();
            var emailClient = ExperianDataValidation.GetPhoneClient(configuration);
            var result = emailClient.ValidateAsync("+442074987788").GetAwaiter().GetResult();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReferenceId, Is.Not.Empty);
            Assert.That(result.ReferenceId, Is.Not.EqualTo(Setup.StaticReferenceId));
        }
    }
}