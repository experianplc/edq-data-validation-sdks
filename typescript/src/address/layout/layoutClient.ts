import { RestApiAddressLayout } from "../../server/address/layout/restApiAddressLayout";
import { RestApiStubImpl } from "../../server/restApiStub";
import { CreateLayoutResult, restApiResponseToCreateLayoutResult } from "./createLayoutResult";
import { LayoutConfiguration } from "./layoutConfiguration";
import { LayoutLineVariable } from "./layoutLineVariable";
import { AppliesTo } from "./appliesTo"
import { getApiRequestFromLayoutAppliesTo } from "../../server/address/layout/restApiAddressLayoutAppliesTo";
import { getApiRequestFromFixedLayoutLine, getApiRequestFromVariableLayoutLine } from "../../server/address/layout/restApiAddressLayoutLine";
import { LayoutLineFixed } from "./layoutLineFixed";
import { RestApiCreateLayoutRequest } from "../../server/address/layout/restApiCreateLayoutRequest";
import { EDVSError } from "../../exceptions/edvsException";
import { Country } from "../../common/country";
import { Dataset } from "../dataset";
import { GetLayoutListItem, restApiResponseToGetLayoutListItem } from "./getLayoutListItem";
import { GetLayoutLayout, restApiResponseToGetLayoutLayout } from "./getLayoutLayout";

export class LayoutClient {
    private readonly configuration: LayoutConfiguration;
    private readonly restApiStub: RestApiStubImpl;
    
    public constructor(configuration: LayoutConfiguration) {
        this.configuration = configuration;
        this.restApiStub = new RestApiStubImpl(configuration);
    }

    public async createLayout(name: string, appliesTo: AppliesTo[], variableLayoutLines: LayoutLineVariable[], fixedLayoutLines: LayoutLineFixed[]) : Promise<CreateLayoutResult> {
        
        const apiLayout: RestApiAddressLayout = {
            name: name,
            applies_to: appliesTo.map(appliesTo => getApiRequestFromLayoutAppliesTo(appliesTo)),
            lines: []
        };        
        const apiVariableLines = variableLayoutLines.map(line => getApiRequestFromVariableLayoutLine(line));
        const apiFixedLines = fixedLayoutLines.map(line => getApiRequestFromFixedLayoutLine(line));
        apiLayout.lines?.push(...apiVariableLines)
        apiLayout.lines?.push(...apiFixedLines);

        const request: RestApiCreateLayoutRequest = {
            layout: apiLayout
        }

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

    public async deleteLayout(name: string): Promise<void> {
        const headers = this.configuration.getCommonHeaders();
        return this.restApiStub.deleteLayoutV2(name, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                }                
            }
        );
    }

    public async getLayouts(datasets: Dataset[], nameContains: string, country?: Country): Promise<GetLayoutListItem[]> {
        
        const headers = this.configuration.getCommonHeaders();
        const countryCode = country ? country.iso3Code : "";
        const datasetCodes = datasets.map(ds => ds.datasetCode);
        
        return this.restApiStub.getLayoutsV2(countryCode, datasetCodes, nameContains, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                } else if (resp.result)  {
                    return Promise.resolve(resp.result.map(res => restApiResponseToGetLayoutListItem(res)))               
                } else {
                    return Promise.reject(new EDVSError("Invalid respnse)"));
                }                
            }
        ).catch(error => {
            if (error instanceof EDVSError && error.message === "Not Found") {
                return [];
            }
            throw error;
        });
    }

    public async getLayout(name: string): Promise<GetLayoutLayout> {
        
        const headers = this.configuration.getCommonHeaders();
        return this.restApiStub.getLayoutV2(name, headers).then(
            resp => {
                if (resp.error) {
                    return Promise.reject(EDVSError.using(resp.error));
                } else if (resp.result?.layout)  {
                ;return Promise.resolve(restApiResponseToGetLayoutLayout(resp.result.layout))               
                } else {
                    return Promise.reject(new EDVSError("Invalid respnse)"));
                }                
            }
        );
    }


}