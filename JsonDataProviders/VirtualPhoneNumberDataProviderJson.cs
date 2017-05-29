using Contracts;
using DataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JsonDataProviders
{
    public partial class VirtualPhoneNumberDataProviderJson : VirtualPhoneNumberDataProvider
    {
        #region CRUD operations

        /// <summary>
        /// Retrieves a list of VirtualPhoneNumber
        /// </summary>
        /// <returns>A collection of VirtualPhoneNumbers</returns>
        public override async Task<ICollection<VirtualPhoneNumber>> Get()
        {
            var results = new Collection<VirtualPhoneNumber>();

            await Task.Delay(1);

            return results;
        }

        /// <summary>
        /// Retrieves a VirtualPhoneNumber
        /// </summary>
        /// <param name="id">A VirtualPhoneNumber object id.</param>
        /// <returns>A VirtualPhoneNumber object</returns>
        public override async Task<VirtualPhoneNumber> GetById(string id)
        {
            var result = default(VirtualPhoneNumber);

            await Task.Delay(1);

            return result;
        }
        /// <summary>
        /// Retrieves a list of VirtualPhoneNumber by user id.
        /// </summary>
        /// <returns>A collection of VirtualPhoneNumbers</returns>
        public override async Task<ICollection<VirtualPhoneNumber>> GetByUserId(string userid)
        {
            var results = new Collection<VirtualPhoneNumber>();

            await Task.Delay(1);

            return results;
        }

        /// <summary>
        /// Creates a new VirtualPhoneNumber resource.
        /// </summary>
        /// <param name="virtualphonenumber">A VirtualPhoneNumber object</param>
        /// <returns>A newly created VirtualPhoneNumber object</returns>
        public override async Task<VirtualPhoneNumber> CreateVirtualPhoneNumber(VirtualPhoneNumber virtualphonenumber)
        {
            var result = default(VirtualPhoneNumber);

            await Task.Delay(1);

            return result;
        }

        /// <summary>
        /// Updates an existing VirtualPhoneNumber resource.
        /// </summary>
        /// <param name="virtualphonenumber">A VirtualPhoneNumber object</param>
        /// <returns>An updated VirtualPhoneNumber object</returns>
        public override async Task<VirtualPhoneNumber> UpdateVirtualPhoneNumber(VirtualPhoneNumber virtualphonenumber)
        {
            var result = default(VirtualPhoneNumber);

            await Task.Delay(1);

            return result;
        }

        /// <summary>
        /// Deletes an existing VirtualPhoneNumber resource.
        /// </summary>
        /// <param name="id">A VirtualPhoneNumber id</param>
        /// <returns>A boolean value indicating whether the delete was successful or not.</returns>
        public override async Task<bool> DeleteVirtualPhoneNumber(string id)
        {
            var success = false;

            await Task.Delay(1);

            return success;
        }

        #endregion CRUD Operations
    }
}