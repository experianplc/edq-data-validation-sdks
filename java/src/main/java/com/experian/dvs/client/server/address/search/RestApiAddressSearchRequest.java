package com.experian.dvs.client.server.address.search;

import com.experian.dvs.client.address.*;
import com.experian.dvs.client.server.address.Address;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.ArrayList;
import java.util.List;

public class RestApiAddressSearchRequest {

    @JsonProperty("country_iso")
    private String countryIso;

    @JsonProperty("datasets")
    private List<String> datasets;

    @JsonProperty("max_suggestions")
    private Integer maxSuggestions;

    @JsonProperty("components")
    private Address address;

    @JsonProperty("location")
    private String location;

    @JsonProperty("options")
    private List<RestApiAdditionalOption> options;

    public static RestApiAddressSearchRequest using(final AddressConfiguration configuration) {
        RestApiAddressSearchRequest searchRequest = new RestApiAddressSearchRequest();

        //Country
        if (configuration.getCountry() != null) {
            searchRequest.setCountryIso(configuration.getCountry().getIso3Code());
        }
        //Datasets
        if (!configuration.getDatasets().isEmpty()) {
            searchRequest.setDatasets(configuration.getDatasets().stream().map(Dataset::getDatasetCode).toList());
        }
        //Max suggestions
        if (configuration.getMaxSuggestions() != AddressConfiguration.DEFAULT_MAX_SUGGESTIONS) {
            searchRequest.setMaxSuggestions(configuration.getMaxSuggestions());
        }
        //Location
        if (!configuration.getLocation().isEmpty()) {
            searchRequest.setLocation(configuration.getLocation());
        }

        if (configuration.getFlattenResults()) {
            searchRequest.getOptions().add(new RestApiAdditionalOption("flatten", Boolean.TRUE.toString()));
        }
        if (configuration.getSearchIntensity() != null) {
            searchRequest.getOptions().add(new RestApiAdditionalOption("intensity", configuration.getSearchIntensity().getName()));
        }
        if (configuration.getPromptSet() != null) {
            searchRequest.getOptions().add(new RestApiAdditionalOption("prompt_set", configuration.getPromptSet().getName()));
        }

        //todo preferred language and preferred script


        return searchRequest;
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

    public Address getAddress() {
        return address;
    }

    public void setAddress(final Address address) {
        this.address = address;
    }

    public List<RestApiAdditionalOption> getOptions() {
        return options;
    }

    public void setOptions(List<RestApiAdditionalOption> options) {
        this.options = options;
    }

        public void addOption(final String name, final String value) {
            if (this.options == null) {
                this.options = new ArrayList<>();
            }
            this.options.add(new RestApiAdditionalOption(name, value));
        }

    public Integer getMaxSuggestions() {
        return maxSuggestions;
    }

    public void setMaxSuggestions(Integer maxSuggestions) {
        this.maxSuggestions = maxSuggestions;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }
}
