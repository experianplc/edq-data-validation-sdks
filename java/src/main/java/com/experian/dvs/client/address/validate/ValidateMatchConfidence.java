package com.experian.dvs.client.address.validate;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum ValidateMatchConfidence {
    UNKNOWN("Unknown"),
    NONE("none"),
    MEDIUM("medium"),
    HIGH("high"),
    ;

    private final String name;
    //Map of name to ValidateMatchType
    private static final Map<String, ValidateMatchConfidence> NAME_MAP = Arrays.stream(ValidateMatchConfidence.values())
            .collect(Collectors.toMap(ValidateMatchConfidence::getName, Function.identity()));

    ValidateMatchConfidence(final String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public static ValidateMatchConfidence fromName(final String name) {
        return NAME_MAP.get(name);
    }
}
