package com.experian.dvs.client.address.validate;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum PostalCodeAction {
    NONE("none"),
    OK("ok"),
    ADDED("added"),
    CORRECTED("corrected")
    ;

    private final String name;
    //Map of name to ValidateMatchType
    private static final Map<String, PostalCodeAction> NAME_MAP = Arrays.stream(PostalCodeAction.values())
            .collect(Collectors.toMap(PostalCodeAction::getName, Function.identity()));

    PostalCodeAction(final String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public static PostalCodeAction fromName(final String name) {
        return NAME_MAP.get(name);
    }
}
