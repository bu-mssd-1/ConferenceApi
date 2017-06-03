using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client;
using Contracts;
using MockDataProviders;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class ObserverPatternTests
    {
        [TestMethod]
        public void TestObserver()
        {
            PublisherModule shell = new ShellModule();

            ModuleBase confHistoryModule = new ConferenceHistoryModule();
            confHistoryModule.PhoneNumberChanged += (o, e) =>
            {
                Debug.WriteLine("Conference history data changed " + e.Data);
            };

            ModuleBase confSettingModule = new ConferenceSettingsModule();
            confSettingModule.PhoneNumberChanged += (o, e) =>
            {
                Debug.WriteLine("Conference settings data changed " + e.Data);
            };

            // Attach the observers
            shell.Attach(confHistoryModule);
            shell.Attach(confSettingModule);

            var mockPhoneNumbers = ConferenceTestMockDataProvider.GetMockConferencePhoneNumbers();

            foreach (var p in mockPhoneNumbers)
            {
                // Setting the item will trigger Notify in each module 
                shell.CurrentlySelectedItem = p;
            }
        }
    }
}
