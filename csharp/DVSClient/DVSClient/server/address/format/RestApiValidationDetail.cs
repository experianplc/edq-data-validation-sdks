using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiValidationDetail
    {
        [JsonProperty("building_firm_name_corrected")]
        public bool? BuildingFirmNameCorrected { get; set; }

        [JsonProperty("primary_number_corrected")]
        public bool? PrimaryNumberCorrected { get; set; }

        [JsonProperty("street_corrected")]
        public bool? StreetCorrected { get; set; }

        [JsonProperty("rural_route_highway_contract_matched")]
        public bool? RuralRouteHighwayContractMatched { get; set; }

        [JsonProperty("city_name_corrected")]
        public bool? CityNameCorrected { get; set; }

        [JsonProperty("city_name_alias_matched")]
        public bool? CityNameAliasMatched { get; set; }

        [JsonProperty("state_corrected")]
        public bool? StateCorrected { get; set; }

        [JsonProperty("zip_code_corrected")]
        public bool? ZipCodeCorrected { get; set; }

        [JsonProperty("secondary_num_retained")]
        public bool? SecondaryNumRetained { get; set; }

        [JsonProperty("iden_pre_st_info_retained")]
        public bool? IdenPreStInfoRetained { get; set; }

        [JsonProperty("gen_pre_st_info_retained")]
        public bool? GenPreStInfoRetained { get; set; }

        [JsonProperty("post_st_info_retained")]
        public bool? PostStInfoRetained { get; set; }
    }
}