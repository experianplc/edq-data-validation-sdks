package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.ExperianDataValidation;
import com.experian.dvs.client.Setup;
import com.experian.dvs.client.address.*;
import com.experian.dvs.client.address.format.FormatResult;
import com.experian.dvs.client.address.layout.elements.Aus;
import com.experian.dvs.client.address.layout.elements.Gbr;
import com.experian.dvs.client.address.search.SearchResult;
import com.experian.dvs.client.address.suggestions.format.SuggestionsFormatResult;
import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.exceptions.NotFoundException;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.Optional;
import java.util.UUID;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.fail;

/**
 * These tests are dependent on pre-existing layouts being available.
 */
public class AddressLayoutTests {

    @BeforeAll
    static void testSetup() {
        Setup.loadEnv();
        //Some of these tests rely on pre-existing layouts because creating a layout during the tests is not feasible
        //This tests that they exist
        final GetLayoutResult layout1 = getLayout(Setup.EXISTING_TEST_LAYOUT);
        if (layout1.getLayout() == null) {
            //Doesn't exist yet. Create it.
            createLayout1();
            fail("The layout " + Setup.EXISTING_TEST_LAYOUT + " did not exist. This has now been created but you will need to wait for the creation to complete (can be 10 minutes or so)");
        }
        if (layout1.getLayout().getStatus() != LayoutStatus.COMPLETED) {
            fail("The layout " + Setup.EXISTING_TEST_LAYOUT + " is not complete. Please wait for it to complete before running these tests (can be 10 minutes or so)");
        }

        //Clean up any test layout from previous runs (they need to have completed creation before they can be deleted)
        deleteTestLayouts();
    }

    @AfterAll
    static void testCleanup() {
        //Delete any layout created during the tests with the common prefix
        deleteTestLayouts();
    }

    @Test
    public void testValidTokenAddressLayout() {
        assertThat(Setup.VALID_TOKEN_ADDRESS).isNotEmpty();
        assertThat(Setup.VALID_TOKEN_ADDRESS_WITH_ENRICHMENT).isNotEmpty();
    }

    @Test
    void layout_Get() {

        final LayoutConfiguration configuration = LayoutConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS).build();

        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);
        final GetLayoutResult result = client.getLayout(Setup.EXISTING_TEST_LAYOUT, Setup.getUniqueReferenceId());
        assertThat(result.getError()).isNotPresent();
    }

    @Test
    void layout_Create() {

        final LayoutConfiguration configuration = LayoutConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .build();
        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);

        final LayoutLineVariable line1 = new LayoutLineVariable("addr_line_1");
        final LayoutLineVariable line2 = new LayoutLineVariable("addr_line_2");
        final LayoutLineFixed line3 = new LayoutLineFixed("post_code", Aus.POSTAL_CODE);
        final LayoutLineFixed line4 = new LayoutLineFixed("country_name", Aus.COUNTRY_NAME);

        final String layoutName = getUniqueLayoutName();
        final CreateLayoutResult createLayoutResult = client.createLayout(layoutName,
                List.of(line1, line2),
                List.of(line3, line4),
                Setup.getUniqueReferenceId(),
                Dataset.AU_ADDRESS);

        assertThat(createLayoutResult.getError()).isNotPresent();
        //Check if the layout was created
        final GetLayoutResult result = client.getLayout(layoutName, Setup.getUniqueReferenceId());
        assertThat(result.getLayout().getStatus()).isEqualTo(LayoutStatus.CREATION_IN_PROGRESS);
    }

    @Test
    void layout_Create_WithOptions() {
        final LayoutConfiguration configuration = LayoutConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .build();
        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);
        //todo add logic
    }

    @Test
    void layout_Delete_DoesNotExist_Throws() {

        final LayoutConfiguration configuration = LayoutConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .build();
        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);

        final String layoutName = "ThisLayoutDoesntExist";
        assertThrows(NotFoundException.class, () -> client.deleteLayout(layoutName, Setup.getUniqueReferenceId()));

    }

    @Test
    void Format_WithCustomLayout_WithComponents() {

        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.GB_ADDRESS)
                .useLayoutName(Setup.EXISTING_TEST_LAYOUT)
                .includeComponents()
                .build();

        final AddressClient client = ExperianDataValidation.getAddressClient(configuration);
        final SearchResult resultAutoComplete = client.search(SearchType.AUTOCOMPLETE, "56 Queens R", Setup.getUniqueReferenceId());
        final FormatResult formatResult = client.format(resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey(), Setup.getUniqueReferenceId());
        assertThat(formatResult.getConfidence()).isEqualTo(AddressConfidence.VERIFIED_MATCH);
        //assertThat(formatResult.getGlobalAddressKey()).isEqualTo(resultAutoComplete.getSuggestions().get(0).getGlobalAddressKey());
        assertThat(formatResult.getAddressFormatted()).isNotNull();
        assertThat(formatResult.getAddressFormatted().getLayoutName()).isEqualTo(Setup.EXISTING_TEST_LAYOUT);
        assertThat(formatResult.getAddressFormatted().hasEnoughLines()).isTrue();
        assertThat(formatResult.getAddressFormatted().hasTruncatedLines()).isFalse();
        assertThat(formatResult.getAddressFormatted().getAddress()).hasSize(4);
        assertThat(formatResult.getAddressFormatted().getAddress().get("addr_line_1")).isNotEmpty();
        assertThat(formatResult.getAddressFormatted().getAddress().get("addr_line_2")).isNotEmpty();
        assertThat(formatResult.getAddressFormatted().getAddress().get("post_code")).isNotEmpty();
        assertThat(formatResult.getAddressFormatted().getAddress().get("country_name")).isNotEmpty();
    }

    @Test
    public void suggestionsFormatWithCustomLayout() {
        final AddressConfiguration configuration = AddressConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .useDataset(Dataset.AU_ADDRESS)
                .useLayoutName(Setup.EXISTING_TEST_LAYOUT)
                .build();
        AddressClient client = ExperianDataValidation.getAddressClient(configuration);

        SuggestionsFormatResult searchResult = client.suggestionsFormat("onslow st, perth", Setup.getUniqueReferenceId());

        assertThat(searchResult.getSuggestions()).isNotEmpty();

        // When using a custom layout the address objects should all be empty
        assertThat(searchResult.getSuggestions()).allMatch(suggestion -> suggestion.getAddress() == null);
        assertThat(searchResult.getSuggestions()).allMatch(suggestion -> suggestion.getAddressFormatted() != null);
    }

    @Test
    void referenceId_OnBuilderStillWorks() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        final LayoutConfiguration configuration = LayoutConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setTransactionId("specialRefId")
                .build();

        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);
        final GetLayoutResult result = client.getLayout(Setup.EXISTING_TEST_LAYOUT);
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_OnMethodTakesPrecedence() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        final LayoutConfiguration configuration = LayoutConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setTransactionId(Setup.getUniqueReferenceId())
                .build();

        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);
        final GetLayoutResult result = client.getLayout(Setup.EXISTING_TEST_LAYOUT, "specialRefId");
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_NotValueSpecified_UsesRandomValue() {
        final LayoutConfiguration configuration = LayoutConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .build();

        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);
        final GetLayoutResult result = client.getLayout(Setup.EXISTING_TEST_LAYOUT);
        assertThat(result.getReferenceId()).isNotEmpty();
    }

    @Test
    void referenceId_OnMethod() {
        final LayoutConfiguration configuration = LayoutConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .build();

        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);

        final LayoutLineVariable line1 = new LayoutLineVariable("addr_line_1");
        final LayoutLineVariable line2 = new LayoutLineVariable("addr_line_2");
        final LayoutLineFixed line3 = new LayoutLineFixed("post_code", List.of(Aus.POSTAL_CODE, Gbr.POSTCODE));
        final LayoutLineFixed line4 = new LayoutLineFixed("country_name", List.of(Aus.COUNTRY_NAME, Gbr.COUNTRY));

        final CreateLayoutResult createLayoutResult = client.createLayout(Setup.EXISTING_TEST_LAYOUT,
                List.of(line1, line2),
                List.of(line3, line4),
                Setup.STATIC_REFERENCE_ID,
                Dataset.GB_ADDRESS);
        assertThat(createLayoutResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        final GetLayoutResult getLayoutResult = client.getLayout(Setup.EXISTING_TEST_LAYOUT, Setup.STATIC_REFERENCE_ID);
        assertThat(getLayoutResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);

        final GetLayoutListResult getLayoutsResult = client.getLayouts(Setup.STATIC_REFERENCE_ID);
        assertThat(getLayoutsResult.getReferenceId()).isEqualTo(Setup.STATIC_REFERENCE_ID);
    }

    private static GetLayoutResult getLayout(final String layoutName) {
        final LayoutConfiguration configuration = LayoutConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS).build();
        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);
        return client.getLayout(layoutName);

    }

    private static void createLayout1() {

        final LayoutConfiguration configuration = LayoutConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS).build();
        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);

        final LayoutLineVariable line1 = new LayoutLineVariable("addr_line_1");
        final LayoutLineVariable line2 = new LayoutLineVariable("addr_line_2");
        final LayoutLineFixed line3 = new LayoutLineFixed("post_code", List.of(Aus.POSTAL_CODE, Gbr.POSTCODE));
        final LayoutLineFixed line4 = new LayoutLineFixed("country_name", List.of(Aus.COUNTRY_NAME, Gbr.COUNTRY));

        final String layoutName = Setup.EXISTING_TEST_LAYOUT;
        final CreateLayoutResult createLayoutResult = client.createLayout(layoutName,
                List.of(line1, line2),
                List.of(line3, line4),
                Dataset.AU_ADDRESS, Dataset.GB_ADDRESS);

        assertThat(createLayoutResult.getError()).isNotPresent();
    }

    private String getUniqueLayoutName() {
        return Setup.TEST_LAYOUT_PREFIX + UUID.randomUUID().toString();
    }

    private static void deleteTestLayouts() {

        //Get all layouts starting with the predefined prefix
        final LayoutConfiguration configuration = LayoutConfiguration.newBuilder(Setup.VALID_TOKEN_ADDRESS).build();
        final LayoutClient client = ExperianDataValidation.getAddressLayoutClient(configuration);
        final GetLayoutListResult layoutsResult = client.getLayouts(Optional.empty(), List.of(), Optional.of(Setup.TEST_LAYOUT_PREFIX));

        //Delete them
        for (var layout : layoutsResult.getLayouts()) {
            if (!layout.getName().equals(Setup.EXISTING_TEST_LAYOUT) && layout.getStatus() == LayoutStatus.COMPLETED) {
                try {
                    client.deleteLayout(layout.getName());
                    System.out.println("Deleted layout: " + layout.getName());
                } catch (EDVSException e) {
                    System.out.println("Failed to delete layout " + layout.getName());
                }
            }
        }
    }
}