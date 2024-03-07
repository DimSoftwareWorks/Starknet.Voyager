﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Starknet.Voyager.Explorer.Models;
using Starknet.Voyager.Explorer.Parameters;
using Starknet.Voyager.Extensions;
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
        /// <param name="blockId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Details of a single block</returns>
        public async Task<Result<BlockDetailsExtended>> GetBlockDetailsAsync(string blockHash, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/blocks/{blockHash}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Result<BlockDetailsExtended>()
                {
                    ErrorMessage = content
                };
            }

            try
            {
                var result = JsonConvert.DeserializeObject<BlockDetailsExtended>(content, jsonSerializerSettings);

                return new Result<BlockDetailsExtended>
                {
                    Value = result,
                };
            }
            catch (JsonException ex)
            {
                return new Result<BlockDetailsExtended>()
                {
                    Exception = ex
                };
            }
        }

        /// <summary>
        /// List blocks.
        /// Get all blocks
        /// </summary>
        /// <param name="pageSize">[ps] The number of items to to return in a page. 
        /// If it's less than 25, then the page size will be 10. If it's 25, then the page size will be 25. If it's greater than 25, then the page size will be 50.</param>
        /// <param name="page">[p] Which page of items to retrieve. Start with 1 unless you know which page you want. 
        /// The JSON response body's lastPage field will indicate the last page you can iterate using such as 3.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of blocks</returns>
        public async Task<BlocksListDetails> GetBlocksAsync(int pageSize, int page, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/blocks?ps={pageSize}&p={page}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BlocksListDetails>(content, jsonSerializerSettings);
        }

        #endregion

        #region TRANSACTIONS

        /// <summary>
        /// Retrieve transaction details
        /// </summary>
        /// <param name="txnHash">Transaction hash</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Get block details by block hash</returns>
        public async Task<TransactionDetails> GetTransactionDetailsAsync(string txnHash, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/txns/{txnHash}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionDetails>(content, jsonSerializerSettings);
        }

        /// <summary>
        /// List transactions
        /// </summary>
        /// <param name="parameters">Query string parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Get all transactions</returns>
        public async Task<TransactionsListDetails> GetTransactionsAsync(GetTransactionsParameters parameters, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/txns?to={parameters.To}" +
                $"&block={parameters.Block}" +
                $"&type={parameters.Type.GetEnumMemberValue()}" +
                $"&rejected={parameters.Rejected}" +
                $"&ps={parameters.PageSize}" +
                $"&p={parameters.Page}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionsListDetails>(content, jsonSerializerSettings);
        }

        #endregion

        #region CLASSES

        /// <summary>
        /// Retrieve class details
        /// </summary>
        /// <param name="classHash">The class's hash</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Get class detail by hash</returns>
        public async Task<ClassDetails> GetClassDetailsAsync(string classHash, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/classes/{classHash}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ClassDetails>(content, jsonSerializerSettings);
        }

        /// <summary>
        /// List classes
        /// </summary>
        /// <param name="pageSize">[ps] The number of items to to return in a page.
        /// If it's less than 25, then the page size will be 10. If it's 25, then the page size will be 25. If it's greater than 25, then the page size will be 50.</param>
        /// <param name="page">[p] Which page of items to retrieve. Start with 1 unless you know which page you want. 
        /// The JSON response body's lastPage field will indicate the last page you can iterate using such as 3.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Get all classes</returns>
        public async Task<ClassesListDetails> GetClassesAsync(int pageSize, int page, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/classes?ps={pageSize}&p={page}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ClassesListDetails>(content, jsonSerializerSettings);
        }

        #endregion

        #region CONTRACTS

        /// <summary>
        /// Retrieve contract details
        /// </summary>
        /// <param name="contractAddress">The contract's address. .stark domains are supported.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Get contract details by address</returns>
        public async Task<ContractDetails> GetContractDetailsAsync(string contractAddress, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/contracts/{contractAddress}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ContractDetails>(content, jsonSerializerSettings);
        }

        /// <summary>
        /// List contracts
        /// </summary>
        /// <param name="pageSize">[ps] The number of items to to return in a page. 
        /// If it's less than 25, then the page size will be 10. If it's 25, then the page size will be 25. If it's greater than 25, then the page size will be 50.</param>
        /// <param name="page">[p] Which page of items to retrieve. Start with 1 unless you know which page you want. The JSON response body's lastPage field will indicate the last page you can iterate using such as 3.</param>
        /// <param name="account">If true, only accounts will be returned. If false, only contracts will be returned. If not specified, both will be returned.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Get all contracts</returns>
        public async Task<ContractsListDetails> GetContractsAsync(int pageSize, int page, bool account, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/contracts?ps={pageSize}&p={page}&account={account}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ContractsListDetails>(content, jsonSerializerSettings);
        }

        #endregion

        #region EVENTS

        /// <summary>
        /// List events
        /// </summary>
        /// <param name="parameters">Query string parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Get all events</returns>
        public async Task<EventsListDetails> GetEventsAsync(GetEventsParameters parameters, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/events?ps={parameters.PageSize}" +
                $"&p={parameters.Page}" +
                $"&contract={parameters.Contract}" +
                $"&txnHash={parameters.TxnHash}" +
                $"&blockHash={parameters.BlockHash}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EventsListDetails>(content, jsonSerializerSettings);
        }

        #endregion

        #region TOKENS

        public async Task<TokensListDetails> GetTokensAsync(GetTokensParameters parameters, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/tokens?attribute={parameters.Attribute.GetEnumMemberValue()}" +
                $"&type={parameters.Type.GetEnumMemberValue()}" +
                $"&ps={parameters.PageSize}" +
                $"&p={parameters.Page}", cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TokensListDetails>(content, jsonSerializerSettings);
        }

        #endregion
    }
}
