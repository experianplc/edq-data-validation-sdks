package com.experian.dvs.client.email;

import java.util.HashMap;
import java.util.Map;

public enum Confidence {
    VERIFIED("verified"),
    UNDELIVERABLE("undeliverable"),
    UNREACHABLE("unreachable"),
    ILLEGITIMATE("illegitimate"),
    DISPOSABLE("disposable"),
    UNKNOWN("unknown");

    private final String name;
    // Map of name to EmailValidateConfidence
    private static final Map<String, Confidence> nameToConfidence = new HashMap<>();
    static {
        for (Confidence confidence : Confidence.values()) {
            nameToConfidence.put(confidence.name, confidence);
        }
    }

    Confidence(final String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static Confidence fromName(final String name) {
        return nameToConfidence.get(name);
    }
}