using DVSClient.Exceptions;
using DVSClient.Server.Address.Datasets;

namespace DVSClient.Address.Datasets
{
    public class GetDatasetsResultFuture
    {
        private readonly Task<RestApiGetDatasetsResponse> _apiResponse;

        public GetDatasetsResultFuture(Task<RestApiGetDatasetsResponse> apiResponse)
        {
            _apiResponse = apiResponse;
        }

        public async Task<GetDatasetsResult> GetAsync()
        {
            try
            {
                var response = await _apiResponse;
                if (response.Error != null)
                {
                    throw EDVSException.Using(response.Error);
                }
                return new GetDatasetsResult(response);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public async Task<GetDatasetsResult> GetAsync(TimeSpan timeout)
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
                return new GetDatasetsResult(response);
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