namespace DVSClient.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a requested resource is not found in the DVSClient.
    /// </summary>
    public class NotFoundException : EDVSException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
