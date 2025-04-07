namespace DVSClient.Address.Format.Components
{
    public class SubBuildingItem
    {
        public string? FullName { get; }
        public string? Type { get; }
        public string? Value { get; }

        public SubBuildingItem(string? fullName, string? type, string? value)
        {
            FullName = fullName;
            Type = type;
            Value = value;
        }
    }
}