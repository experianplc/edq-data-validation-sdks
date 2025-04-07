package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiCommercialMosaicElements {

    @JsonProperty("group_type_code")
    private String groupTypeCode;

    @JsonProperty("group_type_description")
    private String groupTypeDescription;

    @JsonProperty("group_code")
    private String groupCode;

    @JsonProperty("group_description")
    private String groupDescription;

    // Getters and Setters
    public String getGroupTypeCode() {
        return groupTypeCode;
    }

    public void setGroupTypeCode(String groupTypeCode) {
        this.groupTypeCode = groupTypeCode;
    }

    public String getGroupTypeDescription() {
        return groupTypeDescription;
    }

    public void setGroupTypeDescription(String groupTypeDescription) {
        this.groupTypeDescription = groupTypeDescription;
    }

    public String getGroupCode() {
        return groupCode;
    }

    public void setGroupCode(String groupCode) {
        this.groupCode = groupCode;
    }

    public String getGroupDescription() {
        return groupDescription;
    }

    public void setGroupDescription(String groupDescription) {
        this.groupDescription = groupDescription;
    }
}

