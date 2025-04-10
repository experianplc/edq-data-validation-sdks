import { GeocodeMatchLevel } from "../geocodeMatchLevel";

export type UsaRegionalGeocodes = {
    latitude?: number;
    longitude?: number;
    matchLevel?: GeocodeMatchLevel;
    censusTract: string;
    censusBlock: string;
    coreBasedStatisticalArea: string;
    congressionalDistrictCode: string;
    countyCode: string;
};