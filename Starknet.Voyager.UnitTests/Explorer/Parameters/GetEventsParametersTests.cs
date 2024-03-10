using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.UnitTests.Explorer.Parameters
{
    public class GetEventsParametersTests : ParametersTestsBase
    {
        [Fact]
        public void GetEventsParameters_ContractQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetEventsParameters>(nameof(GetEventsParameters.Contract), "contract");
        }

        [Fact]
        public void GetEventsParameters_TxnHashQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetEventsParameters>(nameof(GetEventsParameters.TxnHash), "txnHash");
        }

        [Fact]
        public void GetEventsParameters_BlockHashQueryStringNameShouldBeValid_WhenUsed()
        {
            TestQueryStringNameAttribute<GetEventsParameters>(nameof(GetEventsParameters.BlockHash), "blockHash");
        }
    }
}
