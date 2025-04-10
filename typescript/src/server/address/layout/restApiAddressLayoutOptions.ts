import { RestApiElementSeparator } from "./restApiElementSeparator";

export type RestApiAddressLayoutOptions = {
    variations?: number;
    flatten_diacritics?: boolean;
    enable_enhanced_layout?: boolean;
    display_enhanced_info_on_picklist?: boolean;
    enable_intelligent_layout?: boolean;
    capitalise_unused?: boolean;
    separate_elements?: boolean;
    element_separator?: RestApiElementSeparator;
    retention_element_separator?: RestApiElementSeparator;
    prepend_element_separator?: RestApiElementSeparator;
    separate_element_separator?: RestApiElementSeparator;
    terminate_lines?: boolean;
    line_terminator?: RestApiElementSeparator;
    conditional_format?: string;
    pad_lines?: boolean;
    padding_character?: string;
    multiple_dataplus_delimiter?: string;
    abbreviate_item?: string[];
    capitalise_item?: string[];
    exclude_item?: string[];
    element_extras?: { [key: string]: string };
};