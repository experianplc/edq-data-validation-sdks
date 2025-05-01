using DVSClient.Common;

namespace DVSClient.Address.Layout
{
    /// <summary>
    /// Configuration class for setting up the address layout client.
    /// </summary>
    public class LayoutConfiguration : Configuration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutConfiguration"/> class.
        /// </summary>
        /// <param name="builder">The builder object containing configuration settings.</param>
        protected LayoutConfiguration(LayoutBuilder builder) : base(builder)
        {
        }

        /// <summary>
        /// Creates a new builder instance for configuring the address layout client.
        /// </summary>
        /// <param name="token">The API token to authenticate requests.</param>
        /// <returns>A new instance of the <see cref="LayoutBuilder"/> class.</returns>
        public static LayoutBuilder NewBuilder(string token)
        {
            return new LayoutBuilder(token);
        }

        /// <summary>
        /// Builder class for constructing a <see cref="LayoutConfiguration"/> object with custom settings.
        /// </summary>
        public class LayoutBuilder : Builder
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="LayoutBuilder"/> class.
            /// </summary>
            /// <param name="token">The API token to authenticate requests.</param>
            public LayoutBuilder(string token) : base(token)
            {
            }

            /// <summary>
            /// Builds the <see cref="LayoutConfiguration"/> object with the specified settings.
            /// </summary>
            /// <returns>A <see cref="LayoutConfiguration"/> object with the configured settings.</returns>
            public override LayoutConfiguration Build()
            {
                return new LayoutConfiguration(this);
            }

            /// <summary>
            /// Sets a custom transaction ID for API requests.
            /// </summary>
            /// <param name="transactionId">The transaction ID to use.</param>
            /// <returns>The current <see cref="LayoutBuilder"/> instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to set a unique transaction ID for tracking API requests.
            /// </remarks>
            public new LayoutBuilder SetTransactionId(string transactionId)
            {
                base.SetTransactionId(transactionId);
                return this;
            }
        }
    }
}
