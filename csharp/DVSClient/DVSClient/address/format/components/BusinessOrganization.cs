namespace DVSClient.Address.Format.Components
{
    public class BusinessOrganization
    {
        public string? CompanyName { get; }

        public BusinessOrganization(string? companyName)
        {
            CompanyName = companyName;
        }
    }
}