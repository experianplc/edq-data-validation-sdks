export type RestApiAddressFormatComponents = {
    language?: string;
    country_name?: string;
    country_iso_3?: string;
    country_iso_2?: string;
    postal_code?: {
        full_name?: string;
        primary?: string;
        secondary?: string;
    };
    delivery_service?: {
        full_name?: string;
        service_type?: string;
        service_number?: string;
        post_centre_name?: string;
    };
    secondary_delivery_service?: {
        full_name?: string;
        service_type?: string;
        service_number?: string;
        post_centre_name?: string;
    };
    sub_building?: {
        name?: string;
        entrance?: {
            full_name?: string;
            type?: string;
            value?: string;
        };
        floor?: {
            full_name?: string;
            type?: string;
            value?: string;
        };
        door?: {
            full_name?: string;
            type?: string;
            value?: string;
        };
    };
    building?: {
        building_name?: string;
        secondary_name?: string;
        building_number?: string;
        secondary_number?: string;
        allotment_number?: string;
    };
    organization?: {
        department_name?: string;
        secondary_department_name?: string;
        company_name?: string;
        business?: {
            company_name?: string;
        };
    };
    street?: {
        full_name?: string;
        prefix?: string;
        name?: string;
        type?: string;
        suffix?: string;
    };
    secondary_street?: {
        full_name?: string;
        prefix?: string;
        name?: string;
        type?: string;
        suffix?: string;
    };
    route_service?: {
        full_name?: string;
        service_type?: string;
        service_number?: string;
        delivery_name?: string;
        qualifier?: string;
    };
    locality?: {
        region?: {
            name?: string;
            code?: string;
            description?: string;
        };
        sub_region?: {
            name?: string;
            code?: string;
            description?: string;
        };
        town?: {
            name?: string;
            code?: string;
            description?: string;
        };
        district?: {
            name?: string;
            code?: string;
            description?: string;
        };
        sub_district?: {
            name?: string;
            code?: string;
            description?: string;
        };
    };
    physical_locality?: {
        region?: {
            name?: string;
            code?: string;
            description?: string;
        };
        sub_region?: {
            name?: string;
            code?: string;
            description?: string;
        };
        town?: {
            name?: string;
            code?: string;
            description?: string;
        };
        district?: {
            name?: string;
            code?: string;
            description?: string;
        };
        sub_district?: {
            name?: string;
            code?: string;
            description?: string;
        };
    };
    additional_elements?: {
        locality?: {
            sub_region?: {
                administrative_county?: string;
                former_postal_county?: string;
                traditional_county?: string;
            };
        };
    };
};