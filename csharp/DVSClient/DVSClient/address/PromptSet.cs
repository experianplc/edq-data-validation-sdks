using DVSClient.Common;

namespace DVSClient.Address
{
    public enum PromptSet
    {
        [EnumStringValue("OneLine")]
        OneLine,
        [EnumStringValue("Default")]
        Default,
        [EnumStringValue("Generic")]
        Generic,
        [EnumStringValue("Optimal")]
        Optimal,
        [EnumStringValue("Alternate")]
        Alternate,
        [EnumStringValue("Alternate2")]
        Alternate2
    }
}