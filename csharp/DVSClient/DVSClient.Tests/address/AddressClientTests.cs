using DVSClient.Address.Format;
using DVSClient.Common;
using DVSClient.Exceptions;
using DVSClientTests;
using NUnit.Framework;

namespace DVSClient.Address.Tests
{
    public class AddressClientTests
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
            const string token = "ThisIsNotAValidToken";
            var configuration = Configuration
                .NewBuilder(token)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<UnauthorizedException>(() => client.Search(SearchType.Autocomplete, "56 Queens R"));
            Assert.That(ex?.Message == "The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
        }

        [Test]
        public void Authentication_AlternateTokenSupplied()
        {
            // Use the alternate token in the x-app-key header instead of Auth-Token header
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetUseXAppAuthentication()
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            Assert.That(configuration.GetCommonHeaders().Keys.Contains("x-app-key"));
            Assert.That(configuration.GetCommonHeaders()["x-app-key"], Is.EqualTo(Setup.ValidTokenAddress));

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "experian, nottingham, NG80 1ZZ");

            // Just assert that there is no error, which means the alternative token was used successfully to search 
            Assert.That(searchResult, Is.Not.Null);
        }

        [Test]
        public void Timeouts()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .SetApiRequestTimeoutInSeconds(2)
                .SetHttpClientTimeoutInSeconds(3)
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Autocomplete, "1 main st");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Throws()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.IeAdditionalEircode)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Singleline, "some input"));
            Assert.That(ex?.Message, Is.EqualTo("Unsupported dataset / search type combination."));
        }

        [Test]
        public void DatasetSearchTypeCombinations_Valid()
        {
            var configurationAutocomplete = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAdditionalBusiness)
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .Build();
            var clientAutocomplete = ExperianDataValidation.GetAddressClient(configurationAutocomplete);
            clientAutocomplete.Search(SearchType.Autocomplete, "80 Victoria St");

            var configurationSingleline = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAdditionalBusiness)
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .UseDataset(Dataset.GbAdditionalNotyetbuilt)
                .Build();
            var clientSingleline = ExperianDataValidation.GetAddressClient(configurationSingleline);
            clientSingleline.Search(SearchType.Singleline, "Experian, Cardinal Place, 80 Victoria St, London");

            var configurationTypedown = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .UseDataset(Dataset.GbAdditionalNotyetbuilt)
                .Build();
            var clientTypedown = ExperianDataValidation.GetAddressClient(configurationTypedown);
            clientTypedown.Search(SearchType.Typedown, "London");
        }

        [Test]
        public void DatasetSearchTypeCombinations_Valid_ButOutOfOrder()
        {
            var configurationAutocomplete = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .UseDataset(Dataset.GbAdditionalBusiness)
                .Build();
            var clientAutocomplete = ExperianDataValidation.GetAddressClient(configurationAutocomplete);
            clientAutocomplete.Search(SearchType.Autocomplete, "80 Victoria St");
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Singleline_Throws()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddressWales)
                .UseDataset(Dataset.GbAdditionalNames)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Singleline, "Experian, Cardinal Place, 80 Victoria St, London"));
            Assert.That(ex?.Message == "Unsupported dataset / search type combination.");
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Autocomplete_Throws()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAdditionalBusiness)
                .UseDataset(Dataset.GbAdditionalNames)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Autocomplete, "1 main st,"));
            Assert.That(ex?.Message == "Unsupported dataset / search type combination.");
        }

        [Test]
        public void DatasetSearchTypeCombinations_Invalid_Typedown_Throws()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddressAddressbase)
                .UseDataset(Dataset.GbAdditionalNotyetbuilt)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var ex = Assert.Throws<EDVSException>(() => client.Search(SearchType.Typedown, "London"));
            Assert.That(ex?.Message == "Unsupported dataset / search type combination.");
        }

        [Test]
        public void Search_Attributes_MaxSuggestions()
        {
            // Max suggestions set to 20 - should return at most 20 items in the list of suggestions
            var configuration = Configuration 
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Singleline, "mk65bj");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.Count, Is.EqualTo(20));

            // Max suggestions set to 5 - should return at most 5 items in the list of suggestions
            configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .UseMaxSuggestions(5)
                .Build();
            client = ExperianDataValidation.GetAddressClient(configuration);

            searchResult = client.Search(SearchType.Singleline, "mk65bj");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.Count, Is.EqualTo(5));
        }

        [Test]
        public void Search_Attributes_Location()
        {
            // No location set - default ordering alphabetical
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.UsAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Autocomplete, "1 main st");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            // Ensure that not ALL suggestions are in the state of CA. Results are ordered alphabetically by city.
            Assert.That(searchResult.Suggestions.Any(x => !x.Text.Contains(" CA ")));

            // Location set to Los Angeles - search results are weighted towards LA. The list of suggestions contains matching addresses
            // closer to the provided lat/long
            configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.UsAddress)
                .UseLocation("34.052235, -118.243683")
                .Build();
            client = ExperianDataValidation.GetAddressClient(configuration);

            searchResult = client.Search(SearchType.Autocomplete, "1 main st");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            // Ensure all results are in the state of California
            Assert.That(searchResult.Suggestions.All(x => x.Text.Contains(" CA ")));
        }

        [Test]
        public void Search_Address_Autocomplete()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.AuAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Autocomplete, "56 Queens R");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            // Pick the first one
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatResult = client.Format(globalAddressKey);
            Assert.That(formatResult.Confidence, Is.Not.Null);
            Assert.That(formatResult.GlobalAddressKey, Is.Not.Null);
        }

        [Test]
        public void Search_Address_Singleline()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.AuAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Singleline, "56 Queens R");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatResult = client.Format(globalAddressKey);
            Assert.That(formatResult.Confidence, Is.Not.Null);
            Assert.That(formatResult.GlobalAddressKey, Is.Not.Null);
        }

        [Test]
        public void Search_Address_Typedown()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .UseMaxSuggestions(20)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Typedown, "mk65bj");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);

            while (searchResult.Suggestions.Any(x => x.AdditionalAttributes.Any(y => y.Name == "can_step_in" && y.Value == "true")))
            {
                searchResult = client.SuggestionsStepIn(searchResult.Suggestions.First(x => x.AdditionalAttributes.Any(y => y.Name == "can_step_in" && y.Value == "true")).GlobalAddressKey);
            }

            var globalAddressKey = searchResult.Suggestions.First(x => x.AdditionalAttributes.Any(y => y.Name == "full_address" && y.Value == "true")).GlobalAddressKey;

            // Format with default layout
            var formatResult = client.Format(globalAddressKey);
            Assert.That(formatResult.Confidence, Is.Not.Null);
            Assert.That(formatResult.GlobalAddressKey, Is.Not.Null);
        }

        [Test]
        public void Suggestions_Refine()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.Search(SearchType.Typedown, "melbourne");
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            searchResult = client.SuggestionsStepIn(searchResult.Suggestions.First().GlobalAddressKey);

            // Ensure an informational picklist was returned that prompts for more user input
            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.First().AdditionalAttributes.Any(x => x.Name == "information" && x.Value == "true"));

            // Use the user input to refine the list of suggestions
            searchResult = client.SuggestionsRefine(searchResult.Suggestions.First().GlobalAddressKey, "ro");

            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.All(x => x.Text.StartsWith("ro", StringComparison.OrdinalIgnoreCase)));
        }

        [Test]
        public void Suggestions_Format()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            var searchResult = client.SuggestionsFormat("160, SE1 8EZ");

            Assert.That(searchResult.Suggestions, Is.Not.Empty);
            Assert.That(searchResult.Suggestions.All(x => x.Address != null));
            Assert.That(searchResult.Suggestions.All(x => x.AddressFormatted == null));
        }

        [Test]
        public void Validate_Address()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.AuAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Validate("Unit 1, 8 Main Ave, Lidcombe, 2141");

            Assert.That(result.Confidence, Is.EqualTo(Confidence.VerifiedMatch));
            Assert.That(result.Address, Is.Not.Null);
            Assert.That(result.Address?.AddressLine1, Is.EqualTo("U 1  8 Main Ave"));
            Assert.That(result.Address?.AddressLine2, Is.Empty);
            Assert.That(result.Address?.AddressLine3, Is.Empty);
            Assert.That(result.Address?.Locality, Is.EqualTo("LIDCOMBE"));
            Assert.That(result.Address?.Region, Is.EqualTo("NSW"));
            Assert.That(result.Address?.PostalCode, Is.EqualTo("2141"));
            Assert.That(result.Address?.Country, Is.EqualTo("AUSTRALIA"));
        }

        [Test]
        public void Datasets_Valid()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.GetDatasets(Country.UnitedKingdom);

            Assert.That(result.Result, Is.Not.Empty);
            Assert.That(result.Result?.All(p => p.Country == Country.UnitedKingdom), Is.True);
        }

        [Test]
        public void Format_WithMetadata()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .IncludeMetadata()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian");

            // Pick the first one
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey);

            Assert.That(formatted.Metadata, Is.Not.Null);
            Assert.That(formatted.Metadata?.Udprn, Is.Not.Null);
            Assert.That(formatted.Metadata?.PafAddressKey, Is.Not.Null);
        }

        [Test]
        public void Format_WithComponents()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .IncludeComponents()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian");

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey);

            Assert.That(formatted.Components, Is.Not.Null);
            Assert.That(formatted.Components?.Organization, Is.Not.Null);
            Assert.That(formatted.Components?.Organization?.CompanyName, Is.Not.Null);
            Assert.That(formatted.Components?.Street, Is.Not.Null);
            Assert.That(formatted.Components?.Street?.FullName, Is.Not.Null);
        }

        [Test]
        public void Search_Address_Autocomplete_AdditionalDatasets()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddress)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAdditionalMultipleresidence)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);
            var result = client.Search("flat 3, block a, oxford court, 23 stretford road, manchester, m15 6dd");

            Assert.That(result.Suggestions.Any(p => p.Dataset == "Multiple Residence"), Is.True);
        }

        [Test]
        public void Format_WithEnrichment_SelectAllElementsFromEnrichmentSet()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .IncludeEnrichment()
                .IncludeGlobalGeocodes()
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian");

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey);

            Assert.That(formatted.Enrichment, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.Latitude, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.Longitude, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.MatchLevel, Is.EqualTo(GeocodeMatchLevel.Place));
        }

        [Test]
        public void Format_WithEnrichment_SelectSpecificElementsFromEnrichmentSet()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .IncludeEnrichment()
                .IncludeGlobalGeocodeAttribute(Layout.Attributes.GlobalGeocodeAttribute.Latitude)
                .IncludeGlobalGeocodeAttribute(Layout.Attributes.GlobalGeocodeAttribute.Longitude)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian");

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey);

            Assert.That(formatted.Enrichment, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes, Is.Not.Null);
            Assert.That(formatted.Enrichment?.Geocodes?.Latitude, Is.Positive);
            Assert.That(formatted.Enrichment?.Geocodes?.Longitude, Is.Negative);

            // MatchLevel should be null as attribute was not requested
            Assert.That(formatted.Enrichment?.Geocodes?.MatchLevel, Is.Null);
        }

        [Test]
        public void Format_WithEnrichment_SelectSpecificElementsFromEnrichmentSet1()
        {
            var configuration = Configuration
                .NewBuilder(Setup.ValidTokenAddressWithEnrichment)
                .SetTransactionId(new Guid().ToString())
                .UseDataset(Dataset.GbAddress)
                .IncludeEnrichment()
                .IncludeGbrLocationCompleteAttribute(Layout.Attributes.GbrLocationCompleteAttribute.Latitude)
                .IncludeGbrLocationCompleteAttribute(Layout.Attributes.GbrLocationCompleteAttribute.Longitude)
                .Build();
            var client = ExperianDataValidation.GetAddressClient(configuration);

            // Search
            var searchResult = client.Search(SearchType.Autocomplete, "Experian");

            // Pick the first one 
            var globalAddressKey = searchResult.Suggestions.First().GlobalAddressKey;

            // Format with default layout
            var formatted = client.Format(globalAddressKey);

            Assert.That(formatted.Enrichment, Is.Not.Null);
            Assert.That(formatted.Enrichment?.GbrLocationComplete, Is.Not.Null);
            Assert.That(formatted.Enrichment?.GbrLocationComplete?.Latitude, Is.Not.Null);
            Assert.That(formatted.Enrichment?.GbrLocationComplete?.Longitude, Is.Not.Null);

            // MatchLevel should be null as attribute was not requested
            Assert.That(formatted.Enrichment?.GbrLocationComplete?.MatchLevel, Is.Null);
        }
    }
}