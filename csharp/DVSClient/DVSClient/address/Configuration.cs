using DVSClient.Address.Format;
using DVSClient.Address.Layout.Attributes;
using DVSClient.Common;
using DVSClient.Exceptions;

namespace DVSClient.Address
{
    public class Configuration : Common.Configuration
    {
        public const int DefaultMaxSuggestions = 7;
        public const string DefaultLayoutName = "default";
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
        internal string FormatLayoutName { get; }
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

        internal Country? GetCountry()
        {
            if (this.Datasets == null || !this.Datasets.Any())
            {
                return null;
            }
            return Datasets.ElementAt(0).Country;
        }

        protected Configuration(Builder builder) : base(builder)
        {
            this.Transliterate = builder.Transliterate;
            this.Datasets = builder.Datasets;
            this.MaxSuggestions = builder.MaxSuggestions;
            this.Location = builder.Location;
            this.FlattenResults = builder.FlattenResults;
            this.SearchIntensity = builder.SearchIntensity;
            this.PromptSet = builder.PromptSet;
            this.Components = builder.Components;
            this.Metadata = builder.Metadata;
            this.Enrichment = builder.Enrichment;
            this.ExtraMatchInfo = builder.ExtraMatchInfo;
            this.FormatLayoutName = builder.FormatLayoutName;
            this.LayoutFormat = builder.LayoutFormat;
            this.GlobalGeocodes = builder.GlobalGeocodes;
            this.PremiumLocationInsights = builder.PremiumLocationInsights;
            this.What3Words = builder.What3Words;
            this.AusRegionalGeocodes = builder.AusRegionalGeocodes;
            this.GbrLocationEssential = builder.GbrLocationEssential;
            this.GbrLocationComplete = builder.GbrLocationComplete;
            this.GbrBusiness = builder.GbrBusiness;
            this.GbrGovernment = builder.GbrGovernment;
            this.GbrHealth = builder.GbrHealth;
            this.NzlRegionalGeocodes = builder.NzlRegionalGeocodes;
            this.UsaRegionalGeocodes = builder.UsaRegionalGeocodes;
        }

        public static Builder NewBuilder(string? token = "")
        {
            return new Builder(token);
        }

        public new class Builder : Common.Configuration.Builder
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
            internal string FormatLayoutName { get; private set; } = DefaultLayoutName;
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

            public Builder(string? token = "") : base(token)
            {
            }

            public Builder SetUseXAppAuthentication()
            {
                base.SetUseXAppAuthentication(true);
                return this;
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

            public Builder SetTransliterate()
            {
                this.Transliterate = true;
                return this;
            }

            public Builder UseMaxSuggestions(int maxSuggestions)
            {
                this.MaxSuggestions = maxSuggestions;
                return this;
            }

            public Builder UseLocation(string location)
            {
                this.Location = location;
                return this;
            }

            public Builder SetFlattenResultsOption()
            {
                this.FlattenResults = true;
                return this;
            }

            public Builder UseIntensityOption(Intensity searchIntensity)
            {
                this.SearchIntensity = searchIntensity;
                return this;
            }

            public Builder UsePromptSetOption(PromptSet promptSet)
            {
                this.PromptSet = promptSet;
                return this;
            }

            public Builder IncludeComponents()
            {
                this.Components = true;
                return this;
            }

            public Builder IncludeMetadata()
            {
                this.Metadata = true;
                return this;
            }

            public Builder IncludeEnrichment()
            {
                this.Enrichment = true;
                return this;
            }

            public Builder IncludeExtraMatchInfo()
            {
                this.ExtraMatchInfo = true;
                return this;
            }

            public Builder UseLayout(string layoutName)
            {
                this.FormatLayoutName = layoutName;
                return this;
            }

            public Builder UseLayoutFormat(LayoutFormat layoutFormat)
            {
                this.LayoutFormat = layoutFormat;
                return this;
            }

            public Builder IncludeGlobalGeocodeAttribute(GlobalGeocodeAttribute attribute)
            {
                this.GlobalGeocodes.Add(attribute);
                return this;
            }

            public Builder IncludeGlobalGeocodes()
            {
                this.GlobalGeocodes = EnumExtensions.GetAllEnumValues<GlobalGeocodeAttribute>();
                return this;
            }

            public Builder IncludePremiumLocationInsightsAttribute(PremiumLocationInsightAttribute attribute)
            {
                this.PremiumLocationInsights.Add(attribute);
                return this;
            }

            public Builder IncludePremiumLocationInsights()
            {
                this.PremiumLocationInsights = EnumExtensions.GetAllEnumValues<PremiumLocationInsightAttribute>();
                return this;
            }

            public Builder IncludeWhat3WordsAttribute(What3WordsAttribute attribute)
            {
                this.What3Words.Append(attribute);
                return this;
            }

            public Builder IncludeWhat3Words()
            {
                this.What3Words = EnumExtensions.GetAllEnumValues<What3WordsAttribute>();
                return this;
            }

            public Builder IncludeAusRegionalGeocodeAttribute(AusRegionalGeocodeAttribute attribute)
            {
                this.AusRegionalGeocodes.Add(attribute);
                return this;
            }

            public Builder IncludeAusRegionalGeocodes()
            {
                this.AusRegionalGeocodes = EnumExtensions.GetAllEnumValues<AusRegionalGeocodeAttribute>();
                return this;
            }

            public Builder IncludeGbrLocationEssentialAttribute(GbrLocationEssentialAttribute attribute)
            {
                this.GbrLocationEssential.Add(attribute);
                return this;
            }

            public Builder IncludeGbrLocationEssential()
            {
                this.GbrLocationEssential = EnumExtensions.GetAllEnumValues<GbrLocationEssentialAttribute>();
                return this;
            }

            public Builder IncludeGbrLocationCompleteAttribute(GbrLocationCompleteAttribute attribute)
            {
                this.GbrLocationComplete.Add(attribute);
                return this;
            }

            public Builder IncludeGbrLocationComplete()
            {
                this.GbrLocationComplete = EnumExtensions.GetAllEnumValues<GbrLocationCompleteAttribute>();
                return this;
            }

            public Builder IncludeGbrBusinessAttribute(GbrBusinessAttribute attribute)
            {
                this.GbrBusiness.Add(attribute);
                return this;
            }

            public Builder IncludeGbrBusiness()
            {
                this.GbrBusiness = EnumExtensions.GetAllEnumValues<GbrBusinessAttribute>();
                return this;
            }

            public Builder IncludeGbrGovernmentAttribute(GbrGovernmentAttribute attribute)
            {
                this.GbrGovernment.Add(attribute);
                return this;
            }

            public Builder IncludeGbrGovernment()
            {
                this.GbrGovernment = EnumExtensions.GetAllEnumValues<GbrGovernmentAttribute>();
                return this;
            }

            public Builder IncludeGbrHalthAttribute(GbrHealthAttribute attribute)
            {
                this.GbrHealth.Add(attribute);
                return this;
            }

            public Builder IncludeGbrHalth()
            {
                this.GbrHealth = EnumExtensions.GetAllEnumValues<GbrHealthAttribute>();
                return this;
            }

            public Builder IncludeNzlRegionalGeocodeAttribute(NzlRegionalGeocodeAttribute attribute)
            {
                this.NzlRegionalGeocodes.Add(attribute);
                return this;
            }

            public Builder IncludeNzlRegionalGeocode()
            {
                this.NzlRegionalGeocodes = EnumExtensions.GetAllEnumValues<NzlRegionalGeocodeAttribute>();
                return this;
            }

            public Builder AttributeUsaRegionalGeocodeAttribute(UsaRegionalGeocodeAttribute attribute)
            {
                this.UsaRegionalGeocodes.Add(attribute);
                return this;
            }

            public Builder AttributeUsaRegionalGeocode()
            {
                this.UsaRegionalGeocodes = EnumExtensions.GetAllEnumValues<UsaRegionalGeocodeAttribute>();
                return this;
            }

            public Builder UseDataset(Dataset dataset)
            {
                return AddDataset(dataset);
            }

            public override Configuration Build()
            {
                return new Configuration(this);
            }

            private Builder AddDataset(Dataset dataset)
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