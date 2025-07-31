using DVSClient.Address.Format;
using DVSClient.Address.Layout.Attributes;
using DVSClient.Address.Lookup;
using DVSClient.Common;
using DVSClient.Exceptions;

namespace DVSClient.Address
{
    /// <summary>
    /// Configuration class for setting up the address client.
    /// Provides options for customizing address-related API requests.
    /// </summary>
    public class AddressConfiguration : Configuration
    {
        /// <summary>
        /// The default maximum number of suggestions to return for address searches.
        /// </summary>
        public const int DefaultMaxSuggestions = 7;

        /// <summary>
        /// The default layout name for address formatting.
        /// </summary>
        public const string DefaultLayoutName = "default";

        /// <summary>
        /// The default layout format for address formatting.
        /// </summary>
        public static readonly LayoutFormat DefaultLayoutFormat = Format.LayoutFormat.Default;

        internal bool Transliterate { get; }
        internal IEnumerable<Dataset> Datasets;
        internal int MaxSuggestions { get; }
        internal string Location { get; }
        internal bool FlattenResults { get; }
        internal Intensity? SearchIntensity { get; }
        internal PromptSet? PromptSet { get; }
        internal bool Components { get; }
        internal bool Metadata { get; }
        internal bool Enrichment { get; }
        internal bool ExtraMatchInfo { get; }
        internal string LayoutName { get; }
        internal LayoutFormat? LayoutFormat { get; }
        internal IEnumerable<GlobalGeocodeAttribute> GlobalGeocodes { get; }
        internal IEnumerable<PremiumLocationInsightAttribute> PremiumLocationInsights { get; }
        internal IEnumerable<What3WordsAttribute> What3Words { get; }
        internal IEnumerable<AusRegionalGeocodeAttribute> AusRegionalGeocodes { get; }
        internal IEnumerable<GbrLocationEssentialAttribute> GbrLocationEssential { get; }
        internal IEnumerable<GbrLocationCompleteAttribute> GbrLocationComplete { get; }
        internal IEnumerable<GbrBusinessAttribute> GbrBusiness { get; }
        internal IEnumerable<GbrGovernmentAttribute> GbrGovernment { get; }
        internal IEnumerable<GbrHealthAttribute> GbrHealth { get; }
        internal IEnumerable<NzlRegionalGeocodeAttribute> NzlRegionalGeocodes { get; }
        internal IEnumerable<UsaRegionalGeocodeAttribute> UsaRegionalGeocodes { get; }
        internal bool LookupAddAddresses { get; }
        internal bool LookupAddFinalAddress { get; }
        internal int LookupMaxAddresses { get; }
        internal IEnumerable<LookupLocality> LookupAttributesLocality { get; }
        internal IEnumerable<LookupPostalCode> LookupAttributesPostalCode { get; }

        /// <summary>
        /// Retrieves the country associated with the first dataset in the configuration.
        /// </summary>
        /// <returns>The country of the first dataset, or null if no datasets are configured.</returns>
        internal Country? GetCountry()
        {
            if (this.Datasets == null || !this.Datasets.Any())
            {
                return null;
            }
            return Datasets.ElementAt(0).Country;
        } 

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressConfiguration"/> class using the specified builder.
        /// </summary>
        /// <param name="builder">The builder containing the configuration settings.</param>
        protected AddressConfiguration(AddressBuilder builder) : base(builder)
        {
            this.Transliterate = builder.Transliterate;
            this.Datasets = builder.Datasets.ToList();
            this.MaxSuggestions = builder.MaxSuggestions;
            this.Location = builder.Location;
            this.FlattenResults = builder.FlattenResults;
            this.SearchIntensity = builder.SearchIntensity;
            this.PromptSet = builder.PromptSet;
            this.Components = builder.Components;
            this.Metadata = builder.Metadata;
            this.Enrichment = builder.Enrichment;
            this.ExtraMatchInfo = builder.ExtraMatchInfo;
            this.LayoutName = builder.LayoutName;
            this.LayoutFormat = builder.LayoutFormat;
            this.GlobalGeocodes = builder.GlobalGeocodes.ToList();
            this.PremiumLocationInsights = builder.PremiumLocationInsights.ToList();
            this.What3Words = builder.What3Words.ToList();
            this.AusRegionalGeocodes = builder.AusRegionalGeocodes.ToList();
            this.GbrLocationEssential = builder.GbrLocationEssential.ToList();
            this.GbrLocationComplete = builder.GbrLocationComplete.ToList();
            this.GbrBusiness = builder.GbrBusiness.ToList();
            this.GbrGovernment = builder.GbrGovernment.ToList();
            this.GbrHealth = builder.GbrHealth.ToList();
            this.NzlRegionalGeocodes = builder.NzlRegionalGeocodes.ToList();
            this.UsaRegionalGeocodes = builder.UsaRegionalGeocodes.ToList();
            this.LookupAddAddresses = builder.LookupAddAddresses;
            this.LookupAddFinalAddress = builder.LookupAddFinalAddress;
            this.LookupMaxAddresses = builder.LookupMaxAddresses;
            this.LookupAttributesLocality = builder.LookupAttributesLocality.ToList();
            this.LookupAttributesPostalCode = builder.LookupAttributesPostalCode.ToList();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AddressBuilder"/> class to configure the address client.
        /// </summary>
        /// <param name="token">Optional authentication token for the API.</param>
        /// <returns>A new instance of the <see cref="AddressBuilder"/> class.</returns>
        public static AddressBuilder NewBuilder(string? token = "")
        {
            return new AddressBuilder(token);
        }

        /// <summary>
        /// Builder class for constructing a <see cref="AddressConfiguration"/> object with custom settings.
        /// </summary>
        public class AddressBuilder : Builder
        {
            internal bool Transliterate { get; private set; }
            internal IEnumerable<Dataset> Datasets { get; private set; } = new List<Dataset>();
            internal int MaxSuggestions { get; private set; } = DefaultMaxSuggestions;
            internal string Location { get; private set; } = string.Empty;
            internal bool FlattenResults { get; private set; }
            internal Intensity? SearchIntensity { get; private set; } = null;
            internal PromptSet? PromptSet { get; private set; } = null;
            internal bool Components { get; private set; }
            internal bool Metadata { get; set; }
            internal bool Enrichment { get; private set; }
            internal bool ExtraMatchInfo { get; private set; }
            internal string LayoutName { get; private set; } = DefaultLayoutName;
            internal LayoutFormat LayoutFormat { get; private set; } = DefaultLayoutFormat;
            internal IList<GlobalGeocodeAttribute> GlobalGeocodes { get; private set; } = new List<GlobalGeocodeAttribute>();
            internal IList<PremiumLocationInsightAttribute> PremiumLocationInsights { get; private set; } = new List<PremiumLocationInsightAttribute>();
            internal IList<What3WordsAttribute> What3Words { get; private set; } = new List<What3WordsAttribute>();
            internal IList<AusRegionalGeocodeAttribute> AusRegionalGeocodes { get; private set; } = new List<AusRegionalGeocodeAttribute>();
            internal IList<GbrLocationEssentialAttribute> GbrLocationEssential { get; private set; } = new List<GbrLocationEssentialAttribute>();
            internal IList<GbrLocationCompleteAttribute> GbrLocationComplete { get; private set; } = new List<GbrLocationCompleteAttribute>();
            internal IList<GbrBusinessAttribute> GbrBusiness { get; private set; } = new List<GbrBusinessAttribute>();
            internal IList<GbrGovernmentAttribute> GbrGovernment { get; private set; } = new List<GbrGovernmentAttribute>();
            internal IList<GbrHealthAttribute> GbrHealth { get; private set; } = new List<GbrHealthAttribute>();
            internal IList<NzlRegionalGeocodeAttribute> NzlRegionalGeocodes { get; private set; } = new List<NzlRegionalGeocodeAttribute>();
            internal IList<UsaRegionalGeocodeAttribute> UsaRegionalGeocodes { get; private set; } = new List<UsaRegionalGeocodeAttribute>();
            internal bool LookupAddAddresses { get; private set; }
            internal bool LookupAddFinalAddress { get; private set; }
            internal int LookupMaxAddresses { get; private set; }
            internal IEnumerable<LookupLocality> LookupAttributesLocality { get; private set;} = new List<LookupLocality>();
            internal IEnumerable<LookupPostalCode> LookupAttributesPostalCode { get; private set;} = new List<LookupPostalCode>();

            /// <summary>
            /// Initializes a new instance of the <see cref="AddressBuilder"/> class with an optional token.
            /// </summary>
            /// <param name="token">Optional authentication token for the API.</param>
            public AddressBuilder(string? token = "") : base(token)
            {
            }

            /// <summary>
            /// Enables authentication via the x-app-key header for the configuration.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder SetUseXAppAuthentication()
            {
                base.SetUseXAppAuthentication(true);
                return this;
            }

            /// <summary>
            /// Sets the maximum delay for retrying API requests.
            /// </summary>
            /// <param name="maxDelay">The maximum delay in milliseconds.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public new AddressBuilder SetMaxDelay(int maxDelay)
            {
                base.SetMaxDelay(maxDelay);
                return this;
            }

            /// <summary>
            /// Sets the initial delay for retrying API requests.
            /// </summary>
            /// <param name="initialDelay">The initial delay in milliseconds.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public new AddressBuilder SetInitialDelay(int initialDelay)
            {
                base.SetInitialDelay(initialDelay);
                return this;
            }

            /// <summary>
            /// Sets the maximum number of retries for API requests.
            /// </summary>
            /// <param name="maxRetries">The maximum number of retries.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public new AddressBuilder SetMaxRetries(int maxRetries)
            {
                base.SetMaxRetries(maxRetries);
                return this;
            }

            /// <summary>
            /// Sets the timeout for API requests in seconds.
            /// </summary>
            /// <param name="timeouts">The timeout duration in seconds.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public new AddressBuilder SetApiRequestTimeoutInSeconds(int timeouts)
            {
                base.SetApiRequestTimeoutInSeconds(timeouts);
                return this;
            }

            /// <summary>
            /// Sets the timeout for the HTTP client in seconds.
            /// </summary>
            /// <param name="timeouts">The timeout duration in seconds.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public new AddressBuilder SetHttpClientTimeoutInSeconds(int timeouts)
            {
                base.SetHttpClientTimeoutInSeconds(timeouts);
                return this;
            }

            /// <summary>
            /// Sets a custom reference ID for API requests.
            /// </summary>
            /// <param name="referenceId">The reference ID for tracking the request.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            [Obsolete("Set your reference ID as part every API interaction like the Search, Format, or Validate call instead.")]
            public new AddressBuilder SetTransactionId(string referenceId)
            {
                base.SetTransactionId(referenceId);
                return this;
            }

            /// <summary>
            /// Enables transliteration for address data.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder SetTransliterate()
            {
                this.Transliterate = true;
                return this;
            }

            /// <summary>
            /// Sets the maximum number of suggestions to return for address searches.
            /// </summary>
            /// <param name="maxSuggestions">The maximum number of suggestions.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder UseMaxSuggestions(int maxSuggestions)
            {
                this.MaxSuggestions = maxSuggestions;
                return this;
            }

            /// <summary>
            /// Sets the location for address searches.
            /// </summary>
            /// <param name="location">The location to use for searches.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder UseLocation(string location)
            {
                this.Location = location;
                return this;
            }

            /// <summary>
            /// Enables the option to flatten results in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder SetFlattenResultsOption()
            {
                this.FlattenResults = true;
                return this;
            }

            /// <summary>
            /// Sets the search intensity for address searches.
            /// </summary>
            /// <param name="searchIntensity">The search intensity to use.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder UseIntensityOption(Intensity searchIntensity)
            {
                this.SearchIntensity = searchIntensity;
                return this;
            }

            /// <summary>
            /// Sets the prompt set to use for address searches.
            /// </summary>
            /// <param name="promptSet">The prompt set to use.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder UsePromptSetOption(PromptSet promptSet)
            {
                this.PromptSet = promptSet;
                return this;
            }

            /// <summary>
            /// Includes address components in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeComponents()
            {
                this.Components = true;
                return this;
            }

            /// <summary>
            /// Includes metadata in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeMetadata()
            {
                this.Metadata = true;
                return this;
            }

            /// <summary>
            /// Includes enrichment data in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeEnrichment()
            {
                this.Enrichment = true;
                return this;
            }

            /// <summary>
            /// Includes extra match information in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeExtraMatchInfo()
            {
                this.ExtraMatchInfo = true;
                return this;
            }

            /// <summary>
            /// Sets the layout name for address formatting.
            /// </summary>
            /// <param name="layoutName">The layout name to use.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder UseLayoutName(string layoutName)
            {
                this.LayoutName = layoutName;
                return this;
            }

            /// <summary>
            /// Sets the layout format for address formatting.
            /// </summary>
            /// <param name="layoutFormat">The layout format to use.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder UseLayoutFormat(LayoutFormat layoutFormat)
            {
                this.LayoutFormat = layoutFormat;
                return this;
            }


            /// <summary>
            /// Includes a specific global geocode attribute in the API response.
            /// </summary>
            /// <param name="attribute">The global geocode attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGlobalGeocodeAttribute(GlobalGeocodeAttribute attribute)
            {
                this.GlobalGeocodes.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all global geocode attributes in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGlobalGeocodes()
            {
                this.GlobalGeocodes = EnumExtensions.GetAllEnumValues<GlobalGeocodeAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific premium location insight attribute in the API response.
            /// </summary>
            /// <param name="attribute">The premium location insight attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludePremiumLocationInsightsAttribute(PremiumLocationInsightAttribute attribute)
            {
                this.PremiumLocationInsights.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all premium location insight attributes in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludePremiumLocationInsights()
            {
                this.PremiumLocationInsights = EnumExtensions.GetAllEnumValues<PremiumLocationInsightAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific What3Words attribute in the API response.
            /// </summary>
            /// <param name="attribute">The What3Words attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeWhat3WordsAttribute(What3WordsAttribute attribute)
            {
                this.What3Words.Append(attribute);
                return this;
            }

            /// <summary>
            /// Includes all What3Words attributes in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeWhat3Words()
            {
                this.What3Words = EnumExtensions.GetAllEnumValues<What3WordsAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific Australian regional geocode attribute in the API response.
            /// </summary>
            /// <param name="attribute">The Australian regional geocode attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeAusRegionalGeocodeAttribute(AusRegionalGeocodeAttribute attribute)
            {
                this.AusRegionalGeocodes.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all Australian regional geocode attributes in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeAusRegionalGeocodes()
            {
                this.AusRegionalGeocodes = EnumExtensions.GetAllEnumValues<AusRegionalGeocodeAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific essential location attribute for Great Britain in the API response.
            /// </summary>
            /// <param name="attribute">The Great Britain essential location attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrLocationEssentialAttribute(GbrLocationEssentialAttribute attribute)
            {
                this.GbrLocationEssential.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all essential location attributes for Great Britain in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrLocationEssential()
            {
                this.GbrLocationEssential = EnumExtensions.GetAllEnumValues<GbrLocationEssentialAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific complete location attribute for Great Britain in the API response.
            /// </summary>
            /// <param name="attribute">The Great Britain complete location attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrLocationCompleteAttribute(GbrLocationCompleteAttribute attribute)
            {
                this.GbrLocationComplete.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all complete location attributes for Great Britain in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrLocationComplete()
            {
                this.GbrLocationComplete = EnumExtensions.GetAllEnumValues<GbrLocationCompleteAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific business attribute for Great Britain in the API response.
            /// </summary>
            /// <param name="attribute">The Great Britain business attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrBusinessAttribute(GbrBusinessAttribute attribute)
            {
                this.GbrBusiness.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all business attributes for Great Britain in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrBusiness()
            {
                this.GbrBusiness = EnumExtensions.GetAllEnumValues<GbrBusinessAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific government attribute for Great Britain in the API response.
            /// </summary>
            /// <param name="attribute">The Great Britain government attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrGovernmentAttribute(GbrGovernmentAttribute attribute)
            {
                this.GbrGovernment.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all government attributes for Great Britain in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrGovernment()
            {
                this.GbrGovernment = EnumExtensions.GetAllEnumValues<GbrGovernmentAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific health attribute for Great Britain in the API response.
            /// </summary>
            /// <param name="attribute">The Great Britain health attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrHalthAttribute(GbrHealthAttribute attribute)
            {
                this.GbrHealth.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all health attributes for Great Britain in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeGbrHalth()
            {
                this.GbrHealth = EnumExtensions.GetAllEnumValues<GbrHealthAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific regional geocode attribute for New Zealand in the API response.
            /// </summary>
            /// <param name="attribute">The New Zealand regional geocode attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeNzlRegionalGeocodeAttribute(NzlRegionalGeocodeAttribute attribute)
            {
                this.NzlRegionalGeocodes.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all regional geocode attributes for New Zealand in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeNzlRegionalGeocodes()
            {
                this.NzlRegionalGeocodes = EnumExtensions.GetAllEnumValues<NzlRegionalGeocodeAttribute>();
                return this;
            }

            /// <summary>
            /// Includes a specific regional geocode attribute for the United States in the API response.
            /// </summary>
            /// <param name="attribute">The United States regional geocode attribute to include.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeUsaRegionalGeocodeAttribute(UsaRegionalGeocodeAttribute attribute)
            {
                this.UsaRegionalGeocodes.Add(attribute);
                return this;
            }

            /// <summary>
            /// Includes all regional geocode attributes for the United States in the API response.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder IncludeUsaRegionalGeocodes()
            {
                this.UsaRegionalGeocodes = EnumExtensions.GetAllEnumValues<UsaRegionalGeocodeAttribute>();
                return this;
            }

            /// <summary>
            /// Adds a dataset to the configuration.
            /// </summary>
            /// <param name="dataset">The dataset to add.</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder UseDataset(Dataset dataset)
            {
                return AddDataset(dataset);
            }

            /// <summary>
            /// Builds the <see cref="AddressConfiguration"/> object with the specified settings.
            /// </summary>
            /// <returns>A new instance of the <see cref="AddressConfiguration"/> class.</returns>
            public override AddressConfiguration Build()
            {
                return new AddressConfiguration(this);
            }

            /// <summary>
            /// Specifies if the response should contain a list of matched addresses.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder SetLookupAddAddresses()
            {
                this.LookupAddAddresses = true;
                return this;
            }

            /// <summary>
            /// Specifies if the response should contain a list of matched formatted addresses.
            /// </summary>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder SetLookupAddFinalAddress()
            {
                this.LookupAddFinalAddress = true;
                return this;
            }

            /// <summary>
            /// The maximum number of addresses you want to get returned (1-1000)
            /// Only applicable if SetLookupAddAddresses() has been called.
            /// The default value of this setting is 100.
            /// </summary>
            /// <param name="maxAddresses">The number of addresses</param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder SetLookupMaxAddressses(int maxAddresses)
            {
                this.LookupMaxAddresses = maxAddresses;
                return this;
            }

            /// <summary>
            /// Specifies the locality types you want in the response from a lookup.
            /// </summary>
            /// <param name="lookupLocality"></param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder AddLookupAttributeLocality(LookupLocality lookupLocality) 
            {
                this.LookupAttributesLocality  = this.LookupAttributesLocality.Append(lookupLocality);
                return this;
            }

            /// <summary>
            /// Specifies the postal code types you want in the response from a lookup.
            /// </summary>
            /// <param name="lookupLocality"></param>
            /// <returns>The current <see cref="AddressBuilder"/> instance for method chaining.</returns>
            public AddressBuilder AddLookupAttributePostalCode(LookupPostalCode postalCode) 
            {
                this.LookupAttributesPostalCode = this.LookupAttributesPostalCode.Append(postalCode);
                return this;
            }

            private AddressBuilder AddDataset(Dataset dataset)
            {
                this.Datasets = this.Datasets.Append(dataset);
                ValidateDatasets();
                return this;
            }

            private void ValidateDatasets()
            {
                if (this.Datasets == null || this.Datasets.Count() == 0)
                {
                    throw new InvalidConfigurationException("The supplied configuration must contain a dataset");
                }

                var countries = this.Datasets.ToList().ConvertAll(dataset => dataset.Country);
                if (countries.Count > 1 && countries.Exists(c => !c.Equals(Country.UnitedKingdom)))
                {
                    throw new InvalidConfigurationException("Multiple datasets are currently only supported for the United Kingdom");
                }
            }
        }
    }
}
