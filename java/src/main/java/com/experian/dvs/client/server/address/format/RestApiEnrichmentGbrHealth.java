package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentGbrHealth {

    @JsonProperty("authority_code")
    private String authorityCode;

    @JsonProperty("authority_code_2011")
    private String authorityCode2011;

    @JsonProperty("authority_name")
    private String authorityName;

    @JsonProperty("pclh_code")
    private String pclhCode;

    @JsonProperty("pclh_code_2011")
    private String pclhCode2011;

    @JsonProperty("pclh_name")
    private String pclhName;

    @JsonProperty("ward_code")
    private String wardCode;

    @JsonProperty("ward_code_2011")
    private String wardCode2011;

    @JsonProperty("ward_name")
    private String wardName;

    @JsonProperty("ccg_code")
    private String ccgCode;

    @JsonProperty("ccg_name")
    private String ccgName;

    @JsonProperty("doh_code")
    private String dohCode;

    // Getters and Setters
    public String getAuthorityCode() {
        return authorityCode;
    }

    public void setAuthorityCode(String authorityCode) {
        this.authorityCode = authorityCode;
    }

    public String getAuthorityCode2011() {
        return authorityCode2011;
    }

    public void setAuthorityCode2011(String authorityCode2011) {
        this.authorityCode2011 = authorityCode2011;
    }

    public String getAuthorityName() {
        return authorityName;
    }

    public void setAuthorityName(String authorityName) {
        this.authorityName = authorityName;
    }

    public String getPclhCode() {
        return pclhCode;
    }

    public void setPclhCode(String pclhCode) {
        this.pclhCode = pclhCode;
    }

    public String getPclhCode2011() {
        return pclhCode2011;
    }

    public void setPclhCode2011(String pclhCode2011) {
        this.pclhCode2011 = pclhCode2011;
    }

    public String getPclhName() {
        return pclhName;
    }

    public void setPclhName(String pclhName) {
        this.pclhName = pclhName;
    }

    public String getWardCode() {
        return wardCode;
    }

    public void setWardCode(String wardCode) {
        this.wardCode = wardCode;
    }

    public String getWardCode2011() {
        return wardCode2011;
    }

    public void setWardCode2011(String wardCode2011) {
        this.wardCode2011 = wardCode2011;
    }

    public String getWardName() {
        return wardName;
    }

    public void setWardName(String wardName) {
        this.wardName = wardName;
    }

    public String getCcgCode() {
        return ccgCode;
    }

    public void setCcgCode(String ccgCode) {
        this.ccgCode = ccgCode;
    }

    public String getCcgName() {
        return ccgName;
    }

    public void setCcgName(String ccgName) {
        this.ccgName = ccgName;
    }

    public String getDohCode() {
        return dohCode;
    }

    public void setDohCode(String dohCode) {
        this.dohCode = dohCode;
    }
}
