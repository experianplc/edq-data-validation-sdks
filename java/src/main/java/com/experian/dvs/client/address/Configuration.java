package com.experian.dvs.client.address;

import com.experian.dvs.client.address.format.LayoutFormat;
import com.experian.dvs.client.address.layout.attributes.*;
import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;

import java.util.ArrayList;
import java.util.List;

public class Configuration extends com.experian.dvs.client.common.Configuration {

    public static final int DEFAULT_MAX_SUGGESTIONS = 7;
    public static final String DEFAULT_LAYOUT_NAME = "default";
    public static final LayoutFormat DEFAULT_LAYOUT_FORMAT = LayoutFormat.DEFAULT;

    private final boolean transliterate;
    private final List<Dataset> datasets;
    private final int maxSuggestions;
    private final String location;
    private final boolean flattenResults;
    private final Intensity intensity;
    private final PromptSet promptSet;
    private final boolean components;
    private final boolean metadata;
    private final boolean enrichment;
    private final boolean extraMatchInfo;
    private final String formatLayoutName;
    private final LayoutFormat layoutFormat;
    private final List<GlobalGeocodeAttribute> geocodes;
    private final List<PremiumLocationInsightAttribute> premiumLocationInsights;
    private final List<What3WordsAttribute> what3Words;
    private final List<AUSRegionalGeocode> ausRegionalGeocodes;
    private final List<NZLRegionalGeocode> nzlRegionalGeocodes;
    private final List<UsaRegionalGeocodeAttribute> usaRegionalGeocodes;
    private final List<GbrLocationEssentialAttribute> gbrLocationEssential;
    private final List<GbrLocationCompleteAttribute> gbrLocationComplete;
    private final List<GbrBusinessAttribute> gbrBusiness;
    private final List<GbrGovernmentAttribute> gbrGovernment;
    private final List<GBRHealth> gbrHealth;

    protected Configuration(Builder builder) {
        super(builder);
        this.transliterate = builder.transliterate;
        this.datasets = builder.datasets;
        this.maxSuggestions = builder.maxSuggestions;
        this.location = builder.location;
        this.flattenResults = builder.flattenResults;
        this.intensity = builder.intensity;
        this.promptSet = builder.promptSet;
        this.components = builder.components;
        this.metadata = builder.metadata;
        this.enrichment = builder.enrichment;
        this.extraMatchInfo = builder.extraMatchInfo;
        this.formatLayoutName = builder.formatLayoutName;
        this.layoutFormat = builder.layoutFormat;
        this.geocodes = builder.globalGeocode;
        this.premiumLocationInsights = builder.premiumLocationInsights;
        this.what3Words = builder.what3Words;
        this.ausRegionalGeocodes = builder.ausRegionalGeocode;
        this.nzlRegionalGeocodes = builder.nzlRegionalGeocode;
        this.usaRegionalGeocodes = builder.usaRegionalGeocode;
        this.gbrLocationEssential = builder.gbrLocationEssential;
        this.gbrLocationComplete = builder.gbrLocationComplete;
        this.gbrBusiness = builder.gbrBusiness;
        this.gbrGovernment = builder.gbrGovernment;
        this.gbrHealth = builder.gbrHealth;
    }

    public static Builder newBuilder(String token) {
        return new Builder(token);
    }

    public boolean getTransliterate() {
        return this.transliterate;
    }

    public List<Dataset> getDatasets() {
        return datasets;
    }

    protected boolean hasDataset(Dataset dataset) {
        return this.datasets.contains(dataset);
    }

    public int getMaxSuggestions() {
        return maxSuggestions;
    }

    public Country getCountry() {
        if (this.datasets == null || this.datasets.isEmpty()) {
            return null;
        }
        return datasets.get(0).getCountry();
    }

    public String getLocation() {
        return location;
    }

    public boolean getComponents() {
        return components;
    }

    public boolean getMetadata() {
        return metadata;
    }

    public boolean getEnrichment() {
        return enrichment;
    }

    public String getFormatLayoutName() {
        return formatLayoutName;
    }

    public LayoutFormat getLayoutFormat() {
        return layoutFormat;
    }

    public List<GlobalGeocodeAttribute> getGeocodes() {
        return geocodes;
    }

    public List<PremiumLocationInsightAttribute> getPremiumLocationInsights() {
        return premiumLocationInsights;
    }

    public List<What3WordsAttribute> getWhat3Words() {
        return what3Words;
    }

    public boolean getExtraMatchInfo() {
        return extraMatchInfo;
    }

    public boolean getFlattenResults() {
        return flattenResults;
    }

    public Intensity getSearchIntensity() {
        return intensity;
    }

    public PromptSet getPromptSet() {
        return promptSet;
    }

    public List<AUSRegionalGeocode> getAusRegionalGeocodeAttributes() {
        return ausRegionalGeocodes;
    }
    public List<NZLRegionalGeocode> getNzlRegionalGeocodeAttributes() {
        return nzlRegionalGeocodes;
    }
    public List<UsaRegionalGeocodeAttribute> getUsaRegionalGeocodeAttributes() {
        return usaRegionalGeocodes;
    }

    public List<GbrBusinessAttribute> getBusinessAttributes() {
        return gbrBusiness;
    }

    public List<GbrGovernmentAttribute> getGovernmentAttributes() {
        return gbrGovernment;
    }

    public List<GBRHealth> getHealthAttributes() {
        return gbrHealth;
    }

    public List<GbrLocationCompleteAttribute> getLocationCompleteAttributes() {
        return gbrLocationComplete;
    }

    public List<GbrLocationEssentialAttribute> getLocationEssentialAttributes() {
        return gbrLocationEssential;
    }

    public static class Builder extends com.experian.dvs.client.common.Configuration.Builder {

        private boolean transliterate;
        private List<Dataset> datasets = new ArrayList<>();
        private int maxSuggestions;
        private String location = "";
        private boolean flattenResults;
        private Intensity intensity;
        private PromptSet promptSet;
        private boolean components;
        private boolean metadata;
        private boolean enrichment;
        private boolean extraMatchInfo;
        private String formatLayoutName = "";
        private LayoutFormat layoutFormat;
        private List<GlobalGeocodeAttribute> globalGeocode = new ArrayList<>();
        private List<PremiumLocationInsightAttribute> premiumLocationInsights = new ArrayList<>();
        private List<What3WordsAttribute> what3Words = new ArrayList<>();
        private List<AUSRegionalGeocode> ausRegionalGeocode = new ArrayList<>();
        private List<NZLRegionalGeocode> nzlRegionalGeocode = new ArrayList<>();
        private List<UsaRegionalGeocodeAttribute> usaRegionalGeocode = new ArrayList<>();
        private List<GbrLocationEssentialAttribute> gbrLocationEssential = new ArrayList<>();
        private List<GbrLocationCompleteAttribute> gbrLocationComplete = new ArrayList<>();
        private List<GbrBusinessAttribute> gbrBusiness = new ArrayList<>();
        private List<GbrGovernmentAttribute> gbrGovernment = new ArrayList<>();
        private List<GBRHealth> gbrHealth = new ArrayList<>();

        public Builder(String token) {
            super(token);
            maxSuggestions = DEFAULT_MAX_SUGGESTIONS;
            layoutFormat = DEFAULT_LAYOUT_FORMAT;
            formatLayoutName = DEFAULT_LAYOUT_NAME;
        }

        public Configuration build() {
            return new Configuration(this);
        }

        public Builder setTransactionId(String transactionId)
        {
            super.setTransactionId(transactionId);
            return this;
        }


        public Builder setUseXAppAuthentication(boolean useXAppAuthentication) {
            super.setUseXAppAuthentication(useXAppAuthentication);
            return this;
        }

        public Builder setTransliterate(boolean transliterate) {
            this.transliterate = transliterate;
            return this;
        }

        public Builder useMaxSuggestions(int maxSuggestions) {
            this.maxSuggestions = maxSuggestions;
            return this;
        }

        public Builder useLocation(String location) {
            this.location = location;
            return this;
        }

        public Builder setFlattenResultsOption(boolean flattenResults) {
            this.flattenResults = flattenResults;
            return this;
        }

        public Builder useIntensityOption(Intensity intensity) {
            this.intensity = intensity;
            return this;
        }

        public Builder usePromptSetOption(PromptSet promptSet) {
            this.promptSet = promptSet;
            return this;
        }

        public Builder includeComponents() {
            this.components = true;
            return this;
        }

        public Builder includeMetadata() {
            this.metadata = true;
            return this;
        }
        public Builder includeEnrichment() {
            this.enrichment = true;
            return this;
        }

        public Builder includeExtraMatchInfo() {
            this.extraMatchInfo = true;
            return this;
        }

        public Builder setFormatLayoutName(String layoutName) {
            this.formatLayoutName = layoutName;
            return this;
        }

        public Builder useLayout(LayoutFormat layoutFormat) {
            this.layoutFormat = layoutFormat;
            return this;
        }

        public Builder includeGlobalGeocodeAttribute(GlobalGeocodeAttribute attribute) {
            this.globalGeocode.add(attribute);
            return this;
        }

        public Builder includeGlobalGeocodes() {
            this.globalGeocode = List.of(GlobalGeocodeAttribute.values());
            return this;
        }

        public Builder includePremiumLocationInsightAttribute(PremiumLocationInsightAttribute attribute) {
            this.premiumLocationInsights.add(attribute);
            return this;
        }

        public Builder includePremiumLocationInsight() {
            this.premiumLocationInsights = List.of(PremiumLocationInsightAttribute.values());
            return this;
        }

        public Builder includeWhat3WordsAttribute(What3WordsAttribute attribute) {
            this.what3Words.add(attribute);
            return this;
        }

        public Builder includeWhat3Words() {
            this.what3Words = List.of(What3WordsAttribute.values());
            return this;
        }

        public Builder includeAusRegionalGeocodeAttribute(AUSRegionalGeocode attribute) {
            this.ausRegionalGeocode.add(attribute);
            return this;
        }

        public Builder includeAusRegionalGeocode() {
            this.ausRegionalGeocode = List.of(AUSRegionalGeocode.values());
            return this;
        }

        public Builder includeNzlRegionalGeocodeAttribute(NZLRegionalGeocode attribute) {
            this.nzlRegionalGeocode.add(attribute);
            return this;
        }

        public Builder includeNzlRegionalGeocode() {
            this.nzlRegionalGeocode = List.of(NZLRegionalGeocode.values());
            return this;
        }

        public Builder includeUsaRegionalGeocodeAttribute(UsaRegionalGeocodeAttribute attribute) {
            this.usaRegionalGeocode.add(attribute);
            return this;
        }

        public Builder includeUsaRegionalGeocode() {
            this.usaRegionalGeocode = List.of(UsaRegionalGeocodeAttribute.values());
            return this;
        }

        public Builder includeLocationEssentialAttribute(GbrLocationEssentialAttribute attribute) {
            this.gbrLocationEssential.add(attribute);
            return this;
        }

        public Builder includeLocationEssential() {
            this.gbrLocationEssential = List.of(GbrLocationEssentialAttribute.values());
            return this;
        }

        public Builder includeLocationCompleteAttribute(GbrLocationCompleteAttribute attribute) {
            this.gbrLocationComplete.add(attribute);
            return this;
        }

        public Builder includeLocationComplete() {
            this.gbrLocationComplete = List.of(GbrLocationCompleteAttribute.values());
            return this;
        }

        public Builder includeBusinessAttribute(GbrBusinessAttribute attribute) {
            this.gbrBusiness.add(attribute);
            return this;
        }

        public Builder includeBusiness() {
            this.gbrBusiness = List.of(GbrBusinessAttribute.values());
            return this;
        }

        public Builder includeGovernmentAttribute(GbrGovernmentAttribute attribute) {
            this.gbrGovernment.add(attribute);
            return this;
        }

        public Builder includeGovernment() {
            this.gbrGovernment = List.of(GbrGovernmentAttribute.values());
            return this;
        }

        public Builder includeHealthAttribute(GBRHealth attribute) {
            this.gbrHealth.add(attribute);
            return this;
        }

        public Builder includeHealth() {
            this.gbrHealth = List.of(GBRHealth.values());
            return this;
        }

        public Builder useDataset(Dataset dataset) {
            return addDataset(dataset);
        }

        private Builder addDataset(Dataset dataset) {
            this.datasets.add(dataset);
            validateDatasets();
            return this;
        }

        private void validateDatasets() {
            if (datasets == null || datasets.isEmpty()) {
                throw new InvalidConfigurationException("The supplied configuration must contain a dataset");
            }
            final List<Country> countries = datasets.stream().map(Dataset::getCountry).toList();
            if (countries.size() > 1 && countries.stream().anyMatch(c -> !c.equals(Country.UNITED_KINGDOM))) {
                throw new InvalidConfigurationException("Multiple datasets are currently only supported for the United Kingdom");
            }
        }
    }
}