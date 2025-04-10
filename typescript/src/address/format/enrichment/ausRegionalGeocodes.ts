import { RestApiEnrichmentAusRegionalGeocodes } from "../../../server/address/format/restApiEnrichmentAusRegionalGeocodes";
import { GeocodeMatchLevel, lookupGeocodeMatchLevel } from "../geocodeMatchLevel";

export type AusRegionalGeocodes = {
    latitude?: number;
    longitude?: number;
    matchLevel?: GeocodeMatchLevel;
    sa1: string;
    meshblock: string;
    lgaCode: string;
    lgaName: string;
    streetPid: string;
    localityPid: string;
    geocodeLevelCode: string;
    geocodeLevelDescription: string;
    geocodeTypeCode: string;
    geocodeTypeDescription: string;
    highestLevelLongitude?: number;
    highestLevelLatitude?: number;
    highestLevelElevation: string;
    highestLevelPlanimetricAccuracy: string;
    highestLevelBoundaryExtent: string;
    highestLevelGeocodeReliabilityCode: string;
    highestLevelGeocodeReliabilityDescription: string;
    confidenceLevelCode: string;
    confidenceLevelDescription: string;
    meshblockId2021: string;
    meshblockCode2021: string;
    meshblockMatchCode2021: string;
    meshblockMatchDescription2021: string;
    meshblockId2016: string;
    meshblockCode2016: string;
    meshblockMatchCode2016: string;
    meshblockMatchDescription2016: string;
    addressTypeCode: string;
    primaryAddressPid: string;
    addressJoinType: string;
    collectorDistrictId: string;
    collectorDistrictCode: string;
    commonwealthElectoralBoundaryId: string;
    commonwealthElectoralBoundaryName: string;
    statisticalLocalAreaId: string;
    statisticalLocalAreaCode: string;
    statisticalLocalAreaName: string;
    stateElectoralBoundaryId: string;
    stateElectoralBoundaryName: string;
    stateElectoralEffectiveStart: string;
    stateElectoralEffectiveEnd: string;
    stateElectoralNewPid: string;
    stateElectoralNewName: string;
    stateElectoralNewEffectiveStart: string;
    stateElectoralNewEffectiveEnd: string;
    addressLevelLongitude?: number;
    addressLevelLatitude?: number;
    addressLevelElevation: string;
    addressLevelPlanimetricAccuracy: string;
    addressLevelBoundaryExtent: string;
    addressLevelGeocodeReliabilityCode: string;
    addressLevelGeocodeReliabilityDescription: string;
    streetLevelLongitude?: number;
    streetLevelLatitude?: number;
    streetLevelPlanimetricAccuracy: string;
    streetLevelBoundaryExtent: string;
    streetLevelGeocodeReliabilityCode: string;
    streetLevelGeocodeReliabilityDescription: string;
    localityLevelLongitude?: number;
    localityLevelLatitude?: number;
    localityLevelPlanimetricAccuracy: string;
    localityLevelGeocodeReliabilityCode: string;
    localityLevelGeocodeReliabilityDescription: string;
    gnafLegalParcelIdentifier: string;
    localityClassCode: string;
};

export function restApiResponseToAusRegionalGeocodes(response: RestApiEnrichmentAusRegionalGeocodes): AusRegionalGeocodes {
    return {
        latitude: response.latitude,
        longitude: response.longitude,
        matchLevel: lookupGeocodeMatchLevel(response.match_level),
        sa1: response.sa1 ?? "",
        meshblock: response.meshblock ?? "",
        lgaCode: response.lga_code ?? "",
        lgaName: response.lga_name ?? "",
        streetPid: response.street_pid ?? "",
        localityPid: response.locality_pid ?? "",
        geocodeLevelCode: response.geocode_level_code ?? "",
        geocodeLevelDescription: response.geocode_level_description ?? "",
        geocodeTypeCode: response.geocode_type_code ?? "",
        geocodeTypeDescription: response.geocode_type_description ?? "",
        highestLevelLongitude: response.highest_level_longitude,
        highestLevelLatitude: response.highest_level_latitude,
        highestLevelElevation: response.highest_level_elevation ?? "",
        highestLevelPlanimetricAccuracy: response.highest_level_planimetric_accuracy ?? "",
        highestLevelBoundaryExtent: response.highest_level_boundary_extent ?? "",
        highestLevelGeocodeReliabilityCode: response.highest_level_geocode_reliability_code ?? "",
        highestLevelGeocodeReliabilityDescription: response.highest_level_geocode_reliability_description ?? "",
        confidenceLevelCode: response.confidence_level_code ?? "",
        confidenceLevelDescription: response.confidence_level_description ?? "",
        meshblockId2021: response.meshblock_id_2021 ?? "",
        meshblockCode2021: response.meshblock_code_2021 ?? "",
        meshblockMatchCode2021: response.meshblock_match_code_2021 ?? "",
        meshblockMatchDescription2021: response.meshblock_match_description_2021 ?? "",
        meshblockId2016: response.meshblock_id_2016 ?? "",
        meshblockCode2016: response.meshblock_code_2016 ?? "",
        meshblockMatchCode2016: response.meshblock_match_code_2016 ?? "",
        meshblockMatchDescription2016: response.meshblock_match_description_2016 ?? "",
        addressTypeCode: response.address_type_code ?? "",
        primaryAddressPid: response.primary_address_pid ?? "",
        addressJoinType: response.address_join_type ?? "",
        collectorDistrictId: response.collector_district_id ?? "",
        collectorDistrictCode: response.collector_district_code ?? "",
        commonwealthElectoralBoundaryId: response.commonwealth_electoral_boundary_id ?? "",
        commonwealthElectoralBoundaryName: response.commonwealth_electoral_boundary_name ?? "",
        statisticalLocalAreaId: response.statistical_local_area_id ?? "",
        statisticalLocalAreaCode: response.statistical_local_area_code ?? "",
        statisticalLocalAreaName: response.statistical_local_area_name ?? "",
        stateElectoralBoundaryId: response.state_electoral_boundary_id ?? "",
        stateElectoralBoundaryName: response.state_electoral_boundary_name ?? "",
        stateElectoralEffectiveStart: response.state_electoral_effective_start ?? "",
        stateElectoralEffectiveEnd: response.state_electoral_effective_end ?? "",
        stateElectoralNewPid: response.state_electoral_new_pid ?? "",
        stateElectoralNewName: response.state_electoral_new_name ?? "",
        stateElectoralNewEffectiveStart: response.state_electoral_new_effective_start ?? "",
        stateElectoralNewEffectiveEnd: response.state_electoral_new_effective_end ?? "",
        addressLevelLongitude: response.address_level_longitude,
        addressLevelLatitude: response.address_level_latitude,
        addressLevelElevation: response.address_level_elevation ?? "",
        addressLevelPlanimetricAccuracy: response.address_level_planimetric_accuracy ?? "",
        addressLevelBoundaryExtent: response.address_level_boundary_extent ?? "",
        addressLevelGeocodeReliabilityCode: response.address_level_geocode_reliability_code ?? "",
        addressLevelGeocodeReliabilityDescription: response.address_level_geocode_reliability_description ?? "",
        streetLevelLongitude: response.street_level_longitude,
        streetLevelLatitude: response.street_level_latitude,
        streetLevelPlanimetricAccuracy: response.street_level_planimetric_accuracy ?? "",
        streetLevelBoundaryExtent: response.street_level_boundary_extent ?? "",
        streetLevelGeocodeReliabilityCode: response.street_level_geocode_reliability_code ?? "",
        streetLevelGeocodeReliabilityDescription: response.street_level_geocode_reliability_description ?? "",
        localityLevelLongitude: response.locality_level_longitude,
        localityLevelLatitude: response.locality_level_latitude,
        localityLevelPlanimetricAccuracy: response.locality_level_planimetric_accuracy ?? "",
        localityLevelGeocodeReliabilityCode: response.locality_level_geocode_reliability_code ?? "",
        localityLevelGeocodeReliabilityDescription: response.locality_level_geocode_reliability_description ?? "",
        gnafLegalParcelIdentifier: response.gnaf_legal_parcel_identifier ?? "",
        localityClassCode: response.locality_class_code ?? ""
    };

}