import { RestApiAddressLookupElectricityMeter } from "./restApiAddressLookupElectricityMeter";
import { RestApiAddressLookupGasMeter } from "./restApiAddressLookupGasMeter";

export type RestApiAddressLookupV2ResultAddressFormatted = {
    layout_name?: string;
    address?: {
        electricity_meters?: RestApiAddressLookupElectricityMeter[],
        gas_meters?: RestApiAddressLookupGasMeter[]

    };
};