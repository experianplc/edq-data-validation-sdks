import { RestApiAddressLookupV2ResultAddressFormatted } from "../../server/address/lookup/restApiAddressLookupV2ResultAddressFormatted";
import { LookupElectricityMeter, restApiResponseToLookupElectricityMeter } from "./lookupElectricityMeter";
import { LookupGasMeter, restApiResponseToLookupGasMeter } from "./lookupGasMeter";

export type LookupV2ResultAddressFormatted = {
    layoutName?: string;
    address?: {
        electricityMeters?: LookupElectricityMeter[],
        gasMeters?: LookupGasMeter[]
    };
}

export function restApiResponseToLookupAddressFormatted(response: RestApiAddressLookupV2ResultAddressFormatted): LookupV2ResultAddressFormatted {
    const result: LookupV2ResultAddressFormatted = {
        layoutName: response.layout_name,        
    };
    if (response.address) {
        result.address = {};
        if (response.address.electricity_meters) {
            result.address.electricityMeters = response.address.electricity_meters.map(e => restApiResponseToLookupElectricityMeter(e));
        }
        if (response.address.gas_meters) {
            result.address.gasMeters = response.address.gas_meters.map(g => restApiResponseToLookupGasMeter(g));
        }
    }
    return result;
}