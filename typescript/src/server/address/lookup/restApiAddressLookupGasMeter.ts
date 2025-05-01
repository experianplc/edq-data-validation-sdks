
export type RestApiAddressLookupGasMeter = {
    mprn?: string; // Meter Point Reference Number
    rel_address_primary_name?: string; // The Primary Addressable Object description. This is normally the name and or number of the property.
    rel_address_secondary_name?: string; // The Secondary Addressable Object description, e.g. the “Flat 2” in the address “Flat 2, London House, Exeter”. This is only relevant for a child property. “London House” in this case will the Primary Name of the parent property.
    rel_address_street1?: string; // DPA – thoroughfare, LPI – derived from street
    rel_address_street2?: string; // DPA – dependent thoroughfare, LPI – blank
    rel_address_locality1?: string; // DPA – dependent locality, LPI – derived from street
    rel_address_locality2?: string; // DPA – double dependent locality, LPI – blank
    rel_address_town?: string; // DPA – post town, LPI – derived from street
    rel_address_postcode?: string; // Postcode associated with the address
    rel_address_logical_status?: string; // The status of the address
    rel_address_language?: string; // The language of the address (ISO 639-2 Code)
    rel_address_organisation?: string; // Current organisation name of the property if one exists
    rel_address_address_type?: string; // The type of address of this entry: DPA – Delivery Point Address, LPI – Local Property Identifier
    rel_address_confidence_score?: number; // A relative confidence score on the match from MPL to REL
    rel_address_classification?: string; // Classification code of the property as per the AddressBase Premium classification scheme
    rel_address_latitude?: number; // Latitude of the associated property, usually either the centroid of the building polygon or a general internal point within the building polygon
    rel_address_longitude?: number; // Longitude of the associated property, usually either the centroid of the building polygon or a general internal point within the building polygon
    meter_serial?: string; // The manufacturer's meter serial number as held on the physical meter currently installed on the supply point
    offtake_quantity_annual?: number; // The current annual offtake quantity (AQ) of a Supply Meter Point. Value in kWh
    meter_point_status?: string; // The current status of the operability of the supply meter point. LI = Live; DE = Dead; CA = Capped; CL = Clamped; PL = Planned
    installer_id?: string; // The smart meter Supplier ID
    network_name?: string; // Gas Distribution Network Name
    supplier_name?: string; // The name of the current Supplier
    last_meter_read_date?: string; // The date on which the last meter read recorded at the site
    last_meter_read_type?: string; // Latest meter read type
    last_meter_read_value?: number; // The last meter read value
};
    