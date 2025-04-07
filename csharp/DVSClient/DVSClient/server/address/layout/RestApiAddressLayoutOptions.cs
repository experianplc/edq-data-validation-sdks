using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiAddressLayoutOptions
    {
        /**
         * Defines which form of address to use when automatically fitting address element into the returned address.
         * This is for datasets which include more than one form of address, such as the Netherlands, Belgium, and Finland datasets.
         */
        [JsonProperty("variations")]
        public int? Variations { get; set; }

        /**
         * When set to true, it will replace all diacritic characters, such as accents and umlauts, with their non-diacritic equivalents.
         * For example, the Danish address "Degnsgårdvej 1, 7840 Højslev" would be returned as "Degnsgardvej 1, 7840 Hojslev".
         */
        [JsonProperty("flatten_diacritics")]
        public bool? FlattenDiacritics { get; set; }

        /**
         * When set to true, it will prepend unmatched leading information to address lines.
         */
        [JsonProperty("enable_enhanced_layout")]
        public bool? EnableEnhancedLayout { get; set; }

        /**
         * When set to true, it will define whether any leading unmatched text before the actual address elements are retained in the picklist.
         * This setting will only take effect if the enable_enhanced_layout setting is set to true.
         */
        [JsonProperty("display_enhanced_info_on_picklist")]
        public bool? DisplayEnhancedInfoOnPicklist { get; set; }

        /**
         * When set to true, the intelligent layout will be enabled for the created layout.
         * If the intelligent layout is enabled, the PAF or G-NAF address which most closely matches the entered address will be returned, regardless of the default layout.
         */
        [JsonProperty("enable_intelligent_layout")]
        public bool? EnableIntelligentLayout { get; set; }

        /**
         * When set to true, this will change the case of unmatched leading information.
         */
        [JsonProperty("capitalise_unused")]
        public bool? CapitaliseUnused { get; set; }

        /**
         * When separate_elements set to true, the address elements on a single line are separated, usually by commas.
         */
        [JsonProperty("separate_elements")]
        public bool? SeparateElements { get; set; }

        /**
         * The element_separator setting defines which address elements should be separated by additional characters.
         * This setting will only take effect if the separate_elements setting is set to true.
         * Element separators take precedence right over left. The caret character (^) denotes the position of the address element.
         */
        [JsonProperty("element_separator")]
        public RestApiElementSeparator? ElementSeparator { get; set; }

        /**
         * This defines which retention address elements should be separated by additional characters in the formatted address.
         * This setting will only take effect if the separate_elements and use_extended_retention settings are set to true.
         */
        [JsonProperty("retention_element_separator")]
        public RestApiElementSeparator? RetentionElementSeparator { get; set; }

        /**
         * This defines which prepend address elements should be separated by additional characters in the formatted address.
         * This setting will only take effect if the separate_elements and use_extended_retention settings are set to true.
         */
        [JsonProperty("prepend_element_separator")]
        public RestApiElementSeparator? PrependElementSeparator { get; set; }

        /**
         * This defines which separate address elements should be separated by additional characters in the formatted address.
         * This setting will only take effect if the separate_elements and use_extended_retention settings are set to true.
         */
        [JsonProperty("separate_element_separator")]
        public RestApiElementSeparator? SeparateElementSeparator { get; set; }

        /**
         * When terminate_lines set to true, the address lines are ended with an additional character.
         * The additional characters to use are defined by line_terminator.
         */
        [JsonProperty("terminate_lines")]
        public bool? TerminateLines { get; set; }

        /**
         * The additional characters to use for terminating lines.
         */
        [JsonProperty("line_terminator")]
        public RestApiElementSeparator? LineTerminator { get; set; }

        /**
         * This setting has a different function depending on the dataset being used.
         * For the GBR with additional Business dataset, this setting allows the user to specify whether to display the PAF or Experian organisation data, or a combination of both.
         * For the USA dataset, this setting allows the user to specify whether to return the full city name or the abbreviated city name.
         */
        [JsonProperty("conditional_format")]
        public string? ConditionalFormat { get; set; }

        /**
         * If pad_lines set to true, it populates the line to the maximum width with the single character defined in the padding_character setting.
         * The default padding character is a space.
         */
        [JsonProperty("pad_lines")]
        public bool? PadLines { get; set; }

        /**
         * The character used for padding lines.
         */
        [JsonProperty("padding_character")]
        public string? PaddingCharacter { get; set; }

        /**
         * This defines the delimiter used to separate returned multiple DataPlus values.
         * The default padding character is a pipe.
         */
        [JsonProperty("multiple_dataplus_delimiter")]
        public string? MultipleDataplusDelimiter { get; set; }

        /**
         * This defines which address elements should be abbreviated in the formatted address.
         * The value is a list of element names, which differ from dataset to dataset.
         */
        [JsonProperty("abbreviate_item")]
        public IEnumerable<string>? AbbreviateItem { get; set; }

        /**
         * This defines which address elements should appear in upper case in the formatted address.
         * The value is a list of element names.
         */
        [JsonProperty("capitalise_item")]
        public IEnumerable<string>? CapitaliseItem { get; set; }

        /**
         * This will exclude an address element from appearing in a formatted address, but only if that element wasn't fixed via the lines[x].elements collection.
         */
        [JsonProperty("exclude_item")]
        public IEnumerable<string>? ExcludeItem { get; set; }

        /**
         * This adds specified characters around an address element.
         * The caret character (^) denotes the position of the address element.
         */
        [JsonProperty("element_extras")]
        public IDictionary<string, string>? ElementExtras { get; set; }

        public RestApiAddressLayoutOptions(bool enableEnhancedLayout)
        {
            EnableEnhancedLayout = enableEnhancedLayout;
        }
    }
}