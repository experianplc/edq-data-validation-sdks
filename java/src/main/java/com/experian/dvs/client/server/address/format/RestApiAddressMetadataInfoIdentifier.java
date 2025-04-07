package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressMetadataInfoIdentifier {

    @JsonProperty("umrrn")
    private String umrrn;
    @JsonProperty("udprn")
    private String udprn;
    @JsonProperty("dpid")
    private String dpid;
    @JsonProperty("gnafpid")
    private String gnafpid;
    @JsonProperty("paf_address_key")
    private String pafAddressKey;
    @JsonProperty("hin")
    private String hin;


    public String getUmrrn() {
        return umrrn;
    }

    public void setUmrrn(String umrrn) {
        this.umrrn = umrrn;
    }

    public String getUdprn() {
        return udprn;
    }

    public void setUdprn(String udprn) {
        this.udprn = udprn;
    }

    public String getDpid() {
        return dpid;
    }

    public void setDpid(String dpid) {
        this.dpid = dpid;
    }

    public String getGnafpid() {
        return gnafpid;
    }

    public void setGnafpid(String gnafpid) {
        this.gnafpid = gnafpid;
    }

    public String getPafAddressKey() {
        return pafAddressKey;
    }

    public void setPafAddressKey(String pafAddressKey) {
        this.pafAddressKey = pafAddressKey;
    }

    public String getHin() {
        return hin;
    }

    public void setHin(String hin) {
        this.hin = hin;
    }
}
