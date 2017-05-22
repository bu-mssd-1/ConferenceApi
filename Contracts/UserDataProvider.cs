using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public abstract class UserDataProvider
    {
        public abstract Task<ICollection<User>> Get();
        public abstract Task<User> GetById(string id);
        public abstract Task<User> CreateUser(User User);
        public abstract Task<User> UpdateUser(User User);
        public abstract Task<bool> DeleteUser(string id);
    }
}
