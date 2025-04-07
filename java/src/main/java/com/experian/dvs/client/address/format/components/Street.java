package com.experian.dvs.client.address.format.components;

import java.util.Objects;

public class Street {

        private final String fullName;
        private final String prefix;
        private final String name;
        private final String type;
        private final String suffix;

        // Constructor
        public Street(String fullName, String prefix, String name, String type, String suffix) {
            this.fullName = Objects.toString(fullName, "");
            this.prefix = Objects.toString(prefix, "");
            this.name = Objects.toString(name, "");
            this.type = Objects.toString(type, "");
            this.suffix = Objects.toString(suffix, "");
        }

        // Getters
        public String getFullName() {
            return fullName;
        }

        public String getPrefix() {
            return prefix;
        }

        public String getName() {
            return name;
        }

        public String getType() {
            return type;
        }

        public String getSuffix() {
            return suffix;
        }
    }