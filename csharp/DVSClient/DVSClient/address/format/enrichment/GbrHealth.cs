using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class GbrHealth
    {
        public string AuthorityCode { get; }
        public string AuthorityCode2011 { get; }
        public string AuthorityName { get; }
        public string PclhCode { get; }
        public string PclhCode2011 { get; }
        public string PclhName { get; }
        public string WardCode { get; }
        public string WardCode2011 { get; }
        public string WardName { get; }
        public string CcgCode { get; }
        public string CcgName { get; }
        public string DohCode { get; }

        public GbrHealth(RestApiEnrichmentGbrHealth api)
        {
            AuthorityCode = api.AuthorityCode ?? string.Empty;
            AuthorityCode2011 = api.AuthorityCode2011 ?? string.Empty;
            AuthorityName = api.AuthorityName ?? string.Empty;
            PclhCode = api.PclhCode ?? string.Empty;
            PclhCode2011 = api.PclhCode2011 ?? string.Empty;
            PclhName = api.PclhName ?? string.Empty;
            WardCode = api.WardCode ?? string.Empty;
            WardCode2011 = api.WardCode2011 ?? string.Empty;
            WardName = api.WardName ?? string.Empty;
            CcgCode = api.CcgCode ?? string.Empty;
            CcgName = api.CcgName ?? string.Empty;
            DohCode = api.DohCode ?? string.Empty;
        }
    }
}