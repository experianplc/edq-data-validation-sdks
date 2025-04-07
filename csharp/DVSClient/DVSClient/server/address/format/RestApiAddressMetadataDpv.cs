using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressMetadataDpv
    {
        [JsonProperty("cmra_indicator")]
        public string? CmraIndicator { get; set; }

        [JsonProperty("seed_indicator")]
        public string? SeedIndicator { get; set; }

        [JsonProperty("dpv_indicator")]
        public string? DpvIndicator { get; set; }

        [JsonProperty("footnotes")]
        public string? Footnotes { get; set; }

        [JsonProperty("vacancy_indicator")]
        public string? VacancyIndicator { get; set; }

        [JsonProperty("no_stats_indicator")]
        public string? NoStatsIndicator { get; set; }

        [JsonProperty("pbsa_indicator")]
        public string? PbsaIndicator { get; set; }

        [JsonProperty("lacs_indicator")]
        public string? LacsIndicator { get; set; }

        [JsonProperty("lacs_code")]
        public string? LacsCode { get; set; }

        [JsonProperty("urbanization")]
        public string? Urbanization { get; set; }

        [JsonProperty("delivery_line_1")]
        public string? DeliveryLine1 { get; set; }

        [JsonProperty("delivery_line_2")]
        public string? DeliveryLine2 { get; set; }

        [JsonProperty("last_line")]
        public string? LastLine { get; set; }

        [JsonProperty("no_stat_reason_code")]
        public string? NoStatReasonCode { get; set; }

        [JsonProperty("drop")]
        public string? Drop { get; set; }

        [JsonProperty("throwback")]
        public string? Throwback { get; set; }

        [JsonProperty("non_delivery_days_indicator")]
        public string? NonDeliveryDaysIndicator { get; set; }

        [JsonProperty("non_delivery_days_value")]
        public string? NonDeliveryDaysValue { get; set; }

        [JsonProperty("no_secure_location")]
        public string? NoSecureLocation { get; set; }

        [JsonProperty("door_not_accessible")]
        public string? DoorNotAccessible { get; set; }

        [JsonProperty("enhanced_dpv_code")]
        public string? EnhancedDpvCode { get; set; }

        [JsonProperty("firm_name")]
        public string? FirmName { get; set; }
    }
}