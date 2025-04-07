package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.server.address.format.RestApiStandardIndustryClassificationElements;

import java.util.Objects;

public class StandardIndustryClassificationElements {

    private final String sic2007Code;
    private final String sic2007Description;
    private final String thomsonCode;
    private final String thomsonDescription;

    // Constructor
    public StandardIndustryClassificationElements(RestApiStandardIndustryClassificationElements api) {
        this.sic2007Code = Objects.toString(api.getSic2007Code(), "");
        this.sic2007Description = Objects.toString(api.getSic2007Description(), "");
        this.thomsonCode = Objects.toString(api.getThomsonCode(), "");
        this.thomsonDescription = Objects.toString(api.getThomsonDescription(), "");
    }

    // Getters
    public String getSic2007Code() {
        return sic2007Code;
    }

    public String getSic2007Description() {
        return sic2007Description;
    }

    public String getThomsonCode() {
        return thomsonCode;
    }

    public String getThomsonDescription() {
        return thomsonDescription;
    }
}
