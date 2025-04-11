package com.experian.dvs.client.address;

import com.experian.dvs.client.ExperianDataValidation;
import com.experian.dvs.client.Setup;
import com.experian.dvs.client.address.datasets.GetDatasetsResult;
import com.experian.dvs.client.address.format.GeocodeMatchLevel;
import com.experian.dvs.client.address.format.Result;
import com.experian.dvs.client.address.layout.attributes.GlobalGeocodeAttribute;
import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;
import com.experian.dvs.client.exceptions.UnauthorizedException;
import com.experian.dvs.client.server.address.Address;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.fail;

public class ClientTests {
    @Test
    void authentication_TokenNotSupplied() {
        final Exception ex1 =  assertThrows(InvalidConfigurationException.class, () -> Configuration.newBuilder("").build());
        assertThat(ex1.getMessage().equals("The supplied configuration must contain an authorisation token"));

        final Exception ex2 =  assertThrows(InvalidConfigurationException.class, () -> Configuration.newBuilder(null).build());
        assertThat(ex2.getMessage().equals("The supplied configuration must contain an authorisation token"));
    }

    @Test
    void authentication_InvalidTokenSupplied() {
        final String token = "ThisIsNotAValidToken";
        final Configuration configuration = Configuration
                .newBuilder(token)
                .useDataset(Dataset.AU_ADDRESS)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);

        final Exception ex = assertThrows(UnauthorizedException.class, () -> client.search(SearchType.AUTOCOMPLETE, "56 Queens R"));
        assertThat(ex.getMessage().equals("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token."));
    }

    @Test
    void  authentication_AlternateTokenSupplied() {
        // Use the alternate token in the x-app-key header instead of Auth-Token header
        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setUseXAppAuthentication(true)
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);

        assertThat(configuration.getCommonHeaders().containsKey("x-app-key"));
        assertThat(configuration.getCommonHeaders().get("x-app-key").equals(Setup.VALID_TOKEN_ADDRESS));

        // Search
        var searchResult = client.search(SearchType.AUTOCOMPLETE, "experian, nottingham, NG80 1ZZ");

        // Just assert that there is no error, which means the alternative token was used successfully to search
        assertThat(searchResult).isNotNull();
    }

    @Test
    void datasetSearchTypeCombinations_Invalid() {
        try {
            final Configuration configuration = Configuration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.IE_ADDITIONAL_EIRCODE)
                    .build();
            final Client client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.SINGLELINE, "some input");
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    void datasetSearchTypeCombinations_Valid() {
        final Configuration configurationAutocomplete = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .build();

        final Client clientAutocomplete = ExperianDataValidation.getAddressClient(configurationAutocomplete);
        clientAutocomplete.search(SearchType.AUTOCOMPLETE, "80 Victoria St");

        final Configuration configurationSingleline = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .useDataset(Dataset.GB_ADDITIONAL_NOTYETBUILT)
                .build();

        final Client clientSingleline = ExperianDataValidation.getAddressClient(configurationSingleline);
        clientSingleline.search(SearchType.SINGLELINE, "Experian, Cardinal Place, 80 Victoria St, London");

        final Configuration configurationTypedown = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .useDataset(Dataset.GB_ADDITIONAL_NOTYETBUILT)
                .build();
        final Client clientTypedown = ExperianDataValidation.getAddressClient(configurationTypedown);
        clientTypedown.search(SearchType.TYPEDOWN, "London");
    }

    @Test
    void datasetSearchTypeCombinations_Valid_ButOutOfOrder() {
        final Configuration configurationAutocomplete =  Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                .build();
        final Client clientAutocomplete = ExperianDataValidation.getAddressClient(configurationAutocomplete);
        clientAutocomplete.search(SearchType.AUTOCOMPLETE, "80 Victoria St");
    }

    @Test
    void datasetSearchTypeCombinations_Invalid_Singleline() {
        try {
            final Configuration configuration = Configuration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.GB_ADDRESS_WALES)
                    .useDataset(Dataset.GB_ADDITIONAL_NAMES)
                    .build()
                    ;
            final Client client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.SINGLELINE, "Experian, Cardinal Place, 80 Victoria St, London");
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    void datasetSearchTypeCombinations_Invalid_Autocomplete() {
        try {
            final Configuration configuration = Configuration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                    .useDataset(Dataset.GB_ADDITIONAL_NAMES)
                    .build();

            final Client client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.AUTOCOMPLETE, "1 main st,");
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    void datasetSearchTypeCombinations_Invalid_Typedown() {
        try {
            final Configuration configuration = Configuration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.GB_ADDITIONAL_ADDRESSBASEISLANDS)
                    .useDataset(Dataset.GB_ADDITIONAL_NOTYETBUILT)
                    .build();

            final Client client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.TYPEDOWN, "London");
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    public void searchAttributesMaxSuggestions() {
        // Max suggestions set to 20 - should return at most 20 items in the list of suggestions
        Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        Client client = ExperianDataValidation.getAddressClient(configuration);

        com.experian.dvs.client.address.search.Result result = client.search(SearchType.SINGLELINE, "mk65bj");
        assertThat(result.getSuggestions()).isNotEmpty();
        assertThat(result.getSuggestions()).hasSize(20);

        // Max suggestions set to 5 - should return at most 5 items in the list of suggestions
        configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .useMaxSuggestions(5)
                .build();
        client = ExperianDataValidation.getAddressClient(configuration);

        result = client.search(SearchType.SINGLELINE, "mk65bj");
        assertThat(result.getSuggestions()).isNotEmpty();
        assertThat(result.getSuggestions()).hasSize(5);
    }

    @Test
    public void searchAttributes_Location() {
        // No location set - default ordering alphabetical
        Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.US_ADDRESS)
                .build();
        Client client = ExperianDataValidation.getAddressClient(configuration);

        com.experian.dvs.client.address.search.Result result = client.search(SearchType.AUTOCOMPLETE, "1 main st");
        assertThat(result.getSuggestions()).isNotEmpty();
        // Ensure that not ALL suggestions are in the state of CA. Results are ordered alphabetically by city.
        assertThat(result.getSuggestions()).allMatch(suggestion -> !suggestion.getText().contains(" CA "));

        // Location set to Los Angeles - search results are weighted towards LA. The list of suggestions contains
        // matching addresses closer to the provided lat/long
        configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.US_ADDRESS)
                .useLocation("34.052235, -118.243683")
                .build();
        client = ExperianDataValidation.getAddressClient(configuration);

        result = client.search(SearchType.AUTOCOMPLETE, "1 main st");
        assertThat(result.getSuggestions()).isNotEmpty();

        // Ensure all results are in the state of California
        assertThat(result.getSuggestions()).allMatch(suggestion -> suggestion.getText().contains(" CA "));
    }

    @Test
    void search_Autocomlete() {
        final Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final com.experian.dvs.client.address.search.Result result = client.search(SearchType.AUTOCOMPLETE, "56 Queens R");
        assertThat(result.getSuggestions()).isNotEmpty();

        // Pick the first one
        final var globalAddressKey = result.getSuggestions().get(0).getGlobalAddressKey();
        // Format with default layout
        final var formatResult = client.format(globalAddressKey);
        assertThat(formatResult.getConfidence()).isNotNull();
        assertThat(formatResult.getGlobalAddressKey()).isNotNull();
    }

    @Test
    void search_Singleline() {
        final Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final com.experian.dvs.client.address.search.Result result = client.search(SearchType.SINGLELINE, "56 Queens R");
        assertThat(result.getSuggestions()).isNotEmpty();

        // Pick the first one
        final var globalAddressKey = result.getSuggestions().get(0).getGlobalAddressKey();
        // Format with default layout
        final var formatResult = client.format(globalAddressKey);
        assertThat(formatResult.getConfidence()).isNotNull();
        assertThat(formatResult.getGlobalAddressKey()).isNotNull();
    }

    @Test
    void search_Typedown() {
        final Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);

        com.experian.dvs.client.address.search.Result result = client.search(SearchType.TYPEDOWN, "mk65bj");
        assertThat(result.getSuggestions()).isNotEmpty();

        while (result.getSuggestions().stream()
                .anyMatch(suggestion -> suggestion.getAdditionalAttributes().stream()
                        .anyMatch(attribute -> "can_step_in".equals(attribute.getName()) && "true".equals(attribute.getValue())))) {
            result = client.suggestionsStepIn(result.getSuggestions().stream()
                    .filter(suggestion -> suggestion.getAdditionalAttributes().stream()
                            .anyMatch(attribute -> "can_step_in".equals(attribute.getName()) && "true".equals(attribute.getValue())))
                    .findFirst()
                    .orElseThrow()
                    .getGlobalAddressKey());
        }

        final String globalAddressKey = result.getSuggestions().stream()
                .filter(suggestion -> suggestion.getAdditionalAttributes().stream()
                        .anyMatch(attribute -> "full_address".equals(attribute.getName()) && "true".equals(attribute.getValue())))
                .findFirst()
                .orElseThrow()
                .getGlobalAddressKey();

        // Format with default layout
        final Result formatResult = client.format(globalAddressKey);
        assertThat(formatResult.getConfidence()).isNotNull();
        assertThat(formatResult.getGlobalAddressKey()).isNotEmpty();
    }

    @Test
    public void suggestions_Refine() {
        final Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        com.experian.dvs.client.address.search.Result result = client.search(SearchType.TYPEDOWN, "melbourne");
        result = client.suggestionsStepIn(result.getSuggestions().stream()
                .findFirst()
                .orElseThrow()
                .getGlobalAddressKey());

        // Ensure an informational picklist was returned that prompts for more user input
        assertThat(result.getSuggestions()).isNotEmpty();
        assertThat(result.getSuggestions().stream()
                .findFirst()
                .orElseThrow()
                .getAdditionalAttributes())
                .anyMatch(attribute -> "information".equals(attribute.getName()) && "true".equals(attribute.getValue()));

        // Use the user input to refine the list of suggestions
        result = client.suggestionsRefine(result.getSuggestions().stream()
                .findFirst()
                .orElseThrow()
                .getGlobalAddressKey(), "ro");

        assertThat(result.getSuggestions()).isNotEmpty();
        assertThat(result.getSuggestions().stream()
                .allMatch(suggestion -> suggestion.getText().toLowerCase().startsWith("ro"))).isTrue();
    }

    @Test
    public void suggestions_Format() {
        final Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final com.experian.dvs.client.address.suggestions.format.Result searchResult = client.suggestionsFormat("160, SE1 8EZ");

        assertThat(searchResult.getSuggestions()).isNotEmpty();
        assertThat(searchResult.getSuggestions()).allMatch(suggestion -> suggestion.getAddress() != null);
        assertThat(searchResult.getSuggestions()).allMatch(suggestion -> suggestion.getAddressFormatted() == null);
    }

    @Test
    void validate_Address() {
        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final com.experian.dvs.client.address.validate.Result result = client.validate("Unit 1, 8 Main Ave, Lidcombe, 2141");
        assertThat(result.getConfidence()).isEqualTo(Confidence.VERIFIED_MATCH);
        assertThat(result.getAddress().getAddressLine1()).isEqualTo("U 1  8 Main Ave");
        assertThat(result.getAddress().getAddressLine2()).isEmpty();
        assertThat(result.getAddress().getAddressLine3()).isEmpty();
        assertThat(result.getAddress().getLocality()).isEqualTo("LIDCOMBE");
        assertThat(result.getAddress().getRegion()).isEqualTo("NSW");
        assertThat(result.getAddress().getPostalCode()).isEqualTo("2141");
        assertThat(result.getAddress().getCountry()).isEqualTo("AUSTRALIA");
    }

    @Test
    void datasets_Valid() {
        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .build();

        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final GetDatasetsResult result = client.getDatasets(Country.UNITED_KINGDOM);
        assertThat(result.getResult()).isNotEmpty();
        assertThat(result.getResult().stream().allMatch(p -> p.getCountry() == Country.UNITED_KINGDOM)).isTrue();
    }

    @Test
    void format_WithMetadata() {
        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .includeMetadata()
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final com.experian.dvs.client.address.search.Result resultAutoComplete = client.search(SearchType.AUTOCOMPLETE, "56 Queens R");
        assertThat(resultAutoComplete.getSuggestions()).isNotEmpty();

        final var globalAddressKey = resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey();
        var formatted = client.format(globalAddressKey);

        assertThat(formatted.getMetadata()).isPresent();
        assertThat(formatted.getMetadata().get().getUdprn()).isNotNull();
        assertThat(formatted.getMetadata().get().getPafAddressKey()).isNotNull();
    }

    @Test
    void search_Address_Autocomplete_AdditionalDatasets() {

        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .build();

        final Client client = ExperianDataValidation.getAddressClient(configuration);
        var result = client.search("flat 3, block a, oxford court, 23 stretford road, manchester, m15 6dd");
        assertThat(result.getSuggestions().stream().anyMatch(p -> p.getDataset().equals("Multiple Residence")));
    }

    @Test
    void format_WithEnrichment_SelectAllOfElementsFromEnrichmentSet() {

        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS_WITH_ENRICHMENT)
                .useDataset(Dataset.AU_ADDRESS)
                .includeEnrichment()
                // Select all possible attributes for Global Geocodes enrichment dataset
                .includeGlobalGeocodes()
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final com.experian.dvs.client.address.search.Result resultAutoComplete = client.search(SearchType.AUTOCOMPLETE, "56 Queens R");
        assertThat(resultAutoComplete.getSuggestions()).isNotEmpty();

        final var globalAddressKey = resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey();
        var formatted = client.format(globalAddressKey);

        assertThat(formatted.getEnrichment()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLatitude()).isNotNull();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLongitude()).isNotNull();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getMatchLevel()).isEqualTo(GeocodeMatchLevel.BUILDING);
    }

    @Test
    void format_WithEnrichment_SelectSpecificElementsFromEnrichmentSet() {

        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS_WITH_ENRICHMENT)
                .useDataset(Dataset.AU_ADDRESS)
                .includeEnrichment()
                // Selecting specific attributes from the Global Geocodes enrichment dataset
                .includeGlobalGeocodeAttribute(GlobalGeocodeAttribute.LATITUDE)
                .includeGlobalGeocodeAttribute(GlobalGeocodeAttribute.LONGITUDE)
                .build();
        final Client client = ExperianDataValidation.getAddressClient(configuration);
        final com.experian.dvs.client.address.search.Result resultAutoComplete = client.search(SearchType.AUTOCOMPLETE, "56 Queens R");
        assertThat(resultAutoComplete.getSuggestions()).isNotEmpty();

        final var globalAddressKey = resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey();
        var formatted = client.format(globalAddressKey);

        assertThat(formatted.getEnrichment()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLatitude()).isNotNull();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLongitude()).isNotNull();

        // Match level should be null - was not requested
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getMatchLevel()).isNull();
    }
}
