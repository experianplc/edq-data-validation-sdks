import { AddressElement } from "./elements/addressElement";

export type LayoutLineFixed = {
    name: string;
    maxWidth?: number;
    elements: (AddressElement | null)[];
};