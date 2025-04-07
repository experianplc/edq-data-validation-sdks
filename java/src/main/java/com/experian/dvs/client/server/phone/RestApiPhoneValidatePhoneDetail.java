package com.experian.dvs.client.server.phone;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiPhoneValidatePhoneDetail {

    @JsonProperty("original_operator_name")
    private String originalOperatorName;
    @JsonProperty("original_network_status")
    private String originalNetworkStatus;
    @JsonProperty("original_home_network_identity")
    private String originalHomeNetworkIdentity;
    @JsonProperty("original_country_prefix")
    private String originalCountryPrefix;
    @JsonProperty("original_country_name")
    private String originalCountryName;
    @JsonProperty("original_country_iso")
    private String originalCountryIso;
    @JsonProperty("operator_name")
    private String operatorName;
    @JsonProperty("network_status")
    private String networkStatus;
    @JsonProperty("home_network_identity")
    private String homeNetworkIdentity;
    @JsonProperty("country_prefix")
    private String countryPrefix;
    @JsonProperty("country_name")
    private String countryName;
    @JsonProperty("country_iso")
    private String countryIso;
    @JsonProperty("is_ported")
    private String isPorted;
    @JsonProperty("cache_value_days")
    private Integer cacheValueDays;
    @JsonProperty("date_cached")
    private String dateCached;
    @JsonProperty("email_to_sms_address")
    private String emailToSmsAddress;
    @JsonProperty("email_to_mms_address")
    private String emailToMmsAddress;


    public String getOriginalOperatorName() {
        return originalOperatorName;
    }

    public void setOriginalOperatorName(String originalOperatorName) {
        this.originalOperatorName = originalOperatorName;
    }

    public String getOriginalNetworkStatus() {
        return originalNetworkStatus;
    }

    public void setOriginalNetworkStatus(String originalNetworkStatus) {
        this.originalNetworkStatus = originalNetworkStatus;
    }

    public String getOriginalHomeNetworkIdentity() {
        return originalHomeNetworkIdentity;
    }

    public void setOriginalHomeNetworkIdentity(String originalHomeNetworkIdentity) {
        this.originalHomeNetworkIdentity = originalHomeNetworkIdentity;
    }

    public String getOriginalCountryPrefix() {
        return originalCountryPrefix;
    }

    public void setOriginalCountryPrefix(String originalCountryPrefix) {
        this.originalCountryPrefix = originalCountryPrefix;
    }

    public String getOriginalCountryName() {
        return originalCountryName;
    }

    public void setOriginalCountryName(String originalCountryName) {
        this.originalCountryName = originalCountryName;
    }

    public String getOriginalCountryIso() {
        return originalCountryIso;
    }

    public void setOriginalCountryIso(String originalCountryIso) {
        this.originalCountryIso = originalCountryIso;
    }

    public String getOperatorName() {
        return operatorName;
    }

    public void setOperatorName(String operatorName) {
        this.operatorName = operatorName;
    }

    public String getNetworkStatus() {
        return networkStatus;
    }

    public void setNetworkStatus(String networkStatus) {
        this.networkStatus = networkStatus;
    }

    public String getHomeNetworkIdentity() {
        return homeNetworkIdentity;
    }

    public void setHomeNetworkIdentity(String homeNetworkIdentity) {
        this.homeNetworkIdentity = homeNetworkIdentity;
    }

    public String getCountryPrefix() {
        return countryPrefix;
    }

    public void setCountryPrefix(String countryPrefix) {
        this.countryPrefix = countryPrefix;
    }

    public String getCountryName() {
        return countryName;
    }

    public void setCountryName(String countryName) {
        this.countryName = countryName;
    }

    public String getCountryIso() {
        return countryIso;
    }

    public void setCountryIso(String countryIso) {
        this.countryIso = countryIso;
    }

    public String isPorted() {
        return isPorted;
    }

    public void setPorted(String ported) {
        isPorted = ported;
    }

    public Integer getCacheValueDays() {
        return cacheValueDays;
    }

    public void setCacheValueDays(Integer cacheValueDays) {
        this.cacheValueDays = cacheValueDays;
    }

    public String getDateCached() {
        return dateCached;
    }

    public void setDateCached(String dateCached) {
        this.dateCached = dateCached;
    }

    public String getEmailToSmsAddress() {
        return emailToSmsAddress;
    }

    public void setEmailToSmsAddress(String emailToSmsAddress) {
        this.emailToSmsAddress = emailToSmsAddress;
    }

    public String getEmailToMmsAddress() {
        return emailToMmsAddress;
    }

    public void setEmailToMmsAddress(String emailToMmsAddress) {
        this.emailToMmsAddress = emailToMmsAddress;
    }
}
