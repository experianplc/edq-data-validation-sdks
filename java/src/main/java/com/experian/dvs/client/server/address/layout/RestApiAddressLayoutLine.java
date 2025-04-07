package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.address.layout.LayoutLine;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiAddressLayoutLine {

    @JsonProperty("line_name")
    private String lineName;
    @JsonProperty("max_width")
    private Integer maxWidth;
    @JsonProperty("elements")
    private List<RestApiAddressLayoutLineElement> elements;


    public RestApiAddressLayoutLine() {
    }

    public RestApiAddressLayoutLine(final LayoutLine layoutLine) {
        this.lineName = layoutLine.getName();
        this.maxWidth = layoutLine.getMaxWidth();
        this.elements = layoutLine.getElements() != null && !layoutLine.getElements().isEmpty() ? layoutLine.getElements().stream().map(RestApiAddressLayoutLineElement::new).toList() : null;
    }



    public String getLineName() {
        return lineName;
    }

    public void setLineName(String lineName) {
        this.lineName = lineName;
    }

    public List<RestApiAddressLayoutLineElement> getElements() {
        return elements;
    }

    public void setElements(List<RestApiAddressLayoutLineElement> elements) {
        this.elements = elements;
    }

    public Integer getMaxWidth() {
        return maxWidth;
    }

    public void setMaxWidth(Integer maxWidth) {
        this.maxWidth = maxWidth;
    }
}
