using System.Runtime.Serialization;

namespace DataModels
{
    [DataContract]
    public abstract class ConferenceState
    {
        public abstract void Handle(Conference conference);
    }
}
