using Starknet.Voyager.Attributes;
using Starknet.Voyager.Extensions;
using System.Reflection;
using System.Text;

namespace Starknet.Voyager.Helpers
{
    internal static class StringHelper
    {
        public static string BuildQueryString(object parameters)
        {
            var queryString = new StringBuilder();

            if (parameters == null)
            {
                return string.Empty;
            }

            foreach (var property in parameters.GetType().GetProperties())
            {
                var value = property.GetValue(parameters);

                if (value != null)
                {
                    var queryStringNameAttribute = property.GetCustomAttribute<QueryStringNameAttribute>();

                    if (queryStringNameAttribute == null)
                    {
                        continue;
                    }

                    var name = queryStringNameAttribute.Name;

                    if (property.PropertyType.IsEnum)
                    {
                        queryString.Append($"{name}={value.GetEnumMemberValue()}&");
                    }
                    else
                    {
                        queryString.Append($"{name}={value}&");
                    }
                }
            }

            if (queryString.Length > 0) 
            {
                queryString.Insert(0, '?');
            }

            return queryString.ToString().TrimEnd('&');
        }
    }
}
