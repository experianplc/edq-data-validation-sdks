import { RestApiAddressFormattedLine } from "../../server/address/format/restApiAddressFormattedLine";
import { LineContent, lookupLineContent } from "./lineContent";

export type AddressFormattedLine = {
    label: string;
    line: string;
    hasOverflownToOtherLine: boolean;
    isTruncated: boolean;
    lineContent?: LineContent;
};

export function restApiToAddressFormattedLine(response: RestApiAddressFormattedLine): AddressFormattedLine {
    return {
        label: response.label ?? "",
        line: response.line ?? "",
        hasOverflownToOtherLine: response.has_overflown_to_other_line ?? false,
        isTruncated: response.is_truncated ?? false,
        lineContent: lookupLineContent(response.line_content)
    }
}