using DVSClient.Address.Datasets;
using DVSClient.Common;
using DVSClient.Exceptions;
using DVSClient.Server;
using DVSClient.Server.Address.Format;
using DVSClient.Server.Address.Search;
using DVSClient.Server.Address.Suggestions;
using DVSClient.Server.Address.Validate;

namespace DVSClient.Address
{
    public class Client : IDisposable
    {
        private readonly Address.Configuration _configuration;
        private readonly IRestApiAsyncStub _restApiAsyncStub;

        public Client(Configuration configuration)
        {
            _configuration = configuration;
            _restApiAsyncStub = new RestApiAsyncImpl(configuration);
        }

        public void Dispose()
        {
            _restApiAsyncStub.Dispose();
        }

        public GetDatasetsResult GetDatasets(Country country)
        {
            try
            {
                return GetDatasetsAsync(country).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Search.Result Search(string searchInput)
        {
            try
            {
                return SearchAsync(searchInput).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Search.Result Search(SearchType searchType, string searchInput)
        {
            try
            {
                return SearchAsync(searchType, searchInput).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Format.Result Format(string addressKey)
        {
            try
            {
                return FormatAsync(addressKey).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Validate.Result Validate(string searchInput)
        {
            try
            {
                return ValidateAsync(searchInput).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Validate.Result Validate(List<string> addressLines)
        {
            try
            {
                return ValidateAsync(addressLines).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Search.Result SuggestionsStepIn(string globalAddressKey)
        {
            try
            {
                return SuggestionsStepInAsync(globalAddressKey).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Search.Result SuggestionsRefine(string key, string refinement)
        {
            try
            {
                return SuggestionsRefineAsync(key, refinement).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Suggestions.Result SuggestionsFormat(string searchInput)
        {
            try
            {
                return SuggestionsFormatAsync(searchInput).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Task<GetDatasetsResult> GetDatasetsAsync(Country country)
        {
            var headers = _configuration.GetCommonHeaders();
            var datasetsResponse = _restApiAsyncStub.GetDatasetsV1(country.Iso3Code, headers);
            return new GetDatasetsResultFuture(datasetsResponse).GetAsync();
        }

        public Task<Search.Result> SuggestionsStepInAsync(string globalAddressKey)
        {
            var headers = _configuration.GetCommonHeaders();
            var stepInResponse = _restApiAsyncStub.SuggestionsStepInV1(globalAddressKey, headers);
            return new Search.ResultFuture(stepInResponse).GetAsync();
        }

        public Task<Search.Result> SuggestionsRefineAsync(string key, string refinement)
        {
            var request = RestApiSuggestionsRefineRequest.Using(_configuration);
            request.Refinement = refinement;
            var headers = _configuration.GetCommonHeaders();
            var refineResponse = _restApiAsyncStub.SuggestionsRefineV1(key, request, headers);
            return new Search.ResultFuture(refineResponse).GetAsync();
        }

        public Task<Suggestions.Result> SuggestionsFormatAsync(string searchInput)
        {
            var request = RestApiSuggestionsFormatRequest.Using(_configuration);
            request.Address = new Server.Address.Address(searchInput);
            var headers = _configuration.GetCommonHeaders();
            var suggestionsFormatResponse = _restApiAsyncStub.SuggestionsFormatV1(request, headers);
            return new Suggestions.ResultFuture(suggestionsFormatResponse).GetAsync();
        }

        public Task<Search.Result> SearchAsync(string searchInput)
        {
            return SearchAsync(SearchType.Autocomplete, searchInput);
        }

        public Task<Search.Result> SearchAsync(SearchType searchType, string searchInput)
        {
            return PerformSearchWithSearchTypeAsync(searchType, searchInput);
        }

        public Task<Format.Result> FormatAsync(string addressKey)
        {
            var request = RestApiFormatRequest.Using(_configuration);
            var headers = GetFormatRequestHeaders();
            var formatResponse = _restApiAsyncStub.FormatV1(addressKey, request, headers);
            return new Format.ResultFuture(formatResponse).GetAsync();
        }

        public Task<Validate.Result> ValidateAsync(string address)
        {
            return ValidateAsync(new List<string> { address });
        }

        public Task<Validate.Result> ValidateAsync(List<string> addressLines)
        {
            return ValidateImplAsync(addressLines);
        }

        private Task<Validate.Result> ValidateImplAsync(List<string> addressLines)
        {
            var request = RestApiAddressValidateRequest.Using(_configuration);
            request.Address = new Server.Address.Address(addressLines);
            var headers = _configuration.GetCommonHeaders();

            if (_configuration.Components)
            {
                headers["Add-Components"] = true.ToString();
            }
            if (_configuration.Metadata)
            {
                headers["Add-Metadata"] = true.ToString();
            }
            if (_configuration.Enrichment)
            {
                headers["Add-Enrichment"] = true.ToString();
            }
            if (_configuration.ExtraMatchInfo)
            {
                headers["Add-ExtraMatchInfo"] = true.ToString();
            }

            var response = _restApiAsyncStub.ValidateV1(request, headers);
            return new Validate.ResultFuture(response).GetAsync();
        }

        private Task<Search.Result> PerformSearchWithSearchTypeAsync(SearchType searchType, string searchInput)
        {
            ValidateDatasetsSearchTypeCombination(_configuration.Datasets, searchType);
            var request = RestApiAddressSearchRequest.Using(_configuration);
            request.Address = new Server.Address.Address(searchInput);

            if (searchType == SearchType.Singleline || searchType == SearchType.Typedown)
            {
                request.AddOption("search_type", searchType.ToString());
            }

            var headers = GetSearchRequestHeaders();
            return GetSearchResultAsync(request, headers);
        }

        private Task<Search.Result> GetSearchResultAsync(RestApiAddressSearchRequest searchRequest, Dictionary<string, object> headers)
        {
            var searchResponse = _restApiAsyncStub.SearchV1(searchRequest, headers);
            return new Search.ResultFuture(searchResponse).GetAsync();
        }

        private Dictionary<string, object> GetSearchRequestHeaders()
        {
            var headers = _configuration.GetCommonHeaders();

            if (_configuration.Transliterate)
            {
                headers["Transliterate"] = true.ToString();
            }

            return headers;
        }

        private void ValidateDatasetsSearchTypeCombination(IEnumerable<Dataset> datasets, SearchType searchType)
        {
            if (datasets.Count() == 1 && datasets.ElementAt(0).SearchTypes.Contains(searchType))
            {
                return;
            }
            else if (datasets.Any())
            {
                var datasetCombinations = searchType.FromSearchType();
                if (datasetCombinations.Any(list => new HashSet<Dataset>(list).SetEquals(datasets)))
                {
                    return;
                }
            }

            throw new EDVSException("Unsupported dataset / search type combination.");
        }

        private Dictionary<string, object> GetFormatRequestHeaders()
        {
            var headers = _configuration.GetCommonHeaders();

            if (_configuration.Components)
            {
                headers["Add-Components"] = true.ToString();
            }
            if (_configuration.Metadata)
            {
                headers["Add-Metadata"] = true.ToString();
            }
            if (_configuration.Enrichment)
            {
                headers["Add-Enrichment"] = true.ToString();
            }

            return headers;
        }
    }
}
