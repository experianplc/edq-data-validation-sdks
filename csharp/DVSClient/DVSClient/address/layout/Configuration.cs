namespace DVSClient.Address.Layout
{
    public class Configuration : Common.Configuration
    {
        protected Configuration(Builder builder) : base(builder)
        {
        }

        public static Builder NewBuilder(string token)
        {
            return new Builder(token);
        }

        public new class Builder : Common.Configuration.Builder
        {
            public Builder(string token) : base(token)
            {
            }

            public override Configuration Build()
            {
                return new Configuration(this);
            }

            public Builder SetTransactionId(string transactionId)
            {
                base.SetTransactionId(transactionId);
                return this;
            }
        }
    }
}