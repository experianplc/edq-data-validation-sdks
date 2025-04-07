package com.experian.dvs.client.server.address.layout;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;
import java.util.Map;

public class RestApiAddressLayoutOptions {

    /**
     * Defines which form of address to use when automatically fitting address element into the returned address.
     * This is for datasets which include more than one Form of address, such as the Netherlands, Belgium and Finland datasets.
     */
    @JsonProperty("variations")
    private Integer variations;

    /**
     * When set to true, it will replace all diacritic characters, such as accents and umlauts, with their non-diacritic equivalents.
     * For example, the Danish address "Degnsgårdvej 1, 7840 Højslev" would be returned as "Degnsgardvej 1, 7840 Hojslev".
     */
    @JsonProperty("flatten_diacritics")
    private Boolean flattenDiacritics;

    /**
     * When set to true, it will prepend unmatched leading information to address lines.
     */
    @JsonProperty("enable_enhanced_layout")
    private Boolean enableEnhancedLayout;

    /**
     * When set to true, it will define whether any leading unmatched text before the actual address elements are retained in the picklist.
     * This setting will only take effect if the enable_enhanced_layout setting is set to true.
     */
    @JsonProperty("display_enhanced_info_on_picklist")
    private Boolean displayEnhancedInfoOnPicklist;

    /**
     * When set to true, the intelligent layout will be enabled for the created layout.
     * If the intelligent layout is enabled, the PAF or G-NAF address which most closely matches the entered address will be returned, regardless of the default layout.
     */
    @JsonProperty("enable_intelligent_layout")
    private Boolean enableIntelligentLayout;

    /**
     * When set to true, this will change the case of unmatched leading information.
     */
    @JsonProperty("capitalise_unused")
    private Boolean capitaliseUnused;

    /**
     * When separate_elements set to true, the address elements on a single line are separated, usually by commas.
     */
    @JsonProperty("separate_elements")
    private Boolean separateElements;

    /**
     * The element_separator setting defines which address elements should be separated by additional characters.
     * This setting will only take effect if the separate_elements setting is set to true.
     * Element separators take precedence right over left. The caret character (^) denotes the position of the address element.
     */
    @JsonProperty("element_separator")
    private RestApiElementSeparator elementSeparator;

    /**
     * This defines which retention address elements should be separated by additional characters in the formatted address.
     * This setting will only take effect if the separate_elements and use_extended_retention settings are set to true.
     */
    @JsonProperty("retention_element_separator")
    private RestApiElementSeparator retentionElementSeparator;

    /**
     * This defines which prepend address elements should be separated by additional characters in the formatted address.
     * This setting will only take effect if the separate_elements and use_extended_retention settings are set to true.
     */
    @JsonProperty("prepend_element_separator")
    private RestApiElementSeparator prependElementSeparator;

    /**
     * This defines which separate address elements should be separated by additional characters in the formatted address.
     * This setting will only take effect if the separate_elements and use_extended_retention settings are set to true.
     */
    @JsonProperty("separate_element_separator")
    private RestApiElementSeparator separateElementSeparator;

    /**
     * When terminate_lines set to true, the address lines are ended with an additional character.
     * The additional characters to use are defined by line_terminator.
     */
    @JsonProperty("terminate_lines")
    private Boolean terminateLines;

    /**
     * The additional characters to use for terminating lines.
     */
    @JsonProperty("line_terminator")
    private RestApiElementSeparator lineTerminator;

    /**
     * This setting has a different function depending on the dataset being used.
     * For the GBR with additional Business dataset, this setting allows the user to specify whether to display the PAF or Experian organisation data, or a combination of both.
     * For the USA dataset, this setting allows the user to specify whether to return the full city name or the abbreviated city name.
     */
    @JsonProperty("conditional_format")
    private String conditionalFormat;

    /**
     * If pad_lines set to true, it populates the line to the maximum width with the single character defined in the padding_character setting.
     * The default padding character is a space.
     */
    @JsonProperty("pad_lines")
    private Boolean padLines;

    /**
     * The character used for padding lines.
     */
    @JsonProperty("padding_character")
    private String paddingCharacter;

    /**
     * This defines the delimiter used to separate returned multiple DataPlus values.
     * The default padding character is a pipe.
     */
    @JsonProperty("multiple_dataplus_delimiter")
    private String multipleDataplusDelimiter;

    /**
     * This defines which address elements should be abbreviated in the formatted address.
     * The value is a list of element names, which differ from dataset to dataset.
     */
    @JsonProperty("abbreviate_item")
    private List abbreviateItem;

    /**
     * This defines which address elements should appear in upper case in the formatted address.
     * The value is a list of element names.
     */
    @JsonProperty("capitalise_item")
    private List capitaliseItem;

    /**
     * This will exclude an address element from appearing in a formatted address, but only if that element wasn't fixed via the lines[x].elements collection.
     */
    @JsonProperty("exclude_item")
    private List excludeItem;

    /**
     * This adds specified characters around an address element.
     * The caret character (^) denotes the position of the address element.
     */
    @JsonProperty("element_extras")
    private Map elementExtras;

    public RestApiAddressLayoutOptions(Boolean enableEnhancedLayout) {
        this.enableEnhancedLayout = enableEnhancedLayout;
    }

    public Integer isVariations() {
        return variations;
    }

    public void setVariations(Integer variations) {
        this.variations = variations;
    }

    public Boolean isFlattenDiacritics() {
        return flattenDiacritics;
    }

    public void setFlattenDiacritics(boolean flattenDiacritics) {
        this.flattenDiacritics = flattenDiacritics;
    }

    public Boolean getDisplayEnhancedInfoOnPicklist() {
        return displayEnhancedInfoOnPicklist;
    }

    public void setDisplayEnhancedInfoOnPicklist(Boolean displayEnhancedInfoOnPicklist) {
        this.displayEnhancedInfoOnPicklist = displayEnhancedInfoOnPicklist;
    }

    public Boolean getEnableIntelligentLayout() {
        return enableIntelligentLayout;
    }

    public void setEnableIntelligentLayout(Boolean enableIntelligentLayout) {
        this.enableIntelligentLayout = enableIntelligentLayout;
    }

    public Boolean getCapitaliseUnused() {
        return capitaliseUnused;
    }

    public void setCapitaliseUnused(Boolean capitaliseUnused) {
        this.capitaliseUnused = capitaliseUnused;
    }

    public Boolean getSeparateElements() {
        return separateElements;
    }

    public void setSeparateElements(Boolean separateElements) {
        this.separateElements = separateElements;
    }

    public Boolean getEnableEnhancedLayout() {
        return enableEnhancedLayout;
    }

    public void setEnableEnhancedLayout(Boolean enableEnhancedLayout) {
        this.enableEnhancedLayout = enableEnhancedLayout;
    }

    public RestApiElementSeparator getElementSeparator() {
        return elementSeparator;
    }

    public void setElementSeparator(RestApiElementSeparator elementSeparator) {
        this.elementSeparator = elementSeparator;
    }

    public RestApiElementSeparator getRetentionElementSeparator() {
        return retentionElementSeparator;
    }

    public void setRetentionElementSeparator(RestApiElementSeparator retentionElementSeparator) {
        this.retentionElementSeparator = retentionElementSeparator;
    }

    public RestApiElementSeparator getPrependElementSeparator() {
        return prependElementSeparator;
    }

    public void setPrependElementSeparator(RestApiElementSeparator prependElementSeparator) {
        this.prependElementSeparator = prependElementSeparator;
    }

    public RestApiElementSeparator getSeparateElementSeparator() {
        return separateElementSeparator;
    }

    public void setSeparateElementSeparator(RestApiElementSeparator separateElementSeparator) {
        this.separateElementSeparator = separateElementSeparator;
    }

    public Boolean getTerminateLines() {
        return terminateLines;
    }

    public void setTerminateLines(Boolean terminateLines) {
        this.terminateLines = terminateLines;
    }

    public String getConditionalFormat() {
        return conditionalFormat;
    }

    public void setConditionalFormat(String conditionalFormat) {
        this.conditionalFormat = conditionalFormat;
    }

    public Boolean getPadLines() {
        return padLines;
    }

    public void setPadLines(Boolean padLines) {
        this.padLines = padLines;
    }

    public String getPaddingCharacter() {
        return paddingCharacter;
    }

    public void setPaddingCharacter(String paddingCharacter) {
        this.paddingCharacter = paddingCharacter;
    }

    public String getMultipleDataplusDelimiter() {
        return multipleDataplusDelimiter;
    }

    public void setMultipleDataplusDelimiter(String multipleDataplusDelimiter) {
        this.multipleDataplusDelimiter = multipleDataplusDelimiter;
    }

    public List getAbbreviateItem() {
        return abbreviateItem;
    }

    public void setAbbreviateItem(List abbreviateItem) {
        this.abbreviateItem = abbreviateItem;
    }

    public List getCapitaliseItem() {
        return capitaliseItem;
    }

    public void setCapitaliseItem(List capitaliseItem) {
        this.capitaliseItem = capitaliseItem;
    }

    public Map getElementExtras() {
        return elementExtras;
    }

    public void setElementExtras(Map elementExtras) {
        this.elementExtras = elementExtras;
    }
}