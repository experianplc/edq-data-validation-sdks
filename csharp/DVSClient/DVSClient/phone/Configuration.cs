using DVSClient.Common;

namespace DVSClient.Phone
{
    public class Configuration : Common.Configuration
    {
        public const int DefaultCacheValueDays = 7;
        internal bool? Metadata { get; }
        internal string OutputFormat { get; }
        internal int? CacheValueDays { get; }
        internal bool? IncludeDisposableNumber { get; }
        internal bool? IncludePortedDate { get; }
        internal IEnumerable<Country> LiveStatusForMobile { get; }
        internal IEnumerable<Country> LiveStatusForLandline { get; }

        private Configuration(Builder builder) : base(builder)
        {
            Metadata = builder.Metadata;
            OutputFormat = builder.OutputFormat;
            CacheValueDays = builder.CacheValueDays;
            IncludePortedDate = builder.GetPortedDate;
            IncludeDisposableNumber = builder.GetDisposableNumber;
            LiveStatusForMobile = builder.LiveStatusForMobile;
            LiveStatusForLandline = builder.LiveStatusForLandline;
        }

        public static Builder NewBuilder(string? token)
        {
            return new Builder(token);
        }

        public new class Builder : Common.Configuration.Builder
        {
            internal bool Metadata { get; private set; }
            internal string OutputFormat { get; private set; } = string.Empty;
            internal int CacheValueDays { get; private set; } = DefaultCacheValueDays;
            internal bool GetPortedDate { get; private set; }
            internal bool GetDisposableNumber { get; private set; }
            internal IEnumerable<Country> LiveStatusForMobile { get; private set; } = new List<Country>();
            internal IEnumerable<Country> LiveStatusForLandline { get; private set; } = new List<Country>();

            public Builder(string? token) : base(token)
            {
            }

            public Builder SetMaxDelay(int maxDelay)
            {
                base.SetMaxDelay(maxDelay);
                return this;
            }

            public Builder SetInitialDelay(int initialDelay)
            {
                base.SetInitialDelay(initialDelay);
                return this;
            }

            public Builder SetMaxRetries(int maxRetries)
            {
                base.SetMaxRetries(maxRetries);
                return this;
            }

            public Builder SetApiRequestTimeoutInSeconds(int timeouts)
            {
                base.SetApiRequestTimeoutInSeconds(timeouts);
                return this;
            }

            public Builder SetHttpClientTimeoutInSeconds(int timeouts)
            {
                base.SetHttpClientTimeoutInSeconds(timeouts);
                return this;
            }

            public Builder SetTransactionId(string transactionId)
            {
                base.SetTransactionId(transactionId);
                return this;
            }
            public Builder IncludeMetadata()
            {
                Metadata = true;
                return this;
            }

            public Builder UseOutputFormat(string outputFormat)
            {
                OutputFormat = outputFormat;
                return this;
            }

            public Builder UseCacheValueDays(int cacheValueDays)
            {
                CacheValueDays = cacheValueDays;
                return this;
            }

            public Builder IncludePortedDate()
            {
                GetPortedDate = true;
                return this;
            }

            public Builder IncludeDisposableNumber()
            {
                GetDisposableNumber = true;
                return this;
            }

            public Builder UseLiveStatusForMobile(IEnumerable<Country> liveStatusForMobile)
            {
                LiveStatusForMobile = liveStatusForMobile;
                return this;
            }

            public Builder UseLiveStatusForLandline(IEnumerable<Country> liveStatusForLandline)
            {
                LiveStatusForLandline = liveStatusForLandline;
                return this;
            }

            public override Configuration Build()
            {
                return new Configuration(this);
            }
        }
    }
}