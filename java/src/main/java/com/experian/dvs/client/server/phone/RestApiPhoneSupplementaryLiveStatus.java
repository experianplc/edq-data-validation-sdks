package com.experian.dvs.client.server.phone;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiPhoneSupplementaryLiveStatus {

    @JsonProperty("mobile")
    private List<String> mobile;

    @JsonProperty("landline")
    private List<String> landline;

    public List<String> getMobile() {
        return mobile;
    }

    public void setMobile(List<String> mobile) {
        this.mobile = mobile;
    }

    public List<String> getLandline() {
        return landline;
    }

    public void setLandline(List<String> landline) {
        this.landline = landline;
    }
}
