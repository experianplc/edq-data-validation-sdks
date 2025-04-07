package com.experian.dvs.client.server.address.search;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiAddressSearchResult {

    @JsonProperty("more_results_available")
    private Boolean moreResultsAvailable;

    @JsonProperty("confidence")
    private String confidence;

    @JsonProperty("suggestions_key")
    private String suggestionsKey;

    @JsonProperty("suggestions_prompt")
    private String suggestionsPrompt;

    @JsonProperty("suggestions")
    private List<RestApiSearchResultSuggestion> suggestions;

    public Boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public void setMoreResultsAvailable(Boolean moreResultsAvailable) {
        this.moreResultsAvailable = moreResultsAvailable;
    }

    public List<RestApiSearchResultSuggestion> getSuggestions() {
        return suggestions;
    }

    public void setSuggestions(List<RestApiSearchResultSuggestion> suggestions) {
        this.suggestions = suggestions;
    }

    public String getConfidence() {
        return confidence;
    }

    public void setConfidence(String confidence) {
        this.confidence = confidence;
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
}
