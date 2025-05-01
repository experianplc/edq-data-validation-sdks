using DVSClient.Server.Address.Datasets;
using DVSClient.Server.Address.Format;
using DVSClient.Server.Address.Layout;
using DVSClient.Server.Address.Search;
using DVSClient.Server.Address.Suggestions;
using DVSClient.Server.Address.Validate;
using DVSClient.Server.Email;
using DVSClient.Server.Phone;
using DVSClient.Server.Address.Lookup;

namespace DVSClient.Server
{
    public interface IRestApiAsyncStub : IDisposable
    {
        // Address
        Task<RestApiAddressSearchResponse> SearchV1(RestApiAddressSearchRequest searchRequest, IDictionary<string, object> headers);
        Task<RestApiAddressFormatResponse> FormatV1(string addressKey, RestApiFormatRequest formatRequest, IDictionary<string, object> headers);
        Task<RestApiAddressValidateResponse> ValidateV1(RestApiAddressValidateRequest validateRequest, IDictionary<string, object> headers);
        Task<RestApiAddressSearchResponse> SuggestionsStepInV1(string globalAddressKey, IDictionary<string, object> headers);
        Task<RestApiAddressSearchResponse> SuggestionsRefineV1(string key, RestApiSuggestionsRefineRequest refineRequest, IDictionary<string, object> headers);
        Task<RestApiSuggestionsFormatResponse> SuggestionsFormatV1(RestApiSuggestionsFormatRequest formatRequest, IDictionary<string, object> headers);
        Task<RestApiAddressLookupV2Response> LookupV2(RestApiAddressLookupV2Request request, IDictionary<string, object> headers);

        // Address utilities
        Task<RestApiGetDatasetsResponse> GetDatasetsV1(string countryIso3, IDictionary<string, object> headers);

        // TODO: promptset

        // Layouts
        Task<RestApiCreateLayoutResponse> CreateLayoutV2(RestApiCreateLayoutRequest createLayoutRequest, IDictionary<string, object> headers);
        Task<RestApiGetLayoutListResponse> GetLayoutsV2(string countryIso3, List<string> datasets, string nameContains, IDictionary<string, object> headers);
        Task<RestApiGetLayoutResponse> GetLayoutV2(string layoutName, IDictionary<string, object> headers);
        Task<RestApiDeleteLayoutResponse> DeleteLayoutV2(string layoutName, IDictionary<string, object> headers);

        // Phone
        Task<RestApiPhoneValidateResponse> ValidatePhoneV2(RestApiPhoneValidateRequest validatePhoneRequest, IDictionary<string, object> headers);

        // Email
        Task<RestApiEmailValidateResponse> ValidateEmailV2(RestApiEmailValidateRequest validateEmailRequest, IDictionary<string, object> headers);
    }
}