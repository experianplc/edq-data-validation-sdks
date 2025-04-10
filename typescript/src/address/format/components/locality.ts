import { LocalityItem } from "./localityItem";

export type Locality = {
    region?: LocalityItem;
    subRegion?: LocalityItem;
    town?: LocalityItem;
    district?: LocalityItem;
    subDistrict?: LocalityItem;
};