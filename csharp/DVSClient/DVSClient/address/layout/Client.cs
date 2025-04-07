using DVSClient.Common;
using DVSClient.Exceptions;
using DVSClient.Server;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    public class Client : IDisposable
    {
        private readonly Common.Configuration _configuration;
        private readonly IRestApiAsyncStub _restApiAsyncStub;

        public Client(Common.Configuration configuration)
        {
            _configuration = configuration;
            _restApiAsyncStub = new RestApiAsyncImpl(configuration);
        }

        public void Dispose()
        {
            _restApiAsyncStub.Dispose();
        }

        public Common.Configuration GetConfiguration()
        {
            return _configuration;
        }

        public CreateLayoutResult CreateLayout(string name, IEnumerable<LayoutLineVariable> variableLayoutLines, IEnumerable<LayoutLineFixed> fixedLayoutLines, params Dataset[] appliesToDatasets)
        {
            IEnumerable<AppliesTo> appliesTo = appliesToDatasets.Select(dataset => new AppliesTo(dataset)).ToList();
            return CreateLayout(name, variableLayoutLines, fixedLayoutLines, appliesTo);
        }

        private CreateLayoutResult CreateLayout(string name, IEnumerable<LayoutLineVariable> variableLayoutLines, IEnumerable<LayoutLineFixed> fixedLayoutLines, IEnumerable<AppliesTo> appliesTo)
        {
            var layout = new RestApiAddressLayout(name, appliesTo, variableLayoutLines, fixedLayoutLines);
            var request = RestApiCreateLayoutRequest.Using(_configuration);
            request.Layout = layout;
            var headers = _configuration.GetCommonHeaders();

            try
            {
                var layoutResponse = _restApiAsyncStub.CreateLayoutV2(request, headers).GetAwaiter().GetResult();
                return new CreateLayoutResult(layoutResponse);
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(ex);
            }
        }

        public void DeleteLayout(string name)
        {
            var headers = _configuration.GetCommonHeaders();

            try
            {
                var response = _restApiAsyncStub.DeleteLayoutV2(name, headers).GetAwaiter().GetResult();
                if (response?.Error != null)
                {
                    var responseError = response.Error;
                    throw EDVSException.Using(responseError);
                }
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(ex);
            }
        }

        public GetLayoutListResult GetLayouts()
        {
            return GetLayouts(null, new List<Dataset>(), string.Empty);
        }

        public GetLayoutListResult GetLayouts(Country? country, List<Dataset> datasets, string nameContains)
        {
            var headers = _configuration.GetCommonHeaders();
            
            var countryIso3 = string.Empty;
            if (country != null)
            {
                countryIso3 = country.Iso3Code;
            }

            var datasetsStr = datasets.Select(dataset => dataset.DatasetCode).ToList();

            try
            {
                var layoutListResponse = _restApiAsyncStub.GetLayoutsV2(countryIso3, datasetsStr, nameContains, headers).GetAwaiter().GetResult();
                return new GetLayoutListResult(layoutListResponse);
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(ex);
            }
        }

        public GetLayoutResult GetLayout(string name)
        {
            var headers = _configuration.GetCommonHeaders();

            try
            {
                var layoutResponse = _restApiAsyncStub.GetLayoutV2(name, headers).GetAwaiter().GetResult();
                return new GetLayoutResult(layoutResponse);
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                throw new RestApiInterruptionOrExecutionException(ex);
            }
        }
    }
}