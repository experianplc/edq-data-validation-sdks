package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class Building {
    private final String buildingName;
    private final String secondaryName;
    private final String buildingNumber;
    private final String secondaryNumber;
    private final String allotmentNumber;

    // Constructor
    public Building(String buildingName, String secondaryName, String buildingNumber, String secondaryNumber, String allotmentNumber) {
        this.buildingName = Objects.toString(buildingName, "");
        this.secondaryName = Objects.toString(secondaryName, "");
        this.buildingNumber = Objects.toString(buildingNumber, "");
        this.secondaryNumber = Objects.toString(secondaryNumber, "");
        this.allotmentNumber = Objects.toString(allotmentNumber, "");
    }

    // Getters
    public String getBuildingName() {
        return buildingName;
    }

    public String getSecondaryName() {
        return secondaryName;
    }

    public String getBuildingNumber() {
        return buildingNumber;
    }

    public String getSecondaryNumber() {
        return secondaryNumber;
    }

    public String getAllotmentNumber() {
        return allotmentNumber;
    }
}
