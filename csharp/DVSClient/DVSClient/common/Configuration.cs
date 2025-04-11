using DVSClient.Exceptions;

namespace DVSClient.Common
{
    /// <summary>
    /// Base configuration class for setting up API clients.
    /// Provides common configuration options such as authentication, timeouts, and retry policies.
    /// </summary>
    public abstract class Configuration
    {
        private static readonly Uri ServerUri = new Uri("https://api.experianaperture.io/");
        public const int DefaultApiRequestTimeoutInSeconds = 15;
        public const int DefaultHttpClientTimeoutInSeconds = 20;
        public const int DefaultRetries = 5;
        public const int DefaultInitialDelayInMilliseconds = 1000;
        public const int DefaultMaxDelayInMilliseconds = 15000;

        private readonly string _token;
        private readonly string _transactionId;
        private readonly bool _useXAppAuthentication;
        private readonly int _apiRequestTimeoutInSeconds;
        private readonly int _httpClientTimeoutInSeconds;
        private readonly int _maxRetries;
        private readonly int _initialDelayInMilliseconds;
        private readonly int _maxDelayInMilliseconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="builder">The builder object containing configuration settings.</param>
        protected Configuration(Builder builder)
        {
            _token = builder.Token;
            _useXAppAuthentication = builder.UseXAppAuthentication;
            _transactionId = builder.TransactionId;
            _apiRequestTimeoutInSeconds = builder.ApiRequestTimeoutInSeconds;
            _httpClientTimeoutInSeconds = builder.HttpClientTimeoutInSeconds;
            _maxRetries = builder.MaxRetries;
            _initialDelayInMilliseconds = builder.InitialDelayInMilliseconds;
            _maxDelayInMilliseconds = builder.MaxDelayInMilliseconds;
        }

        /// <summary>
        /// Gets the API token used for authentication.
        /// </summary>
        /// <returns>The API token as a string.</returns>
        public string GetToken() => _token;

        /// <summary>
        /// Checks whether authentication via the x-app-key header is enabled.
        /// </summary>
        /// <returns><c>true</c> if x-app-key header authentication is enabled; otherwise, <c>false</c>.</returns>
        public bool IsUseXAppAuthentication() => _useXAppAuthentication;

        /// <summary>
        /// Gets the base server URI for API requests.
        /// </summary>
        /// <returns>The server URI as a <see cref="Uri"/> object.</returns>
        public Uri GetServerUri() => ServerUri;

        /// <summary>
        /// Gets the transaction ID used for tracking API requests.
        /// </summary>
        /// <returns>The transaction ID as a string.</returns>
        public string GetTransactionId() => _transactionId;

        /// <summary>
        /// Gets the timeout for API requests in seconds.
        /// </summary>
        /// <returns>The timeout duration in seconds.</returns>
        public int GetApiRequestTimeoutInSeconds() => _apiRequestTimeoutInSeconds;

        /// <summary>
        /// Gets the timeout for the HTTP client in seconds.
        /// </summary>
        /// <returns>The timeout duration in seconds.</returns>
        public int GetHttpClientTimeoutInSeconds() => _httpClientTimeoutInSeconds;

        /// <summary>
        /// Gets the maximum number of retries for API requests.
        /// </summary>
        /// <returns>The maximum number of retries.</returns>
        public int GetMaxRetries() => _maxRetries;

        /// <summary>
        /// Gets the initial delay before retrying API requests.
        /// </summary>
        /// <returns>The initial delay in milliseconds.</returns>
        public int GetInitialDelayInMilliseconds() => _initialDelayInMilliseconds;

        /// <summary>
        /// Gets the maximum delay between retries for API requests.
        /// </summary>
        /// <returns>The maximum delay in milliseconds.</returns>
        public int GetMaxDelayInMilliseconds() => _maxDelayInMilliseconds;

        /// <summary>
        /// Generates common headers for API requests.
        /// </summary>
        /// <param name="allowsDotInReferenceId">
        /// A boolean flag indicating whether dots (.) are allowed in the "Reference-Id" header.
        /// If set to <c>false</c>, dots in the version string will be replaced with hyphens (-).
        /// </param>
        /// <returns>A dictionary containing common headers for API requests.</returns>
        public Dictionary<string, object> GetCommonHeaders(bool allowsDotInReferenceId = true)
        {
            var headers = new Dictionary<string, object>();

            if (IsUseXAppAuthentication())
            {
                headers["x-app-key"] = GetToken();
            }
            else
            {
                headers["Auth-Token"] = GetToken();
            }

            var transactionId = GetTransactionId();

            if (string.IsNullOrEmpty(transactionId))
            {
                transactionId = CreateTransactionId();
            }
            headers["Reference-Id"] = ClientReference.GetReference(transactionId, allowsDotInReferenceId);

            if (GetApiRequestTimeoutInSeconds() != DefaultHttpClientTimeoutInSeconds)
            {
                headers["Timeout-Seconds"] = GetApiRequestTimeoutInSeconds().ToString();
            }

            return headers;
        }

        /// <summary>
        /// Creates a new unique transaction ID.
        /// </summary>
        /// <returns>A new transaction ID as a string.</returns>
        private string CreateTransactionId()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Abstract builder class for constructing a <see cref="Configuration"/> object.
        /// </summary>
        public abstract class Builder
        {
            internal string Token { get; }
            internal bool UseXAppAuthentication { get; private set; } = false;
            internal string TransactionId { get; private set; } = string.Empty;
            internal int ApiRequestTimeoutInSeconds { get; private set; } = DefaultApiRequestTimeoutInSeconds;
            internal int HttpClientTimeoutInSeconds { get; private set; } = DefaultHttpClientTimeoutInSeconds;
            internal int MaxRetries { get; private set; } = DefaultRetries;
            internal int InitialDelayInMilliseconds { get; private set; } = DefaultInitialDelayInMilliseconds;
            internal int MaxDelayInMilliseconds { get; private set; } = DefaultMaxDelayInMilliseconds;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="token">The API token to authenticate requests.</param>
            /// <exception cref="InvalidConfigurationException">Thrown if the token is null or empty.</exception>
            protected Builder(string? token = "")
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new InvalidConfigurationException("The supplied configuration must contain an authorisation token.");
                }

                Token = token;
            }

            /// <summary>
            /// Builds the <see cref="Configuration"/> object with the specified settings.
            /// </summary>
            /// <returns>A <see cref="Configuration"/> object.</returns>
            public abstract Configuration Build();

            /// <summary>
            /// Sets the timeout for the HTTP client in seconds.
            /// </summary>
            /// <param name="httpClientTimeout">The timeout duration in seconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            protected Builder SetHttpClientTimeoutInSeconds(int httpClientTimeout)
            {
                HttpClientTimeoutInSeconds = httpClientTimeout;
                return this;
            }

            /// <summary>
            /// Enables or disables authentication via the x-app-key header for the configuration.
            /// </summary>
            /// <param name="useXappKey">A boolean indicating whether to use x-app-key header authentication.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            protected Builder SetUseXAppAuthentication(bool useXappKey)
            {
                UseXAppAuthentication = useXappKey;
                return this;
            }

            /// <summary>
            /// Sets the timeout for API requests in seconds.
            /// </summary>
            /// <param name="apiRequestTimeout">The timeout duration in seconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            protected Builder SetApiRequestTimeoutInSeconds(int apiRequestTimeout)
            {
                ApiRequestTimeoutInSeconds = apiRequestTimeout;
                return this;
            }

            /// <summary>
            /// Sets the maximum number of retries for API requests.
            /// </summary>
            /// <param name="maxRetries">The maximum number of retries.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            protected Builder SetMaxRetries(int maxRetries)
            {
                MaxRetries = maxRetries;
                return this;
            }

            /// <summary>
            /// Sets the initial delay before retrying API requests.
            /// </summary>
            /// <param name="initialDelayInMilliseconds">The initial delay in milliseconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            protected Builder SetInitialDelay(int initialDelayInMilliseconds)
            {
                InitialDelayInMilliseconds = initialDelayInMilliseconds;
                return this;
            }

            /// <summary>
            /// Sets the maximum delay between retries for API requests.
            /// </summary>
            /// <param name="maxDelayInMilliseconds">The maximum delay in milliseconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            protected Builder SetMaxDelay(int maxDelayInMilliseconds)
            {
                MaxDelayInMilliseconds = maxDelayInMilliseconds;
                return this;
            }

            /// <summary>
            /// Sets a custom transaction ID for API requests.
            /// </summary>
            /// <param name="transactionId">The transaction ID to use.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            protected Builder SetTransactionId(string transactionId)
            {
                TransactionId = transactionId;
                return this;
            }
        }
    }
}
