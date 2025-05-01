package com.experian.dvs.client.server.address.suggestions;

import com.experian.dvs.client.address.AddressConfiguration;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiSuggestionsRefineRequest {
    @JsonProperty("refinement")
    private String Refinement;

    public static com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsRefineRequest using(final AddressConfiguration configuration) {
        final com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsRefineRequest refineRequest = new com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsRefineRequest();
        return refineRequest;
    }

    public String getRefinement() {
        return Refinement;
    }

    public void setRefinement(String refinement) {
        this.Refinement = refinement;
    }
}