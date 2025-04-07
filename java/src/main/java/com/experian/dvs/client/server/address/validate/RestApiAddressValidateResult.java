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
    private MatchInfoFlags matchInfo;

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

    public MatchInfoFlags getMatchInfo() {
        return matchInfo;
    }

    public void setMatchInfo(MatchInfoFlags matchInfo) {
        this.matchInfo = matchInfo;
    }


    public static class MatchInfoFlags {

        @JsonProperty("postcode_action")
        private String postcodeAction;

        @JsonProperty("address_action")
        private String addressAction;

        @JsonProperty("generic_info")
        private List<String> genericInfo;

        @JsonProperty("aus_info")
        private List<String> ausInfo;

        // Getters and Setters
        public String getPostcodeAction() {
            return postcodeAction;
        }

        public void setPostcodeAction(String postcodeAction) {
            this.postcodeAction = postcodeAction;
        }

        public String getAddressAction() {
            return addressAction;
        }

        public void setAddressAction(String addressAction) {
            this.addressAction = addressAction;
        }

        public List<String> getGenericInfo() {
            return genericInfo;
        }

        public void setGenericInfo(List<String> genericInfo) {
            this.genericInfo = genericInfo;
        }

        public List<String> getAusInfo() {
            return ausInfo;
        }

        public void setAusInfo(List<String> ausInfo) {
            this.ausInfo = ausInfo;
        }
    }
}