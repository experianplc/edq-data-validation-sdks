package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum AUSRegionalGeocode {

    LATITUDE("latitude"),
    LONGITUDE("longitude"),
    MATCH_LEVEL("match_level"),
    SA1("sa1"),
    MESH_BLOCK("meshblock"),
    LGA_CODE("lga_code"),
    LGA_NAME("lga_name"),
    STREET_PID("street_pid"),
    LOCALITY_PID("locality_pid"),
    GEOCODE_LEVEL_CODE("geocode_level_code"),
    GEOCODE_LEVEL_DESCRIPTION("geocode_level_description"),
    GEOCODE_TYPE_CODE("geocode_type_code"),
    GEOCODE_TYPE_DESCRIPTION("geocode_type_description"),
    HIGHEST_LEVEL_LONGITUDE("highest_level_longitude"),
    HIGHEST_LEVEL_LATITUDE("highest_level_latitude"),
    HIGHEST_LEVEL_ELEVATION("highest_level_elevation"),
    HIGHEST_LEVEL_PLANIMETRIC_ACCURACY("highest_level_planimetric_accuracy"),
    HIGHEST_LEVEL_BOUNDARY_EXTENT("highest_level_boundary_extent"),
    HIGHEST_LEVEL_GEOCODE_RELIABILITY_CODE("highest_level_geocode_reliability_code"),
    HIGHEST_LEVEL_GEOCODE_RELIABILITY_DESCRIPTION("highest_level_geocode_reliability_description"),
    CONFIDENCE_LEVEL_CODE("confidence_level_code"),
    CONFIDENCE_LEVEL_DESCRIPTION("confidence_level_description"),
    MESH_BLOCK_2021_ID("2021_meshblock_id"),
    MESH_BLOCK_2021_CODE("2021_meshblock_code"),
    MESH_BLOCK_2021_MATCH_CODE("2021_meshblock_match_code"),
    MESH_BLOCK_2021_MATCH_DESCRIPTION("2021_meshblock_match_description"),
    MESH_BLOCK_2016_ID("2016_meshblock_id"),
    MESH_BLOCK_2016_CODE("2016_meshblock_code"),
    MESH_BLOCK_2016_MATCH_CODE("2016_meshblock_match_code"),
    MESH_BLOCK_2016_MATCH_DESCRIPTION("2016_meshblock_match_description"),
    ADDRESS_TYPE_CODE("address_type_code"),
    PRIMARY_ADDRESS_PID("primary_address_pid"),
    ADDRESS_JOIN_TYPE("address_join_type"),
    COLLECTOR_DISTRICT_ID("collector_district_id"),
    COLLECTOR_DISTRICT_CODE("collector_district_code"),
    COMMONWEALTH_ELECTORAL_BOUNDARY_ID("commonwealth_electoral_boundary_id"),
    COMMONWEALTH_ELECTORAL_BOUNDARY_NAME("commonwealth_electoral_boundary_name"),
    STATISTICAL_LOCAL_AREA_ID("statistical_local_area_id"),
    STATISTICAL_LOCAL_AREA_CODE("statistical_local_area_code"),
    STATISTICAL_LOCAL_AREA_NAME("statistical_local_area_name"),
    STATE_ELECTORAL_BOUNDARY_ID("state_electoral_boundary_id"),
    STATE_ELECTORAL_BOUNDARY_NAME("state_electoral_boundary_name"),
    STATE_ELECTORAL_EFFECTIVE_START("state_electoral_effective_start"),
    STATE_ELECTORAL_EFFECTIVE_END("state_electoral_effective_end"),
    STATE_ELECTORAL_NEW_PID("state_electoral_new_pid"),
    STATE_ELECTORAL_NEW_NAME("state_electoral_new_name"),
    STATE_ELECTORAL_NEW_EFFECTIVE_START("state_electoral_new_effective_start"),
    STATE_ELECTORAL_NEW_EFFECTIVE_END("state_electoral_new_effective_end"),
    ADDRESS_LEVEL_LONGITUDE("address_level_longitude"),
    ADDRESS_LEVEL_LATITUDE("address_level_latitude"),
    ADDRESS_LEVEL_ELEVATION("address_level_elevation"),
    ADDRESS_LEVEL_PLANIMETRIC_ACCURACY("address_level_planimetric_accuracy"),
    ADDRESS_LEVEL_BOUNDARY_EXTENT("address_level_boundary_extent"),
    ADDRESS_LEVEL_GEOCODE_RELIABILITY_CODE("address_level_geocode_reliability_code"),
    ADDRESS_LEVEL_GEOCODE_RELIABILITY_DESCRIPTION("address_level_geocode_reliability_description"),
    STREET_LEVEL_LONGITUDE("street_level_longitude"),
    STREET_LEVEL_LATITUDE("street_level_latitude"),
    STREET_LEVEL_PLANIMETRIC_ACCURACY("street_level_planimetric_accuracy"),
    STREET_LEVEL_BOUNDARY_EXTENT("street_level_boundary_extent"),
    STREET_LEVEL_GEOCODE_RELIABILITY_CODE("street_level_geocode_reliability_code"),
    STREET_LEVEL_GEOCODE_RELIABILITY_DESCRIPTION("street_level_geocode_reliability_description"),
    LOCALITY_LEVEL_LONGITUDE("locality_level_longitude"),
    LOCALITY_LEVEL_LATITUDE("locality_level_latitude"),
    LOCALITY_LEVEL_PLANIMETRIC_ACCURACY("locality_level_planimetric_accuracy"),
    LOCALITY_LEVEL_GEOCODE_RELIABILITY_CODE("locality_level_geocode_reliability_code"),
    LOCALITY_LEVEL_GEOCODE_RELIABILITY_DESCRIPTION("locality_level_geocode_reliability_description"),
    GNAF_LEGAL_PARCEL_IDENTIFIER("gnaf_legal_parcel_identifier"),
    LOCALITY_CLASS_CODE("locality_class_code");

    private final String value;
    // Map of value to AUSRegionalGeocode
    private static final Map<String, AUSRegionalGeocode> valueMap = Arrays.stream(AUSRegionalGeocode.values()).collect(Collectors.toMap(AUSRegionalGeocode::getValue, Function.identity()));

    public static AUSRegionalGeocode fromValue(final String value) {
        return valueMap.get(value);
    }

    AUSRegionalGeocode(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
