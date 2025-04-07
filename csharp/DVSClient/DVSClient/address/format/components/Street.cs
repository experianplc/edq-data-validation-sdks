namespace DVSClient.Address.Format.Components
{
    public class Street
    {
        public string? FullName { get; }
        public string? Prefix { get; }
        public string? Name { get; }
        public string? Type { get; }
        public string? Suffix { get; }

        public Street(string? fullName, string? prefix, string? name, string? type, string? suffix)
        {
            FullName = fullName;
            Prefix = prefix;
            Name = name;
            Type = type;
            Suffix = suffix;
        }
    }
}