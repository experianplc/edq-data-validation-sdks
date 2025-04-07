using DVSClient.Server.Phone;

namespace DVSClient.Phone.Validate
{
    public class Metadata
    {
        public string Code { get; }
        public string Message { get; }
        public PhoneDetail? PhoneDetail { get; }

        public Metadata(RestApiPhoneValidateMetadata metadata)
        {
            Code = metadata.Code ?? string.Empty;
            Message = metadata.Message ?? string.Empty;
            PhoneDetail = metadata.PhoneDetail != null ? new PhoneDetail(metadata.PhoneDetail) : null;
        }
    }
}
