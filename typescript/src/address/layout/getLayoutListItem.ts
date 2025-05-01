import { RestApiGetLayoutsListItem } from "../../server/address/layout/restApiGetLayoutsListItem";
import { LayoutStatus, lookupAddressLayoutStatus } from "./layoutStatus";
import { AppliesTo, restApiResponseToAppliesTo } from "./appliesTo";

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