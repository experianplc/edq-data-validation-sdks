package com.experian.dvs.client.address.layout.elements;

import com.experian.dvs.client.address.layout.AppliesTo;

import java.util.List;

public interface AddressElement {

    String getElementName();

    static AddressElement fromElementName(List<AppliesTo> appliesTo, final String elementName) {
        return AddressElementLibrary.getAddressElementFromElementName(appliesTo, elementName);
    }

}
