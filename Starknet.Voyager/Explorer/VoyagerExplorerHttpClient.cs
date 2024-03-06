using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Starknet.Voyager.Explorer.Models;
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

        public async Task<BlockDetailsExtended> GetBlockDetailsAsync(string blockId, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync($"block/{blockId}", cancellationToken);
            
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BlockDetailsExtended>(content, jsonSerializerSettings);
        }

        public async Task<IEnumerable<BlockDetails>> GetBlocksAsync(int pageSize, int page, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync($"blocks?ps={pageSize}&p={page}", cancellationToken);
            
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<BlockDetails>>(content, jsonSerializerSettings);
        }

        public async Task<TransactionDetails> GetTransactionDetailsAsync(string transactionId, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync($"transaction/{transactionId}", cancellationToken);
            
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionDetails>(content, jsonSerializerSettings);
        }
    }
}
