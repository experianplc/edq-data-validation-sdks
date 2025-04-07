package com.experian.dvs.client.address.format.components;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;

import java.util.Objects;

public class Organization {
    private final String departmentName;
    private final String secondaryDepartmentName;
    private final String companyName;
    private final BusinessOrganization business;

    // Constructor
    public Organization(RestApiAddressFormatComponents.RestApiAddressComponentOrganization api) {
        this.departmentName = Objects.toString(api.getDepartmentName(), "");
        this.secondaryDepartmentName = Objects.toString(api.getSecondaryDepartmentName(), "");
        this.companyName = Objects.toString(api.getCompanyName(), "");
        this.business = api.getBusiness() != null ? new BusinessOrganization(api.getBusiness().getCompanyName()) : null;
    }

    // Getters
    public String getDepartmentName() {
        return departmentName;
    }

    public String getSecondaryDepartmentName() {
        return secondaryDepartmentName;
    }

    public String getCompanyName() {
        return companyName;
    }

    public BusinessOrganization getBusiness() {
        return business;
    }
}