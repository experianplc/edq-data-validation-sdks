using DVSClient.Address.Datasets;
using DVSClient.Address.Format;
using DVSClient.Address.Lookup;
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
        private readonly AddressConfiguration _configuration;
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
            return GetDatasets(country, string.Empty);
        }

        /// <summary>
        /// Retrieves datasets for the specified country.
        /// </summary>
        /// <param name="country">The country for which datasets are requested.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A result containing the datasets for the specified country.</returns>
        public GetDatasetsResult GetDatasets(Country country, string referenceId)
        {
            try
            {
                return GetDatasetsAsync(country, referenceId).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        /// <summary>
        /// Looks up an address based on a key.
        /// </summary>
        /// <param name="value">The key being used to perform the lookup.</param>
        /// <param name="lookupType">The type of lookup that you wish to perform.</param>
        /// <returns>The result containing the found addresses or suggestions.</returns>
        public LookupResult Lookup(String value, LookupType lookupType)
        {
            return Lookup(value, lookupType);
        }

        /// <summary>
        /// Looks up an address based on a key.
        /// </summary>
        /// <param name="value">The key being used to perform the lookup.</param>
        /// <param name="lookupType">The type of lookup that you wish to perform.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The result containing the found addresses or suggestions.</returns>
        public LookupResult Lookup(String value, LookupType lookupType, string referenceId)
        {
            try
            {
                return LookupAsync(value, lookupType, referenceId).GetAwaiter().GetResult();
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
            return Search(SearchType.Autocomplete, searchInput, string.Empty);
        }

        /// <summary>
        /// Performs a search using the specified input.
        /// </summary>
        /// <param name="searchInput">The search input string.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The search result.</returns>
        public SearchResult Search(string searchInput, string referenceId)
        {
            return Search(SearchType.Autocomplete, searchInput, referenceId);
        }

        /// <summary>
        /// Performs a search using the specified search type and input.
        /// </summary>
        /// <param name="searchType">The type of search to perform.</param>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>The search result.</returns>
        public SearchResult Search(SearchType searchType, string searchInput)
        {
            return Search(searchType, searchInput, string.Empty);
        }

        /// <summary>
        /// Performs a search using the specified search type and input.
        /// </summary>
        /// <param name="searchType">The type of search to perform.</param>
        /// <param name="searchInput">The search input string.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The search result.</returns>
        public SearchResult Search(SearchType searchType, string searchInput, string referenceId)
        {
            try
            {
                return SearchAsync(searchType, searchInput, referenceId).GetAwaiter().GetResult();
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
            return Format(addressKey, string.Empty);
        }

        /// <summary>
        /// Formats an address using the specified address key.
        /// </summary>
        /// <param name="addressKey">The key of the address to format.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The formatted address result.</returns>
        public FormatResult Format(string addressKey, string referenceId)
        {
            try
            {
                return FormatAsync(addressKey, referenceId).GetAwaiter().GetResult();
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
            return Validate(searchInput, string.Empty);
        }

        /// <summary>
        /// Validates an address using the specified input string.
        /// </summary>
        /// <param name="searchInput">The address input string to validate.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The validation result.</returns>
        public ValidateResult Validate(string searchInput, string referenceId)
        {
            try
            {
                return ValidateAsync(searchInput, referenceId).GetAwaiter().GetResult();
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
            return Validate(addressLines, string.Empty);
        }

        /// <summary>
        /// Validates an address using the specified list of address lines.
        /// </summary>
        /// <param name="addressLines">The list of address lines to validate.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The validation result.</returns>
        public ValidateResult Validate(List<string> addressLines, string referenceId)
        {
            try
            {
                return ValidateAsync(addressLines, referenceId).GetAwaiter().GetResult();
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
            return SuggestionsStepIn(globalAddressKey, string.Empty);
        }

        /// <summary>
        /// Steps into a suggestion using the specified global address key.
        /// </summary>
        /// <param name="globalAddressKey">The global address key for the suggestion.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The search result after stepping into the suggestion.</returns>
        public SearchResult SuggestionsStepIn(string globalAddressKey, string referenceId)
        {
            try
            {
                return SuggestionsStepInAsync(globalAddressKey, referenceId).GetAwaiter().GetResult();
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
            return SuggestionsRefine(key, refinement, string.Empty);
        }

        /// <summary>
        /// Refines a suggestion using the specified key and refinement string.
        /// </summary>
        /// <param name="key">The key of the suggestion to refine.</param>
        /// <param name="refinement">The refinement string.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The search result after refining the suggestion.</returns>
        public SearchResult SuggestionsRefine(string key, string refinement, string referenceId)
        {
            try
            {
                return SuggestionsRefineAsync(key, refinement, referenceId).GetAwaiter().GetResult();
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
            return SuggestionsFormat(searchInput, string.Empty);
        }

        /// <summary>
        /// Formats suggestions based on the specified search input.
        /// </summary>
        /// <param name="searchInput">The search input string for formatting suggestions.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>The formatted suggestions result.</returns>
        public SuggestionsFormatResult SuggestionsFormat(string searchInput, string referenceId)
        {
            try
            {
                return SuggestionsFormatAsync(searchInput, referenceId).GetAwaiter().GetResult();
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
            return GetDatasetsAsync(country, string.Empty);
        }

        /// <summary>
        /// Asynchronously retrieves datasets for the specified country.
        /// </summary>
        /// <param name="country">The country for which datasets are requested.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the datasets result.</returns>
        public Task<GetDatasetsResult> GetDatasetsAsync(Country country, string referenceId)
        {
            var headers = _configuration.GetCommonHeaders(referenceId);
            var datasetsResponse = _restApiAsyncStub.GetDatasetsV1(country.Iso3Code, headers);
            return new GetDatasetsResultFuture(datasetsResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously looks up an address based on a key.
        /// </summary>
        /// <param name="value">The key being used to perform the lookup.</param>
        /// <param name="lookupType">The type of lookup that you wish to perform.</param>
        /// <returns>A task that resolves to the result containing the found addresses or suggestions.</returns>
        public Task<LookupResult> LookupAsync(string value, LookupType lookupType)
        {
            return LookupAsync(value, lookupType, string.Empty);
        }

        /// <summary>
        /// Asynchronously looks up an address based on a key.
        /// </summary>
        /// <param name="value">The key being used to perform the lookup.</param>
        /// <param name="lookupType">The type of lookup that you wish to perform.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task that resolves to the result containing the found addresses or suggestions.</returns>
        public Task<LookupResult> LookupAsync(string value, LookupType lookupType, string referenceId)
        {
            var headers = _configuration.GetCommonHeaders(referenceId);
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
        public Task<SearchResult> SuggestionsStepInAsync(string globalAddressKey)
        {
            return SuggestionsStepInAsync(globalAddressKey, string.Empty);
        }

        /// <summary>
        /// Asynchronously steps into a suggestion using the specified global address key.
        /// </summary>
        /// <param name="globalAddressKey">The global address key for the suggestion.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result after stepping into the suggestion.</returns>
        public Task<SearchResult> SuggestionsStepInAsync(string globalAddressKey, string referenceId)
        {
            var headers = _configuration.GetCommonHeaders(referenceId);
            var stepInResponse = _restApiAsyncStub.SuggestionsStepInV1(globalAddressKey, headers);
            return new SearchResultFuture(stepInResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously refines a suggestion using the specified key and refinement string.
        /// </summary>
        /// <param name="key">The key of the suggestion to refine.</param>
        /// <param name="refinement">The refinement string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result after refining the suggestion.</returns>
        public Task<SearchResult> SuggestionsRefineAsync(string key, string refinement)
        {
            return SuggestionsRefineAsync(key, refinement, string.Empty);
        }

        /// <summary>
        /// Asynchronously refines a suggestion using the specified key and refinement string.
        /// </summary>
        /// <param name="key">The key of the suggestion to refine.</param>
        /// <param name="refinement">The refinement string.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result after refining the suggestion.</returns>
        public Task<SearchResult> SuggestionsRefineAsync(string key, string refinement, string referenceId)
        {
            var request = RestApiSuggestionsRefineRequest.Using(_configuration);
            request.Refinement = refinement;
            var headers = _configuration.GetCommonHeaders(referenceId);
            var refineResponse = _restApiAsyncStub.SuggestionsRefineV1(key, request, headers);
            return new SearchResultFuture(refineResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously formats suggestions based on the specified search input.
        /// </summary>
        /// <param name="searchInput">The search input string for formatting suggestions.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted suggestions result.</returns>
        public Task<SuggestionsFormatResult> SuggestionsFormatAsync(string searchInput)
        {
            return SuggestionsFormatAsync(searchInput, string.Empty);
        }

        /// <summary>
        /// Asynchronously formats suggestions based on the specified search input.
        /// </summary>
        /// <param name="searchInput">The search input string for formatting suggestions.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted suggestions result.</returns>
        public Task<SuggestionsFormatResult> SuggestionsFormatAsync(string searchInput, string referenceId)
        {
            var request = RestApiSuggestionsFormatRequest.Using(_configuration);
            request.Address = new Server.Address.Address(searchInput);
            var headers = _configuration.GetCommonHeaders(referenceId);
            var suggestionsFormatResponse = _restApiAsyncStub.SuggestionsFormatV1(request, headers);
            return new SuggestionsFormatResultFuture(suggestionsFormatResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously performs a search using the specified input.
        /// </summary>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<SearchResult> SearchAsync(string searchInput)
        {
            return SearchImplAsync(SearchType.Autocomplete, searchInput, string.Empty);
        }

        /// <summary>
        /// Asynchronously performs a search using the specified input.
        /// </summary>
        /// <param name="searchInput">The search input string.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<SearchResult> SearchAsync(string searchInput, string referenceId)
        {
            return SearchImplAsync(SearchType.Autocomplete, searchInput, referenceId);
        }

        /// <summary>
        /// Asynchronously performs a search using the specified search type and input.
        /// </summary>
        /// <param name="searchType">The type of search to perform.</param>
        /// <param name="searchInput">The search input string.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<SearchResult> SearchAsync(SearchType searchType, string searchInput)
        {
            return SearchImplAsync(searchType, searchInput, string.Empty);
        }

        /// <summary>
        /// Asynchronously performs a search using the specified search type and input.
        /// </summary>
        /// <param name="searchType">The type of search to perform.</param>
        /// <param name="searchInput">The search input string.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the search result.</returns>
        public Task<SearchResult> SearchAsync(SearchType searchType, string searchInput, string referenceId)
        {
            return SearchImplAsync(searchType, searchInput, referenceId);
        }

        /// <summary>
        /// Asynchronously formats an address using the specified address key.
        /// </summary>
        /// <param name="addressKey">The key of the address to format.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted address result.</returns>
        public Task<FormatResult> FormatAsync(string addressKey)
        {
           return FormatAsync(addressKey, string.Empty);
        }

        /// <summary>
        /// Asynchronously formats an address using the specified address key.
        /// </summary>
        /// <param name="addressKey">The key of the address to format.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the formatted address result.</returns>
        public Task<FormatResult> FormatAsync(string addressKey, string referenceId)
        {
            var request = RestApiFormatRequest.Using(_configuration);
            var headers = GetFormatRequestHeaders(referenceId);
            var formatResponse = _restApiAsyncStub.FormatV1(addressKey, request, headers);
            return new FormatResultFuture(formatResponse).GetAsync();
        }

        /// <summary>
        /// Asynchronously validates an address using the specified input string.
        /// </summary>
        /// <param name="address">The address input string to validate.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
        public Task<ValidateResult> ValidateAsync(string address)
        {
            return ValidateImplAsync(new List<string> { address }, string.Empty);
        }

        /// <summary>
        /// Asynchronously validates an address using the specified input string.
        /// </summary>
        /// <param name="address">The address input string to validate.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
        public Task<ValidateResult> ValidateAsync(string address, string referenceId)
        {
            return ValidateImplAsync(new List<string> { address }, referenceId);
        }

        /// <summary>
        /// Asynchronously validates an address using the specified list of address lines.
        /// </summary>
        /// <param name="addressLines">The list of address lines to validate.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
        public Task<ValidateResult> ValidateAsync(List<string> addressLines)
        {
            return ValidateImplAsync(addressLines, string.Empty);
        }

        /// <summary>
        /// Asynchronously validates an address using the specified list of address lines.
        /// </summary>
        /// <param name="addressLines">The list of address lines to validate.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A task representing the asynchronous operation, containing the validation result.</returns>
        public Task<ValidateResult> ValidateAsync(List<string> addressLines, string referenceId)
        {
            return ValidateImplAsync(addressLines, referenceId);
        }

        private Task<ValidateResult> ValidateImplAsync(List<string> addressLines, string referenceId)
        {
            var request = RestApiAddressValidateRequest.Using(_configuration);
            request.Address = new Server.Address.Address(addressLines);
            var headers = _configuration.GetCommonHeaders(referenceId);

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
            return new ValidateResultFuture(response).GetAsync();
        }

        private Task<SearchResult> SearchImplAsync(SearchType searchType, string searchInput, string referenceId)
        {
            ValidateDatasetsSearchTypeCombination(_configuration.Datasets, searchType);
            var request = RestApiAddressSearchRequest.Using(_configuration);
            request.Address = new Server.Address.Address(searchInput);

            if (searchType == SearchType.Singleline || searchType == SearchType.Typedown)
            {
                request.AddOption("search_type", searchType.ToString());
            }

            var headers = GetSearchRequestHeaders(referenceId);
            return GetSearchResultAsync(request, headers);
        }

        private Task<SearchResult> GetSearchResultAsync(RestApiAddressSearchRequest searchRequest, Dictionary<string, object> headers)
        {
            var searchResponse = _restApiAsyncStub.SearchV1(searchRequest, headers);
            return new SearchResultFuture(searchResponse).GetAsync();
        }

        private Dictionary<string, object> GetSearchRequestHeaders(string referenceId)
        {
            var headers = _configuration.GetCommonHeaders(referenceId);

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

        private Dictionary<string, object> GetFormatRequestHeaders(string referenceId)
        {
            var headers = _configuration.GetCommonHeaders(referenceId);

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
