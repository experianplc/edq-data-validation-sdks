import { RestApiAddressLayoutLine } from "../../server/address/layout/restApiAddressLayoutLine";
import { RestApiGetLayoutLayout } from "../../server/address/layout/restApiGetLayoutLayout";
import { LayoutStatus, lookupAddressLayoutStatus } from "./layoutStatus";
import { AppliesTo, restApiResponseToAppliesTo } from "./appliesTo";
import { getAddressElementFromElementName } from "./elements/addressElement";
import { LayoutLineFixed } from "./layoutLineFixed";
import { LayoutLineVariable } from "./layoutLineVariable";

export type GetLayoutLayout = {
    id: string;
    name: string;
    comment: string;
    appliesTo: AppliesTo[];
    lines: (LayoutLineFixed | LayoutLineVariable)[];
    status?: LayoutStatus;
    licenseId: string;
    referenceId?: string;
};

export function restApiResponseToGetLayoutLayout(apiItem: RestApiGetLayoutLayout, refId?: string): GetLayoutLayout {

    const appliesTo = apiItem.applies_to ? apiItem.applies_to.map(p => restApiResponseToAppliesTo(p)): [];
    return {
        id: apiItem.id??"",
        name: apiItem.name??"",
        comment: apiItem.comment??"",
        appliesTo: appliesTo,
        lines: apiItem.lines ? apiItem.lines.map(line => getLayoutLine(appliesTo, line)) : [],
        status: lookupAddressLayoutStatus(apiItem.status),
        licenseId: apiItem.license_id??"",
        referenceId: refId,
    }
}

function getLayoutLine(appliesTo: AppliesTo[], line: RestApiAddressLayoutLine): (LayoutLineFixed | LayoutLineVariable){
    if (line.elements && line.elements.length > 0) {
        const result: LayoutLineFixed = {
            name: line.line_name??"",
            maxWidth: line.max_width,
            elements: line.elements ? line.elements.map(el => getAddressElementFromElementName(appliesTo, el.element_name)) : []
        }
        return result;
    } else {
        const result: LayoutLineVariable = {
            name: line.line_name??"",
            maxWidth: line.max_width            
        }
        return result;
    }
}