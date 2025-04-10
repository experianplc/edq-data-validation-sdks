using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    public class Gbr : IAddressElement
    {
        public static readonly Gbr Empty = new Gbr("empty", "Empty line", "");
        public static readonly Gbr CompanyName = new Gbr("companyName", "Company/organisation name assigned", "");
        public static readonly Gbr Department = new Gbr("department", "Departments within an organisation that are postally addressable", "");
        public static readonly Gbr StreetNumber = new Gbr("streetNumber", "Street/Building number", "");
        public static readonly Gbr BuildingLevel = new Gbr("buildingLevel", "Building level", "");
        public static readonly Gbr BuildingGroup = new Gbr("buildingGroup", "Building group", "");
        public static readonly Gbr BuildingGroupName = new Gbr("buildingGroupName", "Building group name", "");
        public static readonly Gbr BuildingGroupDesc = new Gbr("buildingGroupDesc", "Building group description", "");
        public static readonly Gbr Extension = new Gbr("extension", "Building extension", "");
        public static readonly Gbr ExtensionAlt = new Gbr("extensionAlt", "Building extension alternative information", "");
        public static readonly Gbr ExtensionAltName = new Gbr("extensionAltName", "Building extension alternative name", "");
        public static readonly Gbr ExtensionNumber = new Gbr("extensionNumber", "Building extension number", "");
        public static readonly Gbr SubBuildingType = new Gbr("subBuildingType", "Sub building type", "");
        public static readonly Gbr SubBuildingNumber = new Gbr("subBuildingNumber", "Sub building number", "");
        public static readonly Gbr PoBox = new Gbr("poBox", "PO Box / Delivery service full 1", "");
        public static readonly Gbr PoBoxType = new Gbr("poBoxType", "PO Box type", "");
        public static readonly Gbr PoBoxNumber = new Gbr("poBoxNumber", "PO Box number", "");
        public static readonly Gbr Box = new Gbr("box", "Box", "");
        public static readonly Gbr BoxType = new Gbr("boxType", "Box type", "");
        public static readonly Gbr BoxNumber = new Gbr("boxNumber", "Box number", "");
        public static readonly Gbr StreetPrimary = new Gbr("streetPrimary", "Street primary", "");
        public static readonly Gbr StreetPreDirectionalPrimary = new Gbr("streetPreDirectionalPrimary", "Street pre directional primary", "");
        public static readonly Gbr StreetNamePrimary = new Gbr("streetNamePrimary", "Street name primary", "");
        public static readonly Gbr StreetTypePrimary = new Gbr("streetTypePrimary", "Street type primary", "");
        public static readonly Gbr StreetPostDirectionalPrimary = new Gbr("streetPostDirectionalPrimary", "Street post directional primary", "");
        public static readonly Gbr StreetSecondary = new Gbr("streetSecondary", "Street secondary", "");
        public static readonly Gbr StreetNameSecondary = new Gbr("streetNameSecondary", "Street name secondary", "");
        public static readonly Gbr StreetTypeSecondary = new Gbr("streetTypeSecondary", "Street type secondary", "");
        public static readonly Gbr Region = new Gbr("region", "Region", "");
        public static readonly Gbr RegionAlt = new Gbr("regionAlt", "Region alternative information", "");
        public static readonly Gbr State = new Gbr("state", "State", "");
        public static readonly Gbr StateAbbreviation = new Gbr("stateAbbreviation", "State abbreviation", "");
        public static readonly Gbr County = new Gbr("county", "County", "");
        public static readonly Gbr Town = new Gbr("town", "Town", "");
        public static readonly Gbr PreferredTown = new Gbr("preferredTown", "Preferred town name", "");
        public static readonly Gbr LocalityL1 = new Gbr("localityL1", "Locality L1", "");
        public static readonly Gbr LocalityL2 = new Gbr("localityL2", "Locality L2", "");
        public static readonly Gbr LocalityL3 = new Gbr("localityL3", "Locality L3", "");
        public static readonly Gbr Postcode = new Gbr("postcode", "Postcode", "");
        public static readonly Gbr PostcodeAlt1 = new Gbr("postcodeAlt1", "Postcode alternative information 1", "");
        public static readonly Gbr PostcodeAlt2 = new Gbr("postcodeAlt2", "Postcode alternative information 2", "");
        public static readonly Gbr Country = new Gbr("country", "Country", "");
        public static readonly Gbr CountryCode = new Gbr("countryCode", "Country code", "");
        public static readonly Gbr Retained = new Gbr("retained", "Retained", "");


        private string elementName { get; set; }
        private string description { get; set; }
        private string example { get; set; }

        public Gbr(string elementName, string description, string example)
        {
            this.elementName = elementName;
            this.description = description;
            this.example = example;
        }

        public static IAddressElement? GetElement(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Type addressElementType = typeof(Aus);
                FieldInfo? addressElementProperty = addressElementType.GetField(name);

                if (addressElementProperty != null)
                {
                    return (IAddressElement?)addressElementProperty.GetValue(name);
                }
            }

            return null;
        }

        public string GetElementName()
        {
            return elementName;
        }
    }
}