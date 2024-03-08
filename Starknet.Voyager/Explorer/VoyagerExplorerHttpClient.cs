using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Starknet.Voyager.Explorer.Models;
using Starknet.Voyager.Explorer.Parameters;
using Starknet.Voyager.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Starknet.Voyager.Explorer
{
    internal class VoyagerExplorerHttpClient : IVoyagerExplorerHttpClient
    {
        private readonly HttpClient httpClient;
        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            },
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter()
            }
        };

        public VoyagerExplorerHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        #region BLOCKS

        /// <summary>
        /// Retrieve block details.
        /// Get block details by block hash
        /// </summary>
        /// <returns>Details of a single block</returns>
        public async Task<Result<BlockDetailsExtended>> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken = default)
            => await GetResult<BlockDetailsExtended>($"/blocks/{blockHash}", cancellationToken);

        /// <summary>
        /// List blocks.
        /// Get all blocks
        /// </summary>
        /// <returns>A list of blocks</returns>
        public async Task<Result<BlocksListDetails>> GetBlocksAsync(PagingParameters parameters = default, CancellationToken cancellationToken = default)
            => await GetResult<BlocksListDetails>($"/blocks{StringHelper.BuildQueryString(parameters)}", cancellationToken);

        #endregion

        #region TRANSACTIONS

        /// <summary>
        /// Retrieve transaction details
        /// </summary>
        /// <param name="txnHash">Transaction hash</param>
        /// <returns>Get block details by block hash</returns>
        public async Task<Result<TransactionDetails>> GetTransactionDetailsAsync(string txnHash, CancellationToken cancellationToken = default)
            => await GetResult<TransactionDetails>($"/txns/{txnHash}", cancellationToken);

        /// <summary>
        /// List transactions
        /// </summary>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>Get all transactions</returns>
        public async Task<Result<TransactionsListDetails>> GetTransactionsAsync(GetTransactionsParameters parameters = default, CancellationToken cancellationToken = default)
            => await GetResult<TransactionsListDetails>($"/txns{StringHelper.BuildQueryString(parameters)}", cancellationToken);


        #endregion

        #region CLASSES

        /// <summary>
        /// Retrieve class details
        /// </summary>
        /// <param name="classHash">The class's hash</param>
        /// <returns>Get class detail by hash</returns>
        public async Task<Result<ClassDetails>> GetClassDetailsAsync(string classHash, CancellationToken cancellationToken = default)
            => await GetResult<ClassDetails>($"/classes/{classHash}", cancellationToken);


        /// <summary>
        /// List classes
        /// </summary>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>Get all classes</returns>
        public async Task<Result<ClassesListDetails>> GetClassesAsync(PagingParameters parameters = default, CancellationToken cancellationToken = default)
            => await GetResult<ClassesListDetails>($"/classes{StringHelper.BuildQueryString(parameters)}", cancellationToken);

        #endregion

        #region CONTRACTS

        /// <summary>
        /// Retrieve contract details
        /// </summary>
        /// <param name="contractAddress">The contract's address. .stark domains are supported.</param>
        /// <returns>Get contract details by address</returns>
        public async Task<Result<ContractDetails>> GetContractDetailsAsync(string contractAddress, CancellationToken cancellationToken = default)
            => await GetResult<ContractDetails>($"/contracts/{contractAddress}", cancellationToken);

        /// <summary>
        /// List contracts
        /// </summary>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>Get all contracts</returns>
        public async Task<Result<ContractsListDetails>> GetContractsAsync(GetContractsParameters parameters = default, CancellationToken cancellationToken = default)
            => await GetResult<ContractsListDetails>($"/contracts{StringHelper.BuildQueryString(parameters)}", cancellationToken);

        #endregion

        #region EVENTS

        /// <summary>
        /// List events
        /// </summary>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>Get all events</returns>
        public async Task<Result<EventsListDetails>> GetEventsAsync(GetEventsParameters parameters, CancellationToken cancellationToken = default)
            => await GetResult<EventsListDetails>($"/events{StringHelper.BuildQueryString(parameters)}", cancellationToken);


        #endregion

        #region TOKENS

        /// <summary>
        /// List tokens
        /// </summary>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>List all deployed tokens on the network that conforms to the token standards. This includes token standards like ERC20, ERC721 and ERC1155</returns>
        public async Task<Result<TokensListDetails>> GetTokensAsync(GetTokensParameters parameters, CancellationToken cancellationToken = default)
            => await GetResult<TokensListDetails>($"/tokens{StringHelper.BuildQueryString(parameters)}", cancellationToken);


        #endregion

        private async Task<Result<T>> GetResult<T>(string path, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync(path, cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Result<T>()
                {
                    ErrorMessage = content,
                    StatusCode = (int)response.StatusCode
                };
            }

            try
            {
                var result = JsonConvert.DeserializeObject<T>(content, jsonSerializerSettings);

                return new Result<T>
                {
                    Value = result,
                    StatusCode = 200
                };
            }
            catch (JsonException ex)
            {
                return new Result<T>()
                {
                    Exception = ex
                };
            }
        }
    }
}
