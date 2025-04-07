using DVSClient.Server;

namespace DVSClient.Exceptions
{
    public class EDVSException : Exception
    {
        public EDVSException(string? message) : base(message)
        {
        }

        public EDVSException(string? message, Exception cause) : base(message, cause)
        {
        }

        public EDVSException(Exception cause) : base(cause.Message, cause)
        {
        }

        public static EDVSException Using(RestApiResponseError responseError)
        {
            if (responseError.Title == "Unauthorized")
            {
                return new UnauthorizedException(responseError);
            }

            if (responseError.Title == "Not Found")
            {
                return new NotFoundException(responseError.Detail);
            }

            return new EDVSException(responseError.Detail);
        }
    }
}