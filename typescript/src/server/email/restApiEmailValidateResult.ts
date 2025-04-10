export type RestApiEmailValidateResult = {
    confidence?: string;
    did_you_mean?: string[];
    verbose_output?: string;
    email?: string;
};