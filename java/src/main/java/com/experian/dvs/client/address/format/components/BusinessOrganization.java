package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class BusinessOrganization {

    private final String companyName;

    // Constructor
    public BusinessOrganization(String companyName) {
        this.companyName = Objects.toString(companyName, "");
    }

    // Getters
    public String getCompanyName() {
        return companyName;
    }
}