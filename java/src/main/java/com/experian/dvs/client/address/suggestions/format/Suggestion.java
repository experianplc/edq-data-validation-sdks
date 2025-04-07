package com.experian.dvs.client.address.suggestions.format;

import com.experian.dvs.client.address.format.Address;
import com.experian.dvs.client.address.format.AddressComponents;
import com.experian.dvs.client.address.format.AddressFormatted;
import com.experian.dvs.client.address.format.AddressMetadata;
import com.experian.dvs.client.server.address.suggestions.RestApiSuggestionsFormatSuggestion;

import java.util.Objects;
import java.util.Optional;

public class Suggestion {
    private final String globalAddressKey;
    private final Address address;
    private final AddressFormatted addressFormatted;
    private final AddressComponents components;
    private final AddressMetadata metadata;

    public Suggestion(final RestApiSuggestionsFormatSuggestion suggestion) {
        if (suggestion != null) {
            this.globalAddressKey = Objects.toString(suggestion.getGlobalAddressKey(), "");
            this.address = suggestion.getAddress() != null ? new Address(suggestion.getAddress()) : null;
            //only one currently supported so just pick the first
            this.addressFormatted = suggestion.getAddressesFormatted() != null  && !suggestion.getAddressesFormatted().isEmpty() ? new AddressFormatted(suggestion.getAddressesFormatted().get(0)) : null;
            this.components = suggestion.getComponents() != null ? new AddressComponents(suggestion.getComponents()) : null;
            this.metadata = suggestion.getMetadata() != null ? new AddressMetadata(suggestion.getMetadata()) : null;
        } else {
            this.globalAddressKey = "";
            this.address = null;
            this.addressFormatted = null;
            this.components = null;
            this.metadata = null;
        }
    }

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public Address getAddress() {
        return address;
    }

    public AddressFormatted getAddressFormatted() {
        return addressFormatted;
    }

    public Optional<AddressMetadata> getMetadata() {
        return Optional.ofNullable(metadata);
    }

    public Optional<AddressComponents> getComponents() {
        return Optional.ofNullable(components);
    }

}
