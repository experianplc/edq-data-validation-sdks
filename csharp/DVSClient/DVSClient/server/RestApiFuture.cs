namespace DVSClient.Server
{
    public class RestApiFuture<T>
    {
        private readonly Type _type;
        private readonly Task<HttpResponseMessage> _responseTask;

        public RestApiFuture(Type type, Task<HttpResponseMessage> responseTask)
        {
            _type = type;
            _responseTask = responseTask;
        }

        public bool Cancel(bool mayInterruptIfRunning)
        {
            return _responseTask.IsCanceled;
        }

        public bool IsCanceled => _responseTask.IsCanceled;

        public bool IsCompleted => _responseTask.IsCompleted;

        public T Result
        {
            get
            {
                try
                {
                    using (var response = _responseTask.Result)
                    {
                        return ReadEntity(response);
                    }
                }
                catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
                {
                    throw new OperationCanceledException();
                }
            }
        }

        public T GetAwaiter()
        {
            try
            {
                using (var response = _responseTask.GetAwaiter().GetResult())
                {
                    return ReadEntity(response);
                }
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                throw new OperationCanceledException();
            }
        }

        private T ReadEntity(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return (T)Convert.ChangeType(content, _type);
            }
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
        }
    }
}