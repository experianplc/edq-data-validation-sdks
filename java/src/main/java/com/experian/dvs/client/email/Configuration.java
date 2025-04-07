package com.experian.dvs.client.email;

public class Configuration extends com.experian.dvs.client.common.Configuration {

    private final boolean metadata;

    protected Configuration(Builder builder) {
        super(builder);
        this.metadata = builder.metadata;
    }

    public static Builder newBuilder(String token) {
        return new Builder(token);
    }

    public boolean getMetadata() {
        return metadata;
    }

    public static class Builder extends com.experian.dvs.client.common.Configuration.Builder {

        private boolean metadata;

        public Builder(String token) {
            super(token);
        }

        public Configuration build() {
            return new Configuration(this);
        }

        public Builder includeMetadata() {
            this.metadata = true;
            return this;
        }

        public Builder setTransactionId(String transactionId) {
            super.setTransactionId(transactionId);
            return this;
        }
    }
}
