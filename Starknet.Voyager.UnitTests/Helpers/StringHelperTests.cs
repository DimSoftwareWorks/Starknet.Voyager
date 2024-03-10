using AutoFixture;
using Starknet.Voyager.Explorer.Parameters;
using Starknet.Voyager.Extensions;
using Starknet.Voyager.Helpers;

namespace Starknet.Voyager.UnitTests.Helpers
{
    public class StringHelperTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void BuildQueryString_ShouldReturnQueryString_WhenPropertiesAreValid()
        {
            // Arrange

            var parameters = fixture.Create<GetEventsParameters>();

            // Act

            var actual = StringHelper.BuildQueryString(parameters);

            // Assert

            Assert.NotNull(actual);
            Assert.Contains("?", actual);
            Assert.Contains($"contract={parameters.Contract}", actual);
            Assert.Contains($"txnHash={parameters.TxnHash}", actual);
            Assert.Contains($"blockHash={parameters.BlockHash}", actual);
            Assert.Contains($"ps={parameters.PageSize}", actual);
            Assert.Contains($"p={parameters.Page}", actual);

            var numberOfAmpersands = actual.Count(c => c == '&');
            var numberOfParameters = parameters.GetType().GetProperties().Length;
            Assert.Equal(numberOfParameters - 1, numberOfAmpersands);

            Assert.Equal($"?contract={parameters.Contract}&" +
                $"txnHash={parameters.TxnHash}&" +
                $"blockHash={parameters.BlockHash}&" +
                $"ps={parameters.PageSize}&" +
                $"p={parameters.Page}", actual);
        }

        [Fact]
        public void BuildQueryString_ShouldReturnQueryString_WhenSomePropertiesAreAssigned()
        {
            // Arrange

            var parameters = fixture.Create<GetEventsParameters>();
            parameters.TxnHash = null;
            parameters.PageSize = null;

            // Act

            var actual = StringHelper.BuildQueryString(parameters);

            // Assert

            Assert.NotNull(actual);
            Assert.Contains("?", actual);
            Assert.Contains($"contract={parameters.Contract}", actual);
            Assert.DoesNotContain($"txnHash={parameters.TxnHash}", actual);
            Assert.Contains($"blockHash={parameters.BlockHash}", actual);
            Assert.DoesNotContain($"ps={parameters.PageSize}", actual);
            Assert.Contains($"p={parameters.Page}", actual);

            var numberOfAmpersands = actual.Count(c => c == '&');
            var numberOfParameters = parameters.GetType().GetProperties().Count(p => p.GetValue(parameters) != null);
            Assert.Equal(numberOfParameters - 1, numberOfAmpersands);

            Assert.Equal($"?contract={parameters.Contract}&" +
                $"blockHash={parameters.BlockHash}&" +
                $"p={parameters.Page}", actual);
        }

        [Fact]
        public void BuildQueryString_ShouldReturnQueryString_WhenHasEnumProperty()
        {
            // Arrange

            var parameters = fixture.Create<GetTokensParameters>();

            // Act

            var actual = StringHelper.BuildQueryString(parameters);

            // Assert

            Assert.NotNull(actual);
            Assert.Contains("?", actual);
            Assert.Contains($"attribute={parameters.Attribute.GetEnumMemberValue()}", actual);
            Assert.Contains($"type={parameters.Type.GetEnumMemberValue()}", actual);
            Assert.Contains($"ps={parameters.PageSize}", actual);
            Assert.Contains($"p={parameters.Page}", actual);

            var numberOfAmpersands = actual.Count(c => c == '&');
            var numberOfParameters = parameters.GetType().GetProperties().Length;
            Assert.Equal(numberOfParameters - 1, numberOfAmpersands);

            Assert.Equal($"?attribute={parameters.Attribute.GetEnumMemberValue()}&" +
                $"type={parameters.Type.GetEnumMemberValue()}&" +
                $"ps={parameters.PageSize}&" +
                $"p={parameters.Page}", actual);
        }

        [Fact]
        public void BuildQueryString_ShouldReturnEmptyString_WhenPropertiesAreNull()
        {
            // Arrange

            var parameters = new GetEventsParameters();

            // Act

            var actual = StringHelper.BuildQueryString(parameters);

            // Assert

            Assert.Empty(actual);
        }

        [Fact]
        public void BuildQueryString_ShouldReturnEmptyString_WhenPropertiesObjectIsNull()
        {
            // Arrange

            // Act

            var actual = StringHelper.BuildQueryString(null);

            // Assert

            Assert.Empty(actual);
        }
    }
}
