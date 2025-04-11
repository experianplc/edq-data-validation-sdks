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
import { AddressValidationResult, restApiResponseToValidationResult } from "./validate/addressValidateResult";
import { getAddressValidateRequestFromConfig } from "../server/address/validate/restApiAddressValidateRequest";
import { FormatResult, restApiResponseToFormatResult } from "./format/formatResult";
import { getFormatRequestFromConfig } from "../server/address/format/restApiFormatRequest";
import { RestApiSuggestionsRefineRequest } from "../server/address/suggestions/restApiSuggestionsRefineRequest";
import { restApiResponseToSuggestionsResult, SuggestionsResult } from "./suggestions/suggestionsResult";
import { getSuggestionsFormatRequestFromConfig } from "../server/address/suggestions/restApiSuggestionsFormatRequest";

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
     * @param country The country for which to retrieve datasets.
     * @return A promise that resolves to the result containing the list of datasets.
     */
    public async getDatasets(country: Country): Promise<GetDatasetResult> {
        const headers = this.configuration.getCommonHeaders();
        const resp = await this.restApiStub.getDatasetsV1(country.iso3Code, headers);
        return restApiGetDatasetsResponseToResult(resp);
    }

    /**
     * Searches for addresses using the supplied search input and optional search type.
     *
     * @param searchInput The search input to use (e.g., what the user has typed in).
     * @param searchType  The type of search to perform (optional).
     * @return A promise that resolves to the search result containing a list of suggested addresses.
     */
    public async search(searchInput: string, searchType?: SearchType): Promise<SearchResult> {
        if (!searchType) {
            return this.performSearchWithSearchType(SearchType.Autocomplete, searchInput);
        } else {
            return this.performSearchWithSearchType(searchType, searchInput!);
        }
    }

    private async performSearchWithSearchType(searchType: SearchType, searchInput: string): Promise<SearchResult> {
        this.validateDatasetsSearchTypeCombination(this.configuration.options.datasets ?? [], searchType);
        const request = getAddressSearchRequestFromConfig(this.configuration);
        request.components = { unspecified: [searchInput] };

        if (searchType === SearchType.Singleline || searchType === SearchType.Typedown) {
            request.options?.push({ name: "search_type", value: searchType });
        }
        const headers = this.getSearchRequestHeaders();
        return this.getSearchResult(request, headers);
    }

    private getSearchRequestHeaders(): Map<string, object> {
        const headers = this.configuration.getCommonHeaders();
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
     * Validates an address using the supplied address lines.
     *
     * @param addressLines The address lines to validate.
     * @return A promise that resolves to the validation result.
     */
    public async validate(addressLines: string[]): Promise<AddressValidationResult> {
        const request = getAddressValidateRequestFromConfig(this.configuration);
        request.components = { unspecified: addressLines };

        const headers = this.configuration.getCommonHeaders();

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
     * @param addressKey The key of the address to format.
     * @return A promise that resolves to the formatted address result.
     */
    public format(addressKey: string): Promise<FormatResult> {
        const request = getFormatRequestFromConfig(this.configuration);
        const headers = this.getFormatRequestHeaders();
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
     * @param globalAddressKey The global address key to step into.
     * @return A promise that resolves to the search result containing refined suggestions.
     */
    public suggestionsStepIn(globalAddressKey: string): Promise<SearchResult> {
        const headers = this.configuration.getCommonHeaders();
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
     * @param globalAddressKey The global address key to refine.
     * @param refinement       The refinement input to use.
     * @return A promise that resolves to the search result containing refined suggestions.
     */
    public async suggestionsRefine(globalAddressKey: string, refinement: string): Promise<SearchResult> {
        const headers = this.configuration.getCommonHeaders();
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
     * @param searchInput The search input to format.
     * @return A promise that resolves to the formatted suggestions result.
     */
    public async suggestionsFormat(searchInput: string): Promise<SuggestionsResult> {
        const request = getSuggestionsFormatRequestFromConfig(this.configuration);
        request.components = { unspecified: [searchInput] };
        const headers = this.configuration.getCommonHeaders();

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

    private getFormatRequestHeaders(): Map<string, object> {
        const headers = this.configuration.getCommonHeaders();

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
