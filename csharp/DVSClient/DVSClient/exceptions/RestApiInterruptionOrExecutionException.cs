namespace DVSClient.Exceptions
{
    public class RestApiInterruptionOrExecutionException : EDVSException
    {
        public RestApiInterruptionOrExecutionException(Exception e) : base(e)
        {
        }
    }
}