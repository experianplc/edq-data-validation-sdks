using DVSClient.Address.Format.Enrichment;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class AddressEnrichment
    {
        public string? TransactionId { get; }
        public Geocodes? Geocodes { get; }
        public UsaRegionalGeocodes? UsaRegionalGeocodes { get; }
        public AusRegionalGeocodes? AusRegionalGeocodes { get; }
        public NzlRegionalGeocodes? NzlRegionalGeocodes { get; }
        public UKLocationComplete? GbrLocationComplete { get; }
        public UKLocationEssential? GbrLocationEssential { get; }
        public GbrGovernment? GbrGovernment { get; }
        public GbrBusiness? GbrBusiness { get; }
        public GbrHealth? GbrHealth { get; }
        public Metadata? Metadata { get; }

        public AddressEnrichment(RestApiAddressFormatEnrichment apiAddressFormatEnrichment)
        {
            TransactionId = apiAddressFormatEnrichment.TransactionId ?? string.Empty;

            var result = apiAddressFormatEnrichment.Result;
            Geocodes = result?.Geocodes != null ? new Geocodes(result.Geocodes) : null;
            UsaRegionalGeocodes = result?.UsaRegionalGeocodes != null ? new UsaRegionalGeocodes(result.UsaRegionalGeocodes) : null;
            AusRegionalGeocodes = result?.AusRegionalGeocodes != null ? new AusRegionalGeocodes(result.AusRegionalGeocodes) : null;
            NzlRegionalGeocodes = result?.NzlRegionalGeocodes != null ? new NzlRegionalGeocodes(result.NzlRegionalGeocodes) : null;
            GbrLocationComplete = result?.GbrLocationComplete != null ? new UKLocationComplete(result.GbrLocationComplete) : null;
            GbrLocationEssential = result?.GbrLocationEssential != null ? new UKLocationEssential(result.GbrLocationEssential) : null;
            GbrGovernment = result?.GbrGovernment != null ? new GbrGovernment(result.GbrGovernment) : null;
            GbrBusiness = result?.GbrBusiness != null ? new GbrBusiness(result.GbrBusiness) : null;
            GbrHealth = result?.GbrHealth != null ? new GbrHealth(result.GbrHealth) : null;

            var apiEnrichmentMetadata = apiAddressFormatEnrichment.Metadata;
            Metadata = apiEnrichmentMetadata != null ? new Metadata(apiEnrichmentMetadata) : null;
        }
    }
}