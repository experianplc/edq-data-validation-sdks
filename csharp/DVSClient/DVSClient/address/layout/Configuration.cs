namespace DVSClient.Address.Layout
{
    /// <summary>
    /// Configuration class for setting up the address layout client.
    /// </summary>
    public class Configuration : Common.Configuration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="builder">The builder object containing configuration settings.</param>
        protected Configuration(Builder builder) : base(builder)
        {
        }

        /// <summary>
        /// Creates a new builder instance for configuring the address layout client.
        /// </summary>
        /// <param name="token">The API token to authenticate requests.</param>
        /// <returns>A new instance of the <see cref="Builder"/> class.</returns>
        public static Builder NewBuilder(string token)
        {
            return new Builder(token);
        }

        /// <summary>
        /// Builder class for constructing a <see cref="Configuration"/> object with custom settings.
        /// </summary>
        public new class Builder : Common.Configuration.Builder
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="token">The API token to authenticate requests.</param>
            public Builder(string token) : base(token)
            {
            }

            /// <summary>
            /// Builds the <see cref="Configuration"/> object with the specified settings.
            /// </summary>
            /// <returns>A <see cref="Configuration"/> object with the configured settings.</returns>
            public override Configuration Build()
            {
                return new Configuration(this);
            }

            /// <summary>
            /// Sets a custom transaction ID for API requests.
            /// </summary>
            /// <param name="transactionId">The transaction ID to use.</param>
            /// <returns>The current <see cref="Builder"/> instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to set a unique transaction ID for tracking API requests.
            /// </remarks>
            public new Builder SetTransactionId(string transactionId)
            {
                base.SetTransactionId(transactionId);
                return this;
            }
        }
    }
}
