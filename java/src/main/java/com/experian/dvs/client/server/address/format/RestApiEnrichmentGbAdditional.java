package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentGbAdditional {

    @JsonProperty("urn")
    private String urn;

    @JsonProperty("commercial_mosaic")
    private RestApiCommercialMosaicElements commercialMosaic;

    @JsonProperty("registration")
    private String registration;

    @JsonProperty("non_limited_company_key")
    private String nonLimitedCompanyKey;

    @JsonProperty("phone")
    private String phone;

    @JsonProperty("number_of_employees")
    private String numberOfEmployees;

    @JsonProperty("standard_industry_classification")
    private RestApiStandardIndustryClassificationElements standardIndustryClassification;

    @JsonProperty("location")
    private RestApiEnrichmentLocationElements location;

    // Getters and Setters
    public String getUrn() {
        return urn;
    }

    public void setUrn(String urn) {
        this.urn = urn;
    }

    public RestApiCommercialMosaicElements getCommercialMosaic() {
        return commercialMosaic;
    }

    public void setCommercialMosaic(RestApiCommercialMosaicElements commercialMosaic) {
        this.commercialMosaic = commercialMosaic;
    }

    public String getRegistration() {
        return registration;
    }

    public void setRegistration(String registration) {
        this.registration = registration;
    }

    public String getNonLimitedCompanyKey() {
        return nonLimitedCompanyKey;
    }

    public void setNonLimitedCompanyKey(String nonLimitedCompanyKey) {
        this.nonLimitedCompanyKey = nonLimitedCompanyKey;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getNumberOfEmployees() {
        return numberOfEmployees;
    }

    public void setNumberOfEmployees(String numberOfEmployees) {
        this.numberOfEmployees = numberOfEmployees;
    }

    public RestApiStandardIndustryClassificationElements getStandardIndustryClassification() {
        return standardIndustryClassification;
    }

    public void setStandardIndustryClassification(RestApiStandardIndustryClassificationElements standardIndustryClassification) {
        this.standardIndustryClassification = standardIndustryClassification;
    }

    public RestApiEnrichmentLocationElements getLocation() {
        return location;
    }

    public void setLocation(RestApiEnrichmentLocationElements location) {
        this.location = location;
    }
}
