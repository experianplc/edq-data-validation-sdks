using DVSClient.Address.Layout.Elements;

namespace DVSClient.Address.Layout
{
    public interface ILayoutLine
    {
        public string Name { get; set; }
        public int? MaxWidth { get; set; }

        IEnumerable<IAddressElement?> GetElements();
    }
}