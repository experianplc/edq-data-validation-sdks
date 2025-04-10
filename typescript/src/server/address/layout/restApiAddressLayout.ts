import { RestApiAddressLayoutAppliesTo } from "./restApiAddressLayoutAppliesTo";
import { RestApiAddressLayoutLine } from "./restApiAddressLayoutLine";
import { RestApiAddressLayoutOptions } from "./restApiAddressLayoutOptions";

export type RestApiAddressLayout = {
    name?: string;
    comment?: string;
    applies_to?: RestApiAddressLayoutAppliesTo[];
    options?: RestApiAddressLayoutOptions;
    lines?: RestApiAddressLayoutLine[];
};
