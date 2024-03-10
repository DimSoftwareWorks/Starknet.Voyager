using Newtonsoft.Json;
using Starknet.Voyager.Explorer;
using Starknet.Voyager.Explorer.Enumerations;
using Starknet.Voyager.Explorer.Models;
using Starknet.Voyager.Explorer.Parameters;
using Starknet.Voyager.Helpers;
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

        [Theory]
        [InlineData("ResponseExamples/Blocks-1.json", null, null)]
        [InlineData("ResponseExamples/Blocks-2.json", 10, 1)]
        [InlineData("ResponseExamples/Blocks-3.json", null, 1)]
        [InlineData("ResponseExamples/Blocks-4.json", 10, null)]
        public async Task GetBlocksAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid(string file, int? pageSize, int? page)
        {
            // Arrange

            var parameters = new PagingParameters
            {
                PageSize = pageSize,
                Page = page
            };

            SetupWireMockServer("/blocks", 200, await File.ReadAllTextAsync(file), DictionaryHelpers.GetQueryStringDictionary(parameters));

            // Act

            var result = await voyagerExplorerHttpClient.GetBlocksAsync(parameters);

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

        [Theory]
        [InlineData("ResponseExamples/Transactions-1.json", null, null, null, false, null, null)]
        [InlineData("ResponseExamples/Transactions-2.json", "0x025b74DBFB6AEc63a080b2477e03a4920FbD89C3ba6AdAB7cea1Afd25F8685F9", 10221, TransactionDetailsType.Deploy, false, 10, 1)]
        [InlineData("ResponseExamples/Transactions-3.json", "0x025b74DBFB6AEc63a080b2477e03a4920FbD89C3ba6AdAB7cea1Afd25F8685F9", null, null, false, 5, 1)]
        public async Task GetTransactionsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid(
            string file, 
            string? to, 
            int? block, 
            TransactionDetailsType? type, 
            bool rejected, 
            int? pageSize, 
            int? page)
        {
            // Arrange

            var parameters = new GetTransactionsParameters
            {
                To = to,
                Block = block,
                Type = type,
                Rejected = rejected,
                PageSize = pageSize,
                Page = page
            };

            SetupWireMockServer("/txns", 200, await File.ReadAllTextAsync(file), DictionaryHelpers.GetQueryStringDictionary(parameters));

            // Act

            var result = await voyagerExplorerHttpClient.GetTransactionsAsync(parameters);

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

        #region GetClassDetailsAsync

        [Fact]
        public async Task GetClassDetailsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var classHash = "0x03530cc4759d78042f1b543bf797f5f3d647cde0388c33734cf91b7f7b9314a9";

            var file = "ResponseExamples/ClassDetails.json";

            SetupWireMockServer($"/classes/{classHash}", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetClassDetailsAsync(classHash);

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetClassDetailsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var classHash = "0x03530cc4759d78042f1b543bf797f5f3d647cde0388c33734cf91b7f7b9314a9";
            
            var file = "ResponseExamples/MissingAuthToken.json";

            SetupWireMockServer($"/classes/{classHash}", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetClassDetailsAsync(classHash);

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetClassDetailsAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            var classHash = "0x03530cc4759d78042f1b543bf797f5f3d647cde0388c33734cf91b7f7b9314a9";

            SetupWireMockServer($"/classes/{classHash}", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetClassDetailsAsync(classHash);

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetClassesAsync

        [Fact]
        public async Task GetClassesAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/Classes.json";

            SetupWireMockServer($"/classes", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetClassesAsync();

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetClassesAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";

            SetupWireMockServer($"/classes", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetClassesAsync();

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetClassesAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            SetupWireMockServer($"/classes", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetClassesAsync();

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetContractDetailsAsync

        [Fact]
        public async Task GetContractDetailsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/ContractDetails.json";
            var contractAddress = "0x07faf54d35eb92d381cb5d3b9ba6b35ccf297980e35be22ecfe07eafd2a4ac48";

            SetupWireMockServer($"/contracts/{contractAddress}", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetContractDetailsAsync(contractAddress);

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetContractDetailsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";
            var contractAddress = "0x07faf54d35eb92d381cb5d3b9ba6b35ccf297980e35be22ecfe07eafd2a4ac48";

            SetupWireMockServer($"/contracts/{contractAddress}", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetContractDetailsAsync(contractAddress);

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetContractDetailsAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            var contractAddress = "0x07faf54d35eb92d381cb5d3b9ba6b35ccf297980e35be22ecfe07eafd2a4ac48";

            SetupWireMockServer($"/contracts/{contractAddress}", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetContractDetailsAsync(contractAddress);

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetContractsAsync

        [Theory]
        [InlineData("ResponseExamples/Contracts-1.json", null, null, null)]
        [InlineData("ResponseExamples/Contracts-2.json", 10, 1, true)]
        [InlineData("ResponseExamples/Contracts-3.json", 5, 1, false)]
        public async Task GetContractsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid(string file, int? ps, int? p, bool? account)
        {
            // Arrange

            var parameters = new GetContractsParameters
            {
                PageSize = ps,
                Page = p,
                Account = account
            };

            SetupWireMockServer($"/contracts", 200, await File.ReadAllTextAsync(file), DictionaryHelpers.GetQueryStringDictionary(parameters));

            // Act

            var result = await voyagerExplorerHttpClient.GetContractsAsync(parameters);

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetContractsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";

            SetupWireMockServer($"/contracts", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetContractsAsync();

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetContractsAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            SetupWireMockServer($"/contracts", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetContractsAsync();

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetEventsAsync

        [Theory]
        [InlineData("ResponseExamples/Events-1.json", null, null, null, null, null)]
        [InlineData("ResponseExamples/Events-2.json", 10, 1, null, "0x538e554ebdd09c1f43acef2b74f51569b212a448b74a2768fd3726a224eeaeb", null)]
        [InlineData("ResponseExamples/Events-3.json", 10, 1, "0x0043D82b00bCfAB031cE67Cc5091EE42012892DB1bB1B7cE5947b8a490853d5B", null, null)]
        [InlineData("ResponseExamples/Events-4.json", 5, 1, null, "0x538e554ebdd09c1f43acef2b74f51569b212a448b74a2768fd3726a224eeaeb", "0x5ed1d1d7eba8b1124b3e5b9e6df8ca354a3e16aafc2c9c63a563e662c1c4799")]
        public async Task GetEventsAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid(
            string file,
            int? ps,
            int? p,
            string? contract,
            string? txnHash,
            string? blockHash)
        {
            // Arrange

            var parameters = new GetEventsParameters
            {
                PageSize = ps,
                Page = p,
                Contract = contract,
                TxnHash = txnHash,
                BlockHash = blockHash
            };

            SetupWireMockServer($"/events", 200, await File.ReadAllTextAsync(file), DictionaryHelpers.GetQueryStringDictionary(parameters));

            // Act

            var result = await voyagerExplorerHttpClient.GetEventsAsync(parameters);

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetEventsAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";

            SetupWireMockServer($"/events", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetEventsAsync();

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetEventsAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            SetupWireMockServer($"/events", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetEventsAsync();

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region GetTokensAsync

        [Fact]
        public async Task GetTokensAsync_ShouldReturnResponseWithStatusOk_WhenResponseIsValid()
        {
            // Arrange

            var file = "ResponseExamples/Tokens.json";

            SetupWireMockServer($"/tokens", 200, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetTokensAsync();

            // Assert

            await AssertSuccess(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetTokensAsync_ShouldReturnResponseWithNotFound_WhenResponseIsNotSuccess()
        {
            // Arrange

            var file = "ResponseExamples/MissingAuthToken.json";

            SetupWireMockServer($"/tokens", 404, await File.ReadAllTextAsync(file));

            // Act

            var result = await voyagerExplorerHttpClient.GetTokensAsync();

            // Assert

            await AssertError(result, file);

            // Cleanup

            Reset();
        }

        [Fact]
        public async Task GetTokensAsync_ShouldReturnJsonExceptionResult_WhenResponseIsInvalid()
        {
            // Arrange

            SetupWireMockServer($"/tokens", 200, "{{");

            // Act

            var result = await voyagerExplorerHttpClient.GetTokensAsync();

            // Assert

            AssertException(result);

            // Cleanup

            Reset();
        }

        #endregion

        #region Support

        private void SetupWireMockServer(string path, int code, string body, IDictionary<string, string>? parameters = default)
        {
            var request = Request.Create()
                .WithPath(path)
                .UsingGet();

            if (parameters != null && parameters.Any())
            {
                foreach (var parameter in parameters)
                {
                    request.WithParam(parameter.Key, parameter.Value);
                }
            }

            var response = Response.Create()
                .WithStatusCode(code)
                .WithBody(body);

            wireMockServer
                .Given(request)
                .RespondWith(response);
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
