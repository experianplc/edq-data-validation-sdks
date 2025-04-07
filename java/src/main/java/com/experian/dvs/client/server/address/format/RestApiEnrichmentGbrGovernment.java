package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentGbrGovernment {

    @JsonProperty("eer_code")
    private String eerCode;

    @JsonProperty("eer_code_pre_2011")
    private String eerCodePre2011;

    @JsonProperty("eer_name")
    private String eerName;

    @JsonProperty("gor_code")
    private String gorCode;

    @JsonProperty("gor_code_pre_2011")
    private String gorCodePre2011;

    @JsonProperty("gor_name")
    private String gorName;

    @JsonProperty("lea_code")
    private String leaCode;

    @JsonProperty("lea_name")
    private String leaName;

    @JsonProperty("la_code")
    private String laCode;

    @JsonProperty("la_code_pre_2011")
    private String laCodePre2011;

    @JsonProperty("la_name")
    private String laName;

    @JsonProperty("ward_code")
    private String wardCode;

    @JsonProperty("ward_code_pre_2011")
    private String wardCodePre2011;

    @JsonProperty("ward_name")
    private String wardName;

    @JsonProperty("cens_out_area")
    private String censOutArea;

    // Getters and Setters
    public String getEerCode() {
        return eerCode;
    }

    public void setEerCode(String eerCode) {
        this.eerCode = eerCode;
    }

    public String getEerCodePre2011() {
        return eerCodePre2011;
    }

    public void setEerCodePre2011(String eerCodePre2011) {
        this.eerCodePre2011 = eerCodePre2011;
    }

    public String getEerName() {
        return eerName;
    }

    public void setEerName(String eerName) {
        this.eerName = eerName;
    }

    public String getGorCode() {
        return gorCode;
    }

    public void setGorCode(String gorCode) {
        this.gorCode = gorCode;
    }

    public String getGorCodePre2011() {
        return gorCodePre2011;
    }

    public void setGorCodePre2011(String gorCodePre2011) {
        this.gorCodePre2011 = gorCodePre2011;
    }

    public String getGorName() {
        return gorName;
    }

    public void setGorName(String gorName) {
        this.gorName = gorName;
    }

    public String getLeaCode() {
        return leaCode;
    }

    public void setLeaCode(String leaCode) {
        this.leaCode = leaCode;
    }

    public String getLeaName() {
        return leaName;
    }

    public void setLeaName(String leaName) {
        this.leaName = leaName;
    }

    public String getLaCode() {
        return laCode;
    }

    public void setLaCode(String laCode) {
        this.laCode = laCode;
    }

    public String getLaCodePre2011() {
        return laCodePre2011;
    }

    public void setLaCodePre2011(String laCodePre2011) {
        this.laCodePre2011 = laCodePre2011;
    }

    public String getLaName() {
        return laName;
    }

    public void setLaName(String laName) {
        this.laName = laName;
    }

    public String getWardCode() {
        return wardCode;
    }

    public void setWardCode(String wardCode) {
        this.wardCode = wardCode;
    }

    public String getWardCodePre2011() {
        return wardCodePre2011;
    }

    public void setWardCodePre2011(String wardCodePre2011) {
        this.wardCodePre2011 = wardCodePre2011;
    }

    public String getWardName() {
        return wardName;
    }

    public void setWardName(String wardName) {
        this.wardName = wardName;
    }

    public String getCensOutArea() {
        return censOutArea;
    }

    public void setCensOutArea(String censOutArea) {
        this.censOutArea = censOutArea;
    }
}
