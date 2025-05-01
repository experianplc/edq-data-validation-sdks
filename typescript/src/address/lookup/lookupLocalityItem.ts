export type LookupLocalityItem = {
    name?: string;
    code?: string;
    description?: string;
};

export function restApiResponseToLookupLocalityItem(response: RestApiAddressLookupLocalityItem): LookupLocalityItem {
    return {
        name: response.name??"",
        code: response.code??"",
        description: response.description??""
    }
}