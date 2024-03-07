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
        public async Task GetBlockDetailsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/BlockDetails.json";
            var blockHash = "0x286a940d65af4def432d9cfa318daad965d9a9c3ffbc9fab548f3ebdd244e64";

            await SetupWireMockServer($"/blocks/{blockHash}", 200, file);

            // Act

            var result = await voyagerExplorerHttpClient.GetBlockDetailsAsync(blockHash);

            // Assert

            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.NotNull(result.Value);
            Assert.Equal(
                await SerializeFile<BlockDetailsExtended>(file),
                JsonConvert.SerializeObject(result.Value));

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetBlockDetailsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsInvalid()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";
            var blockHash = "0x286a940d65af4def432d9cfa318daad965d9a9c3ffbc9fab548f3ebdd244e641";

            await SetupWireMockServer($"/blocks/{blockHash}", 404, file);

            // Act

            var result = await voyagerExplorerHttpClient.GetBlockDetailsAsync(blockHash);

            // Assert

            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.NotNull(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.Null(result.Value);
            Assert.Equal(
                await SerializeFile<object>(file),
                Serialize<object>(result.ErrorMessage));

            // Cleanup

            Reset();
        }

        private async Task SetupWireMockServer( string path, int code, string file)
        {
            wireMockServer
                .Given(
                    Request.Create()
                        .WithPath(path)
                        .UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(code)
                        .WithBody(await File.ReadAllTextAsync(file)));
        }

        private void Reset()
        {
            wireMockServer.Reset();
        }

        private static async Task<string> SerializeFile<T>(string file)
        {
            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject<T>(await File.ReadAllTextAsync(file)));
        }

        private static string Serialize<T>(string value)
        {
            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject<T>(value));
        }
    }
}
