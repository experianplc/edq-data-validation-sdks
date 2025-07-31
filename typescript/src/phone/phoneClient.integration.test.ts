import { describe, expect, test } from 'vitest';
import { PhoneConfiguration, PhoneClient } from '../index';
import { validTokenPhone, staticReferenceId, GenerateUniqueReferenceId } from '../testSetup';

describe('Phone client tests', async () => {

    test(`Authentication token not supplied throws`, async () => {
        expect(() => new PhoneConfiguration("")).toThrow('The supplied configuration must contain an authorisation token');        
    });

    test(`Authentication invalid token throws`, async () => {
            
            const token = "ThisIsNotAValidToken";
            const config = new PhoneConfiguration(token, {});
            const client = new PhoneClient(config);
            await expect(client.validate("+442074987788", GenerateUniqueReferenceId())).rejects.toThrow("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
            
    });

    test(`Validate phone number with output format`, async () => {

        const config = new PhoneConfiguration(
            validTokenPhone(),
                {
                    outputFormat: "NATIONAL" 
                }        
        );
        const client = new PhoneClient(config);
        const result = await client.validate("+442074987788", GenerateUniqueReferenceId());
        expect(result.confidence).toBe("NoCoverage");
        expect(result.phoneType).toBe("Landline");
        expect(result.formattedPhoneNumber).toEqual("020 7498 7788");
    });

    test(`Validate phone number with metadata`, async () => {

        const config = new PhoneConfiguration(
            validTokenPhone(),
            {
                includeMetadata: true
            }        
        );
        const client = new PhoneClient(config);
        const result = await client.validate("+442074987788", GenerateUniqueReferenceId());
        expect(result.confidence).toBe("NoCoverage");
        expect(result.phoneType).toBe("Landline");
        expect(result.metadata).toBeDefined();
        expect(result.metadata?.phoneDetail).toBeDefined();
        expect(result.metadata?.phoneDetail?.originalOperatorName).toEqual("BT");
    });
        
    test(`Reference ID - setting on builder works`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        const config = new PhoneConfiguration(
            validTokenPhone(),
            {
                transactionId: staticReferenceId,
                includeMetadata: true
            }

        );
        const client = new PhoneClient(config);
        const result = await client.validate("support@experian.com");

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method takes precedence`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        const config = new PhoneConfiguration(
            validTokenPhone(),
            {
                transactionId: GenerateUniqueReferenceId(),
                includeMetadata: true
            }
        );
        const client = new PhoneClient(config);
        const result = await client.validate("support@experian.com", staticReferenceId);

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method`, async () => {
        const config = new PhoneConfiguration(
            validTokenPhone(),
            {
                includeMetadata: true
            }
        );

        const client = new PhoneClient(config);
        const result = await client.validate("support@experian.com", staticReferenceId);

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - defaults to random guid`, async () => {
        const config = new PhoneConfiguration(
            validTokenPhone(),
            {
                includeMetadata: true
            }
        );

        const client = new PhoneClient(config);
        const result = await client.validate("support@experian.com");

        expect(result.referenceId).toBeDefined();
    });
});
