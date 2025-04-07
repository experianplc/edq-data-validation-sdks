package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentLocationElements {

    @JsonProperty("code")
    private String code;

    @JsonProperty("description")
    private String description;

    @JsonProperty("small_or_home_office")
    private String smallOrHomeOffice;

    // Getters and Setters
    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getSmallOrHomeOffice() {
        return smallOrHomeOffice;
    }

    public void setSmallOrHomeOffice(String smallOrHomeOffice) {
        this.smallOrHomeOffice = smallOrHomeOffice;
    }
}
