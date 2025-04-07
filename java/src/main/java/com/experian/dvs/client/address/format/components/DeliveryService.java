package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class DeliveryService {

    private final String fullName;
    private final String serviceType;
    private final String serviceNumber;
    private final String postCentreName;

    // Constructor
    public DeliveryService(String fullName, String serviceType, String serviceNumber, String postCentreName) {
        this.fullName = Objects.toString(fullName, "");
        this.serviceType = Objects.toString(serviceType, "");
        this.serviceNumber = Objects.toString(serviceNumber, "");
        this.postCentreName = Objects.toString(postCentreName, "");
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

    public String getPostCentreName() {
        return postCentreName;
    }

}
