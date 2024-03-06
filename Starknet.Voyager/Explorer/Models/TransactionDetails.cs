using Starknet.Voyager.Explorer.Enumerations;
using System.Collections.Generic;

namespace Starknet.Voyager.Explorer.Models
{
    public class TransactionDetails
    {
        /// <summary>
        /// A comma-separated list of transaction actions.
        /// </summary>
        public string Actions { get; set; }

        /// <summary>
        /// The block's number
        /// </summary>
        public int BlockNumber { get; set; }

        /// <summary>
        /// Transaction hash
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// The zero-based index of the transaction in the block. For example, if there were three transactions in the block, and this was the second transaction, then it'd be 1.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The hash of the transaction verification on the L1.
        /// </summary>
        public string L1VerificationHash { get; set; }

        /// <summary>
        ///  The transaction's type
        /// </summary>
        public TransactionDetailsType Type { get; set; }

        public string ContractAddress { get; set; }

        public string SenderAddress { get; set; }

        /// <summary>
        /// Might be null if it's a rejected transaction.
        /// </summary>
        public int? Timestamp { get; set; }

        public IEnumerable<string> Signature { get; set; } = new List<string>();

        /// <summary>
        /// A human readable name for the contract.
        /// </summary>
        public string ContractAlias { get; set; }

        /// <summary>
        /// A human readable name for the class.
        /// </summary>
        public string ClassAlias { get; set; }

        /// <summary>
        /// The class's hash.
        /// </summary>
        public string ClassHash { get; set; }

        public TransactionDetailsStatus Status { get; set; }

        public string ContractAddressSalt { get; set; }

        public string MaxFee { get; set; }

        /// <summary>
        /// Always defined if the transaction succeeded, and never defined otherwise (if it was rejected).
        /// </summary>
        public string ActualFee { get; set; }

        public string Nonce { get; set; }

        /// <summary>
        /// The Starknet transaction version.
        /// </summary>
        public string Version { get; set; }
    }

}