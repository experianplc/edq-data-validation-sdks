using DVSClient.Exceptions;
using DVSClient.Server.Phone;

namespace DVSClient.Phone.Validate
{
    public class ValidateResultFuture
    {
        private readonly Task<RestApiPhoneValidateResponse> _apiFuture;

        public ValidateResultFuture(Task<RestApiPhoneValidateResponse> apiFuture)
        {
            _apiFuture = apiFuture;
        }

        public async Task<ValidateResult> GetAsync()
        {
            try
            {
                var response = await _apiFuture;

                if (response.Error != null)
                {
                    throw EDVSException.Using(response.Error);
                }
                return new ValidateResult(response);
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        public async Task<ValidateResult> GetAsync(TimeSpan timeout)
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
                return new ValidateResult(response);
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