package com.experian.dvs.client.address.validate;

import com.experian.dvs.client.server.address.validate.RestApiValidateMatchInfoFlags;

import java.util.List;
import java.util.Optional;

public class ValidateMatchInfo {

    private final PostalCodeAction postalCodeAction;
    private final AddressAction addressAction;
    private final List<String> genericInfo;
    private final List<String> ausInfo;
    private final List<String> deuInfo;
    private final List<String> fraInfo;
    private final List<String> gbrInfo;
    private final List<String> nldInfo;
    private final List<String> nzlInfo;
    private final List<String> sgpInfo;

    // Constructor
    public ValidateMatchInfo(RestApiValidateMatchInfoFlags apiResult) {

        if (apiResult != null) {
            this.postalCodeAction = apiResult.getPostcodeAction() != null ? PostalCodeAction.fromName(apiResult.getPostcodeAction()) : null;
            this.addressAction = apiResult.getAddressAction() != null ? AddressAction.fromName(apiResult.getAddressAction()) : null;
            this.genericInfo = apiResult.getGenericInfo() != null ? apiResult.getGenericInfo().stream().map(String::new).toList() : List.of();
            this.ausInfo = apiResult.getAusInfo() != null ? apiResult.getAusInfo().stream().map(String::new).toList() : List.of();
            this.deuInfo = apiResult.getDeuInfo() != null ? apiResult.getDeuInfo().stream().map(String::new).toList() : List.of();
            this.fraInfo = apiResult.getFraInfo() != null ? apiResult.getFraInfo().stream().map(String::new).toList() : List.of();
            this.gbrInfo = apiResult.getGbrInfo() != null ? apiResult.getGbrInfo().stream().map(String::new).toList() : List.of();
            this.nldInfo = apiResult.getNldInfo() != null ? apiResult.getNldInfo().stream().map(String::new).toList() : List.of();
            this.nzlInfo = apiResult.getNzlInfo() != null ? apiResult.getNzlInfo().stream().map(String::new).toList() : List.of();
            this.sgpInfo = apiResult.getSgpInfo() != null ? apiResult.getSgpInfo().stream().map(String::new).toList() : List.of();
        } else {
            this.postalCodeAction = null;
            this.addressAction = null;
            this.genericInfo = List.of();
            this.ausInfo = List.of();
            this.deuInfo = List.of();
            this.fraInfo = List.of();
            this.gbrInfo = List.of();
            this.nldInfo = List.of();
            this.nzlInfo = List.of();
            this.sgpInfo = List.of();
        }
    }

    // Getters
    public PostalCodeAction getPostalCodeAction() { return postalCodeAction; }

    public AddressAction getAddressAction() { return addressAction; }

    public List<String> getGenericInfo() { return genericInfo; }

    public Optional<List<String>> getAusInfo() { return Optional.ofNullable(ausInfo); }
    public Optional<List<String>> getDeuInfo() { return Optional.ofNullable(deuInfo); }
    public Optional<List<String>> getGbrInfo() { return Optional.ofNullable(gbrInfo); }
    public Optional<List<String>> getNldInfo() { return Optional.ofNullable(nldInfo); }
    public Optional<List<String>> getFraInfo() { return Optional.ofNullable(fraInfo); }
    public Optional<List<String>> getNzlInfo() { return Optional.ofNullable(nzlInfo); }
    public Optional<List<String>> getSgpInfo() { return Optional.ofNullable(sgpInfo); }

}