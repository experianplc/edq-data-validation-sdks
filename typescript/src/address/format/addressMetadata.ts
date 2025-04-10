import { RestApiAddressFormatMetadata } from "../../server/address/format/restApiAddressFormatMetadata";

export type AddressMetadata = {
    sources: string[];
    numberOfHouseholds: string;
    justBuiltDate: string;
    umrrn: string;
    udprn: string;
    dpid: string;
    gnafpid: string;
    pafAddressKey: string;
    hin: string;
    deliveryPointBarcode: string;
    barcodeCheckDigit: string;
    barcodeSortPlanNumber: string;
};

export function restApiResponseToAddressMetadata(response: RestApiAddressFormatMetadata): AddressMetadata {
    const apiInfo = response.address_info;
    const barcode = extractBarcode(response);

    if (apiInfo) {
        const identifier = apiInfo.identifier;
        return {
            sources: apiInfo.sources ?? [],
            numberOfHouseholds: apiInfo.number_of_households ?? "",
            justBuiltDate: apiInfo.just_built_date ?? "",
            ...extractIdentifier(identifier),
            ...barcode,
        };
    }

    return {
        sources: [],
        numberOfHouseholds: "",
        justBuiltDate: "",
        umrrn: "",
        udprn: "",
        dpid: "",
        gnafpid: "",
        pafAddressKey: "",
        hin: "",
        ...barcode,
    };
}

function extractIdentifier(identifier: any) {
    return {
        umrrn: identifier?.umrrn ?? "",
        udprn: identifier?.udprn ?? "",
        dpid: identifier?.dpid ?? "",
        gnafpid: identifier?.gnafpid ?? "",
        pafAddressKey: identifier?.paf_address_key ?? "",
        hin: identifier?.hin ?? "",
    };
}

function extractBarcode(response: RestApiAddressFormatMetadata) {
    return {
        deliveryPointBarcode: response.barcode?.delivery_point_barcode ?? "",
        barcodeCheckDigit: response.barcode?.check_digit ?? "",
        barcodeSortPlanNumber: response.barcode?.sort_plan_number ?? "",
    };
}