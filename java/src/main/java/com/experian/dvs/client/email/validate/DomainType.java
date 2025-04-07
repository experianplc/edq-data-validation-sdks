package com.experian.dvs.client.email.validate;

import java.util.HashMap;
import java.util.Map;

public enum DomainType {
    CONSUMER("consumer"),
    BUSINESS("business");

    private final String name;
    // Map of name to EmailDomainType
    private static final Map<String, DomainType> nameToEmailDomainType = new HashMap<>();
    static {
        for (DomainType type : DomainType.values()) {
            nameToEmailDomainType.put(type.name, type);
        }
    }

    DomainType(final String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static DomainType fromName(final String name) {
        return nameToEmailDomainType.get(name);
    }
}