package com.experian.dvs.client.address.validate;

import com.experian.dvs.client.address.AddressConfidence;
import com.experian.dvs.client.address.format.*;
import com.experian.dvs.client.address.search.SearchSuggestion;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatEnrichment;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatMetadata;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateResponse;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateResult;

import java.util.List;
import java.util.Objects;
import java.util.Optional;

public class ValidateResult {

    private final ValidationDetail validationDetail;
    private final String globalAddressKey;
    private final boolean moreResultsAvailable;
    private final AddressConfidence confidence;
    private final FormatAddress address;
    private final AddressFormatted addressFormatted;
    private final AddressComponents components;
    private final String suggestionsKey;
    private final String suggestionsPrompt;
    private final List<SearchSuggestion> suggestions;
    private final AddressMetadata metadata;
    private final AddressEnrichment enrichment;
    private final ValidateMatchConfidence matchConfidence;
    private final ValidateMatchType matchType;
    private final ValidateMatchInfo matchInfo;

    public ValidateResult(RestApiAddressValidateResponse response) {
        final RestApiAddressValidateResult apiResult = response.getResult();
        final RestApiAddressFormatMetadata apiMetadata = response.getMetadata();
        final RestApiAddressFormatEnrichment apiEnrichment = response.getEnrichment();

        if (apiResult != null) {
            this.validationDetail = apiResult.getValidationDetail() != null ? new ValidationDetail(apiResult.getValidationDetail()) : null;
            this.globalAddressKey = Objects.toString(apiResult.getGlobalAddressKey(), "");
            this.moreResultsAvailable = Boolean.TRUE.equals(apiResult.isMoreResultsAvailable());
            this.confidence = apiResult.getConfidence() != null ? AddressConfidence.fromName(apiResult.getConfidence()) : null;
            this.address = apiResult.getAddress() != null ? new FormatAddress(apiResult.getAddress()) : null;
            //only one currently supported so just pick the first
            this.addressFormatted = apiResult.getAddressesFormatted() != null  && !apiResult.getAddressesFormatted().isEmpty() ? new AddressFormatted(apiResult.getAddressesFormatted().get(0)) : null;
            this.suggestionsKey = Objects.toString(apiResult.getSuggestionsKey(), "");
            this.suggestionsPrompt = Objects.toString(apiResult.getSuggestionsPrompt(), "");
            this.suggestions = apiResult.getSuggestions() != null ? apiResult.getSuggestions().stream().map(SearchSuggestion::new).toList() : List.of();
            this.components = apiResult.getComponents() != null ? new AddressComponents(apiResult.getComponents()) : null;
            this.matchType = apiResult.getMatchType() != null ? ValidateMatchType.fromName(apiResult.getMatchType()) : null;
            this.matchConfidence = apiResult.getMatchConfidence() != null ? ValidateMatchConfidence.fromName(apiResult.getMatchConfidence()) : null;
            this.matchInfo = apiResult.getMatchInfo() != null ? new ValidateMatchInfo(apiResult.getMatchInfo()) : null;
        } else {
            this.validationDetail = null;
            this.globalAddressKey = "";
            this.moreResultsAvailable = false;
            this.confidence = null;
            this.address = null;
            this.addressFormatted = null;
            this.suggestionsKey = "";
            this.suggestionsPrompt = "";
            this.suggestions = List.of();
            this.components = null;
            this.matchConfidence = null;
            this.matchType = null;
            this.matchInfo = null;
        }

        this.metadata = apiMetadata != null ? new AddressMetadata(apiMetadata) : null;
        this.enrichment = apiEnrichment != null ? new AddressEnrichment(apiEnrichment) : null;
    }

    public ValidationDetail getValidationDetail() {
        return validationDetail;
    }

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public AddressConfidence getConfidence() {
        return confidence;
    }

    public FormatAddress getAddress() {
        return address;
    }

    public AddressFormatted getAddressFormatted() {
        return addressFormatted;
    }

    public String getSuggestionsKey() {
        return suggestionsKey;
    }

    public String getSuggestionsPrompt() {
        return suggestionsPrompt;
    }

    public List<SearchSuggestion> getSuggestions() {
        return suggestions;
    }

    public Optional<AddressMetadata> getMetadata() {
        return Optional.ofNullable(metadata);
    }

    public Optional<AddressEnrichment> getEnrichment() {
        return Optional.ofNullable(enrichment);
    }

    public Optional<AddressComponents> getComponents() {
        return Optional.ofNullable(components);
    }

    public ValidateMatchType getMatchType() { return matchType; }

    public ValidateMatchConfidence getMatchConfidence() { return matchConfidence; }

    public Optional<ValidateMatchInfo> getMatchInfo() { return Optional.ofNullable(matchInfo); }
}
