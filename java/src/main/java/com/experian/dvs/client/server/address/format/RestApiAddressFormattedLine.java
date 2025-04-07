package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressFormattedLine {

    @JsonProperty("label")
    private String label;
    @JsonProperty("line")
    private String line;
    @JsonProperty("has_overflown_to_other_line")
    private Boolean hasOverflownToOtherLine;
    @JsonProperty("is_truncated")
    private Boolean isTruncated;
    @JsonProperty("line_content")
    private String lineContent;

    public String getLabel() {
        return label;
    }

    public void setLabel(String label) {
        this.label = label;
    }

    public String getLine() {
        return line;
    }

    public void setLine(String line) {
        this.line = line;
    }

    public Boolean getHasOverflownToOtherLine() {
        return hasOverflownToOtherLine;
    }

    public void setHasOverflownToOtherLine(Boolean hasOverflownToOtherLine) {
        this.hasOverflownToOtherLine = hasOverflownToOtherLine;
    }

    public Boolean getTruncated() {
        return isTruncated;
    }

    public void setTruncated(Boolean truncated) {
        isTruncated = truncated;
    }

    public String getLineContent() {
        return lineContent;
    }

    public void setLineContent(String lineContent) {
        this.lineContent = lineContent;
    }
}
