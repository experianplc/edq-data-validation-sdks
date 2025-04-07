package com.experian.dvs.client.server.email;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEmailMetadata {

    @JsonProperty("domain_detail")
    private RestApiEmailDomainDetail domainDetail;

    public RestApiEmailDomainDetail getDomainDetail() {
        return domainDetail;
    }

    public void setDomainDetail(RestApiEmailDomainDetail domainDetail) {
        this.domainDetail = domainDetail;
    }
}
