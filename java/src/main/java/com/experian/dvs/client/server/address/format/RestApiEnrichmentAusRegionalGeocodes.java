package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentAusRegionalGeocodes {

    @JsonProperty("latitude")
    private Double latitude;

    @JsonProperty("longitude")
    private Double longitude;

    @JsonProperty("match_level")
    private String matchLevel;

    @JsonProperty("sa1")
    private String sa1;

    @JsonProperty("meshblock")
    private String meshblock;

    @JsonProperty("lga_code")
    private String lgaCode;

    @JsonProperty("lga_name")
    private String lgaName;

    @JsonProperty("street_pid")
    private String streetPid;

    @JsonProperty("locality_pid")
    private String localityPid;

    @JsonProperty("geocode_level_code")
    private String geocodeLevelCode;

    @JsonProperty("geocode_level_description")
    private String geocodeLevelDescription;

    @JsonProperty("geocode_type_code")
    private String geocodeTypeCode;

    @JsonProperty("geocode_type_description")
    private String geocodeTypeDescription;

    @JsonProperty("highest_level_longitude")
    private Double highestLevelLongitude;

    @JsonProperty("highest_level_latitude")
    private Double highestLevelLatitude;

    @JsonProperty("highest_level_elevation")
    private String highestLevelElevation;

    @JsonProperty("highest_level_planimetric_accuracy")
    private String highestLevelPlanimetricAccuracy;

    @JsonProperty("highest_level_boundary_extent")
    private String highestLevelBoundaryExtent;

    @JsonProperty("highest_level_geocode_reliability_code")
    private String highestLevelGeocodeReliabilityCode;

    @JsonProperty("highest_level_geocode_reliability_description")
    private String highestLevelGeocodeReliabilityDescription;

    @JsonProperty("confidence_level_code")
    private String confidenceLevelCode;

    @JsonProperty("confidence_level_description")
    private String confidenceLevelDescription;

    @JsonProperty("2021_meshblock_id")
    private String meshblockId2021;

    @JsonProperty("2021_meshblock_code")
    private String meshblockCode2021;

    @JsonProperty("2021_meshblock_match_code")
    private String meshblockMatchCode2021;

    @JsonProperty("2021_meshblock_match_description")
    private String meshblockMatchDescription2021;

    @JsonProperty("2016_meshblock_id")
    private String meshblockId2016;

    @JsonProperty("2016_meshblock_code")
    private String meshblockCode2016;

    @JsonProperty("2016_meshblock_match_code")
    private String meshblockMatchCode2016;

    @JsonProperty("2016_meshblock_match_description")
    private String meshblockMatchDescription2016;

    @JsonProperty("address_type_code")
    private String addressTypeCode;

    @JsonProperty("primary_address_pid")
    private String primaryAddressPid;

    @JsonProperty("address_join_type")
    private String addressJoinType;

    @JsonProperty("collector_district_id")
    private String collectorDistrictId;

    @JsonProperty("collector_district_code")
    private String collectorDistrictCode;

    @JsonProperty("commonwealth_electoral_boundary_id")
    private String commonwealthElectoralBoundaryId;

    @JsonProperty("commonwealth_electoral_boundary_name")
    private String commonwealthElectoralBoundaryName;

    @JsonProperty("statistical_local_area_id")
    private String statisticalLocalAreaId;

    @JsonProperty("statistical_local_area_code")
    private String statisticalLocalAreaCode;

    @JsonProperty("statistical_local_area_name")
    private String statisticalLocalAreaName;

    @JsonProperty("state_electoral_boundary_id")
    private String stateElectoralBoundaryId;

    @JsonProperty("state_electoral_boundary_name")
    private String stateElectoralBoundaryName;

    @JsonProperty("state_electoral_effective_start")
    private String stateElectoralEffectiveStart;

    @JsonProperty("state_electoral_effective_end")
    private String stateElectoralEffectiveEnd;

    @JsonProperty("state_electoral_new_pid")
    private String stateElectoralNewPid;

    @JsonProperty("state_electoral_new_name")
    private String stateElectoralNewName;

    @JsonProperty("state_electoral_new_effective_start")
    private String stateElectoralNewEffectiveStart;

    @JsonProperty("state_electoral_new_effective_end")
    private String stateElectoralNewEffectiveEnd;

    @JsonProperty("address_level_longitude")
    private Double addressLevelLongitude;

    @JsonProperty("address_level_latitude")
    private Double addressLevelLatitude;

    @JsonProperty("address_level_elevation")
    private String addressLevelElevation;

    @JsonProperty("address_level_planimetric_accuracy")
    private String addressLevelPlanimetricAccuracy;

    @JsonProperty("address_level_boundary_extent")
    private String addressLevelBoundaryExtent;

    @JsonProperty("address_level_geocode_reliability_code")
    private String addressLevelGeocodeReliabilityCode;

    @JsonProperty("address_level_geocode_reliability_description")
    private String addressLevelGeocodeReliabilityDescription;

    @JsonProperty("street_level_longitude")
    private Double streetLevelLongitude;

    @JsonProperty("street_level_latitude")
    private Double streetLevelLatitude;

    @JsonProperty("street_level_planimetric_accuracy")
    private String streetLevelPlanimetricAccuracy;

    @JsonProperty("street_level_boundary_extent")
    private String streetLevelBoundaryExtent;

    @JsonProperty("street_level_geocode_reliability_code")
    private String streetLevelGeocodeReliabilityCode;

    @JsonProperty("street_level_geocode_reliability_description")
    private String streetLevelGeocodeReliabilityDescription;

    @JsonProperty("locality_level_longitude")
    private Double localityLevelLongitude;

    @JsonProperty("locality_level_latitude")
    private Double localityLevelLatitude;

    @JsonProperty("locality_level_planimetric_accuracy")
    private String localityLevelPlanimetricAccuracy;

    @JsonProperty("locality_level_geocode_reliability_code")
    private String localityLevelGeocodeReliabilityCode;

    @JsonProperty("locality_level_geocode_reliability_description")
    private String localityLevelGeocodeReliabilityDescription;

    @JsonProperty("gnaf_legal_parcel_identifier")
    private String gnafLegalParcelIdentifier;

    @JsonProperty("locality_class_code")
    private String localityClassCode;

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

    public String getSa1() {
        return sa1;
    }

    public void setSa1(String sa1) {
        this.sa1 = sa1;
    }

    public String getMeshblock() {
        return meshblock;
    }

    public void setMeshblock(String meshblock) {
        this.meshblock = meshblock;
    }

    public String getLgaCode() {
        return lgaCode;
    }

    public void setLgaCode(String lgaCode) {
        this.lgaCode = lgaCode;
    }

    public String getLgaName() {
        return lgaName;
    }

    public void setLgaName(String lgaName) {
        this.lgaName = lgaName;
    }

    public String getStreetPid() {
        return streetPid;
    }

    public void setStreetPid(String streetPid) {
        this.streetPid = streetPid;
    }

    public String getLocalityPid() {
        return localityPid;
    }

    public void setLocalityPid(String localityPid) {
        this.localityPid = localityPid;
    }

    public String getGeocodeLevelCode() {
        return geocodeLevelCode;
    }

    public void setGeocodeLevelCode(String geocodeLevelCode) {
        this.geocodeLevelCode = geocodeLevelCode;
    }

    public String getGeocodeLevelDescription() {
        return geocodeLevelDescription;
    }

    public void setGeocodeLevelDescription(String geocodeLevelDescription) {
        this.geocodeLevelDescription = geocodeLevelDescription;
    }

    public String getGeocodeTypeCode() {
        return geocodeTypeCode;
    }

    public void setGeocodeTypeCode(String geocodeTypeCode) {
        this.geocodeTypeCode = geocodeTypeCode;
    }

    public String getGeocodeTypeDescription() {
        return geocodeTypeDescription;
    }

    public void setGeocodeTypeDescription(String geocodeTypeDescription) {
        this.geocodeTypeDescription = geocodeTypeDescription;
    }

    public Double getHighestLevelLongitude() {
        return highestLevelLongitude;
    }

    public void setHighestLevelLongitude(Double highestLevelLongitude) {
        this.highestLevelLongitude = highestLevelLongitude;
    }

    public Double getHighestLevelLatitude() {
        return highestLevelLatitude;
    }

    public void setHighestLevelLatitude(Double highestLevelLatitude) {
        this.highestLevelLatitude = highestLevelLatitude;
    }

    public String getHighestLevelElevation() {
        return highestLevelElevation;
    }

    public void setHighestLevelElevation(String highestLevelElevation) {
        this.highestLevelElevation = highestLevelElevation;
    }

    public String getHighestLevelPlanimetricAccuracy() {
        return highestLevelPlanimetricAccuracy;
    }

    public void setHighestLevelPlanimetricAccuracy(String highestLevelPlanimetricAccuracy) {
        this.highestLevelPlanimetricAccuracy = highestLevelPlanimetricAccuracy;
    }

    public String getHighestLevelBoundaryExtent() {
        return highestLevelBoundaryExtent;
    }

    public void setHighestLevelBoundaryExtent(String highestLevelBoundaryExtent) {
        this.highestLevelBoundaryExtent = highestLevelBoundaryExtent;
    }

    public String getHighestLevelGeocodeReliabilityCode() {
        return highestLevelGeocodeReliabilityCode;
    }

    public void setHighestLevelGeocodeReliabilityCode(String highestLevelGeocodeReliabilityCode) {
        this.highestLevelGeocodeReliabilityCode = highestLevelGeocodeReliabilityCode;
    }

    public String getHighestLevelGeocodeReliabilityDescription() {
        return highestLevelGeocodeReliabilityDescription;
    }

    public void setHighestLevelGeocodeReliabilityDescription(String highestLevelGeocodeReliabilityDescription) {
        this.highestLevelGeocodeReliabilityDescription = highestLevelGeocodeReliabilityDescription;
    }

    public String getConfidenceLevelCode() {
        return confidenceLevelCode;
    }

    public void setConfidenceLevelCode(String confidenceLevelCode) {
        this.confidenceLevelCode = confidenceLevelCode;
    }

    public String getConfidenceLevelDescription() {
        return confidenceLevelDescription;
    }

    public void setConfidenceLevelDescription(String confidenceLevelDescription) {
        this.confidenceLevelDescription = confidenceLevelDescription;
    }

    public String getMeshblockId2021() {
        return meshblockId2021;
    }

    public void setMeshblockId2021(String meshblockId2021) {
        this.meshblockId2021 = meshblockId2021;
    }

    public String getMeshblockCode2021() {
        return meshblockCode2021;
    }

    public void setMeshblockCode2021(String meshblockCode2021) {
        this.meshblockCode2021 = meshblockCode2021;
    }

    public String getMeshblockMatchCode2021() {
        return meshblockMatchCode2021;
    }

    public void setMeshblockMatchCode2021(String meshblockMatchCode2021) {
        this.meshblockMatchCode2021 = meshblockMatchCode2021;
    }

    public String getMeshblockMatchDescription2021() {
        return meshblockMatchDescription2021;
    }

    public void setMeshblockMatchDescription2021(String meshblockMatchDescription2021) {
        this.meshblockMatchDescription2021 = meshblockMatchDescription2021;
    }

    public String getMeshblockId2016() {
        return meshblockId2016;
    }

    public void setMeshblockId2016(String meshblockId2016) {
        this.meshblockId2016 = meshblockId2016;
    }

    public String getMeshblockCode2016() {
        return meshblockCode2016;
    }

    public void setMeshblockCode2016(String meshblockCode2016) {
        this.meshblockCode2016 = meshblockCode2016;
    }

    public String getMeshblockMatchCode2016() {
        return meshblockMatchCode2016;
    }

    public void setMeshblockMatchCode2016(String meshblockMatchCode2016) {
        this.meshblockMatchCode2016 = meshblockMatchCode2016;
    }

    public String getMeshblockMatchDescription2016() {
        return meshblockMatchDescription2016;
    }

    public void setMeshblockMatchDescription2016(String meshblockMatchDescription2016) {
        this.meshblockMatchDescription2016 = meshblockMatchDescription2016;
    }

    public String getAddressTypeCode() {
        return addressTypeCode;
    }

    public void setAddressTypeCode(String addressTypeCode) {
        this.addressTypeCode = addressTypeCode;
    }

    public String getPrimaryAddressPid() {
        return primaryAddressPid;
    }

    public void setPrimaryAddressPid(String primaryAddressPid) {
        this.primaryAddressPid = primaryAddressPid;
    }

    public String getAddressJoinType() {
        return addressJoinType;
    }

    public void setAddressJoinType(String addressJoinType) {
        this.addressJoinType = addressJoinType;
    }

    public String getCollectorDistrictId() {
        return collectorDistrictId;
    }

    public void setCollectorDistrictId(String collectorDistrictId) {
        this.collectorDistrictId = collectorDistrictId;
    }

    public String getCollectorDistrictCode() {
        return collectorDistrictCode;
    }

    public void setCollectorDistrictCode(String collectorDistrictCode) {
        this.collectorDistrictCode = collectorDistrictCode;
    }

    public String getCommonwealthElectoralBoundaryId() {
        return commonwealthElectoralBoundaryId;
    }

    public void setCommonwealthElectoralBoundaryId(String commonwealthElectoralBoundaryId) {
        this.commonwealthElectoralBoundaryId = commonwealthElectoralBoundaryId;
    }

    public String getCommonwealthElectoralBoundaryName() {
        return commonwealthElectoralBoundaryName;
    }

    public void setCommonwealthElectoralBoundaryName(String commonwealthElectoralBoundaryName) {
        this.commonwealthElectoralBoundaryName = commonwealthElectoralBoundaryName;
    }

    public String getStatisticalLocalAreaId() {
        return statisticalLocalAreaId;
    }

    public void setStatisticalLocalAreaId(String statisticalLocalAreaId) {
        this.statisticalLocalAreaId = statisticalLocalAreaId;
    }

    public String getStatisticalLocalAreaCode() {
        return statisticalLocalAreaCode;
    }

    public void setStatisticalLocalAreaCode(String statisticalLocalAreaCode) {
        this.statisticalLocalAreaCode = statisticalLocalAreaCode;
    }

    public String getStatisticalLocalAreaName() {
        return statisticalLocalAreaName;
    }

    public void setStatisticalLocalAreaName(String statisticalLocalAreaName) {
        this.statisticalLocalAreaName = statisticalLocalAreaName;
    }

    public String getStateElectoralBoundaryId() {
        return stateElectoralBoundaryId;
    }

    public void setStateElectoralBoundaryId(String stateElectoralBoundaryId) {
        this.stateElectoralBoundaryId = stateElectoralBoundaryId;
    }

    public String getStateElectoralBoundaryName() {
        return stateElectoralBoundaryName;
    }

    public void setStateElectoralBoundaryName(String stateElectoralBoundaryName) {
        this.stateElectoralBoundaryName = stateElectoralBoundaryName;
    }

    public String getStateElectoralEffectiveStart() {
        return stateElectoralEffectiveStart;
    }

    public void setStateElectoralEffectiveStart(String stateElectoralEffectiveStart) {
        this.stateElectoralEffectiveStart = stateElectoralEffectiveStart;
    }

    public String getStateElectoralEffectiveEnd() {
        return stateElectoralEffectiveEnd;
    }

    public void setStateElectoralEffectiveEnd(String stateElectoralEffectiveEnd) {
        this.stateElectoralEffectiveEnd = stateElectoralEffectiveEnd;
    }

    public String getStateElectoralNewPid() {
        return stateElectoralNewPid;
    }

    public void setStateElectoralNewPid(String stateElectoralNewPid) {
        this.stateElectoralNewPid = stateElectoralNewPid;
    }

    public String getStateElectoralNewName() {
        return stateElectoralNewName;
    }

    public void setStateElectoralNewName(String stateElectoralNewName) {
        this.stateElectoralNewName = stateElectoralNewName;
    }

    public String getStateElectoralNewEffectiveStart() {
        return stateElectoralNewEffectiveStart;
    }

    public void setStateElectoralNewEffectiveStart(String stateElectoralNewEffectiveStart) {
        this.stateElectoralNewEffectiveStart = stateElectoralNewEffectiveStart;
    }

    public String getStateElectoralNewEffectiveEnd() {
        return stateElectoralNewEffectiveEnd;
    }

    public void setStateElectoralNewEffectiveEnd(String stateElectoralNewEffectiveEnd) {
        this.stateElectoralNewEffectiveEnd = stateElectoralNewEffectiveEnd;
    }

    public Double getAddressLevelLongitude() {
        return addressLevelLongitude;
    }

    public void setAddressLevelLongitude(Double addressLevelLongitude) {
        this.addressLevelLongitude = addressLevelLongitude;
    }

    public Double getAddressLevelLatitude() {
        return addressLevelLatitude;
    }

    public void setAddressLevelLatitude(Double addressLevelLatitude) {
        this.addressLevelLatitude = addressLevelLatitude;
    }

    public String getAddressLevelElevation() {
        return addressLevelElevation;
    }

    public void setAddressLevelElevation(String addressLevelElevation) {
        this.addressLevelElevation = addressLevelElevation;
    }

    public String getAddressLevelPlanimetricAccuracy() {
        return addressLevelPlanimetricAccuracy;
    }

    public void setAddressLevelPlanimetricAccuracy(String addressLevelPlanimetricAccuracy) {
        this.addressLevelPlanimetricAccuracy = addressLevelPlanimetricAccuracy;
    }

    public String getAddressLevelBoundaryExtent() {
        return addressLevelBoundaryExtent;
    }

    public void setAddressLevelBoundaryExtent(String addressLevelBoundaryExtent) {
        this.addressLevelBoundaryExtent = addressLevelBoundaryExtent;
    }

    public String getAddressLevelGeocodeReliabilityCode() {
        return addressLevelGeocodeReliabilityCode;
    }

    public void setAddressLevelGeocodeReliabilityCode(String addressLevelGeocodeReliabilityCode) {
        this.addressLevelGeocodeReliabilityCode = addressLevelGeocodeReliabilityCode;
    }

    public String getAddressLevelGeocodeReliabilityDescription() {
        return addressLevelGeocodeReliabilityDescription;
    }

    public void setAddressLevelGeocodeReliabilityDescription(String addressLevelGeocodeReliabilityDescription) {
        this.addressLevelGeocodeReliabilityDescription = addressLevelGeocodeReliabilityDescription;
    }

    public Double getStreetLevelLongitude() {
        return streetLevelLongitude;
    }

    public void setStreetLevelLongitude(Double streetLevelLongitude) {
        this.streetLevelLongitude = streetLevelLongitude;
    }

    public Double getStreetLevelLatitude() {
        return streetLevelLatitude;
    }

    public void setStreetLevelLatitude(Double streetLevelLatitude) {
        this.streetLevelLatitude = streetLevelLatitude;
    }

    public String getStreetLevelPlanimetricAccuracy() {
        return streetLevelPlanimetricAccuracy;
    }

    public void setStreetLevelPlanimetricAccuracy(String streetLevelPlanimetricAccuracy) {
        this.streetLevelPlanimetricAccuracy = streetLevelPlanimetricAccuracy;
    }

    public String getStreetLevelBoundaryExtent() {
        return streetLevelBoundaryExtent;
    }

    public void setStreetLevelBoundaryExtent(String streetLevelBoundaryExtent) {
        this.streetLevelBoundaryExtent = streetLevelBoundaryExtent;
    }

    public String getStreetLevelGeocodeReliabilityCode() {
        return streetLevelGeocodeReliabilityCode;
    }

    public void setStreetLevelGeocodeReliabilityCode(String streetLevelGeocodeReliabilityCode) {
        this.streetLevelGeocodeReliabilityCode = streetLevelGeocodeReliabilityCode;
    }

    public String getStreetLevelGeocodeReliabilityDescription() {
        return streetLevelGeocodeReliabilityDescription;
    }

    public void setStreetLevelGeocodeReliabilityDescription(String streetLevelGeocodeReliabilityDescription) {
        this.streetLevelGeocodeReliabilityDescription = streetLevelGeocodeReliabilityDescription;
    }

    public Double getLocalityLevelLongitude() {
        return localityLevelLongitude;
    }

    public void setLocalityLevelLongitude(Double localityLevelLongitude) {
        this.localityLevelLongitude = localityLevelLongitude;
    }

    public Double getLocalityLevelLatitude() {
        return localityLevelLatitude;
    }

    public void setLocalityLevelLatitude(Double localityLevelLatitude) {
        this.localityLevelLatitude = localityLevelLatitude;
    }

    public String getLocalityLevelPlanimetricAccuracy() {
        return localityLevelPlanimetricAccuracy;
    }

    public void setLocalityLevelPlanimetricAccuracy(String localityLevelPlanimetricAccuracy) {
        this.localityLevelPlanimetricAccuracy = localityLevelPlanimetricAccuracy;
    }

    public String getLocalityLevelGeocodeReliabilityCode() {
        return localityLevelGeocodeReliabilityCode;
    }

    public void setLocalityLevelGeocodeReliabilityCode(String localityLevelGeocodeReliabilityCode) {
        this.localityLevelGeocodeReliabilityCode = localityLevelGeocodeReliabilityCode;
    }

    public String getLocalityLevelGeocodeReliabilityDescription() {
        return localityLevelGeocodeReliabilityDescription;
    }

    public void setLocalityLevelGeocodeReliabilityDescription(String localityLevelGeocodeReliabilityDescription) {
        this.localityLevelGeocodeReliabilityDescription = localityLevelGeocodeReliabilityDescription;
    }

    public String getGnafLegalParcelIdentifier() {
        return gnafLegalParcelIdentifier;
    }

    public void setGnafLegalParcelIdentifier(String gnafLegalParcelIdentifier) {
        this.gnafLegalParcelIdentifier = gnafLegalParcelIdentifier;
    }

    public String getLocalityClassCode() {
        return localityClassCode;
    }

    public void setLocalityClassCode(String localityClassCode) {
        this.localityClassCode = localityClassCode;
    }
}