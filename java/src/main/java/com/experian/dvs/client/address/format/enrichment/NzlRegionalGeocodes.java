package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.address.format.GeocodeMatchLevel;
import com.experian.dvs.client.server.address.format.RestApiEnrichmentNzlRegionalGeocodes;

import java.util.Objects;

public class NzlRegionalGeocodes {

    private final Double frontOfPropertyNztmXCoordinate;
    private final Double frontOfPropertyNztmYCoordinate;
    private final Double centroidOfPropertyNztmXCoordinate;
    private final Double centroidOfPropertyNztmYCoordinate;
    private final String linzParcelId;
    private final String propertyPurposeType;
    private final String addressable;
    private final String meshBlockCode;
    private final String territorialAuthorityCode;
    private final String territorialAuthorityName;
    private final String regionalCouncilCode;
    private final String regionalCouncilName;
    private final String generalElectorateCode;
    private final String generalElectorateName;
    private final String maoriElectorateCode;
    private final String maoriElectorateName;
    private final Double frontOfPropertyLatitude;
    private final Double frontOfPropertyLongitude;
    private final Double centroidOfPropertyLatitude;
    private final Double centroidOfPropertyLongitude;
    private final GeocodeMatchLevel matchLevel;

    public NzlRegionalGeocodes(RestApiEnrichmentNzlRegionalGeocodes geocodes) {
        this.frontOfPropertyNztmXCoordinate = geocodes.getFrontOfPropertyNztmXCoordinate();
        this.frontOfPropertyNztmYCoordinate = geocodes.getFrontOfPropertyNztmYCoordinate();
        this.centroidOfPropertyNztmXCoordinate = geocodes.getCentroidOfPropertyNztmXCoordinate();
        this.centroidOfPropertyNztmYCoordinate = geocodes.getCentroidOfPropertyNztmYCoordinate();
        this.linzParcelId = Objects.toString(geocodes.getLinzParcelId(), "");
        this.propertyPurposeType = Objects.toString(geocodes.getPropertyPurposeType(), "");
        this.addressable = Objects.toString(geocodes.getAddressable(), "");
        this.meshBlockCode = Objects.toString(geocodes.getMeshBlockCode(), "");
        this.territorialAuthorityCode = Objects.toString(geocodes.getTerritorialAuthorityCode(), "");
        this.territorialAuthorityName = Objects.toString(geocodes.getTerritorialAuthorityName(), "");
        this.regionalCouncilCode = Objects.toString(geocodes.getRegionalCouncilCode(), "");
        this.regionalCouncilName = Objects.toString(geocodes.getRegionalCouncilName(), "");
        this.generalElectorateCode = Objects.toString(geocodes.getGeneralElectorateCode(), "");
        this.generalElectorateName = Objects.toString(geocodes.getGeneralElectorateName(), "");
        this.maoriElectorateCode = Objects.toString(geocodes.getMaoriElectorateCode(), "");
        this.maoriElectorateName = Objects.toString(geocodes.getMaoriElectorateName(), "");
        this.frontOfPropertyLatitude = geocodes.getFrontOfPropertyLatitude();
        this.frontOfPropertyLongitude = geocodes.getFrontOfPropertyLongitude();
        this.centroidOfPropertyLatitude = geocodes.getCentroidOfPropertyLatitude();
        this.centroidOfPropertyLongitude = geocodes.getCentroidOfPropertyLongitude();
        this.matchLevel = geocodes.getMatchLevel() != null ? GeocodeMatchLevel.fromValue(geocodes.getMatchLevel()) : null;


    }

    public Double getFrontOfPropertyNztmXCoordinate() {
        return frontOfPropertyNztmXCoordinate;
    }

    public Double getFrontOfPropertyNztmYCoordinate() {
        return frontOfPropertyNztmYCoordinate;
    }

    public Double getCentroidOfPropertyNztmXCoordinate() {
        return centroidOfPropertyNztmXCoordinate;
    }

    public Double getCentroidOfPropertyNztmYCoordinate() {
        return centroidOfPropertyNztmYCoordinate;
    }

    public String getLinzParcelId() {
        return linzParcelId;
    }

    public String getPropertyPurposeType() {
        return propertyPurposeType;
    }

    public String getAddressable() {
        return addressable;
    }

    public String getMeshBlockCode() {
        return meshBlockCode;
    }

    public String getTerritorialAuthorityCode() {
        return territorialAuthorityCode;
    }

    public String getTerritorialAuthorityName() {
        return territorialAuthorityName;
    }

    public String getRegionalCouncilCode() {
        return regionalCouncilCode;
    }

    public String getRegionalCouncilName() {
        return regionalCouncilName;
    }

    public String getGeneralElectorateCode() {
        return generalElectorateCode;
    }

    public String getGeneralElectorateName() {
        return generalElectorateName;
    }

    public String getMaoriElectorateCode() {
        return maoriElectorateCode;
    }

    public String getMaoriElectorateName() {
        return maoriElectorateName;
    }

    public Double getFrontOfPropertyLatitude() {
        return frontOfPropertyLatitude;
    }

    public Double getFrontOfPropertyLongitude() {
        return frontOfPropertyLongitude;
    }

    public Double getCentroidOfPropertyLatitude() {
        return centroidOfPropertyLatitude;
    }

    public Double getCentroidOfPropertyLongitude() {
        return centroidOfPropertyLongitude;
    }

    public GeocodeMatchLevel getMatchLevel() {
        return matchLevel;
    }
}