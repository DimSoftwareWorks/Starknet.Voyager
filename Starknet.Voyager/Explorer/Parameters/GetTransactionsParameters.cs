using Starknet.Voyager.Attributes;
using Starknet.Voyager.Explorer.Enumerations;

namespace Starknet.Voyager.Explorer.Parameters
{
    public class GetTransactionsParameters : PagingParameters
    {
        /// <summary>
        /// Only transactions from this contract address will be retrieved.
        /// </summary>
        [QueryStringName("to")]
        public string To { get; set; }

        /// <summary>
        /// Block number to query for
        /// </summary>
        [QueryStringName("block")]
        public int? Block { get; set; }

        [QueryStringName("type")]
        public TransactionDetailsType? Type { get; set; }

        /// <summary>
        /// If true, then only rejected transactions will be retrieved. Otherwise, only transactions which haven't been rejected will be retrieved.
        /// </summary>
        [QueryStringName("rejected")]
        public bool Rejected { get; set; }
    }
}
