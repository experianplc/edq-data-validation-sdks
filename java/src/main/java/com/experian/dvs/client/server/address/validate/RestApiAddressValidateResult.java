package com.experian.dvs.client.server.address.validate;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatted;
import com.experian.dvs.client.server.address.format.RestApiFormatAddress;
import com.experian.dvs.client.server.address.format.RestApiValidationDetail;
import com.experian.dvs.client.server.address.search.RestApiSearchResultSuggestion;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiAddressValidateResult {

    @JsonProperty("validation_detail")
    private RestApiValidationDetail validationDetail;

    @JsonProperty("global_address_key")
    private String globalAddressKey;

    @JsonProperty("more_results_available")
    private boolean moreResultsAvailable;

    @JsonProperty("confidence")
    private String confidence;

    @JsonProperty("address")
    private RestApiFormatAddress address;

    @JsonProperty("addresses_formatted")
    private List<RestApiAddressFormatted> addressesFormatted;

    @JsonProperty("components")
    private RestApiAddressFormatComponents components;

    @JsonProperty("suggestions_key")
    private String suggestionsKey;

    @JsonProperty("suggestions_prompt")
    private String suggestionsPrompt;

    @JsonProperty("suggestions")
    private List<RestApiSearchResultSuggestion> suggestions;

    @JsonProperty("match_type")
    private String matchType;

    @JsonProperty("match_confidence")
    private String matchConfidence;

    @JsonProperty("match_info")
    private RestApiValidateMatchInfoFlags matchInfo;

    // Getters and Setters
    public RestApiValidationDetail getValidationDetail() {
        return validationDetail;
    }

    public void setValidationDetail(RestApiValidationDetail validationDetail) {
        this.validationDetail = validationDetail;
    }

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public void setGlobalAddressKey(String globalAddressKey) {
        this.globalAddressKey = globalAddressKey;
    }

    public boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public void setMoreResultsAvailable(boolean moreResultsAvailable) {
        this.moreResultsAvailable = moreResultsAvailable;
    }

    public String getConfidence() {
        return confidence;
    }

    public void setConfidence(String confidence) {
        this.confidence = confidence;
    }

    public RestApiFormatAddress getAddress() {
        return address;
    }

    public void setAddress(RestApiFormatAddress address) {
        this.address = address;
    }

    public List<RestApiAddressFormatted> getAddressesFormatted() {
        return addressesFormatted;
    }

    public void setAddressesFormatted(List<RestApiAddressFormatted> addressesFormatted) {
        this.addressesFormatted = addressesFormatted;
    }

    public RestApiAddressFormatComponents getComponents() {
        return components;
    }

    public void setComponents(RestApiAddressFormatComponents components) {
        this.components = components;
    }

    public String getSuggestionsKey() {
        return suggestionsKey;
    }

    public void setSuggestionsKey(String suggestionsKey) {
        this.suggestionsKey = suggestionsKey;
    }

    public String getSuggestionsPrompt() {
        return suggestionsPrompt;
    }

    public void setSuggestionsPrompt(String suggestionsPrompt) {
        this.suggestionsPrompt = suggestionsPrompt;
    }

    public List<RestApiSearchResultSuggestion> getSuggestions() {
        return suggestions;
    }

    public void setSuggestions(List<RestApiSearchResultSuggestion> suggestions) {
        this.suggestions = suggestions;
    }

    public String getMatchType() {
        return matchType;
    }

    public void setMatchType(String matchType) {
        this.matchType = matchType;
    }

    public String getMatchConfidence() {
        return matchConfidence;
    }

    public void setMatchConfidence(String matchConfidence) {
        this.matchConfidence = matchConfidence;
    }

    public RestApiValidateMatchInfoFlags getMatchInfo() {
        return matchInfo;
    }

    public void setMatchInfo(RestApiValidateMatchInfoFlags matchInfo) {
        this.matchInfo = matchInfo;
    }
}