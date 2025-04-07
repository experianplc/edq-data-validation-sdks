package com.experian.dvs.client.common;

public class ClientReference {

    private static final String PRODUCT = "SDK";
    private static final String INTERFACE = "Java";

    private ClientReference() {
        // Prevent instantiation
    }

    public static String getReference(final String uuid, boolean allowsDotInReferenceId) {
        String version = ClientReference.class.getPackage().getImplementationVersion();

        // TODO once API has been updated.
        if (version != null && !allowsDotInReferenceId)
        {
            version = version.replace('.', '-');
        }

        return String.format("product:%s/version:%s/interface:%s/transaction:%s", PRODUCT, version, INTERFACE, uuid);
    }
}
