using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public abstract class ConferenceDataProvider
    {
        public abstract Task<ICollection<Conference>> Get();
        public abstract Task<Conference> GetById(string id);
        public abstract Task<ICollection<Conference>> GetByUserId(string userid);
        public abstract Task<Conference> CreateConference(Conference conference);
        public abstract Task<Conference> UpdateConference(Conference conference);
        public abstract Task<bool> DeleteConference(string id);
        public abstract Task<Conference> GetByPhoneAndPassCode(string phoneNumber, string passCode);
    }
}
