using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum AusRegionalGeocodeAttribute
    {
        [EnumStringValue("latitude")]
        Latitude,
        [EnumStringValue("longitude")]
        Longitude,
        [EnumStringValue("match_level")]
        MatchLevel,
        [EnumStringValue("sa1")]
        Sa1,
        [EnumStringValue("meshblock")]
        MeshBlock,
        [EnumStringValue("lga_code")]
        LgaCode,
        [EnumStringValue("lga_name")]
        LgaName,
        [EnumStringValue("street_pid")]
        StreetPid,
        [EnumStringValue("locality_pid")]
        LocalityPid,
        [EnumStringValue("geocode_level_code")]
        GeocodeLevelCode,
        [EnumStringValue("geocode_level_description")]
        GeocodeLevelDescription,
        [EnumStringValue("geocode_type_code")]
        GeocodeTypeCode,
        [EnumStringValue("geocode_type_description")]
        GeocodeTypeDescription,
        [EnumStringValue("highest_level_longitude")]
        HighestLevelLongitude,
        [EnumStringValue("highest_level_latitude")]
        HighestLevelLatitude,
        [EnumStringValue("highest_level_elevation")]
        HighestLevelElevation,
        [EnumStringValue("highest_level_planimetric_accuracy")]
        HighestLevelPlanimetricAccuracy,
        [EnumStringValue("highest_level_boundary_extent")]
        HighestLevelBoundaryExtent,
        [EnumStringValue("highest_level_geocode_reliability_code")]
        HighestLevelGeocodeReliabilityCode,
        [EnumStringValue("highest_level_geocode_reliability_description")]
        HighestLevelGeocodeReliabilityDescription,
        [EnumStringValue("confidence_level_code")]
        ConfidenceLevelCode,
        [EnumStringValue("confidence_level_description")]
        ConfidenceLevelDescription,
        [EnumStringValue("2021_meshblock_id")]
        MeshBlock2021Id,
        [EnumStringValue("2021_meshblock_code")]
        MeshBlock2021Code,
        [EnumStringValue("2021_meshblock_match_code")]
        MeshBlock2021MatchCode,
        [EnumStringValue("2021_meshblock_match_description")]
        MeshBlock2021MatchDescription,
        [EnumStringValue("2016_meshblock_id")]
        MeshBlock2016Id,
        [EnumStringValue("2016_meshblock_code")]
        MeshBlock2016Code,
        [EnumStringValue("2016_meshblock_match_code")]
        MeshBlock2016MatchCode,
        [EnumStringValue("2016_meshblock_match_description")]
        MeshBlock2016MatchDescription,
        [EnumStringValue("address_type_code")]
        AddressTypeCode,
        [EnumStringValue("primary_address_pid")]
        PrimaryAddressPid,
        [EnumStringValue("address_join_type")]
        AddressJoinType,
        [EnumStringValue("collector_district_id")]
        CollectorDistrictId,
        [EnumStringValue("collector_district_code")]
        CollectorDistrictCode,
        [EnumStringValue("commonwealth_electoral_boundary_id")]
        CommonwealthElectoralBoundaryId,
        [EnumStringValue("commonwealth_electoral_boundary_name")]
        CommonwealthElectoralBoundaryName,
        [EnumStringValue("statistical_local_area_id")]
        StatisticalLocalAreaId,
        [EnumStringValue("statistical_local_area_code")]
        StatisticalLocalAreaCode,
        [EnumStringValue("statistical_local_area_name")]
        StatisticalLocalAreaName,
        [EnumStringValue("state_electoral_boundary_id")]
        StateElectoralBoundaryId,
        [EnumStringValue("state_electoral_boundary_name")]
        StateElectoralBoundaryName,
        [EnumStringValue("state_electoral_effective_start")]
        StateElectoralEffectiveStart,
        [EnumStringValue("state_electoral_effective_end")]
        StateElectoralEffectiveEnd,
        [EnumStringValue("state_electoral_new_pid")]
        StateElectoralNewPid,
        [EnumStringValue("state_electoral_new_name")]
        StateElectoralNewName,
        [EnumStringValue("state_electoral_new_effective_start")]
        StateElectoralNewEffectiveStart,
        [EnumStringValue("state_electoral_new_effective_end")]
        StateElectoralNewEffectiveEnd,
        [EnumStringValue("address_level_longitude")]
        AddressLevelLongitude,
        [EnumStringValue("address_level_latitude")]
        AddressLevelLatitude,
        [EnumStringValue("address_level_elevation")]
        AddressLevelElevation,
        [EnumStringValue("address_level_planimetric_accuracy")]
        AddressLevelPlanimetricAccuracy,
        [EnumStringValue("address_level_boundary_extent")]
        AddressLevelBoundaryExtent,
        [EnumStringValue("address_level_geocode_reliability_code")]
        AddressLevelGeocodeReliabilityCode,
        [EnumStringValue("address_level_geocode_reliability_description")]
        AddressLevelGeocodeReliabilityDescription,
        [EnumStringValue("street_level_longitude")]
        StreetLevelLongitude,
        [EnumStringValue("street_level_latitude")]
        StreetLevelLatitude,
        [EnumStringValue("street_level_planimetric_accuracy")]
        StreetLevelPlanimetricAccuracy,
        [EnumStringValue("street_level_boundary_extent")]
        StreetLevelBoundaryExtent,
        [EnumStringValue("street_level_geocode_reliability_code")]
        StreetLevelGeocodeReliabilityCode,
        [EnumStringValue("street_level_geocode_reliability_description")]
        StreetLevelGeocodeReliabilityDescription,
        [EnumStringValue("locality_level_longitude")]
        LocalityLevelLongitude,
        [EnumStringValue("locality_level_latitude")]
        LocalityLevelLatitude,
        [EnumStringValue("locality_level_planimetric_accuracy")]
        LocalityLevelPlanimetricAccuracy,
        [EnumStringValue("locality_level_geocode_reliability_code")]
        LocalityLevelGeocodeReliabilityCode,
        [EnumStringValue("locality_level_geocode_reliability_description")]
        LocalityLevelGeocodeReliabilityDescription,
        [EnumStringValue("gnaf_legal_parcel_identifier")]
        GnafLegalParcelIdentifier,
        [EnumStringValue("locality_class_code")]
        LocalityClassCode
    }
}