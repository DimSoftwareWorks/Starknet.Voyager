using System.Runtime.Serialization;

namespace Starknet.Voyager.Explorer.Enumerations
{
    public enum BlockDetailsStatus
    {
        [EnumMember(Value = "Pending")]
        Pending = 0,

        [EnumMember(Value = "Accepted on L2")]
        AcceptedOnL2,

        [EnumMember(Value = "Accepted on L1")]
        AcceptedOnL1
    }
}
