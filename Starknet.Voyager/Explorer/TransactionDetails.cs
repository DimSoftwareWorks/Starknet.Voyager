using System.Collections.Generic;

namespace Starknet.Voyager.Explorer
{
    public class TransactionDetails
    {
        public int BlockNumber { get; set; }
        
        public string Hash { get; set; }
        
        public int Index { get; set; }
        
        public string L1VerificationHash { get; set; }
        
        public string Type { get; set; }
        
        public string ContractAddress { get; set; }
        
        public string SenderAddress { get; set; }
        
        public int Timestamp { get; set; }
        
        public IEnumerable<string> Signature { get; set; } = new List<string>();
        
        public string ContractAlias { get; set; }
        
        public object ClassAlias { get; set; }
        
        public object ClassHash { get; set; }
        
        public string Status { get; set; }
        
        public object ContractAddressSalt { get; set; }
        
        public string MaxFee { get; set; }
        
        public string ActualFee { get; set; }
        
        public string Nonce { get; set; }
        
        public string Version { get; set; }
    }

}