package com.experian.dvs.client.address.format;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatMetadata;
import com.experian.dvs.client.server.address.format.RestApiAddressMetadataBarcode;
import com.experian.dvs.client.server.address.format.RestApiAddressMetadataInfo;
import com.experian.dvs.client.server.address.format.RestApiAddressMetadataInfoIdentifier;

import java.util.List;
import java.util.Objects;

public class AddressMetadata {

    private final List<String> sources;
    private final String numberOfHouseholds;
    private final String justBuiltDate;
    private final String umrrn;
    private final String udprn;
    private final String dpid;
    private final String gnafpid;
    private final String pafAddressKey;
    private final String hin;
    private final String deliveryPointBarcode;
    private final String barcodeCheckDigit;
    private final String barcodeSortPlanNumber;

    public AddressMetadata(final RestApiAddressFormatMetadata apiMetadata) {

        final RestApiAddressMetadataInfo apiInfo = apiMetadata.getAddressInfo();
        if (apiInfo != null) {
            this.sources = apiInfo.getSources() != null ? apiInfo.getSources() : List.of();
            this.numberOfHouseholds = Objects.toString(apiInfo.getNumberOfHouseholds(), "");
            this.justBuiltDate = Objects.toString(apiInfo.getJustBuiltDate(), "");
            final RestApiAddressMetadataInfoIdentifier identifier = apiInfo.getIdentifier();
            if (identifier != null) {
                this.umrrn = Objects.toString(identifier.getUmrrn(), "");
                this.udprn = Objects.toString(identifier.getUdprn(), "");
                this.dpid = Objects.toString(identifier.getDpid(), "");
                this.gnafpid = Objects.toString(identifier.getGnafpid(), "");
                this.pafAddressKey = Objects.toString(identifier.getPafAddressKey(), "");
                this.hin = Objects.toString(identifier.getHin(), "");
            } else {
                this.umrrn = "";
                this.udprn = "";
                this.dpid = "";
                this.gnafpid = "";
                this.pafAddressKey = "";
                this.hin = "";
            }
        } else {
            this.sources = List.of();
            this.numberOfHouseholds = "";
            this.justBuiltDate = "";
            this.umrrn = "";
            this.udprn = "";
            this.dpid = "";
            this.gnafpid = "";
            this.pafAddressKey = "";
            this.hin = "";
        }
        final RestApiAddressMetadataBarcode barcode = apiMetadata.getBarcode();
        if (barcode != null){
            this.deliveryPointBarcode = Objects.toString(barcode.getDeliveryPointBarcode(), "");
            this.barcodeCheckDigit = Objects.toString(barcode.getCheckDigit(), "");
            this.barcodeSortPlanNumber = Objects.toString(barcode.getSortPlanNumber(), "");
        } else {
            this.deliveryPointBarcode = "";
            this.barcodeCheckDigit = "";
            this.barcodeSortPlanNumber = "";

        }
    }


    public List<String> getSources() {
        return sources;
    }

    public String getNumberOfHouseholds() {
        return numberOfHouseholds;
    }

    public String getJustBuiltDate() {
        return justBuiltDate;
    }

    public String getUmrrn() {
        return umrrn;
    }

    public String getUdprn() {
        return udprn;
    }

    public String getDpid() {
        return dpid;
    }

    public String getGnafpid() {
        return gnafpid;
    }

    public String getPafAddressKey() {
        return pafAddressKey;
    }

    public String getHin() {
        return hin;
    }

    public String getDeliveryPointBarcode() {
        return deliveryPointBarcode;
    }

    public String getBarcodeCheckDigit() {
        return barcodeCheckDigit;
    }

    public String getBarcodeSortPlanNumber() {
        return barcodeSortPlanNumber;
    }
}
