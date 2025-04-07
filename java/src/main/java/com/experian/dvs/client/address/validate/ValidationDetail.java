package com.experian.dvs.client.address.validate;

import com.experian.dvs.client.server.address.format.RestApiValidationDetail;

public class ValidationDetail {

    private final boolean buildingFirmNameCorrected;
    private final boolean primaryNumberCorrected;
    private final boolean streetCorrected;
    private final boolean ruralRouteHighwayContractMatched;
    private final boolean cityNameCorrected;
    private final boolean cityNameAliasMatched;
    private final boolean stateCorrected;
    private final boolean zipCodeCorrected;
    private final boolean secondaryNumRetained;
    private final boolean idenPreStInfoRetained;
    private final boolean genPreStInfoRetained;
    private final boolean postStInfoRetained;

    // Constructor
    public ValidationDetail(RestApiValidationDetail api) {
        this.buildingFirmNameCorrected = Boolean.TRUE.equals(api.isBuildingFirmNameCorrected());
        this.primaryNumberCorrected = Boolean.TRUE.equals(api.isPrimaryNumberCorrected());
        this.streetCorrected = Boolean.TRUE.equals(api.isStreetCorrected());
        this.ruralRouteHighwayContractMatched = Boolean.TRUE.equals(api.isRuralRouteHighwayContractMatched());
        this.cityNameCorrected = Boolean.TRUE.equals(api.isCityNameCorrected());
        this.cityNameAliasMatched = Boolean.TRUE.equals(api.isCityNameAliasMatched());
        this.stateCorrected = Boolean.TRUE.equals(api.isStateCorrected());
        this.zipCodeCorrected = Boolean.TRUE.equals(api.isZipCodeCorrected());
        this.secondaryNumRetained = Boolean.TRUE.equals(api.isSecondaryNumRetained());
        this.idenPreStInfoRetained = Boolean.TRUE.equals(api.isIdenPreStInfoRetained());
        this.genPreStInfoRetained = Boolean.TRUE.equals(api.isGenPreStInfoRetained());
        this.postStInfoRetained = Boolean.TRUE.equals(api.isPostStInfoRetained());
    }

    // Getters
    public boolean isBuildingFirmNameCorrected() {
        return buildingFirmNameCorrected;
    }

    public boolean isPrimaryNumberCorrected() {
        return primaryNumberCorrected;
    }

    public boolean isStreetCorrected() {
        return streetCorrected;
    }

    public boolean isRuralRouteHighwayContractMatched() {
        return ruralRouteHighwayContractMatched;
    }

    public boolean isCityNameCorrected() {
        return cityNameCorrected;
    }

    public boolean isCityNameAliasMatched() {
        return cityNameAliasMatched;
    }

    public boolean isStateCorrected() {
        return stateCorrected;
    }

    public boolean isZipCodeCorrected() {
        return zipCodeCorrected;
    }

    public boolean isSecondaryNumRetained() {
        return secondaryNumRetained;
    }

    public boolean isIdenPreStInfoRetained() {
        return idenPreStInfoRetained;
    }

    public boolean isGenPreStInfoRetained() {
        return genPreStInfoRetained;
    }

    public boolean isPostStInfoRetained() {
        return postStInfoRetained;
    }
}