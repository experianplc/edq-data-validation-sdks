package com.experian.dvs.client.server.address.layout;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Map;

public class RestApiElementSeparator {

    @JsonProperty("default")
    private String defaultSeparator;

    @JsonProperty("configuration_by_element")
    private Map<String, Object> configurationByElement;

    public String getDefaultSeparator() {
        return defaultSeparator;
    }

    public void setDefaultSeparator(String defaultSeparator) {
        this.defaultSeparator = defaultSeparator;
    }

    public Map<String, Object> getConfigurationByElement() {
        return configurationByElement;
    }

    public void setConfigurationByElement(Map<String, Object> configurationByElement) {
        this.configurationByElement = configurationByElement;
    }
}
