using DVSClient.Server;

namespace DVSClient.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a REST API call fails due to unauthorized access.
    /// </summary>
    public class UnauthorizedException : EDVSException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class with the details of the unauthorized error.
        /// </summary>
        /// <param name="responseError">The error response from the REST API containing details about the unauthorized access.</param>
        public UnauthorizedException(RestApiResponseError responseError) : base(responseError.Detail)
        {
        }
    }
}
