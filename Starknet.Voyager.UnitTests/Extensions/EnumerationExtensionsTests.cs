using Starknet.Voyager.Explorer.Enumerations;
using Starknet.Voyager.Extensions;

namespace Starknet.Voyager.UnitTests.Extensions
{
    public class EnumerationExtensionsTests
    {
        enum TestEnum
        {
            TestValue1 = 0,
            TestValue2
        }

        [Fact]
        public void GetEnumMemberValue_ReturnsEnumMemberValue_WhenCalledWithEnum()
        {
            // Arrange
            var tokenAttribute = TokenAttribute.Holders;

            // Act
            var result = tokenAttribute.GetEnumMemberValue();

            // Assert
            Assert.Equal("holders", result);
        }

        [Fact]
        public void GetEnumMemberValue_ReturnsNull_WhenEnumMemberAttributeIsMissing()
        {
            // Arrange
            var testEnum = TestEnum.TestValue1;

            // Act
            var result = testEnum.GetEnumMemberValue();

            // Assert
            Assert.Null(result);
        }
    }
}
