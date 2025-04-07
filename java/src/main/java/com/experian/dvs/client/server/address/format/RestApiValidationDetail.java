package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiValidationDetail {

    @JsonProperty("building_firm_name_corrected")
    private Boolean buildingFirmNameCorrected;

    @JsonProperty("primary_number_corrected")
    private Boolean primaryNumberCorrected;

    @JsonProperty("street_corrected")
    private Boolean streetCorrected;

    @JsonProperty("rural_route_highway_contract_matched")
    private Boolean ruralRouteHighwayContractMatched;

    @JsonProperty("city_name_corrected")
    private Boolean cityNameCorrected;

    @JsonProperty("city_name_alias_matched")
    private Boolean cityNameAliasMatched;

    @JsonProperty("state_corrected")
    private Boolean stateCorrected;

    @JsonProperty("zip_code_corrected")
    private Boolean zipCodeCorrected;

    @JsonProperty("secondary_num_retained")
    private Boolean secondaryNumRetained;

    @JsonProperty("iden_pre_st_info_retained")
    private Boolean idenPreStInfoRetained;

    @JsonProperty("gen_pre_st_info_retained")
    private Boolean genPreStInfoRetained;

    @JsonProperty("post_st_info_retained")
    private Boolean postStInfoRetained;

    // Getters and Setters
    public Boolean isBuildingFirmNameCorrected() {
        return buildingFirmNameCorrected;
    }

    public void setBuildingFirmNameCorrected(Boolean buildingFirmNameCorrected) {
        this.buildingFirmNameCorrected = buildingFirmNameCorrected;
    }

    public Boolean isPrimaryNumberCorrected() {
        return primaryNumberCorrected;
    }

    public void setPrimaryNumberCorrected(Boolean primaryNumberCorrected) {
        this.primaryNumberCorrected = primaryNumberCorrected;
    }

    public Boolean isStreetCorrected() {
        return streetCorrected;
    }

    public void setStreetCorrected(Boolean streetCorrected) {
        this.streetCorrected = streetCorrected;
    }

    public Boolean isRuralRouteHighwayContractMatched() {
        return ruralRouteHighwayContractMatched;
    }

    public void setRuralRouteHighwayContractMatched(Boolean ruralRouteHighwayContractMatched) {
        this.ruralRouteHighwayContractMatched = ruralRouteHighwayContractMatched;
    }

    public Boolean isCityNameCorrected() {
        return cityNameCorrected;
    }

    public void setCityNameCorrected(Boolean cityNameCorrected) {
        this.cityNameCorrected = cityNameCorrected;
    }

    public Boolean isCityNameAliasMatched() {
        return cityNameAliasMatched;
    }

    public void setCityNameAliasMatched(Boolean cityNameAliasMatched) {
        this.cityNameAliasMatched = cityNameAliasMatched;
    }

    public Boolean isStateCorrected() {
        return stateCorrected;
    }

    public void setStateCorrected(Boolean stateCorrected) {
        this.stateCorrected = stateCorrected;
    }

    public Boolean isZipCodeCorrected() {
        return zipCodeCorrected;
    }

    public void setZipCodeCorrected(Boolean zipCodeCorrected) {
        this.zipCodeCorrected = zipCodeCorrected;
    }

    public Boolean isSecondaryNumRetained() {
        return secondaryNumRetained;
    }

    public void setSecondaryNumRetained(Boolean secondaryNumRetained) {
        this.secondaryNumRetained = secondaryNumRetained;
    }

    public Boolean isIdenPreStInfoRetained() {
        return idenPreStInfoRetained;
    }

    public void setIdenPreStInfoRetained(Boolean idenPreStInfoRetained) {
        this.idenPreStInfoRetained = idenPreStInfoRetained;
    }

    public Boolean isGenPreStInfoRetained() {
        return genPreStInfoRetained;
    }

    public void setGenPreStInfoRetained(Boolean genPreStInfoRetained) {
        this.genPreStInfoRetained = genPreStInfoRetained;
    }

    public Boolean isPostStInfoRetained() {
        return postStInfoRetained;
    }

    public void setPostStInfoRetained(Boolean postStInfoRetained) {
        this.postStInfoRetained = postStInfoRetained;
    }
}
