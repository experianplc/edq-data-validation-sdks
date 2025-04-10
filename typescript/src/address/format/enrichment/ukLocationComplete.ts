import { RestApiEnrichmentUKLocationComplete } from "../../../server/address/format/restApiEnrichmentUKLocationComplete";
import { GeocodeMatchLevel, lookupGeocodeMatchLevel } from "../geocodeMatchLevel";

export type UKLocationComplete = {
    latitude?: number;
    longitude?: number;
    matchLevel?: GeocodeMatchLevel;
    udprn: string;
    uprn: string;
    xCoordinate?: number;
    yCoordinate?: number;
};

export function restApiResponseToUKLocationComplete(response: RestApiEnrichmentUKLocationComplete): UKLocationComplete {
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