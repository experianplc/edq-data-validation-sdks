using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentNzlRegionalGeocodes
    {
        [JsonProperty("front_of_property_nztm_x_coordinate")]
        public double? FrontOfPropertyNztmXCoordinate { get; set; }

        [JsonProperty("front_of_property_nztm_y_coordinate")]
        public double? FrontOfPropertyNztmYCoordinate { get; set; }

        [JsonProperty("centroid_of_property_nztm_x_coordinate")]
        public double? CentroidOfPropertyNztmXCoordinate { get; set; }

        [JsonProperty("centroid_of_property_nztm_y_coordinate")]
        public double? CentroidOfPropertyNztmYCoordinate { get; set; }

        [JsonProperty("linz_parcel_id")]
        public string? LinzParcelId { get; set; }

        [JsonProperty("property_purpose_type")]
        public string? PropertyPurposeType { get; set; }

        [JsonProperty("addressable")]
        public string? Addressable { get; set; }

        [JsonProperty("mesh_block_code")]
        public string? MeshBlockCode { get; set; }

        [JsonProperty("territorial_authority_code")]
        public string? TerritorialAuthorityCode { get; set; }

        [JsonProperty("territorial_authority_name")]
        public string? TerritorialAuthorityName { get; set; }

        [JsonProperty("regional_council_code")]
        public string? RegionalCouncilCode { get; set; }

        [JsonProperty("regional_council_name")]
        public string? RegionalCouncilName { get; set; }

        [JsonProperty("general_electorate_code")]
        public string? GeneralElectorateCode { get; set; }

        [JsonProperty("general_electorate_name")]
        public string? GeneralElectorateName { get; set; }

        [JsonProperty("maori_electorate_code")]
        public string? MaoriElectorateCode { get; set; }

        [JsonProperty("maori_electorate_name")]
        public string? MaoriElectorateName { get; set; }

        [JsonProperty("front_of_property_latitude")]
        public double? FrontOfPropertyLatitude { get; set; }

        [JsonProperty("front_of_property_longitude")]
        public double? FrontOfPropertyLongitude { get; set; }

        [JsonProperty("centroid_of_property_latitude")]
        public double? CentroidOfPropertyLatitude { get; set; }

        [JsonProperty("centroid_of_property_longitude")]
        public double? CentroidOfPropertyLongitude { get; set; }

        [JsonProperty("match_level")]
        public string? MatchLevel { get; set; }
    }
}