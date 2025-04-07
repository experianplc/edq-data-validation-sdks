using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentAusRegionalGeocodes
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("match_level")]
        public string? MatchLevel { get; set; }

        [JsonProperty("sa1")]
        public string? Sa1 { get; set; }

        [JsonProperty("meshblock")]
        public string? Meshblock { get; set; }

        [JsonProperty("lga_code")]
        public string? LgaCode { get; set; }

        [JsonProperty("lga_name")]
        public string? LgaName { get; set; }

        [JsonProperty("street_pid")]
        public string? StreetPid { get; set; }

        [JsonProperty("locality_pid")]
        public string? LocalityPid { get; set; }

        [JsonProperty("geocode_level_code")]
        public string? GeocodeLevelCode { get; set; }

        [JsonProperty("geocode_level_description")]
        public string? GeocodeLevelDescription { get; set; }

        [JsonProperty("geocode_type_code")]
        public string? GeocodeTypeCode { get; set; }

        [JsonProperty("geocode_type_description")]
        public string? GeocodeTypeDescription { get; set; }

        [JsonProperty("highest_level_longitude")]
        public double? HighestLevelLongitude { get; set; }

        [JsonProperty("highest_level_latitude")]
        public double? HighestLevelLatitude { get; set; }

        [JsonProperty("highest_level_elevation")]
        public string? HighestLevelElevation { get; set; }

        [JsonProperty("highest_level_planimetric_accuracy")]
        public string? HighestLevelPlanimetricAccuracy { get; set; }

        [JsonProperty("highest_level_boundary_extent")]
        public string? HighestLevelBoundaryExtent { get; set; }

        [JsonProperty("highest_level_geocode_reliability_code")]
        public string? HighestLevelGeocodeReliabilityCode { get; set; }

        [JsonProperty("highest_level_geocode_reliability_description")]
        public string? HighestLevelGeocodeReliabilityDescription { get; set; }

        [JsonProperty("confidence_level_code")]
        public string? ConfidenceLevelCode { get; set; }

        [JsonProperty("confidence_level_description")]
        public string? ConfidenceLevelDescription { get; set; }

        [JsonProperty("2021_meshblock_id")]
        public string? MeshblockId2021 { get; set; }

        [JsonProperty("2021_meshblock_code")]
        public string? MeshblockCode2021 { get; set; }

        [JsonProperty("2021_meshblock_match_code")]
        public string? MeshblockMatchCode2021 { get; set; }

        [JsonProperty("2021_meshblock_match_description")]
        public string? MeshblockMatchDescription2021 { get; set; }

        [JsonProperty("2016_meshblock_id")]
        public string? MeshblockId2016 { get; set; }

        [JsonProperty("2016_meshblock_code")]
        public string? MeshblockCode2016 { get; set; }

        [JsonProperty("2016_meshblock_match_code")]
        public string? MeshblockMatchCode2016 { get; set; }

        [JsonProperty("2016_meshblock_match_description")]
        public string? MeshblockMatchDescription2016 { get; set; }

        [JsonProperty("address_type_code")]
        public string? AddressTypeCode { get; set; }

        [JsonProperty("primary_address_pid")]
        public string? PrimaryAddressPid { get; set; }

        [JsonProperty("address_join_type")]
        public string? AddressJoinType { get; set; }

        [JsonProperty("collector_district_id")]
        public string? CollectorDistrictId { get; set; }

        [JsonProperty("collector_district_code")]
        public string? CollectorDistrictCode { get; set; }

        [JsonProperty("commonwealth_electoral_boundary_id")]
        public string? CommonwealthElectoralBoundaryId { get; set; }

        [JsonProperty("commonwealth_electoral_boundary_name")]
        public string? CommonwealthElectoralBoundaryName { get; set; }

        [JsonProperty("statistical_local_area_id")]
        public string? StatisticalLocalAreaId { get; set; }

        [JsonProperty("statistical_local_area_code")]
        public string? StatisticalLocalAreaCode { get; set; }

        [JsonProperty("statistical_local_area_name")]
        public string? StatisticalLocalAreaName { get; set; }

        [JsonProperty("state_electoral_boundary_id")]
        public string? StateElectoralBoundaryId { get; set; }

        [JsonProperty("state_electoral_boundary_name")]
        public string? StateElectoralBoundaryName { get; set; }

        [JsonProperty("state_electoral_effective_start")]
        public string? StateElectoralEffectiveStart { get; set; }

        [JsonProperty("state_electoral_effective_end")]
        public string? StateElectoralEffectiveEnd { get; set; }

        [JsonProperty("state_electoral_new_pid")]
        public string? StateElectoralNewPid { get; set; }

        [JsonProperty("state_electoral_new_name")]
        public string? StateElectoralNewName { get; set; }

        [JsonProperty("state_electoral_new_effective_start")]
        public string? StateElectoralNewEffectiveStart { get; set; }

        [JsonProperty("state_electoral_new_effective_end")]
        public string? StateElectoralNewEffectiveEnd { get; set; }

        [JsonProperty("address_level_longitude")]
        public double? AddressLevelLongitude { get; set; }

        [JsonProperty("address_level_latitude")]
        public double? AddressLevelLatitude { get; set; }

        [JsonProperty("address_level_elevation")]
        public string? AddressLevelElevation { get; set; }

        [JsonProperty("address_level_planimetric_accuracy")]
        public string? AddressLevelPlanimetricAccuracy { get; set; }

        [JsonProperty("address_level_boundary_extent")]
        public string? AddressLevelBoundaryExtent { get; set; }

        [JsonProperty("address_level_geocode_reliability_code")]
        public string? AddressLevelGeocodeReliabilityCode { get; set; }

        [JsonProperty("address_level_geocode_reliability_description")]
        public string? AddressLevelGeocodeReliabilityDescription { get; set; }

        [JsonProperty("street_level_longitude")]
        public double? StreetLevelLongitude { get; set; }

        [JsonProperty("street_level_latitude")]
        public double? StreetLevelLatitude { get; set; }

        [JsonProperty("street_level_planimetric_accuracy")]
        public string? StreetLevelPlanimetricAccuracy { get; set; }

        [JsonProperty("street_level_boundary_extent")]
        public string? StreetLevelBoundaryExtent { get; set; }

        [JsonProperty("street_level_geocode_reliability_code")]
        public string? StreetLevelGeocodeReliabilityCode { get; set; }

        [JsonProperty("street_level_geocode_reliability_description")]
        public string? StreetLevelGeocodeReliabilityDescription { get; set; }

        [JsonProperty("locality_level_longitude")]
        public double? LocalityLevelLongitude { get; set; }

        [JsonProperty("locality_level_latitude")]
        public double? LocalityLevelLatitude { get; set; }

        [JsonProperty("locality_level_planimetric_accuracy")]
        public string? LocalityLevelPlanimetricAccuracy { get; set; }

        [JsonProperty("locality_level_geocode_reliability_code")]
        public string? LocalityLevelGeocodeReliabilityCode { get; set; }

        [JsonProperty("locality_level_geocode_reliability_description")]
        public string? LocalityLevelGeocodeReliabilityDescription { get; set; }

        [JsonProperty("gnaf_legal_parcel_identifier")]
        public string? GnafLegalParcelIdentifier { get; set; }

        [JsonProperty("locality_class_code")]
        public string? LocalityClassCode { get; set; }
    }
}