using DVSClient.Common;
using DVSClient.Server.Address.Datasets;

namespace DVSClient.Address.Datasets
{
    public class GetDatasetsResult
    {
        public ResponseError? Error { get; }
        public IEnumerable<AddressDataset>? Result { get; }

        public GetDatasetsResult(RestApiGetDatasetsResponse response)
        {
            Error = response.Error != null ? new ResponseError(response.Error) : null;
            Result = response.Result != null ? response.Result.Select(r => new AddressDataset(r)).ToList() : null;
        }
    }
}