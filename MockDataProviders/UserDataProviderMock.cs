using Contracts;
using DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MockDataProviders
{
    public partial class UserDataProviderMock : UserDataProvider
    {
        #region CRUD operations

        /// <summary>
        /// Retrieves a list of User
        /// </summary>
        /// <returns>A collection of Users</returns>
        public override async Task<ICollection<User>> Get()
        {
            var results = new Collection<User>();

            await Task.Run(() =>
            {
                results.Add(new User() { UserId = Guid.NewGuid().ToString(), DevicePhoneNumber = "+14254443333", DateCreated = DateTime.UtcNow, Pin = "21212", IsActive = true });
                results.Add(new User() { UserId = Guid.NewGuid().ToString(), DevicePhoneNumber = "+14254442222", DateCreated = DateTime.UtcNow, Pin = "21212", IsActive = true });
                results.Add(new User() { UserId = Guid.NewGuid().ToString(), DevicePhoneNumber = "+14254441111", DateCreated = DateTime.UtcNow, Pin = "21212", IsActive = true });
                results.Add(new User() { UserId = Guid.NewGuid().ToString(), DevicePhoneNumber = "+14254440000", DateCreated = DateTime.UtcNow, Pin = "21212", IsActive = true });
            });

            return results;
        }

        /// <summary>
        /// Retrieves a User
        /// </summary>
        /// <param name="id">A User object id.</param>
        /// <returns>A User object</returns>
        public override async Task<User> GetById(string id)
        {
            var result = default(User);

            await Task.Run(() =>
            {
                result = new User() { UserId = Guid.NewGuid().ToString(), DevicePhoneNumber = "+14254443333", DateCreated = DateTime.UtcNow, Pin = "21212", IsActive = true };
            });

            return result;
        }

        /// <summary>
        /// Creates a new User resource.
        /// </summary>
        /// <param name="user">A User object</param>
        /// <returns>A newly created User object</returns>
        public override async Task<User> CreateUser(User user)
        {
            var result = default(User);

            await Task.Delay(1);

            return result;
        }

        /// <summary>
        /// Updates an existing User resource.
        /// </summary>
        /// <param name="user">A User object</param>
        /// <returns>An updated User object</returns>
        public override async Task<User> UpdateUser(User user)
        {
            var result = default(User);

            await Task.Delay(1);

            return result;
        }

        /// <summary>
        /// Deletes an existing User resource.
        /// </summary>
        /// <param name="id">A User id</param>
        /// <returns>A boolean value indicating whether the delete was successful or not.</returns>
        public override async Task<bool> DeleteUser(string id)
        {
            var success = false;

            await Task.Delay(1);

            return success;
        }

        #endregion CRUD Operations        
    }
}