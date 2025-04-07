package com.experian.dvs.client.address.datasets;

import com.experian.dvs.client.common.Country;
import com.experian.dvs.client.address.Dataset;
import com.experian.dvs.client.server.address.dataset.RestApiAddressDatasetResult;

import java.util.List;

public class AddressDataset {

    private final Country country;
    private final List<Dataset> datasets;
    private final List<List<Dataset>> validCombinations;

    public AddressDataset(final RestApiAddressDatasetResult result) {

        this.country = result.getCountryIso3() != null && !result.getCountryIso3().isEmpty() ? Country.fromIso3(result.getCountryIso3()) : null;
        this.datasets = result.getDatasets() != null && !result.getDatasets().isEmpty() ? result.getDatasets().stream().map(p -> Dataset.fromCode(p.getId())).toList() : List.of();
        this.validCombinations = result.getValidCombinations() != null && !result.getValidCombinations().isEmpty() ? result.getValidCombinations().stream().map(p -> p.stream().map(Dataset::fromCode).toList()).toList() : List.of();
    }

    public Country getCountry() {
        return country;
    }

    public List<Dataset> getDatasets() {
        return datasets;
    }

    public List<List<Dataset>> getValidCombinations() {
        return validCombinations;
    }
}
