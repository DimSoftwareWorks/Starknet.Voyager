using Starknet.Voyager.Attributes;
using Starknet.Voyager.Explorer.Enumerations;

namespace Starknet.Voyager.Explorer.Parameters
{
    public class GetTokensParameters : PagingParameters
    {
        [QueryStringName("attribute")]
        public TokenAttribute Attribute { get; set; }

        [QueryStringName("type")]
        public TokenType Type { get; set; }
    }
}
