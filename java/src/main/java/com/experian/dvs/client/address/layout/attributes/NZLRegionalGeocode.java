package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum NZLRegionalGeocode {

    FRONT_OF_PROPERTY_NZTM_X_COORDINATE("front_of_property_nztm_x_coordinate"),
    FRONT_OF_PROPERTY_NZTM_Y_COORDINATE("front_of_property_nztm_y_coordinate"),
    CENTROID_OF_PROPERTY_NZTM_X_COORDINATE("centroid_of_property_nztm_x_coordinate"),
    CENTROID_OF_PROPERTY_NZTM_Y_COORDINATE("centroid_of_property_nztm_y_coordinate"),
    LINZ_PARCEL_ID("linz_parcel_id"),
    PROPERTY_PURPOSE_TYPE("property_purpose_type"),
    ADDRESSABLE("addressable"),
    MESH_BLOCK_CODE("mesh_block_code"),
    TERRITORIAL_AUTHORITY_CODE("territorial_authority_code"),
    TERRITORIAL_AUTHORITY_NAME("territorial_authority_name"),
    REGIONAL_COUNCIL_CODE("regional_council_code"),
    REGIONAL_COUNCIL_NAME("regional_council_name"),
    GENERAL_ELECTORATE_CODE("general_electorate_code"),
    GENERAL_ELECTORATE_NAME("general_electorate_name"),
    MAORI_ELECTORATE_CODE("maori_electorate_code"),
    MAORI_ELECTORATE_NAME("maori_electorate_name"),
    FRONT_OF_PROPERTY_LATITUDE("front_of_property_latitude"),
    FRONT_OF_PROPERTY_LONGITUDE("front_of_property_longitude"),
    CENTROID_OF_PROPERTY_LATITUDE("centroid_of_property_latitude"),
    CENTROID_OF_PROPERTY_LONGITUDE("centroid_of_property_longitude"),
    MATCH_LEVEL("match_level");

    private final String value;
    // Map of value to NZLRegionalGeocode
    private static final Map<String, NZLRegionalGeocode> valueMap = Arrays.stream(NZLRegionalGeocode.values()).collect(Collectors.toMap(NZLRegionalGeocode::getValue, Function.identity()));

    public static NZLRegionalGeocode fromValue(final String value) {
        return valueMap.get(value);
    }

    NZLRegionalGeocode(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
