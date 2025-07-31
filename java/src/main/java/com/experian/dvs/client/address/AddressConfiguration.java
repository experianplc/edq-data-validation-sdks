package com.experian.dvs.client.address;

import com.experian.dvs.client.address.format.LayoutFormat;
import com.experian.dvs.client.address.layout.attributes.*;
import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;

import java.util.ArrayList;
import java.util.List;

/**
 * AddressConfiguration class for setting up the address client.
 * Provides options for customizing address-related API requests.
 */
public class AddressConfiguration extends com.experian.dvs.client.common.Configuration {

    /**
     * The default maximum number of suggestions to return for address searches.
     */
    public static final int DEFAULT_MAX_SUGGESTIONS = 7;

    /**
     * The default layout name for address formatting.
     */
    public static final String DEFAULT_LAYOUT_NAME = "default";

    /**
     * The default layout format for address formatting.
     */
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
    private final String layoutName;
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

    /**
     * Initializes a new instance of the {@link AddressConfiguration} class using the specified builder.
     *
     * @param builder The builder containing the configuration settings.
     */
    protected AddressConfiguration(AddressBuilder builder) {
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
        this.layoutName = builder.layoutName;
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

    /**
     * Creates a new instance of the {@link AddressBuilder} class to configure the address client.
     *
     * @param token The authentication token for the API.
     * @return A new instance of the {@link AddressBuilder} class.
     */
    public static AddressBuilder newBuilder(String token) {
        return new AddressBuilder(token);
    }

    /**
     * Retrieves the transliteration setting for the configuration.
     *
     * @return True if transliteration is enabled; otherwise, false.
     */
    public boolean getTransliterate() {
        return this.transliterate;
    }

    /**
     * Retrieves the list of datasets configured for the client.
     *
     * @return A list of {@link Dataset} objects.
     */
    public List<Dataset> getDatasets() {
        return datasets;
    }

    /**
     * Checks if a specific dataset is included in the configuration.
     *
     * @param dataset The dataset to check.
     * @return True if the dataset is included; otherwise, false.
     */
    protected boolean hasDataset(Dataset dataset) {
        return this.datasets.contains(dataset);
    }

    /**
     * Retrieves the maximum number of suggestions configured for address searches.
     *
     * @return The maximum number of suggestions.
     */
    public int getMaxSuggestions() {
        return maxSuggestions;
    }

    /**
     * Retrieves the country associated with the first dataset in the configuration.
     *
     * @return The {@link Country} of the first dataset, or null if no datasets are configured.
     */
    public Country getCountry() {
        if (this.datasets == null || this.datasets.isEmpty()) {
            return null;
        }
        return datasets.get(0).getCountry();
    }

    /**
     * Retrieves the location setting for the configuration.
     *
     * @return The location as a string.
     */
    public String getLocation() {
        return location;
    }

    /**
     * Retrieves the components setting for the configuration.
     *
     * @return True if components are included; otherwise, false.
     */
    public boolean getComponents() {
        return components;
    }

    /**
     * Retrieves the metadata setting for the configuration.
     *
     * @return True if metadata is included; otherwise, false.
     */
    public boolean getMetadata() {
        return metadata;
    }

    /**
     * Retrieves the enrichment setting for the configuration.
     *
     * @return True if enrichment is included; otherwise, false.
     */
    public boolean getEnrichment() {
        return enrichment;
    }

    /**
     * Retrieves the layout name for address formatting.
     *
     * @return The layout name as a string.
     */
    public String getLayoutName() {
        return layoutName;
    }

    /**
     * Retrieves the layout format for address formatting.
     *
     * @return The {@link LayoutFormat} object.
     */
    public LayoutFormat getLayoutFormat() {
        return layoutFormat;
    }

    /**
     * Retrieves the list of global geocode attributes configured for the client.
     *
     * @return A list of {@link GlobalGeocodeAttribute} objects.
     */
    public List<GlobalGeocodeAttribute> getGeocodes() {
        return geocodes;
    }

    /**
     * Retrieves the list of premium location insight attributes configured for the client.
     *
     * @return A list of {@link PremiumLocationInsightAttribute} objects.
     */
    public List<PremiumLocationInsightAttribute> getPremiumLocationInsights() {
        return premiumLocationInsights;
    }

    /**
     * Retrieves the list of What3Words attributes configured for the client.
     *
     * @return A list of {@link What3WordsAttribute} objects.
     */
    public List<What3WordsAttribute> getWhat3Words() {
        return what3Words;
    }

    /**
     * Retrieves the extra match information setting for the configuration.
     *
     * @return True if extra match information is included; otherwise, false.
     */
    public boolean getExtraMatchInfo() {
        return extraMatchInfo;
    }

    /**
     * Retrieves the flatten results setting for the configuration.
     *
     * @return True if results are flattened; otherwise, false.
     */
    public boolean getFlattenResults() {
        return flattenResults;
    }

    /**
     * Retrieves the search intensity setting for the configuration.
     *
     * @return The {@link Intensity} object.
     */
    public Intensity getSearchIntensity() {
        return intensity;
    }

    /**
     * Retrieves the prompt set setting for the configuration.
     *
     * @return The {@link PromptSet} object.
     */
    public PromptSet getPromptSet() {
        return promptSet;
    }

    /**
     * Retrieves the list of Australian regional geocode attributes configured for the client.
     *
     * @return A list of {@link AUSRegionalGeocode} objects.
     */
    public List<AUSRegionalGeocode> getAusRegionalGeocodeAttributes() {
        return ausRegionalGeocodes;
    }

    /**
     * Retrieves the list of New Zealand regional geocode attributes configured for the client.
     *
     * @return A list of {@link NZLRegionalGeocode} objects.
     */
    public List<NZLRegionalGeocode> getNzlRegionalGeocodeAttributes() {
        return nzlRegionalGeocodes;
    }

    /**
     * Retrieves the list of United States regional geocode attributes configured for the client.
     *
     * @return A list of {@link UsaRegionalGeocodeAttribute} objects.
     */
    public List<UsaRegionalGeocodeAttribute> getUsaRegionalGeocodeAttributes() {
        return usaRegionalGeocodes;
    }

    /**
     * Retrieves the list of business attributes for Great Britain configured for the client.
     *
     * @return A list of {@link GbrBusinessAttribute} objects.
     */
    public List<GbrBusinessAttribute> getBusinessAttributes() {
        return gbrBusiness;
    }

    /**
     * Retrieves the list of government attributes for Great Britain configured for the client.
     *
     * @return A list of {@link GbrGovernmentAttribute} objects.
     */
    public List<GbrGovernmentAttribute> getGovernmentAttributes() {
        return gbrGovernment;
    }

    /**
     * Retrieves the list of health attributes for Great Britain configured for the client.
     *
     * @return A list of {@link GBRHealth} objects.
     */
    public List<GBRHealth> getHealthAttributes() {
        return gbrHealth;
    }

    /**
     * Retrieves the list of complete location attributes for Great Britain configured for the client.
     *
     * @return A list of {@link GbrLocationCompleteAttribute} objects.
     */
    public List<GbrLocationCompleteAttribute> getLocationCompleteAttributes() {
        return gbrLocationComplete;
    }

    /**
     * Retrieves the list of essential location attributes for Great Britain configured for the client.
     *
     * @return A list of {@link GbrLocationEssentialAttribute} objects.
     */
    public List<GbrLocationEssentialAttribute> getLocationEssentialAttributes() {
        return gbrLocationEssential;
    }

    /**
     * AddressBuilder class for constructing a {@link AddressConfiguration} object with custom settings.
     */
    public static class AddressBuilder extends com.experian.dvs.client.common.Configuration.Builder {

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
        private String layoutName = "";
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

        /**
         * Initializes a new instance of the {@link AddressBuilder} class with the specified token.
         *
         * @param token The authentication token for the API.
         */
        public AddressBuilder(String token) {
            super(token);
            maxSuggestions = DEFAULT_MAX_SUGGESTIONS;
            layoutFormat = DEFAULT_LAYOUT_FORMAT;
            layoutName = DEFAULT_LAYOUT_NAME;
        }

        /**
         * Builds the {@link AddressConfiguration} object with the specified settings.
         *
         * @return A new instance of the {@link AddressConfiguration} class.
         */
        public AddressConfiguration build() {
            return new AddressConfiguration(this);
        }

        /**
         * Sets a custom transaction ID for API requests.
         *
         * @param referenceId The transaction ID to use.
         * @return The current {@link AddressBuilder} instance for method chaining.
         * @deprecated Set your reference ID as part every API interaction like the Search, Format, or Validate call instead.
         */
        @Deprecated(since="1.1.10", forRemoval=true)
        public AddressBuilder setTransactionId(String referenceId) {
            super.setTransactionId(referenceId);
            return this;
        }

        /**
         * Enables or disables authentication via the x-app-key header for the configuration.
         *
         * @param useXAppAuthentication True to enable x-app-key authentication; otherwise, false.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder setUseXAppAuthentication(boolean useXAppAuthentication) {
            super.setUseXAppAuthentication(useXAppAuthentication);
            return this;
        }

        /**
         * Enables or disables transliteration for address data.
         *
         * @param transliterate True to enable transliteration; otherwise, false.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder setTransliterate(boolean transliterate) {
            this.transliterate = transliterate;
            return this;
        }

        /**
         * Sets the maximum number of suggestions to return for address searches.
         *
         * @param maxSuggestions The maximum number of suggestions.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder useMaxSuggestions(int maxSuggestions) {
            this.maxSuggestions = maxSuggestions;
            return this;
        }

        /**
         * Sets the location for address searches.
         *
         * @param location The location to use for searches.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder useLocation(String location) {
            this.location = location;
            return this;
        }

        /**
         * Enables or disables the option to flatten results in the API response.
         *
         * @param flattenResults True to flatten results; otherwise, false.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder setFlattenResultsOption(boolean flattenResults) {
            this.flattenResults = flattenResults;
            return this;
        }

        /**
         * Sets the search intensity for address searches.
         *
         * @param intensity The search intensity to use.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder useIntensityOption(Intensity intensity) {
            this.intensity = intensity;
            return this;
        }

        /**
         * Sets the prompt set to use for address searches.
         *
         * @param promptSet The prompt set to use.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder usePromptSetOption(PromptSet promptSet) {
            this.promptSet = promptSet;
            return this;
        }

        /**
         * Includes address components in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeComponents() {
            this.components = true;
            return this;
        }

        /**
         * Includes metadata in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeMetadata() {
            this.metadata = true;
            return this;
        }

        /**
         * Includes enrichment data in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeEnrichment() {
            this.enrichment = true;
            return this;
        }

        /**
         * Includes extra match information in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeExtraMatchInfo() {
            this.extraMatchInfo = true;
            return this;
        }

        /**
         * Sets the layout name for address formatting.
         *
         * @param layoutName The layout name to use.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder useLayoutName(String layoutName) {
            this.layoutName = layoutName;
            return this;
        }

        /**
         * Sets the layout format for address formatting.
         *
         * @param layoutFormat The layout format to use.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder useLayoutFormat(LayoutFormat layoutFormat) {
            this.layoutFormat = layoutFormat;
            return this;
        }

        /**
         * Includes a specific global geocode attribute in the API response.
         *
         * @param attribute The global geocode attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeGlobalGeocodeAttribute(GlobalGeocodeAttribute attribute) {
            this.globalGeocode.add(attribute);
            return this;
        }

        /**
         * Includes all global geocode attributes in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeGlobalGeocodes() {
            this.globalGeocode = List.of(GlobalGeocodeAttribute.values());
            return this;
        }

        /**
         * Includes a specific premium location insight attribute in the API response.
         *
         * @param attribute The premium location insight attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includePremiumLocationInsightAttribute(PremiumLocationInsightAttribute attribute) {
            this.premiumLocationInsights.add(attribute);
            return this;
        }

        /**
         * Includes all premium location insight attributes in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includePremiumLocationInsight() {
            this.premiumLocationInsights = List.of(PremiumLocationInsightAttribute.values());
            return this;
        }

        /**
         * Includes a specific What3Words attribute in the API response.
         *
         * @param attribute The What3Words attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeWhat3WordsAttribute(What3WordsAttribute attribute) {
            this.what3Words.add(attribute);
            return this;
        }

        /**
         * Includes all What3Words attributes in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeWhat3Words() {
            this.what3Words = List.of(What3WordsAttribute.values());
            return this;
        }

        /**
         * Includes a specific Australian regional geocode attribute in the API response.
         *
         * @param attribute The Australian regional geocode attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeAusRegionalGeocodeAttribute(AUSRegionalGeocode attribute) {
            this.ausRegionalGeocode.add(attribute);
            return this;
        }

        /**
         * Includes all Australian regional geocode attributes in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeAusRegionalGeocodes() {
            this.ausRegionalGeocode = List.of(AUSRegionalGeocode.values());
            return this;
        }

        /**
         * Includes a specific New Zealand regional geocode attribute in the API response.
         *
         * @param attribute The New Zealand regional geocode attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeNzlRegionalGeocodeAttribute(NZLRegionalGeocode attribute) {
            this.nzlRegionalGeocode.add(attribute);
            return this;
        }

        /**
         * Includes all New Zealand regional geocode attributes in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeNzlRegionalGeocodes() {
            this.nzlRegionalGeocode = List.of(NZLRegionalGeocode.values());
            return this;
        }

        /**
         * Includes a specific United States regional geocode attribute in the API response.
         *
         * @param attribute The United States regional geocode attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeUsaRegionalGeocodeAttribute(UsaRegionalGeocodeAttribute attribute) {
            this.usaRegionalGeocode.add(attribute);
            return this;
        }

        /**
         * Includes all United States regional geocode attributes in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeUsaRegionalGeocodes() {
            this.usaRegionalGeocode = List.of(UsaRegionalGeocodeAttribute.values());
            return this;
        }

        /**
         * Includes a specific essential location attribute for Great Britain in the API response.
         *
         * @param attribute The Great Britain essential location attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeLocationEssentialAttribute(GbrLocationEssentialAttribute attribute) {
            this.gbrLocationEssential.add(attribute);
            return this;
        }

        /**
         * Includes all essential location attributes for Great Britain in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeLocationEssential() {
            this.gbrLocationEssential = List.of(GbrLocationEssentialAttribute.values());
            return this;
        }

        /**
         * Includes a specific complete location attribute for Great Britain in the API response.
         *
         * @param attribute The Great Britain complete location attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeLocationCompleteAttribute(GbrLocationCompleteAttribute attribute) {
            this.gbrLocationComplete.add(attribute);
            return this;
        }

        /**
         * Includes all complete location attributes for Great Britain in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeLocationComplete() {
            this.gbrLocationComplete = List.of(GbrLocationCompleteAttribute.values());
            return this;
        }

        /**
         * Includes a specific business attribute for Great Britain in the API response.
         *
         * @param attribute The Great Britain business attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeBusinessAttribute(GbrBusinessAttribute attribute) {
            this.gbrBusiness.add(attribute);
            return this;
        }

        /**
         * Includes all business attributes for Great Britain in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeBusiness() {
            this.gbrBusiness = List.of(GbrBusinessAttribute.values());
            return this;
        }

        /**
         * Includes a specific government attribute for Great Britain in the API response.
         *
         * @param attribute The Great Britain government attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeGovernmentAttribute(GbrGovernmentAttribute attribute) {
            this.gbrGovernment.add(attribute);
            return this;
        }

        /**
         * Includes all government attributes for Great Britain in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeGovernment() {
            this.gbrGovernment = List.of(GbrGovernmentAttribute.values());
            return this;
        }

        /**
         * Includes a specific health attribute for Great Britain in the API response.
         *
         * @param attribute The Great Britain health attribute to include.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeHealthAttribute(GBRHealth attribute) {
            this.gbrHealth.add(attribute);
            return this;
        }

        /**
         * Includes all health attributes for Great Britain in the API response.
         *
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder includeHealth() {
            this.gbrHealth = List.of(GBRHealth.values());
            return this;
        }

        /**
         * Adds a dataset to the configuration.
         *
         * @param dataset The dataset to add.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        public AddressBuilder useDataset(Dataset dataset) {
            return addDataset(dataset);
        }

        /**
         * Adds a dataset to the configuration and validates the datasets.
         *
         * @param dataset The dataset to add.
         * @return The current {@link AddressBuilder} instance for method chaining.
         */
        private AddressBuilder addDataset(Dataset dataset) {
            this.datasets.add(dataset);
            validateDatasets();
            return this;
        }

        /**
         * Validates the datasets to ensure they meet the configuration requirements.
         * Throws an {@link InvalidConfigurationException} if the validation fails.
         */
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
