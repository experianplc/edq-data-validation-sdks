package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.address.Dataset;
import com.experian.dvs.client.address.layout.AppliesTo;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiAddressLayoutAppliesTo {

    @JsonProperty("country_iso")
    private String countryIso;
    @JsonProperty("datasets")
    private List<String> datasets;
    @JsonProperty("language")
    private String language;
    @JsonProperty("script")
    private String script;

    public RestApiAddressLayoutAppliesTo() {
    }

    public RestApiAddressLayoutAppliesTo(final AppliesTo appliesTo) {
        this.countryIso = appliesTo.getCountry() != null ? appliesTo.getCountry().getIso3Code() : null;
        this.datasets = appliesTo.getDatasets() != null ? appliesTo.getDatasets().stream().map(Dataset::getDatasetCode).toList() : null;
        this.language = appliesTo.getLanguage();
        this.script = appliesTo.getScript();
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

    public String getLanguage() {
        return language;
    }

    public void setLanguage(String language) {
        this.language = language;
    }

    public String getScript() {
        return script;
    }

    public void setScript(String script) {
        this.script = script;
    }
}
