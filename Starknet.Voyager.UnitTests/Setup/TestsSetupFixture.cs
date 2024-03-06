using Starknet.Voyager.Explorer;
using WireMock.Server;

namespace Starknet.Voyager.UnitTests.Setup
{
    public class TestsSetupFixture : IDisposable
    {
        public WireMockServer WireMockServer { get; private set; }

        public IVoyagerExplorerHttpClient VoyagerExplorerHttpClient { get; private set; }

        public TestsSetupFixture()
        {
            WireMockServer = WireMockServer.Start();
            VoyagerExplorerHttpClient = new VoyagerExplorerHttpClient(new HttpClient
            {
                BaseAddress = new Uri(WireMockServer.Urls[0])
            });
        }

        public void Dispose()
        {
            WireMockServer.Stop();
            WireMockServer.Dispose();
        }
    }
}
