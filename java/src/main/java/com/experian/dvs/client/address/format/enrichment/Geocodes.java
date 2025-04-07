package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.address.format.GeocodeMatchLevel;
import com.experian.dvs.client.server.address.format.RestApiEnrichmentDatasetGeocodes;

public class Geocodes {

    private final Double latitude;
    private final Double longitude;
    private final GeocodeMatchLevel matchLevel;

    public Geocodes(final RestApiEnrichmentDatasetGeocodes geocodes) {
        this.latitude = geocodes.getLatitude();
        this.longitude = geocodes.getLongitude();
        this.matchLevel = geocodes.getMatchLevel() != null ? GeocodeMatchLevel.fromValue(geocodes.getMatchLevel()) : null;
    }

    public GeocodeMatchLevel getMatchLevel() {
        return matchLevel;
    }

    public Double getLongitude() {
        return longitude;
    }

    public Double getLatitude() {
        return latitude;
    }
}
