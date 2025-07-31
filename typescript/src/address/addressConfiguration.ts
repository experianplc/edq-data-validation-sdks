import { Dataset } from './dataset';
import { Intensity } from './intensity';
import { AusRegionalGeocodeAttribute } from './layout/attributes/ausRegionalGeocodeAttribute';
import { GlobalGeocodeAttribute } from './layout/attributes/globalGeocodeAttribute';
import { What3WordsAttribute } from './layout/attributes/what3WordsAttribute';
import { LayoutFormat } from './layout/layoutFormat';
import { PremiumLocationInsightAttribute } from './layout/attributes/premiumLocationInsightAttribute';
import { PromptSet } from './promptSet';
import { GbrLocationEssentialAttribute } from './layout/attributes/gbrLocationEssentialAttribute';
import { GbrLocationCompleteAttribute } from './layout/attributes/gbrLocationCompleteAttribute';
import { GbrBusinessAttribute } from './layout/attributes/gbrBusinessAttribute';
import { GbrGovernmentAttribute } from './layout/attributes/gbrGovernmentAttribute';
import { GbrHealthAttribute } from './layout/attributes/gbrHealthAttribute';
import { NzlRegionalGeocodeAttribute } from './layout/attributes/nzlRegionalGeocodeAttribute';
import { UsaRegionalGeocodeAttribute } from './layout/attributes/usaRegionalGeocodeAttribute';
import { Configuration, ConfigurationOptions } from '../common/configuration';
import { EDVSError } from '../exceptions/edvsException';
import { LookupLocality } from './lookup/lookupLocality';
import { LookupPostalCode } from './lookup/lookupPostalCode';

/**
 * Interface defining the options for configuring the Address client.
 */
export interface AddressConfigurationOptions extends ConfigurationOptions {
    transliterate?: boolean;
    datasets?: Dataset[];
    maxSuggestions?: number;
    location?: string;
    flattenResults?: boolean;
    searchIntensity?: Intensity;
    promptSet?: PromptSet;
    includeComponents?: boolean;
    includeMetadata?: boolean;
    includeEnrichment?: boolean;
    includeExtraMatchInfo?: boolean;
    layoutName?: string;
    layoutFormat?: LayoutFormat;
    globalGeocodes?: GlobalGeocodeAttribute[];
    premiumLocationInsights?: PremiumLocationInsightAttribute[];
    what3Words?: What3WordsAttribute[];
    ausRegionalGeocodes?: AusRegionalGeocodeAttribute[];
    gbrLocationEssential?: GbrLocationEssentialAttribute[];
    gbrLocationComplete?: GbrLocationCompleteAttribute[];
    gbrBusiness?: GbrBusinessAttribute[];
    gbrGovernment?: GbrGovernmentAttribute[];
    gbrHealth?: GbrHealthAttribute[];
    nzlRegionalGeocodes?: NzlRegionalGeocodeAttribute[];
    usaRegionalGeocodes?: UsaRegionalGeocodeAttribute[];
    lookup? : {
        attributes?: {
            localityLookup?: LookupLocality[];
            postalCodeLookup?: LookupPostalCode[];
        },
        addAddresses?: boolean,
        maxAddresses?: number;
        addFinalAddress?: boolean
    }
}

/**
 * Configuration class for setting up the Address client.
 * Provides options for customizing address-related API requests.
 */
export class AddressConfiguration extends Configuration {

    public static readonly defaultMaxSuggestions = 7;
    public static readonly defaultLayoutName = "default";
    public static readonly defaultLayoutFormat = LayoutFormat.Default;
    public options: AddressConfigurationOptions = {};

    /**
     * Initializes a new instance of the {@link AddressConfiguration} class with the specified token and options.
     *
     * @param token   The authentication token for the API.
     * @param options The configuration options for the Address client.
     */
    constructor(token: string, options: AddressConfigurationOptions = {}) {
        const defaultedOptions = AddressConfiguration.applyDefaultOptions(options);
        super(token, defaultedOptions);
        this.options = defaultedOptions;
    }

    /**
     * Applies default values to the provided configuration options.
     *
     * @param options The configuration options to apply defaults to.
     * @return The configuration options with default values applied.
     */
    protected static applyDefaultOptions(options: AddressConfigurationOptions): AddressConfigurationOptions {
        const baseResult = super.applyDefaultOptions(options);
        const result = { ...options, ...baseResult };

        if (!result.maxSuggestions) {
            result.maxSuggestions = AddressConfiguration.defaultMaxSuggestions;
        }
        if (!result.layoutFormat) {
            result.layoutFormat = AddressConfiguration.defaultLayoutFormat;
        }
        if (!result.layoutName) {
            result.layoutName = AddressConfiguration.defaultLayoutName;
        }

        return result;
    }

    public validateDatasetCountry() {
        //Datasets must all be for the same underlying country
        const datasets = this.options.datasets;
        if (datasets) {
            if (datasets.length === 1) {
                return;
            } else if (datasets.length > 1) {
                // Validate that the country code for all datasets is the same as the first one
                const firstCountryCode = datasets[0].country.iso3Code;
                const allSameCountry = datasets.every(dataset => dataset.country.iso3Code === firstCountryCode);
                if (!allSameCountry) {
                    throw new EDVSError("All datasets must belong to the same country.");
                }
            }
        }
    }
}
