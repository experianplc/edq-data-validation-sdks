using DVSClient.Common;
using DVSClient.Server.Email;

namespace DVSClient.Email.Validate
{
    public class ValidateResult
    {
        public ResponseError? Error { get; }
        public EmailConfidence? Confidence { get; }
        public IEnumerable<string> DidYouMean { get; }
        public VerboseOutput? VerboseOutput { get; }
        public DomainType? DomainType { get; }

        public ValidateResult(RestApiEmailValidateResponse apiResponse)
        {
            Error = apiResponse.Error != null ? new ResponseError(apiResponse.Error) : null;

            var result = apiResponse.Result;
            if (result != null)
            {
                Confidence = result.Confidence?.GetEnumValueFromJsonName<EmailConfidence>();
                DidYouMean = result.DidYouMean != null ? new List<string>(result.DidYouMean) : new List<string>();
                VerboseOutput = result.VerboseOutput?.GetEnumValueFromJsonName<VerboseOutput>();
            }
            else
            {
                Confidence = default;
                DidYouMean = new List<string>();
                VerboseOutput = default;
            }

            var metadata = apiResponse.Metadata;
            if (metadata != null)
            {
                DomainType = metadata.DomainDetail?.Type?.GetEnumValueFromJsonName<DomainType>();
            }
            else
            {
                DomainType = default;
            }
        }
    }
}
