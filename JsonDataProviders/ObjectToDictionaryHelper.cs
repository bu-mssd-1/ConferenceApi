using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonDataProviders
{
    /// <summary>
    /// Converts an object to a dictionary.
    /// </summary>
    /// <typeparam name="T">A type of object</typeparam>
    public static class ObjectToDictionary<T>
    {
        /// <summary>
        /// Converts an object to a dictionary
        /// </summary>
        /// <param name="obj">An object</param>
        /// <returns>A dictionary</returns>
        public static Dictionary<string, string> ToDictionary(T obj)
        {
            var result = new Dictionary<string, string>();

            var serialized = JsonConvert.SerializeObject(obj);
            result = JsonConvert.DeserializeObject<Dictionary<string, string>>(serialized);

            return result;
        }
    }
}
