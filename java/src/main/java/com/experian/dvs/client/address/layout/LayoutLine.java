package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.address.layout.elements.AddressElement;

import java.util.List;

public interface LayoutLine {

    String getName();
    Integer getMaxWidth();
    List<AddressElement> getElements();

}
