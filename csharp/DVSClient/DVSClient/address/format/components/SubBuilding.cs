using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Components
{
    public class SubBuilding
    {
        public string Name { get; }
        public SubBuildingItem? Entrance { get; }
        public SubBuildingItem? Floor { get; }
        public SubBuildingItem? Door { get; }

        public SubBuilding(RestApiAddressFormatComponents.RestApiAddressComponentSubBuilding api)
        {
            Name = api.Name ?? string.Empty;
            Entrance = api.Entrance != null ? new SubBuildingItem(api.Entrance.FullName, api.Entrance.Type, api.Entrance.Value) : null;
            Floor = api.Floor != null ? new SubBuildingItem(api.Floor.FullName, api.Floor.Type, api.Floor.Value) : null;
            Door = api.Door != null ? new SubBuildingItem(api.Door.FullName, api.Door.Type, api.Door.Value) : null;
        }
    }
}