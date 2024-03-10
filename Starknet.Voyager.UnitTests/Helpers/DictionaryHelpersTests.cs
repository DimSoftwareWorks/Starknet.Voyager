using AutoFixture;
using Starknet.Voyager.Explorer.Parameters;
using Starknet.Voyager.Extensions;
using Starknet.Voyager.Helpers;

namespace Starknet.Voyager.UnitTests.Helpers
{
    public class DictionaryHelpersTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void GetQueryStringDictionary_ShouldReturnDictionary_WhenPropertiesAreValid()
        {
            // Arrange

            var parameters = fixture.Create<GetEventsParameters>();

            // Act

            var actual = DictionaryHelpers.GetQueryStringDictionary(parameters);

            // Assert

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Contains("contract", actual);
            Assert.Equal(parameters.Contract, actual["contract"]);
            Assert.Contains("txnHash", actual);
            Assert.Equal(parameters.TxnHash, actual["txnHash"]);
            Assert.Contains("blockHash", actual);
            Assert.Equal(parameters.BlockHash, actual["blockHash"]);
            Assert.Contains("ps", actual);
            Assert.Equal(parameters.PageSize.ToString(), actual["ps"]);
            Assert.Contains("p", actual);
            Assert.Equal(parameters.Page.ToString(), actual["p"]);
            Assert.Equal(parameters.GetType().GetProperties().Length, actual.Count());
        }

        [Fact]
        public void GetQueryStringDictionary_ShouldReturnDictionary_WhenSomePropertiesAreAssigned()
        {
            // Arrange

            var parameters = fixture.Create<GetEventsParameters>();
            parameters.TxnHash = null;
            parameters.PageSize = null;

            // Act

            var actual = DictionaryHelpers.GetQueryStringDictionary(parameters);

            // Assert

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Contains("contract", actual);
            Assert.Equal(parameters.Contract, actual["contract"]);
            Assert.Contains("blockHash", actual);
            Assert.Equal(parameters.BlockHash, actual["blockHash"]);
            Assert.Contains("p", actual);
            Assert.Equal(parameters.Page.ToString(), actual["p"]);
            Assert.Equal(parameters.GetType().GetProperties().Length - 2, actual.Count());
        }

        [Fact]
        public void GetQueryStringDictionary_ShouldReturnDictionary_WhenHasEnumProperty()
        {
            // Arrange

            var parameters = fixture.Create<GetTokensParameters>();

            // Act

            var actual = DictionaryHelpers.GetQueryStringDictionary(parameters);

            // Assert

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Contains("attribute", actual);
            Assert.Equal(parameters.Attribute.GetEnumMemberValue(), actual["attribute"]);
            Assert.Contains("ps", actual);
            Assert.Equal(parameters.PageSize.ToString(), actual["ps"]);
            Assert.Contains("p", actual);
            Assert.Equal(parameters.Page.ToString(), actual["p"]);
            Assert.Contains("type", actual);
            Assert.Equal(parameters.Type.GetEnumMemberValue(), actual["type"]);
            Assert.Equal(parameters.GetType().GetProperties().Length, actual.Count());
        }

        [Fact]
        public void GetQueryStringDictionary_ShouldReturnEmptyDictionary_WhenAllPropertiesAreNull()
        {
            // Arrange

            var parameters = new GetEventsParameters();

            // Act

            var actual = DictionaryHelpers.GetQueryStringDictionary(parameters);

            // Assert

            Assert.Empty(actual);
        }

        [Fact]
        public void GetQueryStringDictionary_ShouldReturnEmptyDictionary_WhenPropertiesObjectIsNull()
        {
            // Arrange

            // Act

            var actual = DictionaryHelpers.GetQueryStringDictionary(null);

            // Assert

            Assert.Empty(actual);
        }
    }
}
