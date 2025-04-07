using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Components
{
    public class AdditionalLocality
    {
        public AdditionalSubRegion? SubRegion { get; }

        public AdditionalLocality(RestApiAddressFormatComponents.RestApiAddressComponentAdditionalLocality api)
        {
            SubRegion = api.SubRegion != null ? new AdditionalSubRegion(api.SubRegion) : null;
        }
    }
}