package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;
import java.util.Map;

@JsonIgnoreProperties(ignoreUnknown = true)
public class RestApiAddressFormatted {

    @JsonProperty("layout_name")
    private String layoutName;
    @JsonProperty("not_enough_lines")
    private Boolean notEnoughLines;
    @JsonProperty("has_truncated_lines")
    private Boolean hasTruncatedLines;
    @JsonProperty("address")
    private Map<String, Object> address;
    @JsonProperty("has_missing_sub_premises")
    private Boolean hasMissingSubPremises;
    @JsonProperty("address_lines")
    private List<RestApiAddressFormattedLine> addressLines;

    public String getLayoutName() {
        return layoutName;
    }

    public void setLayoutName(String layoutName) {
        this.layoutName = layoutName;
    }

    public Boolean getNotEnoughLines() {
        return notEnoughLines;
    }

    public void setNotEnoughLines(Boolean notEnoughLines) {
        this.notEnoughLines = notEnoughLines;
    }

    public Boolean getHasTruncatedLines() {
        return hasTruncatedLines;
    }

    public void setHasTruncatedLines(Boolean hasTruncatedLines) {
        this.hasTruncatedLines = hasTruncatedLines;
    }

    public Map<String, Object> getAddress() {
        return address;
    }

    public Boolean getHasMissingSubPremises() {
        return hasMissingSubPremises;
    }

    public void setHasMissingSubPremises(Boolean hasMissingSubPremises) {
        this.hasMissingSubPremises = hasMissingSubPremises;
    }

    public List<RestApiAddressFormattedLine> getAddressLines() {
        return addressLines;
    }

    public void setAddressLines(List<RestApiAddressFormattedLine> addressLines) {
        this.addressLines = addressLines;
    }
}
