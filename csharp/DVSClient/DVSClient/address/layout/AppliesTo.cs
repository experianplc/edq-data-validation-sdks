using DVSClient.Common;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class AppliesTo
    {
        public IEnumerable<Dataset> Datasets { get; set; }
        public string? Language { get; set; }
        public string? Script { get; set; }

        public AppliesTo(Dataset dataset)
            : this(new List<Dataset> { dataset }, null, null)
        {
        }

        public AppliesTo(List<Dataset> datasets)
            : this(datasets, null, null)
        {
        }

        public AppliesTo(RestApiAddressLayoutAppliesTo appliesTo)
        {
            Datasets = appliesTo.Datasets != null ? appliesTo.Datasets.Select(Dataset.FromCode).ToList() : new List<Dataset>();
            Language = appliesTo.Language ?? string.Empty;
            Script = appliesTo.Script ?? string.Empty;
        }

        public AppliesTo(IEnumerable<Dataset> datasets, string? language, string? script)
        {
            Datasets = datasets;
            Language = language;
            Script = script;
        }

        public Country? GetCountry()
        {
            return Datasets != null && Datasets.Any() ? Datasets.ElementAt(0).Country : null;
        }
    }
}