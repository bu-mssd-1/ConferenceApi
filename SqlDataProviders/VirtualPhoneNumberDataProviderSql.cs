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
    public partial class VirtualPhoneNumberDataProviderSql : VirtualPhoneNumberDataProvider
    {
        #region CRUD operations

        /// <summary>
        /// Retrieves a list of VirtualPhoneNumber
        /// </summary>
        /// <returns>A collection of VirtualPhoneNumbers</returns>
        public override async Task<ICollection<VirtualPhoneNumber>> Get()
        {
            var results = new Collection<VirtualPhoneNumber>();

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetVirtualPhoneNumbers";
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            results.Add(await AssembleVirtualPhoneNumberFromReaderAsync(reader));
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetVirtualPhoneNumberById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@VirtualPhoneNumberId", Value = id });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleVirtualPhoneNumberFromReaderAsync(reader);
                        }
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// Retrieves a list of VirtualPhoneNumber by user id.
        /// </summary>
        /// <returns>A collection of VirtualPhoneNumbers</returns>
        public override async Task<ICollection<VirtualPhoneNumber>> GetByUserId(string userid)
        {
            var results = new Collection<VirtualPhoneNumber>();

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetVirtualPhoneNumberByUserId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = userid });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            results.Add(await AssembleVirtualPhoneNumberFromReaderAsync(reader));
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertVirtualPhoneNumber";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@VirtualPhoneNumberId", Value = virtualphonenumber.VirtualPhoneNumberId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = virtualphonenumber.UserId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@PhoneNumber", Value = virtualphonenumber.PhoneNumber });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DateCreated", Value = virtualphonenumber.DateCreated });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", Value = virtualphonenumber.IsActive });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ProviderId", Value = virtualphonenumber.ProviderId });
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleVirtualPhoneNumberFromReaderAsync(reader);
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateVirtualPhoneNumber";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@VirtualPhoneNumberId", Value = virtualphonenumber.VirtualPhoneNumberId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = virtualphonenumber.UserId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@PhoneNumber", Value = virtualphonenumber.PhoneNumber });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@DateCreated", Value = virtualphonenumber.DateCreated });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@IsActive", Value = virtualphonenumber.IsActive });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ProviderId", Value = virtualphonenumber.ProviderId });
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result = await AssembleVirtualPhoneNumberFromReaderAsync(reader);
                        }
                    }
                }
            }

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

            using (var connection = new SqlConnection(SqlProviderConstant.DatabaseConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DeleteVirtualPhoneNumber";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@VirtualPhoneNumberId", Value = id });

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
        /// Accepts a SqlDataReader and returns a VirtualPhoneNumber object
        /// </summary>
        /// <param name="reader">A sql data reader</param>
        /// <returns>A VirtualPhoneNumber object</returns>
        private async Task<VirtualPhoneNumber> AssembleVirtualPhoneNumberFromReaderAsync(SqlDataReader reader)
        {
            return await Task.Run<VirtualPhoneNumber>(() =>
            {
                return new VirtualPhoneNumber()
                {
                    VirtualPhoneNumberId = reader["VirtualPhoneNumberId"].ToString(),
                    UserId = reader["UserId"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    DateCreated = DateTime.Parse(reader["DateCreated"].ToString()),
                    IsActive = bool.Parse(reader["IsActive"].ToString()),
                    ProviderId = reader["ProviderId"].ToString(),
                };
            });
        }

        #endregion Private Methods
    }
}