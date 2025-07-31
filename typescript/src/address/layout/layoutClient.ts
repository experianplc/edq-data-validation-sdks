import { RestApiAddressLayout } from "../../server/address/layout/restApiAddressLayout";
import { RestApiStubImpl } from "../../server/restApiStub";
import { CreateLayoutResult, restApiResponseToCreateLayoutResult } from "./createLayoutResult";
import { LayoutConfiguration } from "./layoutConfiguration";
import { LayoutLineVariable } from "./layoutLineVariable";
import { AppliesTo } from "./appliesTo";
import { getApiRequestFromLayoutAppliesTo } from "../../server/address/layout/restApiAddressLayoutAppliesTo";
import { getApiRequestFromFixedLayoutLine, getApiRequestFromVariableLayoutLine } from "../../server/address/layout/restApiAddressLayoutLine";
import { LayoutLineFixed } from "./layoutLineFixed";
import { RestApiCreateLayoutRequest } from "../../server/address/layout/restApiCreateLayoutRequest";
import { EDVSError } from "../../exceptions/edvsException";
import { Country } from "../../common/country";
import { Dataset } from "../dataset";
import { GetLayoutListItem, restApiResponseToGetLayoutListItem, restApiResponseToGetLayoutListResult } from "./getLayoutListItem";
import { GetLayoutLayout, restApiResponseToGetLayoutLayout } from "./getLayoutLayout";
import { GetLayoutListResult } from "./getLayoutListResult";

/**
 * Interface defining the options for retrieving layouts.
 */
interface GetLayoutsOptions {
    /**
     * The datasets to filter the layouts by. (optional)
     */
    datasets?: Dataset[];
    /**
     * A string to filter layouts by name. (optional)
     */
    nameContains?: string;
    /**
     * The country to filter layouts by. (optional)
     */
    country?: Country;
    /**
     * The reference ID for tracking the request. (optional)
     */
    referenceId?: string;
}

/**
 * Client class for interacting with the layout-related APIs.
 * Provides methods for creating, deleting, and retrieving layouts.
 */
export class LayoutClient {
    private readonly configuration: LayoutConfiguration;
    private readonly restApiStub: RestApiStubImpl;

    /**
     * Initializes a new instance of the {@link LayoutClient} class with the specified configuration.
     *
     * @param configuration The configuration settings for the layout client.
     */
    public constructor(configuration: LayoutConfiguration) {
        this.configuration = configuration;
        this.restApiStub = new RestApiStubImpl(configuration);
    }

    /**
     * Creates a new layout with the specified name, applies-to rules, variable layout lines, and fixed layout lines.
     *
     * @param name                  The name of the layout to create.
     * @param appliesTo             The rules defining where the layout applies.
     * @param variableLayoutLines   The variable layout lines to include in the layout.
     * @param fixedLayoutLines      The fixed layout lines to include in the layout.
     * @param referenceId           The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the result of the layout creation.
     * @throws EDVSError If the API response contains an error.
     */
    public async createLayout(
        name: string,
        appliesTo: AppliesTo[],
        variableLayoutLines: LayoutLineVariable[],
        fixedLayoutLines: LayoutLineFixed[],
        referenceId?: string
    ): Promise<CreateLayoutResult> {
        const apiLayout: RestApiAddressLayout = {
            name: name,
            applies_to: appliesTo.map(appliesTo => getApiRequestFromLayoutAppliesTo(appliesTo)),
            lines: []
        };
        const apiVariableLines = variableLayoutLines.map(line => getApiRequestFromVariableLayoutLine(line));
        const apiFixedLines = fixedLayoutLines.map(line => getApiRequestFromFixedLayoutLine(line));
        apiLayout.lines?.push(...apiVariableLines);
        apiLayout.lines?.push(...apiFixedLines);

        const request: RestApiCreateLayoutRequest = {
            layout: apiLayout
        };

        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);
        return this.restApiStub.createLayoutV2(request, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                }
                return Promise.resolve(restApiResponseToCreateLayoutResult(resp));
            }
        );
    }

    /**
     * Deletes a layout with the specified name.
     *
     * @param name          The name of the layout to delete.
     * @param referenceId   The reference ID for tracking the request. (optional)
     * @return A promise that resolves when the layout is successfully deleted.
     * @throws EDVSError If the API response contains an error.
     */
    public async deleteLayout(name: string, referenceId?: string): Promise<void> {
        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);
        return this.restApiStub.deleteLayoutV2(name, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                }
                else
                {
                    return Promise.resolve();
                }
            }
        );
    }

    /**
     * Retrieves a list of layouts that match the specified criteria.
     *
     * @param datasets     The datasets to filter the layouts by.
     * @param nameContains A string to filter layouts by name.
     * @param country      The country to filter layouts by (optional).
     * @return A promise that resolves to a list of layout items.
     * @throws EDVSError If the API response contains an error.
     * @deprecated This method signature will be removed. Use {@link getLayouts(options: GetLayoutsOptions)} instead.
     */
    public async getLayouts(
        datasets: Dataset[],
        nameContains: string,
        country?: Country
    ): Promise<GetLayoutListItem[]>;

    /**
     * Retrieves a list of layouts that match the specified criteria.
     *
     * @param options The options for retrieving layouts.
     * @return A promise that resolves to a result containing a list of layouts.
     * @throws EDVSError If the API response contains an error.
     */
    public async getLayouts(
        options: GetLayoutsOptions
    ): Promise<GetLayoutListResult>;

    public async getLayouts(
        datasetsOrOptions: Dataset[] | GetLayoutsOptions,
        nameContains?: string,
        country?: Country
    ): Promise<GetLayoutListItem[] | GetLayoutListResult> {
        let params : GetLayoutsOptions;
        if (Array.isArray(datasetsOrOptions)) {
            // keep for backwards compatibility
            params = {
                datasets: datasetsOrOptions,
                nameContains: nameContains ?? "",
                country: country ?? undefined,
                referenceId: "",
            }
        } else {
            params = datasetsOrOptions;
        }

        return this.getLayoutsImpl(params);
    }

    /**
     * Retrieves the details of a specific layout by its name.
     *
     * @param name          The name of the layout to retrieve.
     * @param referenceId   The reference ID for tracking the request. (optional)
     * @return A promise that resolves to the layout details.
     * @throws EDVSError If the API response contains an error.
     */
    public async getLayout(name: string, referenceId?: string): Promise<GetLayoutLayout> {
        if (!referenceId) { referenceId=""; }
        const headers = this.configuration.getCommonHeaders(referenceId);
        return this.restApiStub.getLayoutV2(name, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                } else if (resp.result?.layout) {
                    return Promise.resolve(restApiResponseToGetLayoutLayout(resp.result?.layout, resp.referenceId));
                } else {
                    return Promise.reject(new EDVSError("Invalid response"));
                }
            }
        );
    }

    private async getLayoutsImpl(params: GetLayoutsOptions): Promise<GetLayoutListItem[] | GetLayoutListResult> {
        const { datasets, nameContains, country, referenceId } = params;

        const countryCode = country?.iso3Code ?? "";
        const datasetCodes = datasets?.map(ds => ds.datasetCode) ?? [];
        const layoutNameContains = nameContains ?? "";
        const headers = this.configuration.getCommonHeaders(referenceId ?? "");

        try {
            const resp = await this.restApiStub.getLayoutsV2(countryCode, datasetCodes, layoutNameContains, headers);

            if (resp.error) throw EDVSError.using(resp.error);
            if (!resp.result) throw new EDVSError("Invalid response");

            if (referenceId === undefined || referenceId === "") {
                // Deprecated behavior
                return resp.result.map(res => restApiResponseToGetLayoutListItem(res));
            } else {
                // New behavior
                return restApiResponseToGetLayoutListResult(resp);
            }
        } catch (error) {
            if (error instanceof EDVSError && error.message === "Not Found") {
                return referenceId === undefined ? [] : { layouts: [], referenceId: referenceId };
            }
            throw error;
        }
    }
}
