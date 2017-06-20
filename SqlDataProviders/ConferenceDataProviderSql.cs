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
    /// <summary>
    /// A controller to manage Conference resource.
    /// </summary>
	public partial class ConferenceDataProviderSql : ConferenceDataProvider
    {
        #region CRUD operations
        
        /// <summary>
        /// Creates a new Conference resource.
        /// </summary>
        /// <param name="conference">A Conference object</param>
        /// <returns>A newly created Conference object</returns>
        public override async Task<Conference> CreateConference(Conference conference)
        {
            var result = default(Conference);

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertConference";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferenceId", Value = conference.ConferenceId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = conference.UserId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferenceName", Value = conference.ConferenceName });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferencePassCode", Value = conference.ConferencePassCode });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferencePhoneNumber", Value = conference.ConferencePhoneNumber });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@WelcomeMessage", Value = conference.WelcomeMessage });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Participants", Value = conference.Participants });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Cost", Value = conference.Cost });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DateCreated", Value = conference.DateCreated });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Status", Value = conference.Status });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ProviderId", Value = conference.ProviderId });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleConferenceFromReaderAsync(reader);
                        }
                    }
                }
            }

            return result;
        }

        #region

        /// <summary>
        /// Retrieves a Conference
        /// </summary>
        /// <param name="id">A Conference object id.</param>
        /// <returns>A Conference object</returns>
        public override async Task<Conference> GetById(string id)
        {
            var result = default(Conference);

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetConferenceById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferenceId", Value = id });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleConferenceFromReaderAsync(reader);
                        }
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Retrieves a list of Conference
        /// </summary>
        /// <returns>A collection of Conferences</returns>
        public override async Task<ICollection<Conference>> Get()
        {
            var results = new Collection<Conference>();

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetConferences";
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            results.Add(await AssembleConferenceFromReaderAsync(reader));
                        }
                    }
                }
            }

            return results;
        }



        /// <summary>
        /// Retrieves a Conference
        /// </summary>
        /// <param name="phoneNumber">A virtual phone number.</param>
        /// <param name="passCode">A pass code.</param>
        /// <returns>A Conference object</returns>
        public override async Task<Conference> GetByPhoneAndPassCode(string phoneNumber, string passCode)
        {
            var result = default(Conference);

            if (!phoneNumber.Trim().StartsWith("+"))
            {
                phoneNumber = "+" + phoneNumber.Trim();
            }

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetConferenceByPhoneAndPassCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@PhoneNumber", Value = phoneNumber });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@PassCode", Value = passCode });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleConferenceFromReaderAsync(reader);
                        }
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Retrieves a list of Conference by user id.
        /// </summary>
        /// <returns>A collection of Conferences</returns>
        public override async Task<ICollection<Conference>> GetByUserId(string userid)
        {
            var results = new Collection<Conference>();

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetConferenceByUserId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = userid });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            results.Add(await AssembleConferenceFromReaderAsync(reader));
                        }
                    }
                }
            }

            return results;
        }

        

        /// <summary>
        /// Updates an existing Conference resource.
        /// </summary>
        /// <param name="conference">A Conference object</param>
        /// <returns>An updated Conference object</returns>
        public override async Task<Conference> UpdateConference(Conference conference)
        {
            var result = default(Conference);

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateConference";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferenceId", Value = conference.ConferenceId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = conference.UserId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferenceName", Value = conference.ConferenceName });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferencePassCode", Value = conference.ConferencePassCode });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferencePhoneNumber", Value = conference.ConferencePhoneNumber });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@WelcomeMessage", Value = conference.WelcomeMessage });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Participants", Value = conference.Participants });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Cost", Value = conference.Cost });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DateCreated", Value = conference.DateCreated });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Status", Value = conference.Status });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ProviderId", Value = conference.ProviderId });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleConferenceFromReaderAsync(reader);
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteConference";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ConferenceId", Value = id });

                    await connection.OpenAsync();

                    if (await command.ExecuteNonQueryAsync() > 0)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        #endregion

        #endregion CRUD Operations

        #region Private Methods

        /// <summary>
        /// Accepts a SqlDataReader and returns a Conference object
        /// </summary>
        /// <param name="reader">A sql data reader</param>
        /// <returns>A Conference object</returns>
        private async Task<Conference> AssembleConferenceFromReaderAsync(SqlDataReader reader)
        {
            return await Task.Run<Conference>(() =>
            {
                return new Conference()
                {
                    ConferenceId = reader["ConferenceId"].ToString(),
                    UserId = reader["UserId"].ToString(),
                    ConferenceName = reader["ConferenceName"].ToString(),
                    ConferencePassCode = reader["ConferencePassCode"].ToString(),
                    ConferencePhoneNumber = reader["ConferencePhoneNumber"].ToString(),
                    WelcomeMessage = reader["WelcomeMessage"].ToString(),
                    Participants = reader["Participants"].ToString(),
                    Cost = decimal.Parse(reader["Cost"].ToString()),
                    DateCreated = DateTime.Parse(reader["DateCreated"].ToString()),
                    Status = reader["Status"].ToString(),
                    ProviderId = reader["ProviderId"].ToString(),
                };
            });
        }

        #endregion Private Methods
    }
}