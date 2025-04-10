import { RestApiAddressMetadataInfoIdentifier } from "./restApiAddressMetadataInfoIdentifier";

export type RestApiAddressMetadataInfo = {
    sources?: string[];
    number_of_households?: string;
    just_built_date?: string;
    identifier?: RestApiAddressMetadataInfoIdentifier;
};