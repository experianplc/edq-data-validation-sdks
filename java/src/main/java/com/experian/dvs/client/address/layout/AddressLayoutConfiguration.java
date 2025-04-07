package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.common.Configuration;

public class AddressLayoutConfiguration extends Configuration {

    protected AddressLayoutConfiguration(Builder builder) {
        super(builder);
    }

    public static Builder newBuilder(final String token) {
        return new Builder(token);
    }


    public static class Builder extends Configuration.Builder {

        public Builder(String token) {
            super(token);
        }


        public AddressLayoutConfiguration build() {
            return new AddressLayoutConfiguration(this);
        }

        public Builder setTransactionId(String transactionId)
        {
            super.setTransactionId(transactionId);
            return this;
        }
    }
}
