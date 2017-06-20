using Contracts;
using DataModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JsonDataProviders
{
    /// <summary>
    /// A data provider to manage Conference resource.
    /// </summary>
	public partial class ConferenceDataProviderJson : ConferenceDataProvider
    {
        #region CRUD operations

        /// <summary>
        /// Retrieves a list of Conference
        /// </summary>
        /// <returns>A collection of Conferences</returns>
        public override async Task<ICollection<Conference>> Get()
        {
            var results = new Collection<Conference>();

            await Task.Delay(1);

            return results;
        }

        /// <summary>
        /// Retrieves a Conference
        /// </summary>
        /// <param name="id">A Conference object id.</param>
        /// <returns>A Conference object</returns>
        public override async Task<Conference> GetById(string id)
        {
            var result = default(Conference);

            await Task.Delay(1);

            return result;
        }
        /// <summary>
        /// Retrieves a list of Conference by user id.
        /// </summary>
        /// <returns>A collection of Conferences</returns>
        public override async Task<ICollection<Conference>> GetByUserId(string userid)
        {
            var results = new Collection<Conference>();

            await Task.Delay(1);

            return results;
        }

        public override async Task<Conference> GetByPhoneAndPassCode(string phoneNumber, string passCode)
        {
            var result = default(Conference);

            await Task.Delay(1);

            return result;
        }

        /// <summary>
        /// Creates a new Conference resource.
        /// </summary>
        /// <param name="conference">A Conference object</param>
        /// <returns>A newly created Conference object</returns>
        public override async Task<Conference> CreateConference(Conference conference)
        {
            var result = default(Conference);

            await Task.Delay(1);

            return result;
        }

        /// <summary>
        /// Updates an existing Conference resource.
        /// </summary>
        /// <param name="conference">A Conference object</param>
        /// <returns>An updated Conference object</returns>
        public override async Task<Conference> UpdateConference(Conference conference)
        {
            var result = default(Conference);

            await Task.Delay(1);

            return result;
        }

        /// <summary>
        /// Deletes an existing Conference resource.
        /// </summary>
        /// <param name="id">A Conference id</param>
        /// <returns>A boolean value indicating whether the delete was successful or not.</returns>
        public override async Task<bool> DeleteConference(string id)
        {
            var success = false;

            await Task.Delay(1);

            return success;
        }

        #endregion CRUD Operations
    }
}