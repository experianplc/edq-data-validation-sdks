package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

@JsonInclude(JsonInclude.Include.NON_NULL)
public class RestApiFormatAttribute {

    @JsonProperty("geocodes")
    private List<String> geocodes;
    @JsonProperty("usa_regional_geocodes")
    private List<String> usaRegionalGeocodes;
    @JsonProperty("aus_regional_geocodes")
    private List<String> ausRegionalGeocodes;
    @JsonProperty("nzl_regional_geocodes")
    private List<String> nzlRegionalGeocodes;
    @JsonProperty("uk_location_complete")
    private List<String> ukLocationComplete;
    @JsonProperty("uk_location_essential")
    private List<String> ukLocationEssential;
    @JsonProperty("gbr_government")
    private List<String> gbrGovernment;
    @JsonProperty("gbr_health")
    private List<String> gbrHealth;
    @JsonProperty("gbr_business")
    private List<String> gbrBusiness;
    @JsonProperty("premium_location_insight")
    private List<String> premiumLocationInsight;
    @JsonProperty("what3words")
    private List<String> what3words;


    public List<String> getGeocodes() {
        return geocodes;
    }

    public void setGeocodes(List<String> geocodes) {
        this.geocodes = geocodes;
    }

    public List<String> getUsaRegionalGeocodes() {
        return usaRegionalGeocodes;
    }

    public void setUsaRegionalGeocodes(List<String> usaRegionalGeocodes) {
        this.usaRegionalGeocodes = usaRegionalGeocodes;
    }

    public List<String> getAusRegionalGeocodes() {
        return ausRegionalGeocodes;
    }

    public void setAusRegionalGeocodes(List<String> ausRegionalGeocodes) {
        this.ausRegionalGeocodes = ausRegionalGeocodes;
    }

    public List<String> getNzlRegionalGeocodes() {
        return nzlRegionalGeocodes;
    }

    public void setNzlRegionalGeocodes(List<String> nzlRegionalGeocodes) {
        this.nzlRegionalGeocodes = nzlRegionalGeocodes;
    }

    public List<String> getUkLocationComplete() {
        return ukLocationComplete;
    }

    public void setUkLocationComplete(List<String> ukLocationComplete) {
        this.ukLocationComplete = ukLocationComplete;
    }

    public List<String> getUkLocationEssential() {
        return ukLocationEssential;
    }

    public void setUkLocationEssential(List<String> ukLocationEssential) {
        this.ukLocationEssential = ukLocationEssential;
    }

    public List<String> getGbrGovernment() {
        return gbrGovernment;
    }

    public void setGbrGovernment(List<String> gbrGovernment) {
        this.gbrGovernment = gbrGovernment;
    }

    public List<String> getGbrHealth() {
        return gbrHealth;
    }

    public void setGbrHealth(List<String> gbrHealth) {
        this.gbrHealth = gbrHealth;
    }

    public List<String> getGbrBusiness() {
        return gbrBusiness;
    }

    public void setGbrBusiness(List<String> gbrBusiness) {
        this.gbrBusiness = gbrBusiness;
    }

    public List<String> getPremiumLocationInsight() {
        return premiumLocationInsight;
    }

    public void setPremiumLocationInsight(List<String> premiumLocationInsight) {
        this.premiumLocationInsight = premiumLocationInsight;
    }

    public List<String> getWhat3words() {
        return what3words;
    }

    public void setWhat3words(List<String> what3words) {
        this.what3words = what3words;
    }
}
