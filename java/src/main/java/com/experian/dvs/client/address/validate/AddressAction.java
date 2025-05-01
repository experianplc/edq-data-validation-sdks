package com.experian.dvs.client.address.validate;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum AddressAction {
    NONE("none"),
    REFORMATTED("reformatted"),
    ENHANCED("enhanced"),
    CORRECTED("corrected")
    ;

    private final String name;
    //Map of name to ValidateMatchType
    private static final Map<String, AddressAction> NAME_MAP = Arrays.stream(AddressAction.values())
            .collect(Collectors.toMap(AddressAction::getName, Function.identity()));

    AddressAction(final String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public static AddressAction fromName(final String name) {
        return NAME_MAP.get(name);
    }
}
