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
            /// Sets a custom reference ID for API requests.
            /// </summary>
            /// <param name="referenceId">The reference ID for tracking the request.</param>
            /// <returns>The current <see cref="LayoutBuilder"/> instance for method chaining.</returns>
            /// <remarks>
            /// Use this method to set a unique reference ID for tracking API requests.
            /// </remarks>
            [Obsolete("Set your reference ID as part every API interaction like the creating or deleting a layout call instead.")]
            public new LayoutBuilder SetTransactionId(string referenceId)
            {
                base.SetTransactionId(referenceId);
                return this;
            }
        }
    }
}
