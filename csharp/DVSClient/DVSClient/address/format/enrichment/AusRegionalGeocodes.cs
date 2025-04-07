using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class AusRegionalGeocodes
    {
        public double? Latitude { get; }
        public double? Longitude { get; }
        public GeocodeMatchLevel? MatchLevel { get; }
        public string Sa1 { get; }
        public string Meshblock { get; }
        public string LgaCode { get; }
        public string LgaName { get; }
        public string StreetPid { get; }
        public string LocalityPid { get; }
        public string GeocodeLevelCode { get; }
        public string GeocodeLevelDescription { get; }
        public string GeocodeTypeCode { get; }
        public string GeocodeTypeDescription { get; }
        public double? HighestLevelLongitude { get; }
        public double? HighestLevelLatitude { get; }
        public string HighestLevelElevation { get; }
        public string HighestLevelPlanimetricAccuracy { get; }
        public string HighestLevelBoundaryExtent { get; }
        public string HighestLevelGeocodeReliabilityCode { get; }
        public string HighestLevelGeocodeReliabilityDescription { get; }
        public string ConfidenceLevelCode { get; }
        public string ConfidenceLevelDescription { get; }
        public string MeshblockId2021 { get; }
        public string MeshblockCode2021 { get; }
        public string MeshblockMatchCode2021 { get; }
        public string MeshblockMatchDescription2021 { get; }
        public string MeshblockId2016 { get; }
        public string MeshblockCode2016 { get; }
        public string MeshblockMatchCode2016 { get; }
        public string MeshblockMatchDescription2016 { get; }
        public string AddressTypeCode { get; }
        public string PrimaryAddressPid { get; }
        public string AddressJoinType { get; }
        public string CollectorDistrictId { get; }
        public string CollectorDistrictCode { get; }
        public string CommonwealthElectoralBoundaryId { get; }
        public string CommonwealthElectoralBoundaryName { get; }
        public string StatisticalLocalAreaId { get; }
        public string StatisticalLocalAreaCode { get; }
        public string StatisticalLocalAreaName { get; }
        public string StateElectoralBoundaryId { get; }
        public string StateElectoralBoundaryName { get; }
        public string StateElectoralEffectiveStart { get; }
        public string StateElectoralEffectiveEnd { get; }
        public string StateElectoralNewPid { get; }
        public string StateElectoralNewName { get; }
        public string StateElectoralNewEffectiveStart { get; }
        public string StateElectoralNewEffectiveEnd { get; }
        public double? AddressLevelLongitude { get; }
        public double? AddressLevelLatitude { get; }
        public string AddressLevelElevation { get; }
        public string AddressLevelPlanimetricAccuracy { get; }
        public string AddressLevelBoundaryExtent { get; }
        public string AddressLevelGeocodeReliabilityCode { get; }
        public string AddressLevelGeocodeReliabilityDescription { get; }
        public double? StreetLevelLongitude { get; }
        public double? StreetLevelLatitude { get; }
        public string StreetLevelPlanimetricAccuracy { get; }
        public string StreetLevelBoundaryExtent { get; }
        public string StreetLevelGeocodeReliabilityCode { get; }
        public string StreetLevelGeocodeReliabilityDescription { get; }
        public double? LocalityLevelLongitude { get; }
        public double? LocalityLevelLatitude { get; }
        public string LocalityLevelPlanimetricAccuracy { get; }
        public string LocalityLevelGeocodeReliabilityCode { get; }
        public string LocalityLevelGeocodeReliabilityDescription { get; }
        public string GnafLegalParcelIdentifier { get; }
        public string LocalityClassCode { get; }

        public AusRegionalGeocodes(RestApiEnrichmentAusRegionalGeocodes apiGeocodes)
        {
            Latitude = apiGeocodes.Latitude;
            Longitude = apiGeocodes.Longitude;
            MatchLevel = apiGeocodes.MatchLevel?.GetEnumValueFromJsonName<GeocodeMatchLevel>();
            Sa1 = apiGeocodes.Sa1 ?? string.Empty;
            Meshblock = apiGeocodes.Meshblock ?? string.Empty;
            LgaCode = apiGeocodes.LgaCode ?? string.Empty;
            LgaName = apiGeocodes.LgaName ?? string.Empty;
            StreetPid = apiGeocodes.StreetPid ?? string.Empty;
            LocalityPid = apiGeocodes.LocalityPid ?? string.Empty;
            GeocodeLevelCode = apiGeocodes.GeocodeLevelCode ?? string.Empty;
            GeocodeLevelDescription = apiGeocodes.GeocodeLevelDescription ?? string.Empty;
            GeocodeTypeCode = apiGeocodes.GeocodeTypeCode ?? string.Empty;
            GeocodeTypeDescription = apiGeocodes.GeocodeTypeDescription ?? string.Empty;
            HighestLevelLongitude = apiGeocodes.HighestLevelLongitude;
            HighestLevelLatitude = apiGeocodes.HighestLevelLatitude;
            HighestLevelElevation = apiGeocodes.HighestLevelElevation ?? string.Empty;
            HighestLevelPlanimetricAccuracy = apiGeocodes.HighestLevelPlanimetricAccuracy ?? string.Empty;
            HighestLevelBoundaryExtent = apiGeocodes.HighestLevelBoundaryExtent ?? string.Empty;
            HighestLevelGeocodeReliabilityCode = apiGeocodes.HighestLevelGeocodeReliabilityCode ?? string.Empty;
            HighestLevelGeocodeReliabilityDescription = apiGeocodes.HighestLevelGeocodeReliabilityDescription ?? string.Empty;
            ConfidenceLevelCode = apiGeocodes.ConfidenceLevelCode ?? string.Empty;
            ConfidenceLevelDescription = apiGeocodes.ConfidenceLevelDescription ?? string.Empty;
            MeshblockId2021 = apiGeocodes.MeshblockId2021 ?? string.Empty;
            MeshblockCode2021 = apiGeocodes.MeshblockCode2021 ?? string.Empty;
            MeshblockMatchCode2021 = apiGeocodes.MeshblockMatchCode2021 ?? string.Empty;
            MeshblockMatchDescription2021 = apiGeocodes.MeshblockMatchDescription2021 ?? string.Empty;
            MeshblockId2016 = apiGeocodes.MeshblockId2016 ?? string.Empty;
            MeshblockCode2016 = apiGeocodes.MeshblockCode2016 ?? string.Empty;
            MeshblockMatchCode2016 = apiGeocodes.MeshblockMatchCode2016 ?? string.Empty;
            MeshblockMatchDescription2016 = apiGeocodes.MeshblockMatchDescription2016 ?? string.Empty;
            AddressTypeCode = apiGeocodes.AddressTypeCode ?? string.Empty;
            PrimaryAddressPid = apiGeocodes.PrimaryAddressPid ?? string.Empty;
            AddressJoinType = apiGeocodes.AddressJoinType ?? string.Empty;
            CollectorDistrictId = apiGeocodes.CollectorDistrictId ?? string.Empty;
            CollectorDistrictCode = apiGeocodes.CollectorDistrictCode ?? string.Empty;
            CommonwealthElectoralBoundaryId = apiGeocodes.CommonwealthElectoralBoundaryId ?? string.Empty;
            CommonwealthElectoralBoundaryName = apiGeocodes.CommonwealthElectoralBoundaryName ?? string.Empty;
            StatisticalLocalAreaId = apiGeocodes.StatisticalLocalAreaId ?? string.Empty;
            StatisticalLocalAreaCode = apiGeocodes.StatisticalLocalAreaCode ?? string.Empty;
            StatisticalLocalAreaName = apiGeocodes.StatisticalLocalAreaName ?? string.Empty;
            StateElectoralBoundaryId = apiGeocodes.StateElectoralBoundaryId ?? string.Empty;
            StateElectoralBoundaryName = apiGeocodes.StateElectoralBoundaryName ?? string.Empty;
            StateElectoralEffectiveStart = apiGeocodes.StateElectoralEffectiveStart ?? string.Empty;
            StateElectoralEffectiveEnd = apiGeocodes.StateElectoralEffectiveEnd ?? string.Empty;
            StateElectoralNewPid = apiGeocodes.StateElectoralNewPid ?? string.Empty;
            StateElectoralNewName = apiGeocodes.StateElectoralNewName ?? string.Empty;
            StateElectoralNewEffectiveStart = apiGeocodes.StateElectoralNewEffectiveStart ?? string.Empty;
            StateElectoralNewEffectiveEnd = apiGeocodes.StateElectoralNewEffectiveEnd ?? string.Empty;
            AddressLevelLongitude = apiGeocodes.AddressLevelLongitude;
            AddressLevelLatitude = apiGeocodes.AddressLevelLatitude;
            AddressLevelElevation = apiGeocodes.AddressLevelElevation ?? string.Empty;
            AddressLevelPlanimetricAccuracy = apiGeocodes.AddressLevelPlanimetricAccuracy ?? string.Empty;
            AddressLevelBoundaryExtent = apiGeocodes.AddressLevelBoundaryExtent ?? string.Empty;
            AddressLevelGeocodeReliabilityCode = apiGeocodes.AddressLevelGeocodeReliabilityCode ?? string.Empty;
            AddressLevelGeocodeReliabilityDescription = apiGeocodes.AddressLevelGeocodeReliabilityDescription ?? string.Empty;
            StreetLevelLongitude = apiGeocodes.StreetLevelLongitude;
            StreetLevelLatitude = apiGeocodes.StreetLevelLatitude;
            StreetLevelPlanimetricAccuracy = apiGeocodes.StreetLevelPlanimetricAccuracy ?? string.Empty;
            StreetLevelBoundaryExtent = apiGeocodes.StreetLevelBoundaryExtent ?? string.Empty;
            StreetLevelGeocodeReliabilityCode = apiGeocodes.StreetLevelGeocodeReliabilityCode ?? string.Empty;
            StreetLevelGeocodeReliabilityDescription = apiGeocodes.StreetLevelGeocodeReliabilityDescription ?? string.Empty;
            LocalityLevelLongitude = apiGeocodes.LocalityLevelLongitude;
            LocalityLevelLatitude = apiGeocodes.LocalityLevelLatitude;
            LocalityLevelPlanimetricAccuracy = apiGeocodes.LocalityLevelPlanimetricAccuracy ?? string.Empty;
            LocalityLevelGeocodeReliabilityCode = apiGeocodes.LocalityLevelGeocodeReliabilityCode ?? string.Empty;
            LocalityLevelGeocodeReliabilityDescription = apiGeocodes.LocalityLevelGeocodeReliabilityDescription ?? string.Empty;
            GnafLegalParcelIdentifier = apiGeocodes.GnafLegalParcelIdentifier ?? string.Empty;
            LocalityClassCode = apiGeocodes.LocalityClassCode ?? string.Empty;
        }
    }
}