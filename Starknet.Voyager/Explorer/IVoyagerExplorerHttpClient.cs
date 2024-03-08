using Starknet.Voyager.Explorer.Models;
using System.Threading.Tasks;
using System.Threading;
using Starknet.Voyager.Explorer.Parameters;

namespace Starknet.Voyager.Explorer
{
    public interface IVoyagerExplorerHttpClient
    {
        Task<Result<BlockDetailsExtended>> GetBlockDetailsAsync(string blockId, CancellationToken cancellationToken = default);

        Task<Result<BlocksListDetails>> GetBlocksAsync(PagingParameters parameters = default, CancellationToken cancellationToken = default);

        Task<Result<TransactionDetails>> GetTransactionDetailsAsync(string txnHash, CancellationToken cancellationToken = default);

        Task<Result<TransactionsListDetails>> GetTransactionsAsync(GetTransactionsParameters parameters, CancellationToken cancellationToken = default);

        Task<Result<ClassDetails>> GetClassDetailsAsync(string classHash, CancellationToken cancellationToken = default);

        Task<Result<ClassesListDetails>> GetClassesAsync(PagingParameters parameters, CancellationToken cancellationToken = default);

        Task<Result<ContractDetails>> GetContractDetailsAsync(string contractAddress, CancellationToken cancellationToken = default);

        Task<Result<ContractsListDetails>> GetContractsAsync(GetContractsParameters parameters, CancellationToken cancellationToken = default);

        Task<Result<EventsListDetails>> GetEventsAsync(GetEventsParameters parameters, CancellationToken cancellationToken = default);

        Task<Result<TokensListDetails>> GetTokensAsync(GetTokensParameters parameters, CancellationToken cancellationToken = default);
    }
}