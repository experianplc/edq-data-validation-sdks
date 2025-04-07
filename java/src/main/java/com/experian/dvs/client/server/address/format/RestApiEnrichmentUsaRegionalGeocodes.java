package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentUsaRegionalGeocodes {

    @JsonProperty("latitude")
    private Double latitude;

    @JsonProperty("longitude")
    private Double longitude;

    @JsonProperty("match_level")
    private String matchLevel;

    @JsonProperty("census_tract")
    private String censusTract;

    @JsonProperty("census_block")
    private String censusBlock;

    @JsonProperty("core_based_statistical_area")
    private String coreBasedStatisticalArea;

    @JsonProperty("congressional_district_code")
    private String congressionalDistrictCode;

    @JsonProperty("county_code")
    private String countyCode;

    // Getters and Setters
    public Double getLatitude() {
        return latitude;
    }

    public void setLatitude(Double latitude) {
        this.latitude = latitude;
    }

    public Double getLongitude() {
        return longitude;
    }

    public void setLongitude(Double longitude) {
        this.longitude = longitude;
    }

    public String getMatchLevel() {
        return matchLevel;
    }

    public void setMatchLevel(String matchLevel) {
        this.matchLevel = matchLevel;
    }

    public String getCensusTract() {
        return censusTract;
    }

    public void setCensusTract(String censusTract) {
        this.censusTract = censusTract;
    }

    public String getCensusBlock() {
        return censusBlock;
    }

    public void setCensusBlock(String censusBlock) {
        this.censusBlock = censusBlock;
    }

    public String getCoreBasedStatisticalArea() {
        return coreBasedStatisticalArea;
    }

    public void setCoreBasedStatisticalArea(String coreBasedStatisticalArea) {
        this.coreBasedStatisticalArea = coreBasedStatisticalArea;
    }

    public String getCongressionalDistrictCode() {
        return congressionalDistrictCode;
    }

    public void setCongressionalDistrictCode(String congressionalDistrictCode) {
        this.congressionalDistrictCode = congressionalDistrictCode;
    }

    public String getCountyCode() {
        return countyCode;
    }

    public void setCountyCode(String countyCode) {
        this.countyCode = countyCode;
    }
}

