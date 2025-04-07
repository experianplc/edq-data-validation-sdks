package com.experian.dvs.client.server.address.validate;

import com.experian.dvs.client.address.*;
import com.experian.dvs.client.address.layout.attributes.*;
import com.experian.dvs.client.server.address.format.RestApiFormatAttribute;
import com.experian.dvs.client.server.address.Address;
import com.experian.dvs.client.server.address.search.RestApiAdditionalOption;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class RestApiAddressValidateRequest {

    @JsonProperty("country_iso")
    private String countryIso;

    @JsonProperty("datasets")
    private List<String> datasets;

    @JsonProperty("max_suggestions")
    private Integer maxSuggestions;

    @JsonProperty("components")
    private Address address;

    @JsonProperty("options")
    private List<RestApiAdditionalOption> options;

    @JsonProperty("attributes")
    private RestApiFormatAttribute attributes;

    @JsonProperty("layouts")
    private List<String> layouts;

    @JsonProperty("layout_format")
    private String layoutFormat;

    public static RestApiAddressValidateRequest using(final Configuration configuration) {

        final RestApiAddressValidateRequest validateRequest = new RestApiAddressValidateRequest();
        //Country
        if (configuration.getCountry() != null) {
            validateRequest.setCountryIso(configuration.getCountry().getIso3Code());
        }
        //Datasets
        if (configuration.getDatasets() != null && !configuration.getDatasets().isEmpty()) {
            validateRequest.setDatasets(configuration.getDatasets().stream().map(Dataset::getDatasetCode).toList());
        }
        //Max suggestions
        if (configuration.getMaxSuggestions() != Configuration.DEFAULT_MAX_SUGGESTIONS) {
            validateRequest.setMaxSuggestions(configuration.getMaxSuggestions());
        }
        //Layout name
        if (!configuration.getFormatLayoutName().isEmpty()) {
            validateRequest.setLayouts(List.of(configuration.getFormatLayoutName()));
        }
        //Layout format
        if (configuration.getLayoutFormat() != null) {
            validateRequest.setLayoutFormat(configuration.getLayoutFormat().getValue() );
        }

        if (configuration.getFlattenResults()) {
            validateRequest.addOption("flatten", Boolean.TRUE.toString());
        }
        if (configuration.getSearchIntensity() != null) {
            validateRequest.addOption("intensity", configuration.getSearchIntensity().getName());
        }
        if (configuration.getPromptSet() != null) {
            validateRequest.addOption("prompt_set", configuration.getPromptSet() .getName());
        }

        final Optional<RestApiFormatAttribute> formatAttributes = getFormatAttribute(configuration);

        formatAttributes.ifPresent(validateRequest::setAttributes);

        return validateRequest;
    }

    public static Optional<RestApiFormatAttribute> getFormatAttribute(final Configuration configuration) {

        final RestApiFormatAttribute attributes = new RestApiFormatAttribute();
        boolean hasAttributes = false;

        if (!configuration.getGeocodes().isEmpty()) {
            attributes.setGeocodes(configuration.getGeocodes().stream().map(GlobalGeocodeAttribute::getValue).toList());
            hasAttributes = true;
        }

        if (!configuration.getPremiumLocationInsights().isEmpty()) {
            attributes.setPremiumLocationInsight(configuration.getPremiumLocationInsights().stream().map(PremiumLocationInsightAttribute::getValue).toList());
        }

        if (!configuration.getWhat3Words().isEmpty()) {
            attributes.setWhat3words(configuration.getWhat3Words().stream().map(What3WordsAttribute::getValue).toList());
        }

        if (!configuration.getLocationCompleteAttributes().isEmpty()) {
            attributes.setUkLocationComplete(configuration.getLocationCompleteAttributes().stream().map(GbrLocationCompleteAttribute::getValue).toList());
            hasAttributes = true;
        }
        if (!configuration.getLocationEssentialAttributes().isEmpty()) {
            attributes.setUkLocationEssential(configuration.getLocationEssentialAttributes().stream().map(GbrLocationEssentialAttribute::getValue).toList());
            hasAttributes = true;
        }
        if (!configuration.getGovernmentAttributes().isEmpty()) {
            attributes.setGbrGovernment(configuration.getGovernmentAttributes().stream().map(GbrGovernmentAttribute::getValue).toList());
            hasAttributes = true;
        }
        if (!configuration.getHealthAttributes().isEmpty()) {
            attributes.setGbrHealth(configuration.getHealthAttributes().stream().map(GBRHealth::getValue).toList());
            hasAttributes = true;
        }
        if (!configuration.getBusinessAttributes().isEmpty()) {
            attributes.setGbrBusiness(configuration.getBusinessAttributes().stream().map(GbrBusinessAttribute::getValue).toList());
            hasAttributes = true;
        }

        if (!configuration.getUsaRegionalGeocodeAttributes().isEmpty()) {
            attributes.setUsaRegionalGeocodes(configuration.getUsaRegionalGeocodeAttributes().stream().map(UsaRegionalGeocodeAttribute::getValue).toList());
            hasAttributes = true;
        }

        if (!configuration.getAusRegionalGeocodeAttributes().isEmpty()) {
            attributes.setAusRegionalGeocodes(configuration.getAusRegionalGeocodeAttributes().stream().map(AUSRegionalGeocode::getValue).toList());
            hasAttributes = true;
        }

        if (!configuration.getNzlRegionalGeocodeAttributes().isEmpty()) {
            attributes.setNzlRegionalGeocodes(configuration.getNzlRegionalGeocodeAttributes().stream().map(NZLRegionalGeocode::getValue).toList());
            hasAttributes = true;
        }

        if (hasAttributes) {
            return Optional.of(attributes);
        }
        return Optional.empty();

    }

    public String getCountryIso() {
        return countryIso;
    }

    public void setCountryIso(String countryIso) {
        this.countryIso = countryIso;
    }

    public List<String> getDatasets() {
        return datasets;
    }

    public void setDatasets(List<String> datasets) {
        this.datasets = datasets;
    }

    public Integer getMaxSuggestions() {
        return maxSuggestions;
    }

    public void setMaxSuggestions(Integer maxSuggestions) {
        this.maxSuggestions = maxSuggestions;
    }

    public Address getAddress() {
        return address;
    }

    public void setAddress(Address address) {
        this.address = address;
    }

    public List<RestApiAdditionalOption> getOptions() {
        return options;
    }

    public void setOptions(List<RestApiAdditionalOption> options) {
        this.options = options;
    }

    public RestApiFormatAttribute getAttributes() {
        return attributes;
    }

    public void setAttributes(RestApiFormatAttribute attributes) {
        this.attributes = attributes;
    }

    public List<String> getLayouts() {
        return layouts;
    }

    public void setLayouts(List<String> layouts) {
        this.layouts = layouts;
    }

    public String getLayoutFormat() {
        return layoutFormat;
    }

    public void setLayoutFormat(String layoutFormat) {
        this.layoutFormat = layoutFormat;
    }

    public void addOption(final String name, final String value) {
        if (this.options == null) {
            this.options = new ArrayList<>();
        }
        this.options.add(new RestApiAdditionalOption(name, value));
    }
}
