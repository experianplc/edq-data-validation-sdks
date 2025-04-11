namespace DVSClient.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid configuration is detected in the DVSClient.
    /// </summary>
    public class InvalidConfigurationException : EDVSException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidConfigurationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="cause">The exception that is the cause of the current exception.</param>
        public InvalidConfigurationException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
