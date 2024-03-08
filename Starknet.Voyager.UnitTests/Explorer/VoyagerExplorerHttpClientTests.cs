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

        #region GetBlockDetailsAsync

        [Fact]
        public async Task GetBlockDetailsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/BlockDetails.json";
            var blockHash = "0x286a940d65af4def432d9cfa318daad965d9a9c3ffbc9fab548f3ebdd244e64";

            SetupWireMockServer($"/blocks/{blockHash}", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetBlockDetailsAsync(blockHash);

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetBlockDetailsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";
            var blockHash = "0x286a940d65af4def432d9cfa318daad965d9a9c3ffbc9fab548f3ebdd244e641";

            SetupWireMockServer($"/blocks/{blockHash}", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetBlockDetailsAsync(blockHash);

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetBlockDetailsAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            var blockHash = "0x286a940d65af4def432d9cfa318daad965d9a9c3ffbc9fab548f3ebdd244e641";

            SetupWireMockServer($"/blocks/{blockHash}", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetBlockDetailsAsync(blockHash);

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetBlocksAsync

        [Fact]
        public async Task GetBlocksAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/Blocks.json";

            SetupWireMockServer($"/blocks", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetBlocksAsync();

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetBlocksAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";

            SetupWireMockServer($"/blocks", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetBlocksAsync();

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetBlocksAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            SetupWireMockServer($"/blocks", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetBlocksAsync();

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetTransactionDetailsAsync

        [Fact]
        public async Task GetTransactionDetailsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/TransactionDetails.json";

            var transactionHash = "0x70d339df281b94e254253d6bf09811dae9cc1e3222fd1b313e7a98a34d84b6";

            SetupWireMockServer($"/txns/{transactionHash}", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetTransactionDetailsAsync(transactionHash);

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetTransactionDetailsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";

            var transactionHash = "0x70d339df281b94e254253d6bf09811dae9cc1e3222fd1b313e7a98a34d84b6";

            SetupWireMockServer($"/txns/{transactionHash}", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetTransactionDetailsAsync(transactionHash);

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetTransactionDetailsAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            var transactionHash = "0x70d339df281b94e254253d6bf09811dae9cc1e3222fd1b313e7a98a34d84b6";
            
            SetupWireMockServer($"/txns/{transactionHash}", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetTransactionDetailsAsync(transactionHash);

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetTransactionsAsync

        [Fact]
        public async Task GetTransactionsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/Transactions.json";

            SetupWireMockServer($"/txns", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetTransactionsAsync();

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetTransactionsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";

            SetupWireMockServer($"/txns", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetTransactionsAsync();

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetTransactionsAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            SetupWireMockServer($"/txns", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetTransactionsAsync();

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region Support

        private void SetupWireMockServer(string path, int code, string body)
        {
            wireMockServer
                .Given(
                    Request.Create()
                        .WithPath(path)
                        .UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(code)
                        .WithBody(body));
        }

        private async Task AssertSuccess<T>(Result<T> result, string file)
            where T : class
        {
            Assert.True(result.IsSuccess);
            Assert.Equal(200, result.StatusCode);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.NotNull(result.Value);
            Assert.Equal(
                await SerializeFile<T>(file),
                JsonConvert.SerializeObject(result.Value));
        }

        private async Task AssertError<T>(Result<T> result, string file)
            where T : class
        {
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
            Assert.NotNull(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.Null(result.Value);
            Assert.Equal(
                await SerializeFile<object>(file),
                Serialize<object>(result.ErrorMessage));
        }

        private void AssertException<T>(Result<T> result)
            where T : class
        {
            Assert.False(result.IsSuccess);
            Assert.Null(result.StatusCode);
            Assert.Null(result.ErrorMessage);
            Assert.NotNull(result.Exception);
            Assert.IsType<JsonReaderException>(result.Exception);
            Assert.Null(result.Value);
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

        #endregion
    }
}
