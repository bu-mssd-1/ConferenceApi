using Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TwilioExternalAdapter;

namespace UnitTests
{
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public async Task AdapterTest()
        {
            CommonAdapter adapter = new TwilioAdapter();

            var result = await adapter.GetAvailablePhoneNumbers("US", "732");

            Assert.IsNotNull(result);
        }
    }
}
