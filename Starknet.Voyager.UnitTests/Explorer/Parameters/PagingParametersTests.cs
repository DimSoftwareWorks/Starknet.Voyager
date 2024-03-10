using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.UnitTests.Explorer.Parameters
{
    public class PagingParametersTests : ParametersTestsBase
    {
        [Fact]
        public void PagingParameters_PageSizeQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<PagingParameters>(nameof(PagingParameters.PageSize), "ps");
        }

        [Fact]
        public void PagingParameters_PageQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<PagingParameters>(nameof(PagingParameters.Page), "p");
        }
    }
}
