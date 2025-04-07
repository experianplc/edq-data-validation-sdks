using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class Geocodes
    {
        public double? Latitude { get; }
        public double? Longitude { get; }
        public GeocodeMatchLevel? MatchLevel { get; }

        public Geocodes(RestApiEnrichmentDatasetGeocodes geocodes)
        {
            Latitude = geocodes.Latitude;
            Longitude = geocodes.Longitude;
            MatchLevel = geocodes.MatchLevel?.GetEnumValueFromJsonName<GeocodeMatchLevel>();
        }
    }
}