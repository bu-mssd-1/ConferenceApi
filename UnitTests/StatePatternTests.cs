using DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockDataProviders;

namespace UnitTests
{
    [TestClass]
    public class StatePatternTests
    {
        [TestMethod]
        public void TestState()
        {
            var conference = ConferenceTestMockDataProvider.GetMockConference();

            // Initial state
            conference.Status = DataModelConstant.ConferenceStarted;
            
            // Set the conference state to pause
            var pauseState = new ConferencePauseState();
            conference.SetState(pauseState);

            // Test if the conference is Paused
            Assert.IsTrue(conference.Status == DataModelConstant.ConferencePaused);

            // Set the conference state to In Progress
            var resumeState = new ConferenceResumeState();
            conference.SetState(resumeState);

            // Test if the conference is Paused
            Assert.IsTrue(conference.Status == DataModelConstant.ConferenceInProgress);

            // Set the conference state to pause
            var endState = new ConferenceEndState();
            conference.SetState(endState);

            // Test if the conference is ended
            Assert.IsTrue(conference.Status == DataModelConstant.ConferenceEnded);
        }
    }
}
