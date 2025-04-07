package com.experian.dvs.client.phone;

import com.experian.dvs.client.common.Country;

import java.util.ArrayList;
import java.util.List;

public class Configuration extends com.experian.dvs.client.common.Configuration {

    public static final int DEFAULT_CACHE_VALUE_DAYS = 7;
    private final boolean metadata;
    private final String outputFormat;
    private final int cacheValueDays;
    private final boolean getPortedDate;
    private final boolean getDisposableNumber;
    private final List<Country> liveStatusForMobile;
    private final List<Country> liveStatusForLandline;

    protected Configuration(Builder builder) {
        super(builder);
        this.metadata = builder.metadata;
        this.outputFormat = builder.outputFormat;
        this.cacheValueDays = builder.cacheValueDays;
        this.getPortedDate = builder.getPortedDate;
        this.getDisposableNumber = builder.getDisposableNumber;
        this.liveStatusForMobile = builder.liveStatusForMobile;
        this.liveStatusForLandline = builder.liveStatusForLandline;
    }

    public static Configuration.Builder newBuilder(String token) {
        return new Builder(token);
    }

    public String getOutputFormat() {
        return outputFormat;
    }

    public int getCacheValueDays() {
        return cacheValueDays;
    }

    public boolean getGetPortedDate() {
        return getPortedDate;
    }

    public boolean getGetDisposableNumber() {
        return getDisposableNumber;
    }

    public List<Country> getLiveStatusForLandline() {
        return liveStatusForLandline;
    }

    public boolean getMetadata() {
        return metadata;
    }

    public List<Country> getLiveStatusForMobile() {
        return liveStatusForMobile;
    }

    public static class Builder extends com.experian.dvs.client.common.Configuration.Builder {
        private boolean metadata;
        private String outputFormat = "";
        private int cacheValueDays = DEFAULT_CACHE_VALUE_DAYS;
        private boolean getPortedDate;
        private boolean getDisposableNumber;
        private List<Country> liveStatusForMobile = new ArrayList<Country>();
        private List<Country> liveStatusForLandline = new ArrayList<Country>();

        public Builder(String token) {
            super(token);
        }

        public Builder setTransactionId(String transactionId)
        {
            super.setTransactionId(transactionId);
            return this;
        }

        public Builder includeMetadata() {
            this.metadata = true;
            return this;
        }

        public Builder useOutputFormat(String outputFormat) {
            this.outputFormat = outputFormat;
            return this;
        }

        public Builder useCacheValueDays(Integer cacheValueDays) {
            this.cacheValueDays = cacheValueDays;
            return this;
        }

        public Builder includePortedDate() {
            this.getPortedDate = true;
            return this;
        }

        public Builder includeDisposableNumber() {
            this.getDisposableNumber = true;
            return this;
        }

        public Builder useLiveStatusForMobile(List<Country> liveStatusForMobile) {
            this.liveStatusForMobile = liveStatusForMobile;
            return this;
        }

        public Builder useLiveStatusForLandline(List<Country> liveStatusForLandline) {
            this.liveStatusForLandline = liveStatusForLandline;
            return this;
        }

        @Override
        public Configuration build() {
            return new Configuration(this);
        }
    }
}