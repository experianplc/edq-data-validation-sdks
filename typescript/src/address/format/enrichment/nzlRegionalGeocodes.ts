import { RestApiEnrichmentNzlRegionalGeocodes } from "../../../server/address/format/restApiEnrichmentNzlRegionalGeocodes";
import { GeocodeMatchLevel, lookupGeocodeMatchLevel } from "../geocodeMatchLevel";

export type NzlRegionalGeocodes = {
    frontOfPropertyNztmXCoordinate?: number;
    frontOfPropertyNztmYCoordinate?: number;
    centroidOfPropertyNztmXCoordinate?: number;
    centroidOfPropertyNztmYCoordinate?: number;
    linzParcelId: string;
    propertyPurposeType: string;
    addressable: string;
    meshBlockCode: string;
    territorialAuthorityCode: string;
    territorialAuthorityName: string;
    regionalCouncilCode: string;
    regionalCouncilName: string;
    generalElectorateCode: string;
    generalElectorateName: string;
    maoriElectorateCode: string;
    maoriElectorateName: string;
    frontOfPropertyLatitude?: number;
    frontOfPropertyLongitude?: number;
    centroidOfPropertyLatitude?: number;
    centroidOfPropertyLongitude?: number;
    matchLevel?: GeocodeMatchLevel;
};

export function restApiResponseToNzlRegionalGeocodes(response: RestApiEnrichmentNzlRegionalGeocodes): NzlRegionalGeocodes {
    return {
        frontOfPropertyNztmXCoordinate: response.front_of_property_nztm_x_coordinate,
        frontOfPropertyNztmYCoordinate: response.front_of_property_nztm_y_coordinate,
        centroidOfPropertyNztmXCoordinate: response.centroid_of_property_nztm_x_coordinate,
        centroidOfPropertyNztmYCoordinate: response.centroid_of_property_nztm_y_coordinate,
        linzParcelId: response.linz_parcel_id ?? "",
        propertyPurposeType: response.property_purpose_type ?? "",
        addressable: response.addressable ?? "",
        meshBlockCode: response.mesh_block_code ?? "",
        territorialAuthorityCode: response.territorial_authority_code ?? "",
        territorialAuthorityName: response.territorial_authority_name ?? "",
        regionalCouncilCode: response.regional_council_code ?? "",
        regionalCouncilName: response.regional_council_name ?? "",
        generalElectorateCode: response.general_electorate_code ?? "",
        generalElectorateName: response.general_electorate_name ?? "",
        maoriElectorateCode: response.maori_electorate_code ?? "",
        maoriElectorateName: response.maori_electorate_name ?? "",
        frontOfPropertyLatitude: response.front_of_property_latitude,
        frontOfPropertyLongitude: response.front_of_property_longitude,
        centroidOfPropertyLatitude: response.centroid_of_property_latitude,
        centroidOfPropertyLongitude: response.centroid_of_property_longitude,
        matchLevel: lookupGeocodeMatchLevel(response.match_level)
    };
}