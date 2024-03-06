using Starknet.Voyager.Explorer;
using Starknet.Voyager.UnitTests.Setup;
using WireMock.Server;

namespace Starknet.Voyager.UnitTests.Explorer
{
    [Collection(nameof(UnitTestsCollection))]
    public class VoyagerExplorerHttpClientTests
    {
        private readonly WireMockServer wireMockServer;
        private readonly IVoyagerExplorerHttpClient voyagerExplorerHttpClient;

        public VoyagerExplorerHttpClientTests(TestsSetupFixture testsSetupFixture)
        {
            wireMockServer = testsSetupFixture.WireMockServer;
            voyagerExplorerHttpClient = testsSetupFixture.VoyagerExplorerHttpClient;
        }

        [Fact]
        public void GetBlockDetailsAsyncShouldReturnSuccess()
        {
        }

        private void Reset()
        {
            wireMockServer.Reset();
        }
    }
}
