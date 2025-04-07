package com.experian.dvs.client.address;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum PromptSet {
    ONE_LINE("OneLine"),
    DEFAULT("Default"),
    GENERIC("Generic"),
    OPTIMAL("Optimal"),
    ALTERNATE("Alternate"),
    ALTERNATE2("Alternate2")
    ;

    private final String name;
    //Map of name to PromptSet
    private static final Map<String, PromptSet> NAME_MAP = Arrays.stream(PromptSet.values())
            .collect(Collectors.toMap(PromptSet::getName, Function.identity()));

    PromptSet(final String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public static PromptSet fromName(final String name) {
        return NAME_MAP.get(name);
    }

}
