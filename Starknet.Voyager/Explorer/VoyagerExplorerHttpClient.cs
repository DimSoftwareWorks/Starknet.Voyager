using System.Net.Http;

namespace Starknet.Voyager.Explorer
{
    internal class VoyagerExplorerHttpClient : IVoyagerExplorerHttpClient
    {
        private readonly HttpClient httpClient;

        public VoyagerExplorerHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
