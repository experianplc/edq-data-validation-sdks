using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Components
{
    public class Locality
    {
        public LocalityItem? Region { get; }
        public LocalityItem? SubRegion { get; }
        public LocalityItem? Town { get; }
        public LocalityItem? District { get; }
        public LocalityItem? SubDistrict { get; }

        public Locality(RestApiAddressFormatComponents.RestApiAddressComponentLocality api)
        {
            Region = api.Region != null ? new LocalityItem(api.Region.Name, api.Region.Code, api.Region.Description) : null;
            SubRegion = api.SubRegion != null ? new LocalityItem(api.SubRegion.Name, api.SubRegion.Code, api.SubRegion.Description) : null;
            Town = api.Town != null ? new LocalityItem(api.Town.Name, api.Town.Code, api.Town.Description) : null;
            District = api.District != null ? new LocalityItem(api.District.Name, api.District.Code, api.District.Description) : null;
            SubDistrict = api.SubDistrict != null ? new LocalityItem(api.SubDistrict.Name, api.SubDistrict.Code, api.SubDistrict.Description) : null;
        }
    }
}