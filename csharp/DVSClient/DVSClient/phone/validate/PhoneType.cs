using DVSClient.Common;

namespace DVSClient.Phone.Validate
{
    public enum PhoneType
    {
        [EnumStringValue("Mobile", "A phone number assigned to a Mobile Telephone Operator / Cell Phone Operator.")]
        Mobile,
        [EnumStringValue("Landline", "A wired telephone in a fixed location such as home or office.")]
        Landline,
        [EnumStringValue("Mobile or landline", "The telephone number could belong to either a mobile or landline type phone.")]
        MobileOrLandline,
        [EnumStringValue("Toll free", "The number can be called from within the home country at no cost. There may be a charge to call this number from outside the home country. This is also called Freephone.")]
        TollFree,
        [EnumStringValue("Premium", "There is a premium charge added to call this number, often there is a service provided on the number so the callee typically receives revenue from the call.")]
        Premium,
        [EnumStringValue("Shared cost", "This telephone number will charge both the caller and callee at the same time. There will be an additional charge to call this type of number.")]
        SharedCost,
        [EnumStringValue("VoIP", "Assigned to a VoIP provider who delivers calls and text messages over the internet.")]
        VoIP,
        [EnumStringValue("Stage and screen", "Reserved by a regulatory body specifically for use as fictitious numbers in films, stage and screen. No real end user will be assigned.")]
        StageAndScreen,
        [EnumStringValue("Pager", "Allocated to a device that receives and displays numeric or alphanumeric messages.")]
        Pager,
        [EnumStringValue("Universal access number", "Typically used by companies to route calls to multiple destinations depending on parameters such as time of day, where the caller currently resides (so not linked to any specific locality within the country), capacity and more.")]
        UniversalAccessNumber,
        [EnumStringValue("Personal number", "Intended to be used by individuals which may route to multiple locations (home, office and cell). Some are charged at a premium number rate.")]
        PersonalNumber,
        [EnumStringValue("Voicemail only", "Access number for voicemail only.")]
        VoicemailOnly,
        [EnumStringValue("Bad format", "The number you submitted could not be identified as a valid telephone number. Check that you added an international country code.")]
        BadFormat,
        [EnumStringValue("Unknown", "Valid number format but not verified with network lookup. Could try again at a later date.")]
        Unknown
    }
}
