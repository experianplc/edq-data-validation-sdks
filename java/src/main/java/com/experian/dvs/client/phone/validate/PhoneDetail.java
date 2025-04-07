package com.experian.dvs.client.phone.validate;

import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.server.phone.RestApiPhoneValidatePhoneDetail;

import java.util.Objects;

public class PhoneDetail {

    private final String originalOperatorName;
    private final String originalNetworkStatus;
    private final String originalHomeNetworkIdentity;
    private final String originalCountryPrefix;
    private final Country originalCountry;
    private final String operatorName;
    private final String networkStatus;
    private final String homeNetworkIdentity;
    private final String countryPrefix;
    private final Country country;
    private final String isPorted;
    private final Integer cacheValueDays;
    private final String dateCached;
    private final String emailToSmsAddress;
    private final String emailToMmsAddress;


    public PhoneDetail(final RestApiPhoneValidatePhoneDetail detail) {
        this.originalOperatorName = Objects.toString(detail.getOriginalOperatorName(), "");
        this.originalNetworkStatus = Objects.toString(detail.getOriginalNetworkStatus(), "");
        this.originalHomeNetworkIdentity = Objects.toString(detail.getOriginalHomeNetworkIdentity(), "");
        this.originalCountryPrefix = Objects.toString(detail.getOriginalCountryPrefix(), "");
        this.originalCountry = detail.getOriginalCountryIso() != null ? Country.fromIso3(detail.getOriginalCountryIso()) : Country.UNKNOWN;
        this.operatorName = Objects.toString(detail.getOperatorName(), "");
        this.networkStatus = Objects.toString(detail.getNetworkStatus(), "");
        this.homeNetworkIdentity = Objects.toString(detail.getHomeNetworkIdentity(), "");
        this.countryPrefix = Objects.toString(detail.getCountryPrefix(), "");
        this.country = detail.getCountryIso() != null ? Country.fromIso3(detail.getCountryIso()) : Country.UNKNOWN;
        this.isPorted = Objects.toString(detail.isPorted(), "");
        this.cacheValueDays = detail.getCacheValueDays() != null ? detail.getCacheValueDays() : null;
        this.dateCached = Objects.toString(detail.getDateCached(), "");
        this.emailToSmsAddress = Objects.toString(detail.getEmailToSmsAddress(), "");
        this.emailToMmsAddress = Objects.toString(detail.getEmailToMmsAddress(), "");

    }

    public String getOriginalOperatorName() {
        return originalOperatorName;
    }

    public String getOriginalNetworkStatus() {
        return originalNetworkStatus;
    }

    public String getOriginalHomeNetworkIdentity() {
        return originalHomeNetworkIdentity;
    }

    public String getOriginalCountryPrefix() {
        return originalCountryPrefix;
    }

    public Country getOriginalCountry() {
        return originalCountry;
    }

    public String getOperatorName() {
        return operatorName;
    }

    public String getNetworkStatus() {
        return networkStatus;
    }

    public String getHomeNetworkIdentity() {
        return homeNetworkIdentity;
    }

    public String getCountryPrefix() {
        return countryPrefix;
    }

    public Country getCountry() {
        return country;
    }

    public String getIsPorted() {
        return isPorted;
    }

    public Integer getCacheValueDays() {
        return cacheValueDays;
    }

    public String getDateCached() {
        return dateCached;
    }

    public String getEmailToSmsAddress() {
        return emailToSmsAddress;
    }

    public String getEmailToMmsAddress() {
        return emailToMmsAddress;
    }
}
