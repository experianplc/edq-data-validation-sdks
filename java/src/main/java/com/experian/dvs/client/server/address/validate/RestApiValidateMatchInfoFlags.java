package com.experian.dvs.client.server.address.validate;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiValidateMatchInfoFlags {

    @JsonProperty("postcode_action")
    private String postcodeAction;

    @JsonProperty("address_action")
    private String addressAction;

    @JsonProperty("generic_info")
    private List<String> genericInfo;

    @JsonProperty("aus_info")
    private List<String> ausInfo;

    @JsonProperty("deu_info")
    private List<String> deuInfo;

    @JsonProperty("fra_info")
    private List<String> fraInfo;

    @JsonProperty("gbr_info")
    private List<String> gbrInfo;

    @JsonProperty("nld_info")
    private List<String> nldInfo;

    @JsonProperty("sgp_info")
    private List<String> sgpInfo;

    @JsonProperty("nzl_info")
    private List<String> nzlInfo;

    // Getters and Setters
    public String getPostcodeAction() {
        return postcodeAction;
    }

    public void setPostcodeAction(String postcodeAction) {
        this.postcodeAction = postcodeAction;
    }

    public String getAddressAction() {
        return addressAction;
    }

    public void setAddressAction(String addressAction) {
        this.addressAction = addressAction;
    }

    public List<String> getGenericInfo() {
        return genericInfo;
    }

    public void setGenericInfo(List<String> genericInfo) {
        this.genericInfo = genericInfo;
    }

    public List<String> getAusInfo() {
        return ausInfo;
    }

    public void setAusInfo(List<String> ausInfo) {
        this.ausInfo = ausInfo;
    }

    public List<String> getDeuInfo() {
        return deuInfo;
    }

    public void setDeuInfo(List<String> deuInfo) {
        this.deuInfo = deuInfo;
    }

    public List<String> getGbrInfo() {
        return gbrInfo;
    }

    public void setGbrInfo(List<String> gbrInfo) {
        this.gbrInfo = gbrInfo;
    }

    public List<String> getNldInfo() {
        return nldInfo;
    }

    public void setNldInfo(List<String> nldInfo) {
        this.nldInfo = nldInfo;
    }

    public List<String> getFraInfo() {
        return fraInfo;
    }

    public void setFraInfo(List<String> fraInfo) {
        this.fraInfo = fraInfo;
    }

    public List<String> getNzlInfo() {
        return nzlInfo;
    }

    public void setNzlInfo(List<String> nzlInfo) {
        this.nzlInfo = nzlInfo;
    }

    public List<String> getSgpInfo() {
        return sgpInfo;
    }

    public void setSgpInfo(List<String> sgpInfo) {
        this.sgpInfo = sgpInfo;
    }
}