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
import { GetLayoutListItem, restApiResponseToGetLayoutListItem } from "./getLayoutListItem";
import { GetLayoutLayout, restApiResponseToGetLayoutLayout } from "./getLayoutLayout";

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
     * @param name               The name of the layout to create.
     * @param appliesTo          The rules defining where the layout applies.
     * @param variableLayoutLines The variable layout lines to include in the layout.
     * @param fixedLayoutLines    The fixed layout lines to include in the layout.
     * @return A promise that resolves to the result of the layout creation.
     * @throws EDVSError If the API response contains an error.
     */
    public async createLayout(
        name: string,
        appliesTo: AppliesTo[],
        variableLayoutLines: LayoutLineVariable[],
        fixedLayoutLines: LayoutLineFixed[]
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

        const headers = this.configuration.getCommonHeaders();
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
     * @param name The name of the layout to delete.
     * @return A promise that resolves when the layout is successfully deleted.
     * @throws EDVSError If the API response contains an error.
     */
    public async deleteLayout(name: string): Promise<void> {
        const headers = this.configuration.getCommonHeaders();
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
     */
    public async getLayouts(datasets: Dataset[], nameContains: string, country?: Country): Promise<GetLayoutListItem[]> {
        const headers = this.configuration.getCommonHeaders();
        const countryCode = country ? country.iso3Code : "";
        const datasetCodes = datasets.map(ds => ds.datasetCode);

        return this.restApiStub.getLayoutsV2(countryCode, datasetCodes, nameContains, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                } else if (resp.result) {
                    return Promise.resolve(resp.result.map(res => restApiResponseToGetLayoutListItem(res)));
                } else {
                    return Promise.reject(new EDVSError("Invalid response"));
                }
            }
        ).catch(error => {
            if (error instanceof EDVSError && error.message === "Not Found") {
                return [];
            }
            throw error;
        });
    }

    /**
     * Retrieves the details of a specific layout by its name.
     *
     * @param name The name of the layout to retrieve.
     * @return A promise that resolves to the layout details.
     * @throws EDVSError If the API response contains an error.
     */
    public async getLayout(name: string): Promise<GetLayoutLayout> {
        const headers = this.configuration.getCommonHeaders();
        return this.restApiStub.getLayoutV2(name, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                } else if (resp.result?.layout) {
                    return Promise.resolve(restApiResponseToGetLayoutLayout(resp.result.layout));
                } else {
                    return Promise.reject(new EDVSError("Invalid response"));
                }
            }
        );
    }
}
