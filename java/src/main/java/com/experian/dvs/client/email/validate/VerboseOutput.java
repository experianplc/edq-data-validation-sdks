package com.experian.dvs.client.email.validate;

import java.util.HashMap;
import java.util.Map;

public enum VerboseOutput {
    VERIFIED("verified"),
    MAILBOX_DISABLED("mailboxDisabled"),
    MAILBOX_DOES_NOT_EXIST("mailboxDoesNotExist"),
    MAILBOX_FULL("mailboxFull"),
    SYNTAX_FAILURE("syntaxFailure"),
    INTERNATIONAL_CHARACTERS_UNSUPPORTED("internationalCharactersUnsupported"),
    UNREACHABLE("unreachable"),
    ILLEGITIMATE("illegitimate"),
    ROLE_ACCOUNT("roleAccount"),
    TYPO_DOMAIN("typoDomain"),
    LOCAL_PART_SPAM_TRAP("localPartSpamTrap"),
    PROFANITY("Profanity"),
    DISPOSABLE("disposable"),
    UNKNOWN("unknown"),
    TIMEOUT("timeout"),
    ACCEPT_ALL("acceptAll"),
    RELAY_DENIED("relayDenied"),
    BLANK("BLANK");

    private final String name;
    // Map of name to VerboseOutput
    private static final Map<String, VerboseOutput> nameToVerboseOutput = new HashMap<>();
    static {
        for (VerboseOutput output : VerboseOutput.values()) {
            nameToVerboseOutput.put(output.name, output);
        }
    }

    VerboseOutput(final String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public static VerboseOutput fromName(final String name) {
        return nameToVerboseOutput.get(name);
    }
}