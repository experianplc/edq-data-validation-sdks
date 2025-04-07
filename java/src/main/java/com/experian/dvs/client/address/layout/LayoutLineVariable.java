package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.address.layout.elements.AddressElement;
import com.experian.dvs.client.server.address.layout.RestApiAddressLayoutLine;

import java.util.List;
import java.util.Objects;

public class LayoutLineVariable implements LayoutLine{

    private String name;
    private Integer maxWidth;


    public LayoutLineVariable(String name) {
        this.name = name;
    }

    public LayoutLineVariable(RestApiAddressLayoutLine line) {
        this.name = Objects.toString(line.getLineName(), "");
        this.maxWidth = line.getMaxWidth();
    }

    @Override
    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public Integer getMaxWidth() {
        return this.maxWidth;
    }

    @Override
    public List<AddressElement> getElements() {
        return List.of();
    }

    public void setMaxWidth(Integer maxWidth) {
        this.maxWidth = maxWidth;
    }
}
