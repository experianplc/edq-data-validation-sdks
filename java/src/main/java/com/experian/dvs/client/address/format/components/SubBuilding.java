package com.experian.dvs.client.address.format.components;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;

import java.util.Objects;

public class SubBuilding {
    private final String name;
    private final SubBuildingItem entrance;
    private final SubBuildingItem floor;
    private final SubBuildingItem door;

    // Constructor
    public SubBuilding(RestApiAddressFormatComponents.RestApiAddressComponentSubBuilding api) {
        this.name = Objects.toString(api.getName(), "");
        this.entrance = api.getEntrance() != null ? new SubBuildingItem(api.getEntrance().getFullName(), api.getEntrance().getType(), api.getEntrance().getValue()) : null;
        this.floor = api.getFloor() != null ? new SubBuildingItem(api.getFloor().getFullName(), api.getFloor().getType(), api.getFloor().getValue()) : null;
        this.door = api.getDoor() != null ? new SubBuildingItem(api.getDoor().getFullName(), api.getDoor().getType(), api.getDoor().getValue()) : null;
    }

    // Getters
    public String getName() {
        return name;
    }

    public SubBuildingItem getEntrance() {
        return entrance;
    }

    public SubBuildingItem getFloor() {
        return floor;
    }

    public SubBuildingItem getDoor() {
        return door;
    }
}
