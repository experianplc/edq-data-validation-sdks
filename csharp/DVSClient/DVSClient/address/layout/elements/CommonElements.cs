namespace DVSClient.Address.Layout.Elements
{
    internal abstract class CommonElements
    {
        protected static readonly AddressElement Empty = new AddressElement("empty", "Empty line", "");

        protected static readonly CommonOrganization Organization = new CommonOrganization
        {
            CompanyName = new AddressElement("companyName", "Company/organization name assigned", ""),
            Department = new AddressElement("department", "Departments within an organization that are postally addressable", ""),
        };

        protected static readonly CommonBuilding Building = new CommonBuilding
        {
            StreetNumber = new AddressElement("streetNumber", "Street/Building number", ""),
            BuildingLevel = new AddressElement("buildingLevel", "Building level", ""),
            BuildingName = new AddressElement("buildingName", "Building name", "Treasury Building"),
            Subbuilding = new CommonSubbuilding
            {
                Extension = new AddressElement("extension", "Building extension", ""),
                ExtensionAlt = new AddressElement("extensionAlt", "Building extension alternative information", ""),
                ExtensionAltName = new AddressElement("extensionAltName", "Building extension alternative name", ""),
                ExtensionNumber = new AddressElement("extensionNumber", "Building extension number", ""),
                SubBuildingType = new AddressElement("subBuildingType", "Sub building type", ""),
                SubBuildingNumber = new AddressElement("subBuildingNumber", "Sub building number", ""),
            }
        };

        protected static readonly CommonStreet Street = new CommonStreet
        {
            Street = new AddressElement("streetPrimary", "Street primary", ""),
            PreDirectional = new AddressElement("streetPreDirectionalPrimary", "Street pre directional primary", ""),
            Name = new AddressElement("streetNamePrimary", "Street name primary", ""),
            Type = new AddressElement("streetTypePrimary", "Street type primary", ""),
            PostDirectional = new AddressElement("streetPostDirectionalPrimary", "Street post directional primary", ""),
            SecondaryStreet = new CommonStreet
            {
                Street = new AddressElement("streetSecondary", "Street secondary", ""),
                Name = new AddressElement("streetNameSecondary", "Street name secondary", ""),
                Type = new AddressElement("streetTypeSecondary", "Street type secondary", ""),
            }
        };

        protected static readonly CommonLocality Locality = new CommonLocality
        {
            Region = new AddressElement("region", "Region", ""),
            RegionAlt = new AddressElement("regionAlt", "Region alternative information", ""),
            State = new AddressElement("state", "State", ""),
            StateAbbreviation = new AddressElement("stateAbbreviation", "State abbreviation", ""),
            County = new AddressElement("county", "County", ""),
            Town = new AddressElement("town", "Town", ""),

            LocalityL1 = new AddressElement("localityL1", "Locality L1", ""),
            LocalityL2 = new AddressElement("localityL2", "Locality L2", ""),
            LocalityL3 = new AddressElement("localityL3", "Locality L3", ""),
        };

        protected static readonly CommonPostalCode PostalCode = new CommonPostalCode
        {
            Postcode = new AddressElement("postcode", "Postcode", ""),
            PostcodeAlt1 = new AddressElement("postcodeAlt1", "Postcode alternative information 1", ""),
            PostcodeAlt2 = new AddressElement("postcodeAlt2", "Postcode alternative information 2", ""),
        };

        protected static readonly CommonCountry Country = new CommonCountry
        {
            Country = new AddressElement("country", "Country", ""),
            CountryCode = new AddressElement("countryCode", "Country code", ""),
        };

        protected static readonly CommonPoBox PoBox = new CommonPoBox
        {
            PoBox = new AddressElement("poBox", "PO Box / Delivery service full 1", ""),
            Type = new AddressElement("poBoxType", "PO Box type", ""),
            Number = new AddressElement("poBoxNumber", "", ""),
        };
    }

    public class CommonOrganization
    {
        public AddressElement CompanyName { get; set; }
        public AddressElement Department { get; set; }
    }

    // Represents a building with various subcomponents
    public class CommonBuilding
    {
        public AddressElement StreetNumber { get; set; }
        public AddressElement BuildingLevel { get; set; }
        public CommonSubbuilding Subbuilding { get; set; }
        public AddressElement BuildingName { get; internal set; }
    }

    // Represents a subbuilding with detailed attributes
    public class CommonSubbuilding
    {
        public AddressElement Extension { get; set; }
        public AddressElement ExtensionAlt { get; set; }
        public AddressElement ExtensionAltName { get; set; }
        public AddressElement ExtensionNumber { get; set; }
        public AddressElement SubBuildingType { get; set; }
        public AddressElement SubBuildingNumber { get; set; }
    }

    // Represents a PO Box with its attributes
    public class CommonPoBox
    {
        public AddressElement PoBox { get; set; }
        public AddressElement Type { get; set; }
        public AddressElement Number { get; set; }
    }

    // Represents a street with primary and secondary attributes
    public class CommonStreet
    {
        public AddressElement Street { get; set; }
        public AddressElement PreDirectional { get; set; }
        public AddressElement Name { get; set; }
        public AddressElement Type { get; set; }
        public AddressElement PostDirectional { get; set; }
        public CommonStreet SecondaryStreet { get; set; }
    }

    // Represents a locality with various regional attributes
    public class CommonLocality
    {
        public AddressElement Region { get; set; }
        public AddressElement RegionAlt { get; set; }
        public AddressElement State { get; set; }
        public AddressElement StateAbbreviation { get; set; }
        public AddressElement County { get; set; }
        public AddressElement Town { get; set; }
        public AddressElement LocalityL1 { get; set; }
        public AddressElement LocalityL2 { get; set; }
        public AddressElement LocalityL3 { get; set; }
    }

    // Represents a postal code with alternative information
    public class CommonPostalCode
    {
        public AddressElement Postcode { get; set; }
        public AddressElement PostcodeAlt1 { get; set; }
        public AddressElement PostcodeAlt2 { get; set; }
    }

    // Represents a country with its name and code
    public class CommonCountry
    {
        public AddressElement Country { get; set; }
        public AddressElement CountryCode { get; set; }
    }

}