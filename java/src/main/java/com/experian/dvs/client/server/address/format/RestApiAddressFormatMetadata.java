package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressFormatMetadata {

    @JsonProperty("address_info")
    private RestApiAddressMetadataInfo addressInfo;

    @JsonProperty("barcode")
    private RestApiAddressMetadataBarcode barcode;

    @JsonProperty("route_classification")
    private RestApiAddressMetadataRouteClassification routeClassification;

    @JsonProperty("address_classification")
    private RestApiAddressMetadataAddressClassification addressClassification;

    @JsonProperty("dpv")
    private RestApiAddressMetadataDpv dpv;


    public RestApiAddressMetadataInfo getAddressInfo() {
        return addressInfo;
    }

    public void setAddressInfo(RestApiAddressMetadataInfo addressInfo) {
        this.addressInfo = addressInfo;
    }

    public RestApiAddressMetadataBarcode getBarcode() {
        return barcode;
    }

    public void setBarcode(RestApiAddressMetadataBarcode barcode) {
        this.barcode = barcode;
    }

    public RestApiAddressMetadataRouteClassification getRouteClassification() {
        return routeClassification;
    }

    public void setRouteClassification(RestApiAddressMetadataRouteClassification routeClassification) {
        this.routeClassification = routeClassification;
    }

    public RestApiAddressMetadataAddressClassification getAddressClassification() {
        return addressClassification;
    }

    public void setAddressClassification(RestApiAddressMetadataAddressClassification addressClassification) {
        this.addressClassification = addressClassification;
    }

    public RestApiAddressMetadataDpv getDpv() {
        return dpv;
    }

    public void setDpv(RestApiAddressMetadataDpv dpv) {
        this.dpv = dpv;
    }
}
