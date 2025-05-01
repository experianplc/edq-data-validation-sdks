package com.experian.dvs.client.address.validate;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum ValidateMatchType {
    UNKNOWN("Unknown"),
    UNPROCESSED("unprocessed"),
    BLANK("blank"),
    UNMATCHED("unmatched"),
    POSTAL_CODE_MATCH_WITHOUT_ADDRESS("post_code_no_address"),
    MULTIPLE_MATCH_WITHOUT_POSTAL_CODE("multiple_no_post_code"),
    MULTIPLE_MATCH_WITH_POSTAL_CODE("multiple_with_post_code"),
    PARTIAL_MATCH_WITHOUT_POSTAL_CODE("partial_no_post_code"),
    PARTIAL_MATCH_WITH_POSTAL_CODE("partial_with_post_code"),
    FULL_MATCH_WITHOUT_POSTAL_CODE("full_no_post_code"),
    FULL_MATCH_WITH_POSTAL_CODE("full_with_post_code")
    ;

    private final String name;
    //Map of name to ValidateMatchType
    private static final Map<String, ValidateMatchType> NAME_MAP = Arrays.stream(ValidateMatchType.values())
            .collect(Collectors.toMap(ValidateMatchType::getName, Function.identity()));

    ValidateMatchType(final String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public static ValidateMatchType fromName(final String name) {
        return NAME_MAP.get(name);
    }
}
