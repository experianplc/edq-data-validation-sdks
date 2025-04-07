using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class GbrGovernment
    {
        public string EerCode { get; }
        public string EerCodePre2011 { get; }
        public string EerName { get; }
        public string GorCode { get; }
        public string GorCodePre2011 { get; }
        public string GorName { get; }
        public string LeaCode { get; }
        public string LeaName { get; }
        public string LaCode { get; }
        public string LaCodePre2011 { get; }
        public string LaName { get; }
        public string WardCode { get; }
        public string WardCodePre2011 { get; }
        public string WardName { get; }
        public string CensOutArea { get; }

        public GbrGovernment(RestApiEnrichmentGbrGovernment api)
        {
            EerCode = api.EerCode ?? string.Empty;
            EerCodePre2011 = api.EerCodePre2011 ?? string.Empty;
            EerName = api.EerName ?? string.Empty;
            GorCode = api.GorCode ?? string.Empty;
            GorCodePre2011 = api.GorCodePre2011 ?? string.Empty;
            GorName = api.GorName ?? string.Empty;
            LeaCode = api.LeaCode ?? string.Empty;
            LeaName = api.LeaName ?? string.Empty;
            LaCode = api.LaCode ?? string.Empty;
            LaCodePre2011 = api.LaCodePre2011 ?? string.Empty;
            LaName = api.LaName ?? string.Empty;
            WardCode = api.WardCode ?? string.Empty;
            WardCodePre2011 = api.WardCodePre2011 ?? string.Empty;
            WardName = api.WardName ?? string.Empty;
            CensOutArea = api.CensOutArea ?? string.Empty;
        }
    }
}