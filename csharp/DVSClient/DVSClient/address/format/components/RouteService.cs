namespace DVSClient.Address.Format.Components
{
    public class RouteService
    {
        public string? FullName { get; }
        public string? ServiceType { get; }
        public string? ServiceNumber { get; }
        public string? DeliveryName { get; }
        public string? Qualifier { get; }

        public RouteService(string? fullName, string? serviceType, string? serviceNumber, string? deliveryName, string? qualifier)
        {
            FullName = fullName;
            ServiceType = serviceType;
            ServiceNumber = serviceNumber;
            DeliveryName = deliveryName;
            Qualifier = qualifier;
        }
    }
}