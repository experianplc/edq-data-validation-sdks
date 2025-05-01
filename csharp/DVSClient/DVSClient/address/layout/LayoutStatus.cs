using DVSClient.Common;

namespace DVSClient.Address.Layout
{
    public enum LayoutStatus
    {
        [EnumStringValue("creation_in_progress")]
        CreationInProgress,
        [EnumStringValue("completed")]
        Completed
    }
}