package com.experian.dvs.client.email;

import com.experian.dvs.client.ExperianDataValidation;
import com.experian.dvs.client.Setup;
import com.experian.dvs.client.email.validate.DomainType;
import com.experian.dvs.client.email.validate.VerboseOutput;
import com.experian.dvs.client.exceptions.InvalidConfigurationException;
import com.experian.dvs.client.exceptions.UnauthorizedException;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

class ClientTests {

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
        final Configuration configuration = Configuration.newBuilder(token).build();

        final Client client = ExperianDataValidation.getEmailClient(configuration);
        final Exception ex = assertThrows(UnauthorizedException.class, () -> client.validate("support@experian.com"));
        assertThat(ex.getMessage().equals("The authentication token you've provided is incorrect. Please check the Self Service Portal to find the right token."));
    }

    @Test
    void validate_Email() {

        final Configuration configuration = Configuration.newBuilder(Setup.VALID_TOKEN_EMAIL)
                .includeMetadata()
                .build();

        final Client client = ExperianDataValidation.getEmailClient(configuration);
        final var result = client.validate("support@experian.com");
        assertThat(result.getError()).isEmpty();
        assertThat(result.getDidYouMean()).isEmpty();
        assertThat(result.getConfidence()).isEqualTo(Confidence.ILLEGITIMATE);
        assertThat(result.getVerboseOutput()).isEqualTo(VerboseOutput.ROLE_ACCOUNT);
        assertThat(result.getDomainType()).isEqualTo(DomainType.BUSINESS);
    }


}
