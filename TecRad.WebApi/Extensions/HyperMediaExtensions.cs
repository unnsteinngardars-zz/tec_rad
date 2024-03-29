using System.Collections.Generic;
using System.Dynamic;

namespace TecRad.WebApi.Extensions
{
    public static class HyperMediaExtensions 
    {
        public static void AddReference<T>(this ExpandoObject item, string key, T value) => item.TryAdd(key, value);
    }
}