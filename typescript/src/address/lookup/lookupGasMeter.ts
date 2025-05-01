import { RestApiAddressLookupGasMeter } from "../../server/address/lookup/restApiAddressLookupGasMeter";

export type LookupGasMeter = {
    mprn?: string; // Meter Point Reference Number
    relAddressPrimaryName?: string; // The Primary Addressable Object description. This is normally the name and or number of the property.
    relAddressSecondaryName?: string; // The Secondary Addressable Object description, e.g. the “Flat 2” in the address “Flat 2, London House, Exeter”. This is only relevant for a child property. “London House” in this case will the Primary Name of the parent property.
    relAddressStreet1?: string; // DPA – thoroughfare, LPI – derived from street
    relAddressStreet2?: string; // DPA – dependent thoroughfare, LPI – blank
    relAddressLocality1?: string; // DPA – dependent locality, LPI – derived from street
    relAddressLocality2?: string; // DPA – double dependent locality, LPI – blank
    relAddressTown?: string; // DPA – post town, LPI – derived from street
    relAddressPostcode?: string; // Postcode associated with the address
    relAddressLogicalStatus?: string; // The status of the address
    relAddressLanguage?: string; // The language of the address (ISO 639-2 Code)
    relAddressOrganisation?: string; // Current organisation name of the property if one exists
    relAddressAddressType?: string; // The type of address of this entry: DPA – Delivery Point Address, LPI – Local Property Identifier
    relAddressConfidenceScore?: number; // A relative confidence score on the match from MPL to REL
    relAddressClassification?: string; // Classification code of the property as per the AddressBase Premium classification scheme
    relAddressLatitude?: number; // Latitude of the associated property, usually either the centroid of the building polygon or a general internal point within the building polygon
    relAddressLongitude?: number; // Longitude of the associated property, usually either the centroid of the building polygon or a general internal point within the building polygon
    meterSerial?: string; // The manufacturer's meter serial number as held on the physical meter currently installed on the supply point
    offtakeQuantityAnnual?: number; // The current annual offtake quantity (AQ) of a Supply Meter Point. Value in kWh
    meterPointStatus?: string; // The current status of the operability of the supply meter point. LI = Live; DE = Dead; CA = Capped; CL = Clamped; PL = Planned
    installerId?: string; // The smart meter Supplier ID
    networkName?: string; // Gas Distribution Network Name
    supplierName?: string; // The name of the current Supplier
    lastMeterReadDate?: string; // The date on which the last meter read recorded at the site
    lastMeterReadType?: string; // Latest meter read type
    lastMeterReadValue?: number; // The last meter read value
};

export function restApiResponseToLookupGasMeter(response: RestApiAddressLookupGasMeter): LookupGasMeter {
    return {
        mprn: response.mprn,
        relAddressPrimaryName: response.rel_address_primary_name,
        relAddressSecondaryName: response.rel_address_secondary_name,
        relAddressStreet1: response.rel_address_street1,
        relAddressStreet2: response.rel_address_street2,
        relAddressLocality1: response.rel_address_locality1,
        relAddressLocality2: response.rel_address_locality2,
        relAddressTown: response.rel_address_town,
        relAddressPostcode: response.rel_address_postcode,
        relAddressLogicalStatus: response.rel_address_logical_status,
        relAddressLanguage: response.rel_address_language,
        relAddressOrganisation: response.rel_address_organisation,
        relAddressAddressType: response.rel_address_address_type,
        relAddressConfidenceScore: response.rel_address_confidence_score,
        relAddressClassification: response.rel_address_classification,
        relAddressLatitude: response.rel_address_latitude,
        relAddressLongitude: response.rel_address_longitude,
        meterSerial: response.meter_serial,
        offtakeQuantityAnnual: response.offtake_quantity_annual,
        meterPointStatus: response.meter_point_status,
        installerId: response.installer_id,
        networkName: response.network_name,
        supplierName: response.supplier_name,
        lastMeterReadDate: response.last_meter_read_date,
        lastMeterReadType: response.last_meter_read_type,
        lastMeterReadValue: response.last_meter_read_value,
    };
}