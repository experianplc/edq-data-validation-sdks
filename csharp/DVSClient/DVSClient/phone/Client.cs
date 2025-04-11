using DVSClient.Exceptions;
using DVSClient.Phone.Validate;
using DVSClient.Server;
using DVSClient.Server.Phone;

namespace DVSClient.Phone
{
    /// <summary>
    /// Client for validating phone numbers using the Experian Data Validation Services.
    /// </summary>
    public class Client : IDisposable
    {
        private readonly Configuration _configuration;
        private readonly IRestApiAsyncStub _restApiAsyncStub;

        /// <summary>
        /// Initializes a new instance of the Client class for phone validation.
        /// </summary>
        /// <param name="configuration">The configuration object containing API settings.</param>
        public Client(Configuration configuration)
        {
            _configuration = configuration;
            _restApiAsyncStub = new RestApiAsyncImpl(configuration);
        }

        /// <summary>
        /// Disposes of resources used by the client.
        /// </summary>
        public void Dispose()
        {
            _restApiAsyncStub.Dispose();
        }

        /// <summary>
        /// Validates a phone number synchronously.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>A Result object containing validation details.</returns>
        /// <exception cref="RestApiInterruptionOrExecutionException">Thrown if the API call is interrupted or fails.</exception>
        /// <remarks>
        /// This method blocks the calling thread until the validation is complete. 
        /// Use this method if you need a synchronous operation.
        /// </remarks>
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

        /// <summary>
        /// Validates a phone number asynchronously.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>A Task that resolves to a Result object containing validation details.</returns>
        public Task<Result> ValidateAsync(string email)
        {
            return ValidateImplAsync(email);
        }

        /// <summary>
        /// Internal implementation for validating a phone number asynchronously.
        /// </summary>
        /// <param name="email">The phone number to validate.</param>
        /// <returns>A <see cref="Task{Result}"/> that resolves to a <see cref="Result"/> object containing validation details.</returns>
        /// <remarks>
        /// This method is used internally by both synchronous and asynchronous validation methods.
        /// </remarks>
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