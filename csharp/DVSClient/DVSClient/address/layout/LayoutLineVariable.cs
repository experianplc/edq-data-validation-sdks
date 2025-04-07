using DVSClient.Address.Layout.Elements;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class LayoutLineVariable : ILayoutLine
    {
        public string Name { get; set; }
        public int? MaxWidth { get; set; }

        public LayoutLineVariable(string name)
        {
            Name = name;
        }

        public LayoutLineVariable(RestApiAddressLayoutLine line)
        {
            Name = line.LineName ?? string.Empty;
            MaxWidth = line.MaxWidth;
        }

        public IEnumerable<IAddressElement?> GetElements()
        {
            return new List<IAddressElement?>();
        }
    }
}