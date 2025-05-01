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

/**
 * AddressClient class for managing address layouts.
 * Provides methods for creating, deleting, and retrieving address layouts.
 */
public class LayoutClient implements Closeable {

    private final LayoutConfiguration configuration;
    private final RestApiAsyncStub restApiAsyncStub;

    /**
     * Initializes a new instance of the {@link LayoutClient} class with the specified configuration.
     *
     * @param configuration The configuration object for the address layout client.
     */
    public LayoutClient(LayoutConfiguration configuration) {
        this.configuration = configuration;
        this.restApiAsyncStub = new RestApiAsyncImpl(configuration);
    }

    /**
     * Closes the client and releases any resources used.
     *
     * @throws IOException If an I/O error occurs while closing the client.
     */
    @Override
    public void close() throws IOException {
        this.restApiAsyncStub.close();
    }

    /**
     * Retrieves the configuration used by the client.
     *
     * @return The {@link LayoutConfiguration} object.
     */
    public LayoutConfiguration getConfiguration() {
        return configuration;
    }

    /**
     * Creates a new address layout with the specified name, variable layout lines, fixed layout lines, and datasets.
     *
     * @param name                The name of the layout.
     * @param variableLayoutLines The variable layout lines for the layout.
     * @param fixedLayoutLines    The fixed layout lines for the layout.
     * @param appliesToDatasets   The datasets to which the layout applies.
     * @return The result of the layout creation.
     */
    public CreateLayoutResult createLayout(final String name,
                                           final List<LayoutLineVariable> variableLayoutLines,
                                           final List<LayoutLineFixed> fixedLayoutLines,
                                           final Dataset... appliesToDatasets) {
        final List<AppliesTo> appliesTo = Arrays.stream(appliesToDatasets).map(AppliesTo::new).toList();
        return createLayout(name, variableLayoutLines, fixedLayoutLines, appliesTo);
    }

    /**
     * Creates a new address layout with the specified name, variable layout lines, fixed layout lines, and applies-to settings.
     *
     * @param name                The name of the layout.
     * @param variableLayoutLines The variable layout lines for the layout.
     * @param fixedLayoutLines    The fixed layout lines for the layout.
     * @param appliesTo           The applies-to settings for the layout.
     * @return The result of the layout creation.
     */
    public CreateLayoutResult createLayout(final String name,
                                           final List<LayoutLineVariable> variableLayoutLines,
                                           final List<LayoutLineFixed> fixedLayoutLines,
                                           final List<AppliesTo> appliesTo) {
        final RestApiAddressLayout layout = new RestApiAddressLayout(name, appliesTo, variableLayoutLines, fixedLayoutLines);
        final RestApiCreateLayoutRequest request = RestApiCreateLayoutRequest.using(this.configuration);
        request.setLayout(layout);

        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        try {
            final RestApiCreateLayoutResponse layoutResponse = this.restApiAsyncStub.createLayoutV2(request, headers).get();
            return new CreateLayoutResult(layoutResponse);
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Deletes an address layout with the specified name.
     *
     * @param name The name of the layout to delete.
     */
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

    /**
     * Retrieves a list of all address layouts.
     *
     * @return The result containing the list of layouts.
     */
    public GetLayoutListResult getLayouts() {
        return getLayouts(Optional.empty(), List.of(), Optional.empty());
    }

    /**
     * Retrieves a list of address layouts based on the specified filters.
     *
     * @param country      The country filter for the layouts.
     * @param datasets     The datasets filter for the layouts.
     * @param nameContains A filter for layout names containing the specified string.
     * @return The result containing the list of layouts.
     */
    public GetLayoutListResult getLayouts(final Optional<Country> country, final List<Dataset> datasets, final Optional<String> nameContains) {
        final Map<String, Object> headers = this.configuration.getCommonHeaders();
        final Optional<String> countryIso3 = country.map(Country::getIso3Code);
        final List<String> datasetsStr = datasets.stream().map(Dataset::getDatasetCode).toList();

        try {
            final RestApiGetLayoutListResponse layoutListResponse = this.restApiAsyncStub.getLayoutsV2(countryIso3, datasetsStr, nameContains, headers).get();
            return new GetLayoutListResult(layoutListResponse);
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Retrieves the details of a specific address layout by name.
     *
     * @param name The name of the layout to retrieve.
     * @return The result containing the layout details.
     */
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
