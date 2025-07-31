using DVSClient.Address.Format;
using DVSClient.Address.Lookup;
using DVSClient.Address.Validate;
using DVSClient.Common;
using DVSClient.Exceptions;
using DVSClientTests;
using NUnit.Framework;

namespace DVSClient.Address.Tests
{

    public class AddressClientTests
    {
        [OneTimeSetUp]
        public void TestSetup()
        {
            Setup.LoadEnv();
        }

        [Test]
        public void Authentication_TokenNotSupplied_Throws()
        {
            var ex = Assert.Throws<InvalidConfigurationException>(() => AddressConfiguration.NewBuilder("").Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token.");

            ex = Assert.Throws<InvalidConfigurationException>(() => AddressConfiguration.NewBuilder(null).Build());
            Assert.That(ex?.Message == "The supplied configuration must contain an authorisation token.");
        }

        [Test]
        public void Authentication_InvalidTokenSupplied_Throws()
        {
            const string token = "ThisIsNotAValidToken";
            var configuration = AddressConfiguration
                .NewBuilder(token)
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<UnauthorizedException>(() => client.Search(SearchType.Autocomplete, "56 Queens R", Setup.GetUniqueReferenceId()));
            Assert.That(ex?.Message == "The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
        }

        [Test]
        public void Authentication_AlternateTokenSupplied()
        {
            // Use the alternate token in the x-app-key header instead of Auth-Token header
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetUseXAppAuthentication()
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            Assert.That(configuration.GetCommonHeaders(Setup.StaticReferenceId).Keys.Contains("x-app-key"));
            Assert.That(configuration.GetCommonHeaders(Setup.StaticReferenceId)["x-app-key"], Is.EqualTo(Setup.ValidTokenAddress));

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "experian, nottingham, NG80 1ZZ", Setup.GetUniqueReferenceId());

            // Just assert that there is no error, which means the alternative token was used successfully to search 
            Assert.That(searchResult, Is.Not.Null);
        }

        [Test]
        public void ReferenceId_OnBuilderStillWorks()
        {
            // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(Setup.StaticReferenceId)
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search("experian, nottingham, NG80 1ZZ");

            Assert.That(searchResult, Is.Not.Null);
            Assert.That(searchResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_OnMethodTakesPrecedence()
        {
            // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
            // Setting the reference ID on the method should take precedence
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(Setup.GetUniqueReferenceId())
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search("experian, nottingham, NG80 1ZZ", Setup.StaticReferenceId);

            Assert.That(searchResult, Is.Not.Null);
            Assert.That(searchResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_OnMethod()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search("experian, nottingham, NG80 1ZZ", Setup.StaticReferenceId);
            Assert.That(searchResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            var validateResult = client.Validate("experian, nottingham, NG80 1ZZ", Setup.StaticReferenceId);
            Assert.That(validateResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            var lookupResult = client.Lookup("NG80 1ZZ", LookupType.PostalCode, Setup.StaticReferenceId);
            Assert.That(lookupResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            var formatResult = client.Format(searchResult.Suggestions.First().GlobalAddressKey, Setup.StaticReferenceId);
            Assert.That(formatResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            var typedownResult = client.Search(SearchType.Typedown, "mk65bj");
            var stepinResult = client.SuggestionsStepIn(typedownResult.Suggestions.First().GlobalAddressKey, Setup.StaticReferenceId);
            Assert.That(stepinResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            stepinResult = client.SuggestionsStepIn(stepinResult.Suggestions.First().GlobalAddressKey);
            var refineResult = client.SuggestionsRefine(stepinResult.Suggestions.First().GlobalAddressKey, "30", Setup.StaticReferenceId);
            Assert.That(refineResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));

            var getDatasetsResult = client.GetDatasets(Country.UnitedKingdom, Setup.StaticReferenceId);
            Assert.That(getDatasetsResult.ReferenceId, Is.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void ReferenceId_NotValueSpecified_UsesRandomValue()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search("experian, nottingham, NG80 1ZZ");

            Assert.That(searchResult, Is.Not.Null);
            Assert.That(searchResult.ReferenceId, Is.Not.Empty);
            Assert.That(searchResult.ReferenceId, Is.Not.EqualTo(Setup.StaticReferenceId));
        }

        [Test]
        public void Lookup_NoDatasets_Throws()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .Build();

            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<EDVSException>(() => client.Lookup("SW1E 5JL", LookupType.PostalCode, Setup.GetUniqueReferenceId()));
            Assert.That(ex?.Message, Is.EqualTo("No datasets have been supplied in the configuration."));
        }

        [Test]
        public void DatasetsFromDifferentCountries_Throws()
        {
            try
            {
                var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .UseDataset(Dataset.AuAddress)
                .Build();
                Assert.Fail("Expected InvalidConfigurationException was not thrown.");
            }
            catch (InvalidConfigurationException ex)
            {
                Assert.That(ex?.Message, Is.EqualTo("Multiple datasets are currently only supported for the United Kingdom"));
            }

        }

        [Test]
        public async Task Lookup_WithNoOptions_ReturnsExpectedResults()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var result = await client.LookupAsync("SW1E 5JL", LookupType.PostalCode, Setup.GetUniqueReferenceId());

            Assert.That(result.Confidence, Is.EqualTo(AddressConfidence.NoMatches));
            Assert.That(result.MoreResultsAvailable, Is.False);
            Assert.That(result.Suggestions!.Count, Is.EqualTo(1));
            Assert.That(result.Suggestions!.ElementAt(0).Locality?.Region?.Name, Is.EqualTo("England"));
            Assert.That(result.Suggestions!.ElementAt(0).Locality?.SubRegion?.Name, Is.EqualTo("Greater London"));
            Assert.That(result.Suggestions!.ElementAt(0).Locality?.Town?.Name, Is.EqualTo("London"));
            Assert.That(result.Suggestions!.ElementAt(0).LocalityKey?.Length, Is.GreaterThan(0));
            Assert.That(result.Suggestions!.ElementAt(0).PostalCodeKey?.Length, Is.GreaterThan(0));
            Assert.That(result.Suggestions!.ElementAt(0).PostalCode?.FullName, Is.EqualTo("SW1E 5JL"));
        }

        [Test]
        public async Task Lookup_With_Options_ReturnsExpectedResults()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = await client.LookupAsync("SW1E 5", LookupType.PostalCode, Setup.GetUniqueReferenceId());
            Assert.That(result.Confidence, Is.EqualTo(AddressConfidence.NoMatches));

            //Number of suggestions should be the default max of 7
            Assert.That(result.Suggestions!.Count, Is.EqualTo(7));

            //Test max suggestions of 3
            configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .UseMaxSuggestions(3)
                .Build();
            client = ExperianDataValidation.GetAddressClient(configuration);
            result = await client.LookupAsync("SW1E 5", LookupType.PostalCode, Setup.GetUniqueReferenceId());
            Assert.That(result.Suggestions!.Count, Is.EqualTo(3));

            //Add address and final address
            configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .SetLookupAddAddresses()
                .SetLookupAddFinalAddress()
                .Build();
            client = ExperianDataValidation.GetAddressClient(configuration);
            result = await client.LookupAsync("SW1E 5", LookupType.PostalCode, Setup.GetUniqueReferenceId());
            //There should be the default 100 addresses
            Assert.That(result.Addresses!.Count, Is.EqualTo(100));

            //Make that number lower
            configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .SetLookupAddAddresses()
                .SetLookupAddFinalAddress()
                .SetLookupMaxAddressses(20)
                .Build();
            client = ExperianDataValidation.GetAddressClient(configuration);
            result = await client.LookupAsync("SW1E 5", LookupType.PostalCode, Setup.GetUniqueReferenceId());
            Assert.That(result.Addresses!.Count, Is.EqualTo(20));
        }

        [Test]
        public void Timeouts()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetApiRequestTimeoutInSeconds(2)
                .SetHttpClientTimeoutInSeconds(3)
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Autocomplete, "1 main st", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Throws()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.IeAdditionalEircode)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Singleline, "some input", Setup.GetUniqueReferenceId()));
            Assert.That(ex?.Message, Is.EqualTo("Unsupported dataset / search type combination."));
        }

        [Test]
        public void DatasetSearchTypeCombinations_Valid()
        {
            var configurationAutocomplete = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAdditionalBusiness)
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .Build();
            var clientAutocomplete = ExperianDataValidation.GetAddressClient(configurationAutocomplete);
            clientAutocomplete.Search(SearchType.Autocomplete, "80 Victoria St", Setup.GetUniqueReferenceId());

            var configurationSingleline = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAdditionalBusiness)
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .UseDataset(Dataset.GbAdditionalNotyetbuilt)
                .Build();
            var clientSingleline = ExperianDataValidation.GetAddressClient(configurationSingleline);
            clientSingleline.Search(SearchType.Singleline, "Experian, Cardinal Place, 80 Victoria St, London", Setup.GetUniqueReferenceId());

            var configurationTypedown = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .UseDataset(Dataset.GbAdditionalNotyetbuilt)
                .Build();
            var clientTypedown = ExperianDataValidation.GetAddressClient(configurationTypedown);
            clientTypedown.Search(SearchType.Typedown, "London", Setup.GetUniqueReferenceId());
        }

        [Test]
        public void DatasetSearchTypeCombinations_Valid_ButOutOfOrder()
        {
            var configurationAutocomplete = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .UseDataset(Dataset.GbAdditionalBusiness)
                .Build();
            var clientAutocomplete = ExperianDataValidation.GetAddressClient(configurationAutocomplete);
            clientAutocomplete.Search(SearchType.Autocomplete, "80 Victoria St", Setup.GetUniqueReferenceId());
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Singleline_Throws()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddressWales)
                .UseDataset(Dataset.GbAdditionalNames)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Singleline, "Experian, Cardinal Place, 80 Victoria St, London", Setup.GetUniqueReferenceId()));
            Assert.That(ex?.Message == "Unsupported dataset / search type combination.");
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Autocomplete_Throws()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAdditionalBusiness)
                .UseDataset(Dataset.GbAdditionalNames)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Autocomplete, "1 main st,", Setup.GetUniqueReferenceId()));
            Assert.That(ex?.Message == "Unsupported dataset / search type combination.");
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Typedown_Throws()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddressAddressbase)
                .UseDataset(Dataset.GbAdditionalNotyetbuilt)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Typedown, "London", Setup.GetUniqueReferenceId()));
            Assert.That(ex?.Message == "Unsupported dataset / search type combination.");
        }

        [Test]
        public void Search_Attributes_MaxSuggestions()
        {
            // Max suggestions set to 20 - should return at most 20 items in the list of suggestions
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Singleline, "mk65bj", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.Count, Is.EqualTo(20));

            // Max suggestions set to 5 - should return at most 5 items in the list of suggestions
            configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .UseMaxSuggestions(5)
                .Build();
            client = ExperianDataValidation.GetAddressClient(configuration);

            searchResult = client.Search(SearchType.Singleline, "mk65bj", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.Count, Is.EqualTo(5));
        }

        [Test]
        public void Search_Attributes_Location()
        {
            // No location set - default ordering alphabetical
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.UsAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Autocomplete, "1 main st", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            // Ensure that not ALL suggestions are in the state of CA. Results are ordered alphabetically by city.
            Assert.That(searchResult.Suggestions.Any(x => !x.Text.Contains(" CA ")));

            // Location set to Los Angeles - search results are weighted towards LA. The list of suggestions contains matching addresses
            // closer to the provided lat/long
            configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.UsAddress)
                .UseLocation("34.052235, -118.243683")
                .Build();
            client = ExperianDataValidation.GetAddressClient(configuration);

            searchResult = client.Search(SearchType.Autocomplete, "1 main st", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            // Ensure all results are in the state of California
            Assert.That(searchResult.Suggestions.All(x => x.Text.Contains(" CA ")));
        }

        [Test]
        public void Search_Address_Autocomplete()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.AuAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Autocomplete, "56 Queens R", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            // Pick the first one
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatResult = client.Format(globalAddressKey, Setup.GetUniqueReferenceId());
            Assert.That(formatResult.Confidence, Is.Not.Null);
            Assert.That(formatResult.GlobalAddressKey, Is.Not.Null);
        }

        [Test]
        public void Search_Address_Singleline()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.AuAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Singleline, "56 Queens R", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatResult = client.Format(globalAddressKey, Setup.GetUniqueReferenceId());
            Assert.That(formatResult.Confidence, Is.Not.Null);
            Assert.That(formatResult.GlobalAddressKey, Is.Not.Null);
        }

        [Test]
        public void Search_Address_Typedown()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Typedown, "mk65bj", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            while (searchResult.Suggestions.Any(x => x.AdditionalAttributes.Any(y => y.Name == "can_step_in" && y.Value == "true")))
            {
                searchResult = client.SuggestionsStepIn(searchResult.Suggestions.First(x => x.AdditionalAttributes.Any(y => y.Name == "can_step_in" && y.Value == "true")).GlobalAddressKey, Setup.GetUniqueReferenceId());
            }

            var globalAddressKey = searchResult.Suggestions.First(x => x.AdditionalAttributes.Any(y => y.Name == "full_address" && y.Value == "true")).GlobalAddressKey;

            // Format with default layout
            var formatResult = client.Format(globalAddressKey, Setup.GetUniqueReferenceId());
            Assert.That(formatResult.Confidence, Is.Not.Null);
            Assert.That(formatResult.GlobalAddressKey, Is.Not.Null);
        }

        [Test]
        public void Suggestions_Refine()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Typedown, "melbourne", Setup.GetUniqueReferenceId());
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            searchResult = client.SuggestionsStepIn(searchResult.Suggestions.First().GlobalAddressKey, Setup.GetUniqueReferenceId());

            // Ensure an informational picklist was returned that prompts for more user input
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.First().AdditionalAttributes.Any(x => x.Name == "information" && x.Value == "true"));

            // Use the user input to refine the list of suggestions
            searchResult = client.SuggestionsRefine(searchResult.Suggestions.First().GlobalAddressKey, "ro", Setup.GetUniqueReferenceId());

            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.All(x => x.Text.StartsWith("ro", StringComparison.OrdinalIgnoreCase)));
        }

        [Test]
        public void Suggestions_Format()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.SuggestionsFormat("160, SE1 8EZ", Setup.GetUniqueReferenceId());

            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.All(x => x.Address != null));
            Assert.That(searchResult.Suggestions.All(x => x.AddressFormatted == null));
        }

        [Test]
        public void Validate_Address()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.GetUniqueReferenceId());

            Assert.That(result.Confidence, Is.EqualTo(AddressConfidence.VerifiedMatch));
            Assert.That(result.Address, Is.Not.Null);
            Assert.That(result.AddressFormatted, Is.Null);
            Assert.That(result.Address?.AddressLine1, Is.EqualTo("U 1  8 Main Ave"));
            Assert.That(result.Address?.AddressLine2, Is.Empty);
            Assert.That(result.Address?.AddressLine3, Is.Empty);
            Assert.That(result.Address?.Locality, Is.EqualTo("LIDCOMBE"));
            Assert.That(result.Address?.Region, Is.EqualTo("NSW"));
            Assert.That(result.Address?.PostalCode, Is.EqualTo("2141"));
            Assert.That(result.Address?.Country, Is.EqualTo("AUSTRALIA"));
            Assert.That(result.MatchConfidence, Is.EqualTo(ValidateMatchConfidence.High));
            Assert.That(result.MatchType, Is.EqualTo(ValidateMatchType.FullMatchWithPostalCode));
        }

        [Test]
        public void Validate_Address_ReturnsMultiple()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Validate("Main Ave, Lidcombe, 2141", Setup.GetUniqueReferenceId());

            Assert.That(result.Confidence, Is.EqualTo(AddressConfidence.StreetPartial));
            Assert.That(result.Suggestions.Count(), Is.EqualTo(7));
            Assert.That(result.Address, Is.Null);
            Assert.That(result.AddressFormatted, Is.Null);
            Assert.That(result.SuggestionsKey, Is.Not.Empty);
            Assert.That(result.SuggestionsPrompt, Is.Not.Empty);
        }

        [Test]
        public void Validate_WithComponents()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.AuAddress)
                .IncludeComponents()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.GetUniqueReferenceId());

            Assert.That(result.Components, Is.Not.Null);
            Assert.That(result.Components?.PostalCode, Is.Not.Null);
            Assert.That(result.Components?.PostalCode?.FullName, Is.EqualTo("2141"));
            Assert.That(result.Components?.Street, Is.Not.Null);
            Assert.That(result.Components?.Street?.FullName, Is.EqualTo("Main Ave"));
            Assert.That(result.Components?.Street?.Name, Is.EqualTo("Main"));
            Assert.That(result.Components?.Street?.Type, Is.EqualTo("Ave"));
        }

        [Test]
        public void Validate_WithEnrichment()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .UseDataset(Dataset.AuAddress)
                .IncludeEnrichment()
                .IncludeAusRegionalGeocodes()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.GetUniqueReferenceId());

            Assert.That(result.Enrichment, Is.Not.Null);
            Assert.That(result.Enrichment?.AusRegionalGeocodes, Is.Not.Null);
            Assert.That(result.Enrichment?.AusRegionalGeocodes?.Longitude, Is.Positive);
            Assert.That(result.Enrichment?.AusRegionalGeocodes?.Latitude, Is.Negative);
        }

        [Test]
        public void Validate_WithMetadata()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .UseDataset(Dataset.AuAddress)
                .IncludeMetadata()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.GetUniqueReferenceId());

            Assert.That(result.Metadata, Is.Not.Null);
            Assert.That(result.Metadata?.Dpid, Is.Not.Null);
            Assert.That(result.Metadata?.Hin, Is.Not.Null);
        }

        [Test]
        public void Validate_WithMatchInfo()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .UseDataset(Dataset.AuAddress)
                .IncludeExtraMatchInfo()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.GetUniqueReferenceId());

            Assert.That(result.MatchInfo, Is.Not.Null);
            Assert.That(result.MatchInfo?.PostalCodeAction, Is.EqualTo(PostalCodeAction.Ok));
            Assert.That(result.MatchInfo?.AddressAction, Is.EqualTo(AddressAction.Corrected));
            Assert.That(result.MatchInfo?.GenericInfo, Is.Not.Null);
            Assert.That(result.MatchInfo?.GenericInfo?.Contains("address_cleaned"), Is.True);
            Assert.That(result.MatchInfo?.AusInfo, Is.Not.Null);
            Assert.That(result.MatchInfo?.AusInfo?.Contains("bsp_state_nsw"), Is.True);

            // All other countries should be null
            Assert.That(result.MatchInfo?.GbrInfo, Is.Null);
        }

        [Test]
        public void Datasets_Valid()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.GetDatasets(Country.UnitedKingdom, Setup.GetUniqueReferenceId());

            Assert.That(result.Result, Is.Not.Empty);
            Assert.That(result.Result?.All(p => p.Country == Country.UnitedKingdom), Is.True);
        }

        [Test]
        public void Format_WithMetadata()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .IncludeMetadata()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian", Setup.GetUniqueReferenceId());

            // Pick the first one
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey, Setup.GetUniqueReferenceId());

            Assert.That(formatted.Metadata, Is.Not.Null);
            Assert.That(formatted.Metadata?.Udprn, Is.Not.Null);
            Assert.That(formatted.Metadata?.PafAddressKey, Is.Not.Null);
        }

        [Test]
        public void Format_WithComponents()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAddress)
                .IncludeComponents()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian", Setup.GetUniqueReferenceId());

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey, Setup.GetUniqueReferenceId());

            Assert.That(formatted.Components, Is.Not.Null);
            Assert.That(formatted.Components?.Organization, Is.Not.Null);
            Assert.That(formatted.Components?.Organization?.CompanyName, Is.Not.Null);
            Assert.That(formatted.Components?.Street, Is.Not.Null);
            Assert.That(formatted.Components?.Street?.FullName, Is.Not.Null);
        }

        [Test]
        public void Search_Address_Autocomplete_AdditionalDatasets()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddress)
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Search("flat 3, block a, oxford court, 23 stretford road, manchester, m15 6dd", Setup.GetUniqueReferenceId());

            Assert.That(result.Suggestions.Any(p => p.Dataset == "Multiple Residence"), Is.True);
        }

        [Test]
        public void Format_WithEnrichment_SelectAllElementsFromEnrichmentSet()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .UseDataset(Dataset.GbAddress)
                .IncludeEnrichment()
                .IncludeGlobalGeocodes()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian", Setup.GetUniqueReferenceId());

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey, Setup.GetUniqueReferenceId());

            Assert.That(formatted.Enrichment, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.Latitude, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.Longitude, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.MatchLevel, Is.EqualTo(GeocodeMatchLevel.Place));
        }

        [Test]
        public void Format_WithEnrichment_SelectSpecificElementsFromEnrichmentSet()
        {
            var configuration = AddressConfiguration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .UseDataset(Dataset.GbAddress)
                .IncludeEnrichment()
                .IncludeGlobalGeocodeAttribute(Layout.Attributes.GlobalGeocodeAttribute.Latitude)
                .IncludeGlobalGeocodeAttribute(Layout.Attributes.GlobalGeocodeAttribute.Longitude)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian", Setup.GetUniqueReferenceId());

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey, Setup.GetUniqueReferenceId());

            Assert.That(formatted.Enrichment, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.Latitude, Is.Positive);
            Assert.That(formatted.Enrichment?.Geocodes?.Longitude, Is.Negative);

            // MatchLevel should be null as attribute was not requested
            Assert.That(formatted.Enrichment?.Geocodes?.MatchLevel, Is.Null);
        }
    }
}