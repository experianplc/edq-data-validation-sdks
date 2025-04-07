package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.address.format.GeocodeMatchLevel;
import com.experian.dvs.client.server.address.format.RestApiEnrichmentUsaRegionalGeocodes;

import java.util.Objects;

public class UsaRegionalGeocodes {

    private final Double latitude;

    private final Double longitude;

    private final GeocodeMatchLevel matchLevel;

    private final String censusTract;

    private final String censusBlock;

    private final String coreBasedStatisticalArea;

    private final String congressionalDistrictCode;

    private final String countyCode;

    public UsaRegionalGeocodes(final RestApiEnrichmentUsaRegionalGeocodes geocodes) {
        this.latitude = geocodes.getLatitude();
        this.longitude = geocodes.getLongitude();
        this.matchLevel = geocodes.getMatchLevel() != null ? GeocodeMatchLevel.fromValue(geocodes.getMatchLevel()) : null;
        this.censusTract = Objects.toString(geocodes.getCensusTract(), "");
        this.censusBlock = Objects.toString(geocodes.getCensusBlock(), "");
        this.coreBasedStatisticalArea = Objects.toString(geocodes.getCoreBasedStatisticalArea(), "");
        this.congressionalDistrictCode = Objects.toString(geocodes.getCongressionalDistrictCode(), "");
        this.countyCode = Objects.toString(geocodes.getCountyCode(), "");
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

    public String getCensusTract() {
        return censusTract;
    }

    public String getCensusBlock() {
        return censusBlock;
    }

    public String getCoreBasedStatisticalArea() {
        return coreBasedStatisticalArea;
    }

    public String getCongressionalDistrictCode() {
        return congressionalDistrictCode;
    }

    public String getCountyCode() {
        return countyCode;
    }
}
