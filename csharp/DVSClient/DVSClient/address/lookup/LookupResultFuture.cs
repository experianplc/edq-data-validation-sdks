using DVSClient.Exceptions;
using DVSClient.Server.Address.Lookup;

namespace DVSClient.address.lookup
{
    public class LookupResultFuture
    {
        private readonly Task<RestApiAddressLookupV2Response> _apiResponse;

        public LookupResultFuture(Task<RestApiAddressLookupV2Response> apiResponse)
        {
            _apiResponse = apiResponse;
        }

        public async Task<LookupResult> GetAsync()
        {
            try
            {
                var response = await _apiResponse;
                if (response.Error != null)
                {
                    throw EDVSException.Using(response.Error);
                }
                return new LookupResult(response.Result == null ? new RestApiAddressLookupV2Result() : response.Result);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public async Task<LookupResult> GetAsync(TimeSpan timeout)
        {
            try
            {
                var response = await Task.WhenAny(_apiResponse, Task.Delay(timeout)) == _apiResponse
                    ? await _apiResponse
                    : throw new TimeoutException();

                if (response.Error != null)
                {
                    throw EDVSException.Using(response.Error);
                }
                return new LookupResult(response.Result == null ? new RestApiAddressLookupV2Result() : response.Result);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException || e is TimeoutException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }
        public bool Cancel(bool mayInterruptIfRunning)
        {
            return _apiResponse.IsCanceled;
        }

        public bool IsCancelled()
        {
            return _apiResponse.IsCanceled;
        }

        public bool IsDone()
        {
            return _apiResponse.IsCompleted;
        }
    }
}