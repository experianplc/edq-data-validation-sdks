import { RestApiAddressLayoutAppliesTo } from "./restApiAddressLayoutAppliesTo";

export type RestApiGetLayoutsListItem = {
    id?: string;
    name?: string;
    applies_to?: RestApiAddressLayoutAppliesTo[];
    status?: string;
};