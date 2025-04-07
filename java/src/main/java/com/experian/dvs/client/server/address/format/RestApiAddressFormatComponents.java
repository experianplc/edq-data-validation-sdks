package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressFormatComponents {

    @JsonProperty("language")
    private String language;

    @JsonProperty("country_name")
    private String countryName;

    @JsonProperty("country_iso_3")
    private String countryIso3;

    @JsonProperty("country_iso_2")
    private String countryIso2;

    @JsonProperty("postal_code")
    private RestApiAddressComponentPostalCode postalCode;

    @JsonProperty("delivery_service")
    private RestApiAddressComponentDeliveryService deliveryService;

    @JsonProperty("secondary_delivery_service")
    private RestApiAddressComponentDeliveryService secondaryDeliveryService;

    @JsonProperty("sub_building")
    private RestApiAddressComponentSubBuilding subBuilding;

    @JsonProperty("building")
    private RestApiAddressComponentBuilding building;

    @JsonProperty("organization")
    private RestApiAddressComponentOrganization organization;

    @JsonProperty("street")
    private RestApiAddressComponentStreet street;

    @JsonProperty("secondary_street")
    private RestApiAddressComponentStreet secondaryStreet;

    @JsonProperty("route_service")
    private RestApiAddressComponentRouteService routeService;

    @JsonProperty("locality")
    private RestApiAddressComponentLocality locality;

    @JsonProperty("physical_locality")
    private RestApiAddressComponentLocality physicalLocality;

    @JsonProperty("additional_elements")
    private RestApiAddressComponentAdditionalElements additionalElements;

    // Getters and Setters

    public String getLanguage() {
        return language;
    }

    public void setLanguage(String language) {
        this.language = language;
    }

    public String getCountryName() {
        return countryName;
    }

    public void setCountryName(String countryName) {
        this.countryName = countryName;
    }

    public String getCountryIso3() {
        return countryIso3;
    }

    public void setCountryIso3(String countryIso3) {
        this.countryIso3 = countryIso3;
    }

    public String getCountryIso2() {
        return countryIso2;
    }

    public void setCountryIso2(String countryIso2) {
        this.countryIso2 = countryIso2;
    }

    public RestApiAddressComponentPostalCode getPostalCode() {
        return postalCode;
    }

    public void setPostalCode(RestApiAddressComponentPostalCode postalCode) {
        this.postalCode = postalCode;
    }

    public RestApiAddressComponentDeliveryService getDeliveryService() {
        return deliveryService;
    }

    public void setDeliveryService(RestApiAddressComponentDeliveryService deliveryService) {
        this.deliveryService = deliveryService;
    }

    public RestApiAddressComponentDeliveryService getSecondaryDeliveryService() {
        return secondaryDeliveryService;
    }

    public void setSecondaryDeliveryService(RestApiAddressComponentDeliveryService secondaryDeliveryService) {
        this.secondaryDeliveryService = secondaryDeliveryService;
    }

    public RestApiAddressComponentSubBuilding getSubBuilding() {
        return subBuilding;
    }

    public void setSubBuilding(RestApiAddressComponentSubBuilding subBuilding) {
        this.subBuilding = subBuilding;
    }

    public RestApiAddressComponentBuilding getBuilding() {
        return building;
    }

    public void setBuilding(RestApiAddressComponentBuilding building) {
        this.building = building;
    }

    public RestApiAddressComponentOrganization getOrganization() {
        return organization;
    }

    public void setOrganization(RestApiAddressComponentOrganization organization) {
        this.organization = organization;
    }

    public RestApiAddressComponentStreet getStreet() {
        return street;
    }

    public void setStreet(RestApiAddressComponentStreet street) {
        this.street = street;
    }

    public RestApiAddressComponentStreet getSecondaryStreet() {
        return secondaryStreet;
    }

    public void setSecondaryStreet(RestApiAddressComponentStreet secondaryStreet) {
        this.secondaryStreet = secondaryStreet;
    }

    public RestApiAddressComponentRouteService getRouteService() {
        return routeService;
    }

    public void setRouteService(RestApiAddressComponentRouteService routeService) {
        this.routeService = routeService;
    }

    public RestApiAddressComponentLocality getLocality() {
        return locality;
    }

    public void setLocality(RestApiAddressComponentLocality locality) {
        this.locality = locality;
    }

    public RestApiAddressComponentLocality getPhysicalLocality() {
        return physicalLocality;
    }

    public void setPhysicalLocality(RestApiAddressComponentLocality physicalLocality) {
        this.physicalLocality = physicalLocality;
    }

    public RestApiAddressComponentAdditionalElements getAdditionalElements() {
        return additionalElements;
    }

    public void setAdditionalElements(RestApiAddressComponentAdditionalElements additionalElements) {
        this.additionalElements = additionalElements;
    }

    // Static Classes

    public static class RestApiAddressComponentPostalCode {
        @JsonProperty("full_name")
        private String fullName;

        @JsonProperty("primary")
        private String primary;

        @JsonProperty("secondary")
        private String secondary;

        // Getters and Setters
        public String getFullName() {
            return fullName;
        }

        public void setFullName(String fullName) {
            this.fullName = fullName;
        }

        public String getPrimary() {
            return primary;
        }

        public void setPrimary(String primary) {
            this.primary = primary;
        }

        public String getSecondary() {
            return secondary;
        }

        public void setSecondary(String secondary) {
            this.secondary = secondary;
        }
    }

    public static class RestApiAddressComponentDeliveryService {
        @JsonProperty("full_name")
        private String fullName;

        @JsonProperty("service_type")
        private String serviceType;

        @JsonProperty("service_number")
        private String serviceNumber;

        @JsonProperty("post_centre_name")
        private String postCentreName;

        // Getters and Setters
        public String getFullName() {
            return fullName;
        }

        public void setFullName(String fullName) {
            this.fullName = fullName;
        }

        public String getServiceType() {
            return serviceType;
        }

        public void setServiceType(String serviceType) {
            this.serviceType = serviceType;
        }

        public String getServiceNumber() {
            return serviceNumber;
        }

        public void setServiceNumber(String serviceNumber) {
            this.serviceNumber = serviceNumber;
        }

        public String getPostCentreName() {
            return postCentreName;
        }

        public void setPostCentreName(String postCentreName) {
            this.postCentreName = postCentreName;
        }
    }

    public static class RestApiAddressComponentSubBuilding {
        @JsonProperty("name")
        private String name;

        @JsonProperty("entrance")
        private AddressComponentSubBuildingItem entrance;

        @JsonProperty("floor")
        private AddressComponentSubBuildingItem floor;

        @JsonProperty("door")
        private AddressComponentSubBuildingItem door;

        // Getters and Setters
        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public AddressComponentSubBuildingItem getEntrance() {
            return entrance;
        }

        public void setEntrance(AddressComponentSubBuildingItem entrance) {
            this.entrance = entrance;
        }

        public AddressComponentSubBuildingItem getFloor() {
            return floor;
        }

        public void setFloor(AddressComponentSubBuildingItem floor) {
            this.floor = floor;
        }

        public AddressComponentSubBuildingItem getDoor() {
            return door;
        }

        public void setDoor(AddressComponentSubBuildingItem door) {
            this.door = door;
        }
    }

    public static class AddressComponentSubBuildingItem {
        @JsonProperty("full_name")
        private String fullName;

        @JsonProperty("type")
        private String type;

        @JsonProperty("value")
        private String value;

        // Getters and Setters
        public String getFullName() {
            return fullName;
        }

        public void setFullName(String fullName) {
            this.fullName = fullName;
        }

        public String getType() {
            return type;
        }

        public void setType(String type) {
            this.type = type;
        }

        public String getValue() {
            return value;
        }

        public void setValue(String value) {
            this.value = value;
        }
    }

    public static class RestApiAddressComponentBuilding {
        @JsonProperty("building_name")
        private String buildingName;

        @JsonProperty("secondary_name")
        private String secondaryName;

        @JsonProperty("building_number")
        private String buildingNumber;

        @JsonProperty("secondary_number")
        private String secondaryNumber;

        @JsonProperty("allotment_number")
        private String allotmentNumber;

        // Getters and Setters
        public String getBuildingName() {
            return buildingName;
        }

        public void setBuildingName(String buildingName) {
            this.buildingName = buildingName;
        }

        public String getSecondaryName() {
            return secondaryName;
        }

        public void setSecondaryName(String secondaryName) {
            this.secondaryName = secondaryName;
        }

        public String getBuildingNumber() {
            return buildingNumber;
        }

        public void setBuildingNumber(String buildingNumber) {
            this.buildingNumber = buildingNumber;
        }

        public String getSecondaryNumber() {
            return secondaryNumber;
        }

        public void setSecondaryNumber(String secondaryNumber) {
            this.secondaryNumber = secondaryNumber;
        }

        public String getAllotmentNumber() {
            return allotmentNumber;
        }

        public void setAllotmentNumber(String allotmentNumber) {
            this.allotmentNumber = allotmentNumber;
        }
    }

    public static class RestApiAddressComponentOrganization {
        @JsonProperty("department_name")
        private String departmentName;

        @JsonProperty("secondary_department_name")
        private String secondaryDepartmentName;

        @JsonProperty("company_name")
        private String companyName;

        @JsonProperty("business")
        private AddressComponentBusinessOrganization business;

        // Getters and Setters
        public String getDepartmentName() {
            return departmentName;
        }

        public void setDepartmentName(String departmentName) {
            this.departmentName = departmentName;
        }

        public String getSecondaryDepartmentName() {
            return secondaryDepartmentName;
        }

        public void setSecondaryDepartmentName(String secondaryDepartmentName) {
            this.secondaryDepartmentName = secondaryDepartmentName;
        }

        public String getCompanyName() {
            return companyName;
        }

        public void setCompanyName(String companyName) {
            this.companyName = companyName;
        }

        public AddressComponentBusinessOrganization getBusiness() {
            return business;
        }

        public void setBusiness(AddressComponentBusinessOrganization business) {
            this.business = business;
        }
    }

    public static class AddressComponentBusinessOrganization {
        @JsonProperty("company_name")
        private String companyName;

        // Getters and Setters
        public String getCompanyName() {
            return companyName;
        }

        public void setCompanyName(String companyName) {
            this.companyName = companyName;
        }
    }

    public static class RestApiAddressComponentStreet {
        @JsonProperty("full_name")
        private String fullName;

        @JsonProperty("prefix")
        private String prefix;

        @JsonProperty("name")
        private String name;

        @JsonProperty("type")
        private String type;

        @JsonProperty("suffix")
        private String suffix;

        // Getters and Setters
        public String getFullName() {
            return fullName;
        }

        public void setFullName(String fullName) {
            this.fullName = fullName;
        }

        public String getPrefix() {
            return prefix;
        }

        public void setPrefix(String prefix) {
            this.prefix = prefix;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getType() {
            return type;
        }

        public void setType(String type) {
            this.type = type;
        }

        public String getSuffix() {
            return suffix;
        }

        public void setSuffix(String suffix) {
            this.suffix = suffix;
        }
    }

    public static class RestApiAddressComponentRouteService {
        @JsonProperty("full_name")
        private String fullName;

        @JsonProperty("service_type")
        private String serviceType;

        @JsonProperty("service_number")
        private String serviceNumber;

        @JsonProperty("delivery_name")
        private String deliveryName;

        @JsonProperty("qualifier")
        private String qualifier;

        // Getters and Setters
        public String getFullName() {
            return fullName;
        }

        public void setFullName(String fullName) {
            this.fullName = fullName;
        }

        public String getServiceType() {
            return serviceType;
        }

        public void setServiceType(String serviceType) {
            this.serviceType = serviceType;
        }

        public String getServiceNumber() {
            return serviceNumber;
        }

        public void setServiceNumber(String serviceNumber) {
            this.serviceNumber = serviceNumber;
        }

        public String getDeliveryName() {
            return deliveryName;
        }

        public void setDeliveryName(String deliveryName) {
            this.deliveryName = deliveryName;
        }

        public String getQualifier() {
            return qualifier;
        }

        public void setQualifier(String qualifier) {
            this.qualifier = qualifier;
        }
    }

    public static class RestApiAddressComponentLocality {
        @JsonProperty("region")
        private AddressComponentLocalityItem region;

        @JsonProperty("sub_region")
        private AddressComponentLocalityItem subRegion;

        @JsonProperty("town")
        private AddressComponentLocalityItem town;

        @JsonProperty("district")
        private AddressComponentLocalityItem district;

        @JsonProperty("sub_district")
        private AddressComponentLocalityItem subDistrict;

        // Getters and Setters
        public AddressComponentLocalityItem getRegion() {
            return region;
        }

        public void setRegion(AddressComponentLocalityItem region) {
            this.region = region;
        }

        public AddressComponentLocalityItem getSubRegion() {
            return subRegion;
        }

        public void setSubRegion(AddressComponentLocalityItem subRegion) {
            this.subRegion = subRegion;
        }

        public AddressComponentLocalityItem getTown() {
            return town;
        }

        public void setTown(AddressComponentLocalityItem town) {
            this.town = town;
        }

        public AddressComponentLocalityItem getDistrict() {
            return district;
        }

        public void setDistrict(AddressComponentLocalityItem district) {
            this.district = district;
        }

        public AddressComponentLocalityItem getSubDistrict() {
            return subDistrict;
        }

        public void setSubDistrict(AddressComponentLocalityItem subDistrict) {
            this.subDistrict = subDistrict;
        }
    }

    public static class AddressComponentLocalityItem {
        @JsonProperty("name")
        private String name;

        @JsonProperty("code")
        private String code;

        @JsonProperty("description")
        private String description;

        // Getters and Setters
        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getCode() {
            return code;
        }

        public void setCode(String code) {
            this.code = code;
        }

        public String getDescription() {
            return description;
        }

        public void setDescription(String description) {
            this.description = description;
        }
    }

    public static class RestApiAddressComponentAdditionalElements {
        @JsonProperty("locality")
        private RestApiAddressComponentAdditionalLocality locality;

        // Getters and Setters
        public RestApiAddressComponentAdditionalLocality getLocality() {
            return locality;
        }

        public void setLocality(RestApiAddressComponentAdditionalLocality locality) {
            this.locality = locality;
        }
    }

    public static class RestApiAddressComponentAdditionalLocality {
        @JsonProperty("sub_region")
        private RestApiAddressComponentAdditionalSubRegion subRegion;

        // Getters and Setters
        public RestApiAddressComponentAdditionalSubRegion getSubRegion() {
            return subRegion;
        }

        public void setSubRegion(RestApiAddressComponentAdditionalSubRegion subRegion) {
            this.subRegion = subRegion;
        }
    }

    public static class RestApiAddressComponentAdditionalSubRegion {
        @JsonProperty("administrative_county")
        private String administrativeCounty;

        @JsonProperty("former_postal_county")
        private String formerPostalCounty;

        @JsonProperty("traditional_county")
        private String traditionalCounty;

        // Getters and Setters
        public String getAdministrativeCounty() {
            return administrativeCounty;
        }

        public void setAdministrativeCounty(String administrativeCounty) {
            this.administrativeCounty = administrativeCounty;
        }

        public String getFormerPostalCounty() {
            return formerPostalCounty;
        }

        public void setFormerPostalCounty(String formerPostalCounty) {
            this.formerPostalCounty = formerPostalCounty;
        }

        public String getTraditionalCounty() {
            return traditionalCounty;
        }

        public void setTraditionalCounty(String traditionalCounty) {
            this.traditionalCounty = traditionalCounty;
        }
    }
}