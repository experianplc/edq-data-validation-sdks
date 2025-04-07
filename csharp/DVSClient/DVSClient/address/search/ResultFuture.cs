using DVSClient.Exceptions;
using DVSClient.Server.Address.Search;

namespace DVSClient.Address.Search
{
    public class ResultFuture
    {
        private readonly Task<RestApiAddressSearchResponse> _apiFuture;

        public ResultFuture(Task<RestApiAddressSearchResponse> apiFuture)
        {
            _apiFuture = apiFuture;
        }

        public async Task<Result> GetAsync()
        {
            try
            {
                var apiSearchResponse = await _apiFuture;
                var optError = apiSearchResponse.Error;
                if (optError != null)
                {
                    throw EDVSException.Using(optError);
                }
                return new Result(apiSearchResponse);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public async Task<Result> GetAsync(TimeSpan timeout)
        {
            try
            {
                var apiSearchResponse = await Task.WhenAny(_apiFuture, Task.Delay(timeout)) == _apiFuture
                    ? await _apiFuture
                    : throw new TimeoutException();
                var optError = apiSearchResponse.Error;
                if (optError != null)
                {
                    throw EDVSException.Using(optError);
                }
                return new Result(apiSearchResponse);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException || e is TimeoutException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public bool Cancel(bool mayInterruptIfRunning)
        {
            return _apiFuture.IsCanceled;
        }

        public bool IsCancelled()
        {
            return _apiFuture.IsCanceled;
        }

        public bool IsDone()
        {
            return _apiFuture.IsCompleted;
        }
    }
}