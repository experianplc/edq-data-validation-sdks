package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressMetadataBarcode {

    @JsonProperty("delivery_point_barcode")
    private String deliveryPointBarcode;

    @JsonProperty("check_digit")
    private String checkDigit;

    @JsonProperty("sort_plan_number")
    private String sortPlanNumber;


    public String getDeliveryPointBarcode() {
        return deliveryPointBarcode;
    }

    public void setDeliveryPointBarcode(String deliveryPointBarcode) {
        this.deliveryPointBarcode = deliveryPointBarcode;
    }

    public String getCheckDigit() {
        return checkDigit;
    }

    public void setCheckDigit(String checkDigit) {
        this.checkDigit = checkDigit;
    }

    public String getSortPlanNumber() {
        return sortPlanNumber;
    }

    public void setSortPlanNumber(String sortPlanNumber) {
        this.sortPlanNumber = sortPlanNumber;
    }
}
