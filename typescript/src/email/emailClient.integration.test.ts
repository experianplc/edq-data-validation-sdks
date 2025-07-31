import { describe, expect, test } from 'vitest';
import { staticReferenceId, validTokenEmail, GenerateUniqueReferenceId } from '../testSetup';
import { EmailConfiguration, EmailClient } from '../index';

describe('Email client tests', async () => {

    test(`Authentication token not supplied throws`, async () => {
        expect(() => new EmailConfiguration("")).toThrow('The supplied configuration must contain an authorisation token');
    });

    test(`Authentication invalid token throws`, async () => {
            
            const token = "ThisIsNotAValidToken";
            const config = new EmailConfiguration(token, {});
            const client = new EmailClient(config);
            await expect(client.validate("support@experian.com", GenerateUniqueReferenceId())).rejects.toThrow("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
            
    });

    test(`Valid email`, async () => {
        const config = new EmailConfiguration(
            validTokenEmail(),
            {
                includeMetadata: true
            }
        );
        const client = new EmailClient(config);
        const result = await client.validate("support@experian.com", GenerateUniqueReferenceId());

        expect(result.error).toBeUndefined;
        expect(result.didYouMean).toBeUndefined;
        expect(result.confidence).toBe("Illegitimate");
        expect(result.verboseOutput).toBe("RoleAccount");
        expect(result.domainType).toBe("Business");
    });
    
    test(`Reference ID - setting on builder works`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        const config = new EmailConfiguration(
            validTokenEmail(),
            {
                transactionId: staticReferenceId,
                includeMetadata: true
            }

        );
        const client = new EmailClient(config);
        const result = await client.validate("support@experian.com");

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method takes precedence`, async () => {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        const config = new EmailConfiguration(
            validTokenEmail(),
            {
                transactionId: GenerateUniqueReferenceId(),
                includeMetadata: true
            }
        );
        const client = new EmailClient(config);
        const result = await client.validate("support@experian.com", staticReferenceId);

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - setting on method`, async () => {
        const config = new EmailConfiguration(
            validTokenEmail(),
            {
                includeMetadata: true
            }
        );

        const client = new EmailClient(config);
        const result = await client.validate("support@experian.com", staticReferenceId);

        expect(result.referenceId).toBe(staticReferenceId);
    });

    test(`Reference ID - defaults to random guid`, async () => {
        const config = new EmailConfiguration(
            validTokenEmail(),
            {
                includeMetadata: true
            }
        );

        const client = new EmailClient(config);
        const result = await client.validate("support@experian.com");

        expect(result.referenceId).toBeDefined();
    });
});