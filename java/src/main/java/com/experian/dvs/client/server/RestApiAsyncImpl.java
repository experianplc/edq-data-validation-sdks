package com.experian.dvs.client.server;

import com.experian.dvs.client.common.Configuration;
import com.experian.dvs.client.server.address.dataset.RestApiGetDatasetsResponse;
import com.experian.dvs.client.server.address.format.RestApiFormatRequest;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatResponse;
import com.experian.dvs.client.server.address.layout.RestApiCreateLayoutRequest;
import com.experian.dvs.client.server.address.layout.RestApiCreateLayoutResponse;
import com.experian.dvs.client.server.address.layout.RestApiGetLayoutListResponse;
import com.experian.dvs.client.server.address.layout.RestApiGetLayoutResponse;
import com.experian.dvs.client.server.address.search.RestApiAddressSearchRequest;
import com.experian.dvs.client.server.address.search.RestApiAddressSearchResponse;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatRequest;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatResponse;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsRefineRequest;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateRequest;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateResponse;
import com.experian.dvs.client.server.email.RestApiEmailValidateRequest;
import com.experian.dvs.client.server.email.RestApiEmailValidateResponse;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateRequest;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResponse;
import jakarta.ws.rs.client.*;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.UriBuilder;
import org.apache.http.client.config.RequestConfig;
import org.glassfish.jersey.apache.connector.ApacheConnectorProvider;
import org.glassfish.jersey.client.ClientConfig;
import org.glassfish.jersey.logging.LoggingFeature;

import java.io.IOException;
import java.net.URI;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.concurrent.Future;
import java.util.logging.Level;
import java.util.logging.Logger;

public class RestApiAsyncImpl implements RestApiAsyncStub {

    private final Configuration configuration;
    private final Client client;

    public RestApiAsyncImpl(final Configuration configuration) {
        this.configuration = configuration;
        this.client = ClientBuilder.newClient(getClientConfig());
    }

    @Override
    public void close() throws IOException {
        this.client.close();
    }

    @Override
    public Future<RestApiAddressSearchResponse> searchV1(RestApiAddressSearchRequest searchRequest, Map<String, Object> headers) {
        final String endPoint = "address/search/v1";
        return post(endPoint, RestApiAddressSearchResponse.class, searchRequest, headers, Map.of());
    }

    @Override
    public Future<RestApiAddressFormatResponse> formatV1(final String addressKey, final RestApiFormatRequest formatRequest, final Map<String, Object> headers) {
        final String endPoint = "address/format/v1/" + addressKey;
        return post(endPoint, RestApiAddressFormatResponse.class, formatRequest, headers, Map.of());
    }

    @Override
    public Future<RestApiCreateLayoutResponse> createLayoutV2(RestApiCreateLayoutRequest createLayoutRequest, final Map<String, Object> headers) {
        final String endPoint = "address/layouts/v2";
        return post(endPoint, RestApiCreateLayoutResponse.class, createLayoutRequest, headers, Map.of());
    }

    @Override
    public Future<RestApiGetLayoutListResponse> getLayoutsV2(final Optional<String> countryIso3, final List<String> datasets, final Optional<String> nameContains, final Map<String, Object> headers) {
        final String endPoint = "address/layouts/v2/";

        final Map<String, Object> params = new HashMap<>();
        countryIso3.ifPresent(s -> params.put("country_iso", s));
        if (datasets != null && !datasets.isEmpty()) {
            params.put("datasets", String.join(",", datasets));
        }
        nameContains.ifPresent(s -> params.put("name_contains", s));
        return get(endPoint, RestApiGetLayoutListResponse.class, headers, params);
    }

    @Override
    public Future<RestApiGetLayoutResponse> getLayoutV2(String layoutName, final Map<String, Object> headers) {
        final String endPoint = "address/layouts/v2/" + layoutName;
        return get(endPoint, RestApiGetLayoutResponse.class, headers, Map.of());
    }

    @Override
    public Future<Optional<RestApiResponseError>> deleteLayoutV2(String layoutName, Map<String, Object> headers) {
        final String endPoint = "address/layouts/v2/" + layoutName;
        return delete(endPoint, headers, Map.of());
    }

    @Override
    public Future<RestApiGetDatasetsResponse> getDatasetsV1(final String countryIso3, Map<String, Object> headers) {
        final String endPoint = "address/datasets/v1";
        final Map<String, Object> params = Map.of("country_iso", countryIso3);
        return get(endPoint, RestApiGetDatasetsResponse.class, headers, params);
    }

    @Override
    public Future<RestApiAddressValidateResponse> validateV1(RestApiAddressValidateRequest validateRequest, Map<String, Object> headers) {
        final String endPoint = "address/validate/v1";
        return post(endPoint, RestApiAddressValidateResponse.class, validateRequest, headers, Map.of());
    }

    public Future<RestApiAddressSearchResponse> suggestionsStepInV1(String global_address_key, Map<String, Object>  headers)
    {
        final String endPoint = "/address/suggestions/stepin/v1/" + global_address_key;
        return get(endPoint, RestApiAddressSearchResponse.class, headers, Map.of());
    }

    public Future<RestApiAddressSearchResponse> suggestionsRefineV1(String key, RestApiSuggestionsRefineRequest refineRequest, Map<String, Object> headers)
    {
        final String endPoint = "/address/suggestions/refine/v1/" + key;
        return post(endPoint, RestApiAddressSearchResponse.class, refineRequest, headers, Map.of());
    }

    public Future<RestApiSuggestionsFormatResponse> suggestionsFormatV1(RestApiSuggestionsFormatRequest formatRequest, Map<String, Object> headers)
    {
        final String endPoint = "/address/suggestions/format/v1/";
        return post(endPoint, RestApiSuggestionsFormatResponse.class, formatRequest, headers, Map.of());
    }

    @Override
    public Future<RestApiPhoneValidateResponse> validatePhoneV2(RestApiPhoneValidateRequest validatePhoneRequest, Map<String, Object> headers) {
        final String endPoint = "phone/validate/v2";
        return post(endPoint, RestApiPhoneValidateResponse.class, validatePhoneRequest, headers, Map.of());
    }

    @Override
    public Future<RestApiEmailValidateResponse> validateEmailV2(RestApiEmailValidateRequest validateEmailRequest, Map<String, Object> headers) {
        final String endPoint = "email/validate/v2";
        return post(endPoint, RestApiEmailValidateResponse.class, validateEmailRequest, headers, Map.of());
    }

    private <T> RestApiFuture<T> post(final String endPoint, final Class<T> cls, final Object requestObject, final Map<String, Object> headers, final Map<String, Object> parameters) {
        final URI uri = getURI(endPoint, parameters);
        final WebTarget webTarget = this.client.target(uri);
        final Invocation.Builder request =  webTarget.request(MediaType.APPLICATION_JSON);
        headers.forEach(request::header);
        return new RestApiFuture<T>(cls, request.async().post(Entity.entity(requestObject, MediaType.APPLICATION_JSON)));
    }

    private <T> RestApiFuture<T> get(final String endPoint, final Class<T> cls, final Map<String, Object> headers, final Map<String, Object> parameters) {
        final URI uri = getURI(endPoint, parameters);
        final WebTarget webTarget = this.client.target(uri);
        final Invocation.Builder request =  webTarget.request(MediaType.APPLICATION_JSON);
        headers.forEach(request::header);
        return new RestApiFuture<>(cls, request.async().get());
    }

    private Future<Optional<RestApiResponseError>> delete(final String endPoint, final Map<String, Object> headers, final Map<String, Object> parameters) {

        final URI uri = getURI(endPoint, parameters);
        final WebTarget webTarget = this.client.target(uri);
        final Invocation.Builder request =  webTarget.request(MediaType.WILDCARD);
        headers.forEach(request::header);
        return new RestApiResponseErrorFuture(request.async().delete());
    }

    private URI getURI(final String endPoint, final Map<String, Object> parameters) {

        final URI baseUri = URI.create(this.configuration.getServerUri().toString() + endPoint);
        if (!parameters.isEmpty()) {
            UriBuilder uriBuilder = UriBuilder.fromUri(baseUri);
            parameters.forEach(uriBuilder::queryParam);
            return uriBuilder.build();
        } else {
            return baseUri;
        }
    }

    private ClientConfig getClientConfig() {
        Logger logger = Logger.getLogger(RestApiAsyncStub.class.getName());
        return  (new ClientConfig())
                .connectorProvider(new ApacheConnectorProvider())
                .property("jersey.config.apache.client.requestConfig", RequestConfig.custom().setCookieSpec("standard").build())
                .register(new LoggingFeature(logger, Level.INFO, LoggingFeature.Verbosity.PAYLOAD_ANY, 10000));

    }
}
