using DVSClient.Common;

namespace DVSClient.Email
{
    /// <summary>
    /// Configuration class for setting up the email validation client.
    /// </summary>
    public class EmailConfiguration : Configuration
    {
        internal bool? Metadata { get; }

        private EmailConfiguration(EmailBuilder builder) : base(builder)
        {
            Metadata = builder.Metadata;
        }

        /// <summary>
        /// Creates a new builder instance for configuring the email validation client.
        /// </summary>
        /// <param name="token">The API token to authenticate requests.</param>
        /// <returns>A new instance of the Builder class.</returns>
        public static EmailBuilder NewBuilder(string? token)
        {
            return new EmailBuilder(token);
        }

        /// <summary>
        /// Builder class for constructing a Configuration object with custom settings.
        /// </summary>
        public class EmailBuilder : Builder
        {
            internal bool? Metadata { get; private set; }

            /// <summary>
            /// Initializes a new instance of the Builder class.
            /// </summary>
            /// <param name="token">The API token to authenticate requests.</param>
            public EmailBuilder(string? token) : base(token)
            {
            }

            /// <summary>
            /// Builds the Configuration object with the specified settings.
            /// </summary>
            /// <returns>A Configuration object with the configured settings.</returns>
            public override EmailConfiguration Build()
            {
                return new EmailConfiguration(this);
            }

            /// <summary>
            /// Sets the maximum delay between retries for API requests.
            /// </summary>
            /// <param name="maxDelay">The maximum delay in milliseconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to configure the maximum delay between retries when an API request fails.
            /// </remarks>
            public new EmailBuilder SetMaxDelay(int maxDelay)
            {
                base.SetMaxDelay(maxDelay);
                return this;
            }

            /// <summary>
            /// Sets the initial delay before retrying API requests.
            /// </summary>
            /// <param name="initialDelay">The initial delay in milliseconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to configure the initial delay before retrying a failed API request.
            /// </remarks>
            public new EmailBuilder SetInitialDelay(int initialDelay)
            {
                base.SetInitialDelay(initialDelay);
                return this;
            }

            /// <summary>
            /// Sets the maximum number of retries for API requests.
            /// </summary>
            /// <param name="maxRetries">The maximum number of retries.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to configure how many times the client should retry a failed API request.
            /// </remarks>
            public new EmailBuilder SetMaxRetries(int maxRetries)
            {
                base.SetMaxRetries(maxRetries);
                return this;
            }

            /// <summary>
            /// Sets the timeout for API requests in seconds.
            /// </summary>
            /// <param name="timeouts">The timeout duration in seconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to configure the maximum time the client should wait for an API response.
            /// </remarks>
            public new EmailBuilder SetApiRequestTimeoutInSeconds(int timeouts)
            {
                base.SetApiRequestTimeoutInSeconds(timeouts);
                return this;
            }

            /// <summary>
            /// Sets the timeout for the HTTP client in seconds.
            /// </summary>
            /// <param name="timeouts">The timeout duration in seconds.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to configure the timeout for the underlying HTTP client used for API requests.
            /// </remarks>
            public new EmailBuilder SetHttpClientTimeoutInSeconds(int timeouts)
            {
                base.SetHttpClientTimeoutInSeconds(timeouts);
                return this;
            }

            /// <summary>
            /// Sets a custom transaction ID for API requests.
            /// </summary>
            /// <param name="transactionId">The transaction ID to use.</param>
            /// <returns>The current Builder instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to set a unique transaction ID for tracking API requests.
            /// </remarks>
            public new EmailBuilder SetTransactionId(string transactionId)
            {
                base.SetTransactionId(transactionId);
                return this;
            }

            /// <summary>
            /// Includes metadata in the API response.
            /// </summary>
            /// <returns>The current Builder instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to include additional metadata in the API response, such as validation details.
            /// </remarks>
            public EmailBuilder IncludeMetadata()
            {
                Metadata = true;
                return this;
            }
        }
    }
}
