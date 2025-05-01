package com.experian.dvs.client.layout.elements;

import com.experian.dvs.client.address.Dataset;
import com.experian.dvs.client.address.layout.elements.AddressElement;
import com.experian.dvs.client.address.layout.elements.Aus;
import com.experian.dvs.client.address.layout.elements.AddressElementLibrary;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

class AddressElementTests {

    @Test
    void addressElementLibrary_GetElement() {
        final AddressElement addressElement = AddressElementLibrary.getAddressElementFromElementName(Dataset.AU_ADDRESS, "buildingName2");
        assertThat(addressElement).isEqualTo(Aus.BUILDING_NAME_2);
    }

    @Test
    void addressElementLibrary_ElementNotInDataset() {
        final AddressElement addressElement = AddressElementLibrary.getAddressElementFromElementName(Dataset.AU_ADDRESS_GNAF, "whatever");
        assertThat(addressElement).isNull();
    }

    @Test
    void addressElementLibrary_DatasetNotInMap_Throws() {
        Exception ex =  assertThrows(IllegalArgumentException.class, () -> AddressElementLibrary.getAddressElementFromElementName(Dataset.AD_ADDRESS_ED, "whatever"));
        assertThat(ex.getMessage().equals("No AddressElements class found for dataset: ad-address-ed"));
    }
}
