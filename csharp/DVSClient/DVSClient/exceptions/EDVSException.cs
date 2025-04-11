using DVSClient.Server;

namespace DVSClient.Exceptions
{
    /// <summary>
    /// Represents a custom exception for handling errors in the DVSClient.
    /// Provides constructors for various error scenarios and a factory method for creating specific exceptions based on API response errors.
    /// </summary>
    public class EDVSException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EDVSException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public EDVSException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EDVSException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="cause">The exception that is the cause of the current exception.</param>
        public EDVSException(string? message, Exception cause) : base(message, cause)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EDVSException"/> class with a reference to the inner exception that is the cause of this exception.
        /// The message of the inner exception is used as the message for this exception.
        /// </summary>
        /// <param name="cause">The exception that is the cause of the current exception.</param>
        public EDVSException(Exception cause) : base(cause.Message, cause)
        {
        }

        /// <summary>
        /// Creates an appropriate exception based on the provided <see cref="RestApiResponseError"/>.
        /// </summary>
        /// <param name="responseError">The error response from the REST API.</param>
        /// <returns>An instance of <see cref="EDVSException"/> or a derived exception type based on the error details.</returns>
        public static EDVSException Using(RestApiResponseError responseError)
        {
            // Check if the error is related to unauthorized access and return an UnauthorizedException.
            if (responseError.Title == "Unauthorized")
            {
                return new UnauthorizedException(responseError);
            }

            // Check if the error is related to a resource not being found and return a NotFoundException.
            if (responseError.Title == "Not Found")
            {
                return new NotFoundException(responseError.Detail);
            }

            // For all other errors, return a generic EDVSException with the error details.
            return new EDVSException(responseError.Detail);
        }
    }
}
