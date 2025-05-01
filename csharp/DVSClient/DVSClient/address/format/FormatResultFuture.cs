using DVSClient.Exceptions;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class FormatResultFuture
    {
        private readonly Task<RestApiAddressFormatResponse> _apiFuture;

        public FormatResultFuture(Task<RestApiAddressFormatResponse> apiFuture)
        {
            _apiFuture = apiFuture;
        }

        public async Task<FormatResult> GetAsync()
        {
            try
            {
                var response = await _apiFuture;
                if (response.Error != null)
                {
                    throw EDVSException.Using(response.Error);
                }
                return new FormatResult(response);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public async Task<FormatResult> GetAsync(TimeSpan timeout)
        {
            try
            {
                var response = await Task.WhenAny(_apiFuture, Task.Delay(timeout)) == _apiFuture
                    ? await _apiFuture
                    : throw new TimeoutException();

                if (response.Error != null)
                {
                    throw EDVSException.Using(response.Error);
                }
                return new FormatResult(response);
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