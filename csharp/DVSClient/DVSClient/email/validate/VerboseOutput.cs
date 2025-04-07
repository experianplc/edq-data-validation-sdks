using DVSClient.Common;

namespace DVSClient.Email.Validate
{
    public enum VerboseOutput
    {
        [EnumStringValue("verified")]
        Verified,
        [EnumStringValue("mailboxDisabled")]
        MailboxDisabled,
        [EnumStringValue("mailboxDoesNotExist")]
        MailboxDoesNotExist,
        [EnumStringValue("mailboxFull")]
        MailboxFull,
        [EnumStringValue("syntaxFailure")]
        SyntaxFailure,
        [EnumStringValue("internationalCharactersUnsupported")]
        InternationalCharactersUnsupported,
        [EnumStringValue("unreachable")]
        Unreachable,
        [EnumStringValue("illegitimate")]
        Illegitimate,
        [EnumStringValue("roleAccount")]
        RoleAccount,
        [EnumStringValue("typoDomain")]
        TypoDomain,
        [EnumStringValue("localPartSpamTrap")]
        LocalPartSpamTrap,
        [EnumStringValue("profanity")]
        Profanity,
        [EnumStringValue("disposable")]
        Disposable,
        [EnumStringValue("unknown")]
        Unknown,
        [EnumStringValue("timeout")]
        Timeout,
        [EnumStringValue("acceptAll")]
        AcceptAll,
        [EnumStringValue("relayDenied")]
        RelayDenied,
        [EnumStringValue("BLANK")]
        BLANK
    }
}
