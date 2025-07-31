using DVSClient.Address;
using DVSClient.Address.Layout;
using DVSClient.Address.Layout.Elements;
using DVSClient.Exceptions;
using DVSClientTests;
using NUnit.Framework;

namespace DVSClient.Address.Layout.Tests
{
    /* 
    * These tests are dependent on pre-existing layouts being available.
    */
    [TestFixture]
    public class AddressLayoutTests
    {
        [OneTimeSetUp]
        public void TestSetup()
        {
            Setup.LoadEnv();

            // Some of these tests rely on pre-existing layouts because creating a layout during the tests is not feasible
            // This tests that they exist
            var testLayout = GetLayout(Setup.ExistingTestLayout);

            if (testLayout?.Error?.Title == "Not Found")
            {
                // Doesn't exist yet. Create it.
                CreateTestLayout();
                Assert.Fail($"The layout {Setup.ExistingTestLayout} did not exist. This has now been created but you will need to wait for the creation to complete (can be 10 minutes or so)");
            }
            else if (testLayout?.Layout?.Status != LayoutStatus.Completed)
            {
                Assert.Fail($"The layout {Setup.ExistingTestLayout} is not complete. Please wait for it to complete before running these tests (can be 10 minutes or so)");
            }

            // Clean up any test layout from previous runs (they need to have completed creation before they can be deleted
            DeleteTestLayouts();
        }

        [OneTimeTearDown]
        public void TestCleanup()
        {
            // Delete any layout created during the tests with the common prefix
            DeleteTestLayouts();
        }

        [Test]
        public void Layout_Get()
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            var result = client.GetLayout(Setup.ExistingTestLayout, Setup.GetUniqueReferenceId());
            Assert.That(result.Error, Is.Null);
        }

        [Test]
        public void Layout_Create()
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            var line1 = new LayoutLineVariable("addr_line_1");
            var line2 = new LayoutLineVariable("addr_line_2");
            var line3 = new LayoutLineFixed("post_code", Aus.PostalCode);
            var line4 = new LayoutLineFixed("country_name", Aus.CountryName);
            var layoutName = GetUniqueLayoutName();
            var createLayoutResult = client.CreateLayout(layoutName, new List<LayoutLineVariable> { line1, line2 }, new List<LayoutLineFixed> { line3, line4 }, Setup.GetUniqueReferenceId(), Dataset.AuAddress);
            Assert.That(createLayoutResult.Error, Is.Null);
            var result = client.GetLayout(layoutName, Setup.GetUniqueReferenceId());
            Assert.That(result.Error, Is.Null);
        }

        [Test]
        public void Layout_Create_WithOptions()
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            // TODO
            // Add your test logic here
        }

        [Test]
        public void Layout_Delete_DoesNotExist_Throws()
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            var layoutName = "ThisLayoutDoesntExist";

            var ex = Assert.Throws<NotFoundException>(() => client.DeleteLayout(layoutName, Setup.GetUniqueReferenceId()));
        }

        [Test]
        public void Format_WithCustomLayout_WithComponents()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .UseLayoutName(Setup.ExistingTestLayout)
                .IncludeComponents()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var searchResultAutoComplete = client.Search(SearchType.Autocomplete, "56 Queens R", Setup.GetUniqueReferenceId());
            var formatResult = client.Format(searchResultAutoComplete.Suggestions.First().GlobalAddressKey, Setup.GetUniqueReferenceId());
            Assert.That(formatResult.Confidence, Is.EqualTo(AddressConfidence.VerifiedMatch));
            //Assert.That(formatResult.GlobalAddressKey, Is.EqualTo(searchResultAutoComplete.Suggestions.First().GlobalAddressKey));
            Assert.That(formatResult.AddressFormatted, Is.Not.Null);
            Assert.That(formatResult.AddressFormatted?.LayoutName, Is.EqualTo(Setup.ExistingTestLayout));
            Assert.That(formatResult.AddressFormatted?.HasEnoughLines, Is.Null);
            Assert.That(formatResult.AddressFormatted?.HasTruncatedLines, Is.Null);
            Assert.That(formatResult.AddressFormatted?.HasMissingSubPremises, Is.Null);
            Assert.That(formatResult.AddressFormatted?.Address.Count, Is.EqualTo(4));
            Assert.That(formatResult.AddressFormatted?.Address["addr_line_1"], Is.Not.Empty);
            Assert.That(formatResult.AddressFormatted?.Address["addr_line_2"], Is.Not.Empty);
            Assert.That(formatResult.AddressFormatted?.Address["post_code"], Is.Not.Empty);
            Assert.That(formatResult.AddressFormatted?.Address["country_name"], Is.Not.Empty);

            Assert.That(formatResult.Components, Is.Not.Null);
            Assert.That(formatResult.Components?.PostalCode?.FullName, Is.EqualTo(formatResult.AddressFormatted?.Address["post_code"].ToUpperInvariant()));
        }

        [Test]
        public void Suggestions_Format_WithCustomLayout()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.AuAddress)
                .UseLayoutName(Setup.ExistingTestLayout)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.SuggestionsFormat("onslow st, perth", Setup.GetUniqueReferenceId());

            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            // When using a custom layout the Address objects should all be empty
            Assert.That(searchResult.Suggestions.All(x => x.Address == null));
            // When using a custom layout the AddressFormatted objects should all be empty
            Assert.That(searchResult.Suggestions.All(x => x.AddressFormatted != null));
        }

        [Test]
        public void ReferenceId_OnBuilderStillWorks()
        {
            // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
            var configuration = LayoutConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(Setup.StaticReferenceId)
                .Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            var result = client.GetLayout(Setup.ExistingTestLayout);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_OnMethodTakesPrecedence()
        {
            // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
            // Setting the reference ID on the method should take precedence
            var configuration = LayoutConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(Setup.GetUniqueReferenceId())
                .Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            var result = client.GetLayout(Setup.ExistingTestLayout, Setup.StaticReferenceId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_OnMethod()
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);

            var line1 = new LayoutLineVariable("addr_line_1");
            var line2 = new LayoutLineVariable("addr_line_2");
            var line3 = new LayoutLineFixed("post_code", Gbr.Postcode);
            var line4 = new LayoutLineFixed("country_name", Gbr.Town);

            var createLayoutResult = client.CreateLayout(
                this.GetUniqueLayoutName(),
                new List<LayoutLineVariable> { line1, line2 },
                new List<LayoutLineFixed> { line3, line4 },
                Setup.StaticReferenceId,
                Dataset.GbAddress);
            Assert.That(createLayoutResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            var getLayoutResult = client.GetLayout(Setup.ExistingTestLayout, Setup.StaticReferenceId);
            Assert.That(getLayoutResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            var getLayoutsResult = client.GetLayouts(Setup.StaticReferenceId);
            Assert.That(getLayoutsResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_NotValueSpecified_UsesRandomValue()
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            var result = client.GetLayout(Setup.ExistingTestLayout);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ReferenceId, Is.Not.Empty);
            Assert.That(result.ReferenceId, Is.Not.EqualTo(Setup.StaticReferenceId));
        }

        private string GetUniqueLayoutName()
        {
            return Setup.TestLayoutPrefix + Guid.NewGuid().ToString();
        }

        private GetLayoutResult GetLayout(string layoutName)
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            return client.GetLayout(layoutName, Setup.GetUniqueReferenceId());
        }

        private void CreateTestLayout()
        {
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            var line1 = new LayoutLineVariable("addr_line_1");
            var line2 = new LayoutLineVariable("addr_line_2");
            var line3 = new LayoutLineFixed("post_code", new List<IAddressElement?> { Aus.PostalCode, Gbr.Postcode });
            var line4 = new LayoutLineFixed("country_name", new List<IAddressElement?> { Aus.CountryName, Gbr.Country });
            var layoutName = Setup.ExistingTestLayout;
            var createLayoutResult = client.CreateLayout(
                layoutName, 
                new List<LayoutLineVariable> { line1, line2 },
                new List<LayoutLineFixed> { line3, line4 },
                Setup.GetUniqueReferenceId(),
                Dataset.AuAddress, Dataset.GbAddress);
            Assert.That(createLayoutResult.Error, Is.Null);
            var result = client.GetLayout(layoutName, Setup.GetUniqueReferenceId());
            Assert.That(result?.Layout?.Status.HasValue, Is.True);
            Assert.That(result?.Layout?.Status, Is.EqualTo(LayoutStatus.CreationInProgress));
        }

        private void DeleteTestLayouts()
        {
            // Get all layouts starting with the predefined prefix
            var configuration = LayoutConfiguration.NewBuilder(Setup.ValidTokenAddress).Build();
            var client = ExperianDataValidation.GetAddressLayoutClient(configuration);
            GetLayoutListResult layoutsResult;

            try
            {
                layoutsResult = client.GetLayouts(null, new List<Dataset>(), Setup.TestLayoutPrefix, Setup.GetUniqueReferenceId());
            }
            catch (NotFoundException)
            {
                // No layouts to delete
                return;
            }

            // Delete them
            foreach (var layout in layoutsResult.Layouts)
            {
                if (layout.Status == LayoutStatus.Completed && layout.Name != Setup.ExistingTestLayout)
                {
                    try
                    {
                        client.DeleteLayout(layout.Name, Setup.GetUniqueReferenceId());
                    }
                    catch (EDVSException)
                    {
                        Console.WriteLine($"Failed to delete layout {layout.Name}");
                    }
                }
            }
        }
    }
}