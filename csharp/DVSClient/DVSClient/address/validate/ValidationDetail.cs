using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Validate
{
    public class ValidationDetail
    {
        public bool BuildingFirmNameCorrected { get; }
        public bool PrimaryNumberCorrected { get; }
        public bool StreetCorrected { get; }
        public bool RuralRouteHighwayContractMatched { get; }
        public bool CityNameCorrected { get; }
        public bool CityNameAliasMatched { get; }
        public bool StateCorrected { get; }
        public bool ZipCodeCorrected { get; }
        public bool SecondaryNumRetained { get; }
        public bool IdenPreStInfoRetained { get; }
        public bool GenPreStInfoRetained { get; }
        public bool PostStInfoRetained { get; }

        public ValidationDetail(RestApiValidationDetail api)
        {
            BuildingFirmNameCorrected = api.BuildingFirmNameCorrected ?? false;
            PrimaryNumberCorrected = api.PrimaryNumberCorrected ?? false;
            StreetCorrected = api.StreetCorrected ?? false;
            RuralRouteHighwayContractMatched = api.RuralRouteHighwayContractMatched ?? false;
            CityNameCorrected = api.CityNameCorrected ?? false;
            CityNameAliasMatched = api.CityNameAliasMatched ?? false;
            StateCorrected = api.StateCorrected ?? false;
            ZipCodeCorrected = api.ZipCodeCorrected ?? false;
            SecondaryNumRetained = api.SecondaryNumRetained ?? false;
            IdenPreStInfoRetained = api.IdenPreStInfoRetained ?? false;
            GenPreStInfoRetained = api.GenPreStInfoRetained ?? false;
            PostStInfoRetained = api.PostStInfoRetained ?? false;
        }
    }
}