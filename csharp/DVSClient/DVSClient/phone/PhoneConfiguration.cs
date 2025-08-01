﻿using DVSClient.Common;

namespace DVSClient.Phone
{
    /// <summary>
    /// Configuration class for setting up the email validation client.
    /// </summary>
    public class PhoneConfiguration : Configuration
    {
        public const int DefaultCacheValueDays = 7;
        internal bool? Metadata { get; }
        internal string OutputFormat { get; }
        internal int? CacheValueDays { get; }
        internal bool? IncludeDisposableNumber { get; }
        internal bool? IncludePortedDate { get; }
        internal IEnumerable<Country> LiveStatusForMobile { get; }
        internal IEnumerable<Country> LiveStatusForLandline { get; }

        private PhoneConfiguration(PhoneBuilder builder) : base(builder)
        {
            Metadata = builder.Metadata;
            OutputFormat = builder.OutputFormat;
            CacheValueDays = builder.CacheValueDays;
            IncludePortedDate = builder.GetPortedDate;
            IncludeDisposableNumber = builder.GetDisposableNumber;
            LiveStatusForMobile = builder.LiveStatusForMobile;
            LiveStatusForLandline = builder.LiveStatusForLandline;
        }

        /// <summary>
        /// Creates a new builder instance for configuring the phone validation client.
        /// </summary>
        /// <param name="token">The API token to authenticate requests.</param>
        /// <returns>A new instance of the Builder class.</returns>
        public static PhoneBuilder NewBuilder(string? token)
        {
            return new PhoneBuilder(token);
        }

        public class PhoneBuilder : Builder
        {
            internal bool Metadata { get; private set; }
            internal string OutputFormat { get; private set; } = string.Empty;
            internal int CacheValueDays { get; private set; } = DefaultCacheValueDays;
            internal bool GetPortedDate { get; private set; }
            internal bool GetDisposableNumber { get; private set; }
            internal IEnumerable<Country> LiveStatusForMobile { get; private set; } = new List<Country>();
            internal IEnumerable<Country> LiveStatusForLandline { get; private set; } = new List<Country>();

            /// <summary>
            /// Initializes a new instance of the Builder class.
            /// </summary>
            /// <param name="token">The API token to authenticate requests.</param>
            public PhoneBuilder(string? token) : base(token)
            {
            }

            /// <summary>
            /// Sets the maximum delay between retries for API requests.
            /// </summary>
            /// <param name="maxDelay">The maximum delay in milliseconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public new PhoneBuilder SetMaxDelay(int maxDelay)
            {
                base.SetMaxDelay(maxDelay);
                return this;
            }

            /// <summary>
            /// Sets the initial delay before retrying API requests.
            /// </summary>
            /// <param name="initialDelay">The initial delay in milliseconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public new PhoneBuilder SetInitialDelay(int initialDelay)
            {
                base.SetInitialDelay(initialDelay);
                return this;
            }

            /// <summary>
            /// Sets the maximum number of retries for API requests.
            /// </summary>
            /// <param name="maxRetries">The maximum number of retries.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public new PhoneBuilder SetMaxRetries(int maxRetries)
            {
                base.SetMaxRetries(maxRetries);
                return this;
            }

            /// <summary>
            /// Sets the timeout for API requests in seconds.
            /// </summary>
            /// <param name="timeouts">The timeout duration in seconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public new PhoneBuilder SetApiRequestTimeoutInSeconds(int timeouts)
            {
                base.SetApiRequestTimeoutInSeconds(timeouts);
                return this;
            }

            /// <summary>
            /// Sets the timeout for the HTTP client in seconds.
            /// </summary>
            /// <param name="timeouts">The timeout duration in seconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public new PhoneBuilder SetHttpClientTimeoutInSeconds(int timeouts)
            {
                base.SetHttpClientTimeoutInSeconds(timeouts);
                return this;
            }

            /// <summary>
            /// Sets a custom reference ID for API requests.
            /// </summary>
            /// <param name="referenceId">The reference ID to use.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            [Obsolete("Set your reference ID as part every API interaction like the Validate call instead.")]
            public new PhoneBuilder SetTransactionId(string referenceId)
            {
                base.SetTransactionId(referenceId);
                return this;
            }

            /// <summary>
            /// Includes metadata in the API response.
            /// </summary>
            /// <returns>The current Builder instance for method chaining.</returns>
            public PhoneBuilder IncludeMetadata()
            {
                Metadata = true;
                return this;
            }

            /// <summary>
            /// Specifies the phone number output format for the API response.
            /// </summary>
            /// <param name="outputFormat">The desired output format (e.g., NATIONAL).</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public PhoneBuilder UseOutputFormat(string outputFormat)
            {
                OutputFormat = outputFormat;
                return this;
            }

            /// <summary>
            /// Sets the maximum ages of the cache for the phone number validation result.
            /// </summary>
            /// <param name="cacheValueDays">The maximum age of the cache.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public PhoneBuilder UseCacheValueDays(int cacheValueDays)
            {
                CacheValueDays = cacheValueDays;
                return this;
            }

            /// <summary>
            /// Includes the ported date of the phone number in the API response.
            /// </summary>
            /// <returns>The current Builder instance for method chaining.</returns>
            public PhoneBuilder IncludePortedDate()
            {
                GetPortedDate = true;
                return this;
            }

            /// <summary>
            /// Includes information about whether the phone number is disposable in the API response.
            /// </summary>
            /// <returns>The current Builder instance for method chaining.</returns>
            public PhoneBuilder IncludeDisposableNumber()
            {
                GetDisposableNumber = true;
                return this;
            }

            /// <summary>
            /// Specifies the countries for which live status should be checked for mobile numbers.
            /// </summary>
            /// <param name="liveStatusForMobile">A list of countries to check live status for mobile numbers.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public PhoneBuilder UseLiveStatusForMobile(IEnumerable<Country> liveStatusForMobile)
            {
                LiveStatusForMobile = liveStatusForMobile;
                return this;
            }

            /// <summary>
            /// Specifies the countries for which live status should be checked for landline numbers.
            /// </summary>
            /// <param name="liveStatusForLandline">A list of countries to check live status for landline numbers.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            public PhoneBuilder UseLiveStatusForLandline(IEnumerable<Country> liveStatusForLandline)
            {
                LiveStatusForLandline = liveStatusForLandline;
                return this;
            }

            /// <summary>
            /// Builds the Configuration object with the specified settings.
            /// </summary>
            /// <returns>A Configuration object with the configured settings.</returns>
            public override PhoneConfiguration Build()
            {
                return new PhoneConfiguration(this);
            }
        }
    }
}
