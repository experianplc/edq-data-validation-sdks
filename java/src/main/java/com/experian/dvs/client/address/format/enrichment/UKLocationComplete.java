package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.address.format.GeocodeMatchLevel;
import com.experian.dvs.client.server.address.format.RestApiEnrichmentUKLocationComplete;

import java.util.Objects;

public class UKLocationComplete {

    private final Double latitude;
    private final Double longitude;
    private final GeocodeMatchLevel matchLevel;
    private final String udprn;
    private final String uprn;
    private final Double xCoordinate;
    private final Double yCoordinate;

    public UKLocationComplete(RestApiEnrichmentUKLocationComplete api) {
        this.latitude = api.getLatitude();
        this.longitude = api.getLongitude();
        this.matchLevel = api.getMatchLevel() != null ? GeocodeMatchLevel.fromValue(api.getMatchLevel()) : null;
        this.udprn = Objects.toString(api.getUdprn(), "");
        this.uprn = Objects.toString(api.getUprn(), "");
        this.xCoordinate = api.getXCoordinate();
        this.yCoordinate = api.getYCoordinate();
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

    public String getUdprn() {
        return udprn;
    }

    public String getUprn() {
        return uprn;
    }

    public Double getXCoordinate() {
        return xCoordinate;
    }

    public Double getYCoordinate() {
        return yCoordinate;
    }
}
