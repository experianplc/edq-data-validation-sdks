using DVSClient.Common;

namespace DVSClient.Address
{
    public enum Accuracy
    {
        [EnumStringValue("A+")]
        APlus = 1,
        [EnumStringValue("A")]
        A = 2,
        [EnumStringValue("A-")]
        AMinus = 3,
        [EnumStringValue("B")]
        B = 4,
        [EnumStringValue("B-")]
        BMinus = 5
    }
}