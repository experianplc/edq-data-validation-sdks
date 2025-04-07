using DVSClient.Address.Format.Components;
using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class AddressComponents
    {
        public string? Language { get; }
        public Country? Country { get; }
        public PostalCode? PostalCode { get; }
        public DeliveryService? DeliveryService { get; }
        public DeliveryService? SecondaryDeliveryService { get; }
        public SubBuilding? SubBuilding { get; }
        public ComponentBuilding? Building { get; }
        public Organization? Organization { get; }
        public Street? Street { get; }
        public Street? SecondaryStreet { get; }
        public RouteService? RouteService { get; }
        public Locality? Locality { get; }
        public Locality? PhysicalLocality { get; }
        public AdditionalElements? AdditionalElements { get; }

        public AddressComponents(RestApiAddressFormatComponents api)
        {
            Language = api.Language ?? string.Empty;
            Country = api.CountryIso3 != null ? Country.FromIso3(api.CountryIso3) : null;
            PostalCode = api.PostalCode != null ? new PostalCode(api.PostalCode.FullName, api.PostalCode.Primary, api.PostalCode.Secondary) : null;
            DeliveryService = api.DeliveryService != null ? new DeliveryService(api.DeliveryService.FullName, api.DeliveryService.ServiceType, api.DeliveryService.ServiceNumber, api.DeliveryService.PostCentreName) : null;
            SecondaryDeliveryService = api.SecondaryDeliveryService != null ? new DeliveryService(api.SecondaryDeliveryService.FullName, api.SecondaryDeliveryService.ServiceType, api.SecondaryDeliveryService.ServiceNumber, api.SecondaryDeliveryService.PostCentreName) : null;
            SubBuilding = api.SubBuilding != null ? new SubBuilding(api.SubBuilding) : null;
            Building = api.Building != null ? new ComponentBuilding(api.Building.BuildingName, api.Building.SecondaryName, api.Building.BuildingNumber, api.Building.SecondaryNumber, api.Building.AllotmentNumber) : null;
            Organization = api.Organization != null ? new Organization(api.Organization) : null;
            Street = api.Street != null ? new Street(api.Street.FullName, api.Street.Prefix, api.Street.Name, api.Street.Type, api.Street.Suffix) : null;
            SecondaryStreet = api.SecondaryStreet != null ? new Street(api.SecondaryStreet.FullName, api.SecondaryStreet.Prefix, api.SecondaryStreet.Name, api.SecondaryStreet.Type, api.SecondaryStreet.Suffix) : null;
            RouteService = api.RouteService != null ? new RouteService(api.RouteService.FullName, api.RouteService.ServiceType, api.RouteService.ServiceNumber, api.RouteService.DeliveryName, api.RouteService.Qualifier) : null;
            Locality = api.Locality != null ? new Locality(api.Locality) : null;
            PhysicalLocality = api.PhysicalLocality != null ? new Locality(api.PhysicalLocality) : null;
            AdditionalElements = api.AdditionalElements != null ? new AdditionalElements(api.AdditionalElements) : null;
        }
    }
}