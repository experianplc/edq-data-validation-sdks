using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupElectricityMeter
    {
        
        [JsonProperty("mpan")]
        public string? Mpan { get; set; } // Meter Point Administration Number

        [JsonProperty("address_line_1")]
        public string? AddressLine1 { get; set; } // Metering Point address line 1

        [JsonProperty("address_line_2")]
        public string? AddressLine2 { get; set; } // Metering Point address line 2

        [JsonProperty("address_line_3")]
        public string? AddressLine3 { get; set; } // Metering Point address line 3

        [JsonProperty("address_line_4")]
        public string? AddressLine4 { get; set; } // Metering Point address line 4

        [JsonProperty("address_line_5")]
        public string? AddressLine5 { get; set; } // Metering Point address line 5

        [JsonProperty("address_line_6")]
        public string? AddressLine6 { get; set; } // Metering Point address line 6

        [JsonProperty("address_line_7")]
        public string? AddressLine7 { get; set; } // Metering Point address line 7

        [JsonProperty("address_line_8")]
        public string? AddressLine8 { get; set; } // Metering Point address line 8

        [JsonProperty("address_line_9")]
        public string? AddressLine9 { get; set; } // Metering Point address line 9

        [JsonProperty("address_postal_code")]
        public string? AddressPostalCode { get; set; } // Metering Point postcode

        [JsonProperty("trading_status")]
        public string? TradingStatus { get; set; } // MPAN trading status

        [JsonProperty("trading_status_efd")]
        public string? TradingStatusEfd { get; set; } // MPAN trading status effective from date

        [JsonProperty("profile_class")]
        public string? ProfileClass { get; set; } // Profile Class

        [JsonProperty("profile_class_efd")]
        public string? ProfileClassEfd { get; set; } // Profile Class effective from date

        [JsonProperty("meter_timeswitch_class")]
        public string? MeterTimeswitchClass { get; set; } // Meter Time-switch Class

        [JsonProperty("meter_timeswitch_class_efd")]
        public string? MeterTimeswitchClassEfd { get; set; } // Meter Time-switch Class effective from date

        [JsonProperty("line_loss_factor")]
        public string? LineLossFactor { get; set; } // Line Loss Factor Class

        [JsonProperty("line_loss_factor_efd")]
        public string? LineLossFactorEfd { get; set; } // Line Loss Factor Class effective from date

        [JsonProperty("standard_settlement_configuration")]
        public string? StandardSettlementConfiguration { get; set; } // Standard Settlement Configuration

        [JsonProperty("standard_settlement_configuration_efd")]
        public string? StandardSettlementConfigurationEfd { get; set; } // Standard Settlement Configuration effective from date

        [JsonProperty("energisation_status")]
        public string? EnergisationStatus { get; set; } // Energisation status

        [JsonProperty("energisation_status_efd")]
        public string? EnergisationStatusEfd { get; set; } // Energisation status effective from date

        [JsonProperty("gsp_group_id")]
        public string? GspGroupId { get; set; } // Grid Supply Point Group Id

        [JsonProperty("gsp_group_efd")]
        public string? GspGroupEfd { get; set; } // Grid Supply Point Group effective from date

        [JsonProperty("data_aggregator_mpid")]
        public string? DataAggregatorMpid { get; set; } // Data Aggregator MPID

        [JsonProperty("data_aggregator_efd")]
        public string? DataAggregatorEfd { get; set; } // Data Aggregator appointment effective from date

        [JsonProperty("data_collector_mpid")]
        public string? DataCollectorMpid { get; set; } // Data Collector MPID

        [JsonProperty("data_collector_efd")]
        public string? DataCollectorEfd { get; set; } // Data Collector appointment effective from date

        [JsonProperty("supplier_mpid")]
        public string? SupplierMpid { get; set; } // Supplier MPID

        [JsonProperty("supplier_efd")]
        public string? SupplierEfd { get; set; } // Effective from date of the current supplier

        [JsonProperty("meter_operator_mpid")]
        public string? MeterOperatorMpid { get; set; } // Meter Operator MPID

        [JsonProperty("meter_operator_efd")]
        public string? MeterOperatorEfd { get; set; } // Meter Operator appointment effective from date

        [JsonProperty("measurement_class")]
        public string? MeasurementClass { get; set; } // Measurement Class

        [JsonProperty("measurement_class_efd")]
        public string? MeasurementClassEfd { get; set; } // Measurement Class effective from date

        [JsonProperty("green_deal_in_effect")]
        public bool? GreenDealInEffect { get; set; } // An indicator whether Green Deal is currently active for this MPAN

        [JsonProperty("smso_mpid")]
        public string? SmsoMpid { get; set; } // Smart Metering System Operator MPID

        [JsonProperty("smso_efd")]
        public string? SmsoEfd { get; set; } // Smart Metering System Operator effective from date

        [JsonProperty("dcc_service_flag")]
        public bool? DccServiceFlag { get; set; } // Data Communications Company Service Flag

        [JsonProperty("dcc_service_flag_efd")]
        public string? DccServiceFlagEfd { get; set; } // Data Communications Company Service Flag effective from date

        [JsonProperty("ihd_status")]
        public string? IhdStatus { get; set; } // In Home Display Install status

        [JsonProperty("ihd_status_efd")]
        public string? IhdStatusEfd { get; set; } // In Home Display Install status effective from date

        [JsonProperty("smets_version")]
        public string? SmetsVersion { get; set; } // Smart Metering Equipment Technical Specification version

        [JsonProperty("distributor_mpid")]
        public string? DistributorMpid { get; set; } // Distributor MPID
        [JsonProperty("metered_indicator")]
        public bool? MeteredIndicator { get; set; } // Metered Indicator

        [JsonProperty("metered_indicator_efd")]
        public string? MeteredIndicatorEfd { get; set; } // Metered Indicator effective from date
        [JsonProperty("metered_indicator_etd")]
        public string? MeteredIndicatorEtd { get; set; } // Metered Indicator effective to date

        [JsonProperty("consumer_type")]
        public string? ConsumerType { get; set; } // Consumer Type

        [JsonProperty("relationship_status_indicator")]
        public string? RelationshipStatusIndicator { get; set; } // Relationship Status Indicator

        [JsonProperty("rmp_state")]
        public string? RmpState { get; set; } // RMP State

        [JsonProperty("rmp_efd")]
        public string? RmpEfd { get; set; } // RMP State effective from date

        [JsonProperty("domestic_consumer_indicator")]
        public bool? DomesticConsumerIndicator { get; set; } // Domestic Consumer Indicator as supplied via CSS messages

        [JsonProperty("css_supplier_mpid")]
        public string? CssSupplierMpid { get; set; } // Current supplier as supplied via CSS messages

        [JsonProperty("css_supply_start_date")]
        public string? CssSupplyStartDate { get; set; } // Current supply start date as supplier via CSS messages

        [JsonProperty("meter_serial_number")]
        public string? MeterSerialNumber { get; set; } // Meter Serial Number

        [JsonProperty("meter_install_date")]
        public string? MeterInstallDate { get; set; } // Meter Install Date

        [JsonProperty("meter_type")]
        public string? MeterType { get; set; } // Meter Type

        [JsonProperty("map_mpid")]
        public string? MapMpid { get; set; } // Meter Asset Provider MPID

        [JsonProperty("map_mpid_efd")]
        public string? MapMpidEfd { get; set; } // Meter Asset Provider effective from date

        [JsonProperty("installing_supplier_mpid")]
        public string? InstallingSupplierMpid { get; set; } // Installing Supplier MPID

    }
}