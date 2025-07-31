using DVSClient.Server.Address.Lookup;

namespace DVSClient.Address.Lookup
{
    public class LookupGasMeter
    {
        // Meter Point Reference Number
        public string? Mprn { get; }

        public string? RelAddressPrimaryName { get; }
        public string? RelAddressSecondaryName { get; }
        public string? RelAddressStreet1 { get; }
        public string? RelAddressStreet2 { get; }
        public string? RelAddressLocality1 { get; }
        public string? RelAddressLocality2 { get; }
        public string? RelAddressTown { get; }
        public string? RelAddressPostcode { get; }
        public string? RelAddressLogicalStatus { get; }
        public string? RelAddressLanguage { get; }
        public string? RelAddressOrganisation { get; }
        public string? RelAddressAddressType { get; }
        public double? RelAddressConfidenceScore { get; }
        public string? RelAddressClassification { get; }
        public double? RelAddressLatitude { get; }
        public double? RelAddressLongitude { get; }
        public string? MeterSerial { get; }
        public double? OfftakeQuantityAnnual { get; }
        public string? MeterPointStatus { get; }
        public string? InstallerId { get; }
        public string? NetworkName { get; }
        public string? SupplierName { get; }
        public string? LastMeterReadDate { get; }
        public string? LastMeterReadType { get; }
        public double? LastMeterReadValue { get; }

        public LookupGasMeter(RestApiAddressLookupGasMeter response) 
        {
            Mprn = response.Mprn ?? "";
            RelAddressPrimaryName = response.RelAddressPrimaryName ?? "";
            RelAddressSecondaryName = response.RelAddressSecondaryName ?? "";
            RelAddressStreet1 = response.RelAddressStreet1 ?? "";
            RelAddressStreet2 = response.RelAddressStreet2 ?? "";
            RelAddressLocality1 = response.RelAddressLocality1 ?? "";
            RelAddressLocality2 = response.RelAddressLocality2 ?? "";
            RelAddressTown = response.RelAddressTown ?? "";
            RelAddressPostcode = response.RelAddressPostcode ?? "";
            RelAddressLogicalStatus = response.RelAddressLogicalStatus ?? "";
            RelAddressLanguage = response.RelAddressLanguage ?? "";
            RelAddressOrganisation = response.RelAddressOrganisation ?? "";
            RelAddressAddressType = response.RelAddressAddressType ?? "";
            RelAddressConfidenceScore = response.RelAddressConfidenceScore ?? 0;
            RelAddressClassification = response.RelAddressClassification ?? "";
            RelAddressLatitude = response.RelAddressLatitude ?? 0;
            RelAddressLongitude = response.RelAddressLongitude ?? 0;
            MeterSerial = response.MeterSerial ?? "";
            OfftakeQuantityAnnual = response.OfftakeQuantityAnnual ?? 0;
            MeterPointStatus = response.MeterPointStatus ?? "";
            InstallerId = response.InstallerId ?? "";
            NetworkName = response.NetworkName ?? "";
            SupplierName = response.SupplierName ?? "";
            LastMeterReadDate = response.LastMeterReadDate ?? "";
            LastMeterReadType = response.LastMeterReadType ?? "";
            LastMeterReadValue = response.LastMeterReadValue ?? 0;
        }
    
    }
}