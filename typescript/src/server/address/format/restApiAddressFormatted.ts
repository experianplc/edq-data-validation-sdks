import { RestApiAddressFormattedLine } from "./restApiAddressFormattedLine";

export type RestApiAddressFormatted = {
    layout_name?: string;
    not_enough_lines?: boolean;
    has_truncated_lines?: boolean;
    address?: { [key: string]: string };
    has_missing_sub_premises?: boolean;
    address_lines?: RestApiAddressFormattedLine[];
};