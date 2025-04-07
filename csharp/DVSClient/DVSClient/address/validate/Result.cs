using DVSClient.Address.Format;
using DVSClient.Common;
using DVSClient.Server.Address.Validate;

namespace DVSClient.Address.Validate
{
    public class Result
    {
        public ValidationDetail? ValidationDetail { get; }
        public string GlobalAddressKey { get; }
        public bool? MoreResultsAvailable { get; }
        public Confidence? Confidence { get; }
        public Format.Address? Address { get; }
        public AddressFormatted? AddressFormatted { get; }

        public Result(RestApiAddressValidateResponse response)
        {
            var result = response.Result;
            if (result != null)
            {
                ValidationDetail = result.ValidationDetail != null ? new ValidationDetail(result.ValidationDetail) : null;
                GlobalAddressKey = result.GlobalAddressKey ?? string.Empty;
                MoreResultsAvailable = result.MoreResultsAvailable;
                Confidence = result.Confidence?.GetEnumValueFromJsonName<Confidence>();
                Address = result.Address != null ? new Format.Address(result.Address) : null;
                AddressFormatted = result.AddressesFormatted != null && result.AddressesFormatted.Any()
                    ? new AddressFormatted(result.AddressesFormatted.ElementAt(0))
                    : null;
            }
            else
            {
                ValidationDetail = null;
                GlobalAddressKey = string.Empty;
                MoreResultsAvailable = false;
                Confidence = null;
                Address = null;
                AddressFormatted = null;
            }
        }
    }
}