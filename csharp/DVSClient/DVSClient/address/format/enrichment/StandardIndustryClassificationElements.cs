using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class StandardIndustryClassificationElements
    {
        public string Sic2007Code { get; }
        public string Sic2007Description { get; }
        public string ThomsonCode { get; }
        public string ThomsonDescription { get; }

        public StandardIndustryClassificationElements(RestApiStandardIndustryClassificationElements api)
        {
            Sic2007Code = api.Sic2007Code ?? string.Empty;
            Sic2007Description = api.Sic2007Description ?? string.Empty;
            ThomsonCode = api.ThomsonCode ?? string.Empty;
            ThomsonDescription = api.ThomsonDescription ?? string.Empty;
        }
    }
}