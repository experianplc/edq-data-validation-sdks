import { Dataset, Datasets } from "../../dataset"
import { AppliesTo } from "../appliesTo";
import { AugAddressElements } from "./augAddressElements";
import { AusAddressElements } from "./ausAddressElements"
import { GbrAddressElements } from "./gbrAddressElements";
(global as any).AusAddressElements = AusAddressElements;

export type AddressElement = {
    elementName: string,
    description: string,
    example: string
}

const datasetToElementNamespaceMap: Map<string, any> = new Map<string, any>([
    [Datasets.AuAddress.datasetCode, AusAddressElements],
    [Datasets.AuAddressGnaf.datasetCode, AugAddressElements],
    [Datasets.GbAddress.datasetCode, GbrAddressElements]
]);

const datasetToElementLookupMap: Map<string, (elementName: string) => AddressElement | undefined> = new Map([
    [Datasets.AuAddress.datasetCode, (elementName: string) => AusAddressElements.getElementByName(elementName)],
    [Datasets.AuAddressGnaf.datasetCode, (elementName: string) => AugAddressElements.getElementByName(elementName)],
    [Datasets.GbAddress.datasetCode, (elementName: string) => GbrAddressElements.getElementByName(elementName)]
]);

export function getAddressElementFromElementName(appliesTo: AppliesTo[], elementName?: string): AddressElement | null {
    
    if (!elementName) {
        return null;
    }

    for ( const nextAppliesTo of appliesTo) {
        for (const dataset of nextAppliesTo.datasets) {
            const addressElement = getAddressElementForDataset(dataset, elementName);
            if (addressElement) {
                return addressElement;
            }
        }
    }
    return null;
}

export function getAddressElementForDataset(dataset: Dataset, elementName?: string): AddressElement| undefined  {

    const namespace = datasetToElementNamespaceMap.get(dataset.datasetCode);
    if (namespace) {
        return Object.values(namespace)
        .filter((element): element is AddressElement => element !== null && typeof element === "object" && "elementName" in element)
        .find((element) => element.elementName === elementName);
    }
}

