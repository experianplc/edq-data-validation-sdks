namespace DVSClientTests
{
    internal static class Setup
    {
        internal static string ValidTokenAddress = Environment.GetEnvironmentVariable("DVS_API_VALID_TOKEN_ADDRESS");
        internal static string ValidTokenAddressWithEnrichment = Environment.GetEnvironmentVariable("DVS_API_VALID_TOKEN_ADDRESS_WITH_ENRICHMENT");

        internal static string ValidTokenEmail = Environment.GetEnvironmentVariable("DVS_API_VALID_TOKEN_EMAIL");
        internal static string ValidTokenPhone = Environment.GetEnvironmentVariable("DVS_API_VALID_TOKEN_PHONE");

        // These tests assume that a layout with the following name already exists for use in these tests
        // We can't create one on the fly because they take a couple of minutes to complete.
        internal static string ExistingTestLayout = "DVSSDKTestLayoutCSharp";

        // Any layouts created during the tests will be prefixed with this (so that we identify them to clean them up)
        internal static string TestLayoutPrefix = "DVSSDK_CSharp_";
    }
}
