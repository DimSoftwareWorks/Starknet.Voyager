namespace Starknet.Voyager.Explorer.Parameters
{
    public class GetEventsParameters
    {
        /// <summary>
        /// [ps] The number of items to to return in a page. 
        /// If it's less than 25, then the page size will be 10. If it's 25, then the page size will be 25. If it's greater than 25, then the page size will be 50.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// [p] Which page of items to retrieve. Start with 1 unless you know which page you want. The JSON response body's lastPage field will indicate the last page you can iterate using such as 3.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The contract address. You cannot mix this query parameter with the blockHash and transactionHash query parameters.
        /// </summary>
        public string Contract { get; set; }

        /// <summary>
        /// The transaction hash
        /// </summary>
        public string TxnHash { get; set; }

        /// <summary>
        /// The block hash
        /// </summary>
        public string BlockHash { get; set; }
    }
}
