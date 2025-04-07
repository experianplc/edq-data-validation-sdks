namespace DVSClient.Address.Format.Components
{
    public class PostalCode
    {
        public string? FullName { get; }
        public string? Primary { get; }
        public string? Secondary { get; }

        public PostalCode(string? fullName, string? primary, string? secondary)
        {
            FullName = fullName;
            Primary = primary;
            Secondary = secondary;
        }
    }
}