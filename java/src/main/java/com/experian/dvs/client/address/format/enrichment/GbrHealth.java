package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.server.address.format.RestApiEnrichmentGbrHealth;

import java.util.Objects;

public class GbrHealth {

    private final String authorityCode;
    private final String authorityCode2011;
    private final String authorityName;
    private final String pclhCode;
    private final String pclhCode2011;
    private final String pclhName;
    private final String wardCode;
    private final String wardCode2011;
    private final String wardName;
    private final String ccgCode;
    private final String ccgName;
    private final String dohCode;

    // Constructor
    public GbrHealth(RestApiEnrichmentGbrHealth api) {
        this.authorityCode = Objects.toString(api.getAuthorityCode(), "");
        this.authorityCode2011 = Objects.toString(api.getAuthorityCode2011(), "");
        this.authorityName = Objects.toString(api.getAuthorityName(), "");
        this.pclhCode = Objects.toString(api.getPclhCode(), "");
        this.pclhCode2011 = Objects.toString(api.getPclhCode2011(), "");
        this.pclhName = Objects.toString(api.getPclhName(), "");
        this.wardCode = Objects.toString(api.getWardCode(), "");
        this.wardCode2011 = Objects.toString(api.getWardCode2011(), "");
        this.wardName = Objects.toString(api.getWardName(), "");
        this.ccgCode = Objects.toString(api.getCcgCode(), "");
        this.ccgName = Objects.toString(api.getCcgName(), "");
        this.dohCode = Objects.toString(api.getDohCode(), "");
    }

    // Getters
    public String getAuthorityCode() {
        return authorityCode;
    }

    public String getAuthorityCode2011() {
        return authorityCode2011;
    }

    public String getAuthorityName() {
        return authorityName;
    }

    public String getPclhCode() {
        return pclhCode;
    }

    public String getPclhCode2011() {
        return pclhCode2011;
    }

    public String getPclhName() {
        return pclhName;
    }

    public String getWardCode() {
        return wardCode;
    }

    public String getWardCode2011() {
        return wardCode2011;
    }

    public String getWardName() {
        return wardName;
    }

    public String getCcgCode() {
        return ccgCode;
    }

    public String getCcgName() {
        return ccgName;
    }

    public String getDohCode() {
        return dohCode;
    }
}
