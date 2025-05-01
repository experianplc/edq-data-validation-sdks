package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.server.address.layout.RestApiGetLayoutsListItem;

import java.util.List;
import java.util.Objects;

public class GetLayoutListItem {

    private final String id;
    private final String name;
    private final List<AppliesTo> appliesTo;
    private final LayoutStatus status;

    public GetLayoutListItem(RestApiGetLayoutsListItem item) {
        this.id = Objects.requireNonNull(item.getId());
        this.name = Objects.requireNonNull(item.getName());
        this.appliesTo = item.getAppliesTo() != null ? item.getAppliesTo().stream().map(AppliesTo::new).toList() : List.of();
        this.status = item.getStatus() != null ? LayoutStatus.fromName(item.getStatus()) : null;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public List<AppliesTo> getAppliesTo() {
        return appliesTo;
    }

    public LayoutStatus getStatus() {
        return status;
    }
}

