import { RestApiAddressLayoutAppliesTo } from "./restApiAddressLayoutAppliesTo";
import { RestApiAddressLayoutLine } from "./restApiAddressLayoutLine";

export type RestApiGetLayoutLayout = {
    id?: string;
    name?: string;
    comment?: string;
    applies_to?: RestApiAddressLayoutAppliesTo[];
    lines?: RestApiAddressLayoutLine[];
    status?: string;
    license_id?: string;
};