using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contracts;
using MockDataProviders;
using DataModels;

namespace UnitTests
{
    /// <summary>
    /// This is a test for COR pattern
    /// </summary>
    [TestClass]
    public class ChainOfResponsibilityTest
    {
        [TestMethod]
        public void TestBillProcess()
        {
            BillProcess callDurationCollector = new CallDurationCollector();
            BillProcess callCostCollector = new CallCostProcessor();

            callDurationCollector.SetSuccessor(callCostCollector);

            // Make sure we have the right successor for call duration collector
            Assert.IsTrue(callDurationCollector.Successor.GetType() == typeof(CallCostProcessor));
            
            var confHistory = ConferenceTestMockDataProvider.MockConferenceHistory.FirstOrDefault();
            var conference = new Conference() { ConferenceId = confHistory.ConferenceId,
                ConferencePhoneNumber = confHistory.ConferencePhoneNumber };

            // Make sure the total duration and total cost is zero at this point
            Assert.IsTrue(conference.Cost == null);
            Assert.IsTrue(conference.TotalDuration == 0);

            callDurationCollector.Process(conference);

            // Make sure that total duration and total cost is greater than zero at this point
            Assert.IsTrue(conference.Cost != null);
            Assert.IsTrue(conference.TotalDuration > 0);
        }
    }
}

