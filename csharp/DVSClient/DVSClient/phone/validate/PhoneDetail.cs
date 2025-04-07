using DVSClient.Common;
using DVSClient.Server.Phone;

namespace DVSClient.Phone.Validate
{
    public class PhoneDetail
    {
        public string OriginalOperatorName { get; }
        public string OriginalNetworkStatus { get; }
        public string OriginalHomeNetworkIdentity { get; }
        public string OriginalCountryPrefix { get; }
        public Country OriginalCountry { get; }
        public string OperatorName { get; }
        public string NetworkStatus { get; }
        public string HomeNetworkIdentity { get; }
        public string CountryPrefix { get; }
        public Country Country { get; }
        public string IsPorted { get; }
        public int? CacheValueDays { get; }
        public string DateCached { get; }
        public string EmailToSmsAddress { get; }
        public string EmailToMmsAddress { get; }

        public PhoneDetail(RestApiPhoneValidatePhoneDetail detail)
        {
            OriginalOperatorName = detail.OriginalOperatorName ?? string.Empty;
            OriginalNetworkStatus = detail.OriginalNetworkStatus ?? string.Empty;
            OriginalHomeNetworkIdentity = detail.OriginalHomeNetworkIdentity ?? string.Empty;
            OriginalCountryPrefix = detail.OriginalCountryPrefix ?? string.Empty;
            OriginalCountry = !string.IsNullOrEmpty(detail.OriginalCountryIso) ? Country.FromIso3(detail.OriginalCountryIso) : Country.Unknown;
            OperatorName = detail.OperatorName ?? string.Empty;
            NetworkStatus = detail.NetworkStatus ?? string.Empty;
            HomeNetworkIdentity = detail.HomeNetworkIdentity ?? string.Empty;
            CountryPrefix = detail.CountryPrefix ?? string.Empty;
            Country = !string.IsNullOrEmpty(detail.CountryIso) ? Country.FromIso3(detail.CountryIso) : Country.Unknown;
            IsPorted = detail.IsPorted ?? string.Empty;
            CacheValueDays = detail.CacheValueDays;
            DateCached = detail.DateCached ?? string.Empty;
            EmailToSmsAddress = detail.EmailToSmsAddress ?? string.Empty;
            EmailToMmsAddress = detail.EmailToMmsAddress ?? string.Empty;
        }
    }
}
