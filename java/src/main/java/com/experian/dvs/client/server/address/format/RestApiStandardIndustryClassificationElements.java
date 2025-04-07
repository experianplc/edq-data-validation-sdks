package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiStandardIndustryClassificationElements {

    @JsonProperty("sic_2007_code")
    private String sic2007Code;

    @JsonProperty("sic_2007_description")
    private String sic2007Description;

    @JsonProperty("thomson_code")
    private String thomsonCode;

    @JsonProperty("thomson_description")
    private String thomsonDescription;

    // Getters and Setters
    public String getSic2007Code() {
        return sic2007Code;
    }

    public void setSic2007Code(String sic2007Code) {
        this.sic2007Code = sic2007Code;
    }

    public String getSic2007Description() {
        return sic2007Description;
    }

    public void setSic2007Description(String sic2007Description) {
        this.sic2007Description = sic2007Description;
    }

    public String getThomsonCode() {
        return thomsonCode;
    }

    public void setThomsonCode(String thomsonCode) {
        this.thomsonCode = thomsonCode;
    }

    public String getThomsonDescription() {
        return thomsonDescription;
    }

    public void setThomsonDescription(String thomsonDescription) {
        this.thomsonDescription = thomsonDescription;
    }
}
