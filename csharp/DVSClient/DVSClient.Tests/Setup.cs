namespace DVSClientTests
{
    internal static class Setup
    {
        
        internal static string ValidTokenAddress = GetEnvironmentVariableOrThrow("DVS_API_VALID_TOKEN_ADDRESS");
        internal static string ValidTokenAddressWithEnrichment = GetEnvironmentVariableOrThrow("DVS_API_VALID_TOKEN_ADDRESS_WITH_ENRICHMENT");

        internal static string ValidTokenEmail = GetEnvironmentVariableOrThrow("DVS_API_VALID_TOKEN_EMAIL");
        internal static string ValidTokenPhone = GetEnvironmentVariableOrThrow("DVS_API_VALID_TOKEN_PHONE");

        // These tests assume that a layout with the following name already exists for use in these tests
        // We can't create one on the fly because they take a couple of minutes to complete.
        internal static string ExistingTestLayout = "DVSSDK_CSharp_TestLayout";

        // Any layouts created during the tests will be prefixed with this (so that we identify them to clean them up)
        internal static string TestLayoutPrefix = "DVSSDK_CSharp_";

        private static string GetEnvironmentVariableOrThrow(string variableName)
        {
            var value = Environment.GetEnvironmentVariable(variableName);
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"The environment variable '{variableName}' is not set or is empty.\r\n" +
                    $"You can add a .env file to the project containing the environment variables as key-value pairs.");
            }
            return value;
        }

        public static void LoadEnv() 
        {
            DotNetEnv.Env.TraversePath().Load();
        }
    }
}
