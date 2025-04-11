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

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class with the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration object for the client.</param>
        public Client(Configuration configuration)
        {
            _configuration = configuration;
            _restApiAsyncStub = new RestApiAsyncImpl(configuration);
        }

        /// <summary>
        /// Disposes of the resources used by the client.
        /// </summary>
        public void Dispose()
        {
            _restApiAsyncStub.Dispose();
        }

        /// <summary>
        /// Retrieves datasets for the specified country.
        /// </summary>
        /// <param name="country">The country for which datasets are requested.</param>
        /// <returns>A result containing the datasets for the specified country.</returns>
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

        /// <summary>
        /// Performs a search using the specified input.
        /// </summary>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>The search result.</returns>
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

        /// <summary>
        /// Performs a search using the specified search type and input.
        /// </summary>
        /// <param name="searchType">The type of search to perform.</param>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>The search result.</returns>
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

        /// <summary>
        /// Formats an address using the specified address key.
        /// </summary>
        /// <param name="addressKey">The key of the address to format.</param>
        /// <returns>The formatted address result.</returns>
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

        /// <summary>
        /// Validates an address using the specified input string.
        /// </summary>
        /// <param name="searchInput">The address input string to validate.</param>
        /// <returns>The validation result.</returns>
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

        /// <summary>
        /// Validates an address using the specified list of address lines.
        /// </summary>
        /// <param name="addressLines">The list of address lines to validate.</param>
        /// <returns>The validation result.</returns>
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

        /// <summary>
        /// Steps into a suggestion using the specified global address key.
        /// </summary>
        /// <param name="globalAddressKey">The global address key for the suggestion.</param>
        /// <returns>The search result after stepping into the suggestion.</returns>
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

        /// <summary>
        /// Refines a suggestion using the specified key and refinement string.
        /// </summary>
        /// <param name="key">The key of the suggestion to refine.</param>
        /// <param name="refinement">The refinement string.</param>
        /// <returns>The search result after refining the suggestion.</returns>
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

        /// <summary>
        /// Formats suggestions based on the specified search input.
        /// </summary>
        /// <param name="searchInput">The search input string for formatting suggestions.</param>
        /// <returns>The formatted suggestions result.</returns>
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

        /// <summary>
        /// Asynchronously retrieves datasets for the specified country.
        /// </summary>
        /// <param name="country">The country for which datasets are requested.</param>
        /// <returns>A task representing the asynchronous operation, containing the datasets result.</returns>
        public Task<GetDatasetsResult> GetDatasetsAsync(Country country)
        {
            var headers = _configuration.GetCommonHeaders();
            var datasetsResponse = _restApiAsyncStub.GetDatasetsV1(country.Iso3Code, headers);
            return new GetDatasetsResultFuture(datasetsResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously steps into a suggestion using the specified global address key.
        /// </summary>
        /// <param name="globalAddressKey">The global address key for the suggestion.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result after stepping into the suggestion.</returns>
        public Task<Search.Result> SuggestionsStepInAsync(string globalAddressKey)
        {
            var headers = _configuration.GetCommonHeaders();
            var stepInResponse = _restApiAsyncStub.SuggestionsStepInV1(globalAddressKey, headers);
            return new Search.ResultFuture(stepInResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously refines a suggestion using the specified key and refinement string.
        /// </summary>
        /// <param name="key">The key of the suggestion to refine.</param>
        /// <param name="refinement">The refinement string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result after refining the suggestion.</returns>
        public Task<Search.Result> SuggestionsRefineAsync(string key, string refinement)
        {
            var request = RestApiSuggestionsRefineRequest.Using(_configuration);
            request.Refinement = refinement;
            var headers = _configuration.GetCommonHeaders();
            var refineResponse = _restApiAsyncStub.SuggestionsRefineV1(key, request, headers);
            return new Search.ResultFuture(refineResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously formats suggestions based on the specified search input.
        /// </summary>
        /// <param name="searchInput">The search input string for formatting suggestions.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted suggestions result.</returns>
        public Task<Suggestions.Result> SuggestionsFormatAsync(string searchInput)
        {
            var request = RestApiSuggestionsFormatRequest.Using(_configuration);
            request.Address = new Server.Address.Address(searchInput);
            var headers = _configuration.GetCommonHeaders();
            var suggestionsFormatResponse = _restApiAsyncStub.SuggestionsFormatV1(request, headers);
            return new Suggestions.ResultFuture(suggestionsFormatResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously performs a search using the specified input.
        /// </summary>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<Search.Result> SearchAsync(string searchInput)
        {
            return SearchAsync(SearchType.Autocomplete, searchInput);
        }

        /// <summary>
        /// Asynchronously performs a search using the specified search type and input.
        /// </summary>
        /// <param name="searchType">The type of search to perform.</param>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<Search.Result> SearchAsync(SearchType searchType, string searchInput)
        {
            return PerformSearchWithSearchTypeAsync(searchType, searchInput);
        }

        /// <summary>
        /// Asynchronously formats an address using the specified address key.
        /// </summary>
        /// <param name="addressKey">The key of the address to format.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted address result.</returns>
        public Task<Format.Result> FormatAsync(string addressKey)
        {
            var request = RestApiFormatRequest.Using(_configuration);
            var headers = GetFormatRequestHeaders();
            var formatResponse = _restApiAsyncStub.FormatV1(addressKey, request, headers);
            return new Format.ResultFuture(formatResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously validates an address using the specified input string.
        /// </summary>
        /// <param name="address">The address input string to validate.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
        public Task<Validate.Result> ValidateAsync(string address)
        {
            return ValidateAsync(new List<string> { address });
        }

        /// <summary>
        /// Asynchronously validates an address using the specified list of address lines.
        /// </summary>
        /// <param name="addressLines">The list of address lines to validate.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
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
