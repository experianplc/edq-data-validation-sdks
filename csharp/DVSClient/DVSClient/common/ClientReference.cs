using System.Reflection;

namespace DVSClient.Common
{
    public class ClientReference
    {
        private const string PRODUCT = "SDK";
        private const string INTERFACE = "CSharp";

        // Private constructor to prevent instantiation
        private ClientReference() { }

        public static string GetReference(string uuid, bool allowsDotInReferenceId = true)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly?.GetName().Version?.ToString() ?? "0.0.0.0";

            // TODO once API has been updated.
            if (!allowsDotInReferenceId)
            {
                version = version.Replace('.', '-');
            }

            return $"product:{PRODUCT}/version:{version}/interface:{INTERFACE}/transaction:{uuid}";
        }
    }
}