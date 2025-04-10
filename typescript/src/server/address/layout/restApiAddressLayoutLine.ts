import { AddressElement } from "../../../address/layout/elements/addressElement";
import { LayoutLineFixed } from "../../../address/layout/layoutLineFixed";
import { LayoutLineVariable } from "../../../address/layout/layoutLineVariable";
import { RestApiAddressLayoutLineElement } from "./restApiAddressLayoutLineElement";
import { RestApiCreateLayoutRequest } from "./restApiCreateLayoutRequest";

export type RestApiAddressLayoutLine = {
    line_name?: string;
    max_width?: number;
    elements?: RestApiAddressLayoutLineElement[];
};

export function getApiRequestFromVariableLayoutLine(line: LayoutLineVariable): RestApiAddressLayoutLine  {
    return {
        line_name: line.name,
        max_width: line.maxWidth
        
    };
}

export function getApiRequestFromFixedLayoutLine(line: LayoutLineFixed): RestApiAddressLayoutLine  {
    const result: RestApiAddressLayoutLine = {
        line_name: line.name,
        max_width: line.maxWidth,                
        elements: []
    };
    for (const element of (Array.isArray(line.elements) ? line.elements : [])) {
        if (element === null) {            
            result.elements?.push({});
        } else {
            const typedElement = element as AddressElement;
            result.elements?.push({element_name: typedElement.elementName});
        }
    }

    return result;    
}
