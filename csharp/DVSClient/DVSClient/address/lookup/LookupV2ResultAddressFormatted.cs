using DVSClient.Server.Address.Lookup;

namespace DVSClient.Address.Lookup
{
    public class LookupV2ResultAddressFormatted
    {
        public string? LayoutName { get; }
        public LookupV2ResultAddressFormattedAddress? Address { get; }

        public LookupV2ResultAddressFormatted(RestApiAddressLookupV2ResultAddressFormatted response)
        {
            LayoutName = response.LayoutName;
            if (response.Address != null) {
                Address = new LookupV2ResultAddressFormattedAddress(response.Address);
            }
        }
    }

    public class LookupV2ResultAddressFormattedAddress
    {
        public IEnumerable<LookupElectricityMeter>? ElectricityMeters { get; }
        public IEnumerable<LookupGasMeter>? GasMeters { get; }

        public LookupV2ResultAddressFormattedAddress(RestApiAddressLookupV2ResultAddressFormatted.AddressDetails addressDetails)
        {
            ElectricityMeters = addressDetails.ElectricityMeters != null 
                ? addressDetails.ElectricityMeters.Select(em => new LookupElectricityMeter(em)).ToList() 
                : null;
            GasMeters = addressDetails.GasMeters != null 
                ? addressDetails.GasMeters.Select(gm => new LookupGasMeter(gm)).ToList() 
                : null;
        }
    }
}