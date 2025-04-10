import { afterAll, beforeAll, describe, expect, test } from 'vitest';
import { LayoutConfiguration } from './layoutConfiguration';
import { existingTestLayout, testLayoutPrefix, validTokenAddress } from '../../testSetup';
import { LayoutClient } from './layoutClient';
import { GetLayoutLayout } from './getLayoutLayout';
import { LayoutLineVariable } from './layoutLineVariable';
import { LayoutLineFixed } from './layoutLineFixed';
import { AusAddressElements } from './elements/ausAddressElements';
import { Datasets } from '../dataset';
import { CreateLayoutResult } from './createLayoutResult';
import { EDVSError } from '../../exceptions/edvsException';
import { AddressLayoutStatus } from './addressLayoutStatus';
import { randomUUID } from 'crypto';
import { AddressConfiguration } from '../addressConfiguration';
import { AusRegionalGeocodeAttribute } from './attributes/ausRegionalGeocodeAttribute';
import { AddressClient } from '../addressClient';
import { SearchType } from '../searchType';
import { GbrAddressElements } from './elements/gbrAddressElements';


describe('Address client tests', () => {

    
    beforeAll(async () => {
        try {
            const layout = await getLayout(existingTestLayout);
            if (layout.status !== AddressLayoutStatus.Completed) {
                expect.fail(`The layout ${existingTestLayout} is not complete. Please wait for it to complete before running these tests (can be 10 minutes or so)`);
            }
        } catch (err: unknown) {
            if (err instanceof EDVSError && err.message === "Not Found") {
                //Doesn't exist so we need to create it
                await createTestLayout();
                expect.fail(`The layout ${existingTestLayout} did not exist. This has now been created but you will need to wait for the creation to complete (can be 10 minutes or so))`);
            } else {
                throw err;
            }
        }
    });

    afterAll(async () => {
        await deleteTestLayouts();
    });

    test(`Get Layout`, async () => {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const result = await client.getLayout(existingTestLayout);
        expect(result.id.length).toBeGreaterThan(0);
    });
    
    

    test(`Create Layout`, async () => {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const line1: LayoutLineVariable = {name: "addr_line_1"};
        const line2: LayoutLineVariable = {name:"addr_line_2"};
        const line3: LayoutLineFixed = {name: "post_code", elements: [AusAddressElements.PostalCode]};
        const line4: LayoutLineFixed = {name: "country_name", elements: [AusAddressElements.CountryName]};
        const layoutName = getUniqueLayoutName();
        
        const result = await client.createLayout(layoutName, [{datasets: [Datasets.AuAddress]}], [line1, line2], [line3, line4]);
        expect(result.id.length).toBeGreaterThan(0);
        const getResult = await client.getLayout(layoutName);
        expect(getResult).toBeDefined();
        expect(getResult.name).toEqual(layoutName);
    });
    
    test(`Format with custom layout and components`, async () => {
        const addressConfig = new AddressConfiguration(validTokenAddress(),{
            transactionId: randomUUID(),
            datasets: [Datasets.GbAddress],
            formatLayoutName: existingTestLayout,
            includeComponents: true,
        });
        const addrClient = new AddressClient(addressConfig);
        const searchResultAutoComplete = await addrClient.search("56 Queens R", SearchType.Autocomplete);
        const formatResult = await addrClient.format(searchResultAutoComplete.suggestions[0].globalAddressKey);
        expect(formatResult.confidence).toBe("VerifiedMatch");
        //expect(formatResult.globalAddressKey).toEqual(searchResultAutoComplete.suggestions[0].globalAddressKey);
        expect(formatResult.addressFormatted).toBeDefined();
        expect(formatResult.addressFormatted?.layoutName).toEqual(existingTestLayout);
        expect(formatResult.addressFormatted?.notEnoughLines).toBeFalsy();
        expect(formatResult.addressFormatted?.hasTruncatedLines).toBeFalsy();
        
        const addressEntries = Object.entries(formatResult.addressFormatted?.address || {});
        expect(addressEntries.length).toEqual(4);
        const addrLine1 = formatResult.addressFormatted?.address["addr_line_1"];
        expect(addrLine1).toBeDefined();
        expect(addrLine1?.length).toBeGreaterThan(0);
        const addrLine2 = formatResult.addressFormatted?.address["addr_line_2"];
        expect(addrLine2).toBeDefined();
        expect(addrLine2?.length).toBeGreaterThan(0);
        const postode = formatResult.addressFormatted?.address["post_code"];
        expect(postode).toBeDefined();
        expect(postode?.length).toBeGreaterThan(0);
        const countryName = formatResult.addressFormatted?.address["country_name"];
        expect(countryName).toBeDefined();
        expect(countryName?.length).toBeGreaterThan(0);
                
    });

    async function createTestLayout(): Promise<CreateLayoutResult> {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const line1: LayoutLineVariable = {name: "addr_line_1"};
        const line2: LayoutLineVariable = {name:"addr_line_2"};
        const line3: LayoutLineFixed = {name: "post_code", elements: [AusAddressElements.PostalCode, GbrAddressElements.Postcode]};
        const line4: LayoutLineFixed = {name: "country_name", elements: [AusAddressElements.CountryName, GbrAddressElements.Country]};
        const layoutName = existingTestLayout;
        
        return client.createLayout(layoutName, [{datasets: [Datasets.AuAddress]}, {datasets: [Datasets.GbAddress]}], [line1, line2], [line3, line4]);

    }
    

    async function deleteTestLayouts(): Promise<void> {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const layouts = await client.getLayouts([], testLayoutPrefix);

        for (const layout of layouts) {
            if (layout.name !== existingTestLayout && layout.status === AddressLayoutStatus.Completed) {
                try {
                    await client.deleteLayout(layout.name);
                } catch {
                    console.error(`Failed to delete layout: ${layout.name}`);
                }
            }
        }
    }

    function getLayout(layoutName: string): Promise<GetLayoutLayout> {            
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        return client.getLayout(layoutName);
    }

    function getUniqueLayoutName() {
        return testLayoutPrefix + randomUUID();
    }
});
