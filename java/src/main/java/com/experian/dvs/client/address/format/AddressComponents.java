package com.experian.dvs.client.address.format;

import com.experian.dvs.client.address.format.components.*;
import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;

import java.util.Objects;

public class AddressComponents {

    private final String language;
    private final Country country;
    private final PostalCode postalCode;
    private final DeliveryService deliveryService;
    private final DeliveryService secondaryDeliveryService;
    private final SubBuilding subBuilding;
    private final Building building;
    private final Organization organization;
    private final Street street;
    private final Street secondaryStreet;
    private final RouteService routeService;
    private final Locality locality;
    private final Locality physicalLocality;
    private final AdditionalElements additionalElements;

    // Constructor
    public AddressComponents(RestApiAddressFormatComponents api) {
        this.language = Objects.toString(api.getLanguage(), "");
        this.country = api.getCountryIso3() != null ? Country.fromIso3(api.getCountryIso3()) : null;
        this.postalCode = api.getPostalCode() != null ? new PostalCode(api.getPostalCode().getFullName(), api.getPostalCode().getPrimary(), api.getPostalCode().getSecondary()) : null;
        this.deliveryService = api.getDeliveryService() != null ? new DeliveryService(api.getDeliveryService().getFullName(), api.getDeliveryService().getServiceType(), api.getDeliveryService().getServiceNumber(), api.getDeliveryService().getPostCentreName()) : null;
        this.secondaryDeliveryService = api.getSecondaryDeliveryService() != null ? new DeliveryService(api.getSecondaryDeliveryService().getFullName(), api.getSecondaryDeliveryService().getServiceType(), api.getSecondaryDeliveryService().getServiceNumber(), api.getSecondaryDeliveryService().getPostCentreName()) : null;
        this.subBuilding = api.getSubBuilding() != null ? new SubBuilding(api.getSubBuilding()) : null;
        this.building = api.getBuilding() != null ? new Building(api.getBuilding().getBuildingName(), api.getBuilding().getSecondaryName(), api.getBuilding().getBuildingNumber(), api.getBuilding().getSecondaryNumber(), api.getBuilding().getAllotmentNumber()) : null;
        this.organization = api.getOrganization() != null ? new Organization(api.getOrganization()) : null;
        this.street = api.getStreet() != null ? new Street(api.getStreet().getFullName(), api.getStreet().getPrefix(), api.getStreet().getName(), api.getStreet().getType(), api.getStreet().getSuffix()) : null;
        this.secondaryStreet = api.getSecondaryStreet() != null ? new Street(api.getSecondaryStreet().getFullName(), api.getSecondaryStreet().getPrefix(), api.getSecondaryStreet().getName(), api.getSecondaryStreet().getType(), api.getSecondaryStreet().getSuffix()) : null;
        this.routeService = api.getRouteService() != null ? new RouteService(api.getRouteService().getFullName(), api.getRouteService().getServiceType(), api.getRouteService().getServiceNumber(), api.getRouteService().getDeliveryName(), api.getRouteService().getQualifier()) : null;
        this.locality = api.getLocality() != null ? new Locality(api.getLocality()) : null;
        this.physicalLocality = api.getPhysicalLocality() != null ? new Locality(api.getPhysicalLocality()) : null;
        this.additionalElements = api.getAdditionalElements() != null ? new AdditionalElements(api.getAdditionalElements()) : null;

    }

    // Getters

    public String getLanguage() {
        return language;
    }

    public Country getCountry() {
        return country;
    }

    public PostalCode getPostalCode() {
        return postalCode;
    }

    public DeliveryService getDeliveryService() {
        return deliveryService;
    }

    public DeliveryService getSecondaryDeliveryService() {
        return secondaryDeliveryService;
    }

    public SubBuilding getSubBuilding() {
        return subBuilding;
    }

    public Building getBuilding() {
        return building;
    }

    public Organization getOrganization() {
        return organization;
    }

    public Street getStreet() {
        return street;
    }

    public Street getSecondaryStreet() {
        return secondaryStreet;
    }

    public RouteService getRouteService() {
        return routeService;
    }

    public Locality getLocality() {
        return locality;
    }

    public Locality getPhysicalLocality() {
        return physicalLocality;
    }

    public AdditionalElements getAdditionalElements() {
        return additionalElements;
    }
}
