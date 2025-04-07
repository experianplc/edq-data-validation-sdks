using DVSClient.Common;
using DVSClient.Server.Address.Datasets;

namespace DVSClient.Address.Datasets
{
    public class AddressDataset
    {
        public Country? Country { get; }
        public IEnumerable<Dataset> Datasets { get; }
        public IEnumerable<List<Dataset>> ValidCombinations { get; }

        public AddressDataset(RestApiAddressDatasetResult result)
        {
            Country = !string.IsNullOrEmpty(result.CountryIso3) ? Country.FromIso3(result.CountryIso3) : null;
            Datasets = result.Datasets != null && result.Datasets.Any() ? result.Datasets.Select(p => Dataset.FromCode(p.Id)).ToList() : new List<Dataset>();
            ValidCombinations = result.ValidCombinations != null && result.ValidCombinations.Any() ? result.ValidCombinations.Select(p => p.Select(Dataset.FromCode).ToList()).ToList() : new List<List<Dataset>>();
        }
    }
}