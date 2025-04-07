using DVSClient.Common;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class CreateLayoutResult
    {
        public ResponseError? Error { get; }
        public string Id { get; }

        public CreateLayoutResult(RestApiCreateLayoutResponse response)
        {
            Error = response.Error != null ? new ResponseError(response.Error) : null;
            Id = response.Result?.Id ?? string.Empty;
        }
    }
}