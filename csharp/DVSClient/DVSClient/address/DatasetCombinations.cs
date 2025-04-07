namespace DVSClient.Address
{
    public static class DatasetCombinations
    {
        private static readonly IDictionary<SearchType, IEnumerable<IEnumerable<Dataset>>> CombinationsDetails =
            new Dictionary<SearchType, IEnumerable<IEnumerable<Dataset>>>
            {
                {
                    SearchType.Autocomplete,
                    new List<IEnumerable<Dataset>>
                    {
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalBusiness },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalElectricity },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalGas },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAddress, Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas },
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalGas, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalGas, Dataset.GbAdditionalBusiness },
                        new List<Dataset> { Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalBusiness },
                        new List<Dataset> { Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalGas, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalBusiness },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalBusiness },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas, Dataset.GbAdditionalBusiness },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalBusiness },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalElectricity, Dataset.GbAdditionalGas, Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence }
                    }
                },
                {
                    SearchType.Singleline,
                    new List<IEnumerable<Dataset>>
                    {
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNames, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalNames }
                    }
                },
                {
                    SearchType.Typedown,
                    new List<IEnumerable<Dataset>>
                    {
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalBusiness, Dataset.GbAdditionalNames, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalNames },
                        new List<Dataset> { Dataset.GbAdditionalNotyetbuilt, Dataset.GbAdditionalNames },
                    }
                },
                {
                    SearchType.Validate,
                    new List<IEnumerable<Dataset>>
                    {
                        new List<Dataset> { Dataset.GbAdditionalMultipleresidence, Dataset.GbAdditionalNotyetbuilt },
                    }
                }
            };

        public static IEnumerable<IEnumerable<Dataset>> FromSearchType(this SearchType searchType)
        {
            return CombinationsDetails[searchType];
        }
    }
}