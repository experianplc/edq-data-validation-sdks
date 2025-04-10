package com.experian.dvs.client;

public class Setup {
    public static final String VALID_TOKEN_ADDRESS = System.getenv("DVS_API_VALID_TOKEN_ADDRESS");
    public static final String VALID_TOKEN_ADDRESS_WITH_ENRICHMENT = System.getenv("DVS_API_VALID_TOKEN_ADDRESS_WITH_ENRICHMENT");
    public static final String VALID_TOKEN_EMAIL = System.getenv("DVS_API_VALID_TOKEN_EMAIL");
    public static final String VALID_TOKEN_PHONE = System.getenv("DVS_API_VALID_TOKEN_PHONE");

    // These tests assume that a layout with the following name already exists for use in these tests
    // We can't create one on the fly because they take a couple of minutes to complete.
    public static final String EXISTING_TEST_LAYOUT = "DVSSDK_Java_TestLayout";

    // Any layouts created during the tests will be prefixed with this (so that we identify them to clean them up)
    public static final String TEST_LAYOUT_PREFIX = "DVSSDK_Java_";
}
