using DVSClient.Address.Layout.Elements;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class LayoutLineFixed : ILayoutLine
    {
        public string Name { get; set; }
        public int? MaxWidth { get; set; }
        public IEnumerable<IAddressElement?> Elements { get; set; }

        public LayoutLineFixed(string name, IAddressElement? element)
            : this(name, new List<IAddressElement?> { element })
        {
        }

        public LayoutLineFixed(string name, List<IAddressElement?> elements)
        {
            Name = name;
            Elements = elements;
        }

        public LayoutLineFixed(IEnumerable<AppliesTo> appliesTo, RestApiAddressLayoutLine line)
        {
            Name = line.LineName ?? string.Empty;
            MaxWidth = line.MaxWidth;
            Elements = line.Elements != null ? GetAddressElements(appliesTo, line.Elements) : new List<IAddressElement?>();
        }

        private IEnumerable<IAddressElement?> GetAddressElements(IEnumerable<AppliesTo> appliesTo, IEnumerable<RestApiAddressLayoutLineElement> elements)
        {
            return elements.Select(element => GetAddressElement(appliesTo, element)).ToList();
        }

        private IAddressElement? GetAddressElement(IEnumerable<AppliesTo> appliesTo, RestApiAddressLayoutLineElement element)
        {
            return IAddressElement.FromElementName(appliesTo, element.ElementName);
        }

        public IEnumerable<IAddressElement?> GetElements()
        {
            return Elements;
        }
    }
}