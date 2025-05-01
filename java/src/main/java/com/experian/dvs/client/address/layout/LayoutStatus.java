package com.experian.dvs.client.address.layout;

import java.util.HashMap;
import java.util.Map;

public enum LayoutStatus {

    CREATION_IN_PROGRESS("CreationInProgress"),
    COMPLETED("Completed")
    ;

    private final String name;
    //Map of name to LayoutStatus
    private static final Map<String, LayoutStatus> nameToLayoutStatus = new HashMap<>();

    static {
        for (LayoutStatus status : LayoutStatus.values()) {
            nameToLayoutStatus.put(status.getName(), status);
        }
    }

    LayoutStatus(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static LayoutStatus fromName(String name) {
        return nameToLayoutStatus.get(name);
    }
}
