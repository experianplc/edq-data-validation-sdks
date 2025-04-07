using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Components
{
    public class AdditionalSubRegion
    {
        public string AdministrativeCounty { get; }
        public string FormerPostalCounty { get; }
        public string TraditionalCounty { get; }

        public AdditionalSubRegion(RestApiAddressFormatComponents.RestApiAddressComponentAdditionalSubRegion api)
        {
            AdministrativeCounty = api.AdministrativeCounty ?? string.Empty;
            FormerPostalCounty = api.FormerPostalCounty ?? string.Empty;
            TraditionalCounty = api.TraditionalCounty ?? string.Empty;
        }
    }
}