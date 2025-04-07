using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressFormatComponents
    {
        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("country_name")]
        public string? CountryName { get; set; }

        [JsonProperty("country_iso_3")]
        public string? CountryIso3 { get; set; }

        [JsonProperty("country_iso_2")]
        public string? CountryIso2 { get; set; }

        [JsonProperty("postal_code")]
        public RestApiAddressComponentPostalCode? PostalCode { get; set; }

        [JsonProperty("delivery_service")]
        public RestApiAddressComponentDeliveryService? DeliveryService { get; set; }

        [JsonProperty("secondary_delivery_service")]
        public RestApiAddressComponentDeliveryService? SecondaryDeliveryService { get; set; }

        [JsonProperty("sub_building")]
        public RestApiAddressComponentSubBuilding? SubBuilding { get; set; }

        [JsonProperty("building")]
        public RestApiAddressComponentBuilding? Building { get; set; }

        [JsonProperty("organization")]
        public RestApiAddressComponentOrganization? Organization { get; set; }

        [JsonProperty("street")]
        public RestApiAddressComponentStreet? Street { get; set; }

        [JsonProperty("secondary_street")]
        public RestApiAddressComponentStreet? SecondaryStreet { get; set; }

        [JsonProperty("route_service")]
        public RestApiAddressComponentRouteService? RouteService { get; set; }

        [JsonProperty("locality")]
        public RestApiAddressComponentLocality? Locality { get; set; }

        [JsonProperty("physical_locality")]
        public RestApiAddressComponentLocality? PhysicalLocality { get; set; }

        [JsonProperty("additional_elements")]
        public RestApiAddressComponentAdditionalElements? AdditionalElements { get; set; }

        public class RestApiAddressComponentPostalCode
        {
            [JsonProperty("full_name")]
            public string? FullName { get; set; }

            [JsonProperty("primary")]
            public string? Primary { get; set; }

            [JsonProperty("secondary")]
            public string? Secondary { get; set; }
        }

        public class RestApiAddressComponentDeliveryService
        {
            [JsonProperty("full_name")]
            public string? FullName { get; set; }

            [JsonProperty("service_type")]
            public string? ServiceType { get; set; }

            [JsonProperty("service_number")]
            public string? ServiceNumber { get; set; }

            [JsonProperty("post_centre_name")]
            public string? PostCentreName { get; set; }
        }

        public class RestApiAddressComponentSubBuilding
        {
            [JsonProperty("name")]
            public string? Name { get; set; }

            [JsonProperty("entrance")]
            public AddressComponentSubBuildingItem? Entrance { get; set; }

            [JsonProperty("floor")]
            public AddressComponentSubBuildingItem? Floor { get; set; }

            [JsonProperty("door")]
            public AddressComponentSubBuildingItem? Door { get; set; }
        }

        public class AddressComponentSubBuildingItem
        {
            [JsonProperty("full_name")]
            public string? FullName { get; set; }

            [JsonProperty("type")]
            public string? Type { get; set; }

            [JsonProperty("value")]
            public string? Value { get; set; }
        }

        public class RestApiAddressComponentBuilding
        {
            [JsonProperty("building_name")]
            public string? BuildingName { get; set; }

            [JsonProperty("secondary_name")]
            public string? SecondaryName { get; set; }

            [JsonProperty("building_number")]
            public string? BuildingNumber { get; set; }

            [JsonProperty("secondary_number")]
            public string? SecondaryNumber { get; set; }

            [JsonProperty("allotment_number")]
            public string? AllotmentNumber { get; set; }
        }

        public class RestApiAddressComponentOrganization
        {
            [JsonProperty("department_name")]
            public string? DepartmentName { get; set; }

            [JsonProperty("secondary_department_name")]
            public string? SecondaryDepartmentName { get; set; }

            [JsonProperty("company_name")]
            public string? CompanyName { get; set; }

            [JsonProperty("business")]
            public AddressComponentBusinessOrganization? Business { get; set; }
        }

        public class AddressComponentBusinessOrganization
        {
            [JsonProperty("company_name")]
            public string? CompanyName { get; set; }
        }

        public class RestApiAddressComponentStreet
        {
            [JsonProperty("full_name")]
            public string? FullName { get; set; }

            [JsonProperty("prefix")]
            public string? Prefix { get; set; }

            [JsonProperty("name")]
            public string? Name { get; set; }

            [JsonProperty("type")]
            public string? Type { get; set; }

            [JsonProperty("suffix")]
            public string? Suffix { get; set; }
        }

        public class RestApiAddressComponentRouteService
        {
            [JsonProperty("full_name")]
            public string? FullName { get; set; }

            [JsonProperty("service_type")]
            public string? ServiceType { get; set; }

            [JsonProperty("service_number")]
            public string? ServiceNumber { get; set; }

            [JsonProperty("delivery_name")]
            public string? DeliveryName { get; set; }

            [JsonProperty("qualifier")]
            public string? Qualifier { get; set; }
        }

        public class RestApiAddressComponentLocality
        {
            [JsonProperty("region")]
            public AddressComponentLocalityItem? Region { get; set; }

            [JsonProperty("sub_region")]
            public AddressComponentLocalityItem? SubRegion { get; set; }

            [JsonProperty("town")]
            public AddressComponentLocalityItem? Town { get; set; }

            [JsonProperty("district")]
            public AddressComponentLocalityItem? District { get; set; }

            [JsonProperty("sub_district")]
            public AddressComponentLocalityItem? SubDistrict { get; set; }
        }

        public class AddressComponentLocalityItem
        {
            [JsonProperty("name")]
            public string? Name { get; set; }

            [JsonProperty("code")]
            public string? Code { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }
        }

        public class RestApiAddressComponentAdditionalElements
        {
            [JsonProperty("locality")]
            public RestApiAddressComponentAdditionalLocality? Locality { get; set; }
        }

        public class RestApiAddressComponentAdditionalLocality
        {
            [JsonProperty("sub_region")]
            public RestApiAddressComponentAdditionalSubRegion? SubRegion { get; set; }
        }

        public class RestApiAddressComponentAdditionalSubRegion
        {
            [JsonProperty("administrative_county")]
            public string? AdministrativeCounty { get; set; }

            [JsonProperty("former_postal_county")]
            public string? FormerPostalCounty { get; set; }

            [JsonProperty("traditional_county")]
            public string? TraditionalCounty { get; set; }
        }
    }
}