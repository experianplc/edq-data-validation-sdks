package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.address.layout.elements.AddressElement;
import com.experian.dvs.client.server.address.layout.RestApiAddressLayoutLine;
import com.experian.dvs.client.server.address.layout.RestApiAddressLayoutLineElement;

import java.util.List;
import java.util.Objects;

public class LayoutLineFixed implements LayoutLine{

    private String name;
    private Integer maxWidth;
    private List<AddressElement> elements;

    public LayoutLineFixed(String name, AddressElement element) {
        this(name, List.of(element));
    }

    public LayoutLineFixed(String name, List<AddressElement> elements) {
        this.name = name;
        this.elements = elements;
    }

    public LayoutLineFixed(List<AppliesTo> appliesTo, RestApiAddressLayoutLine line) {
        this.name = Objects.toString(line.getLineName(), "");
        this.maxWidth = line.getMaxWidth();
        this.elements = line.getElements() != null ? getAddressElements(appliesTo, line.getElements()) : List.of();
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public Integer getMaxWidth() {
        return this.maxWidth;
    }

    @Override
    public List<AddressElement> getElements() {
        return elements;
    }


    private List<AddressElement> getAddressElements(List<AppliesTo> appliesTo, final List<RestApiAddressLayoutLineElement> elements) {
        return elements.stream().map(element -> getAddressElement(appliesTo, element)).toList();
    }

    private AddressElement getAddressElement(List<AppliesTo> appliesTo, final RestApiAddressLayoutLineElement element) {
        return AddressElement.fromElementName(appliesTo, element.getElementName());
    }
}
