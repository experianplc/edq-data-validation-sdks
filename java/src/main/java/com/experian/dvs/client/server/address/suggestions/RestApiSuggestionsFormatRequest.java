package com.experian.dvs.client.server.address.suggestions;

import com.experian.dvs.client.address.AddressConfiguration;
import com.experian.dvs.client.address.Dataset;
import com.experian.dvs.client.server.address.Address;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiSuggestionsFormatRequest {
    @JsonProperty("country_iso")
    private String countryIso;

    @JsonProperty("datasets")
    private List<String> datasets;

    @JsonProperty("max_suggestions")
    private Integer maxSuggestions;

    @JsonProperty("components")
    private Address address;

    @JsonProperty("layouts")
    private List<String> layouts;

    public static com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatRequest using(final AddressConfiguration configuration) {

        final com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatRequest formatRequest = new com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatRequest();
        //Country
        if (configuration.getCountry() != null) {
            formatRequest.setCountryIso(configuration.getCountry().getIso3Code());
        }
        //Datasets
        if (configuration.getDatasets() != null && !configuration.getDatasets().isEmpty()) {
            formatRequest.setDatasets(configuration.getDatasets().stream().map(Dataset::getDatasetCode).toList());
        }
        //Max suggestions
        if (configuration.getMaxSuggestions() != AddressConfiguration.DEFAULT_MAX_SUGGESTIONS) {
            formatRequest.setMaxSuggestions(configuration.getMaxSuggestions());
        }
        //Layout name
        if (!configuration.getFormatLayoutName().isEmpty()) {
            formatRequest.setLayouts(List.of(configuration.getFormatLayoutName()));
        }
        return formatRequest;
    }

    public String getCountryIso() {
        return countryIso;
    }

    public void setCountryIso(String countryIso) {
        this.countryIso = countryIso;
    }

    public List<String> getDatasets() {
        return datasets;
    }

    public void setDatasets(List<String> datasets) {
        this.datasets = datasets;
    }

    public Integer getMaxSuggestions() {
        return maxSuggestions;
    }

    public void setMaxSuggestions(Integer maxSuggestions) {
        this.maxSuggestions = maxSuggestions;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    public List<String> getLayouts() {
        return layouts;
    }

    public void setLayouts(List<String> layouts) {
        this.layouts = layouts;
    }
}