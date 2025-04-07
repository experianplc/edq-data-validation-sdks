package com.experian.dvs.client.server.address.dataset;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiAddressDatasetResult {

    @JsonProperty("country_iso_3")
    private String countryIso3;
    @JsonProperty("country_name")
    private String countryName;
    @JsonProperty("datasets")
    private List<RestApiAddressDatasetElement> datasets;
    @JsonProperty("valid_combinations")
    private List<List<String>> validCombinations;

    public String getCountryIso3() {
        return countryIso3;
    }

    public void setCountryIso3(String countryIso3) {
        this.countryIso3 = countryIso3;
    }

    public String getCountryName() {
        return countryName;
    }

    public void setCountryName(String countryName) {
        this.countryName = countryName;
    }

    public List<RestApiAddressDatasetElement> getDatasets() {
        return datasets;
    }

    public void setDatasets(List<RestApiAddressDatasetElement> datasets) {
        this.datasets = datasets;
    }

    public List<List<String>> getValidCombinations() {
        return validCombinations;
    }

    public void setValidCombinations(List<List<String>> validCombinations) {
        this.validCombinations = validCombinations;
    }
}
