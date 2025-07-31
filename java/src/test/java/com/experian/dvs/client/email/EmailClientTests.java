package com.experian.dvs.client.email;

import com.experian.dvs.client.ExperianDataValidation;
import com.experian.dvs.client.Setup;
import com.experian.dvs.client.email.validate.DomainType;
import com.experian.dvs.client.email.validate.VerboseOutput;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;
import com.experian.dvs.client.exceptions.UnauthorizedException;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

class EmailClientTests {
    @BeforeAll
    public static void setup() {
        Setup.loadEnv();
    }

    @Test
    public void testValidTokenEmail() {
        assertThat(Setup.VALID_TOKEN_EMAIL).isNotEmpty();
    }

    @Test
    void authentication_TokenNotSupplied_Throws() {
        final Exception ex1 =  assertThrows(InvalidConfigurationException.class, () -> EmailConfiguration.newBuilder("").build());
        assertThat(ex1.getMessage()).isEqualTo("The supplied configuration must contain an authorisation token");

        final Exception ex2 =  assertThrows(InvalidConfigurationException.class, () -> EmailConfiguration.newBuilder(null).build());
        assertThat(ex2.getMessage()).isEqualTo("The supplied configuration must contain an authorisation token");
    }

    @Test
    void authentication_InvalidTokenSupplied_Throws() {
        final String token = "ThisIsNotAValidToken";
        final EmailConfiguration configuration = EmailConfiguration.newBuilder(token).build();

        final EmailClient client = ExperianDataValidation.getEmailClient(configuration);
        final Exception ex = assertThrows(UnauthorizedException.class, () -> client.validate("support@experian.com", Setup.getUniqueReferenceId()));
        assertThat(ex.getMessage()).isEqualTo("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token.");
    }

    @Test
    void validate_Email() {

        final EmailConfiguration configuration = EmailConfiguration.newBuilder(Setup.VALID_TOKEN_EMAIL)
                .includeMetadata()
                .build();

        final EmailClient client = ExperianDataValidation.getEmailClient(configuration);
        final var result = client.validate("support@experian.com", Setup.getUniqueReferenceId());
        assertThat(result.getError()).isEmpty();
        assertThat(result.getDidYouMean()).isEmpty();
        assertThat(result.getConfidence()).isEqualTo(EmailConfidence.ILLEGITIMATE);
        assertThat(result.getVerboseOutput()).isEqualTo(VerboseOutput.ROLE_ACCOUNT);
        assertThat(result.getDomainType()).isEqualTo(DomainType.BUSINESS);
    }

    @Test
    void referenceId_OnBuilderStillWorks() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        final EmailConfiguration configuration = EmailConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setTransactionId("specialRefId")
                .build();
        final EmailClient client = ExperianDataValidation.getEmailClient(configuration);
        var result = client.validate("support@experian.com");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_OnMethodTakesPrecedence() {
        // Set reference ID on builder. Method is deprecated, but still provided for backwards compatibility
        // Setting the reference ID on the method should take precedence
        final EmailConfiguration configuration = EmailConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .setTransactionId(Setup.getUniqueReferenceId())
                .build();
        final EmailClient client = ExperianDataValidation.getEmailClient(configuration);
        var result = client.validate("support@experian.com", "specialRefId");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_OnMethod() {
        final EmailConfiguration configuration = EmailConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .build();
        final EmailClient client = ExperianDataValidation.getEmailClient(configuration);
        var result = client.validate("support@experian.com", "specialRefId");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isEqualTo("specialRefId");
    }

    @Test
    void referenceId_NotValueSpecified_UsesRandomValue() {
        final EmailConfiguration configuration = EmailConfiguration
                .newBuilder(Setup.VALID_TOKEN_ADDRESS)
                .build();
        final EmailClient client = ExperianDataValidation.getEmailClient(configuration);
        var result = client.validate("support@experian.com");

        assertThat(result).isNotNull();
        assertThat(result.getReferenceId()).isNotEmpty();
    }
}
