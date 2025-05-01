namespace DVSClient.Address.Layout.Elements
{
    public interface IAddressElement
    {
        string GetElementName();

        public static IAddressElement? FromElementName(IEnumerable<AppliesTo> appliesTo, string? elementName)
        {
            return AddressElementLibrary.GetAddressElementFromElementName(appliesTo, elementName);
        }
    }
}