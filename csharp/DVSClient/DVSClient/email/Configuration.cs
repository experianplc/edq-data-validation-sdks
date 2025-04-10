using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

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

            public new Builder SetMaxDelay(int maxDelay)
            {
                base.SetMaxDelay(maxDelay);
                return this;
            }

            public new Builder SetInitialDelay(int initialDelay)
            {
                base.SetInitialDelay(initialDelay);
                return this;
            }

            public new Builder SetMaxRetries(int maxRetries)
            {
                base.SetMaxRetries(maxRetries);
                return this;
            }

            public new Builder SetApiRequestTimeoutInSeconds(int timeouts)
            {
                base.SetApiRequestTimeoutInSeconds(timeouts);
                return this;
            }

            public new Builder SetHttpClientTimeoutInSeconds(int timeouts)
            {
                base.SetHttpClientTimeoutInSeconds(timeouts);
                return this;
            }

            public new Builder SetTransactionId(string transactionId)
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