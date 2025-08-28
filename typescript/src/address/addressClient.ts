import { RestApiStubImpl } from "../server/restApiStub";
import { AddressConfiguration } from "./addressConfiguration";
import { GetDatasetResult, restApiGetDatasetsResponseToResult } from "./datasets/getDatasetResult";
import { Country } from "../common/country";
import { SearchType } from "./searchType";
import { restApiResponseToSearchResult, SearchResult } from "./search/searchResult";
import { Dataset } from "./dataset";
import { DatasetCombinations } from "./datasetCombinations";
import { getAddressSearchRequestFromConfig, RestApiAddressSearchRequest } from "../server/address/restApiSearchRequest";
import { EDVSError } from "../exceptions/edvsException";
import { ValidateResult, restApiResponseToValidationResult } from "./validate/validateResult";
import { getAddressValidateRequestFromConfig } from "../server/address/validate/restApiAddressValidateRequest";
import { FormatResult, restApiResponseToFormatResult } from "./format/formatResult";
import { getFormatRequestFromConfig } from "../server/address/format/restApiFormatRequest";
import { RestApiSuggestionsRefineRequest } from "../server/address/suggestions/restApiSuggestionsRefineRequest";
import { restApiResponseToSuggestionsResult, SuggestionsFormatResult } from "./suggestions/suggestionsFormatResult";
import { getSuggestionsFormatRequestFromConfig } from "../server/address/suggestions/restApiSuggestionsFormatRequest";
import { LookupType } from "./lookup/lookupType";
import { getLookupRequestFromConfig } from "../server/address/lookup/restApiAddressLookupV2Request";
import { LookupResult, restApiResponseToLookupResult } from "./lookup/lookupResult";


/**
 * Interface defining the options for address searching.
 */
export interface AddressSearchOptions {
    /**
     * The search input to use (e.g., what the user has typed in).
     */
     searchInput : string,
    /**
     * The type of search to perform. (optional)
     */
     searchType? : SearchType,
    /**
     * The reference ID for tracking the request. (optional)
     */
    referenceId? : string,
}

/**
 * Client class for interacting with the address-related APIs.
 * Provides methods for searching, validating, formatting, and refining addresses.
 */
export class AddressClient {

    private readonly configuration: AddressConfiguration;
    private readonly restApiStub: RestApiStubImpl;

    /**
     * Initializes a new instance of the {@link AddressClient} class with the specified configuration.
     *
     * @param configuration The configuration settings for the client.
     */
    public constructor(configuration: AddressConfiguration) {
        this.configuration = configuration;
        this.restApiStub = new RestApiStubImpl(configuration);
    }

    /**
     * Retrieves the datasets available for the specified country.
     *
     * @param country       The country for which to retrieve datasets.
     * @param referenceId   The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the result containing the list of datasets.
     */
    public async getDatasets(country: Country, referenceId?: string): Promise<GetDatasetResult> {
        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);
        const resp = await this.restApiStub.getDatasetsV1(country.iso3Code, headers);
        return restApiGetDatasetsResponseToResult(resp);
    }

    /**
     * Looks up an address based on a key.
     * @param value         The key being used to perform the lookup
     * @param lookupType    The type of lookup that you wish to perform.
     * @param referenceId   The reference ID for tracking the request. (optional)
     * @returns A promise that resolves to the result containing the found addresses / suggestions.
     */
    public async lookup(value: string, lookupType: LookupType, referenceId?: string): Promise<LookupResult> {
        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);
        const lookupOptions = this.configuration.options.lookup;
        if (lookupOptions) {
            if (lookupOptions.addAddresses) {
                headers.set("Add-Addresses", "true" as String) //NOSONAR
            }
            if (lookupOptions.addFinalAddress) {
                headers.set("Add-FinalAddress", "true" as String) //NOSONAR
            }
        }
        

        const request = getLookupRequestFromConfig(this.configuration);
        request.key = {
            type: lookupType,
            value: value
        }

        const resp = await this.restApiStub.lookupV2(request, headers);
        return restApiResponseToLookupResult(resp)    
    }

    /**
     * Searches for addresses using the supplied search input and optional search type.
     *
     * @param searchInput   The search input to use (e.g., what the user has typed in).
     * @param searchType    The type of search to perform (optional).
     * @return A promise that resolves to the search result containing a list of suggested addresses.
     * @deprecated This method signature will be removed. Use {@link search(options: AddressSearchOptions)} instead.
     */
    public async search(searchInput: string, searchType?: SearchType): Promise<SearchResult>

    /**
     * Searches for addresses using the supplied search input and optional search type.
     *
     * @param options       Defining the options for address searching.
     * @return A promise that resolves to the search result containing a list of suggested addresses.
     */
    public async search(options: AddressSearchOptions): Promise<SearchResult>

    public async search(searchInputOrSearchOptions: string | AddressSearchOptions, searchType?: SearchType): Promise<SearchResult> {
        let options : AddressSearchOptions;
        if (typeof searchInputOrSearchOptions === 'string') {
            // keep for backwards compatibility
            options = {
                searchInput: searchInputOrSearchOptions,
                searchType: searchType,
                referenceId: "",
            }
        } else {
            options = searchInputOrSearchOptions;
        }

        return this.searchImpl(options);
    }

    private async searchImpl(options: AddressSearchOptions): Promise<SearchResult> {
        const { searchInput, searchType, referenceId } = options;

        if (!searchType) {
            return this.performSearchWithSearchType(SearchType.Autocomplete, searchInput, referenceId ?? "");
        } else {
            return this.performSearchWithSearchType(searchType, searchInput, referenceId ?? "");
        }
    }

    private async performSearchWithSearchType(searchType: SearchType, searchInput: string, referenceId: string): Promise<SearchResult> {
        this.validateDatasetsSearchTypeCombination(this.configuration.options.datasets ?? [], searchType);
        const request = getAddressSearchRequestFromConfig(this.configuration);
        request.components = { unspecified: [searchInput] };

        if (searchType === SearchType.Singleline || searchType === SearchType.Typedown) {
            request.options?.push({ name: "search_type", value: searchType });
        }
        const headers = this.getSearchRequestHeaders(referenceId);
        return this.getSearchResult(request, headers);
    }

    private getSearchRequestHeaders(referenceId: string): Map<string, object> {
        const headers = this.configuration.getCommonHeaders(referenceId);
        if (this.configuration.options.transliterate) {
            headers.set("Transliterate", { value: "true" });
        }
        return headers;
    }

    private async getSearchResult(searchRequest: RestApiAddressSearchRequest, headers: Map<string, object>): Promise<SearchResult> {
        try {
            const resp = await this.restApiStub.searchV1(searchRequest, headers);
            if (resp.error) {
                throw EDVSError.using(resp.error);
            }
            return restApiResponseToSearchResult(resp);
        } catch (error) {
            return Promise.reject(error instanceof Error ? error : new Error(String(error)));
        }
    }

    private validateDatasetsSearchTypeCombination(datasets: Dataset[], searchType: SearchType): void {
        if (datasets.length === 1 && datasets[0].searchTypes.includes(searchType)) {
            return;
        } else if (datasets.length > 0) {
            const datasetCombinations = DatasetCombinations.fromSearchType(searchType);
            if (datasetCombinations.some(combination =>
                combination.length === datasets.length &&
                combination.every(dataset => datasets.some(d => d.datasetCode === dataset.datasetCode))
            )) {
                return;
            }
        }

        throw new EDVSError("Unsupported dataset / search type combination.");
    }

    /**
     * Validates an address using the supplied address line(s).
     *
     * @param addressLines  The address lines to validate.
     * @param referenceId   The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the validation result.
     */
    public async validate(addressLines: string | string[], referenceId?: string): Promise<ValidateResult> {
        const request = getAddressValidateRequestFromConfig(this.configuration);

        const lines: string[] = Array.isArray(addressLines) ? addressLines : [addressLines];
        request.components = { unspecified: lines };
        
        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);

        if (this.configuration.options.includeComponents) {
            headers.set("Add-Components", "true" as String); //NOSONAR
        }
        if (this.configuration.options.includeMetadata) {
            headers.set("Add-Metadata", "true" as String); //NOSONAR
        }
        if (this.configuration.options.includeEnrichment) {
            headers.set("Add-Enrichment", "true" as String); //NOSONAR
        }
        if (this.configuration.options.includeExtraMatchInfo) {
            headers.set("Add-ExtraMatchInfo", "true" as String); //NOSONAR
        }

        try {
            const resp = await this.restApiStub.validateV1(request, headers);
            if (resp.error) {
                throw EDVSError.using(resp.error);
            }
            return restApiResponseToValidationResult(resp);
        } catch (error) {
            return Promise.reject(error instanceof Error ? error : new Error(String(error)));
        }
    }

    /**
     * Formats an address using the specified address key.
     *
     * @param addressKey    The key of the address to format.
     * @param referenceId   The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the formatted address result.
     */
    public format(addressKey: string, referenceId?: string): Promise<FormatResult> {
        if (!referenceId) { referenceId=""; }
        const request = getFormatRequestFromConfig(this.configuration);
        const headers = this.getFormatRequestHeaders(referenceId);
        return this.restApiStub.formatV1(addressKey, request, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                }
                return Promise.resolve(restApiResponseToFormatResult(resp));
            }
        );
    }

    /**
     * Steps into a suggestion using the specified global address key.
     *
     * @param globalAddressKey  The global address key to step into.
     * @param referenceId       The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the search result containing refined suggestions.
     */
    public suggestionsStepIn(globalAddressKey: string, referenceId?: string): Promise<SearchResult> {
        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);
        return this.restApiStub.suggestionsStepInV1(globalAddressKey, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                }
                return Promise.resolve(restApiResponseToSearchResult(resp));
            }
        );
    }

    /**
     * Refines a suggestion using the specified global address key and refinement input.
     *
     * @param globalAddressKey  The global address key to refine.
     * @param refinement        The refinement input to use.
     * @param referenceId       The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the search result containing refined suggestions.
     */
    public async suggestionsRefine(globalAddressKey: string, refinement: string, referenceId?: string): Promise<SearchResult> {
        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);
        const request: RestApiSuggestionsRefineRequest = {
            refinement
        };
        try {
            const resp = await this.restApiStub.suggestionsRefineV1(globalAddressKey, request, headers);
            if (resp.error) {
                throw EDVSError.using(resp.error);
            }
            return restApiResponseToSearchResult(resp);
        } catch (error) {
            return Promise.reject(error instanceof Error ? error : new Error(String(error)));
        }
    }

    /**
     * Formats suggestions using the supplied search input.
     *
     * @param searchInput   The search input to format.
     * @param referenceId   The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the formatted suggestions result.
     */
    public async suggestionsFormat(searchInput: string, referenceId?: string): Promise<SuggestionsFormatResult> {
        if (!referenceId) { referenceId=""; }
        const request = getSuggestionsFormatRequestFromConfig(this.configuration);
        request.components = { unspecified: [searchInput] };
        const headers = this.configuration.getCommonHeaders(referenceId);

        try {
            const resp = await this.restApiStub.suggestionsFormatV1(request, headers);
            if (resp.error) {
                throw EDVSError.using(resp.error);
            }
            return restApiResponseToSuggestionsResult(resp);
        } catch (error) {
            return Promise.reject(error instanceof Error ? error : new Error(String(error)));
        }
    }

    private getFormatRequestHeaders(referenceId : string): Map<string, object> {
        const headers = this.configuration.getCommonHeaders(referenceId);

        if (this.configuration.options.includeComponents) {
            headers.set("Add-Components", "true" as String); //NOSONAR
        }
        if (this.configuration.options.includeMetadata) {
            headers.set("Add-Metadata", "true" as String); //NOSONAR
        }
        if (this.configuration.options.includeEnrichment) {
            headers.set("Add-Enrichment", "true" as String); //NOSONAR
        }

        return headers;
    }
}
