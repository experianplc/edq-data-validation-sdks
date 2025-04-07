package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiFormattedAddressLines {

    @JsonProperty("layout_name")
    private String layoutName;
    @JsonProperty("not_enough_lines")
    private Boolean notEnoughLines;
    @JsonProperty("has_truncated_lines")
    private Boolean hasTruncatedLines;

    public String getLayoutName() {
        return layoutName;
    }

    public void setLayoutName(String layoutName) {
        this.layoutName = layoutName;
    }

    public Boolean getNotEnoughLines() {
        return notEnoughLines;
    }

    public void setNotEnoughLines(Boolean notEnoughLines) {
        this.notEnoughLines = notEnoughLines;
    }

    public Boolean getHasTruncatedLines() {
        return hasTruncatedLines;
    }

    public void setHasTruncatedLines(Boolean hasTruncatedLines) {
        this.hasTruncatedLines = hasTruncatedLines;
    }
}
