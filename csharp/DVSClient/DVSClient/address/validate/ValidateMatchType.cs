using DVSClient.Common;

namespace DVSClient.Address.Validate
{
    public enum ValidateMatchType
    {
        [EnumStringValue("Unknown")]
        Unknown,
        [EnumStringValue("unprocessed")]
        Unprocessed,
        [EnumStringValue("blank")]
        Blank,
        [EnumStringValue("unmatched")]
        Unmatched,
        [EnumStringValue("post_code_no_address")]
        PostalCodeMatchWithoutAddress,
        [EnumStringValue("multiple_no_post_code")]
        MultipleMatchWithoutPostalCode,
        [EnumStringValue("multiple_with_post_code")]
        MultipleMatchWithPostalCode,
        [EnumStringValue("partial_no_post_code")]
        PartialMatchWithoutPostalCode,
        [EnumStringValue("partial_with_post_code")]
        PartialMatchWithPostalCode,
        [EnumStringValue("full_no_post_code")]
        FullMatchWithoutPostalCode,
        [EnumStringValue("full_with_post_code")]
        FullMatchWithPostalCode,
    }
}
