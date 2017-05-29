using ConferenceWebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ProxyTests
    {
        [TestMethod]
        public void ProxyTest()
        {
            IVoiceCallPricing pricing = new VoiceCallPricingProxy();

            var results = pricing.GetPricing();

            Assert.IsNotNull(results);
        }
    }
}
