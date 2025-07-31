package com.experian.dvs.client.address;

import com.experian.dvs.client.ExperianDataValidation;
import com.experian.dvs.client.Setup;
import com.experian.dvs.client.address.datasets.GetDatasetsResult;
import com.experian.dvs.client.address.format.FormatResult;
import com.experian.dvs.client.address.format.GeocodeMatchLevel;
import com.experian.dvs.client.address.layout.attributes.GlobalGeocodeAttribute;
import com.experian.dvs.client.address.search.SearchResult;
import com.experian.dvs.client.address.suggestions.format.SuggestionsFormatResult;
import com.experian.dvs.client.address.validate.*;
import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;
import com.experian.dvs.client.exceptions.UnauthorizedException;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.fail;

public class AddressClientTests {
    @BeforeAll
    public static void setup() {
        Setup.loadEnv();
    }

    @Test
    public void testValidTokenAddress() {
        assertThat(Setup.VALID_TOKEN_ADDRESS).isNotEmpty();
        assertThat(Setup.VALID_TOKEN_ADDRESS_WITH_ENRICHMENT).isNotEmpty();
    }

    @Test
    void authentication_TokenNotSupplied() {
        final Exception ex1 = assertThrows(InvalidConfigurationException.class, () -> AddressConfiguration.newBuilder("").build());
        assertThat(ex1.getMessage()).isEqualTo("The supplied configuration must contain an authorisation token");

        final Exception ex2 = assertThrows(InvalidConfigurationException.class, () -> AddressConfiguration.newBuilder(null).build());
        assertThat(ex2.getMessage()).isEqualTo("The supplied configuration must contain an authorisation token");
    }

    @Test
    void authentication_InvalidTokenSupplied() {
        final String token = "ThisIsNotAValidToken";
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(token)
                .useDataset(Dataset.AU_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);

        final Exception ex = assertThrows(UnauthorizedException.class, () -> client.search(SearchType.AUTOCOMPLETE, "56 Queens R", Setup.getUniqueReferenceId()));
        assertThat(ex.getMessage()).isEqualTo("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
    }

    @Test
    void authentication_AlternateTokenSupplied() {
        // Use the alternate token in the x-app-key header instead of Auth-Token header
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setUseXAppAuthentication(true)
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);


        assertThat(configuration.getCommonHeaders(Setup.getUniqueReferenceId())).containsKey("x-app-key");
        assertThat(configuration.getCommonHeaders(Setup.getUniqueReferenceId()).get("x-app-key")).isEqualTo(Setup.VALID_TOKEN_ADDRESS);

        // Search
        var searchResult = client.search(SearchType.AUTOCOMPLETE, "experian, nottingham, NG80 1ZZ", Setup.getUniqueReferenceId());

        // Just assert that there is no error, which means the alternative token was used successfully to search
        assertThat(searchResult).isNotNull();
    }

    @Test
    void referenceId_OnBuilderStillWorks() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setTransactionId("specialRefId")
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        var searchResult = client.search(SearchType.AUTOCOMPLETE, "experian, nottingham, NG80 1ZZ");

        assertThat(searchResult).isNotNull();
        assertThat(searchResult.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_OnMethodTakesPrecedence() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setTransactionId(Setup.getUniqueReferenceId())
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        var searchResult = client.search(SearchType.AUTOCOMPLETE, "experian, nottingham, NG80 1ZZ", "specialRefId");

        assertThat(searchResult).isNotNull();
        assertThat(searchResult.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_OnMethod() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);

        // Checking setting ID on all address methods is supported
        var searchResult = client.search(SearchType.AUTOCOMPLETE, "experian, nottingham, NG80 1ZZ", Setup.STATIC_REFERENCE_ID);
        assertThat(searchResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        var validateResult = client.validate("experian, nottingham, NG80 1ZZ", Setup.STATIC_REFERENCE_ID);
        assertThat(validateResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        // TODO
        //var lookupResult = client.lookup("NG80 1ZZ", Setup.STATIC_REFERENCE_ID);
        //assertThat(validateResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        var formatResult = client.format(searchResult.getSuggestions().get(0).getGlobalAddressKey(), Setup.STATIC_REFERENCE_ID);
        assertThat(formatResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        var suggestionsFormatResult = client.suggestionsFormat("160, SE1 8EZ", Setup.STATIC_REFERENCE_ID);
        assertThat(suggestionsFormatResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        var typedownResult = client.search(SearchType.TYPEDOWN, "mk65bj");
        var suggestionsStepInResult = client.suggestionsStepIn(typedownResult.getSuggestions().get(0).getGlobalAddressKey(), Setup.STATIC_REFERENCE_ID);
        assertThat(suggestionsStepInResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        suggestionsStepInResult = client.suggestionsStepIn(suggestionsStepInResult.getSuggestions().get(0).getGlobalAddressKey());
        var suggestionsRefineResult = client.suggestionsRefine(suggestionsStepInResult.getSuggestions().get(0).getGlobalAddressKey(), "30", Setup.STATIC_REFERENCE_ID);
        assertThat(suggestionsRefineResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        var getDatasetsResult = client.getDatasets(Country.UNITED_KINGDOM, Setup.STATIC_REFERENCE_ID);
        assertThat(getDatasetsResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);
    }

    @Test
    void referenceId_NotValueSpecified_UsesRandomValue() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        var searchResult = client.search(SearchType.AUTOCOMPLETE, "experian, nottingham, NG80 1ZZ");

        assertThat(searchResult).isNotNull();
        assertThat(searchResult.getReferenceId()).isNotEmpty();
    }

    @Test
    void datasetSearchTypeCombinations_Invalid() {
        try {
            final AddressConfiguration configuration = AddressConfiguration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.IE_ADDITIONAL_EIRCODE)
                    .build();
            final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.SINGLELINE, "some input", Setup.getUniqueReferenceId());
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    void datasetSearchTypeCombinations_Valid() {
        final AddressConfiguration configurationAutocomplete = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .build();

        final AddressClient clientAutocomplete = ExperianDataValidation.getAddressClient(configurationAutocomplete);
        clientAutocomplete.search(SearchType.AUTOCOMPLETE, "80 Victoria St", Setup.getUniqueReferenceId());

        final AddressConfiguration configurationSingleline = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .useDataset(Dataset.GB_ADDITIONAL_NOTYETBUILT)
                .build();

        final AddressClient clientSingleline = ExperianDataValidation.getAddressClient(configurationSingleline);
        clientSingleline.search(SearchType.SINGLELINE, "Experian, Cardinal Place, 80 Victoria St, London", Setup.getUniqueReferenceId());

        final AddressConfiguration configurationTypedown = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .useDataset(Dataset.GB_ADDITIONAL_NOTYETBUILT)
                .build();
        final AddressClient clientTypedown = ExperianDataValidation.getAddressClient(configurationTypedown);
        clientTypedown.search(SearchType.TYPEDOWN, "London", Setup.getUniqueReferenceId());
    }

    @Test
    void datasetSearchTypeCombinations_Valid_ButOutOfOrder() {
        final AddressConfiguration configurationAutocomplete =  AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                .build();
        final AddressClient clientAutocomplete = ExperianDataValidation.getAddressClient(configurationAutocomplete);
        clientAutocomplete.search(SearchType.AUTOCOMPLETE, "80 Victoria St", Setup.getUniqueReferenceId());
    }

    @Test
    void datasetSearchTypeCombinations_Invalid_Singleline() {
        try {
            final AddressConfiguration configuration = AddressConfiguration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.GB_ADDRESS_WALES)
                    .useDataset(Dataset.GB_ADDITIONAL_NAMES)
                    .build()
                    ;
            final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.SINGLELINE, "Experian, Cardinal Place, 80 Victoria St, London", Setup.getUniqueReferenceId());
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    void datasetSearchTypeCombinations_Invalid_Autocomplete() {
        try {
            final AddressConfiguration configuration = AddressConfiguration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.GB_ADDITIONAL_BUSINESS)
                    .useDataset(Dataset.GB_ADDITIONAL_NAMES)
                    .build();

            final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.AUTOCOMPLETE, "1 main st,", Setup.getUniqueReferenceId());
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    void datasetSearchTypeCombinations_Invalid_Typedown() {
        try {
            final AddressConfiguration configuration = AddressConfiguration
                    .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                    .useDataset(Dataset.GB_ADDITIONAL_ADDRESSBASEISLANDS)
                    .useDataset(Dataset.GB_ADDITIONAL_NOTYETBUILT)
                    .build();

            final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
            client.search(SearchType.TYPEDOWN, "London", Setup.getUniqueReferenceId());
            fail();
        } catch (EDVSException e) {
            assertThat(e.getMessage()).isEqualTo("Unsupported dataset / search type combination.");
        }
    }

    @Test
    public void searchAttributesMaxSuggestions() {
        // Max suggestions set to 20 - should return at most 20 items in the list of suggestions
        AddressConfiguration configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        AddressClient client = ExperianDataValidation.getAddressClient(configuration);

        SearchResult result = client.search(SearchType.SINGLELINE, "mk65bj", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions()).isNotEmpty();
        assertThat(result.getSuggestions()).hasSize(20);

        // Max suggestions set to 5 - should return at most 5 items in the list of suggestions
        configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .useMaxSuggestions(5)
                .build();
        client = ExperianDataValidation.getAddressClient(configuration);

        result = client.search(SearchType.SINGLELINE, "mk65bj", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions()).isNotEmpty();
        assertThat(result.getSuggestions()).hasSize(5);
    }

    @Test
    public void searchAttributes_Location() {
        // No location set - default ordering alphabetical
        AddressConfiguration configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.US_ADDRESS)
                .build();
        AddressClient client = ExperianDataValidation.getAddressClient(configuration);

        SearchResult result = client.search(SearchType.AUTOCOMPLETE, "1 main st", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions()).isNotEmpty();
        // Ensure that not ALL suggestions are in the state of CA. Results are ordered alphabetically by city.
        assertThat(result.getSuggestions()).allMatch(suggestion -> !suggestion.getText().contains(" CA "));

        // Location set to Los Angeles - search results are weighted towards LA. The list of suggestions contains
        // matching addresses closer to the provided lat/long
        configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.US_ADDRESS)
                .useLocation("34.052235, -118.243683")
                .build();
        client = ExperianDataValidation.getAddressClient(configuration);

        result = client.search(SearchType.AUTOCOMPLETE, "1 main st", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions()).isNotEmpty();

        // Ensure all results are in the state of California
        assertThat(result.getSuggestions()).allMatch(suggestion -> suggestion.getText().contains(" CA "));
    }

    @Test
    void search_Autocomlete() {
        final AddressConfiguration configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final SearchResult result = client.search(SearchType.AUTOCOMPLETE, "56 Queens R", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions()).isNotEmpty();

        // Pick the first one
        final var globalAddressKey = result.getSuggestions().get(0).getGlobalAddressKey();
        // Format with default layout
        final var formatResult = client.format(globalAddressKey, Setup.getUniqueReferenceId());
        assertThat(formatResult.getConfidence()).isNotNull();
        assertThat(formatResult.getGlobalAddressKey()).isNotNull();
    }

    @Test
    void search_Singleline() {
        final AddressConfiguration configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final SearchResult result = client.search(SearchType.SINGLELINE, "56 Queens R", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions()).isNotEmpty();

        // Pick the first one
        final var globalAddressKey = result.getSuggestions().get(0).getGlobalAddressKey();
        // Format with default layout
        final var formatResult = client.format(globalAddressKey, Setup.getUniqueReferenceId());
        assertThat(formatResult.getConfidence()).isNotNull();
        assertThat(formatResult.getGlobalAddressKey()).isNotNull();
    }

    @Test
    void search_Typedown() {
        final AddressConfiguration configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .useMaxSuggestions(20)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);

        SearchResult result = client.search(SearchType.TYPEDOWN, "mk65bj", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions()).isNotEmpty();

        while (result.getSuggestions().stream()
                .anyMatch(suggestion -> suggestion.getAdditionalAttributes().stream()
                        .anyMatch(attribute -> "can_step_in".equals(attribute.getName()) && "true".equals(attribute.getValue())))) {
            result = client.suggestionsStepIn(result.getSuggestions().stream()
                    .filter(suggestion -> suggestion.getAdditionalAttributes().stream()
                            .anyMatch(attribute -> "can_step_in".equals(attribute.getName()) && "true".equals(attribute.getValue())))
                    .findFirst()
                    .orElseThrow()
                    .getGlobalAddressKey(), Setup.getUniqueReferenceId());
        }

        final String globalAddressKey = result.getSuggestions().stream()
                .filter(suggestion -> suggestion.getAdditionalAttributes().stream()
                        .anyMatch(attribute -> "full_address".equals(attribute.getName()) && "true".equals(attribute.getValue())))
                .findFirst()
                .orElseThrow()
                .getGlobalAddressKey();

        // Format with default layout
        final FormatResult formatResult = client.format(globalAddressKey, Setup.getUniqueReferenceId());
        assertThat(formatResult.getConfidence()).isNotNull();
        assertThat(formatResult.getGlobalAddressKey()).isNotEmpty();
    }

    @Test
    public void suggestions_Refine() {
        final AddressConfiguration configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        SearchResult result = client.search(SearchType.TYPEDOWN, "melbourne", Setup.getUniqueReferenceId());
        result = client.suggestionsStepIn(result.getSuggestions().stream()
                .findFirst()
                .orElseThrow()
                .getGlobalAddressKey(), Setup.getUniqueReferenceId());

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
                .getGlobalAddressKey(), "ro", Setup.getUniqueReferenceId());

        assertThat(result.getSuggestions()).isNotEmpty();
        assertThat(result.getSuggestions().stream()
                .allMatch(suggestion -> suggestion.getText().toLowerCase().startsWith("ro"))).isTrue();
    }

    @Test
    public void suggestions_Format() {
        final AddressConfiguration configuration = AddressConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final SuggestionsFormatResult searchResult = client.suggestionsFormat("160, SE1 8EZ", Setup.getUniqueReferenceId());

        assertThat(searchResult.getSuggestions()).isNotEmpty();
        assertThat(searchResult.getSuggestions()).allMatch(suggestion -> suggestion.getAddress() != null);
        assertThat(searchResult.getSuggestions()).allMatch(suggestion -> suggestion.getAddressFormatted() == null);
    }

    @Test
    void validate_Address() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final ValidateResult validateResult = client.validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.getUniqueReferenceId());
        assertThat(validateResult.getConfidence()).isEqualTo(AddressConfidence.VERIFIED_MATCH);
        assertThat(validateResult.getAddress().getAddressLine1()).isEqualTo("U 1  8 Main Ave");
        assertThat(validateResult.getAddress().getAddressLine2()).isEmpty();
        assertThat(validateResult.getAddress().getAddressLine3()).isEmpty();
        assertThat(validateResult.getAddress().getLocality()).isEqualTo("LIDCOMBE");
        assertThat(validateResult.getAddress().getRegion()).isEqualTo("NSW");
        assertThat(validateResult.getAddress().getPostalCode()).isEqualTo("2141");
        assertThat(validateResult.getAddress().getCountry()).isEqualTo("AUSTRALIA");
        assertThat(validateResult.getMatchType()).isEqualTo(ValidateMatchType.FULL_MATCH_WITH_POSTAL_CODE);
        assertThat(validateResult.getMatchConfidence()).isEqualTo(ValidateMatchConfidence.HIGH);
    }

    @Test
    void validate_Address_ReturnsMuliple() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final ValidateResult validateResult = client.validate("Main Ave, Lidcombe, 2141", Setup.getUniqueReferenceId());

        assertThat(validateResult.getConfidence()).isEqualTo(AddressConfidence.STREET_PARTIAL);
        assertThat(validateResult.getSuggestions().size()).isEqualTo(7);
        assertThat(validateResult.getAddress()).isNull();
        assertThat(validateResult.getAddressFormatted()).isNull();
        assertThat(validateResult.getSuggestionsKey()).isNotNull();
        assertThat(validateResult.getSuggestionsPrompt()).isNotNull();
    }

    @Test
    void validate_Address_WithComponents() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .includeComponents()
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final ValidateResult validateResult = client.validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.getUniqueReferenceId());

        assertThat(validateResult.getComponents()).isNotNull();
        assertThat(validateResult.getComponents().get().getPostalCode()).isNotNull();
        assertThat(validateResult.getComponents().get().getPostalCode().getFullName()).isEqualTo("2141");
        assertThat(validateResult.getComponents().get().getStreet()).isNotNull();
        assertThat(validateResult.getComponents().get().getStreet().getFullName()).isEqualTo("Main Ave");
        assertThat(validateResult.getComponents().get().getStreet().getName()).isEqualTo("Main");
        assertThat(validateResult.getComponents().get().getStreet().getType()).isEqualTo("Ave");
    }

    @Test
    void validate_Address_WithEnrichment() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS_WITH_ENRICHMENT)
                .useDataset(Dataset.AU_ADDRESS)
                .includeEnrichment()
                .includeAusRegionalGeocodes()
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final ValidateResult validateResult = client.validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.getUniqueReferenceId());

        assertThat(validateResult.getEnrichment()).isNotNull();
        assertThat(validateResult.getEnrichment().get().getAusRegionalGeocodes()).isNotNull();
        assertThat(validateResult.getEnrichment().get().getAusRegionalGeocodes().get().getLongitude()).isPositive();
        assertThat(validateResult.getEnrichment().get().getAusRegionalGeocodes().get().getLatitude()).isNegative();
    }

    @Test
    void validate_Address_WithMetadata() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .includeMetadata()
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final ValidateResult validateResult = client.validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.getUniqueReferenceId());

        assertThat(validateResult.getMetadata()).isNotNull();
        assertThat(validateResult.getMetadata().get().getDpid()).isNotNull();
        assertThat(validateResult.getMetadata().get().getHin()).isNotNull();
    }

    @Test
    void validate_Address_WithMatchInfo() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .includeExtraMatchInfo()
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final ValidateResult result = client.validate("Unit 1, 8 Main Ave, Lidcombe, 2141", Setup.getUniqueReferenceId());

        assertThat(result.getMatchInfo()).isNotNull();
        assertThat(result.getMatchInfo().get().getAddressAction()).isEqualTo(AddressAction.CORRECTED);
        assertThat(result.getMatchInfo().get().getPostalCodeAction()).isEqualTo(PostalCodeAction.OK);
        assertThat(result.getMatchInfo().get().getGenericInfo()).isNotNull();
        assertThat(result.getMatchInfo().get().getGenericInfo().contains("address_cleaned")).isTrue();
        assertThat(result.getMatchInfo().get().getAusInfo()).isNotNull();
        assertThat(result.getMatchInfo().get().getAusInfo().get().contains("bsp_state_nsw")).isTrue();

        // all other match infos should be empty
        assertThat(result.getMatchInfo().get().getGbrInfo().get()).isEmpty();
    }

    @Test
    void datasets_Valid() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .build();

        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final GetDatasetsResult result = client.getDatasets(Country.UNITED_KINGDOM, Setup.getUniqueReferenceId());
        assertThat(result.getResult()).isNotEmpty();
        assertThat(result.getResult().stream().allMatch(p -> p.getCountry() == Country.UNITED_KINGDOM)).isTrue();
    }

    @Test
    void format_WithMetadata() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .includeMetadata()
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final SearchResult resultAutoComplete = client.search(SearchType.AUTOCOMPLETE, "56 Queens R", Setup.getUniqueReferenceId());
        assertThat(resultAutoComplete.getSuggestions()).isNotEmpty();

        final var globalAddressKey = resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey();
        var formatted = client.format(globalAddressKey, Setup.getUniqueReferenceId());

        assertThat(formatted.getMetadata()).isPresent();
        assertThat(formatted.getMetadata().get().getUdprn()).isNotNull();
        assertThat(formatted.getMetadata().get().getPafAddressKey()).isNotNull();
    }

    @Test
    void search_Address_Autocomplete_AdditionalDatasets() {

        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
                .build();

        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        var result = client.search("flat 3, block a, oxford court, 23 stretford road, manchester, m15 6dd", Setup.getUniqueReferenceId());
        assertThat(result.getSuggestions().stream().anyMatch(p -> p.getDataset().equals("Multiple Residence")));
    }

    @Test
    void format_WithEnrichment_SelectAllOfElementsFromEnrichmentSet() {

        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS_WITH_ENRICHMENT)
                .useDataset(Dataset.AU_ADDRESS)
                .includeEnrichment()
                // Select all possible attributes for Global Geocodes enrichment dataset
                .includeGlobalGeocodes()
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final SearchResult resultAutoComplete = client.search(SearchType.AUTOCOMPLETE, "56 Queens R", Setup.getUniqueReferenceId());
        assertThat(resultAutoComplete.getSuggestions()).isNotEmpty();

        final var globalAddressKey = resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey();
        var formatted = client.format(globalAddressKey, Setup.getUniqueReferenceId());

        assertThat(formatted.getEnrichment()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLatitude()).isNotNull();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLongitude()).isNotNull();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getMatchLevel()).isEqualTo(GeocodeMatchLevel.BUILDING);
    }

    @Test
    void format_WithEnrichment_SelectSpecificElementsFromEnrichmentSet() {

        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS_WITH_ENRICHMENT)
                .useDataset(Dataset.AU_ADDRESS)
                .includeEnrichment()
                // Selecting specific attributes from the Global Geocodes enrichment dataset
                .includeGlobalGeocodeAttribute(GlobalGeocodeAttribute.LATITUDE)
                .includeGlobalGeocodeAttribute(GlobalGeocodeAttribute.LONGITUDE)
                .build();
        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final SearchResult resultAutoComplete = client.search(SearchType.AUTOCOMPLETE, "56 Queens R", Setup.getUniqueReferenceId());
        assertThat(resultAutoComplete.getSuggestions()).isNotEmpty();

        final var globalAddressKey = resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey();
        var formatted = client.format(globalAddressKey, Setup.getUniqueReferenceId());

        assertThat(formatted.getEnrichment()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes()).isPresent();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLatitude()).isNotNull();
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getLongitude()).isNotNull();

        // Match level should be null - was not requested
        assertThat(formatted.getEnrichment().get().getGeocodes().get().getMatchLevel()).isNull();
    }
}
