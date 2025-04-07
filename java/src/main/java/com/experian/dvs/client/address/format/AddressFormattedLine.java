package com.experian.dvs.client.address.format;

import com.experian.dvs.client.server.address.format.RestApiAddressFormattedLine;

import java.util.Objects;

public class AddressFormattedLine {

    private final String label;
    private final String line;
    private final boolean hasOverflownToOtherLine;
    private final boolean isTruncated;
    private final LineContent lineContent;

    public AddressFormattedLine(final RestApiAddressFormattedLine result) {
        this.label = Objects.toString(result.getLabel(), "");
        this.line = Objects.toString(result.getLine(), "");
        this.hasOverflownToOtherLine = Boolean.TRUE.equals(result.getHasOverflownToOtherLine());
        this.isTruncated = Boolean.TRUE.equals(result.getTruncated());
        this.lineContent = result.getLineContent() != null ? LineContent.fromName(result.getLineContent()) : LineContent.NONE;
    }

    public String getLabel() {
        return label;
    }

    public String getLine() {
        return line;
    }

    public boolean isHasOverflownToOtherLine() {
        return hasOverflownToOtherLine;
    }

    public boolean isTruncated() {
        return isTruncated;
    }

    public LineContent getLineContent() {
        return lineContent;
    }
}
