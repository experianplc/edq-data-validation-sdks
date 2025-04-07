namespace DVSClient.Address.Format.Components
{
    public class ComponentBuilding
    {
        public string? BuildingName { get; }
        public string? SecondaryName { get; }
        public string? BuildingNumber { get; }
        public string? SecondaryNumber { get; }
        public string? AllotmentNumber { get; }

        public ComponentBuilding(string? buildingName, string? secondaryName, string? buildingNumber, string? secondaryNumber, string? allotmentNumber)
        {
            BuildingName = buildingName;
            SecondaryName = secondaryName;
            BuildingNumber = buildingNumber;
            SecondaryNumber = secondaryNumber;
            AllotmentNumber = allotmentNumber;
        }
    }
}