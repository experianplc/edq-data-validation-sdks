using DVSClient.Common;

namespace DVSClient.Address.Format
{
    public enum LineContent
    {
        [EnumStringValue("none")]
        None,
        [EnumStringValue("address")]
        Address,
        [EnumStringValue("name")]
        Name,
        [EnumStringValue("ancillery")]
        Ancillery,
        [EnumStringValue("dataplus")]
        Dataplus
    }
}