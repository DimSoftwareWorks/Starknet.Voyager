using System.Runtime.Serialization;

namespace Starknet.Voyager.Explorer.Enumerations
{
    public enum TokenType
    {
        [EnumMember(Value = "erc20")]
        Erc20 = 0,

        [EnumMember(Value = "erc721")]
        Erc721,

        [EnumMember(Value = "erc1155")]
        Erc1155
    }
}
