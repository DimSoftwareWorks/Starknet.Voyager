using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.UnitTests.Explorer.Parameters
{
    public class GetTransactionsParametersTests : ParametersTestsBase
    {
        [Fact]
        public void GetTransactionsParameters_ToQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetTransactionsParameters>(nameof(GetTransactionsParameters.To), "to");
        }

        [Fact]
        public void GetTransactionsParameters_BlockQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetTransactionsParameters>(nameof(GetTransactionsParameters.Block), "block");
        }

        [Fact]
        public void GetTransactionsParameters_TypeQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetTransactionsParameters>(nameof(GetTransactionsParameters.Type), "type");
        }

        [Fact]
        public void GetTransactionsParameters_RejectedQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetTransactionsParameters>(nameof(GetTransactionsParameters.Rejected), "rejected");
        }
    }
}
