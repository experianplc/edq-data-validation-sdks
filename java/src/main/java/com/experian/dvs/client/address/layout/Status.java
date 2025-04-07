package com.experian.dvs.client.address.layout;

import java.util.HashMap;
import java.util.Map;

public enum Status {

    CREATION_IN_PROGRESS("CreationInProgress"),
    COMPLETED("Completed")
    ;

    private final String name;
    //Map of name to LayoutStatus
    private static final Map<String, Status> nameToLayoutStatus = new HashMap<>();

    static {
        for (Status status : Status.values()) {
            nameToLayoutStatus.put(status.getName(), status);
        }
    }

    Status(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static Status fromName(String name) {
        return nameToLayoutStatus.get(name);
    }
}
