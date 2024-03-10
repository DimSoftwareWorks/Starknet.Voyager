using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class BlocksListDetails
    {
        /// <summary>
        /// If the page query parameter has the same value, then you've reached the last page.
        /// </summary>
        public int LastPage { get; set; }

        public IEnumerable<BlockDetails> Items { get; set; } = new List<BlockDetails>();
    }
}
