package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.address.Dataset;
import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.exceptions.NotFoundException;
import com.experian.dvs.client.exceptions.RestApiInterruptionOrExecutionException;
import com.experian.dvs.client.server.RestApiAsyncImpl;
import com.experian.dvs.client.server.RestApiAsyncStub;
import com.experian.dvs.client.server.RestApiResponseError;
import com.experian.dvs.client.server.address.layout.*;

import java.io.Closeable;
import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.concurrent.ExecutionException;

public class AddressLayoutClient implements Closeable {

    private final AddressLayoutConfiguration configuration;
    private final RestApiAsyncStub restApiAsyncStub;

    public AddressLayoutClient(AddressLayoutConfiguration configuration) {
        this.configuration = configuration;
        this.restApiAsyncStub = new RestApiAsyncImpl(configuration);
    }

    @Override
    public void close() throws IOException {
        this.restApiAsyncStub.close();
    }

    public AddressLayoutConfiguration getConfiguration() {
        return configuration;
    }

    public CreateLayoutResult createLayout(final String name,
                                           final List<LayoutLineVariable> variableLayoutLines,
                                           final List<LayoutLineFixed> fixedLayoutLines,
                                           final Dataset... appliesToDatasets) {

        final List<AppliesTo> appliesTo = Arrays.stream(appliesToDatasets).map(AppliesTo::new).toList();
        return createLayout(name, variableLayoutLines, fixedLayoutLines, appliesTo);


    }


    public CreateLayoutResult createLayout(final String name,
                                           final List<LayoutLineVariable> variableLayoutLines,
                                           final List<LayoutLineFixed> fixedLayoutLines,
                                           final List<AppliesTo> appliesTo) {


        final RestApiAddressLayout layout = new RestApiAddressLayout(name, appliesTo, variableLayoutLines, fixedLayoutLines);


        final RestApiCreateLayoutRequest request = RestApiCreateLayoutRequest.using(this.configuration);
        request.setLayout(layout);

        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        ;
        try {
            final RestApiCreateLayoutResponse layoutResponse = this.restApiAsyncStub.createLayoutV2(request, headers).get();
            return new CreateLayoutResult(layoutResponse);
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    public void deleteLayout(final String name) {

        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        try {
            final Optional<RestApiResponseError> error = this.restApiAsyncStub.deleteLayoutV2(name, headers).get();
            if (error.isPresent()) {
                final RestApiResponseError responseError = error.get();
                responseError.setDetail(String.format("Failed to delete layout %s", name));
                throw EDVSException.using(error.get());
            }
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    public GetLayoutListResult getLayouts() {
        return getLayouts(Optional.empty(), List.of(), Optional.empty());
    }

    public GetLayoutListResult getLayouts(final Optional<Country> country, final List<Dataset> datasets, final Optional<String> nameContains) {

        final Map<String, Object> headers = this.configuration.getCommonHeaders();

        final Optional<String> countryIso3 = country.map(Country::getIso3Code);
        final List<String> datasetsStr = datasets.stream().map(Dataset::getDatasetCode).toList();


        try {
            final RestApiGetLayoutListResponse layoutListResponse = this.restApiAsyncStub.getLayoutsV2(countryIso3,  datasetsStr, nameContains,  headers).get();
            return new GetLayoutListResult(layoutListResponse);
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }

    }

    public GetLayoutResult getLayout(final String name) {

        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        try {
            final RestApiGetLayoutResponse layoutResponse = this.restApiAsyncStub.getLayoutV2(name, headers).get();
            return new GetLayoutResult(layoutResponse);
        } catch (NotFoundException e) {
            return new GetLayoutResult(null);
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }

    }
}
