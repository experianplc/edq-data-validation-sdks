using DVSClient.Server.Address.Search;

namespace DVSClient.Address.Search
{
    public class AdditionalAttribute
    {
        public string Name { get; }
        public string Value { get; }

        public AdditionalAttribute(RestApiSearchResultAdditionalAttribute restApiSearchResultAdditionalAttribute)
        {
            Name = restApiSearchResultAdditionalAttribute.Name ?? string.Empty;
            Value = restApiSearchResultAdditionalAttribute.Value ?? string.Empty;
        }
    }
}