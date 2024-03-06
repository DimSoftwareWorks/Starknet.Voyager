using Starknet.Voyager.Explorer.Enumerations;

namespace Starknet.Voyager.Explorer.Models
{
    public class BlockDetails
    {
        /// <summary>
        /// The block number
        /// </summary>
        public int BlockNumber { get; set; }

        /// <summary>
        /// The block hash
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// The block timestamp
        /// </summary>
        public int Timestamp { get; set; }

        public string StateRoot { get; set; }

        public int TxnCount { get; set; }

        public int MessageCount { get; set; }

        public int EventCount { get; set; }

        public object L1VerificationTxnHash { get; set; }

        /// <summary>
        ///  Status of the block, can either be Received, Accepted on L2 or Accepted on L1.
        /// </summary>
        public TransactionDetailsStatus Status { get; set; }
    }
}