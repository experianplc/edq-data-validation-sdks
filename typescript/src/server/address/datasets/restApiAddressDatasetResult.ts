import { RestApiAddressDatasetElement } from "./restApiAddressDatasetElement";

export interface RestApiAddressDatasetResult {
    country_iso_3?: string;
    country_name?: string;
    datasets?: RestApiAddressDatasetElement[];
    valid_combinations?: string[][];
}
