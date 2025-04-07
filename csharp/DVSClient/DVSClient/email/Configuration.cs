namespace DVSClient.Email
{
    public class Configuration : Common.Configuration
    {
        internal bool? Metadata { get; }

        private Configuration(Builder builder) : base(builder)
        {
            Metadata = builder.Metadata;
        }

        public static Builder NewBuilder(string? token)
        {
            return new Builder(token);
        }

        public new class Builder : Common.Configuration.Builder
        {
            internal bool? Metadata { get; private set; }

            public Builder(string? token) : base(token)
            {
            }

            public override Configuration Build()
            {
                return new Configuration(this);
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
        }
    }
}