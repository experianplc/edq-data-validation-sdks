using DVSClient.Exceptions;

namespace DVSClient.Common
{
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

        protected Configuration(Builder builder)
        {
            this._token = builder.Token;
            this._useXAppAuthentication = builder.UseXAppAuthentication;
            this._transactionId = builder.TransactionId;
            this._apiRequestTimeoutInSeconds = builder.ApiRequestTimeoutInSeconds;
            this._httpClientTimeoutInSeconds = builder.HttpClientTimeoutInSeconds;
            this._maxRetries = builder.MaxRetries;
            this._initialDelayInMilliseconds = builder.InitialDelayInMilliseconds;
            this._maxDelayInMilliseconds = builder.MaxDelayInMilliseconds;
        }

        public string GetToken() => _token;
        public bool IsUseXAppAuthentication() => _useXAppAuthentication;
        public Uri GetServerUri() => ServerUri;
        public string GetTransactionId() => _transactionId;
        public int GetApiRequestTimeoutInSeconds() => _apiRequestTimeoutInSeconds;
        public int GetHttpClientTimeoutInSeconds() => _httpClientTimeoutInSeconds;
        public int GetMaxRetries() => _maxRetries;
        public int GetInitialDelayInMilliseconds() => _initialDelayInMilliseconds;
        public int GetMaxDelayInMilliseconds() => _maxDelayInMilliseconds;

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

            if (GetApiRequestTimeoutInSeconds() != Configuration.DefaultHttpClientTimeoutInSeconds)
            {
                headers["Timeout-Seconds"] = GetApiRequestTimeoutInSeconds().ToString();
            }

            return headers;
        }

        private string CreateTransactionId()
        {
            return Guid.NewGuid().ToString();
        }

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

            protected Builder(string? token = "")
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new InvalidConfigurationException("The supplied configuration must contain an authorisation token");
                }

                Token = token;
            }

            public abstract Configuration Build();

            protected Builder SetHttpClientTimeoutInSeconds(int httpClientTimeout)
            {
                HttpClientTimeoutInSeconds = httpClientTimeout;
                return this;
            }

            protected Builder SetUseXAppAuthentication(bool useXappKey)
            {
                UseXAppAuthentication = useXappKey;
                return this;
            }

            protected Builder SetApiRequestTimeoutInSeconds(int apiRequestTimeout)
            {
                ApiRequestTimeoutInSeconds = apiRequestTimeout;
                return this;
            }

            protected Builder SetMaxRetries(int maxRetries)
            {
                MaxRetries = maxRetries;
                return this;
            }

            protected Builder SetInitialDelay(int initialDelayInMilliseconds)
            {
                InitialDelayInMilliseconds = initialDelayInMilliseconds;
                return this;
            }

            protected Builder SetMaxDelay(int maxDelayInMilliseconds)
            {
                MaxDelayInMilliseconds = maxDelayInMilliseconds;
                return this;
            }

            protected Builder SetTransactionId(string transactionId)
            {
                TransactionId = transactionId;
                return this;
            }
        }
    }
}