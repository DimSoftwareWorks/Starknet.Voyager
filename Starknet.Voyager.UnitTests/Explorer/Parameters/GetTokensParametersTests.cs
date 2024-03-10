using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.UnitTests.Explorer.Parameters
{
    public class GetTokensParametersTests : ParametersTestsBase
    {
        [Fact]
        public void GetTokensParameters_AttributeQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetTokensParameters>(nameof(GetTokensParameters.Attribute), "attribute");
        }

        [Fact]
        public void GetTokensParameters_TypeQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetTokensParameters>(nameof(GetTokensParameters.Type), "type");
        }
    }
}
