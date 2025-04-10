
import { Dataset, Datasets } from "./dataset";
import { SearchType } from "./searchType";

export class DatasetCombinations {

    private static readonly CombinationsDetails: { [key in SearchType]: Dataset[][] } = {
        [SearchType.Autocomplete]: [
            [Datasets.GbAddress, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAddress, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAddress, Datasets.GbAdditionalBusiness],
            [Datasets.GbAddress, Datasets.GbAdditionalElectricity],
            [Datasets.GbAddress, Datasets.GbAdditionalGas],
            [Datasets.GbAddress, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAddress, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAddress, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAddress, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAddress, Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas],
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalGas, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalGas, Datasets.GbAdditionalBusiness],
            [Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalBusiness],
            [Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalGas, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalBusiness],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalBusiness],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas, Datasets.GbAdditionalBusiness],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalBusiness],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalElectricity, Datasets.GbAdditionalGas, Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence]
        ],
        [SearchType.Singleline]: [
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNames, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalNames]
        ],
        [SearchType.Typedown]: [
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNames, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt],
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalNames],
            [Datasets.GbAdditionalNotyetbuilt, Datasets.GbAdditionalNames]
        ],
        [SearchType.Validate]: [
            [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt]
        ],
        [SearchType.LookupV2]: [],
        [SearchType.LookupV1]: []
    };

    public static fromSearchType(searchType: SearchType): Dataset[][] {
        return this.CombinationsDetails[searchType];
    }
}
