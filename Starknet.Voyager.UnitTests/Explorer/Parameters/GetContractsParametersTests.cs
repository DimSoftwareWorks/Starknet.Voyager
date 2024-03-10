using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.UnitTests.Explorer.Parameters
{
    public class GetContractsParametersTests : ParametersTestsBase
    {
        [Fact]
        public void GetContractsParameters_AccountQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetContractsParameters>(nameof(GetContractsParameters.Account), "account");
        }
    }
}
