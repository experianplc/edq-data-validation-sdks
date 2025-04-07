package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class RouteService {

    private final String fullName;
    private final String serviceType;
    private final String serviceNumber;
    private final String deliveryName;
    private final String qualifier;

    // Constructor
    public RouteService(String fullName, String serviceType, String serviceNumber, String deliveryName, String qualifier) {
        this.fullName = Objects.toString(fullName, "");
        this.serviceType = Objects.toString(serviceType, "");
        this.serviceNumber = Objects.toString(serviceNumber, "");
        this.deliveryName = Objects.toString(deliveryName, "");
        this.qualifier = Objects.toString(qualifier, "");
    }

    // Getters
    public String getFullName() {
        return fullName;
    }

    public String getServiceType() {
        return serviceType;
    }

    public String getServiceNumber() {
        return serviceNumber;
    }

    public String getDeliveryName() {
        return deliveryName;
    }

    public String getQualifier() {
        return qualifier;
    }

}
