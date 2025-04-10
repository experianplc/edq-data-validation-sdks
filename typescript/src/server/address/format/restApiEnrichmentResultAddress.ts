import { RestApiEnrichmentAusRegionalGeocodes } from "./restApiEnrichmentAusRegionalGeocodes";
import { RestApiEnrichmentDatasetGeocodes } from "./restApiEnrichmentDatasetGeocodes";
import { RestApiEnrichmentGbAdditional } from "./restApiEnrichmentGbAdditional";
import { RestApiEnrichmentGbrGovernment } from "./restApiEnrichmentGbrGovernment";
import { RestApiEnrichmentGbrHealth } from "./restApiEnrichmentGbrHealth";
import { RestApiEnrichmentNzlRegionalGeocodes } from "./restApiEnrichmentNzlRegionalGeocodes";
import { RestApiEnrichmentUKLocationComplete } from "./restApiEnrichmentUKLocationComplete";
import { RestApiEnrichmentUKLocationEssential } from "./restApiEnrichmentUKLocationEssential";
import { RestApiEnrichmentUsaRegionalGeocodes } from "./restApiEnrichmentUsaRegionalGeocodes";
import { RestApiEnrichmentWhat3Words } from "./restApiEnrichmentWhat3Words";
import { RestApiPremiumLocationInsight } from "./restApiPremiumLocationInsight";

export type RestApiEnrichmentResultAddress = {
    geocodes?: RestApiEnrichmentDatasetGeocodes;
    usa_regional_geocodes?: RestApiEnrichmentUsaRegionalGeocodes;
    aus_regional_geocodes?: RestApiEnrichmentAusRegionalGeocodes;
    nz_regional_geocodes?: RestApiEnrichmentNzlRegionalGeocodes;
    uk_location_complete?: RestApiEnrichmentUKLocationComplete;
    uk_location_essential?: RestApiEnrichmentUKLocationEssential;
    gbr_government?: RestApiEnrichmentGbrGovernment;
    gbr_business?: RestApiEnrichmentGbAdditional;
    gbr_health?: RestApiEnrichmentGbrHealth;
    premium_location_insight?: RestApiPremiumLocationInsight;
    what3words?: RestApiEnrichmentWhat3Words;
};