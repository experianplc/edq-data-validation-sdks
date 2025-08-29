import { EmailConfiguration, EmailConfigurationOptions } from './emailConfiguration'; 
import { EmailClient } from './emailClient';
import { ValidateResult } from './validate/validateResult';
import { ResponseError } from '../common/responseError';
import { EmailConfidence } from './emailConfidence';
import { VerboseOutput } from './validate/verboseOutput';
import { DomainType } from './validate/domainType';

export {
    EmailConfiguration, 
    EmailClient, 
    EmailConfidence,
    VerboseOutput,
    DomainType
};

export type {
    EmailConfigurationOptions,
    ValidateResult,
    ResponseError
}
