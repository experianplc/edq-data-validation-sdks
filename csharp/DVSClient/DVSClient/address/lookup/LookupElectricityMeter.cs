using DVSClient.Server.Address.Lookup;

namespace DVSClient.Address.Lookup
{
    public class LookupElectricityMeter
    {
        public string Mpan { get; } // Meter Point Administration Number
        public string AddressLine1 { get; } // Metering Point address line 1
        public string AddressLine2 { get; } // Metering Point address line 2
        public string AddressLine3 { get; } // Metering Point address line 3
        public string AddressLine4 { get; } // Metering Point address line 4
        public string AddressLine5 { get; } // Metering Point address line 5
        public string AddressLine6 { get; } // Metering Point address line 6
        public string AddressLine7 { get; } // Metering Point address line 7
        public string AddressLine8 { get; } // Metering Point address line 8
        public string AddressLine9 { get; } // Metering Point address line 9
        public string AddressPostalCode { get; } // Metering Point postcode
        public string TradingStatus { get; } // MPAN trading status
        public string TradingStatusEfd { get; } // MPAN trading status effective from date
        public string ProfileClass { get; } // Profile Class
        public string ProfileClassEfd { get; } // Profile Class effective from date
        public string MeterTimeswitchClass { get; } // Meter Time-switch Class
        public string MeterTimeswitchClassEfd { get; } // Meter Time-switch Class effective from date
        public string LineLossFactor { get; } // Line Loss Factor Class
        public string LineLossFactorEfd { get; } // Line Loss Factor Class effective from date
        public string StandardSettlementConfiguration { get; } // Standard Settlement Configuration
        public string StandardSettlementConfigurationEfd { get; } // Standard Settlement Configuration effective from date
        public string EnergisationStatus { get; } // Energisation status
        public string EnergisationStatusEfd { get; } // Energisation status effective from date
        public string GspGroupId { get; } // Grid Supply Point Group Id
        public string GspGroupEfd { get; } // Grid Supply Point Group effective from date
        public string DataAggregatorMpid { get; } // Data Aggregator MPID
        public string DataAggregatorEfd { get; } // Data Aggregator appointment effective from date
        public string DataCollectorMpid { get; } // Data Collector MPID
        public string DataCollectorEfd { get; } // Data Collector appointment effective from date
        public string SupplierMpid { get; } // Supplier MPID
        public string SupplierEfd { get; } // Effective from date of the current supplier
        public string MeterOperatorMpid { get; } // Meter Operator MPID
        public string MeterOperatorEfd { get; } // Meter Operator appointment effective from date
        public string MeasurementClass { get; } // Measurement Class
        public string MeasurementClassEfd { get; } // Measurement Class effective from date
        public bool? GreenDealInEffect { get; } // An indicator whether Green Deal is currently active for this MPAN
        public string SmsoMpid { get; } // Smart Metering System Operator MPID
        public string SmsoEfd { get; } // Smart Metering System Operator effective from date
        public bool? DccServiceFlag { get; } // Data Communications Company Service Flag
        public string DccServiceFlagEfd { get; } // Data Communications Company Service Flag effective from date
        public string IhdStatus { get; } // In Home Display Install status
        public string IhdStatusEfd { get; } // In Home Display Install status effective from date
        public string SmetsVersion { get; } // Smart Metering Equipment Technical Specification version
        public string DistributorMpid { get; } // Distributor MPID
        public bool? MeteredIndicator { get; } // Metered Indicator
        public string MeteredIndicatorEfd { get; } // Metered Indicator effective from date
        public string MeteredIndicatorEtd { get; } // Metered Indicator effective to date
        public string ConsumerType { get; } // Consumer Type
        public string RelationshipStatusIndicator { get; } // Relationship Status Indicator
        public string RmpState { get; } // RMP State
        public string RmpEfd { get; } // RMP State effective from date
        public bool? DomesticConsumerIndicator { get; } // Domestic Consumer Indicator as supplied via CSS messages
        public string CssSupplierMpid { get; } // Current supplier as supplied via CSS messages
        public string CssSupplyStartDate { get; } // Current supply start date as supplier via CSS messages
        public string MeterSerialNumber { get; } // Meter Serial Number
        public string MeterInstallDate { get; } // Meter Install Date
        public string MeterType { get; } // Meter Type
        public string MapMpid { get; } // Meter Asset Provider MPID
        public string MapMpidEfd { get; } // Meter Asset Provider effective from date
        public string InstallingSupplierMpid { get; } // Installing Supplier MPID

        public LookupElectricityMeter(RestApiAddressLookupElectricityMeter response)
        {
            Mpan = response.Mpan ?? "";
            AddressLine1 = response.AddressLine1 ?? "";
            AddressLine2 = response.AddressLine2 ?? "";
            AddressLine3 = response.AddressLine3 ?? "";
            AddressLine4 = response.AddressLine4 ?? "";
            AddressLine5 = response.AddressLine5 ?? "";
            AddressLine6 = response.AddressLine6 ?? "";
            AddressLine7 = response.AddressLine7 ?? "";
            AddressLine8 = response.AddressLine8 ?? "";
            AddressLine9 = response.AddressLine9 ?? "";
            AddressPostalCode = response.AddressPostalCode ?? "";
            TradingStatus = response.TradingStatus ?? "";
            TradingStatusEfd = response.TradingStatusEfd ?? "";
            ProfileClass = response.ProfileClass ?? "";
            ProfileClassEfd = response.ProfileClassEfd ?? "";
            MeterTimeswitchClass = response.MeterTimeswitchClass ?? "";
            MeterTimeswitchClassEfd = response.MeterTimeswitchClassEfd ?? "";
            LineLossFactor = response.LineLossFactor ?? "";
            LineLossFactorEfd = response.LineLossFactorEfd ?? "";
            StandardSettlementConfiguration = response.StandardSettlementConfiguration ?? "";
            StandardSettlementConfigurationEfd = response.StandardSettlementConfigurationEfd ?? "";
            EnergisationStatus = response.EnergisationStatus ?? "";
            EnergisationStatusEfd = response.EnergisationStatusEfd ?? "";
            GspGroupId = response.GspGroupId ?? "";
            GspGroupEfd = response.GspGroupEfd ?? "";
            DataAggregatorMpid = response.DataAggregatorMpid ?? "";
            DataAggregatorEfd = response.DataAggregatorEfd ?? "";
            DataCollectorMpid = response.DataCollectorMpid ?? "";
            DataCollectorEfd = response.DataCollectorEfd ?? "";
            SupplierMpid = response.SupplierMpid ?? "";
            SupplierEfd = response.SupplierEfd ?? "";
            MeterOperatorMpid = response.MeterOperatorMpid ?? "";
            MeterOperatorEfd = response.MeterOperatorEfd ?? "";
            MeasurementClass = response.MeasurementClass ?? "";
            MeasurementClassEfd = response.MeasurementClassEfd ?? "";
            GreenDealInEffect = response.GreenDealInEffect;
            SmsoMpid = response.SmsoMpid ?? "";
            SmsoEfd = response.SmsoEfd ?? "";
            DccServiceFlag = response.DccServiceFlag;
            DccServiceFlagEfd = response.DccServiceFlagEfd ?? "";
            IhdStatus = response.IhdStatus ?? "";
            IhdStatusEfd = response.IhdStatusEfd ?? "";
            SmetsVersion = response.SmetsVersion ?? "";
            DistributorMpid = response.DistributorMpid ?? "";
            MeteredIndicator = response.MeteredIndicator;
            MeteredIndicatorEfd = response.MeteredIndicatorEfd ?? "";
            MeteredIndicatorEtd = response.MeteredIndicatorEtd ?? "";
            ConsumerType = response.ConsumerType ?? "";
            RelationshipStatusIndicator = response.RelationshipStatusIndicator ?? "";
            RmpState = response.RmpState ?? "";
            RmpEfd = response.RmpEfd ?? "";
            DomesticConsumerIndicator = response.DomesticConsumerIndicator;
            CssSupplierMpid = response.CssSupplierMpid ?? "";
            CssSupplyStartDate = response.CssSupplyStartDate ?? "";
            MeterSerialNumber = response.MeterSerialNumber ?? "";
            MeterInstallDate = response.MeterInstallDate ?? "";
            MeterType = response.MeterType ?? "";
            MapMpid = response.MapMpid ?? "";
            MapMpidEfd = response.MapMpidEfd ?? "";
            InstallingSupplierMpid = response.InstallingSupplierMpid ?? "";
        }
    }
}