using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public abstract class VirtualPhoneNumberDataProvider
    {
        public abstract Task<ICollection<VirtualPhoneNumber>> Get();
        public abstract Task<VirtualPhoneNumber> GetById(string id);
        public abstract Task<ICollection<VirtualPhoneNumber>> GetByUserId(string userid);
        public abstract Task<VirtualPhoneNumber> CreateVirtualPhoneNumber(VirtualPhoneNumber VirtualPhoneNumber);
        public abstract Task<VirtualPhoneNumber> UpdateVirtualPhoneNumber(VirtualPhoneNumber VirtualPhoneNumber);
        public abstract Task<bool> DeleteVirtualPhoneNumber(string id);
    }
}
