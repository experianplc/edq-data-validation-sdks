package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressMetadataDpv {

    @JsonProperty("cmra_indicator")
    private String cmraIndicator;

    @JsonProperty("seed_indicator")
    private String seedIndicator;

    @JsonProperty("dpv_indicator")
    private String dpvIndicator;

    @JsonProperty("footnotes")
    private String footnotes;

    @JsonProperty("vacancy_indicator")
    private String vacancyIndicator;

    @JsonProperty("no_stats_indicator")
    private String noStatsIndicator;

    @JsonProperty("pbsa_indicator")
    private String pbsaIndicator;

    @JsonProperty("lacs_indicator")
    private String lacsIndicator;

    @JsonProperty("lacs_code")
    private String lacsCode;

    @JsonProperty("urbanization")
    private String urbanization;

    @JsonProperty("delivery_line_1")
    private String deliveryLine1;

    @JsonProperty("delivery_line_2")
    private String deliveryLine2;

    @JsonProperty("last_line")
    private String lastLine;

    @JsonProperty("no_stat_reason_code")
    private String noStatReasonCode;

    @JsonProperty("drop")
    private String drop;

    @JsonProperty("throwback")
    private String throwback;

    @JsonProperty("non_delivery_days_indicator")
    private String nonDeliveryDaysIndicator;

    @JsonProperty("non_delivery_days_value")
    private String nonDeliveryDaysValue;

    @JsonProperty("no_secure_location")
    private String noSecureLocation;

    @JsonProperty("door_not_accessible")
    private String doorNotAccessible;

    @JsonProperty("enhanced_dpv_code")
    private String enhancedDpvCode;

    @JsonProperty("firm_name")
    private String firmName;

    // Getters and Setters
    public String getCmraIndicator() {
        return cmraIndicator;
    }

    public void setCmraIndicator(String cmraIndicator) {
        this.cmraIndicator = cmraIndicator;
    }

    public String getSeedIndicator() {
        return seedIndicator;
    }

    public void setSeedIndicator(String seedIndicator) {
        this.seedIndicator = seedIndicator;
    }

    public String getDpvIndicator() {
        return dpvIndicator;
    }

    public void setDpvIndicator(String dpvIndicator) {
        this.dpvIndicator = dpvIndicator;
    }

    public String getFootnotes() {
        return footnotes;
    }

    public void setFootnotes(String footnotes) {
        this.footnotes = footnotes;
    }

    public String getVacancyIndicator() {
        return vacancyIndicator;
    }

    public void setVacancyIndicator(String vacancyIndicator) {
        this.vacancyIndicator = vacancyIndicator;
    }

    public String getNoStatsIndicator() {
        return noStatsIndicator;
    }

    public void setNoStatsIndicator(String noStatsIndicator) {
        this.noStatsIndicator = noStatsIndicator;
    }

    public String getPbsaIndicator() {
        return pbsaIndicator;
    }

    public void setPbsaIndicator(String pbsaIndicator) {
        this.pbsaIndicator = pbsaIndicator;
    }

    public String getLacsIndicator() {
        return lacsIndicator;
    }

    public void setLacsIndicator(String lacsIndicator) {
        this.lacsIndicator = lacsIndicator;
    }

    public String getLacsCode() {
        return lacsCode;
    }

    public void setLacsCode(String lacsCode) {
        this.lacsCode = lacsCode;
    }

    public String getUrbanization() {
        return urbanization;
    }

    public void setUrbanization(String urbanization) {
        this.urbanization = urbanization;
    }

    public String getDeliveryLine1() {
        return deliveryLine1;
    }

    public void setDeliveryLine1(String deliveryLine1) {
        this.deliveryLine1 = deliveryLine1;
    }

    public String getDeliveryLine2() {
        return deliveryLine2;
    }

    public void setDeliveryLine2(String deliveryLine2) {
        this.deliveryLine2 = deliveryLine2;
    }

    public String getLastLine() {
        return lastLine;
    }

    public void setLastLine(String lastLine) {
        this.lastLine = lastLine;
    }

    public String getNoStatReasonCode() {
        return noStatReasonCode;
    }

    public void setNoStatReasonCode(String noStatReasonCode) {
        this.noStatReasonCode = noStatReasonCode;
    }

    public String getDrop() {
        return drop;
    }

    public void setDrop(String drop) {
        this.drop = drop;
    }

    public String getThrowback() {
        return throwback;
    }

    public void setThrowback(String throwback) {
        this.throwback = throwback;
    }

    public String getNonDeliveryDaysIndicator() {
        return nonDeliveryDaysIndicator;
    }

    public void setNonDeliveryDaysIndicator(String nonDeliveryDaysIndicator) {
        this.nonDeliveryDaysIndicator = nonDeliveryDaysIndicator;
    }

    public String getNonDeliveryDaysValue() {
        return nonDeliveryDaysValue;
    }

    public void setNonDeliveryDaysValue(String nonDeliveryDaysValue) {
        this.nonDeliveryDaysValue = nonDeliveryDaysValue;
    }

    public String getNoSecureLocation() {
        return noSecureLocation;
    }

    public void setNoSecureLocation(String noSecureLocation) {
        this.noSecureLocation = noSecureLocation;
    }

    public String getDoorNotAccessible() {
        return doorNotAccessible;
    }

    public void setDoorNotAccessible(String doorNotAccessible) {
        this.doorNotAccessible = doorNotAccessible;
    }

    public String getEnhancedDpvCode() {
        return enhancedDpvCode;
    }

    public void setEnhancedDpvCode(String enhancedDpvCode) {
        this.enhancedDpvCode = enhancedDpvCode;
    }

    public String getFirmName() {
        return firmName;
    }

    public void setFirmName(String firmName) {
        this.firmName = firmName;
    }
}