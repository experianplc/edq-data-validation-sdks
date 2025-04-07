package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class SubBuildingItem {

    private final String fullName;
    private final String type;
    private final String value;

    // Constructor
    public SubBuildingItem(String fullName, String type, String value) {
        this.fullName = Objects.toString(fullName, "");
        this.type = Objects.toString(type, "");
        this.value = Objects.toString(value, "");
    }

    // Getters
    public String getFullName() {
        return fullName;
    }

    public String getType() {
        return type;
    }

    public String getValue() {
        return value;
    }
}
