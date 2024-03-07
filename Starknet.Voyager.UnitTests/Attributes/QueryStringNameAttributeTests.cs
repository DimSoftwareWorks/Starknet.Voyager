using Starknet.Voyager.Attributes;

namespace Starknet.Voyager.UnitTests.Attributes
{
    public class QueryStringNameAttributeTests
    {
        [Fact]
        public void QueryStringNameAttribute_ShouldSetTheNameProperty_WhenCreated()
        {
            // Arrange
            var name = "name";
            var queryStringNameAttribute = new QueryStringNameAttribute(name);

            // Act
            var result = queryStringNameAttribute.Name;

            // Assert
            Assert.Equal(name, result);
        }
    }
}
