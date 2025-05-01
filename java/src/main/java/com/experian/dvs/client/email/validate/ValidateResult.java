package com.experian.dvs.client.email.validate;

import com.experian.dvs.client.common.ResponseError;
import com.experian.dvs.client.email.EmailConfidence;
import com.experian.dvs.client.server.email.RestApiEmailMetadata;
import com.experian.dvs.client.server.email.RestApiEmailValidateResponse;
import com.experian.dvs.client.server.email.RestApiEmailValidateResult;

import java.util.List;
import java.util.Optional;

public class ValidateResult {

    private final ResponseError error;
    private final EmailConfidence confidence;
    private final List<String> didYouMean;
    private final VerboseOutput verboseOutput;
    private final DomainType domainType;

    public ValidateResult(RestApiEmailValidateResponse apiResponse) {
        this.error = apiResponse.getError() != null ? new ResponseError(apiResponse.getError()) : null;

        final RestApiEmailValidateResult result = apiResponse.getResult();
        if (result != null) {
            this.confidence = result.getConfidence() != null ? EmailConfidence.fromName(result.getConfidence()) : null;
            this.didYouMean = result.getDidYouMean() != null ? List.copyOf(result.getDidYouMean()) : List.of();
            this.verboseOutput = result.getVerboseOutput() != null ? VerboseOutput.fromName(result.getVerboseOutput()) : null;
        } else {
            this.confidence = null;
            this.didYouMean = List.of();
            this.verboseOutput = null;

        }
        final RestApiEmailMetadata metadata = apiResponse.getMetadata();
        if (metadata != null) {
            this.domainType = metadata.getDomainDetail() != null && metadata.getDomainDetail().getType() != null ? DomainType.fromName(metadata.getDomainDetail().getType()) : null;
        } else {
            this.domainType = null;
        }
    }

    public Optional<ResponseError> getError() {
        return Optional.ofNullable(this.error);
    }

    public EmailConfidence getConfidence() {
        return confidence;
    }

    public List<String> getDidYouMean() {
        return didYouMean;
    }

    public VerboseOutput getVerboseOutput() {
        return verboseOutput;
    }

    public DomainType getDomainType() {
        return domainType;
    }
}
