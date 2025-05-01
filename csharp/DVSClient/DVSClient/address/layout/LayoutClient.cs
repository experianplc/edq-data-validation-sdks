using DVSClient.Common;
using DVSClient.Exceptions;
using DVSClient.Server;
using DVSClient.Server.Address.Layout;

namespace DVSClient.Address.Layout
{
    /// <summary>
    /// Client for managing address layouts, including creating, retrieving, listing, and deleting layouts.
    /// </summary>
    public class LayoutClient : IDisposable
    {
        private readonly LayoutConfiguration _configuration;
        private readonly IRestApiAsyncStub _restApiAsyncStub;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutClient"/> class for address layout operations.
        /// </summary>
        /// <param name="configuration">The configuration object containing API settings.</param>
        public LayoutClient(LayoutConfiguration configuration)
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
        /// Retrieves the configuration used by the client.
        /// </summary>
        /// <returns>The <see cref="Common.Configuration"/> object used by the client.</returns>
        public LayoutConfiguration GetConfiguration()
        {
            return _configuration;
        }

        /// <summary>
        /// Creates a new address layout.
        /// </summary>
        /// <param name="name">The name of the layout to create.</param>
        /// <param name="variableLayoutLines">A list of variable layout lines.</param>
        /// <param name="fixedLayoutLines">A list of fixed layout lines.</param>
        /// <param name="appliesToDatasets">The datasets to which the layout applies.</param>
        /// <returns>A <see cref="CreateLayoutResult"/> object containing the result of the creation operation.</returns>
        /// <exception cref="RestApiInterruptionOrExecutionException">Thrown if the API call is interrupted or fails.</exception>
        /// <remarks>
        /// Use this method to create a new address layout with the specified lines and datasets.
        /// </remarks>
        public CreateLayoutResult CreateLayout(
            string name,
            IEnumerable<LayoutLineVariable> variableLayoutLines,
            IEnumerable<LayoutLineFixed> fixedLayoutLines,
            params Dataset[] appliesToDatasets)
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

        /// <summary>
        /// Deletes an address layout by its name.
        /// </summary>
        /// <param name="name">The name of the layout to delete.</param>
        /// <exception cref="RestApiInterruptionOrExecutionException">Thrown if the API call is interrupted or fails.</exception>
        /// <exception cref="EDVSException">Thrown if the layout does not exist or deletion fails.</exception>
        /// <remarks>
        /// Use this method to delete a specific address layout by its name.
        /// </remarks>
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

        /// <summary>
        /// Retrieves a list of address layouts.
        /// </summary>
        /// <returns>A <see cref="GetLayoutListResult"/> object containing the list of layouts.</returns>
        /// <remarks>
        /// Use this method to retrieve all available address layouts.
        /// </remarks>
        public GetLayoutListResult GetLayouts()
        {
            return GetLayouts(null, new List<Dataset>(), string.Empty);
        }

        /// <summary>
        /// Retrieves a list of address layouts based on filters.
        /// </summary>
        /// <param name="country">The country to filter layouts by (optional).</param>
        /// <param name="datasets">A list of datasets to filter layouts by (optional).</param>
        /// <param name="nameContains">A string to filter layouts by name (optional).</param>
        /// <returns>A <see cref="GetLayoutListResult"/> object containing the filtered list of layouts.</returns>
        /// <remarks>
        /// Use this method to retrieve a list of address layouts based on specific filters.
        /// </remarks>
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

        /// <summary>
        /// Retrieves an address layout by its name.
        /// </summary>
        /// <param name="name">The name of the layout to retrieve.</param>
        /// <returns>A <see cref="GetLayoutResult"/> object containing the layout details.</returns>
        /// <exception cref="RestApiInterruptionOrExecutionException">Thrown if the API call is interrupted or fails.</exception>
        /// <remarks>
        /// Use this method to retrieve details of a specific address layout by its name.
        /// </remarks>
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
