package com.experian.dvs.client.address;

import com.experian.dvs.client.address.datasets.GetDatasetsResult;
import com.experian.dvs.client.address.datasets.GetDatasetsResultFuture;
import com.experian.dvs.client.address.format.Result;
import com.experian.dvs.client.address.format.ResultFuture;
import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.exceptions.RestApiInterruptionOrExecutionException;
import com.experian.dvs.client.server.RestApiAsyncImpl;
import com.experian.dvs.client.server.RestApiAsyncStub;
import com.experian.dvs.client.server.address.Address;
import com.experian.dvs.client.server.address.dataset.RestApiGetDatasetsResponse;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatResponse;
import com.experian.dvs.client.server.address.format.RestApiFormatRequest;
import com.experian.dvs.client.server.address.search.RestApiAddressSearchRequest;
import com.experian.dvs.client.server.address.search.RestApiAddressSearchResponse;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatRequest;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatResponse;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsRefineRequest;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateRequest;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateResponse;

import java.io.Closeable;
import java.io.IOException;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;

/**
 * Client class for interacting with the address-related APIs.
 * Provides methods for searching, validating, formatting, and refining addresses.
 */
public class Client implements Closeable {

    private final Configuration configuration;
    private final RestApiAsyncStub restApiAsyncStub;

    /**
     * Initializes a new instance of the {@link Client} class with the specified configuration.
     *
     * @param configuration The configuration settings for the client.
     */
    public Client(Configuration configuration) {
        this.configuration = configuration;
        this.restApiAsyncStub = new RestApiAsyncImpl(configuration);
    }

    /**
     * Closes the client and releases any resources held by it.
     *
     * @throws IOException If an I/O error occurs while closing the client.
     */
    @Override
    public void close() throws IOException {
        this.restApiAsyncStub.close();
    }

    /**
     * Retrieves the datasets available for the specified country.
     *
     * @param country The country for which to retrieve datasets.
     * @return The result containing the list of datasets.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public GetDatasetsResult getDatasets(final Country country) {
        try {
            return this.getDatasetsAsync(country).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Searches for addresses using the supplied search input.
     * This uses the default 'autocomplete' method of searching, where it is expected
     * that this function is called on each character that the end user is entering.
     *
     * @param searchInput The search input to use (i.e., what the end user has currently typed in).
     * @return The search result containing a list of suggested addresses.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.address.search.Result search(final String searchInput) {
        try {
            return this.searchAsync(searchInput).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Searches for addresses using the specified search type and input.
     *
     * @param searchType  The type of search to perform (e.g., autocomplete, singleline).
     * @param searchInput The search input to use.
     * @return The search result containing a list of suggested addresses.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.address.search.Result search(SearchType searchType, final String searchInput) {
        try {
            return this.searchAsync(searchType, searchInput).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Formats an address using the specified address key.
     *
     * @param addressKey The key of the address to format.
     * @return The formatted address result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public Result format(final String addressKey) {
        try {
            return this.formatAsync(addressKey).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Validates an address using the supplied search input.
     *
     * @param searchInput The search input to validate.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.address.validate.Result validate(final String searchInput) {
        try {
            return this.validateAsync(searchInput).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Validates an address using the supplied address lines.
     *
     * @param addressLines The address lines to validate.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.address.validate.Result validate(final List<String> addressLines) {
        try {
            return this.validateAsync(addressLines).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Steps into a suggestion using the specified global address key.
     *
     * @param globalAddressKey The global address key to step into.
     * @return The search result containing refined suggestions.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.address.search.Result suggestionsStepIn(final String globalAddressKey) {
        try {
            return this.suggestionsStepInAsync(globalAddressKey).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Refines a suggestion using the specified key and refinement input.
     *
     * @param key        The key of the suggestion to refine.
     * @param refinement The refinement input to use.
     * @return The search result containing refined suggestions.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.address.search.Result suggestionsRefine(final String key, final String refinement) {
        try {
            return this.suggestionsRefineAsync(key, refinement).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Formats suggestions using the supplied search input.
     *
     * @param searchInput The search input to format.
     * @return The formatted suggestions result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.address.suggestions.format.Result suggestionsFormat(final String searchInput) {
        try {
            return this.suggestionsFormatAsync(searchInput).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Retrieves the datasets available for the specified country asynchronously.
     *
     * @param country The country for which to retrieve datasets.
     * @return A future representing the asynchronous operation.
     */
    public Future<GetDatasetsResult> getDatasetsAsync(final Country country) {
        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        final Future<RestApiGetDatasetsResponse> datasetsResponse = this.restApiAsyncStub.getDatasetsV1(country.getIso3Code(), headers);
        return new GetDatasetsResultFuture(datasetsResponse);
    }

    /**
     * Searches for addresses asynchronously using the supplied search input.
     *
     * @param searchInput The search input to use.
     * @return A future representing the asynchronous operation.
     */
    public Future<com.experian.dvs.client.address.search.Result> searchAsync(final String searchInput) {
        return searchAsync(SearchType.AUTOCOMPLETE, searchInput);
    }

    /**
     * Searches for addresses asynchronously using the specified search type and input.
     *
     * @param searchType  The type of search to perform.
     * @param searchInput The search input to use.
     * @return A future representing the asynchronous operation.
     */
    public Future<com.experian.dvs.client.address.search.Result> searchAsync(SearchType searchType, final String searchInput) {
        return performSearchWithSearchType(searchType, searchInput);
    }

    /**
     * Formats an address asynchronously using the specified address key.
     *
     * @param addressKey The key of the address to format.
     * @return A future representing the asynchronous operation.
     */
    public Future<Result> formatAsync(final String addressKey) {
        final RestApiFormatRequest request = RestApiFormatRequest.using(this.configuration);
        final Map<String, Object> headers = getFormatRequestHeaders();
        final Future<RestApiAddressFormatResponse> formatResponse = this.restApiAsyncStub.formatV1(addressKey, request, headers);

        return new ResultFuture(formatResponse);
    }

    /**
     * Validates an address asynchronously using the supplied search input.
     *
     * @param address The search input to validate.
     * @return A future representing the asynchronous operation.
     */
    public Future<com.experian.dvs.client.address.validate.Result> validateAsync(final String address) {
        return validateAsync(List.of(address));
    }

    /**
     * Validates an address asynchronously using the supplied address lines.
     *
     * @param addressLines The address lines to validate.
     * @return A future representing the asynchronous operation.
     */
    public Future<com.experian.dvs.client.address.validate.Result> validateAsync(final List<String> addressLines) {
        return validateImpl(addressLines);
    }

    /**
     * Steps into a suggestion asynchronously using the specified global address key.
     *
     * @param globalAddressKey The global address key to step into.
     * @return A future representing the asynchronous operation.
     */
    public Future<com.experian.dvs.client.address.search.Result> suggestionsStepInAsync(final String globalAddressKey) {
        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        final Future<RestApiAddressSearchResponse> suggestionsStepInResponse = this.restApiAsyncStub.suggestionsStepInV1(globalAddressKey, headers);
        return new com.experian.dvs.client.address.search.ResultFuture(suggestionsStepInResponse);
    }

    /**
     * Refines a suggestion asynchronously using the specified key and refinement input.
     *
     * @param key        The key of the suggestion to refine.
     * @param refinement The refinement input to use.
     * @return A future representing the asynchronous operation.
     */
    public Future<com.experian.dvs.client.address.search.Result> suggestionsRefineAsync(final String key, final String refinement) {
        final RestApiSuggestionsRefineRequest request = RestApiSuggestionsRefineRequest.using(this.configuration);
        request.setRefinement(refinement);
        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        final Future<RestApiAddressSearchResponse> suggestionsRefineResponse = this.restApiAsyncStub.suggestionsRefineV1(key, request, headers);
        return new com.experian.dvs.client.address.search.ResultFuture(suggestionsRefineResponse);
    }

    /**
     * Formats suggestions asynchronously using the supplied search input.
     *
     * @param searchInput The search input to format.
     * @return A future representing the asynchronous operation.
     */
    public Future<com.experian.dvs.client.address.suggestions.format.Result> suggestionsFormatAsync(final String searchInput) {
        final RestApiSuggestionsFormatRequest request = RestApiSuggestionsFormatRequest.using(this.configuration);
        request.setAddress(new Address(searchInput));
        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        final Future<RestApiSuggestionsFormatResponse> suggestionsFormatResponse = this.restApiAsyncStub.suggestionsFormatV1(request, headers);
        return new com.experian.dvs.client.address.suggestions.format.ResultFuture(suggestionsFormatResponse);
    }

    private Future<com.experian.dvs.client.address.validate.Result> validateImpl(final List<String> addressLines) {
        final RestApiAddressValidateRequest request = RestApiAddressValidateRequest.using(this.configuration);
        request.setAddress(new Address(addressLines));

        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        if (this.configuration.getComponents()) {
            headers.put("Add-Components", Boolean.TRUE.toString());
        }
        if (this.configuration.getMetadata()) {
            headers.put("Add-Metadata", Boolean.TRUE.toString());
        }
        if (this.configuration.getEnrichment()) {
            headers.put("Add-Enrichment", Boolean.TRUE.toString());
        }
        if (this.configuration.getExtraMatchInfo()) {
            headers.put("Add-ExtraMatchInfo", Boolean.TRUE.toString());
        }

        final Future<RestApiAddressValidateResponse> response = this.restApiAsyncStub.validateV1(request, headers);
        return new com.experian.dvs.client.address.validate.ResultFuture(response);
    }

    private Future<com.experian.dvs.client.address.search.Result> performSearchWithSearchType(final SearchType searchType, final String searchInput) {
        validateDatasetsSearchTypeCombination(this.configuration.getDatasets(), searchType);
        final RestApiAddressSearchRequest request = RestApiAddressSearchRequest.using(this.configuration);
        request.setAddress(new Address(searchInput));

        if (searchType == SearchType.SINGLELINE || searchType == SearchType.TYPEDOWN) {
            request.addOption("search_type", searchType.toString());
        }

        final Map<String, Object> headers = getSearchRequestHeaders();
        return getSearchResult(request, headers);
    }

    private Future<com.experian.dvs.client.address.search.Result> getSearchResult(final RestApiAddressSearchRequest searchRequest, final Map<String, Object> headers) {
        final Future<RestApiAddressSearchResponse> searchResponse = this.restApiAsyncStub.searchV1(searchRequest, headers);

        return new com.experian.dvs.client.address.search.ResultFuture(searchResponse);
    }

    private Map<String, Object> getSearchRequestHeaders() {

        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        if (this.configuration.getTransliterate()) {
            headers.put("Transliterate", Boolean.TRUE.toString());
        }

        return headers;
    }

    private void validateDatasetsSearchTypeCombination(List<Dataset> datasets, SearchType searchType) {

        if (datasets.size() == 1 && datasets.get(0).getSearchTypes().contains(searchType)) {
            return;
        } else if (datasets.size() > 1) {
            final List<List<Dataset>> datasetCombinations = DatasetCombinations.fromSearchType(searchType);
            if (datasetCombinations.stream().anyMatch(datasets::containsAll)) {
                return;
            }
        }

        throw new EDVSException("Unsupported dataset / search type combination.");
    }

    private Map<String, Object> getFormatRequestHeaders() {

        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        if (this.configuration.getComponents()) {
            headers.put("Add-Components", Boolean.TRUE.toString());
        }
        if (this.configuration.getMetadata()) {
            headers.put("Add-Metadata", Boolean.TRUE.toString());
        }
        if (this.configuration.getEnrichment()) {
            headers.put("Add-Enrichment", Boolean.TRUE.toString());
        }

        return headers;
    }
}
