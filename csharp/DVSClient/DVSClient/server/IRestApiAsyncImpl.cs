using System.Text;
using System.Web;
using DVSClient.Common;
using DVSClient.Server.Address.Datasets;
using DVSClient.Server.Address.Format;
using DVSClient.Server.Address.Layout;
using DVSClient.Server.Address.Search;
using DVSClient.Server.Address.Suggestions;
using DVSClient.Server.Address.Validate;
using DVSClient.Server.Address.Lookup;
using DVSClient.Server.Email;
using DVSClient.Server.Phone;
using Newtonsoft.Json;
using System.Net;

namespace DVSClient.Server
{
    public class RestApiAsyncImpl : IRestApiAsyncStub
    {
        private readonly Configuration _configuration;
        private readonly HttpClient _client;

        public RestApiAsyncImpl(Configuration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient { 
                BaseAddress = configuration.GetServerUri(), 
                Timeout = TimeSpan.FromSeconds(configuration.GetHttpClientTimeoutInSeconds())
            };
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<RestApiAddressSearchResponse> SearchV1(RestApiAddressSearchRequest searchRequest, IDictionary<string, object> headers)
        {
            var endPoint = "address/search/v1";
            return await PostAsync<RestApiAddressSearchResponse>(endPoint, searchRequest, headers);
        }

        public async Task<RestApiAddressFormatResponse> FormatV1(string addressKey, RestApiFormatRequest formatRequest, IDictionary<string, object> headers)
        {
            var endPoint = $"address/format/v1/{addressKey}";
            return await PostAsync<RestApiAddressFormatResponse>(endPoint, formatRequest, headers);
        }

        public async Task<RestApiCreateLayoutResponse> CreateLayoutV2(RestApiCreateLayoutRequest createLayoutRequest, IDictionary<string, object> headers)
        {
            var endPoint = "address/layouts/v2";
            return await PostAsync<RestApiCreateLayoutResponse>(endPoint, createLayoutRequest, headers);
        }

        public async Task<RestApiGetLayoutListResponse> GetLayoutsV2(string countryIso3, List<string> datasets, string nameContains, IDictionary<string, object> headers)
        {
            var endPoint = "address/layouts/v2/";
            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(countryIso3))
            {
                parameters.Add("country_iso", countryIso3);
            }

            if (datasets != null && datasets.Count > 0)
            {
                parameters.Add("datasets", string.Join(",", datasets));
            }
            
            if (!string.IsNullOrWhiteSpace(nameContains))
            {
                parameters.Add("name_contains", nameContains);
            }

            return await GetAsync<RestApiGetLayoutListResponse>(endPoint, headers, parameters);
        }

        public async Task<RestApiGetLayoutResponse> GetLayoutV2(string layoutName, IDictionary<string, object> headers)
        {
            var endPoint = $"address/layouts/v2/{layoutName}";
            return await GetAsync<RestApiGetLayoutResponse>(endPoint, headers, new Dictionary<string, string>());
        }

        public async Task<RestApiDeleteLayoutResponse> DeleteLayoutV2(string layoutName, IDictionary<string, object> headers)
        {
            var endPoint = $"address/layouts/v2/{layoutName}";
            return await DeleteAsync<RestApiDeleteLayoutResponse>(endPoint, headers, new Dictionary<string, string>());
        }

        public async Task<RestApiGetDatasetsResponse> GetDatasetsV1(string countryIso3, IDictionary<string, object> headers)
        {
            var endPoint = "address/datasets/v1";
            var parameters = new Dictionary<string, string> { { "country_iso", countryIso3 } };
            return await GetAsync<RestApiGetDatasetsResponse>(endPoint, headers, parameters);
        }

        public async Task<RestApiAddressValidateResponse> ValidateV1(RestApiAddressValidateRequest validateRequest, IDictionary<string, object> headers)
        {
            var endPoint = "address/validate/v1";
            return await PostAsync<RestApiAddressValidateResponse>(endPoint, validateRequest, headers);
        }

        public async Task<RestApiAddressSearchResponse> SuggestionsStepInV1(string global_address_key, IDictionary<string, object> headers)
        {
            var endPoint = $"/address/suggestions/stepin/v1/{global_address_key}";
            return await GetAsync<RestApiAddressSearchResponse>(endPoint, headers);
        }

        public async Task<RestApiAddressSearchResponse> SuggestionsRefineV1(string key, RestApiSuggestionsRefineRequest refineRequest, IDictionary<string, object> headers)
        {
            var endPoint = $"/address/suggestions/refine/v1/{key}";
            return await PostAsync<RestApiAddressSearchResponse>(endPoint, refineRequest, headers);
        }

        public async Task<RestApiSuggestionsFormatResponse> SuggestionsFormatV1(RestApiSuggestionsFormatRequest formatRequest, IDictionary<string, object> headers)
        {
            var endPoint = $"/address/suggestions/format/v1/";
            return await PostAsync<RestApiSuggestionsFormatResponse>(endPoint, formatRequest, headers);
        }

        public async Task<RestApiAddressLookupV2Response> LookupV2(RestApiAddressLookupV2Request request, IDictionary<string, object> headers)
        {
            var endPoint = "address/lookup/v2";
            return await PostAsync<RestApiAddressLookupV2Response>(endPoint, request, headers);
        }

        public async Task<RestApiPhoneValidateResponse> ValidatePhoneV2(RestApiPhoneValidateRequest validatePhoneRequest, IDictionary<string, object> headers)
        {
            var endPoint = "phone/validate/v2";
            return await PostAsync<RestApiPhoneValidateResponse>(endPoint, validatePhoneRequest, headers);
        }

        public async Task<RestApiEmailValidateResponse> ValidateEmailV2(RestApiEmailValidateRequest validateEmailRequest, IDictionary<string, object> headers)
        {
            var endPoint = "email/validate/v2";
            return await PostAsync<RestApiEmailValidateResponse>(endPoint, validateEmailRequest, headers);
        }

        private async Task<T> ExecuteWithRetryAsync<T>(Func<Task<HttpResponseMessage>> operation) where T : RestApiResponse
        {
            int attempt = 0;
            int delay = _configuration.GetInitialDelayInMilliseconds();

            while (attempt < _configuration.GetMaxRetries())
            {
                try
                {
                    var response = await operation();
                    var content = await response.Content.ReadAsStringAsync();

                    // init to 204 - no content response
                    var noContentResponse = new { };
                    T result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(noContentResponse))
                                   ?? throw new InvalidOperationException("Deserialization returned null.");

                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.NoContent)
                        {
                            // Successful Delete operation returns 204 - No Content
                            return result;
                        }
                        else
                        {
                            result = JsonConvert.DeserializeObject<T>(content) ?? throw new InvalidOperationException("Deserialization returned null.");
                        }
                    }

                    if ((int)response.StatusCode >= 500)
                    {
                        throw new HttpRequestException($"Server error: {(int)response.StatusCode}");
                    }
                    else if ((int)response.StatusCode == 404)
                    {
                        // Only Get / Delete on missing layout is throwing 404
                        var errorResponse = new { Error = new { Title = response.ReasonPhrase } };
                        result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(errorResponse)) ?? throw new InvalidOperationException("Deserialization returned null.");
                    }
                    else if ((int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
                    {
                        // Do not retry on client errors (4xx)
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            result = JsonConvert.DeserializeObject<T>(content) ?? throw new InvalidOperationException("Deserialization returned null.");
                        }
                        else
                        {
                            result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(new { Error = new { Title = response.ReasonPhrase } }))
                                   ?? throw new InvalidOperationException("Deserialization returned null.");
                        }
                    }

                    result.ReferenceId = GetRefIdFromHeaderValue(response.Headers.GetValues("Reference-Id").FirstOrDefault(string.Empty));

                    return result;
                }
                catch (HttpRequestException)
                {
                    attempt++;
                    if (attempt >= _configuration.GetMaxRetries())
                    {
                        throw;
                    }

                    // Use capped exponential backoff pattern to determine delay before resubmitting the request
                    await Task.Delay(delay);
                    delay = Math.Min(delay * 2, _configuration.GetMaxDelayInMilliseconds());
                }
            }
            throw new Exception("Max retry attempts exceeded.");
        }

        private string GetRefIdFromHeaderValue(string referenceId)
        {
            string pattern = "/transaction:";
            if (referenceId.Contains(pattern))
            {
                referenceId = referenceId.Substring(referenceId.LastIndexOf(pattern) + pattern.Length);
            }

            return referenceId;
        }

        private async Task<T> PostAsync<T>(string endPoint, object requestObject, IDictionary<string, object> headers) where T : RestApiResponse
        {
            return await ExecuteWithRetryAsync<T>(async () =>
            {
                var request = new HttpRequestMessage(HttpMethod.Post, endPoint)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json")
                };
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value.ToString());
                }
                return await _client.SendAsync(request);
            });
        }

        private async Task<T> GetAsync<T>(string endPoint, IDictionary<string, object> headers) where T : RestApiResponse
        {
            return await GetAsync<T>(endPoint, headers, new Dictionary<string, string>());
        }

        private async Task<T> GetAsync<T>(string endPoint, IDictionary<string, object> headers, IDictionary<string, string> parameters) where T : RestApiResponse
        {
            return await ExecuteWithRetryAsync<T>(async () =>
            {
                if (_client.BaseAddress == null)
                {
                    throw new InvalidOperationException("BaseAddress is not set on the HttpClient.");
                }

                var uriBuilder = new UriBuilder(new Uri(_client.BaseAddress, endPoint));
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                foreach (var param in parameters)
                {
                    query[param.Key] = param.Value;
                }
                uriBuilder.Query = query.ToString();
                var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value.ToString());
                }
                return await _client.SendAsync(request);
            });
        }

        private async Task<T> DeleteAsync<T>(string endPoint, IDictionary<string, object> headers, IDictionary<string, string> parameters) where T : RestApiResponse
        {
            return await ExecuteWithRetryAsync<T>(async () =>
            {
                if (_client.BaseAddress == null)
                {
                    throw new InvalidOperationException("BaseAddress is not set on the HttpClient.");
                }

                var uriBuilder = new UriBuilder(new Uri(_client.BaseAddress, endPoint));
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                foreach (var param in parameters)
                {
                    query[param.Key] = param.Value;
                }

                uriBuilder.Query = query.ToString();
                var request = new HttpRequestMessage(HttpMethod.Delete, uriBuilder.ToString());
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value.ToString());
                }
                return await _client.SendAsync(request);
            });
        }
    }
}