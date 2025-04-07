using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class GbrBusiness
    {
        public string? Urn { get; }
        public CommercialMosaicElements? CommercialMosaic { get; }
        public string? Registration { get; }
        public string? NonLimitedCompanyKey { get; }
        public string? Phone { get; }
        public string? NumberOfEmployees { get; }
        public StandardIndustryClassificationElements? StandardIndustryClassification { get; }
        public LocationElements? Location { get; }

        public GbrBusiness(RestApiEnrichmentGbAdditional api)
        {
            Urn = api.Urn ?? null;
            CommercialMosaic = api.CommercialMosaic != null ? new CommercialMosaicElements(api.CommercialMosaic) : null;
            Registration = api.Registration ?? null;
            NonLimitedCompanyKey = api.NonLimitedCompanyKey ?? null;
            Phone = api.Phone ?? null;
            NumberOfEmployees = api.NumberOfEmployees ?? null;
            StandardIndustryClassification = api.StandardIndustryClassification != null ? new StandardIndustryClassificationElements(api.StandardIndustryClassification) : null;
            Location = api.Location != null ? new LocationElements(api.Location) : null;
        }
    }
}