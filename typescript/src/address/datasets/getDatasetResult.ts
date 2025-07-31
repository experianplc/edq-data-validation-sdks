import { ResponseError } from "../../common/responseError";
import { EDVSError } from "../../exceptions/edvsException";
import { RestApiGetDatasetsResponse } from "../../server/address/datasets/restApiGetDatasetsResponse";
import { AddressDataset, restApiAddressDatasetResult2AddressDataset } from "./addressDataset";

export type GetDatasetResult = {
    error?: ResponseError;
    result?: AddressDataset[];
    referenceId?: string;
}

export function restApiGetDatasetsResponseToResult(response: RestApiGetDatasetsResponse): Promise<GetDatasetResult> {
    const result: GetDatasetResult = {};
    if (response.error) {
        return Promise.reject(EDVSError.using(response.error));
    }
    if (response.result) {
        result.result = response.result.map(res => restApiAddressDatasetResult2AddressDataset(res));
    }

    result.referenceId = response.referenceId;
    return Promise.resolve(result);
}