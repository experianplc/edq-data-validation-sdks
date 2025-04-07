using DVSClient.Exceptions;
using DVSClient.Phone.Validate;
using DVSClient.Server;
using DVSClient.Server.Phone;

namespace DVSClient.Phone
{
    public class Client : IDisposable
    {
        private readonly Configuration _configuration;
        private readonly IRestApiAsyncStub _restApiAsyncStub;

        public Client(Configuration configuration)
        {
            _configuration = configuration;
            _restApiAsyncStub = new RestApiAsyncImpl(configuration);
        }

        public void Dispose()
        {
            _restApiAsyncStub.Dispose();
        }

        public Result Validate(string email)
        {
            try
            {
                return ValidateAsync(email).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public Task<Result> ValidateAsync(string email)
        {
            return ValidateImplAsync(email);
        }

        private Task<Result> ValidateImplAsync(string phoneNumber)
        {
            var request = RestApiPhoneValidateRequest.Using(_configuration);
            request.Number = phoneNumber;

            var headers = _configuration.GetCommonHeaders(allowsDotInReferenceId: false);

            if (_configuration.Metadata.HasValue && _configuration.Metadata.Value)
            {
                headers["Add-Metadata"] = true.ToString();
            }

            var response = _restApiAsyncStub.ValidatePhoneV2(request, headers);
            return new ResultFuture(response).GetAsync();
        }
    }
}