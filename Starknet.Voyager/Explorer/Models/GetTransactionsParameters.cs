using Starknet.Voyager.Explorer.Enumerations;

namespace Starknet.Voyager.Explorer.Models
{
    public class GetTransactionsParameters
    {
        /// <summary>
        /// Only transactions from this contract address will be retrieved.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Block number to query for
        /// </summary>
        public int Block { get; set; }

        public TransactionDetailsType Type { get; set; }

        /// <summary>
        /// If true, then only rejected transactions will be retrieved. Otherwise, only transactions which haven't been rejected will be retrieved.
        /// </summary>
        public bool Rejected { get; set; }

        /// <summary>
        /// [ps] The number of items to to return in a page.
        /// If it's less than 25, then the page size will be 10. If it's 25, then the page size will be 25. If it's greater than 25, then the page size will be 50.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// [p] Which page of items to retrieve. Start with 1 unless you know which page you want. The JSON response body's lastPage field will indicate the last page you can iterate using such as 3.
        /// </summary>
        public int Page { get; set; }
    }
}
