package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.address.format.GeocodeMatchLevel;
import com.experian.dvs.client.server.address.format.RestApiEnrichmentAusRegionalGeocodes;

import java.util.Objects;

public class AusRegionalGeocodes {

    private final Double latitude;
    private final Double longitude;
    private final GeocodeMatchLevel matchLevel;
    private final String sa1;
    private final String meshblock;
    private final String lgaCode;
    private final String lgaName;
    private final String streetPid;
    private final String localityPid;
    private final String geocodeLevelCode;
    private final String geocodeLevelDescription;
    private final String geocodeTypeCode;
    private final String geocodeTypeDescription;
    private final Double highestLevelLongitude;
    private final Double highestLevelLatitude;
    private final String highestLevelElevation;
    private final String highestLevelPlanimetricAccuracy;
    private final String highestLevelBoundaryExtent;
    private final String highestLevelGeocodeReliabilityCode;
    private final String highestLevelGeocodeReliabilityDescription;
    private final String confidenceLevelCode;
    private final String confidenceLevelDescription;
    private final String meshblockId2021;
    private final String meshblockCode2021;
    private final String meshblockMatchCode2021;
    private final String meshblockMatchDescription2021;
    private final String meshblockId2016;
    private final String meshblockCode2016;
    private final String meshblockMatchCode2016;
    private final String meshblockMatchDescription2016;
    private final String addressTypeCode;
    private final String primaryAddressPid;
    private final String addressJoinType;
    private final String collectorDistrictId;
    private final String collectorDistrictCode;
    private final String commonwealthElectoralBoundaryId;
    private final String commonwealthElectoralBoundaryName;
    private final String statisticalLocalAreaId;
    private final String statisticalLocalAreaCode;
    private final String statisticalLocalAreaName;
    private final String stateElectoralBoundaryId;
    private final String stateElectoralBoundaryName;
    private final String stateElectoralEffectiveStart;
    private final String stateElectoralEffectiveEnd;
    private final String stateElectoralNewPid;
    private final String stateElectoralNewName;
    private final String stateElectoralNewEffectiveStart;
    private final String stateElectoralNewEffectiveEnd;
    private final Double addressLevelLongitude;
    private final Double addressLevelLatitude;
    private final String addressLevelElevation;
    private final String addressLevelPlanimetricAccuracy;
    private final String addressLevelBoundaryExtent;
    private final String addressLevelGeocodeReliabilityCode;
    private final String addressLevelGeocodeReliabilityDescription;
    private final Double streetLevelLongitude;
    private final Double streetLevelLatitude;
    private final String streetLevelPlanimetricAccuracy;
    private final String streetLevelBoundaryExtent;
    private final String streetLevelGeocodeReliabilityCode;
    private final String streetLevelGeocodeReliabilityDescription;
    private final Double localityLevelLongitude;
    private final Double localityLevelLatitude;
    private final String localityLevelPlanimetricAccuracy;
    private final String localityLevelGeocodeReliabilityCode;
    private final String localityLevelGeocodeReliabilityDescription;
    private final String gnafLegalParcelIdentifier;
    private final String localityClassCode;

    public AusRegionalGeocodes(RestApiEnrichmentAusRegionalGeocodes apiGeocodes) {
        this.latitude = apiGeocodes.getLatitude();
        this.longitude = apiGeocodes.getLongitude();
        this.matchLevel = apiGeocodes.getMatchLevel() != null ? GeocodeMatchLevel.fromValue(apiGeocodes.getMatchLevel()) : null;
        this.sa1 = Objects.toString(apiGeocodes.getSa1(), "");
        this.meshblock = Objects.toString(apiGeocodes.getMeshblock(), "");
        this.lgaCode = Objects.toString(apiGeocodes.getLgaCode(), "");
        this.lgaName = Objects.toString(apiGeocodes.getLgaName(), "");
        this.streetPid = Objects.toString(apiGeocodes.getStreetPid(), "");
        this.localityPid = Objects.toString(apiGeocodes.getLocalityPid(), "");
        this.geocodeLevelCode = Objects.toString(apiGeocodes.getGeocodeLevelCode(), "");
        this.geocodeLevelDescription = Objects.toString(apiGeocodes.getGeocodeLevelDescription(), "");
        this.geocodeTypeCode = Objects.toString(apiGeocodes.getGeocodeTypeCode(), "");
        this.geocodeTypeDescription = Objects.toString(apiGeocodes.getGeocodeTypeDescription(), "");
        this.highestLevelLongitude = apiGeocodes.getHighestLevelLongitude();
        this.highestLevelLatitude = apiGeocodes.getHighestLevelLatitude();
        this.highestLevelElevation = Objects.toString(apiGeocodes.getHighestLevelElevation(), "");
        this.highestLevelPlanimetricAccuracy = Objects.toString(apiGeocodes.getHighestLevelPlanimetricAccuracy(), "");
        this.highestLevelBoundaryExtent = Objects.toString(apiGeocodes.getHighestLevelBoundaryExtent(), "");
        this.highestLevelGeocodeReliabilityCode = Objects.toString(apiGeocodes.getHighestLevelGeocodeReliabilityCode(), "");
        this.highestLevelGeocodeReliabilityDescription = Objects.toString(apiGeocodes.getHighestLevelGeocodeReliabilityDescription(), "");
        this.confidenceLevelCode = Objects.toString(apiGeocodes.getConfidenceLevelCode(), "");
        this.confidenceLevelDescription = Objects.toString(apiGeocodes.getConfidenceLevelDescription(), "");
        this.meshblockId2021 = Objects.toString(apiGeocodes.getMeshblockId2021(), "");
        this.meshblockCode2021 = Objects.toString(apiGeocodes.getMeshblockCode2021(), "");
        this.meshblockMatchCode2021 = Objects.toString(apiGeocodes.getMeshblockMatchCode2021(), "");
        this.meshblockMatchDescription2021 = Objects.toString(apiGeocodes.getMeshblockMatchDescription2021(), "");
        this.meshblockId2016 = Objects.toString(apiGeocodes.getMeshblockId2016(), "");
        this.meshblockCode2016 = Objects.toString(apiGeocodes.getMeshblockCode2016(), "");
        this.meshblockMatchCode2016 = Objects.toString(apiGeocodes.getMeshblockMatchCode2016(), "");
        this.meshblockMatchDescription2016 = Objects.toString(apiGeocodes.getMeshblockMatchDescription2016(), "");
        this.addressTypeCode = Objects.toString(apiGeocodes.getAddressTypeCode(), "");
        this.primaryAddressPid = Objects.toString(apiGeocodes.getPrimaryAddressPid(), "");
        this.addressJoinType = Objects.toString(apiGeocodes.getAddressJoinType(), "");
        this.collectorDistrictId = Objects.toString(apiGeocodes.getCollectorDistrictId(), "");
        this.collectorDistrictCode = Objects.toString(apiGeocodes.getCollectorDistrictCode(), "");
        this.commonwealthElectoralBoundaryId = Objects.toString(apiGeocodes.getCommonwealthElectoralBoundaryId(), "");
        this.commonwealthElectoralBoundaryName = Objects.toString(apiGeocodes.getCommonwealthElectoralBoundaryName(), "");
        this.statisticalLocalAreaId = Objects.toString(apiGeocodes.getStatisticalLocalAreaId(), "");
        this.statisticalLocalAreaCode = Objects.toString(apiGeocodes.getStatisticalLocalAreaCode(), "");
        this.statisticalLocalAreaName = Objects.toString(apiGeocodes.getStatisticalLocalAreaName(), "");
        this.stateElectoralBoundaryId = Objects.toString(apiGeocodes.getStateElectoralBoundaryId(), "");
        this.stateElectoralBoundaryName = Objects.toString(apiGeocodes.getStateElectoralBoundaryName(), "");
        this.stateElectoralEffectiveStart = Objects.toString(apiGeocodes.getStateElectoralEffectiveStart(), "");
        this.stateElectoralEffectiveEnd = Objects.toString(apiGeocodes.getStateElectoralEffectiveEnd(), "");
        this.stateElectoralNewPid = Objects.toString(apiGeocodes.getStateElectoralNewPid(), "");
        this.stateElectoralNewName = Objects.toString(apiGeocodes.getStateElectoralNewName(), "");
        this.stateElectoralNewEffectiveStart = Objects.toString(apiGeocodes.getStateElectoralNewEffectiveStart(), "");
        this.stateElectoralNewEffectiveEnd = Objects.toString(apiGeocodes.getStateElectoralNewEffectiveEnd(), "");
        this.addressLevelLongitude = apiGeocodes.getAddressLevelLongitude();
        this.addressLevelLatitude = apiGeocodes.getAddressLevelLatitude();
        this.addressLevelElevation = Objects.toString(apiGeocodes.getAddressLevelElevation(), "");
        this.addressLevelPlanimetricAccuracy = Objects.toString(apiGeocodes.getAddressLevelPlanimetricAccuracy(), "");
        this.addressLevelBoundaryExtent = Objects.toString(apiGeocodes.getAddressLevelBoundaryExtent(), "");
        this.addressLevelGeocodeReliabilityCode = Objects.toString(apiGeocodes.getAddressLevelGeocodeReliabilityCode(), "");
        this.addressLevelGeocodeReliabilityDescription = Objects.toString(apiGeocodes.getAddressLevelGeocodeReliabilityDescription(), "");
        this.streetLevelLongitude = apiGeocodes.getStreetLevelLongitude();
        this.streetLevelLatitude = apiGeocodes.getStreetLevelLatitude();
        this.streetLevelPlanimetricAccuracy = Objects.toString(apiGeocodes.getStreetLevelPlanimetricAccuracy(), "");
        this.streetLevelBoundaryExtent = Objects.toString(apiGeocodes.getStreetLevelBoundaryExtent(), "");
        this.streetLevelGeocodeReliabilityCode = Objects.toString(apiGeocodes.getStreetLevelGeocodeReliabilityCode(), "");
        this.streetLevelGeocodeReliabilityDescription = Objects.toString(apiGeocodes.getStreetLevelGeocodeReliabilityDescription(), "");
        this.localityLevelLongitude = apiGeocodes.getLocalityLevelLongitude();
        this.localityLevelLatitude = apiGeocodes.getLocalityLevelLatitude();
        this.localityLevelPlanimetricAccuracy = Objects.toString(apiGeocodes.getLocalityLevelPlanimetricAccuracy(), "");
        this.localityLevelGeocodeReliabilityCode = Objects.toString(apiGeocodes.getLocalityLevelGeocodeReliabilityCode(), "");
        this.localityLevelGeocodeReliabilityDescription = Objects.toString(apiGeocodes.getLocalityLevelGeocodeReliabilityDescription(), "");
        this.gnafLegalParcelIdentifier = Objects.toString(apiGeocodes.getGnafLegalParcelIdentifier(), "");
        this.localityClassCode = Objects.toString(apiGeocodes.getLocalityClassCode(), "");

    }

    public Double getLatitude() {
        return latitude;
    }

    public Double getLongitude() {
        return longitude;
    }

    public GeocodeMatchLevel getMatchLevel() {
        return matchLevel;
    }

    public String getSa1() {
        return sa1;
    }

    public String getMeshblock() {
        return meshblock;
    }

    public String getLgaCode() {
        return lgaCode;
    }

    public String getLgaName() {
        return lgaName;
    }

    public String getStreetPid() {
        return streetPid;
    }

    public String getLocalityPid() {
        return localityPid;
    }

    public String getGeocodeLevelCode() {
        return geocodeLevelCode;
    }

    public String getGeocodeLevelDescription() {
        return geocodeLevelDescription;
    }

    public String getGeocodeTypeCode() {
        return geocodeTypeCode;
    }

    public String getGeocodeTypeDescription() {
        return geocodeTypeDescription;
    }

    public Double getHighestLevelLongitude() {
        return highestLevelLongitude;
    }

    public Double getHighestLevelLatitude() {
        return highestLevelLatitude;
    }

    public String getHighestLevelElevation() {
        return highestLevelElevation;
    }

    public String getHighestLevelPlanimetricAccuracy() {
        return highestLevelPlanimetricAccuracy;
    }

    public String getHighestLevelBoundaryExtent() {
        return highestLevelBoundaryExtent;
    }

    public String getHighestLevelGeocodeReliabilityCode() {
        return highestLevelGeocodeReliabilityCode;
    }

    public String getHighestLevelGeocodeReliabilityDescription() {
        return highestLevelGeocodeReliabilityDescription;
    }

    public String getConfidenceLevelCode() {
        return confidenceLevelCode;
    }

    public String getConfidenceLevelDescription() {
        return confidenceLevelDescription;
    }

    public String getMeshblockId2021() {
        return meshblockId2021;
    }

    public String getMeshblockCode2021() {
        return meshblockCode2021;
    }

    public String getMeshblockMatchCode2021() {
        return meshblockMatchCode2021;
    }

    public String getMeshblockMatchDescription2021() {
        return meshblockMatchDescription2021;
    }

    public String getMeshblockId2016() {
        return meshblockId2016;
    }

    public String getMeshblockCode2016() {
        return meshblockCode2016;
    }

    public String getMeshblockMatchCode2016() {
        return meshblockMatchCode2016;
    }

    public String getMeshblockMatchDescription2016() {
        return meshblockMatchDescription2016;
    }

    public String getAddressTypeCode() {
        return addressTypeCode;
    }

    public String getPrimaryAddressPid() {
        return primaryAddressPid;
    }

    public String getAddressJoinType() {
        return addressJoinType;
    }

    public String getCollectorDistrictId() {
        return collectorDistrictId;
    }

    public String getCollectorDistrictCode() {
        return collectorDistrictCode;
    }

    public String getCommonwealthElectoralBoundaryId() {
        return commonwealthElectoralBoundaryId;
    }

    public String getCommonwealthElectoralBoundaryName() {
        return commonwealthElectoralBoundaryName;
    }

    public String getStatisticalLocalAreaId() {
        return statisticalLocalAreaId;
    }

    public String getStatisticalLocalAreaCode() {
        return statisticalLocalAreaCode;
    }

    public String getStatisticalLocalAreaName() {
        return statisticalLocalAreaName;
    }

    public String getStateElectoralBoundaryId() {
        return stateElectoralBoundaryId;
    }

    public String getStateElectoralBoundaryName() {
        return stateElectoralBoundaryName;
    }

    public String getStateElectoralEffectiveStart() {
        return stateElectoralEffectiveStart;
    }

    public String getStateElectoralEffectiveEnd() {
        return stateElectoralEffectiveEnd;
    }

    public String getStateElectoralNewPid() {
        return stateElectoralNewPid;
    }

    public String getStateElectoralNewName() {
        return stateElectoralNewName;
    }

    public String getStateElectoralNewEffectiveStart() {
        return stateElectoralNewEffectiveStart;
    }

    public String getStateElectoralNewEffectiveEnd() {
        return stateElectoralNewEffectiveEnd;
    }

    public Double getAddressLevelLongitude() {
        return addressLevelLongitude;
    }

    public Double getAddressLevelLatitude() {
        return addressLevelLatitude;
    }

    public String getAddressLevelElevation() {
        return addressLevelElevation;
    }

    public String getAddressLevelPlanimetricAccuracy() {
        return addressLevelPlanimetricAccuracy;
    }

    public String getAddressLevelBoundaryExtent() {
        return addressLevelBoundaryExtent;
    }

    public String getAddressLevelGeocodeReliabilityCode() {
        return addressLevelGeocodeReliabilityCode;
    }

    public String getAddressLevelGeocodeReliabilityDescription() {
        return addressLevelGeocodeReliabilityDescription;
    }

    public Double getStreetLevelLongitude() {
        return streetLevelLongitude;
    }

    public Double getStreetLevelLatitude() {
        return streetLevelLatitude;
    }

    public String getStreetLevelPlanimetricAccuracy() {
        return streetLevelPlanimetricAccuracy;
    }

    public String getStreetLevelBoundaryExtent() {
        return streetLevelBoundaryExtent;
    }

    public String getStreetLevelGeocodeReliabilityCode() {
        return streetLevelGeocodeReliabilityCode;
    }

    public String getStreetLevelGeocodeReliabilityDescription() {
        return streetLevelGeocodeReliabilityDescription;
    }

    public Double getLocalityLevelLongitude() {
        return localityLevelLongitude;
    }

    public Double getLocalityLevelLatitude() {
        return localityLevelLatitude;
    }

    public String getLocalityLevelPlanimetricAccuracy() {
        return localityLevelPlanimetricAccuracy;
    }

    public String getLocalityLevelGeocodeReliabilityCode() {
        return localityLevelGeocodeReliabilityCode;
    }

    public String getLocalityLevelGeocodeReliabilityDescription() {
        return localityLevelGeocodeReliabilityDescription;
    }

    public String getGnafLegalParcelIdentifier() {
        return gnafLegalParcelIdentifier;
    }

    public String getLocalityClassCode() {
        return localityClassCode;
    }
}
