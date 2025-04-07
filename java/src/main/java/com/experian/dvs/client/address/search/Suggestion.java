package com.experian.dvs.client.address.search;

import com.experian.dvs.client.server.address.search.RestApiSearchResultSuggestion;

import java.util.Collections;
import java.util.List;
import java.util.Objects;

public class Suggestion {

    private final String globalAddressKey;
    private final String text;
    private final List<List<Integer>> matched;
    private final String formatUrl;
    private final String dataset;
    private final List<AdditionalAttribute> additionalAttributes;

    public Suggestion(final RestApiSearchResultSuggestion suggestion) {
        this.globalAddressKey = Objects.toString(suggestion.getGlobalAddressKey(), "");
        this.text = Objects.toString(suggestion.getText(), "");
        this.matched = suggestion.getMatched() != null ? suggestion.getMatched() : Collections.emptyList();
        this.formatUrl = Objects.toString(suggestion.getFormatUrl(), "");
        this.dataset = Objects.toString(suggestion.getDataset());
        this.additionalAttributes = suggestion.getAdditionalAttributes() != null ? suggestion.getAdditionalAttributes().stream().map(AdditionalAttribute::new).toList() : Collections.emptyList();
    }

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public String getText() {
        return text;
    }

    public List<List<Integer>> getMatched() {
        return matched;
    }

    public String getFormatUrl() {
        return formatUrl;
    }

    public String getDataset() {
        return dataset;
    }

    public List<AdditionalAttribute> getAdditionalAttributes() {
        return additionalAttributes;
    }
}
