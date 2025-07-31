import { AddressConfiguration } from "../../../address/addressConfiguration";
import { getFormatAttribute } from "../validate/restApiAddressValidateRequest";
import { RestApiFormatAttribute } from "./restApiFormatAttribute";

export type RestApiFormatRequest = {
    layouts?: string[];
    layout_format?: string;
    attributes?: RestApiFormatAttribute;
};

export function getFormatRequestFromConfig(config: AddressConfiguration): RestApiFormatRequest {
    const request: RestApiFormatRequest = {
        layouts: [config.options.layoutName!],
        layout_format: config.options.layoutFormat!
    };
    const attributes = getFormatAttribute(config);
    if (attributes) {
        request.attributes = attributes;
    }
    return request;
        
}

