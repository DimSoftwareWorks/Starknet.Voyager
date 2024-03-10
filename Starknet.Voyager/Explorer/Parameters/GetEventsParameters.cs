using Starknet.Voyager.Attributes;

namespace Starknet.Voyager.Explorer.Parameters
{
    public class GetEventsParameters : PagingParameters
    {
        /// <summary>
        /// The contract address. You cannot mix this query parameter with the blockHash and transactionHash query parameters.
        /// </summary>
        [QueryStringName("contract")] 
        public string Contract { get; set; }

        /// <summary>
        /// The transaction hash
        /// </summary>
        [QueryStringName("txnHash")] 
        public string TxnHash { get; set; }

        /// <summary>
        /// The block hash
        /// </summary>
        [QueryStringName("blockHash")] 
        public string BlockHash { get; set; }
    }
}
