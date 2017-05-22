using ConferenceWebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlDataProviders;
using MockDataProviders;

namespace UnitTests
{
    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void CreateDataProviderTest()
        {
            // Create an instance of the data provider factory
            var factory = new DataProviderFactory();

            // Test if the returned providers are sql data providers
            var providerType = DataProviderType.Sql;
            Assert.IsTrue(factory.GetUserDataProvider(providerType).GetType() == typeof(UserDataProviderSql));
            Assert.IsTrue(factory.GetConferenceDataProvider(providerType).GetType() == typeof(ConferenceDataProviderSql));
            Assert.IsTrue(factory.GetVirtualPhoneNumberDataProvider(providerType).GetType() == typeof(VirtualPhoneNumberDataProviderSql));

            // Test if the returned providers are mock data providers
            providerType = DataProviderType.Mock;
            Assert.IsTrue(factory.GetUserDataProvider(providerType).GetType() == typeof(UserDataProviderMock));
            Assert.IsTrue(factory.GetConferenceDataProvider(providerType).GetType() == typeof(ConferenceDataProviderMock));
            Assert.IsTrue(factory.GetVirtualPhoneNumberDataProvider(providerType).GetType() == typeof(VirtualPhoneNumberDataProviderMock));
            
        }
    }
}
