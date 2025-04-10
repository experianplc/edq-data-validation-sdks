export type RestApiPremiumLocationInsight = {
    geocodes?: PremiumLocationInsightGeocodes;
    geocodes_building_xy?: PremiumLocationInsightGeocodesBuildingXy;
    geocodes_access?: PremiumLocationInsightGeocodesAccess[];
    time?: PremiumLocationInsightTime[];
};

export type PremiumLocationInsightGeocodes = {
    latitude?: number;
    longitude?: number;
    match_level?: string;
};

export type PremiumLocationInsightGeocodesBuildingXy = {
    x_coordinate?: number;
    y_coordinate?: number;
};

export type PremiumLocationInsightGeocodesAccess = {
    latitude?: number;
    longitude?: number;
};

export type PremiumLocationInsightTime = {
    time_zone_id?: string;
    generic?: string;
    standard?: string;
    daylight?: string;
    reference_time?: PremiumLocationInsightReferenceTime;
    time_transition?: PremiumLocationInsightTimeTransition[];
};

export type PremiumLocationInsightReferenceTime = {
    tag?: string;
    standard_offset?: string;
    daylight_savings?: string;
    sunrise?: string;
    sunset?: string;
};

export type PremiumLocationInsightTimeTransition = {
    tag?: string;
    standard_offset?: string;
    daylight_savings?: string;
    utc_start?: string;
    utc_end?: string;
};