using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Components
{
    public class AdditionalElements
    {
        public AdditionalLocality? Locality { get; }

        public AdditionalElements(RestApiAddressFormatComponents.RestApiAddressComponentAdditionalElements api)
        {
            Locality = api.Locality != null ? new AdditionalLocality(api.Locality) : null;
        }
    }
}