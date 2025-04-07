package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class LocalityItem {
    private final String name;
    private final String code;
    private final String description;

    // Constructor
    public LocalityItem(String name, String code, String description) {
        this.name = Objects.toString(name, "");
        this.code = Objects.toString(code, "");
        this.description = Objects.toString(description, "");
    }

    // Getters
    public String getName() {
        return name;
    }

    public String getCode() {
        return code;
    }

    public String getDescription() {
        return description;
    }
}
