import { describe, expect, test, vi } from 'vitest';
import { staticReferenceId, validTokenAddress, validTokenAddressWithEnrichment, GenerateUniqueReferenceId } from '../testSetup';
import { AddressClient, AddressConfiguration, Countries, Datasets, GlobalGeocodeAttribute, SearchType } from '../index';
import { LookupType } from './lookup/lookupType';
import { AusRegionalGeocodeAttribute } from './layout/attributes/ausRegionalGeocodeAttribute';
import { v4 as uuidv4 } from 'uuid';

describe('Address client tests', async () => {

    test(`Authentication token not supplied throws`, async () => {
        expect(() => new AddressConfiguration("")).toThrow('The supplied configuration must contain an authorisation token');        
    });

    test(`Authentication invalid token throws`, async () => {
        
        const token = "ThisIsNotAValidToken";
        const config = new AddressConfiguration(token, {transactionId: GenerateUniqueReferenceId(), datasets: [Datasets.AuAddress]});
        const client = new AddressClient(config);
        await expect(client.getDatasets(Countries.UnitedKingdom)).rejects.toThrow("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
        
    });
    
    test(`test`, async () => {
        // Create configuration object based on tests and requirements
        const config = new AddressConfiguration('your-authentication-token', {
            transactionId: uuidv4(),
            datasets: [Datasets.UsAddress],
            globalGeocodes: Object.values(GlobalGeocodeAttribute),
            // Intensity is 'Close' by default, so no need to set it explicitly
            // Layout name is '', so no need to set it explicitly
        });

        // Create the client with the configuration
        const client = new AddressClient(config);

        // Perform a search with the country 'us' and dataset 'us-address'
        const searchResult = await client.search({
            searchInput: '1600 Pennsylvania Ave NW',
            searchType: SearchType.Autocomplete,
            referenceId: uuidv4(),
        });

        if (searchResult.suggestions.length === 0) {
            console.log('No suggestions found');
            return;
        }

        // Pick the first suggestion's globalAddressKey
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;

        // Format the address using the globalAddressKey and a new transaction ID
        const formattedAddress = await client.format(globalAddressKey, uuidv4());

        console.log('Formatted Address:', formattedAddress);
    )};

    test(`Reference ID - setting on builder works`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        const config = new AddressConfiguration(
            validTokenAddress(),
            {
                transactionId: staticReferenceId,
                datasets: [Datasets.GbAddress]
            }

        );
        const client = new AddressClient(config);
        const result = await client.validate("experian, nottingham, NG80 1ZZ");

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method takes precedence`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        const config = new AddressConfiguration(
            validTokenAddress(),
            {
                transactionId: GenerateUniqueReferenceId(),
                datasets: [Datasets.GbAddress]
            }
        );
        const client = new AddressClient(config);
        const result = await client.validate("experian, nottingham, NG80 1ZZ", staticReferenceId);

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(),
            {
                datasets: [Datasets.GbAddress],
            }
        );

        const client = new AddressClient(config);

        // Checking setting ID on all address methods is supported
        let validateResult = await client.validate("experian, nottingham, NG80 1ZZ", staticReferenceId);
        expect(validateResult.referenceId).toBe(staticReferenceId);

        let lookupResult = await client.lookup("SW40JT", LookupType.PostalCode, staticReferenceId);
        expect(lookupResult.referenceId).toBe(staticReferenceId);

        const searchResult = await client.search({
            searchInput: "experian, nottingham, NG80 1ZZ",
            referenceId: staticReferenceId,
        });
        expect(searchResult.referenceId).toBe(staticReferenceId);

        const formatResult = await client.format(searchResult.suggestions[0].globalAddressKey, staticReferenceId);
        expect(formatResult.referenceId).toBe(staticReferenceId);

        const suggestionsFormatResult = await client.suggestionsFormat("160, SE1 8EZ", staticReferenceId);
        expect(suggestionsFormatResult.referenceId).toBe(staticReferenceId);

        let typedownResult = await client.search({
            searchInput: "mk65bj",
            searchType: SearchType.Typedown,
            referenceId: GenerateUniqueReferenceId()
        });
        let suggestionsStepinResult = await client.suggestionsStepIn(typedownResult.suggestions[0].globalAddressKey, staticReferenceId);
        expect(suggestionsStepinResult.referenceId).toBe(staticReferenceId);

        suggestionsStepinResult = await client.suggestionsStepIn(suggestionsStepinResult.suggestions[0].globalAddressKey, GenerateUniqueReferenceId());
        const suggestionsRefinementResult = await client.suggestionsRefine(suggestionsStepinResult.suggestions[0].globalAddressKey, "30", staticReferenceId);
        expect(suggestionsRefinementResult.referenceId).toBe(staticReferenceId);

        const datasetsResult = await client.getDatasets(Countries.UnitedKingdom, staticReferenceId);
        expect(datasetsResult.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - defaults to random guid`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(),
            {
                datasets: [Datasets.GbAddress]
            }
        );

        const client = new AddressClient(config);
        const result = await client.validate("experian, nottingham, NG80 1ZZ", GenerateUniqueReferenceId());

        expect(result.referenceId).toBeDefined();
    });
    
    test(`Lookup with no datasets throws`, async () => {
        const config = new AddressConfiguration(validTokenAddress())
        
            const client = new AddressClient(config);
            await expect(client.lookup("SW1E 5JL", LookupType.PostalCode, GenerateUniqueReferenceId())).rejects.toThrow("No datasets have been supplied in the configuration.");        
            
    });

    test(`Lookup with datasets from different countries throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAddress, Datasets.AuAddress]
            })
        
            const client = new AddressClient(config);
            await expect(client.lookup("SW1E 5JL", LookupType.PostalCode, GenerateUniqueReferenceId())).rejects.toThrow("All datasets must belong to the same country.");        

    });

    test(`Lookup with no options`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAddress]
            })
        const client = new AddressClient(config);
        const result = await client.lookup("SW1E 5JL", LookupType.PostalCode, GenerateUniqueReferenceId());
        expect(result.confidence).toEqual("NoMatches");
        expect(result.moreResultsAvailable).toBeFalsy();
        expect(result.suggestions?.length).toEqual(1);
        expect(result.suggestions![0].locality?.region?.name).toEqual("England");
        expect(result.suggestions![0].locality?.subRegion?.name).toEqual("Greater London");
        expect(result.suggestions![0].locality?.town?.name).toEqual("London");
        expect(result.suggestions![0].localityKey?.length).toBeGreaterThan(0);
        expect(result.suggestions![0].postalCodeKey?.length).toBeGreaterThan(0);
        expect(result.suggestions![0].postalCode?.fullName).toEqual("SW1E 5JL");
    });

    test(`Lookup with options`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAddress]
            })
        let client = new AddressClient(config);
        let result = await client.lookup("SW1E 5", LookupType.PostalCode, GenerateUniqueReferenceId());
        expect(result.confidence).toEqual("NoMatches");
        
        //Number of suggestions should be the default max of 7        
        expect(result.suggestions?.length).toEqual(7);
        
        //Test max suggestions of 3
        config.options.maxSuggestions = 3;
        client = new AddressClient(config);
        result = await client.lookup("SW1E 5", LookupType.PostalCode, GenerateUniqueReferenceId());
        expect(result.suggestions?.length).toEqual(3);

        //Add address and final address
        config.options.lookup = {
            addAddresses: true,
            addFinalAddress: true
        }
        client = new AddressClient(config);
        result = await client.lookup("SW1E 5", LookupType.PostalCode, GenerateUniqueReferenceId());
        //There should be the default 100 addresses
        expect(result.addresses?.length).toEqual(100);

        //Make that number lower
        config.options.lookup.maxAddresses = 20;
        client = new AddressClient(config);
        result = await client.lookup("SW1E 5", LookupType.PostalCode, GenerateUniqueReferenceId());
        //There should be the default 100 addresses
        expect(result.addresses?.length).toEqual(20);

        //Use a layout
        
        //Uncomment when the token has been sorted out
        
        // config.options.datasets = [Datasets.GbAdditionalElectricity];
        // config.options.layoutName = "ElectricityUtilityLookup";
        // client = new AddressClient(config);
        // result = await client.lookup("1200022547009", LookupType.Mpan);
        // expect(result.addressesFormatted).toBeDefined();
        // expect(result.addressesFormatted![0].layoutName).toEqual("ElectricityUtilityLookup");
        // expect(result.addressesFormatted![0].address?.electricityMeters).toBeDefined();
        // expect(result.addressesFormatted![0].address?.electricityMeters?.length).toEqual(1);
        // expect(result.addressesFormatted![0].address?.electricityMeters![0].mpan).toEqual("1200022547009");
        // expect(result.addressesFormatted![0].address?.electricityMeters![0].addressPostalCode).toEqual("SE20 7EU");        

    }, 30000);

    test(`timeouts`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                apiRequestTimeoutInSeconds: 2,
                httpClientTimeoutInSeconds: 3,
                datasets: [Datasets.AuAddress]
            });
        const client = new AddressClient(config);
        const searchResult = await client.search({
            searchInput: "1 main sqt",
            searchType: SearchType.Autocomplete,
            referenceId: GenerateUniqueReferenceId()});
        expect(searchResult.suggestions.length).toBeGreaterThan(0);
    });

    test(`DatasetSearchTypeCombinations. Invalid throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.IeAdditionalEircode]
            });
        const client = new AddressClient(config);
        await expect(client.search("some input", SearchType.Singleline)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`DatasetSearchTypeCombinations. Valid`, async () => {
        
        const configAutoComplete = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence]
            });
        const clientAutocomplete = new AddressClient(configAutoComplete);
        await clientAutocomplete.search({
            searchInput: "80 Victoria St",
            referenceId: GenerateUniqueReferenceId()
        });

        const configSingleline = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt]
            });
        const clientSingleline = new AddressClient(configSingleline);
        await clientSingleline.search({
            searchInput: "Experian, Cardinal Place, 80 Victoria St, London",
            searchType: SearchType.Singleline,
            referenceId: GenerateUniqueReferenceId()
        });

        const configTypedown = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt]
            });
        const clientTypedown = new AddressClient(configTypedown);
        await clientTypedown.search({
            searchInput: "London",
            searchType: SearchType.Typedown,
            referenceId: GenerateUniqueReferenceId()
        });
    });

    test(`DatasetSearchTypeCombinations. Valid, but out of order`, async () => {

        const configAutoComplete = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence]
            });
        const clientAutocomplete = new AddressClient(configAutoComplete);
        await clientAutocomplete.search("80 Victoria St", SearchType.Autocomplete);
    });
        
    test(`DatasetSearchTypeCombinations. Invalid singleline throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAddressWales, Datasets.GbAdditionalNames]
            });
        const client = new AddressClient(config);
        await expect(client.search("Experian, Cardinal Place, 80 Victoria St, London", SearchType.Singleline)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`DatasetSearchTypeCombinations. Invalid autocomplete throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNames]
            });
        const client = new AddressClient(config);
        await expect(client.search("1 main st,", SearchType.Autocomplete)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`DatasetSearchTypeCombinations. Invalid typedown throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAddressAddressbase, Datasets.GbAdditionalNotyetbuilt]
            });
        const client = new AddressClient(config);
        await expect(client.search("London", SearchType.Typedown)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`Search attributes, max suggestions`, async () => {

        // Max suggestions set to 20 - should return at most 20 items in the list of suggestions
        const config20 = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAddress],
                maxSuggestions: 20
            });
        const client20 = new AddressClient(config20);
        const searchResult20 = await client20.search({
            searchInput: "mk65bj",
            searchType: SearchType.Singleline,
            referenceId: GenerateUniqueReferenceId()
        });
        expect(searchResult20.suggestions.length).toEqual(20);

        // Max suggestions set to 5 - should return at most 20 items in the list of suggestions
        const config5 = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.GbAddress],
                maxSuggestions: 5
            });
        const client5 = new AddressClient(config5);
        const searchResult5 = await client5.search({
            searchInput: "mk65bj",
            searchType: SearchType.Singleline,
            referenceId: GenerateUniqueReferenceId()
        });
        expect(searchResult5.suggestions.length).toEqual(5);
            
    });

    test(`Search attributes, location`, async () => {
        // No location set - default ordering alphabetical
        const configNoLoc = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.UsAddress],
            });
        const clientNoLoc = new AddressClient(configNoLoc);
        const searchResultNoLoc = await clientNoLoc.search("1 main st");
        expect(searchResultNoLoc.suggestions.length).greaterThan(0);
        expect(searchResultNoLoc.suggestions.find(p => {
            return !p.text.includes(" CA ");
        })).toBeDefined();

        // Location set to Los Angeles - search results are weighted towards LA. The list of suggestions contains matching addresses
        // closer to the provided lat/long
        const configLA = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets: [Datasets.UsAddress],
                location: "34.052235, -118.243683"
            });
        const clientLA = new AddressClient(configLA);
        const searchResultLA = await clientLA.search("1 main st");
        expect(searchResultLA.suggestions.length).greaterThan(0);
         // Ensure all results are in the state of California
        expect(searchResultLA.suggestions.every(p => {
            return p.text.includes(" CA ");
        })).toBeDefined();
    });

    
    test(`Search address`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), {datasets:[Datasets.AuAddress], maxSuggestions:20});
        const client = new AddressClient(config);

        const searchObsolete = await client.search("56 Queens R");
        const searchOptions = await client.search({searchInput: "56 Queens R"});
        const searchAllOptions = await client.search({searchInput: "56 Queens R", searchType: SearchType.Autocomplete, referenceId: GenerateUniqueReferenceId() });

        //returns the same results
        expect(searchObsolete.suggestions.length).toBe(searchOptions.suggestions.length);
        expect(searchAllOptions.suggestions.length).toBe(searchOptions.suggestions.length);

        expect(searchObsolete.suggestions[0].globalAddressKey).toBe(searchOptions.suggestions[0].globalAddressKey);
        expect(searchAllOptions.suggestions[0].globalAddressKey).toBe(searchOptions.suggestions[0].globalAddressKey);
    });

    test(`Search address autocomplete`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), {datasets:[Datasets.AuAddress], maxSuggestions:20});
        const client = new AddressClient(config);
        const searchResult = await client.search("56 Queens R");

        expect(searchResult.suggestions.length).toBeGreaterThan(0);

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
        const formatResult = await client.format(globalAddressKey, GenerateUniqueReferenceId());
        expect(formatResult.confidence).toBe("VerifiedMatch");
        expect(formatResult.globalAddressKey).toBeDefined();
        
    });

    test(`Search address singleline`, async () => {

        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets:[Datasets.AuAddress], 
                maxSuggestions:20});
        const client = new AddressClient(config);
        const searchResult = await client.search({
            searchInput: "56 Queens R", 
            searchType: SearchType.Singleline,
            referenceId: GenerateUniqueReferenceId()
        });
        expect(searchResult.suggestions.length).toBeGreaterThan(0);

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
        const formatResult = await client.format(globalAddressKey, GenerateUniqueReferenceId());
        expect(formatResult.confidence).toBe("VerifiedMatch");
        expect(formatResult.globalAddressKey).toBeDefined();
    });

    test(`Search address typedown`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets:[Datasets.GbAddress], 
                maxSuggestions:20});

        const client = new AddressClient(config);
        let searchResult = await client.search("mk65bj", SearchType.Typedown);
        expect(searchResult.suggestions.length).toBeGreaterThan(0);

        const spyOnStepIn = vi.spyOn(client, 'suggestionsStepIn');

        while (searchResult.suggestions.some(suggestion => 
            suggestion.additionalAttributes?.some(attr => attr.name === "can_step_in" && attr.value === "true"))) {
            
            const stepInSuggestion = searchResult.suggestions.find(suggestion => 
                suggestion.additionalAttributes?.some(attr => attr.name === "can_step_in" && attr.value === "true"));

            if (stepInSuggestion) {
                searchResult = await client.suggestionsStepIn(stepInSuggestion.globalAddressKey, GenerateUniqueReferenceId());
            }
        }

        expect(spyOnStepIn).toHaveBeenCalled();
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
        const formatResult = await client.format(globalAddressKey, GenerateUniqueReferenceId());
        expect(formatResult.confidence).toBeDefined
        expect(formatResult.globalAddressKey).toBeDefined();
     }, 10000);

     test(`Suggestions refine`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), {datasets:[Datasets.AuAddress]});
        
        const client = new AddressClient(config);
        let searchResult = await client.search({
            searchInput: "melbourne",
            searchType: SearchType.Typedown,
            referenceId: GenerateUniqueReferenceId()
        });
        expect(searchResult.suggestions.length).toBeGreaterThan(0);
        searchResult = await client.suggestionsStepIn(searchResult.suggestions[0].globalAddressKey, GenerateUniqueReferenceId());

        // Ensure an informational picklist was returned that prompts for more user input
        expect(searchResult.suggestions.length).toBeGreaterThan(0);
        expect(searchResult.suggestions[0].additionalAttributes?.some(attr => attr.name === "information" && attr.value === "true")).toBeTruthy();

        // Use the user input to refine the list of suggestions
        searchResult = await client.suggestionsRefine(searchResult.suggestions[0].globalAddressKey, "ro", GenerateUniqueReferenceId());

        expect(searchResult.suggestions.length).toBeGreaterThan(0);
        expect(searchResult.suggestions.every(suggestion => suggestion.text.toLowerCase().startsWith("ro"))).toBeTruthy();
     });

     test(`Suggestions format`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), {datasets:[Datasets.GbAddress]});

        const client = new AddressClient(config);
        const searchResult = await client.suggestionsFormat("160, SE1 8EZ", GenerateUniqueReferenceId());

        expect(searchResult.suggestions).not.toHaveLength(0);
        expect(searchResult.suggestions.every(x => x.address !== null)).toBeTruthy();
        expect(searchResult.suggestions.every(x => x.addressFormatted)).toBeUndefined
        
     });

    test(`Validate address`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), { datasets:[Datasets.AuAddress] });
        const client = new AddressClient(config);
        const result = await client.validate(["Unit 1, 8 Main Ave, Lidcombe, 2141"], GenerateUniqueReferenceId());

        expect(result.confidence).toEqual("VerifiedMatch");
        expect(result.address).not.toBeNull();
        expect(result.address?.addressLine1).toEqual("U 1  8 Main Ave");
        expect(result.address?.addressLine2).toBe("");
        expect(result.address?.addressLine3).toBe("");
        expect(result.address?.locality).toEqual("LIDCOMBE");
        expect(result.address?.region).toEqual("NSW");
        expect(result.address?.postalCode).toEqual("2141");
        expect(result.address?.country).toEqual("AUSTRALIA");
        expect(result.matchType).toEqual("FullMatchWithPostalCode");
        expect(result.matchConfidence).toEqual("High");
    });

    test(`Validate address. Multiple addresses in response`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), { datasets:[Datasets.AuAddress] });
        const client = new AddressClient(config);
        const result = await client.validate(["Main Ave, Lidcombe, 2141"], GenerateUniqueReferenceId());

        expect(result.address).toBeUndefined();
        expect(result.addressFormatted).toBeUndefined();
        expect(result.suggestions?.length).toBe(7);
        expect(result.suggestionsKey?.length).toBeGreaterThan(0);
        expect(result.suggestionsPrompt).toBe("Enter selection"); 
    });

    test(`Validate address. With components`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets:[Datasets.AuAddress],
                includeComponents: true
            });
        const client = new AddressClient(config);
        const result = await client.validate(["Unit 1, 8 Main Ave, Lidcombe, 2141"], GenerateUniqueReferenceId());

        expect(result.components).toBeDefined();
        expect(result.components?.postalCode).toBeDefined();
        expect(result.components?.postalCode?.fullName).toBe("2141");
        expect(result.components?.street).toBeDefined();
        expect(result.components?.street?.fullName).toBe("Main Ave");
        expect(result.components?.street?.name).toBe("Main");
        expect(result.components?.street?.type).toBe("Ave");
    });

    test(`Validate address. With enrichment`, async () => {
        const config = new AddressConfiguration(
            validTokenAddressWithEnrichment(), 
            {
                datasets:[Datasets.AuAddress],
                includeEnrichment: true,
                ausRegionalGeocodes: Object.values(AusRegionalGeocodeAttribute)
            });
        const client = new AddressClient(config);
        const result = await client.validate(["Unit 1, 8 Main Ave, Lidcombe, 2141"], GenerateUniqueReferenceId());

        expect(result.enrichment).toBeDefined();
        expect(result.enrichment?.ausRegionalGeocodes).toBeDefined();
        expect(result.enrichment?.ausRegionalGeocodes?.latitude).toBeLessThan(0);
        expect(result.enrichment?.ausRegionalGeocodes?.longitude).toBeGreaterThan(0);
    });

    test(`Validate address. With metadata`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets:[Datasets.AuAddress],
                includeMetadata: true,
            });
        const client = new AddressClient(config);
        const result = await client.validate(["Unit 1, 8 Main Ave, Lidcombe, 2141"], GenerateUniqueReferenceId());

        expect(result.metadata).toBeDefined();
        expect(result.metadata?.dpid).toBeDefined();
        expect(result.metadata?.hin).toBeDefined();
    });

    test(`Validate address. With match info`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets:[Datasets.AuAddress],
                includeExtraMatchInfo: true,
            });
        const client = new AddressClient(config);
        const result = await client.validate(["Unit 1, 8 Main Ave, Lidcombe, 2141"], GenerateUniqueReferenceId());

        expect(result.matchInfo).toBeDefined();
        expect(result.matchInfo?.postalCodeAction).toBe("Ok");
        expect(result.matchInfo?.addressAction).toBe("Corrected");
        expect(result.matchInfo?.generic_info).toBeDefined();
        expect(result.matchInfo?.generic_info?.find(item => item === "address_cleaned")).toBeTruthy();
        expect(result.matchInfo?.aus_info).toBeDefined();
        expect(result.matchInfo?.aus_info?.find(item => item === "bsp_state_nsw")).toBeTruthy();

        // All other country infos should be undefined
        expect(result.matchInfo?.gbr_info).toBeUndefined();
    });

    test(`Datasets - valid`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), {datasets:[Datasets.GbAddress]});
        const client = new AddressClient(config);
        const result = await client.getDatasets(Countries.UnitedKingdom, GenerateUniqueReferenceId());
        expect(result.result).toBeDefined();
        expect(result.result?.every(ds => ds.country === Countries.UnitedKingdom)).true;
    });

    test(`Format - with metadata`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets:[Datasets.GbAddress],
                includeMetadata: true
            });
        const client = new AddressClient(config);

        // Search
        const searchResult = await client.search({
            searchInput: "Experian",
            referenceId: GenerateUniqueReferenceId()
        });

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;

        // Format with default layout
        const formatted = await client.format(globalAddressKey, GenerateUniqueReferenceId());

        expect(formatted).toBeDefined();
        expect(formatted.metadata).toBeDefined();
        expect(formatted.metadata?.udprn).toBeDefined();
        expect(formatted.metadata?.pafAddressKey).toBeDefined();
    });

    test(`Format - with components`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {
                datasets:[Datasets.GbAddress],
                includeComponents: true
            });
        const client = new AddressClient(config);

        // Search
        const searchResult = await client.search({
            searchInput: "Experian",
            referenceId: GenerateUniqueReferenceId()
        });

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;

        // Format with default layout
        const formatted = await client.format(globalAddressKey, GenerateUniqueReferenceId());

        expect(formatted).toBeDefined();
        expect(formatted.components?.organization).toBeDefined();
        expect(formatted.components?.organization?.companyName).toBeDefined();
        expect(formatted.components?.street).toBeDefined();
        expect(formatted.components?.street?.fullName).toBeDefined();
    });

    test(`Search Address - autocomplete additional datasets`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), { datasets:[Datasets.GbAdditionalMultipleresidence] });
        const client = new AddressClient(config);
        const result = await client.search({
            searchInput: "flat 3, block a, oxford court, 23 stretford road, manchester, m15 6dd",
            referenceId: GenerateUniqueReferenceId()
        });

        expect(result.suggestions.some(p => p.dataset === "Multiple Residence")).toBeTruthy();
    });

    test(`Format with enrichment - select all elements from enrichment list`, async () => {

        const config = new AddressConfiguration(
            validTokenAddressWithEnrichment(), 
            {
                datasets:[Datasets.GbAddress],
                includeEnrichment: true,
                globalGeocodes: Object.values(GlobalGeocodeAttribute)
            });
        const client = new AddressClient(config);
        const searchResult = await client.search({
            searchInput: "Experian",
            referenceId: GenerateUniqueReferenceId()
        });

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
        // Format with default layout
        const formatted = await client.format(globalAddressKey, GenerateUniqueReferenceId());
        expect(formatted).toBeDefined();
        expect(formatted.enrichment).toBeDefined();
        expect(formatted.enrichment?.geocodes).toBeDefined();
        expect(formatted.enrichment?.geocodes?.latitude).toBeDefined();
        expect(formatted.enrichment?.geocodes?.longitude).toBeDefined();
        expect(formatted.enrichment?.geocodes?.matchLevel).toBe("Place");
    }, 30000);

    test(`Format with enrichment - select specific elements from enrichment list`, async () => {

        const config = new AddressConfiguration(
            validTokenAddressWithEnrichment(), 
            {
                datasets:[Datasets.GbAddress],
                includeEnrichment: true,
                globalGeocodes: [GlobalGeocodeAttribute.Latitude, GlobalGeocodeAttribute.Longitude]
            });
        const client = new AddressClient(config);
        const searchResult = await client.search({
            searchInput: "Experian",
            referenceId: GenerateUniqueReferenceId()
        });
        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
        // Format with default layout
        const formatted = await client.format(globalAddressKey, GenerateUniqueReferenceId());
        expect(formatted).toBeDefined();
        expect(formatted.enrichment).toBeDefined();
        expect(formatted.enrichment?.geocodes).toBeDefined();
        expect(formatted.enrichment?.geocodes?.latitude).toBeDefined();
        expect(formatted.enrichment?.geocodes?.longitude).toBeDefined();
        // MatchLevel should be null as attribute was not requested
        expect(formatted.enrichment?.geocodes?.matchLevel).toBeUndefined();

    }, 30000);
});