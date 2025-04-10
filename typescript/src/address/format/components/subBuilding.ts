import { SubBuildingItem } from "./subBuildingItem";

export type SubBuilding = {
    name: string;
    entrance?: SubBuildingItem;
    floor?: SubBuildingItem;
    door?: SubBuildingItem;
};