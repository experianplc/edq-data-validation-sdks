package com.experian.dvs.client.server;

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

import java.io.Closeable;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.concurrent.Future;

public interface RestApiAsyncStub extends Closeable {

    //FormatAddress
    Future<RestApiAddressSearchResponse> searchV1(RestApiAddressSearchRequest searchRequest, Map<String, Object> headers);
    Future<RestApiAddressFormatResponse> formatV1(String addressKey, RestApiFormatRequest formatRequest, Map<String, Object> headers);
    Future<RestApiAddressValidateResponse> validateV1(RestApiAddressValidateRequest validateRequest, Map<String, Object> headers);
    Future<RestApiAddressSearchResponse> suggestionsStepInV1(String addressKey, Map<String, Object> headers);
    Future<RestApiAddressSearchResponse> suggestionsRefineV1(String addressKey, RestApiSuggestionsRefineRequest refineRequest, Map<String, Object> headers);
    Future<RestApiSuggestionsFormatResponse> suggestionsFormatV1(RestApiSuggestionsFormatRequest formatRequest, Map<String, Object> headers);
    // TODO: Lookup

    // Layouts
    Future<RestApiCreateLayoutResponse> createLayoutV2(RestApiCreateLayoutRequest createLayoutRequest, Map<String, Object> headers);
    Future<RestApiGetLayoutListResponse> getLayoutsV2(final Optional<String> countryIso3, final List<String> datasets, final Optional<String> nameContains, Map<String, Object> headers);
    Future<RestApiGetLayoutResponse> getLayoutV2(String layoutName, Map<String, Object> headers);
    Future<Optional<RestApiResponseError>> deleteLayoutV2(String layoutName, Map<String, Object> headers);

    // FormatAddress Utils
    Future<RestApiGetDatasetsResponse> getDatasetsV1(String countryIso3, Map<String, Object> headers);
    // TODO: promptsets

    //Phone
    Future<RestApiPhoneValidateResponse> validatePhoneV2(RestApiPhoneValidateRequest validatePhoneRequest, Map<String, Object> headers);

    //Email
    Future<RestApiEmailValidateResponse> validateEmailV2(RestApiEmailValidateRequest validateEmailRequest, Map<String, Object> headers);
}
