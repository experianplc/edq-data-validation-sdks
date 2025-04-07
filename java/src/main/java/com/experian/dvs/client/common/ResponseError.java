package com.experian.dvs.client.common;

import com.experian.dvs.client.server.RestApiResponseError;

import java.util.Objects;

public class ResponseError {

    private final String type;
    private final String title;
    private final String detail;
    private final String instance;

    public ResponseError(final RestApiResponseError error) {
        this.type = Objects.toString(error.getType(), "");
        this.title = Objects.toString(error.getTitle(), "");
        this.detail = Objects.toString(error.getDetail(), "");
        this.instance = Objects.toString(error.getInstance(), "");
    }


    public String getType() {
        return type;
    }

    public String getTitle() {
        return title;
    }

    public String getDetail() {
        return detail;
    }

    public String getInstance() {
        return instance;
    }
}
