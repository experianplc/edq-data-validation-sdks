package com.experian.dvs.client.address;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum Intensity {
    EXACT("Exact"),
    CLOSE("Close"),
    EXTENSIVE("Extensive")
    ;

    private final String name;
    //Map of name to SearchIntensity
    private static final Map<String, Intensity> NAME_MAP = Arrays.stream(Intensity.values())
            .collect(Collectors.toMap(Intensity::getName, Function.identity()));


    Intensity(final String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public static Intensity fromName(final String name) {
        return NAME_MAP.get(name);
    }

}
