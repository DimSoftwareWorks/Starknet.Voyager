using System.Runtime.Serialization;

namespace Starknet.Voyager.Explorer.Enumerations
{
    public enum TransactionDetailsStatus
    {
        [EnumMember(Value = "Received")]
        Received = 0,

        [EnumMember(Value = "Accepted on L2")]
        AcceptedOnL2,

        [EnumMember(Value = "Accepted on L1")]
        AcceptedOnL1,

        [EnumMember(Value = "Rejected")]
        Rejected,

        [EnumMember(Value = "Reverted")]
        Reverted
    }
}
