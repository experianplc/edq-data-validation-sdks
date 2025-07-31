import { RestApiGetLayoutsListItem } from "../../server/address/layout/restApiGetLayoutsListItem";
import { LayoutStatus, lookupAddressLayoutStatus } from "./layoutStatus";
import { AppliesTo, restApiResponseToAppliesTo } from "./appliesTo";
import { GetLayoutListResult } from "./getLayoutListResult";
import { RestApiGetLayoutResponse } from "../../server/address/layout/restApiGetLayoutResponse";
import { RestApiGetLayoutListResponse } from "../../server/address/layout/restApiGetLayoutListResponse";

export type GetLayoutListItem = {
    id: string;
    name: string;
    appliesTo: AppliesTo[];
    status?: LayoutStatus;
};

export function restApiResponseToGetLayoutListItem(apiItem: RestApiGetLayoutsListItem): GetLayoutListItem {
    const result: GetLayoutListItem = {
        id: apiItem.id??"",
        name: apiItem.name??"",
        appliesTo: apiItem.applies_to? apiItem.applies_to.map( p => restApiResponseToAppliesTo(p)) : []
    }
    const status = lookupAddressLayoutStatus(apiItem.status);
    if (status) {
        result.status = status;
    }
    return result;
}

export function restApiResponseToGetLayoutListResult(response: RestApiGetLayoutListResponse): GetLayoutListResult {
    const result: GetLayoutListResult = {
        layouts: response.result?.map(res => restApiResponseToGetLayoutListItem(res)),
        referenceId: response.referenceId,
    }

    return result;
}