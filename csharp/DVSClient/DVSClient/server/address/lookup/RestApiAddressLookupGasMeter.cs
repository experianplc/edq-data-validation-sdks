using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
   
    public class RestApiAddressLookupGasMeter
    {
        [JsonProperty("mprn")]
        public string? Mprn { get; set; } // Meter Point Reference Number

        [JsonProperty("rel_address_primary_name")]
        public string? RelAddressPrimaryName { get; set; } // The Primary Addressable Object description. This is normally the name and or number of the property.

        [JsonProperty("rel_address_secondary_name")]
        public string? RelAddressSecondaryName { get; set; } // The Secondary Addressable Object description, e.g. the “Flat 2” in the address “Flat 2, London House, Exeter”. This is only relevant for a child property. “London House” in this case will the Primary Name of the parent property.

        [JsonProperty("rel_address_street1")]
        public string? RelAddressStreet1 { get; set; } // DPA – thoroughfare, LPI – derived from street

        [JsonProperty("rel_address_street2")]
        public string? RelAddressStreet2 { get; set; } // DPA – dependent thoroughfare, LPI – blank

        [JsonProperty("rel_address_locality1")]
        public string? RelAddressLocality1 { get; set; } // DPA – dependent locality, LPI – derived from street

        [JsonProperty("rel_address_locality2")]
        public string? RelAddressLocality2 { get; set; } // DPA – double dependent locality, LPI – blank

        [JsonProperty("rel_address_town")]
        public string? RelAddressTown { get; set; } // DPA – post town, LPI – derived from street

        [JsonProperty("rel_address_postcode")]
        public string? RelAddressPostcode { get; set; } // Postcode associated with the address

        [JsonProperty("rel_address_logical_status")]
        public string? RelAddressLogicalStatus { get; set; } // The status of the address

        [JsonProperty("rel_address_language")]
        public string? RelAddressLanguage { get; set; } // The language of the address (ISO 639-2 Code)

        [JsonProperty("rel_address_organisation")]
        public string? RelAddressOrganisation { get; set; } // Current organisation name of the property if one exists

        [JsonProperty("rel_address_address_type")]
        public string? RelAddressAddressType { get; set; } // The type of address of this entry: DPA – Delivery Point Address, LPI – Local Property Identifier

        [JsonProperty("rel_address_confidence_score")]
        public double? RelAddressConfidenceScore { get; set; } // A relative confidence score on the match from MPL to REL

        [JsonProperty("rel_address_classification")]
        public string? RelAddressClassification { get; set; } // Classification code of the property as per the AddressBase Premium classification scheme

        [JsonProperty("rel_address_latitude")]
        public double? RelAddressLatitude { get; set; } // Latitude of the associated property, usually either the centroid of the building polygon or a general internal point within the building polygon

        [JsonProperty("rel_address_longitude")]
        public double? RelAddressLongitude { get; set; } // Longitude of the associated property, usually either the centroid of the building polygon or a general internal point within the building polygon

        [JsonProperty("meter_serial")]
        public string? MeterSerial { get; set; } // The manufacturer's meter serial number as held on the physical meter currently installed on the supply point

        [JsonProperty("offtake_quantity_annual")]
        public double? OfftakeQuantityAnnual { get; set; } // The current annual offtake quantity (AQ) of a Supply Meter Point. Value in kWh

        [JsonProperty("meter_point_status")]
        public string? MeterPointStatus { get; set; } // The current status of the operability of the supply meter point. LI = Live; DE = Dead; CA = Capped; CL = Clamped; PL = Planned

        [JsonProperty("installer_id")]
        public string? InstallerId { get; set; } // The smart meter Supplier ID

        [JsonProperty("network_name")]
        public string? NetworkName { get; set; } // Gas Distribution Network Name

        [JsonProperty("supplier_name")]
        public string? SupplierName { get; set; } // The name of the current Supplier

        [JsonProperty("last_meter_read_date")]
        public string? LastMeterReadDate { get; set; } // The date on which the last meter read recorded at the site

        [JsonProperty("last_meter_read_type")]
        public string? LastMeterReadType { get; set; } // Latest meter read type

        [JsonProperty("last_meter_read_value")]
        public double? LastMeterReadValue { get; set; } // The last meter read value

    }
}