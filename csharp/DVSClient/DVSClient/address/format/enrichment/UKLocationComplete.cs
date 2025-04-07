using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class UKLocationComplete
    {
        public double? Latitude { get; }
        public double? Longitude { get; }
        public GeocodeMatchLevel? MatchLevel { get; }
        public string Udprn { get; }
        public string Uprn { get; }
        public double? XCoordinate { get; }
        public double? YCoordinate { get; }

        public UKLocationComplete(RestApiEnrichmentUKLocationComplete api)
        {
            Latitude = api.Latitude;
            Longitude = api.Longitude;
            MatchLevel = api.MatchLevel?.GetEnumValueFromJsonName<GeocodeMatchLevel>();
            Udprn = api.Udprn ?? string.Empty;
            Uprn = api.Uprn ?? string.Empty;
            XCoordinate = api.XCoordinate;
            YCoordinate = api.YCoordinate;
        }
    }
}