using Starknet.Voyager.Explorer.Models;
using System.Threading.Tasks;
using System.Threading;
using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.Explorer
{
    public interface IVoyagerExplorerHttpClient
    {
        Task<BlockDetailsExtended> GetBlockDetailsAsync(string blockId, CancellationToken cancellationToken);

        Task<BlocksListDetails> GetBlocksAsync(int pageSize, int page, CancellationToken cancellationToken);

        Task<TransactionDetails> GetTransactionDetailsAsync(string txnHash, CancellationToken cancellationToken);

        Task<TransactionsListDetails> GetTransactionsAsync(GetTransactionsParameters parameters, CancellationToken cancellationToken);

        Task<ClassDetails> GetClassDetailsAsync(string classHash, CancellationToken cancellationToken);

        Task<ClassesListDetails> GetClassesAsync(int pageSize, int page, CancellationToken cancellationToken);

        Task<ContractDetails> GetContractDetailsAsync(string contractAddress, CancellationToken cancellationToken);

        Task<ContractsListDetails> GetContractsAsync(int pageSize, int page, bool account, CancellationToken cancellationToken);

        Task<EventsListDetails> GetEventsAsync(GetEventsParameters parameters, CancellationToken cancellationToken);

        Task<TokensListDetails> GetTokensAsync(GetTokensParameters parameters, CancellationToken cancellationToken);
    }
}