package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.address.Dataset;
import com.experian.dvs.client.server.address.layout.RestApiAddressLayoutAppliesTo;

import java.util.List;
import java.util.Objects;

public class AppliesTo {

    private List<Dataset> datasets;
    private String language;
    private String script;


    public AppliesTo(Dataset dataset) {
        this(List.of(dataset), null, null);

    }

    public AppliesTo(List<Dataset> datasets) {
        this(datasets, null, null);
        //Ensure that the datasets have been applied and that they are all for the same country


    }

    public AppliesTo(RestApiAddressLayoutAppliesTo appliesTo) {

        this.datasets = appliesTo.getDatasets() != null ? appliesTo.getDatasets().stream().map(Dataset::fromCode).toList() : List.of();
        this.language = Objects.toString(appliesTo.getLanguage(), "");
        this.script = Objects.toString(appliesTo.getScript(), "");
    }

    public AppliesTo(List<Dataset> datasets, String language, String script) {
        this.datasets = datasets;
        this.language = language;
        this.script = script;
    }

    public Country getCountry() {
        if (this.datasets == null || this.datasets.isEmpty()) {
            return null;
        }
        return this.datasets.get(0).getCountry();
    }


    public List<Dataset> getDatasets() {
        return datasets;
    }

    public void setDatasets(List<Dataset> datasets) {
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
