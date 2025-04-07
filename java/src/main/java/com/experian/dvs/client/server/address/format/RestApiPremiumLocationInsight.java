package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;
import java.util.List;

public class RestApiPremiumLocationInsight {

    @JsonProperty("geocodes")
    private PremiumLocationInsightGeocodes geocodes;

    @JsonProperty("geocodes_building_xy")
    private PremiumLocationInsightGeocodesBuildingXy geocodesBuildingXy;

    @JsonProperty("geocodes_access")
    private List<PremiumLocationInsightGeocodesAccess> geocodesAccess;

    @JsonProperty("time")
    private List<PremiumLocationInsightTime> time;

    // Getters and Setters

    public PremiumLocationInsightGeocodes getGeocodes() {
        return geocodes;
    }

    public void setGeocodes(PremiumLocationInsightGeocodes geocodes) {
        this.geocodes = geocodes;
    }

    public PremiumLocationInsightGeocodesBuildingXy getGeocodesBuildingXy() {
        return geocodesBuildingXy;
    }

    public void setGeocodesBuildingXy(PremiumLocationInsightGeocodesBuildingXy geocodesBuildingXy) {
        this.geocodesBuildingXy = geocodesBuildingXy;
    }

    public List<PremiumLocationInsightGeocodesAccess> getGeocodesAccess() {
        return geocodesAccess;
    }

    public void setGeocodesAccess(List<PremiumLocationInsightGeocodesAccess> geocodesAccess) {
        this.geocodesAccess = geocodesAccess;
    }

    public List<PremiumLocationInsightTime> getTime() {
        return time;
    }

    public void setTime(List<PremiumLocationInsightTime> time) {
        this.time = time;
    }

    // Static Classes

    public static class PremiumLocationInsightGeocodes {
        @JsonProperty("latitude")
        private Double latitude;

        @JsonProperty("longitude")
        private Double longitude;

        @JsonProperty("match_level")
        private String matchLevel;

        // Getters and Setters
        public Double getLatitude() {
            return latitude;
        }

        public void setLatitude(Double latitude) {
            this.latitude = latitude;
        }

        public Double getLongitude() {
            return longitude;
        }

        public void setLongitude(Double longitude) {
            this.longitude = longitude;
        }

        public String getMatchLevel() {
            return matchLevel;
        }

        public void setMatchLevel(String matchLevel) {
            this.matchLevel = matchLevel;
        }
    }

    public static class PremiumLocationInsightGeocodesBuildingXy {
        @JsonProperty("x_coordinate")
        private Double xCoordinate;

        @JsonProperty("y_coordinate")
        private Double yCoordinate;

        // Getters and Setters
        public Double getXCoordinate() {
            return xCoordinate;
        }

        public void setXCoordinate(Double xCoordinate) {
            this.xCoordinate = xCoordinate;
        }

        public Double getYCoordinate() {
            return yCoordinate;
        }

        public void setYCoordinate(Double yCoordinate) {
            this.yCoordinate = yCoordinate;
        }
    }

    public static class PremiumLocationInsightGeocodesAccess {
        @JsonProperty("latitude")
        private Double latitude;

        @JsonProperty("longitude")
        private Double longitude;

        // Getters and Setters
        public Double getLatitude() {
            return latitude;
        }

        public void setLatitude(Double latitude) {
            this.latitude = latitude;
        }

        public Double getLongitude() {
            return longitude;
        }

        public void setLongitude(Double longitude) {
            this.longitude = longitude;
        }
    }

    public static class PremiumLocationInsightTime {
        @JsonProperty("time_zone_id")
        private String timeZoneId;

        @JsonProperty("generic")
        private String generic;

        @JsonProperty("standard")
        private String standard;

        @JsonProperty("daylight")
        private String daylight;

        @JsonProperty("reference_time")
        private PremiumLocationInsightReferenceTime referenceTime;

        @JsonProperty("time_transition")
        private List<PremiumLocationInsightTimeTransition> timeTransition;

        // Getters and Setters
        public String getTimeZoneId() {
            return timeZoneId;
        }

        public void setTimeZoneId(String timeZoneId) {
            this.timeZoneId = timeZoneId;
        }

        public String getGeneric() {
            return generic;
        }

        public void setGeneric(String generic) {
            this.generic = generic;
        }

        public String getStandard() {
            return standard;
        }

        public void setStandard(String standard) {
            this.standard = standard;
        }

        public String getDaylight() {
            return daylight;
        }

        public void setDaylight(String daylight) {
            this.daylight = daylight;
        }

        public PremiumLocationInsightReferenceTime getReferenceTime() {
            return referenceTime;
        }

        public void setReferenceTime(PremiumLocationInsightReferenceTime referenceTime) {
            this.referenceTime = referenceTime;
        }

        public List<PremiumLocationInsightTimeTransition> getTimeTransition() {
            return timeTransition;
        }

        public void setTimeTransition(List<PremiumLocationInsightTimeTransition> timeTransition) {
            this.timeTransition = timeTransition;
        }
    }

    public static class PremiumLocationInsightReferenceTime {
        @JsonProperty("tag")
        private String tag;

        @JsonProperty("standard_offset")
        private String standardOffset;

        @JsonProperty("daylight_savings")
        private String daylightSavings;

        @JsonProperty("sunrise")
        private String sunrise;

        @JsonProperty("sunset")
        private String sunset;

        // Getters and Setters
        public String getTag() {
            return tag;
        }

        public void setTag(String tag) {
            this.tag = tag;
        }

        public String getStandardOffset() {
            return standardOffset;
        }

        public void setStandardOffset(String standardOffset) {
            this.standardOffset = standardOffset;
        }

        public String getDaylightSavings() {
            return daylightSavings;
        }

        public void setDaylightSavings(String daylightSavings) {
            this.daylightSavings = daylightSavings;
        }

        public String getSunrise() {
            return sunrise;
        }

        public void setSunrise(String sunrise) {
            this.sunrise = sunrise;
        }

        public String getSunset() {
            return sunset;
        }

        public void setSunset(String sunset) {
            this.sunset = sunset;
        }
    }

    public static class PremiumLocationInsightTimeTransition {
        @JsonProperty("tag")
        private String tag;

        @JsonProperty("standard_offset")
        private String standardOffset;

        @JsonProperty("daylight_savings")
        private String daylightSavings;

        @JsonProperty("utc_start")
        private String utcStart;

        @JsonProperty("utc_end")
        private String utcEnd;

        // Getters and Setters
        public String getTag() {
            return tag;
        }

        public void setTag(String tag) {
            this.tag = tag;
        }

        public String getStandardOffset() {
            return standardOffset;
        }

        public void setStandardOffset(String standardOffset) {
            this.standardOffset = standardOffset;
        }

        public String getDaylightSavings() {
            return daylightSavings;
        }

        public void setDaylightSavings(String daylightSavings) {
            this.daylightSavings = daylightSavings;
        }

        public String getUtcStart() {
            return utcStart;
        }

        public void setUtcStart(String utcStart) {
            this.utcStart = utcStart;
        }

        public String getUtcEnd() {
            return utcEnd;
        }

        public void setUtcEnd(String utcEnd) {
            this.utcEnd = utcEnd;
        }
    }
}
