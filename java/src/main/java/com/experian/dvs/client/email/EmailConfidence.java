package com.experian.dvs.client.email;

import java.util.HashMap;
import java.util.Map;

public enum EmailConfidence {
    VERIFIED("verified"),
    UNDELIVERABLE("undeliverable"),
    UNREACHABLE("unreachable"),
    ILLEGITIMATE("illegitimate"),
    DISPOSABLE("disposable"),
    UNKNOWN("unknown");

    private final String name;
    // Map of name to EmailValidateConfidence
    private static final Map<String, EmailConfidence> nameToConfidence = new HashMap<>();
    static {
        for (EmailConfidence confidence : EmailConfidence.values()) {
            nameToConfidence.put(confidence.name, confidence);
        }
    }

    EmailConfidence(final String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static EmailConfidence fromName(final String name) {
        return nameToConfidence.get(name);
    }
}