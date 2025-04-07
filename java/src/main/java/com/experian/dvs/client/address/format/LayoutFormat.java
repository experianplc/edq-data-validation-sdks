package com.experian.dvs.client.address.format;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum LayoutFormat {


        DEFAULT("default"),
        ADDRESS_LINES("address_lines ");

        private final String value;
        private static final Map<String, LayoutFormat> valueMap = Arrays.stream(LayoutFormat.values()).collect(Collectors.toMap(LayoutFormat::getValue, Function.identity()));

        public static LayoutFormat fromValue(final String value) {
            return valueMap.get(value);
        }

        LayoutFormat(final String value) {
            this.value = value;
        }

        public String getValue() {
            return value;
        }

}
