package com.experian.dvs.client.server.address.format;


import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentNzlRegionalGeocodes {

    @JsonProperty("front_of_property_nztm_x_coordinate")
    private Double frontOfPropertyNztmXCoordinate;

    @JsonProperty("front_of_property_nztm_y_coordinate")
    private Double frontOfPropertyNztmYCoordinate;

    @JsonProperty("centroid_of_property_nztm_x_coordinate")
    private Double centroidOfPropertyNztmXCoordinate;

    @JsonProperty("centroid_of_property_nztm_y_coordinate")
    private Double centroidOfPropertyNztmYCoordinate;

    @JsonProperty("linz_parcel_id")
    private String linzParcelId;

    @JsonProperty("property_purpose_type")
    private String propertyPurposeType;

    @JsonProperty("addressable")
    private String addressable;

    @JsonProperty("mesh_block_code")
    private String meshBlockCode;

    @JsonProperty("territorial_authority_code")
    private String territorialAuthorityCode;

    @JsonProperty("territorial_authority_name")
    private String territorialAuthorityName;

    @JsonProperty("regional_council_code")
    private String regionalCouncilCode;

    @JsonProperty("regional_council_name")
    private String regionalCouncilName;

    @JsonProperty("general_electorate_code")
    private String generalElectorateCode;

    @JsonProperty("general_electorate_name")
    private String generalElectorateName;

    @JsonProperty("maori_electorate_code")
    private String maoriElectorateCode;

    @JsonProperty("maori_electorate_name")
    private String maoriElectorateName;

    @JsonProperty("front_of_property_latitude")
    private Double frontOfPropertyLatitude;

    @JsonProperty("front_of_property_longitude")
    private Double frontOfPropertyLongitude;

    @JsonProperty("centroid_of_property_latitude")
    private Double centroidOfPropertyLatitude;

    @JsonProperty("centroid_of_property_longitude")
    private Double centroidOfPropertyLongitude;

    @JsonProperty("match_level")
    private String matchLevel;

    // Getters and Setters
    public Double getFrontOfPropertyNztmXCoordinate() {
        return frontOfPropertyNztmXCoordinate;
    }

    public void setFrontOfPropertyNztmXCoordinate(Double frontOfPropertyNztmXCoordinate) {
        this.frontOfPropertyNztmXCoordinate = frontOfPropertyNztmXCoordinate;
    }

    public Double getFrontOfPropertyNztmYCoordinate() {
        return frontOfPropertyNztmYCoordinate;
    }

    public void setFrontOfPropertyNztmYCoordinate(Double frontOfPropertyNztmYCoordinate) {
        this.frontOfPropertyNztmYCoordinate = frontOfPropertyNztmYCoordinate;
    }

    public Double getCentroidOfPropertyNztmXCoordinate() {
        return centroidOfPropertyNztmXCoordinate;
    }

    public void setCentroidOfPropertyNztmXCoordinate(Double centroidOfPropertyNztmXCoordinate) {
        this.centroidOfPropertyNztmXCoordinate = centroidOfPropertyNztmXCoordinate;
    }

    public Double getCentroidOfPropertyNztmYCoordinate() {
        return centroidOfPropertyNztmYCoordinate;
    }

    public void setCentroidOfPropertyNztmYCoordinate(Double centroidOfPropertyNztmYCoordinate) {
        this.centroidOfPropertyNztmYCoordinate = centroidOfPropertyNztmYCoordinate;
    }

    public String getLinzParcelId() {
        return linzParcelId;
    }

    public void setLinzParcelId(String linzParcelId) {
        this.linzParcelId = linzParcelId;
    }

    public String getPropertyPurposeType() {
        return propertyPurposeType;
    }

    public void setPropertyPurposeType(String propertyPurposeType) {
        this.propertyPurposeType = propertyPurposeType;
    }

    public String getAddressable() {
        return addressable;
    }

    public void setAddressable(String addressable) {
        this.addressable = addressable;
    }

    public String getMeshBlockCode() {
        return meshBlockCode;
    }

    public void setMeshBlockCode(String meshBlockCode) {
        this.meshBlockCode = meshBlockCode;
    }

    public String getTerritorialAuthorityCode() {
        return territorialAuthorityCode;
    }

    public void setTerritorialAuthorityCode(String territorialAuthorityCode) {
        this.territorialAuthorityCode = territorialAuthorityCode;
    }

    public String getTerritorialAuthorityName() {
        return territorialAuthorityName;
    }

    public void setTerritorialAuthorityName(String territorialAuthorityName) {
        this.territorialAuthorityName = territorialAuthorityName;
    }

    public String getRegionalCouncilCode() {
        return regionalCouncilCode;
    }

    public void setRegionalCouncilCode(String regionalCouncilCode) {
        this.regionalCouncilCode = regionalCouncilCode;
    }

    public String getRegionalCouncilName() {
        return regionalCouncilName;
    }

    public void setRegionalCouncilName(String regionalCouncilName) {
        this.regionalCouncilName = regionalCouncilName;
    }

    public String getGeneralElectorateCode() {
        return generalElectorateCode;
    }

    public void setGeneralElectorateCode(String generalElectorateCode) {
        this.generalElectorateCode = generalElectorateCode;
    }

    public String getGeneralElectorateName() {
        return generalElectorateName;
    }

    public void setGeneralElectorateName(String generalElectorateName) {
        this.generalElectorateName = generalElectorateName;
    }

    public String getMaoriElectorateCode() {
        return maoriElectorateCode;
    }

    public void setMaoriElectorateCode(String maoriElectorateCode) {
        this.maoriElectorateCode = maoriElectorateCode;
    }

    public String getMaoriElectorateName() {
        return maoriElectorateName;
    }

    public void setMaoriElectorateName(String maoriElectorateName) {
        this.maoriElectorateName = maoriElectorateName;
    }

    public Double getFrontOfPropertyLatitude() {
        return frontOfPropertyLatitude;
    }

    public void setFrontOfPropertyLatitude(Double frontOfPropertyLatitude) {
        this.frontOfPropertyLatitude = frontOfPropertyLatitude;
    }

    public Double getFrontOfPropertyLongitude() {
        return frontOfPropertyLongitude;
    }

    public void setFrontOfPropertyLongitude(Double frontOfPropertyLongitude) {
        this.frontOfPropertyLongitude = frontOfPropertyLongitude;
    }

    public Double getCentroidOfPropertyLatitude() {
        return centroidOfPropertyLatitude;
    }

    public void setCentroidOfPropertyLatitude(Double centroidOfPropertyLatitude) {
        this.centroidOfPropertyLatitude = centroidOfPropertyLatitude;
    }

    public Double getCentroidOfPropertyLongitude() {
        return centroidOfPropertyLongitude;
    }

    public void setCentroidOfPropertyLongitude(Double centroidOfPropertyLongitude) {
        this.centroidOfPropertyLongitude = centroidOfPropertyLongitude;
    }

    public String getMatchLevel() {
        return matchLevel;
    }

    public void setMatchLevel(String matchLevel) {
        this.matchLevel = matchLevel;
    }
}