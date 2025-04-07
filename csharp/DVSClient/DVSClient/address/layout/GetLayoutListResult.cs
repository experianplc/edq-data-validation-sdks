using DVSClient.Common;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class GetLayoutListResult
    {
        public ResponseError? Error { get; }
        public IEnumerable<GetLayoutListItem> Layouts { get; }

        public GetLayoutListResult(RestApiGetLayoutListResponse response)
        {
            Error = response.Error != null ? new ResponseError(response.Error) :null;
            Layouts = response.Result != null ? response.Result.Select(item => new GetLayoutListItem(item)).ToList() : new List<GetLayoutListItem>();
        }
    }
}