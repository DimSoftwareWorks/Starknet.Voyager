using Starknet.Voyager.Explorer.Models;
using System.Threading.Tasks;
using System.Threading;
using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.Explorer
{
    public interface IVoyagerExplorerHttpClient
    {
        Task<Result<BlockDetailsExtended>> GetBlockDetailsAsync(string blockId, CancellationToken cancellationToken = default);

        Task<BlocksListDetails> GetBlocksAsync(int pageSize, int page, CancellationToken cancellationToken = default);

        Task<TransactionDetails> GetTransactionDetailsAsync(string txnHash, CancellationToken cancellationToken = default);

        Task<TransactionsListDetails> GetTransactionsAsync(GetTransactionsParameters parameters, CancellationToken cancellationToken = default);

        Task<ClassDetails> GetClassDetailsAsync(string classHash, CancellationToken cancellationToken = default);

        Task<ClassesListDetails> GetClassesAsync(int pageSize, int page, CancellationToken cancellationToken = default);

        Task<ContractDetails> GetContractDetailsAsync(string contractAddress, CancellationToken cancellationToken = default);

        Task<ContractsListDetails> GetContractsAsync(int pageSize, int page, bool account, CancellationToken cancellationToken = default);

        Task<EventsListDetails> GetEventsAsync(GetEventsParameters parameters, CancellationToken cancellationToken = default);

        Task<TokensListDetails> GetTokensAsync(GetTokensParameters parameters, CancellationToken cancellationToken = default);
    }
}