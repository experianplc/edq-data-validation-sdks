package com.experian.dvs.client.phone;

import com.experian.dvs.client.ExperianDataValidation;
import com.experian.dvs.client.Setup;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;
import com.experian.dvs.client.exceptions.UnauthorizedException;
import com.experian.dvs.client.phone.validate.PhoneType;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class PhoneClientTests {
    @BeforeAll
    public static void setup() {
        Setup.loadEnv();
    }

    @Test
    public void testValidTokenPhone() {
        assertThat(Setup.VALID_TOKEN_PHONE).isNotEmpty();
    }

    @Test
    void authentication_TokenNotSupplied_Throws() {
        final Exception ex1 =  assertThrows(InvalidConfigurationException.class, () -> PhoneConfiguration.newBuilder("").build());
        assertThat(ex1.getMessage()).isEqualTo("The supplied configuration must contain an authorisation token");

        final Exception ex2 =  assertThrows(InvalidConfigurationException.class, () -> PhoneConfiguration.newBuilder(null).build());
        assertThat(ex2.getMessage()).isEqualTo("The supplied configuration must contain an authorisation token");
    }

    @Test
    void authentication_InvalidTokenSupplied_Throws() {
        final String token = "ThisIsNotAValidToken";
        final PhoneConfiguration configuration = PhoneConfiguration
                .newBuilder(token)
                .build();

        final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);
        final Exception ex = assertThrows(UnauthorizedException.class, () -> client.validate("+44123456767", Setup.getUniqueReferenceId()));
        assertThat(ex.getMessage()).isEqualTo("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
    }

    @Test
    void validate_PhoneNumber_WithOutputFormat() {
        final PhoneConfiguration configuration = PhoneConfiguration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .useOutputFormat("NATIONAL")
                .build();
        final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);
        final var result = client.validate("+442074987788", Setup.getUniqueReferenceId());

        assertThat(result.getConfidence()).isEqualTo(PhoneConfidence.NO_COVERAGE);
        assertThat(result.getPhoneType()).isEqualTo(PhoneType.LANDLINE);
        assertThat(result.getFormattedPhoneNumber()).isEqualTo("020 7498 7788");
    }

    @Test
    void Validate_PhoneNumber_WithMetadata() {
        final PhoneConfiguration configuration = PhoneConfiguration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .includeMetadata()
                .build();
        final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);
        final var result = client.validate("+442074987788", Setup.getUniqueReferenceId());

        assertThat(result.getConfidence()).isEqualTo(PhoneConfidence.NO_COVERAGE);
        assertThat(result.getPhoneType()).isEqualTo(PhoneType.LANDLINE);
        assertThat(result.getMetadata()).isNotNull();
        assertThat(result.getMetadata().getPhoneDetail()).isNotNull();
        assertThat(result.getMetadata().getPhoneDetail().getOriginalOperatorName()).isEqualTo("BT");
    }

    @Test
    void referenceId_OnBuilderStillWorks() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        final PhoneConfiguration configuration = PhoneConfiguration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .setTransactionId("specialRefId")
                .build();
        final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);
        var result = client.validate("+442074987788");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_OnMethodTakesPrecedence() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        final PhoneConfiguration configuration = PhoneConfiguration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .setTransactionId(Setup.getUniqueReferenceId())
                .build();
        final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);
        var result = client.validate("+442074987788", "specialRefId");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_OnMethod() {
        final PhoneConfiguration configuration = PhoneConfiguration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .build();
        final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);
        var result = client.validate("+442074987788", "specialRefId");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_NotValueSpecified_UsesRandomValue() {
        final PhoneConfiguration configuration = PhoneConfiguration
                .newBuilder(Setup.VALID_TOKEN_PHONE)
                .build();
        final PhoneClient client = ExperianDataValidation.getPhoneClient(configuration);
        var result = client.validate("+442074987788");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isNotEmpty();
    }
}
