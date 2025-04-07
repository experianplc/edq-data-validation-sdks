using DVSClient.Server;

namespace DVSClient.Exceptions
{
    public class UnauthorizedException : EDVSException
    {
        public UnauthorizedException(RestApiResponseError responseError) : base(responseError.Detail)
        {
        }
    }
}
