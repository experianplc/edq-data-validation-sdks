using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class FormatAddress
    {
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string AddressLine3 { get; }
        public string Locality { get; }
        public string Region { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public FormatAddress(RestApiFormatAddress apiAddress)
        {
            AddressLine1 = apiAddress.AddressLine1 ?? string.Empty;
            AddressLine2 = apiAddress.AddressLine2 ?? string.Empty;
            AddressLine3 = apiAddress.AddressLine3 ?? string.Empty;
            Locality = apiAddress.Locality ?? string.Empty;
            Region = apiAddress.Region ?? string.Empty;
            PostalCode = apiAddress.PostalCode ?? string.Empty;
            Country = apiAddress.Country ?? string.Empty;
        }
    }
}