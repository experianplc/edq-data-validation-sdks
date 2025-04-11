namespace DVSClient.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a REST API call is interrupted or fails during execution.
    /// </summary>
    public class RestApiInterruptionOrExecutionException : EDVSException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestApiInterruptionOrExecutionException"/> class with a reference to the exception that caused the error.
        /// </summary>
        /// <param name="e">The exception that caused the REST API interruption or execution failure.</param>
        public RestApiInterruptionOrExecutionException(Exception e) : base(e)
        {
        }
    }
}
