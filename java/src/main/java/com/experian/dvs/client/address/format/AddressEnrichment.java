package com.experian.dvs.client.address.format;

import com.experian.dvs.client.address.format.enrichment.*;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatEnrichment;
import com.experian.dvs.client.server.address.format.RestApiEnrichmentMetadata;
import com.experian.dvs.client.server.address.format.RestApiEnrichmentResultAddress;

import java.util.Objects;
import java.util.Optional;

public class AddressEnrichment {

    private final String transactionId;
    private final Geocodes geocodes;
    private final UsaRegionalGeocodes usaRegionalGeocodes;
    private final AusRegionalGeocodes ausRegionalGeocodes;
    private final NzlRegionalGeocodes nzlRegionalGeocodes;
    private final UKLocationComplete ukLocationComplete;
    private final UKLocationEssential ukLocationEssential;
    private final GbrGovernment gbrGovernment;
    private final GbrBusiness gbrBusiness;
    private final GbrHealth gbrHealth;
    private final Metadata metadata;

    public AddressEnrichment(RestApiAddressFormatEnrichment apiAddressFormatEnrichment) {
        this.transactionId = Objects.toString(apiAddressFormatEnrichment.getTransactionId(), "");
        final RestApiEnrichmentResultAddress result = apiAddressFormatEnrichment.getResult();
        if (result != null) {
            this.geocodes = result.getGeocodes() != null ? new Geocodes(result.getGeocodes()) : null;
            this.usaRegionalGeocodes = result.getUsaRegionalGeocodes() != null ? new UsaRegionalGeocodes(result.getUsaRegionalGeocodes()) : null;
            this.ausRegionalGeocodes = result.getAusRegionalGeocodes() != null ? new AusRegionalGeocodes(result.getAusRegionalGeocodes()) : null;
            this.nzlRegionalGeocodes = result.getNzlRegionalGeocodes() != null ? new NzlRegionalGeocodes(result.getNzlRegionalGeocodes()) : null;
            this.ukLocationComplete = result.getUkLocationComplete() != null ? new UKLocationComplete(result.getUkLocationComplete()) : null;
            this.ukLocationEssential = result.getUkLocationEssential() != null ? new UKLocationEssential(result.getUkLocationEssential()) : null;
            this.gbrGovernment = result.getGbrGovernment() != null ? new GbrGovernment(result.getGbrGovernment()) : null;
            this.gbrBusiness = result.getGbrBusiness() != null ? new GbrBusiness(result.getGbrBusiness()) : null;
            this.gbrHealth = result.getGbrHealth() != null ? new GbrHealth(result.getGbrHealth()) : null;
        } else {
            this.geocodes = null;
            this.usaRegionalGeocodes = null;
            this.ausRegionalGeocodes = null;
            this.nzlRegionalGeocodes = null;
            this.ukLocationComplete = null;
            this.ukLocationEssential = null;
            this.gbrGovernment = null;
            this.gbrBusiness = null;
            this.gbrHealth = null;
        }
        final RestApiEnrichmentMetadata apiEnrichmentMetadata = apiAddressFormatEnrichment.getMetadata();
        if (apiEnrichmentMetadata != null) {
            this.metadata = new Metadata(apiEnrichmentMetadata);
        } else {
            this.metadata = null;
        }
    }

    public String getTransactionId() {
        return transactionId;
    }

    public Optional<Geocodes> getGeocodes() {
        return Optional.ofNullable(geocodes);
    }

    public Optional<UsaRegionalGeocodes> getUsaRegionalGeocodes() {
        return Optional.ofNullable(usaRegionalGeocodes);
    }

    public Optional<AusRegionalGeocodes> getAusRegionalGeocodes() {
        return Optional.ofNullable(ausRegionalGeocodes);
    }

    public Optional<NzlRegionalGeocodes> getNzlRegionalGeocodes() {
        return Optional.ofNullable(nzlRegionalGeocodes);
    }

    public Optional<UKLocationComplete> getUkLocationComplete() {
        return Optional.ofNullable(ukLocationComplete);
    }

    public Optional<UKLocationEssential> getUkLocationEssential() {
        return Optional.ofNullable(ukLocationEssential);
    }

    public Optional<GbrGovernment> getGbrGovernment() {
        return Optional.ofNullable(gbrGovernment);
    }

    public Optional<GbrBusiness> getGbrBusiness() {
        return Optional.ofNullable(gbrBusiness);
    }

    public Optional<GbrHealth> getGbrHealth() {
        return Optional.ofNullable(gbrHealth);
    }
}
