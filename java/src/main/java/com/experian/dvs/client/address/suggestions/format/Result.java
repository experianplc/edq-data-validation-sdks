package com.experian.dvs.client.address.suggestions.format;

import com.experian.dvs.client.address.Confidence;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatResponse;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatResult;

import java.util.List;

public class Result {

    private final boolean moreResultsAvailable;
    private final Confidence confidence;
    private final List<Suggestion> suggestions;

    public Result(RestApiSuggestionsFormatResponse response) {
        final RestApiSuggestionsFormatResult result = response.getResult();
        if (result != null) {
            this.moreResultsAvailable = Boolean.TRUE.equals(result.isMoreResultsAvailable());
            this.confidence = result.getConfidence() != null ? Confidence.fromName(result.getConfidence()) : null;
            this.suggestions = result.getSuggestions() != null ? result.getSuggestions().stream().map(Suggestion::new).toList() : List.of();
        } else {
            this.moreResultsAvailable = false;
            this.confidence = null;
            this.suggestions = List.of();
        }
    }

    public boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public Confidence getConfidence() {
        return confidence;
    }

    public List<Suggestion> getSuggestions() {
        return suggestions;
    }
}
