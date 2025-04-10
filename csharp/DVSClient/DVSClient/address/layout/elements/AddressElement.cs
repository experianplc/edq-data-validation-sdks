using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    public class AddressElement : IAddressElement
    {
        private string elementName { get; set; }
        private string description { get; set; }
        private string example { get; set; }

        public AddressElement(string elementName, string description, string example)
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