package com.experian.dvs.client.address;

public enum Accuracy {
    A_PLUS("A+"),
    A("A"),
    A_MINUS("A-"),
    B("B"),
    B_MINUS("B-")
    ;

    private final String value;

    Accuracy(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
