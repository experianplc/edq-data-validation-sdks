type RestApiAddressLookupSuggestion = {
    locality?: {
        region?: RestApiAddressLookupLocalityItem;
        sub_region?: RestApiAddressLookupLocalityItem;
        town?: RestApiAddressLookupLocalityItem;
        district?: RestApiAddressLookupLocalityItem;
        sub_district?: RestApiAddressLookupLocalityItem;
    };
    postal_code?: {
        full_name?: string;
        primary?: string;
        secondary: string;
    };
    postal_code_key?: string;
    locality_key?: string;
    what3words?: {
        name?: string;
        description?: string;
    };
};