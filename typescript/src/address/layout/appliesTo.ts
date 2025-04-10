import { RestApiAddressLayoutAppliesTo } from '../../server/address/layout/restApiAddressLayoutAppliesTo';
import { Dataset, Datasets } from '../dataset';

export type AppliesTo = {
    datasets: Dataset[];
    language?: string;
    script?: string;
};

export function restApiResponseToAppliesTo(apiItem: RestApiAddressLayoutAppliesTo): AppliesTo {
    return {
        datasets: apiItem.datasets ? apiItem.datasets.map(p => Datasets.fromCode(p)) : [],
        language: apiItem.language??"",
        script: apiItem.script??""
    }
}