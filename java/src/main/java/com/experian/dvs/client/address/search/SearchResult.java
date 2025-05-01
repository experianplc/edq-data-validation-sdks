package com.experian.dvs.client.address.search;

import com.experian.dvs.client.address.AddressConfidence;
import com.experian.dvs.client.server.address.search.RestApiAddressSearchResponse;
import com.experian.dvs.client.server.address.search.RestApiAddressSearchResult;

import java.util.List;
import java.util.Objects;

public class SearchResult {

    private final boolean moreResultsAvailable;
    private final AddressConfidence confidence;
    private final String suggestionsKey;
    private final String suggestionsPrompt;
    private final List<SearchSuggestion> suggestions;


    public SearchResult(final RestApiAddressSearchResponse response) {
        final RestApiAddressSearchResult apiResult = response.getResult();

        if (apiResult != null) {
            this.moreResultsAvailable = Boolean.TRUE.equals(apiResult.isMoreResultsAvailable());
            this.confidence = apiResult.getConfidence() != null ? AddressConfidence.fromName(apiResult.getConfidence()) : null;
            this.suggestionsKey = Objects.toString(apiResult.getSuggestionsKey(), "");
            this.suggestionsPrompt = Objects.toString(apiResult.getSuggestionsPrompt(), "");
            this.suggestions = apiResult.getSuggestions() != null ? apiResult.getSuggestions().stream().map(SearchSuggestion::new).toList() : List.of();
        } else {
            this.moreResultsAvailable = false;
            this.confidence = null;
            this.suggestionsKey = "";
            this.suggestionsPrompt = "";
            this.suggestions = List.of();
        }
    }

    public boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public AddressConfidence getConfidence() {
        return confidence;
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
}
