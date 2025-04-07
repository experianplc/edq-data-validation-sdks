using DVSClient.Server;

namespace DVSClient.Common
{
    public class ResponseError
    {
        public string Type { get; }
        public string Title { get; }
        public string Detail { get; }
        public string Instance { get; }

        public ResponseError(RestApiResponseError error)
        {
            Type = error?.Type ?? string.Empty;
            Title = error?.Title ?? string.Empty;
            Detail = error?.Detail ?? string.Empty;
            Instance = error?.Instance ?? string.Empty;
        }
    }
}
