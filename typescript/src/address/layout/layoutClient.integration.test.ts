import { afterAll, beforeAll, describe, expect, test } from 'vitest';
import { LayoutConfiguration } from './layoutConfiguration';
import { existingTestLayout, testLayoutPrefix, validTokenAddress, staticReferenceId, GenerateUniqueReferenceId } from '../../testSetup';
import { LayoutClient } from './layoutClient';
import { GetLayoutLayout } from './getLayoutLayout';
import { LayoutLineVariable } from './layoutLineVariable';
import { LayoutLineFixed } from './layoutLineFixed';
import { AusAddressElements } from './elements/ausAddressElements';
import { Datasets } from '../dataset';
import { CreateLayoutResult } from './createLayoutResult';
import { EDVSError } from '../../exceptions/edvsException';
import { LayoutStatus } from './layoutStatus';
import { randomUUID } from 'crypto';
import { AddressConfiguration } from '../addressConfiguration';
import { AddressClient } from '../addressClient';
import { SearchType } from '../searchType';
import { GbrAddressElements } from './elements/gbrAddressElements';
import { Countries } from '../../common/country';


describe('Address client tests', () => {

    beforeAll(async () => {
        try {
            const layout = await getLayout(existingTestLayout);
            if (layout.status !== LayoutStatus.Completed) {
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

        await deleteTestLayouts();
    }); 

    afterAll(async () => { 
        await deleteTestLayouts();
    });

    test(`Get Layout`, async () => {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const result = await client.getLayout(existingTestLayout, GenerateUniqueReferenceId());
        expect(result.id.length).toBeGreaterThan(0);
    });

    test(`Get Layouts`, async () => {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);

        const getLayoutsDeprecated = await client.getLayouts([Datasets.GbAddress], testLayoutPrefix);

        const getLayouts = await client.getLayouts({
            datasets: [Datasets.GbAddress],
            nameContains: testLayoutPrefix,
            referenceId: staticReferenceId});

        expect(getLayoutsDeprecated.length).toBe(getLayouts.layouts?.length);
    });

    test(`Create Layout`, async () => {
        const configuration = new LayoutConfiguration(validTokenAddress()); 
        const client = new LayoutClient(configuration);
        const line1: LayoutLineVariable = {name: "addr_line_1"};
        const line2: LayoutLineVariable = {name:"addr_line_2"};
        const line3: LayoutLineFixed = {name: "post_code", elements: [AusAddressElements.PostalCode]};
        const line4: LayoutLineFixed = {name: "country_name", elements: [AusAddressElements.CountryName]};
        const layoutName = getUniqueLayoutName();

        const result = await client.createLayout(layoutName, [{datasets: [Datasets.AuAddress]}], [line1, line2], [line3, line4], GenerateUniqueReferenceId());
        expect(result.id.length).toBeGreaterThan(0);
        const getResult = await client.getLayout(layoutName, GenerateUniqueReferenceId());
        expect(getResult).toBeDefined();
        expect(getResult.name).toEqual(layoutName);
    });

    test(`Format with custom layout and components`, async () => {
        const addressConfig = new AddressConfiguration(validTokenAddress(),{
            datasets: [Datasets.GbAddress],
            layoutName: existingTestLayout,
            includeComponents: true,
        });
        const addrClient = new AddressClient(addressConfig);
        const searchResultAutoComplete = await addrClient.search({
            searchInput: "56 Queens R",
            searchType: SearchType.Autocomplete,
            referenceId: GenerateUniqueReferenceId()});
        const formatResult = await addrClient.format(searchResultAutoComplete.suggestions[0].globalAddressKey, GenerateUniqueReferenceId());
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

    test(`Reference ID - setting on builder works`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        const configuration = new LayoutConfiguration(validTokenAddress(), {transactionId: staticReferenceId});
        const client = new LayoutClient(configuration);
        const result = await client.getLayout(existingTestLayout);
        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method takes precedence`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        const configuration = new LayoutConfiguration(validTokenAddress(), {transactionId: GenerateUniqueReferenceId()});
        const client = new LayoutClient(configuration);
        const result = await client.getLayout(existingTestLayout,  staticReferenceId);
        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method`, async () => {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);

        const line1: LayoutLineVariable = {name: "addr_line_1"};
        const line2: LayoutLineVariable = {name:"addr_line_2"};
        const line3: LayoutLineFixed = {name: "post_code", elements: [AusAddressElements.PostalCode, GbrAddressElements.Postcode]};
        const line4: LayoutLineFixed = {name: "country_name", elements: [AusAddressElements.CountryName, GbrAddressElements.Country]};

        // Checking setting ID on layout methods is supported
        const createLayoutResult = await client.createLayout(getUniqueLayoutName(), [{datasets: [Datasets.GbAddress]}], [line1, line2], [line3, line4], staticReferenceId);
        expect(createLayoutResult.referenceId).toBe(staticReferenceId);

        const getLayoutResult  = await client.getLayout(existingTestLayout,  staticReferenceId);
        expect(getLayoutResult.referenceId).toBe(staticReferenceId);

        const getLayoutsResult = await client.getLayouts({
            datasets: [Datasets.GbAddress],
            nameContains: existingTestLayout,
            country: Countries.UnitedKingdom,
            referenceId: staticReferenceId});
        expect(getLayoutsResult.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - defaults to random guid`, async () => {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const result = await client.getLayout(existingTestLayout);
        expect(result.referenceId).toBeDefined();
    });

    async function createTestLayout(): Promise<CreateLayoutResult> {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const line1: LayoutLineVariable = {name: "addr_line_1"};
        const line2: LayoutLineVariable = {name:"addr_line_2"};
        const line3: LayoutLineFixed = {name: "post_code", elements: [AusAddressElements.PostalCode, GbrAddressElements.Postcode]};
        const line4: LayoutLineFixed = {name: "country_name", elements: [AusAddressElements.CountryName, GbrAddressElements.Country]};
        const layoutName = existingTestLayout;

        return client.createLayout(layoutName, [{datasets: [Datasets.AuAddress]}, {datasets: [Datasets.GbAddress]}], [line1, line2], [line3, line4], GenerateUniqueReferenceId());
    } 

    async function deleteTestLayouts(): Promise<void> { 
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        const result = await client.getLayouts({nameContains: testLayoutPrefix, referenceId: GenerateUniqueReferenceId()});

        if (result.layouts) {
            for (const layout of result.layouts) {
                if (layout.name !== existingTestLayout && layout.status === LayoutStatus.Completed) {
                    try {
                        await client.deleteLayout(layout.name, GenerateUniqueReferenceId())
                        console.info(`Deleted layout: ${layout.name}`);
                    } catch {
                        console.error(`Failed to delete layout: ${layout.name}`);
                    }
                }
            }
        }
    }

    function getLayout(layoutName: string): Promise<GetLayoutLayout> {
        const configuration = new LayoutConfiguration(validTokenAddress());
        const client = new LayoutClient(configuration);
        return client.getLayout(layoutName, GenerateUniqueReferenceId());
    }

    function getUniqueLayoutName() {
        return testLayoutPrefix + randomUUID();
    }
});
