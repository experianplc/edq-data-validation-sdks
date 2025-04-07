using DVSClient.Common;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class GetLayoutResult
    {
        public ResponseError? Error { get; }
        public GetLayoutLayout? Layout { get; }

        public GetLayoutResult(RestApiGetLayoutResponse response)
        {
            Error = response.Error != null ? new ResponseError(response.Error) : null;
            var result = response.Result;
            Layout = result != null ? new GetLayoutLayout(result?.Layout) : null;
        }
    }
}