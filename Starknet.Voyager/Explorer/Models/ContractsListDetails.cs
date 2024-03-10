using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class ContractsListDetails
    {
        public int LastPage { get; set; }

        public IEnumerable<ContractDetails> Items { get; set; } = new List<ContractDetails>();
    }
}
