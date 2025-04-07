package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiAddressMetadataInfo {

    @JsonProperty("sources")
    private List<String> sources;

    @JsonProperty("number_of_households")
    private String numberOfHouseholds;

    @JsonProperty("just_built_date")
    private String justBuiltDate;

    @JsonProperty("identifier")
    private RestApiAddressMetadataInfoIdentifier identifier;

    public List<String> getSources() {
        return sources;
    }

    public void setSources(List<String> sources) {
        this.sources = sources;
    }

    public String getNumberOfHouseholds() {
        return numberOfHouseholds;
    }

    public void setNumberOfHouseholds(String numberOfHouseholds) {
        this.numberOfHouseholds = numberOfHouseholds;
    }

    public String getJustBuiltDate() {
        return justBuiltDate;
    }

    public void setJustBuiltDate(String justBuiltDate) {
        this.justBuiltDate = justBuiltDate;
    }

    public RestApiAddressMetadataInfoIdentifier getIdentifier() {
        return identifier;
    }

    public void setIdentifier(RestApiAddressMetadataInfoIdentifier identifier) {
        this.identifier = identifier;
    }
}
