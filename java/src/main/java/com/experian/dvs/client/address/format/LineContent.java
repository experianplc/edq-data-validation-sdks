package com.experian.dvs.client.address.format;

import java.util.HashMap;
import java.util.Map;

public enum LineContent {

    NONE("none"),
    ADDRESS("address"),
    NAME("name"),
    ANCILLERY("ancillery"),
    DATAPLUS("dataplus")
    ;

    private final String name;
    //Map of name to AddressConfidence
    private static final Map<String, LineContent> nameToLineContent = new HashMap<>();
    static {
        for (LineContent lineContent : LineContent.values()) {
            nameToLineContent.put(lineContent.name, lineContent);
        }
    }

    LineContent(final String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static LineContent fromName(final String name) {
        return nameToLineContent.get(name);
    }
}
