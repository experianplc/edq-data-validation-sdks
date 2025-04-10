import { describe, expect, test } from 'vitest';
import { PhoneConfiguration, PhoneClient } from '../index';
import { randomUUID } from 'crypto';
import { validTokenPhone } from '../testSetup';

describe('Email client tests', async () => {

    test(`Authentication token not supplied throws`, async () => {
        expect(() => new PhoneConfiguration("")).toThrow('The supplied configuration must contain an authorisation token');        
    });

    test(`Authentication invalid token throws`, async () => {
            
            const token = "ThisIsNotAValidToken";
            const config = new PhoneConfiguration(token, {transactionId: randomUUID()});
            const client = new PhoneClient(config);
            await expect(client.validate("support@experian.com")).rejects.toThrow("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
            
    });

    test(`Validate phone number with output format`, async () => {

        const config = new PhoneConfiguration(
                    validTokenPhone(),
                    {transactionId: randomUUID(),
                     outputFormat: "NATIONAL" 
                    }        
        );
        const client = new PhoneClient(config);
        const result = await client.validate("+442074987788");
        expect(result.confidence).toBe("NoCoverage");
        expect(result.phoneType).toBe("Landline");
        expect(result.formattedPhoneNumber).toEqual("020 7498 7788");
    });

    test(`Validate phone number with metadata`, async () => {

        const config = new PhoneConfiguration(
                    validTokenPhone(),
                    {transactionId: randomUUID(),
                     includeMetadata: true
                    }        
        );
        const client = new PhoneClient(config);
        const result = await client.validate("+442074987788");
        expect(result.confidence).toBe("NoCoverage");
        expect(result.phoneType).toBe("Landline");
        expect(result.metadata).toBeDefined();
        expect(result.metadata?.phoneDetail).toBeDefined();
        expect(result.metadata?.phoneDetail?.originalOperatorName).toEqual("BT");
    });
});
