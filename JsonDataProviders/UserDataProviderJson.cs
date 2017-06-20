using Contracts;
using DataModels;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace JsonDataProviders
{
    public partial class UserDataProviderJson : UserDataProvider
    {
        #region CRUD operations

        /// <summary>
        /// Retrieves a list of User
        /// </summary>
        /// <returns>A collection of Users</returns>
        public override async Task<ICollection<User>> Get()
        {
            var results = new Collection<User>();

            await Task.Delay(1);

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
                // Query the singleton indexer
                var queryResult = DataIndexer.Instance.Query(string.Format("Id='{0}'", id));

                if (queryResult != null)
                {
                    // Query result gives us a matching User Id
                    var queryItem = queryResult.Items.FirstOrDefault();
                    var userId = queryItem.Id;

                    // We now go fetch the user json from the json file store
                    // For Json data provider, we save an individual object by its id
                    // Example: User Id : E18A9A29-49E0-4D8D-8528-AB70AA4BA56D will be saved as E18A9A29-49E0-4D8D-8528-AB70AA4BA56D.json file
                    var jsonFileName = string.Format("{0}{1}.json", JsonProviderConstant.DataFolderPath, userId);

                    if (File.Exists(jsonFileName))
                    {
                        var fileContent = File.ReadAllText(jsonFileName);
                        result = JsonConvert.DeserializeObject<User>(fileContent);
                    }
                }
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

            await Task.Run(() =>
            {
                var jsonFileName = string.Format("{0}{1}.json", JsonProviderConstant.DataFolderPath, user.UserId);

                File.WriteAllText(jsonFileName, JsonConvert.SerializeObject(user));

                // Lets put the new user in the index store
                DataIndexer.Instance.AddObjectToIndex<User>(user);

                result = user;
            });

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

        public override async Task<bool> DoesUserExits(string phoneNumber)
        {
            var success = false;

            await Task.Delay(1);

            return success;
        }

        #endregion CRUD Operations        
    }
}