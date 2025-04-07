package com.experian.dvs.client.address.layout.elements;

import com.experian.dvs.client.address.Dataset;
import com.experian.dvs.client.address.layout.AppliesTo;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.EnumMap;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public abstract class ElementLibrary {

    private ElementLibrary() {
        throw new IllegalStateException("Utility class");
    }

    private static final Map<Dataset, Class<? extends AddressElement>> DATASET_TO_ADDRESS_ELEMENT_CLASS_MAP = Map.of(
            Dataset.AU_ADDRESS, Aus.class,
            Dataset.AU_ADDRESS_GNAF, Aug.class
    );

    private static final Map<Dataset, Map<String, AddressElement>> ELEMENT_NAME_TO_ADDRESS_ELEMENT_MAP = new EnumMap<>(Dataset.class);

    private static Map<String, AddressElement> getElementNameToAddressElementMap(final Dataset dataset) {

        var cls = DATASET_TO_ADDRESS_ELEMENT_CLASS_MAP.get(dataset);
        if (cls == null) {
            throw new IllegalArgumentException("No AddressElements class found for dataset: " + dataset.name());
        }
        try {
            final Method valuesMethod = cls.getMethod("values");
            final Object[] enumConstants = (Object[]) valuesMethod.invoke(null);
            final Map<String, AddressElement> elementNameToAddressElementMap = new HashMap<>();
            for (Object constant : enumConstants) {
                final Method getElementNameMethod = constant.getClass().getMethod("getElementName");
                final String elementName = (String) getElementNameMethod.invoke(constant);
                elementNameToAddressElementMap.put(elementName, (AddressElement) constant);
            }
            return elementNameToAddressElementMap;
        } catch (NoSuchMethodException | InvocationTargetException | IllegalAccessException e) {
            throw new IllegalStateException("Error looking up address elements for dataset " + dataset.name(), e);
        }
    }

    public static AddressElement getAddressElementFromElementName(List<AppliesTo> appliesTo, final String elementName) {
        for (AppliesTo nextAppliesTo : appliesTo) {
            for (Dataset dataset : nextAppliesTo.getDatasets()) {
                AddressElement addressElement = getAddressElementFromElementName(dataset, elementName);
                if (addressElement != null) {
                    return addressElement;
                }
            }
        }
        return null;
    }


    public static AddressElement getAddressElementFromElementName(final Dataset dataset, final String elementName) {
        final Map<String, AddressElement> elementNameToAddressElementMap = ELEMENT_NAME_TO_ADDRESS_ELEMENT_MAP.computeIfAbsent(dataset, ElementLibrary::getElementNameToAddressElementMap);
        return elementNameToAddressElementMap.get(elementName);
    }
}
