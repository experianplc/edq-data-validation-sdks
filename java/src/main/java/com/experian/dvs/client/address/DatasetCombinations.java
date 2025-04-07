package com.experian.dvs.client.address;

import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum DatasetCombinations {
    AUTOCOMPLETE(
            SearchType.AUTOCOMPLETE,
            List.of(
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_BUSINESS),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_ELECTRICITY),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_GAS),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDRESS, Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS),

                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),

                    List.of(Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_BUSINESS),
                    List.of(Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_BUSINESS),
                    List.of(Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),

                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_BUSINESS),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_BUSINESS),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),

                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_BUSINESS),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_BUSINESS),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_ELECTRICITY, Dataset.GB_ADDITIONAL_GAS, Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE)
            )
    ),
    SINGLELINE(
            SearchType.SINGLELINE,
            List.of(
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NAMES, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_NAMES)
            )
    ),
    TYPEDOWN(
            SearchType.TYPEDOWN,
            List.of(
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_BUSINESS, Dataset.GB_ADDITIONAL_NAMES, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT),
                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_NAMES),
                    List.of(Dataset.GB_ADDITIONAL_NOTYETBUILT, Dataset.GB_ADDITIONAL_NAMES)
            )
    ),
    VALIDATE(
            SearchType.VALIDATE,
            List.of(
                    List.of(Dataset.GB_ADDITIONAL_MULTIPLERESIDENCE, Dataset.GB_ADDITIONAL_NOTYETBUILT)
            )
    );

    private final SearchType searchType;
    private final List<List<Dataset>> datasets;

    //Map of search type to Dataset
    private static final Map<SearchType, DatasetCombinations> searchTypeMap = Arrays.stream(DatasetCombinations.values())
            .collect(Collectors.toMap(DatasetCombinations::getSearchType, Function.identity()));

    DatasetCombinations(SearchType searchType, List<List<Dataset>> datasets) {
        this.searchType = searchType;
        this.datasets = datasets;
    }

    public static List<List<Dataset>> fromSearchType(SearchType searchType) {
        return searchTypeMap.get(searchType).datasets;
    }

    public SearchType getSearchType() {
        return searchType;
    }

    public List<List<Dataset>> getDatasets() {
        return datasets;
    }

}