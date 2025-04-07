package com.experian.dvs.client.address.format;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatted;

import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;

public class AddressFormatted {

    private final String layoutName;
    private final boolean notEnoughLines;
    private final boolean hasTruncatedLines;
    private final Map<String, String> address = new LinkedHashMap<>();
    private final boolean hasMissingSubPremises;
    private final List<AddressFormattedLine> addressLines;

    public AddressFormatted(final RestApiAddressFormatted result) {
        this.layoutName = Objects.toString(result.getLayoutName(), "");
        this.notEnoughLines = Boolean.TRUE.equals(result.getNotEnoughLines());
        this.hasTruncatedLines = Boolean.TRUE.equals(result.getHasTruncatedLines());
        if (result.getAddress() != null) {
            result.getAddress().forEach((key, value) -> address.put(key, Objects.toString(value, "")));
        }
        this.hasMissingSubPremises = Boolean.TRUE.equals(result.getHasMissingSubPremises());
        this.addressLines = result.getAddressLines() != null ? result.getAddressLines().stream().map(AddressFormattedLine::new).toList() : List.of();
    }

    public String getLayoutName() {
        return layoutName;
    }

    public boolean hasEnoughLines() {
        return !notEnoughLines;
    }

    public boolean hasTruncatedLines() {
        return hasTruncatedLines;
    }

    public Map<String, String> getAddress() {
        return address;
    }

    public boolean hasMissingSubPremises() {
        return hasMissingSubPremises;
    }

    public List<AddressFormattedLine> getAddressLines() {
        return addressLines;
    }
}
