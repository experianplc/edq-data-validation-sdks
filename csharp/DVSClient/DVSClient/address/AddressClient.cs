using DVSClient.address.lookup;
using DVSClient.Address.Datasets;
using DVSClient.Address.Format;
using DVSClient.Address.Search;
using DVSClient.Address.Suggestions;
using DVSClient.Address.Validate;
using DVSClient.Common;
using DVSClient.Exceptions;
using DVSClient.Server;
using DVSClient.Server.Address.Format;
using DVSClient.Server.Address.Lookup;
using DVSClient.Server.Address.Search;
using DVSClient.Server.Address.Suggestions;
using DVSClient.Server.Address.Validate;

namespace DVSClient.Address
{
    public class AddressClient : IDisposable
    {
        private readonly Address.AddressConfiguration _configuration;
        private readonly IRestApiAsyncStub _restApiAsyncStub;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressClient"/> class with the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration object for the client.</param>
        public AddressClient(AddressConfiguration configuration)
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

        /**
        * Looks up an address based on a key.
        * @param value The key being used to perform the lookup
        * @param lookupType The type of lookup that you wish to perform.
        * @returns A promise that resolves to the result containing the found addresses / suggestions.
        */
        public LookupResult Lookup(String value, LookupType lookupType)
        {
            try
            {
                return LookupAsync(value, lookupType).GetAwaiter().GetResult();
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
        public SearchResult Search(string searchInput)
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
        public SearchResult Search(SearchType searchType, string searchInput)
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
        public FormatResult Format(string addressKey)
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
        public ValidateResult Validate(string searchInput)
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
        public ValidateResult Validate(List<string> addressLines)
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
        public SearchResult SuggestionsStepIn(string globalAddressKey)
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
        public SearchResult SuggestionsRefine(string key, string refinement)
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
        public SuggestionsFormatResult SuggestionsFormat(string searchInput)
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

        /**
        * Asynchronously looks up an address based on a key.
        * @param value The key being used to perform the lookup
        * @param lookupType The type of lookup that you wish to perform.
        * @returns A promise that resolves to the result containing the found addresses / suggestions.
        */
        public Task<LookupResult> LookupAsync(String value, LookupType lookupType)
        {
            var headers = _configuration.GetCommonHeaders();
            if (_configuration.LookupAddAddresses) 
            {
                headers.Add("Add-Addresses", "true");
            }
            if (_configuration.LookupAddFinalAddress) 
            {
                headers.Add("Add-FinalAddress", "true");
            }

            var request = RestApiAddressLookupV2Request.Using(value, lookupType, _configuration);
            var lookupResponse = _restApiAsyncStub.LookupV2(request, headers);
            return new LookupResultFuture(lookupResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously steps into a suggestion using the specified global address key.
        /// </summary>
        /// <param name="globalAddressKey">The global address key for the suggestion.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result after stepping into the suggestion.</returns>
        public Task<Search.SearchResult> SuggestionsStepInAsync(string globalAddressKey)
        {
            var headers = _configuration.GetCommonHeaders();
            var stepInResponse = _restApiAsyncStub.SuggestionsStepInV1(globalAddressKey, headers);
            return new Search.SearchResultFuture(stepInResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously refines a suggestion using the specified key and refinement string.
        /// </summary>
        /// <param name="key">The key of the suggestion to refine.</param>
        /// <param name="refinement">The refinement string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result after refining the suggestion.</returns>
        public Task<Search.SearchResult> SuggestionsRefineAsync(string key, string refinement)
        {
            var request = RestApiSuggestionsRefineRequest.Using(_configuration);
            request.Refinement = refinement;
            var headers = _configuration.GetCommonHeaders();
            var refineResponse = _restApiAsyncStub.SuggestionsRefineV1(key, request, headers);
            return new Search.SearchResultFuture(refineResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously formats suggestions based on the specified search input.
        /// </summary>
        /// <param name="searchInput">The search input string for formatting suggestions.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted suggestions result.</returns>
        public Task<Suggestions.SuggestionsFormatResult> SuggestionsFormatAsync(string searchInput)
        {
            var request = RestApiSuggestionsFormatRequest.Using(_configuration);
            request.Address = new Server.Address.Address(searchInput);
            var headers = _configuration.GetCommonHeaders();
            var suggestionsFormatResponse = _restApiAsyncStub.SuggestionsFormatV1(request, headers);
            return new Suggestions.SuggestionsFormatResultFuture(suggestionsFormatResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously performs a search using the specified input.
        /// </summary>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<Search.SearchResult> SearchAsync(string searchInput)
        {
            return SearchAsync(SearchType.Autocomplete, searchInput);
        }

        /// <summary>
        /// Asynchronously performs a search using the specified search type and input.
        /// </summary>
        /// <param name="searchType">The type of search to perform.</param>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<Search.SearchResult> SearchAsync(SearchType searchType, string searchInput)
        {
            return PerformSearchWithSearchTypeAsync(searchType, searchInput);
        }

        /// <summary>
        /// Asynchronously formats an address using the specified address key.
        /// </summary>
        /// <param name="addressKey">The key of the address to format.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted address result.</returns>
        public Task<Format.FormatResult> FormatAsync(string addressKey)
        {
            var request = RestApiFormatRequest.Using(_configuration);
            var headers = GetFormatRequestHeaders();
            var formatResponse = _restApiAsyncStub.FormatV1(addressKey, request, headers);
            return new Format.FormatResultFuture(formatResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously validates an address using the specified input string.
        /// </summary>
        /// <param name="address">The address input string to validate.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
        public Task<Validate.ValidateResult> ValidateAsync(string address)
        {
            return ValidateAsync(new List<string> { address });
        }

        /// <summary>
        /// Asynchronously validates an address using the specified list of address lines.
        /// </summary>
        /// <param name="addressLines">The list of address lines to validate.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
        public Task<Validate.ValidateResult> ValidateAsync(List<string> addressLines)
        {
            return ValidateImplAsync(addressLines);
        }

        private Task<Validate.ValidateResult> ValidateImplAsync(List<string> addressLines)
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
            return new Validate.ValidateResultFuture(response).GetAsync();
        }

        private Task<Search.SearchResult> PerformSearchWithSearchTypeAsync(SearchType searchType, string searchInput)
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

        private Task<Search.SearchResult> GetSearchResultAsync(RestApiAddressSearchRequest searchRequest, Dictionary<string, object> headers)
        {
            var searchResponse = _restApiAsyncStub.SearchV1(searchRequest, headers);
            return new Search.SearchResultFuture(searchResponse).GetAsync();
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
