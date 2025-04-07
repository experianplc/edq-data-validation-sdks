namespace DVSClient.Exceptions
{
    public class NotFoundException : EDVSException
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
