package com.experian.dvs.client.address;

import java.util.HashMap;
import java.util.Map;

public enum AddressConfidence {
    UNKNOWN("Unknown"),
    VERIFIED_MATCH("Verified match"),
    MULTIPLE_MATCHES("Multiple matches"),
    TOO_MANY_MATCHES("Too many matches"),
    INTERACTION_REQUIRED("Interaction required"),
    PREMISES_PARTIAL("Premises partial"),
    STREET_PARTIAL("Street partial"),
    VERIFIED_PLACE("Verified place"),
    VERIFIED_STREET("Verified street"),
    INCOMPLETE_ADDRESS("Incomplete address"),
    INSUFFICIENT_SEARCH_TERMS("Insufficient search terms"),
    NO_MATCHES("No matches")
    ;

    private final String name;
    //Map of name to AddressConfidence
    private static final Map<String, AddressConfidence> nameToConfidence = new HashMap<>();
    static {
        for (AddressConfidence confidence : AddressConfidence.values()) {
            nameToConfidence.put(confidence.name, confidence);
        }
    }

    AddressConfidence(final String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static AddressConfidence fromName(final String name) {
        return nameToConfidence.get(name);
    }

}
