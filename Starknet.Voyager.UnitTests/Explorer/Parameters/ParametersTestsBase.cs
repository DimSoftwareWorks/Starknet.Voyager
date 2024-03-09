using Starknet.Voyager.Attributes;
using System.Reflection;

namespace Starknet.Voyager.UnitTests.Explorer.Parameters
{
    public abstract class ParametersTestsBase
    {
        protected void TestQueryStringNameAttribute<T>(string propertyName, string expectedName)
            where T : class
        {
            // Arrange

            var parameters = Activator.CreateInstance<T>();

            // Act
            
            var result = parameters?.GetType().GetProperty(propertyName)?.GetCustomAttribute<QueryStringNameAttribute>()?.Name;

            // Assert
            
            Assert.NotNull(result);
            Assert.Equal(expectedName, result);
        }
    }
}
