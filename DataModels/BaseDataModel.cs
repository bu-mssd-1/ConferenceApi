using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace DataModels
{
    [DataContract]
    public abstract class BaseModel
    {
        /// <summary>
        /// We need this ID for Json Indexer
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Converts the object into a Json string
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Writes the object into a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>A boolean</returns>
        public void WriteToFile(string fileName)
        {
            System.IO.File.WriteAllText(fileName, this.ToJson());
        }
    }
}
