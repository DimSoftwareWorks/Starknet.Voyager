using System.Runtime.Serialization;

namespace Starknet.Voyager.Explorer.Enumerations
{
    public enum TokenAttribute
    {
        [EnumMember(Value = "holders")]
        Holders = 0,

        [EnumMember(Value = "transfers")]
        Transfers
    }
}
