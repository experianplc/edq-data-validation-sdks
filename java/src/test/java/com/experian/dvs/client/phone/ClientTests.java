package com.experian.dvs.client.phone;

import com.experian.dvs.client.ExperianDataValidation;
import com.experian.dvs.client.Setup;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;
import com.experian.dvs.client.exceptions.UnauthorizedException;
import com.experian.dvs.client.phone.validate.PhoneType;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class ClientTests {
    @Test
    void authentication_TokenNotSupplied_Throws() {
        final Exception ex1 =  assertThrows(InvalidConfigurationException.class, () -> Configuration.newBuilder("").build());
        assertThat(ex1.getMessage().equals("The supplied configuration must contain an authorisation token"));

        final Exception ex2 =  assertThrows(InvalidConfigurationException.class, () -> Configuration.newBuilder(null).build());
        assertThat(ex2.getMessage().equals("The supplied configuration must contain an authorisation token"));
    }

    @Test
    void authentication_InvalidTokenSupplied_Throws() {
        final String token = "ThisIsNotAValidToken";
        final Configuration configuration = Configuration
                .newBuilder(token)
                .build();

        final Client client = ExperianDataValidation.getPhoneClient(configuration);
        final Exception ex = assertThrows(UnauthorizedException.class, () -> client.validate("+44123456767"));
        assertThat(ex.getMessage().equals("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token."));
    }

    @Test
    void validate_PhoneNumber_WithOutputFormat() {
        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .useOutputFormat("NATIONAL")
                .build();
        final Client client = ExperianDataValidation.getPhoneClient(configuration);
        final var result = client.validate("+442074987788");

        assertThat(result.getConfidence().equals(Confidence.NO_COVERAGE));
        assertThat(result.getPhoneType().equals(PhoneType.LANDLINE));
        assertThat(result.getFormattedPhoneNumber().equals("020 7498 7788"));
    }

    @Test
    void Validate_PhoneNumber_WithMetadata() {
        final Configuration configuration = Configuration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .includeMetadata()
                .build();
        final Client client = ExperianDataValidation.getPhoneClient(configuration);
        final var result = client.validate("+442074987788");

        assertThat(result.getConfidence().equals(Confidence.NO_COVERAGE));
        assertThat(result.getPhoneType().equals(PhoneType.LANDLINE.name()));
        assertThat(result.getMetadata()).isNotNull();
        assertThat(result.getMetadata().getPhoneDetail()).isNotNull();
        assertThat(result.getMetadata().getPhoneDetail().getOriginalOperatorName().equals("BT"));
    }
}
