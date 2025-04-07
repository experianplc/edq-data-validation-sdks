package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.server.address.format.RestApiEnrichmentGbrGovernment;

import java.util.Objects;

public class GbrGovernment {

    private final String eerCode;
    private final String eerCodePre2011;
    private final String eerName;
    private final String gorCode;
    private final String gorCodePre2011;
    private final String gorName;
    private final String leaCode;
    private final String leaName;
    private final String laCode;
    private final String laCodePre2011;
    private final String laName;
    private final String wardCode;
    private final String wardCodePre2011;
    private final String wardName;
    private final String censOutArea;

    // Constructor
    public GbrGovernment(RestApiEnrichmentGbrGovernment api) {
        this.eerCode = Objects.toString(api.getEerCode(), "");
        this.eerCodePre2011 = Objects.toString(api.getEerCodePre2011(), "");
        this.eerName = Objects.toString(api.getEerName(), "");
        this.gorCode = Objects.toString(api.getGorCode(), "");
        this.gorCodePre2011 = Objects.toString(api.getGorCodePre2011(), "");
        this.gorName = Objects.toString(api.getGorName(), "");
        this.leaCode = Objects.toString(api.getLeaCode(), "");
        this.leaName = Objects.toString(api.getLeaName(), "");
        this.laCode = Objects.toString(api.getLaCode(), "");
        this.laCodePre2011 = Objects.toString(api.getLaCodePre2011(), "");
        this.laName = Objects.toString(api.getLaName(), "");
        this.wardCode = Objects.toString(api.getWardCode(), "");
        this.wardCodePre2011 = Objects.toString(api.getWardCodePre2011(), "");
        this.wardName = Objects.toString(api.getWardName(), "");
        this.censOutArea = Objects.toString(api.getCensOutArea(), "");
    }

    // Getters
    public String getEerCode() {
        return eerCode;
    }

    public String getEerCodePre2011() {
        return eerCodePre2011;
    }

    public String getEerName() {
        return eerName;
    }

    public String getGorCode() {
        return gorCode;
    }

    public String getGorCodePre2011() {
        return gorCodePre2011;
    }

    public String getGorName() {
        return gorName;
    }

    public String getLeaCode() {
        return leaCode;
    }

    public String getLeaName() {
        return leaName;
    }

    public String getLaCode() {
        return laCode;
    }

    public String getLaCodePre2011() {
        return laCodePre2011;
    }

    public String getLaName() {
        return laName;
    }

    public String getWardCode() {
        return wardCode;
    }

    public String getWardCodePre2011() {
        return wardCodePre2011;
    }

    public String getWardName() {
        return wardName;
    }

    public String getCensOutArea() {
        return censOutArea;
    }
}