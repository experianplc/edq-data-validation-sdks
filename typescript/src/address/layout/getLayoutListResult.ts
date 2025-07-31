import { ResponseError } from "../../common/responseError";
import { GetLayoutListItem } from "./getLayoutListItem";

export type GetLayoutListResult = {
    error?: ResponseError;
    layouts?: GetLayoutListItem[];
    referenceId?: string;
};