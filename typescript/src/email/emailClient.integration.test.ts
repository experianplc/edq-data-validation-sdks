import { describe, expect, test } from 'vitest';
import { randomUUID } from 'crypto';
import { validTokenEmail } from '../testSetup';
import { EmailConfiguration, EmailClient } from '../index';

describe('Email client tests', async () => {

    test(`Authentication token not supplied throws`, async () => {
        expect(() => new EmailConfiguration("")).toThrow('The supplied configuration must contain an authorisation token');        
    });

    test(`Authentication invalid token throws`, async () => {
            
            const token = "ThisIsNotAValidToken";
            const config = new EmailConfiguration(token, {transactionId: randomUUID()});
            const client = new EmailClient(config);
            await expect(client.validate("support@experian.com")).rejects.toThrow("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
            
    });

    test(`Valid email`, async () => {
        const config = new EmailConfiguration(
            validTokenEmail(),
            {transactionId: randomUUID(),
                includeMetadata: true
            }

        );
        const client = new EmailClient(config);
        const result = await client.validate("support@experian.com");

        expect(result.error).toBeUndefined;
        expect(result.didYouMean).toBeUndefined;
        expect(result.confidence).toBe("Illegitimate");
        expect(result.verboseOutput).toBe("RoleAccount");
        expect(result.domainType).toBe("Business");
    });
    

});