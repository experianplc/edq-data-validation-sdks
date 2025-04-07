package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.server.address.layout.RestApiAddressLayoutLine;
import com.experian.dvs.client.server.address.layout.RestApiGetLayoutLayout;

import java.util.List;
import java.util.Objects;

public class GetLayoutLayout {

    private final String id;
    private final String name;
    private final String comment;
    private final List<AppliesTo> appliesTo;
    private final List<LayoutLine> lines;
    private final Status status;
    private final String licenseId;

    public GetLayoutLayout(final RestApiGetLayoutLayout layout) {
        this.id = Objects.toString(layout.getId(), "");
        this.name = Objects.toString(layout.getName(), "");
        this.comment = Objects.toString(layout.getComment(), "");
        this.appliesTo = layout.getAppliesTo() != null ? layout.getAppliesTo().stream().map(AppliesTo::new).toList() : List.of();
        this.lines = layout.getLines() != null ? layout.getLines().stream().map(p -> getLayoutLine(this.appliesTo, p)).toList() : List.of();
        this.status = layout.getStatus() != null ? Status.fromName(layout.getStatus()) : null;
        this.licenseId = Objects.toString(layout.getLicenseId(), "");
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getComment() {
        return comment;
    }

    public List<AppliesTo> getAppliesTo() {
        return appliesTo;
    }

    public List<LayoutLine> getLines() {
        return lines;
    }

    public Status getStatus() {
        return status;
    }

    public String getLicenseId() {
        return licenseId;
    }

    private LayoutLine getLayoutLine(final List<AppliesTo> appliesTo, RestApiAddressLayoutLine line) {
        if (line.getElements() == null || line.getElements().isEmpty()) {
            return new LayoutLineVariable(line);
        }
        return new LayoutLineFixed(appliesTo, line);
    }
}
