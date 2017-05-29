using Contracts;
using JsonDataProviders;
using MockDataProviders;
using SqlDataProviders;

namespace ConferenceWebApi
{
    /// <summary>
    /// This is an abstract factory implementation
    /// </summary>
    public class DataProviderFactory
    {
        /// <summary>
        /// Creates a user data provider based on a data provider type
        /// </summary>
        /// <param name="dataProviderType">An enum that represents different types of supported data storage</param>
        /// <returns>A user data provider</returns>
        public UserDataProvider GetUserDataProvider(DataProviderType dataProviderType)
        {
            var provider = default(UserDataProvider);

            switch (dataProviderType)
            {
                case DataProviderType.Sql:
                    provider = new UserDataProviderSql();
                    break;
                case DataProviderType.Mock:
                    provider = new UserDataProviderMock();
                    break;
                case DataProviderType.Json:
                    provider = new UserDataProviderJson();
                    break;
                default:
                    break;
            }

            
            return provider;
        }

        /// <summary>
        /// Creates a conference data provider based on a data provider type
        /// </summary>
        /// <param name="dataProviderType">An enum that represents different types of supported data storage</param>
        /// <returns>A conference data provider</returns>
        public ConferenceDataProvider GetConferenceDataProvider(DataProviderType dataProviderType)
        {
            var provider = default(ConferenceDataProvider);

            switch (dataProviderType)
            {
                case DataProviderType.Sql:
                    provider = new ConferenceDataProviderSql();
                    break;
                case DataProviderType.Mock:
                    provider = new ConferenceDataProviderMock();
                    break;
                case DataProviderType.Json:
                    provider = new ConferenceDataProviderJson();
                    break;
                default:
                    break;
            }
            
            return provider;
        }

        /// <summary>
        /// Creates a virtaul phone number data provider based on a data provider type
        /// </summary>
        /// <param name="dataProviderType">An enum that represents different types of supported data storage</param>
        /// <returns>A virtaul phone number data provider</returns>
        public VirtualPhoneNumberDataProvider GetVirtualPhoneNumberDataProvider(DataProviderType dataProviderType)
        {
            var provider = default(VirtualPhoneNumberDataProvider);

            switch (dataProviderType)
            {
                case DataProviderType.Sql:
                    provider = new VirtualPhoneNumberDataProviderSql();
                    break;
                case DataProviderType.Mock:
                    provider = new VirtualPhoneNumberDataProviderMock();
                    break;
                case DataProviderType.Json:
                    provider = new VirtualPhoneNumberDataProviderJson();
                    break;
                default:
                    break;
            }

            return provider;
        }
    }
}
