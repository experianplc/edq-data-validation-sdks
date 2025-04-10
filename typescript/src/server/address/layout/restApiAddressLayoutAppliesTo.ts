import { AppliesTo } from "../../../address/layout/appliesTo";

export type RestApiAddressLayoutAppliesTo = {
    country_iso?: string;
    datasets?: string[];
    language?: string;
    script?: string;
};


export function getApiRequestFromLayoutAppliesTo(appliesTo: AppliesTo): RestApiAddressLayoutAppliesTo  {
    const result: RestApiAddressLayoutAppliesTo = {};

    if (appliesTo.datasets && appliesTo.datasets.length > 0) {
        result.country_iso =  appliesTo.datasets[0].country.iso3Code;
        result.datasets = appliesTo.datasets.map(dataset => dataset.datasetCode);
    }
    if (appliesTo.language) {
        result.language = appliesTo.language;
    }
    if (appliesTo.script) {
        result.script = appliesTo.script;
    }
    return result;

}