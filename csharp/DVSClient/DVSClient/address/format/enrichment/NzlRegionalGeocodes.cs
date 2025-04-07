using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class NzlRegionalGeocodes
    {
        public double? FrontOfPropertyNztmXCoordinate { get; }
        public double? FrontOfPropertyNztmYCoordinate { get; }
        public double? CentroidOfPropertyNztmXCoordinate { get; }
        public double? CentroidOfPropertyNztmYCoordinate { get; }
        public string LinzParcelId { get; }
        public string PropertyPurposeType { get; }
        public string Addressable { get; }
        public string MeshBlockCode { get; }
        public string TerritorialAuthorityCode { get; }
        public string TerritorialAuthorityName { get; }
        public string RegionalCouncilCode { get; }
        public string RegionalCouncilName { get; }
        public string GeneralElectorateCode { get; }
        public string GeneralElectorateName { get; }
        public string MaoriElectorateCode { get; }
        public string MaoriElectorateName { get; }
        public double? FrontOfPropertyLatitude { get; }
        public double? FrontOfPropertyLongitude { get; }
        public double? CentroidOfPropertyLatitude { get; }
        public double? CentroidOfPropertyLongitude { get; }
        public GeocodeMatchLevel? MatchLevel { get; }

        public NzlRegionalGeocodes(RestApiEnrichmentNzlRegionalGeocodes geocodes)
        {
            FrontOfPropertyNztmXCoordinate = geocodes.FrontOfPropertyNztmXCoordinate;
            FrontOfPropertyNztmYCoordinate = geocodes.FrontOfPropertyNztmYCoordinate;
            CentroidOfPropertyNztmXCoordinate = geocodes.CentroidOfPropertyNztmXCoordinate;
            CentroidOfPropertyNztmYCoordinate = geocodes.CentroidOfPropertyNztmYCoordinate;
            LinzParcelId = geocodes.LinzParcelId ?? string.Empty;
            PropertyPurposeType = geocodes.PropertyPurposeType ?? string.Empty;
            Addressable = geocodes.Addressable ?? string.Empty;
            MeshBlockCode = geocodes.MeshBlockCode ?? string.Empty;
            TerritorialAuthorityCode = geocodes.TerritorialAuthorityCode ?? string.Empty;
            TerritorialAuthorityName = geocodes.TerritorialAuthorityName ?? string.Empty;
            RegionalCouncilCode = geocodes.RegionalCouncilCode ?? string.Empty;
            RegionalCouncilName = geocodes.RegionalCouncilName ?? string.Empty;
            GeneralElectorateCode = geocodes.GeneralElectorateCode ?? string.Empty;
            GeneralElectorateName = geocodes.GeneralElectorateName ?? string.Empty;
            MaoriElectorateCode = geocodes.MaoriElectorateCode ?? string.Empty;
            MaoriElectorateName = geocodes.MaoriElectorateName ?? string.Empty;
            FrontOfPropertyLatitude = geocodes.FrontOfPropertyLatitude;
            FrontOfPropertyLongitude = geocodes.FrontOfPropertyLongitude;
            CentroidOfPropertyLatitude = geocodes.CentroidOfPropertyLatitude;
            CentroidOfPropertyLongitude = geocodes.CentroidOfPropertyLongitude;
            MatchLevel = geocodes.MatchLevel?.GetEnumValueFromJsonName<GeocodeMatchLevel>();
        }
    }
}