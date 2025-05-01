package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEnrichmentResultAddress {

    @JsonProperty("geocodes")
    private RestApiEnrichmentDatasetGeocodes geocodes;

    @JsonProperty("usa_regional_geocodes")
    private RestApiEnrichmentUsaRegionalGeocodes usaRegionalGeocodes;

    @JsonProperty("aus_regional_geocodes")
    private RestApiEnrichmentAusRegionalGeocodes ausRegionalGeocodes;

    @JsonProperty("nzl_regional_geocodes")
    private RestApiEnrichmentNzlRegionalGeocodes nzlRegionalGeocodes;

    @JsonProperty("uk_location_complete")
    private RestApiEnrichmentUKLocationComplete ukLocationComplete;

    @JsonProperty("uk_location_essential")
    private RestApiEnrichmentUKLocationEssential ukLocationEssential;

    @JsonProperty("gbr_government")
    private RestApiEnrichmentGbrGovernment gbrGovernment;

    @JsonProperty("gbr_business")
    private RestApiEnrichmentGbAdditional gbrBusiness;

    @JsonProperty("gbr_health")
    private RestApiEnrichmentGbrHealth gbrHealth;

    @JsonProperty("premium_location_insight")
    private RestApiPremiumLocationInsight premiumLocationInsight;

    @JsonProperty("what3words")
    private RestApiEnrichmentWhat3Words what3words;

    public RestApiEnrichmentDatasetGeocodes getGeocodes() {
        return geocodes;
    }

    public void setGeocodes(RestApiEnrichmentDatasetGeocodes geocodes) {
        this.geocodes = geocodes;
    }

    public RestApiEnrichmentUsaRegionalGeocodes getUsaRegionalGeocodes() {
        return usaRegionalGeocodes;
    }

    public void setUsaRegionalGeocodes(RestApiEnrichmentUsaRegionalGeocodes usaRegionalGeocodes) {
        this.usaRegionalGeocodes = usaRegionalGeocodes;
    }

    public RestApiEnrichmentAusRegionalGeocodes getAusRegionalGeocodes() {
        return ausRegionalGeocodes;
    }

    public void setAusRegionalGeocodes(RestApiEnrichmentAusRegionalGeocodes ausRegionalGeocodes) {
        this.ausRegionalGeocodes = ausRegionalGeocodes;
    }

    public RestApiEnrichmentNzlRegionalGeocodes getNzlRegionalGeocodes() {
        return nzlRegionalGeocodes;
    }

    public void setNzlRegionalGeocodes(RestApiEnrichmentNzlRegionalGeocodes nzlRegionalGeocodes) {
        this.nzlRegionalGeocodes = nzlRegionalGeocodes;
    }

    public RestApiEnrichmentUKLocationComplete getUkLocationComplete() {
        return ukLocationComplete;
    }

    public void setUkLocationComplete(RestApiEnrichmentUKLocationComplete ukLocationComplete) {
        this.ukLocationComplete = ukLocationComplete;
    }

    public RestApiEnrichmentUKLocationEssential getUkLocationEssential() {
        return ukLocationEssential;
    }

    public void setUkLocationEssential(RestApiEnrichmentUKLocationEssential ukLocationEssential) {
        this.ukLocationEssential = ukLocationEssential;
    }

    public RestApiEnrichmentGbrGovernment getGbrGovernment() {
        return gbrGovernment;
    }

    public void setGbrGovernment(RestApiEnrichmentGbrGovernment gbrGovernment) {
        this.gbrGovernment = gbrGovernment;
    }

    public RestApiEnrichmentGbAdditional getGbrBusiness() {
        return gbrBusiness;
    }

    public void setGbrBusiness(RestApiEnrichmentGbAdditional gbrBusiness) {
        this.gbrBusiness = gbrBusiness;
    }

    public RestApiEnrichmentGbrHealth getGbrHealth() {
        return gbrHealth;
    }

    public void setGbrHealth(RestApiEnrichmentGbrHealth gbrHealth) {
        this.gbrHealth = gbrHealth;
    }

    public RestApiPremiumLocationInsight getPremiumLocationInsight() {
        return premiumLocationInsight;
    }

    public void setPremiumLocationInsight(RestApiPremiumLocationInsight premiumLocationInsight) {
        this.premiumLocationInsight = premiumLocationInsight;
    }

    public RestApiEnrichmentWhat3Words getWhat3words() {
        return what3words;
    }

    public void setWhat3words(RestApiEnrichmentWhat3Words what3words) {
        this.what3words = what3words;
    }
}
