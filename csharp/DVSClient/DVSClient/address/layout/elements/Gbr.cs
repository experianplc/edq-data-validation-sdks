using System;
using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    internal class Gbr : CommonElements, IAddressElement
    {
        public static new AddressElement Empty => CommonElements.Empty;
        public static new CommonBuilding Building => CommonElements.Building;
        public static new CommonStreet Street => CommonElements.Street;
        public static new CommonLocality Locality => CommonElements.Locality;
        public static new CommonCountry Country => CommonElements.Country;
        public static new CommonPostalCode PostalCode => CommonElements.PostalCode;
        public static new CommonPoBox PoBox => CommonElements.PoBox;

        public static Gbr Retained = new Gbr("retained", "Retained", "");
        public static new GbrOrganization Organization = new GbrOrganization
        {
            DifferentCompanyName = new AddressElement("companyName", "Company/organization name assigned", ""),
        };

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


    public class GbrOrganization : CommonOrganization
    {
        public AddressElement DifferentCompanyName { get; set; }
    }
}