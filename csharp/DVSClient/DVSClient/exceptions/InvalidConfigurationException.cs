namespace DVSClient.Exceptions
{
    public class InvalidConfigurationException : EDVSException
    {
        public InvalidConfigurationException(string message) : base(message)
        {
        }

        public InvalidConfigurationException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}
