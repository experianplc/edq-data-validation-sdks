package com.experian.dvs.client.address.format;

import java.util.HashMap;
import java.util.Map;

public enum GeocodeMatchLevel {

    BUILDING("building"),
    POSTAL_CODE("postal_code"),
    DISTRICT("district"),
    CITY("city"),
    COUNTY("county"),
    STATE("state"),
    COUNTRY("country"),
    STREET("street"),
    PLACE("place"),
    ADDRESS_BLOCK("addressBlock"),
    INTERSECTION("intersection"),
    LOCALITY("locality")
    ;

    private final String value;
    // Map of level to GeocodeMatchLevel
    private static final Map<String, GeocodeMatchLevel> levelToGeocodeMatchLevel = new HashMap<>();
    static {
        for (GeocodeMatchLevel geocodeMatchLevel : GeocodeMatchLevel.values()) {
            levelToGeocodeMatchLevel.put(geocodeMatchLevel.value, geocodeMatchLevel);
        }
    }

    GeocodeMatchLevel(final String level) {
        this.value = level;
    }

    public String getValue() {
        return value;
    }

    public static GeocodeMatchLevel fromValue(final String level) {
        return levelToGeocodeMatchLevel.get(level);
    }
}
