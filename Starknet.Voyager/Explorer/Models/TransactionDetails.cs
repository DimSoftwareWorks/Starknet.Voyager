using Starknet.Voyager.Explorer.Enumerations;
using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class TransactionDetails
    {
        public string Actions { get; set; }

        public int BlockNumber { get; set; }

        public string Hash { get; set; }

        public int Index { get; set; }

        public string L1VerificationHash { get; set; }

        public TransactionDetailsType Type { get; set; }

        public string ContractAddress { get; set; }

        public string SenderAddress { get; set; }

        public int? Timestamp { get; set; }

        public IEnumerable<string> Signature { get; set; } = new List<string>();

        public string ContractAlias { get; set; }

        public string ClassAlias { get; set; }

        public string ClassHash { get; set; }

        public TransactionDetailsStatus Status { get; set; }

        public string ContractAddressSalt { get; set; }

        public string MaxFee { get; set; }

        public string ActualFee { get; set; }

        public string Nonce { get; set; }

        public string Version { get; set; }
    }

}