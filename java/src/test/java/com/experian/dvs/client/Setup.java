package com.experian.dvs.client;

import io.github.cdimascio.dotenv.Dotenv;

public class Setup {
    public static String VALID_TOKEN_ADDRESS;
    public static String VALID_TOKEN_PHONE;
    public static String VALID_TOKEN_EMAIL;
    public static String VALID_TOKEN_ADDRESS_WITH_ENRICHMENT;

    // These tests assume that a layout with the following name already exists for use in these tests
    // We can't create one on the fly because they take a couple of minutes to complete.
    public static final String EXISTING_TEST_LAYOUT = "DVSSDK_Java_TestLayout";

    // Any layouts created during the tests will be prefixed with this (so that we identify them to clean them up)
    public static final String TEST_LAYOUT_PREFIX = "DVSSDK_Java_";

    public static void loadEnv() {
        // Load environment variables using dotenv
        Dotenv dotenv = Dotenv
                .configure()
                .ignoreIfMissing()
                .load();

        // Initialize environment variables
        VALID_TOKEN_ADDRESS = dotenv.get("DVS_API_VALID_TOKEN_ADDRESS");
        VALID_TOKEN_ADDRESS_WITH_ENRICHMENT = dotenv.get("DVS_API_VALID_TOKEN_ADDRESS_WITH_ENRICHMENT");
        VALID_TOKEN_EMAIL = dotenv.get("DVS_API_VALID_TOKEN_EMAIL");
        VALID_TOKEN_PHONE = dotenv.get("DVS_API_VALID_TOKEN_PHONE");
    }
}
