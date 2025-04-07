using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class Result
    {
        public string? GlobalAddressKey { get; }
        public Confidence? Confidence { get; }
        public Address? Address { get; }
        public AddressFormatted? AddressFormatted { get; }
        public AddressComponents? Components { get; }
        public AddressMetadata? Metadata { get; }
        public AddressEnrichment? Enrichment { get; }

        public Result()
        {
        }

        public Result(RestApiAddressFormatResponse response)
        {
            var apiResult = response.Result;
            var apiMetadata = response.Metadata;
            var apiEnrichment = response.Enrichment;

            if (apiResult != null)
            {
                GlobalAddressKey = apiResult.GlobalAddressKey;
                Confidence = apiResult.Confidence?.GetEnumValueFromJsonName<Confidence>();
                Address = apiResult.Address != null ? new Address(apiResult.Address) : null;
                AddressFormatted = apiResult.AddressesFormatted != null ? new AddressFormatted(apiResult.AddressesFormatted.First()) : null;
                Components = apiResult.Components != null ? new AddressComponents(apiResult.Components) : null;
            }
            else
            {
                GlobalAddressKey = string.Empty;
                Confidence = null;
                Address = null;
                AddressFormatted = null;
                Components = null;
            }

            Metadata = apiMetadata != null ? new AddressMetadata(apiMetadata) : null;
            Enrichment = apiEnrichment != null ? new AddressEnrichment(apiEnrichment) : null;
        }
    }
}