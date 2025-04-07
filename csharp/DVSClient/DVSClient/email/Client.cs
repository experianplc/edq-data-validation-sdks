using DVSClient.Email.Validate;
using DVSClient.Exceptions;
using DVSClient.Server;
using DVSClient.Server.Email;

namespace DVSClient.Email
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

        private Task<Result> ValidateImplAsync(string email)
        {
            var request = RestApiEmailValidateRequest.Using(_configuration);
            request.Email = email;

            var headers = _configuration.GetCommonHeaders(allowsDotInReferenceId: false);

            if (_configuration.Metadata.HasValue && _configuration.Metadata.Value)
            {
                headers["Add-Metadata"] = true.ToString();
            }

            var response = _restApiAsyncStub.ValidateEmailV2(request, headers);
            return new ResultFuture(response).GetAsync();
        }
    }
}