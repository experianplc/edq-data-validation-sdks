import { RestApiEnrichmentUKLocationEssential } from "../../../server/address/format/restApiEnrichmentUKLocationEssential";
import { GeocodeMatchLevel, lookupGeocodeMatchLevel } from "../geocodeMatchLevel";

export type UKLocationEssential = {
    latitude?: number;
    longitude?: number;
    matchLevel?: GeocodeMatchLevel;
    udprn: string;
    uprn: string;
    xCoordinate?: number;
    yCoordinate?: number;
};

export function restApiResponseToUKLocationEssential(response: RestApiEnrichmentUKLocationEssential): UKLocationEssential {
    return {
        latitude: response.latitude,
        longitude: response.longitude,
        matchLevel: lookupGeocodeMatchLevel(response.match_level),
        udprn: response.udprn??"",
        uprn: response.uprn??"",
        xCoordinate: response.x_coordinate,
        yCoordinate: response.y_coordinate
    };
}