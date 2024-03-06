using Starknet.Voyager.Explorer.Enumerations;

namespace Starknet.Voyager.Explorer.Models
{
    public class BlockDetails
    {
        public int BlockNumber { get; set; }

        public string Hash { get; set; }

        public int Timestamp { get; set; }

        public string StateRoot { get; set; }

        public int TxnCount { get; set; }

        public int MessageCount { get; set; }

        public int EventCount { get; set; }

        public object L1VerificationTxnHash { get; set; }

        public TransactionDetailsStatus Status { get; set; }
    }
}