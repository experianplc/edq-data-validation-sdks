package com.experian.dvs.client.server.address.format;

import com.experian.dvs.client.address.AddressConfiguration;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateRequest;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;
import java.util.Optional;

@JsonInclude(JsonInclude.Include.NON_NULL)
public class RestApiFormatRequest {


    @JsonProperty("layouts")
    private List<String> layouts;

    @JsonProperty("layout_format")
    private String layoutFormat;

    @JsonProperty("attributes")
    private RestApiFormatAttribute attributes;

    public static RestApiFormatRequest using(final AddressConfiguration configuration) {
        final RestApiFormatRequest request = new RestApiFormatRequest();

        request.setLayouts(List.of(configuration.getFormatLayoutName()));
        request.setLayoutFormat(configuration.getLayoutFormat().getValue());

        final Optional<RestApiFormatAttribute> attributes = RestApiAddressValidateRequest.getFormatAttribute(configuration);
        if (attributes.isPresent()) {
            request.setAttributes(attributes.get());
        }

        return request;
    }

    public List<String> getLayouts() {
        return layouts;
    }

    public void setLayouts(List<String> layouts) {
        this.layouts = layouts;
    }

    public String getLayoutFormat() {
        return layoutFormat;
    }

    public void setLayoutFormat(String layoutFormat) {
        this.layoutFormat = layoutFormat;
    }

    public RestApiFormatAttribute getAttributes() {
        return attributes;
    }

    public void setAttributes(RestApiFormatAttribute attributes) {
        this.attributes = attributes;
    }
}
