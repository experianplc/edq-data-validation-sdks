import { RestApiAddressFormatted } from "../../server/address/format/restApiAddressFormatted";
import { AddressFormattedLine, restApiToAddressFormattedLine } from "./addressFormattedLine";

export type AddressFormatted = {
    notEnoughLines: boolean;
    layoutName: string;
    hasTruncatedLines: boolean;
    address: { [key: string]: string };
    hasMissingSubPremises: boolean;
    addressLines: AddressFormattedLine[];
};

export function restApiToAddressFormatted(response: RestApiAddressFormatted): AddressFormatted {
    
    return {
        layoutName: response.layout_name ?? "",
        notEnoughLines: response.not_enough_lines ?? false,
        hasTruncatedLines: response.has_truncated_lines ?? false,
        address: Object.fromEntries(
            Object.entries(response.address ?? {}).map(([key, value]) => [key, value ?? ""])
        ),
        hasMissingSubPremises: response.has_missing_sub_premises ?? false,
        addressLines: response.address_lines ? response.address_lines.map(line => restApiToAddressFormattedLine(line)) : []
    };
    
}