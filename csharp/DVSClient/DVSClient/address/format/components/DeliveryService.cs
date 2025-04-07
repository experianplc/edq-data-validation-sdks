namespace DVSClient.Address.Format.Components
{
    public class DeliveryService
    {
        public string? FullName { get; }
        public string? ServiceType { get; }
        public string? ServiceNumber { get; }
        public string? PostCentreName { get; }

        public DeliveryService(string? fullName, string? serviceType, string? serviceNumber, string? postCentreName)
        {
            FullName = fullName;
            ServiceType = serviceType;
            ServiceNumber = serviceNumber;
            PostCentreName = postCentreName;
        }
    }
}