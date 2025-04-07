package com.experian.dvs.client.server.address.layout;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiGetLayoutLayout {

    @JsonProperty("id")
    private String id;
    @JsonProperty("name")
    private String name;
    @JsonProperty("comment")
    private String comment;
    @JsonProperty("applies_to")
    private List<RestApiAddressLayoutAppliesTo> appliesTo;
    @JsonProperty("lines")
    private List<RestApiAddressLayoutLine> lines;
    @JsonProperty("status")
    private String status;
    @JsonProperty("license_id")
    private String licenseId;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public List<RestApiAddressLayoutAppliesTo> getAppliesTo() {
        return appliesTo;
    }

    public void setAppliesTo(List<RestApiAddressLayoutAppliesTo> appliesTo) {
        this.appliesTo = appliesTo;
    }

    public List<RestApiAddressLayoutLine> getLines() {
        return lines;
    }

    public void setLines(List<RestApiAddressLayoutLine> lines) {
        this.lines = lines;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getLicenseId() {
        return licenseId;
    }

    public void setLicenseId(String licenseId) {
        this.licenseId = licenseId;
    }
}
