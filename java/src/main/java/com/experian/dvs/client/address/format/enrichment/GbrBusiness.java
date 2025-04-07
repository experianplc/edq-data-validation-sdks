package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.server.address.format.RestApiEnrichmentGbAdditional;

import java.util.Objects;

public class GbrBusiness {

    private final String urn;
    private final CommercialMosaicElements commercialMosaic;
    private final String registration;
    private final String nonLimitedCompanyKey;
    private final String phone;
    private final String numberOfEmployees;
    private final StandardIndustryClassificationElements standardIndustryClassification;
    private final LocationElements location;

    // Constructor
    public GbrBusiness(RestApiEnrichmentGbAdditional api) {
        this.urn = Objects.toString(api.getUrn(), "");
        this.commercialMosaic = api.getCommercialMosaic() != null ? new CommercialMosaicElements(api.getCommercialMosaic()) : null;
        this.registration = Objects.toString(api.getRegistration(), "");
        this.nonLimitedCompanyKey = Objects.toString(api.getNonLimitedCompanyKey(), "");
        this.phone = Objects.toString(api.getPhone(), "");
        this.numberOfEmployees = Objects.toString(api.getNumberOfEmployees(), "");
        this.standardIndustryClassification = api.getStandardIndustryClassification() != null ? new StandardIndustryClassificationElements(api.getStandardIndustryClassification()) : null;
        this.location = api.getLocation() != null ? new LocationElements(api.getLocation()) : null;
    }

    // Getters
    public String getUrn() {
        return urn;
    }

    public CommercialMosaicElements getCommercialMosaic() {
        return commercialMosaic;
    }

    public String getRegistration() {
        return registration;
    }

    public String getNonLimitedCompanyKey() {
        return nonLimitedCompanyKey;
    }

    public String getPhone() {
        return phone;
    }

    public String getNumberOfEmployees() {
        return numberOfEmployees;
    }

    public StandardIndustryClassificationElements getStandardIndustryClassification() {
        return standardIndustryClassification;
    }

    public LocationElements getLocation() {
        return location;
    }
}
