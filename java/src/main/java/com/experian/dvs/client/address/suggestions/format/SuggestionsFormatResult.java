package com.experian.dvs.client.address.suggestions.format;

import com.experian.dvs.client.address.AddressConfidence;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatResponse;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatResult;

import java.util.List;

public class SuggestionsFormatResult {

    private final boolean moreResultsAvailable;
    private final AddressConfidence confidence;
    private final List<SuggestionsFormatSuggestion> suggestions;

    public SuggestionsFormatResult(RestApiSuggestionsFormatResponse response) {
        final RestApiSuggestionsFormatResult result = response.getResult();
        if (result != null) {
            this.moreResultsAvailable = Boolean.TRUE.equals(result.isMoreResultsAvailable());
            this.confidence = result.getConfidence() != null ? AddressConfidence.fromName(result.getConfidence()) : null;
            this.suggestions = result.getSuggestions() != null ? result.getSuggestions().stream().map(SuggestionsFormatSuggestion::new).toList() : List.of();
        } else {
            this.moreResultsAvailable = false;
            this.confidence = null;
            this.suggestions = List.of();
        }
    }

    public boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public AddressConfidence getConfidence() {
        return confidence;
    }

    public List<SuggestionsFormatSuggestion> getSuggestions() {
        return suggestions;
    }
}
