using DVSClient.Common;
using DVSClient.Server.Phone;

namespace DVSClient.Phone.Validate
{
    public class Result
    {
        public string Number { get; }
        public string ValidatedPhoneNumber { get; }
        public string FormattedPhoneNumber { get; }
        public PhoneType? PhoneType { get; }
        public Confidence? Confidence { get; }
        public string PortedDate { get; }
        public string DisposableNumber { get; }
        public Metadata? Metadata { get; }

        public Result(RestApiPhoneValidateResponse response)
        {
            var result = response.Result;
            if (result != null)
            {
                Number = result.Number ?? string.Empty;
                ValidatedPhoneNumber = result.ValidatedPhoneNumber ?? string.Empty;
                FormattedPhoneNumber = result.FormattedPhoneNumber ?? string.Empty;
                PhoneType = result.PhoneType?.GetEnumValueFromJsonName<PhoneType>();
                Confidence = result.Confidence?.GetEnumValueFromJsonName<Confidence>();
                PortedDate = result.PortedDate ?? string.Empty;
                DisposableNumber = result.DisposableNumber ?? string.Empty;
            }
            else
            {
                Number = string.Empty;
                ValidatedPhoneNumber = string.Empty;
                FormattedPhoneNumber = string.Empty;
                PhoneType = null;
                Confidence = null;
                PortedDate = string.Empty;
                DisposableNumber = string.Empty;
            }

            var metadataFromApi = response.Metadata;
            Metadata = metadataFromApi != null ? new Metadata(metadataFromApi) : null;
        }
    }
}
