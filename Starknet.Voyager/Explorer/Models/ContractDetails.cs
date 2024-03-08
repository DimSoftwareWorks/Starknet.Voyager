namespace Starknet.Voyager.Explorer.Models
{
    public class ContractDetails
    {
        public string Address { get; set; }
        
        public int BlockNumber { get; set; }
        
        public string LastUpdatedBlock { get; set; }
        
        public bool IsAccount { get; set; }
        
        public bool IsErcToken { get; set; }
        
        public bool IsProxy { get; set; }

        public string Type { get; set; }
        
        public int CreationTimestamp { get; set; }
        
        public object VerifiedTimestamp { get; set; }
        
        public object ClassAlias { get; set; }
        
        public object ContractAlias { get; set; }
        
        public string ClassHash { get; set; }
        
        public string Version { get; set; }
        
        public string BlockHash { get; set; }
        
        public string Nonce { get; set; }
        
        public string TokenName { get; set; }
        
        public string TokenSymbol { get; set; }
    }
}
