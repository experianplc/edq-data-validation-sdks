package com.experian.dvs.client.server.email;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiEmailValidateResult {

    @JsonProperty("confidence")
    private String confidence;

    @JsonProperty("did_you_mean")
    private List<String> didYouMean;

    @JsonProperty("verbose_output")
    private String verboseOutput;

    @JsonProperty("email")
    private String email;

    public String getConfidence() {
        return confidence;
    }

    public void setConfidence(String confidence) {
        this.confidence = confidence;
    }

    public List<String> getDidYouMean() {
        return didYouMean;
    }

    public void setDidYouMean(List<String> didYouMean) {
        this.didYouMean = didYouMean;
    }

    public String getVerboseOutput() {
        return verboseOutput;
    }

    public void setVerboseOutput(String verboseOutput) {
        this.verboseOutput = verboseOutput;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
