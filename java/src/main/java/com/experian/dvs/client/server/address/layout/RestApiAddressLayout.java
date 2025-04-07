package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.address.layout.AppliesTo;
import com.experian.dvs.client.address.layout.LayoutLineFixed;
import com.experian.dvs.client.address.layout.LayoutLineVariable;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.ArrayList;
import java.util.List;

public class RestApiAddressLayout {

    @JsonProperty("name")
    private String name;

    @JsonProperty("comment")
    private String comment;

    @JsonProperty("applies_to")
    private List<RestApiAddressLayoutAppliesTo> appliesTo;

    @JsonProperty("options")
    private RestApiAddressLayoutOptions options;

    @JsonProperty("lines")
    private List<RestApiAddressLayoutLine> lines;

    public RestApiAddressLayout(final String name,
                                final List<AppliesTo> appliesTo,
                                final List<LayoutLineVariable> variableLayoutLines,
                                final List<LayoutLineFixed> fixedLayoutLines) {

        setName(name);
        setAppliesTo(appliesTo.stream().map(RestApiAddressLayoutAppliesTo::new).toList());

        final List<RestApiAddressLayoutLine> newLines = new ArrayList<>();
        newLines.addAll(variableLayoutLines.stream().map(RestApiAddressLayoutLine::new).toList());
        newLines.addAll(fixedLayoutLines.stream().map(RestApiAddressLayoutLine::new).toList());
        setLines(newLines);

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

    public RestApiAddressLayoutOptions getOptions() {
        return options;
    }

    public void setOptions(RestApiAddressLayoutOptions options) {
        this.options = options;
    }
}
