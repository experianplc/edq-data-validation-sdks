import { RestApiAddressMetadataAddressClassification } from "./restApiAddressMetadataAddressClassification";
import { RestApiAddressMetadataBarcode } from "./restApiAddressMetadataBarcode";
import { RestApiAddressMetadataDpv } from "./restApiAddressMetadataDpv";
import { RestApiAddressMetadataInfo } from "./restApiAddressMetadataInfo";
import { RestApiAddressMetadataRouteClassification } from "./restApiAddressMetadataRouteClassification";

export type RestApiAddressFormatMetadata = {
    address_info?: RestApiAddressMetadataInfo;
    barcode?: RestApiAddressMetadataBarcode;
    route_classification?: RestApiAddressMetadataRouteClassification;
    address_classification?: RestApiAddressMetadataAddressClassification;
    dpv?: RestApiAddressMetadataDpv;
};