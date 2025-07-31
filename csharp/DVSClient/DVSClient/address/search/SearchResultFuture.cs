using DVSClient.Exceptions;
using DVSClient.Server.Address.Search;

namespace DVSClient.Address.Search
{
    public class SearchResultFuture
    {
        private readonly Task<RestApiAddressSearchResponse> _apiFuture;

        public SearchResultFuture(Task<RestApiAddressSearchResponse> apiFuture)
        {
            _apiFuture = apiFuture;
        }

        public async Task<SearchResult> GetAsync()
        {
            try
            {
                var apiSearchResponse = await _apiFuture;
                var error = apiSearchResponse.Error;
                if (error != null)
                {
                    throw EDVSException.Using(error);
                }
                return new SearchResult(apiSearchResponse);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public async Task<SearchResult> GetAsync(TimeSpan timeout)
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
                return new SearchResult(apiSearchResponse);
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