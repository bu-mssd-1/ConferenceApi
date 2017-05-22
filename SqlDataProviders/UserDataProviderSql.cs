using Contracts;
using DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlDataProviders
{
    public partial class UserDataProviderSql : UserDataProvider
    {
        #region CRUD operations

        /// <summary>
        /// Retrieves a list of User
        /// </summary>
        /// <returns>A collection of Users</returns>
        public override async Task<ICollection<User>> Get()
        {
            var results = new Collection<User>();

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetUsers";
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            results.Add(await AssembleUserFromReaderAsync(reader));
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetUserById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = id });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleUserFromReaderAsync(reader);
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = user.UserId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DevicePhoneNumber", Value = user.DevicePhoneNumber });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Pin", Value = user.Pin });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DateCreated", Value = user.DateCreated });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", Value = user.IsActive });
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleUserFromReaderAsync(reader);
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = user.UserId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DevicePhoneNumber", Value = user.DevicePhoneNumber });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Pin", Value = user.Pin });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DateCreated", Value = user.DateCreated });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", Value = user.IsActive });
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleUserFromReaderAsync(reader);
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = id });

                    await connection.OpenAsync();

                    if (await command.ExecuteNonQueryAsync() > 0)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        #endregion CRUD Operations        

        #region Private Methods

        /// <summary>
        /// Accepts a SqlDataReader and returns a User object
        /// </summary>
        /// <param name="reader">A sql data reader</param>
        /// <returns>A User object</returns>
        private async Task<User> AssembleUserFromReaderAsync(SqlDataReader reader)
        {
            return await Task.Run<User>(() =>
            {
                return new User()
                {
                    UserId = reader["UserId"].ToString(),
                    DevicePhoneNumber = reader["DevicePhoneNumber"].ToString(),
                    Pin = reader["Pin"].ToString(),
                    DateCreated = DateTime.Parse(reader["DateCreated"].ToString()),
                    IsActive = bool.Parse(reader["IsActive"].ToString()),
                };
            });
        }

        #endregion Private Methods
    }
}