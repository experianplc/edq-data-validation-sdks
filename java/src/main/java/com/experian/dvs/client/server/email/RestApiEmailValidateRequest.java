package com.experian.dvs.client.server.email;

import com.experian.dvs.client.email.EmailConfiguration;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEmailValidateRequest {

    @JsonProperty("email")
    private String email;

    public static RestApiEmailValidateRequest using(final EmailConfiguration configuration) {
        // Currently no optional attributes. Keeping same structure as FormatAddress & Phone requests though.
        final RestApiEmailValidateRequest request = new RestApiEmailValidateRequest();
        return request;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
