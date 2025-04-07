namespace DVSClient.Address.Format.Components
{
    public class LocalityItem
    {
        public string? Name { get; }
        public string? Code { get; }
        public string? Description { get; }

        public LocalityItem(string? name, string? code, string? description)
        {
            Name = name;
            Code = code;
            Description = description;
        }
    }
}