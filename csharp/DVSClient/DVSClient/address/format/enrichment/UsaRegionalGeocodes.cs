using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class UsaRegionalGeocodes
    {
        public double? Latitude { get; }
        public double? Longitude { get; }
        public GeocodeMatchLevel? MatchLevel { get; }
        public string CensusTract { get; }
        public string CensusBlock { get; }
        public string CoreBasedStatisticalArea { get; }
        public string CongressionalDistrictCode { get; }
        public string CountyCode { get; }

        public UsaRegionalGeocodes(RestApiEnrichmentUsaRegionalGeocodes geocodes)
        {
            Latitude = geocodes.Latitude;
            Longitude = geocodes.Longitude;
            MatchLevel = geocodes.MatchLevel?.GetEnumValueFromJsonName<GeocodeMatchLevel>();
            CensusTract = geocodes.CensusTract ?? string.Empty;
            CensusBlock = geocodes.CensusBlock ?? string.Empty;
            CoreBasedStatisticalArea = geocodes.CoreBasedStatisticalArea ?? string.Empty;
            CongressionalDistrictCode = geocodes.CongressionalDistrictCode ?? string.Empty;
            CountyCode = geocodes.CountyCode ?? string.Empty;
        }
    }
}