using DVSClient.Common;
using static DVSClient.Server.Address.Validate.RestApiAddressValidateResult;

namespace DVSClient.Address.Validate
{
    public class ValidateMatchInfo
    {
        public PostalCodeAction? PostalCodeAction { get; set; }

        public AddressAction? AddressAction { get; set; }

        public IEnumerable<string>? GenericInfo { get; set; }

        public IEnumerable<string>? AusInfo { get; set; }
        public IEnumerable<string>? DeuInfo { get; set; }
        public IEnumerable<string>? FraInfo { get; set; }
        public IEnumerable<string>? GbrInfo { get; set; }
        public IEnumerable<string>? NldInfo { get; set; }
        public IEnumerable<string>? NzlInfo { get; set; }
        public IEnumerable<string>? SgpInfo { get; set; }

        public ValidateMatchInfo(RestApiValidateMatchInfoFlags validateMatchInfo)
        {
            if (validateMatchInfo != null)
            {
                PostalCodeAction = validateMatchInfo.PostcodeAction?.GetEnumValueFromJsonName<PostalCodeAction>();
                AddressAction = validateMatchInfo.AddressAction?.GetEnumValueFromJsonName<AddressAction>();
                GenericInfo = validateMatchInfo.GenericInfo;
                AusInfo = validateMatchInfo.AusInfo;
                DeuInfo = validateMatchInfo.DeuInfo;
                FraInfo = validateMatchInfo.FraInfo;
                GbrInfo = validateMatchInfo.GbrInfo;
                NldInfo = validateMatchInfo.NldInfo;
                NzlInfo = validateMatchInfo.NzlInfo;
                SgpInfo = validateMatchInfo.SgpInfo;
            }
            else
            {
                PostalCodeAction = null;
                AddressAction = null;
                GenericInfo = null;
                AusInfo = null;
                DeuInfo = null;
                FraInfo = null;
                GbrInfo = null;
                NldInfo = null;
                NzlInfo = null;
                SgpInfo = null;
            }
        }
    }
}