using Starknet.Voyager.Attributes;
using Starknet.Voyager.Extensions;
using System.Collections.Generic;
using System.Reflection;

namespace Starknet.Voyager.Helpers
{
    internal static class DictionaryHelpers
    {
        public static IDictionary<string, string> GetQueryStringDictionary(object parameters)
        {
            var dictionary = new Dictionary<string, string>();

            if (parameters == null)
            {
                return dictionary;
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
                        dictionary.Add(name, value.GetEnumMemberValue());
                    }
                    else
                    {
                        dictionary.Add(name, value.ToString()!);
                    }
                }
            }

            return dictionary;
        }
    }
}
