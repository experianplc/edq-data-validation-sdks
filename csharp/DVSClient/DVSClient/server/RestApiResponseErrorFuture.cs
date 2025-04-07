namespace DVSClient.Server
{
    public class RestApiResponseErrorFuture
    {
        private readonly Task<HttpResponseMessage> _responseTask;

        public RestApiResponseErrorFuture(Task<HttpResponseMessage> responseTask)
        {
            _responseTask = responseTask;
        }

        public bool Cancel(bool mayInterruptIfRunning)
        {
            return false;
        }

        public bool IsCanceled => false;

        public bool IsCompleted => _responseTask.IsCompleted;

        public RestApiResponseError? Result
        {
            get
            {
                try
                {
                    using (var response = _responseTask.Result)
                    {
                        return GetOptionalError(response);
                    }
                }
                catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
                {
                    throw new OperationCanceledException();
                }
            }
        }

        public RestApiResponseError? GetAwaiter()
        {
            try
            {
                using (var response = _responseTask.GetAwaiter().GetResult())
                {
                    return GetOptionalError(response);
                }
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                throw new OperationCanceledException();
            }
        }

        private RestApiResponseError? GetOptionalError(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                var error = new RestApiResponseError
                {   
                    Type = ((int)response.StatusCode).ToString(),
                    Title = response.ReasonPhrase ?? string.Empty
                };
                return error;
            }
            return null;
        }
    }
}