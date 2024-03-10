using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class TransactionsListDetails
    {
        /// <summary>
        /// If the page query parameter has the same value, then you've reached the last page.
        /// </summary>
        public int LastPage { get; set; }

        public IEnumerable<TransactionDetails> Items { get; set; } = new List<TransactionDetails>();
    }
}
