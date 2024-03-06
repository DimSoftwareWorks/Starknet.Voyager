using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class ClassDetails
    {
        public string Hash { get; set; }
        
        public string TransactionHash { get; set; }
        
        public int Type { get; set; }
        
        public int CreationTimestamp { get; set; }
        
        public object VerifiedTimestamp { get; set; }
        
        public object ClassAlias { get; set; }
        
        public string Version { get; set; }
        
        public string ContractsCount { get; set; }
        
        public bool IsAccount { get; set; }

        /// <summary>
        /// The contract address (usually an account) that declared this class.
        /// </summary>
        public string DeclaredBy { get; set; }
        
        public IEnumerable<string> byteCode { get; set; } = new List<string>();
        
        public IEnumerable<Abi> Abi { get; set; } = new List<Abi>();

        public string License { get; set; }

        public object Code { get; set; }
    }
}
