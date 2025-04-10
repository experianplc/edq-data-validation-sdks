import { randomUUID } from 'crypto';
import { describe, expect, test } from 'vitest';
import { validTokenAddress, validTokenAddressWithEnrichment } from '../testSetup';
import { AddressClient, AddressConfiguration, Countries, Datasets, GlobalGeocodeAttribute, SearchType } from '../index';


describe('Address client tests', async () => {

    test(`Authentication token not supplied throws`, async () => {
        expect(() => new AddressConfiguration("")).toThrow('The supplied configuration must contain an authorisation token');        
    });

    test(`Authentication invalid token throws`, async () => {
        
        const token = "ThisIsNotAValidToken";
        const config = new AddressConfiguration(token, {transactionId: randomUUID(), datasets: [Datasets.AuAddress]});
        const client = new AddressClient(config);
        await expect(client.getDatasets(Countries.UnitedKingdom)).rejects.toThrow("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
        
    });

    test(`timeouts`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
             apiRequestTimeoutInSeconds: 2,
             httpClientTimeoutInSeconds: 3,
             datasets: [Datasets.AuAddress]
            });
        const client = new AddressClient(config);
        const searchResult = await client.search("1 main sqt", SearchType.Autocomplete);
        expect(searchResult.suggestions.length).toBeGreaterThan(0);
    });

    test(`DatasetSearchTypeCombinations. Invalid throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.IeAdditionalEircode]
            });
        const client = new AddressClient(config);
        await expect(client.search("some input", SearchType.Singleline)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`DatasetSearchTypeCombinations. Valid`, async () => {
        
        const configAutoComplete = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence]
            });
        const clientAutocomplete = new AddressClient(configAutoComplete);
        await clientAutocomplete.search("80 Victoria St", SearchType.Autocomplete);

        const configSingleline = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt]
            });
        const clientSingleline = new AddressClient(configSingleline);
        await clientSingleline.search("Experian, Cardinal Place, 80 Victoria St, London", SearchType.Singleline);

        const configTypedown = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAdditionalMultipleresidence, Datasets.GbAdditionalNotyetbuilt]
            });
        const clientTypedown = new AddressClient(configTypedown);
        await clientTypedown.search("London", SearchType.Typedown);


    });

    test(`DatasetSearchTypeCombinations. Valid, but out of order`, async () => {

        const configAutoComplete = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalMultipleresidence]
            });
        const clientAutocomplete = new AddressClient(configAutoComplete);
        await clientAutocomplete.search("80 Victoria St", SearchType.Autocomplete);
    });
        
    test(`DatasetSearchTypeCombinations. Invalid singleline throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAddressWales, Datasets.GbAdditionalNames]
            });
        const client = new AddressClient(config);
        await expect(client.search("Experian, Cardinal Place, 80 Victoria St, London", SearchType.Singleline)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`DatasetSearchTypeCombinations. Invalid autocomplete throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAdditionalBusiness, Datasets.GbAdditionalNames]
            });
        const client = new AddressClient(config);
        await expect(client.search("1 main st,", SearchType.Autocomplete)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`DatasetSearchTypeCombinations. Invalid typedown throws`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAddressAddressbase, Datasets.GbAdditionalNotyetbuilt]
            });
        const client = new AddressClient(config);
        await expect(client.search("London", SearchType.Typedown)).rejects.toThrow("Unsupported dataset / search type combination.");        
    });

    test(`Search attributes, max suggestions`, async () => {

        // Max suggestions set to 20 - should return at most 20 items in the list of suggestions
        const config20 = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAddress],
             maxSuggestions: 20
            });
        const client20 = new AddressClient(config20);
        const searchResult20 = await client20.search("mk65bj", SearchType.Singleline);
        expect(searchResult20.suggestions.length).toEqual(20);

        // Max suggestions set to 5 - should return at most 20 items in the list of suggestions
        const config5 = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.GbAddress],
             maxSuggestions: 5
            });
        const client5 = new AddressClient(config5);
        const searchResult5 = await client5.search("mk65bj", SearchType.Singleline);
        expect(searchResult5.suggestions.length).toEqual(5);
            
    });

    test(`Search attributes, location`, async () => {
        // No location set - default ordering alphabetical
        const configNoLoc = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.UsAddress],
            });
        const clientNoLoc = new AddressClient(configNoLoc);
        const searchResultNoLoc = await clientNoLoc.search("1 main st", SearchType.Autocomplete);
        expect(searchResultNoLoc.suggestions.length).greaterThan(0);
        expect(searchResultNoLoc.suggestions.find(p => {
            return !p.text.includes(" CA ");
        })).toBeDefined();

        // Location set to Los Angeles - search results are weighted towards LA. The list of suggestions contains matching addresses
        // closer to the provided lat/long
        const configLA = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(),              
             datasets: [Datasets.UsAddress],
             location: "34.052235, -118.243683"
            });
        const clientLA = new AddressClient(configLA);
        const searchResultLA = await clientLA.search("1 main st", SearchType.Autocomplete);
        expect(searchResultLA.suggestions.length).greaterThan(0);
         // Ensure all results are in the state of California
        expect(searchResultLA.suggestions.every(p => {
            return p.text.includes(" CA ");
        })).toBeDefined();
    });

    test(`Search address autocomplete`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), {transactionId: randomUUID(), datasets:[Datasets.AuAddress], maxSuggestions:20});
        const client = new AddressClient(config);
        const searchResult = await client.search("56 Queens R");

        expect(searchResult.suggestions.length).toBeGreaterThan(0);

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
        const formatResult = await client.format(globalAddressKey);
        expect(formatResult.confidence).toBe("VerifiedMatch");
        expect(formatResult.globalAddressKey).toBeDefined();
        
    });

    test(`Search address singleline`, async () => {

        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.AuAddress], 
            maxSuggestions:20});
        const client = new AddressClient(config);
        const searchResult = await client.search("56 Queens R", SearchType.Singleline);
        expect(searchResult.suggestions.length).toBeGreaterThan(0);

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
        const formatResult = await client.format(globalAddressKey);
        expect(formatResult.confidence).toBe("VerifiedMatch");
        expect(formatResult.globalAddressKey).toBeDefined();
    });

    test(`Search address typedown`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.GbAddress], 
            maxSuggestions:20});

        const client = new AddressClient(config);
        let searchResult = await client.search("mk65bj", SearchType.Typedown);
        expect(searchResult.suggestions.length).toBeGreaterThan(0);

        while (searchResult.suggestions.some(suggestion => 
            suggestion.additionalAttributes?.some(attr => attr.name === "can_step_in" && attr.value === "true"))) {
            
            const stepInSuggestion = searchResult.suggestions.find(suggestion => 
                suggestion.additionalAttributes?.some(attr => attr.name === "can_step_in" && attr.value === "true"));

            if (stepInSuggestion) {
                searchResult = await client.suggestionsStepIn(stepInSuggestion.globalAddressKey);
            }
        }
     }, 10000);

     test(`Suggestions refine`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.AuAddress],        
        });
        
        const client = new AddressClient(config);
        let searchResult = await client.search("melbourne", SearchType.Typedown);
        expect(searchResult.suggestions.length).toBeGreaterThan(0);
        searchResult = await client.suggestionsStepIn(searchResult.suggestions[0].globalAddressKey);

        // Ensure an informational picklist was returned that prompts for more user input
        expect(searchResult.suggestions.length).toBeGreaterThan(0);
        expect(searchResult.suggestions[0].additionalAttributes?.some(attr => attr.name === "information" && attr.value === "true")).toBeTruthy();

        // Use the user input to refine the list of suggestions
         searchResult = await client.suggestionsRefine(searchResult.suggestions[0].globalAddressKey, "ro");

         expect(searchResult.suggestions.length).toBeGreaterThan(0);
         expect(searchResult.suggestions.every(suggestion => suggestion.text.toLowerCase().startsWith("ro"))).toBeTruthy();

     });

     test(`Suggestions format`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.GbAddress],        
        });

        const client = new AddressClient(config);
        const searchResult = await client.suggestionsFormat("160, SE1 8EZ");

        expect(searchResult.suggestions).not.toHaveLength(0);
        expect(searchResult.suggestions.every(x => x.address !== null)).toBeTruthy();
        expect(searchResult.suggestions.every(x => x.addressFormatted)).toBeUndefined
        
     });

    test(`Validate address`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.AuAddress]
        });
        const client = new AddressClient(config);
        const result = await client.validate(["Unit 1, 8 Main Ave, Lidcombe, 2141"]);

        expect(result.confidence).toEqual("VerifiedMatch");
        expect(result.address).not.toBeNull();
        expect(result.address?.addressLine1).toEqual("U 1  8 Main Ave");
        expect(result.address?.addressLine2).toBe("");
        expect(result.address?.addressLine3).toBe("");
        expect(result.address?.locality).toEqual("LIDCOMBE");
        expect(result.address?.region).toEqual("NSW");
        expect(result.address?.postalCode).toEqual("2141");
        expect(result.address?.country).toEqual("AUSTRALIA");

    });

    test(`Datasets - valid`, async () => {
        const config = new AddressConfiguration(validTokenAddress(), {transactionId: randomUUID(), datasets:[Datasets.GbAddress]});
        const client = new AddressClient(config);
        const result = await client.getDatasets(Countries.UnitedKingdom);
        expect(result.result).toBeDefined();
        expect(result.result?.every(ds => ds.country === Countries.UnitedKingdom)).true;

    });

    test(`Format - with metadata`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.GbAddress],
            includeMetadata: true
        });
        const client = new AddressClient(config);

        // Search
        const searchResult = await client.search("Experian", SearchType.Autocomplete);

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;

        // Format with default layout
        const formatted = await client.format(globalAddressKey);

        expect(formatted).toBeDefined();
        expect(formatted.metadata).toBeDefined();
        expect(formatted.metadata?.udprn).toBeDefined();
        expect(formatted.metadata?.pafAddressKey).toBeDefined();

    });

    test(`Format - with components`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.GbAddress],
            includeComponents: true
        });
        const client = new AddressClient(config);

        // Search
        const searchResult = await client.search("Experian", SearchType.Autocomplete);

        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;

        // Format with default layout
        const formatted = await client.format(globalAddressKey);

        expect(formatted).toBeDefined();
        expect(formatted.components?.organization).toBeDefined();
        expect(formatted.components?.organization?.companyName).toBeDefined();
        expect(formatted.components?.street).toBeDefined();
        expect(formatted.components?.street?.fullName).toBeDefined();

    });

    test(`Search Address - autocomplete additional datasets`, async () => {
        const config = new AddressConfiguration(
            validTokenAddress(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.GbAdditionalMultipleresidence]            
        });
        const client = new AddressClient(config);
        const result = await client.search("flat 3, block a, oxford court, 23 stretford road, manchester, m15 6dd");

        expect(result.suggestions.some(p => p.dataset === "Multiple Residence")).toBeTruthy();
    });

    test(`Format with enrichment - select all elements from enrichment list`, async () => {

        const config = new AddressConfiguration(
            validTokenAddressWithEnrichment(), 
            {transactionId: randomUUID(), 
            datasets:[Datasets.GbAddress],
            includeEnrichment: true,
            globalGeocodes: Object.values(GlobalGeocodeAttribute)
        });
        const client = new AddressClient(config);
        const searchResult = await client.search("Experian", SearchType.Autocomplete);
        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
         // Format with default layout
         const formatted = await client.format(globalAddressKey);
         expect(formatted).toBeDefined();
        expect(formatted.enrichment).toBeDefined();
        expect(formatted.enrichment?.geocodes).toBeDefined();
        expect(formatted.enrichment?.geocodes?.latitude).toBeDefined();
        expect(formatted.enrichment?.geocodes?.longitude).toBeDefined();
        expect(formatted.enrichment?.geocodes?.matchLevel).toBe("Place");

    }, 30000);

    test(`Format with enrichment - select specific element from enrichment list`, async () => {

        const config = new AddressConfiguration(
            validTokenAddressWithEnrichment(),
            {transactionId: randomUUID(), 
            datasets:[Datasets.GbAddress],
            includeEnrichment: true,
            globalGeocodes: [GlobalGeocodeAttribute.Latitude, GlobalGeocodeAttribute.Longitude]
        });
        const client = new AddressClient(config);
        const searchResult = await client.search("Experian", SearchType.Autocomplete);
        // Pick the first one
        const globalAddressKey = searchResult.suggestions[0].globalAddressKey;
         // Format with default layout
         const formatted = await client.format(globalAddressKey);
         expect(formatted).toBeDefined();
        expect(formatted.enrichment).toBeDefined();
        expect(formatted.enrichment?.geocodes).toBeDefined();
        expect(formatted.enrichment?.geocodes?.latitude).toBeDefined();
        expect(formatted.enrichment?.geocodes?.longitude).toBeDefined();
        // MatchLevel should be null as attribute was not requested
        expect(formatted.enrichment?.geocodes?.matchLevel).toBeUndefined();

    });
});