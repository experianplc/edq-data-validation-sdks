export enum VerboseOutput {
    Verified = "verified",
    MailboxDisabled = "mailboxDisabled",
    MailboxDoesNotExist = "mailboxDoesNotExist",
    MailboxFull = "mailboxFull",
    SyntaxFailure = "syntaxFailure",
    InternationalCharactersUnsupported = "internationalCharactersUnsupported",
    Unreachable = "unreachable",
    Illegitimate = "illegitimate",
    RoleAccount = "roleAccount",
    TypoDomain = "typoDomain",
    LocalPartSpamTrap = "localPartSpamTrap",
    Profanity = "profanity",
    Disposable = "disposable",
    Unknown = "unknown",
    Timeout = "timeout",
    AcceptAll = "acceptAll",
    RelayDenied = "relayDenied",
    BLANK = "BLANK"
}

export function lookupVerboseOutput(str?: string): VerboseOutput {
    if (str) {
        return Object.keys(VerboseOutput).find(key => VerboseOutput[key as keyof typeof VerboseOutput] === str) as VerboseOutput | VerboseOutput.BLANK;    
    } else {
        return VerboseOutput.BLANK;
    }
}
