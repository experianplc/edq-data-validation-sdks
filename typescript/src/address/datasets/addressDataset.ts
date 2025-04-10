import { Countries, Country } from "../../common/country";
import { RestApiAddressDatasetResult } from "../../server/address/datasets/restApiAddressDatasetResult";
import { Dataset, Datasets } from "../dataset";

export type AddressDataset = {
    country: Country;
    datasets: Dataset[];
    validCombinations: Dataset[][];
}

export function restApiAddressDatasetResult2AddressDataset(toConvert: RestApiAddressDatasetResult): AddressDataset {
    return {
        country: toConvert.country_iso_3 && toConvert.country_iso_3.length > 0 ? Countries.fromIso3(toConvert.country_iso_3) : Countries.Unknown,
        datasets: toConvert.datasets && toConvert.datasets.length > 0 ? toConvert.datasets.map( ds => ds.id ? Datasets.fromCode(ds.id) : undefined).filter((ds): ds is Dataset => ds !== undefined) : [],
        validCombinations: toConvert.valid_combinations && toConvert.valid_combinations.length > 0 ? toConvert.valid_combinations.map( vc => vc.map( p => Datasets.fromCode(p))) : []
    }
}