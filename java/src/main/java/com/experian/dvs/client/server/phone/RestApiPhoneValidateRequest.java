package com.experian.dvs.client.server.phone;

import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.phone.Configuration;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiPhoneValidateRequest {

    @JsonProperty("number")
    private String number;
    @JsonProperty("output_format")
    private String outputFormat;
    @JsonProperty("cache_value_days")
    private Integer cacheValueDays;
    @JsonProperty("country_iso")
    private String countryIso;
    @JsonProperty("get_ported_date")
    private Boolean getPortedDate;
    @JsonProperty("get_disposable_number")
    private Boolean getDisposableNumber;
    @JsonProperty("supplementary_live_status")
    private RestApiPhoneSupplementaryLiveStatus supplementaryLiveStatus;

    public static RestApiPhoneValidateRequest using(final Configuration configuration) {
        final RestApiPhoneValidateRequest request = new RestApiPhoneValidateRequest();

        if (!configuration.getOutputFormat().isEmpty()) {
            request.setOutputFormat(configuration.getOutputFormat());
        }
        if (configuration.getCacheValueDays() != Configuration.DEFAULT_CACHE_VALUE_DAYS) {
            request.setCacheValueDays(configuration.getCacheValueDays());
        }
        if (configuration.getGetPortedDate()) {
            request.setGetPortedDate(true);
        }
        if (configuration.getGetDisposableNumber()) {
            request.setGetDisposableNumber(true);
        }


        if (!configuration.getLiveStatusForMobile().isEmpty() || !configuration.getLiveStatusForLandline().isEmpty()) {
            final RestApiPhoneSupplementaryLiveStatus supplementaryLiveStatus = new RestApiPhoneSupplementaryLiveStatus();
            if (!configuration.getLiveStatusForMobile().isEmpty()) {
                supplementaryLiveStatus.setMobile(configuration.getLiveStatusForMobile().stream().map(Country::getIso3Code).toList());
            }
            if (!configuration.getLiveStatusForLandline().isEmpty()) {
                supplementaryLiveStatus.setLandline(configuration.getLiveStatusForLandline().stream().map(Country::getIso3Code).toList());
            }
            request.setSupplementaryLiveStatus(supplementaryLiveStatus);
        }

        return request;
    }

    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    public String getOutputFormat() {
        return outputFormat;
    }

    public void setOutputFormat(String outputFormat) {
        this.outputFormat = outputFormat;
    }

    public Integer getCacheValueDays() {
        return cacheValueDays;
    }

    public void setCacheValueDays(Integer cacheValueDays) {
        this.cacheValueDays = cacheValueDays;
    }

    public String getCountryIso() {
        return countryIso;
    }

    public void setCountryIso(String countryIso) {
        this.countryIso = countryIso;
    }

    public Boolean getGetPortedDate() {
        return getPortedDate;
    }

    public void setGetPortedDate(Boolean getPortedDate) {
        this.getPortedDate = getPortedDate;
    }

    public Boolean getGetDisposableNumber() {
        return getDisposableNumber;
    }

    public void setGetDisposableNumber(Boolean getDisposableNumber) {
        this.getDisposableNumber = getDisposableNumber;
    }

    public RestApiPhoneSupplementaryLiveStatus getSupplementaryLiveStatus() {
        return supplementaryLiveStatus;
    }

    public void setSupplementaryLiveStatus(RestApiPhoneSupplementaryLiveStatus supplementaryLiveStatus) {
        this.supplementaryLiveStatus = supplementaryLiveStatus;
    }
}
