using Newtonsoft.Json;
using Starknet.Voyager.Explorer;
using Starknet.Voyager.Explorer.Models;
using Starknet.Voyager.UnitTests.Setup;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
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
        public async Task GetBlockDetailsAsyncShouldReturnResponseWithStatusOkWhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/BlockDetails.json";
            var blockHash = "0x286a940d65af4def432d9cfa318daad965d9a9c3ffbc9fab548f3ebdd244e64";

            await SetupWireMockServer($"/blocks/{blockHash}", file);

            // Act

            var result = await voyagerExplorerHttpClient.GetBlockDetailsAsync(blockHash);

            // Assert

            Assert.True(result.IsSuccess);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.NotNull(result.Value);
            Assert.Equal(
                await SerializeFile<BlockDetailsExtended>(file),
                JsonConvert.SerializeObject(result.Value));

            // Cleanup

            Reset();
        }

        private async Task<string> SerializeFile<T>(string file)
        {
            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject<T>(await File.ReadAllTextAsync(file)));
        }

        private async Task SetupWireMockServer( string path, string file)
        {
            wireMockServer
                .Given(
                    Request.Create()
                        .WithPath(path)
                        .UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody(await File.ReadAllTextAsync(file)));
        }

        private void Reset()
        {
            wireMockServer.Reset();
        }
    }
}
