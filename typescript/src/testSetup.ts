import { randomUUID } from 'crypto';
import dotenv from 'dotenv';

dotenv.config();

export const existingTestLayout = "DVSSDK_Typescript_TestLayout";
export const testLayoutPrefix = "DVSSDK_Typescript_";
export const staticReferenceId = GenerateUniqueReferenceId();

export function validTokenAddress(): string {
    const token = process.env.DVS_API_VALID_TOKEN_ADDRESS;
    if (!token) {
        throw new Error("DVS_API_VALID_TOKEN_ADDRESS environment variable is not set");
    }
    return token;
}

export function validTokenAddressWithEnrichment(): string {
    const token = process.env.DVS_API_VALID_TOKEN_ADDRESS_WITH_ENRICHMENT;
    if (!token) {
        throw new Error("DVS_API_VALID_TOKEN_ADDRESS_WITH_ENRICHMENT environment variable is not set");
    }
    return token;
}

export function validTokenEmail(): string {
    const token = process.env.DVS_API_VALID_TOKEN_EMAIL;
    if (!token) {
        throw new Error("DVS_API_VALID_TOKEN_EMAIL environment variable is not set");
    }
    return token;
}

export function validTokenPhone(): string {
    const token = process.env.DVS_API_VALID_TOKEN_PHONE;
    if (!token) {
        throw new Error("DVS_API_VALID_TOKEN_PHONE environment variable is not set");
    }
    return token;
}

export function isDevMode(): boolean {
    const devMode = process.env.DVS_API_DEV_MODE;
    return devMode === "true";
    
}

export function GenerateUniqueReferenceId(): string {
    const token = randomUUID();
    return token;
}