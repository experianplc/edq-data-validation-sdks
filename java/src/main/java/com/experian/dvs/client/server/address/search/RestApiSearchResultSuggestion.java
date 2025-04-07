package com.experian.dvs.client.server.address.search;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiSearchResultSuggestion {

    @JsonProperty("global_address_key")
    private String globalAddressKey;

    @JsonProperty("text")
    private String text;

    @JsonProperty("matched")
    private List<List<Integer>> matched;

    @JsonProperty("format")
    private String formatUrl;

    @JsonProperty("dataset")
    private String dataset;

    @JsonProperty("additional_attributes")
    private List<RestApiSearchResultAdditionalAttribute> additionalAttributes;

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public void setGlobalAddressKey(String globalAddressKey) {
        this.globalAddressKey = globalAddressKey;
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public String getFormatUrl() {
        return formatUrl;
    }

    public void setFormatUrl(String formatUrl) {
        this.formatUrl = formatUrl;
    }


    public List<RestApiSearchResultAdditionalAttribute> getAdditionalAttributes() {
        return additionalAttributes;
    }

    public void setAdditionalAttributes(List<RestApiSearchResultAdditionalAttribute> additionalAttributes) {
        this.additionalAttributes = additionalAttributes;
    }

    public List<List<Integer>> getMatched() {
        return matched;
    }

    public void setMatched(List<List<Integer>> matched) {
        this.matched = matched;
    }

    public String getDataset() {
        return dataset;
    }

    public void setDataset(String dataset) {
        this.dataset = dataset;
    }
}
