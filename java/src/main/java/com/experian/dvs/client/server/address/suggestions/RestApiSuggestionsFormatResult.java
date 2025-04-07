package com.experian.dvs.client.server.address.suggestions;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiSuggestionsFormatResult {
    @JsonProperty("more_results_available")
    private boolean moreResultsAvailable;

    @JsonProperty("confidence")
    private String confidence;

    @JsonProperty("suggestions")
    private List<RestApiSuggestionsFormatSuggestion> suggestions;


    public boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public void setMoreResultsAvailable(boolean moreResultsAvailable) {
        this.moreResultsAvailable = moreResultsAvailable;
    }

    public String getConfidence() {
        return confidence;
    }

    public void setConfidence(String globalAddressKey) {
        this.confidence = confidence;
    }

    public List<RestApiSuggestionsFormatSuggestion> getSuggestions() {
        return suggestions;
    }

    public void setSuggestions(List<RestApiSuggestionsFormatSuggestion> suggestions) {
        this.suggestions = suggestions;
    }

}
