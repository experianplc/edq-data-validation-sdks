package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class PostalCode {

    private final String fullName;
    private final String primary;
    private final String secondary;

    // Constructor
    public PostalCode(String fullName, String primary, String secondary) {
        this.fullName = Objects.toString(fullName, "");
        this.primary = Objects.toString(primary, "");
        this.secondary = Objects.toString(secondary, "");
    }

    // Getters
    public String getFullName() {
        return fullName;
    }

    public String getPrimary() {
        return primary;
    }

    public String getSecondary() {
        return secondary;
    }
}
