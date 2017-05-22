using System.Runtime.Serialization;

namespace DataModels
{
    [DataContract]
    public abstract class BaseModel
    {
        public string ToJson()
        {
            return "TODO: Convert to Json";
        }

        public bool WriteToFile(string fileName)
        {
            // TODO: Write the object to a file
            return true;
        }
    }
}
