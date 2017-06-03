using Contracts;
using DataModels;
using MockDataProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    public class ConferenceHistoryModule : ModuleBase
    {
        private List<ConferenceHistoryItem> conferenceHistoryData;

        public override event EventHandler<EventArgs<string>> PhoneNumberChanged;

        public ConferenceHistoryModule()
        {
            this.ModuleId = Guid.NewGuid().ToString();
            this.BuildMockData();
        }

        public override void OnPhoneNumberChanged(string phoneNumber)
        {
            if (this.PhoneNumberChanged != null)
            {
                if (this.conferenceHistoryData != null)
                {
                    var data = this.conferenceHistoryData.Where(c => c.ConferencePhoneNumber == phoneNumber);
                    var jsonData = JsonConvert.SerializeObject(data);

                    this.PhoneNumberChanged(this, new EventArgs<string>(jsonData));
                }
            }
        }

        private void BuildMockData()
        {
            var conferenceNumbers = ConferenceTestMockDataProvider.GetMockConferencePhoneNumbers();
            var participantNumbers = ConferenceTestMockDataProvider.GetMockParticipantPhoneNumbers();
            var conferenceIds = ConferenceTestMockDataProvider.GetMockConferences();

            conferenceHistoryData = new List<ConferenceHistoryItem>();

            foreach (var conf in conferenceIds)
            {
                foreach (var confNum in conferenceNumbers)
                {
                    foreach (var participant in participantNumbers)
                    {
                        conferenceHistoryData.Add(new ConferenceHistoryItem() { ConferenceId = conf, ConferencePhoneNumber = confNum,
                            ParticipantPhoneNumber = participant, Start = DateTime.Now.AddMinutes(-20), End = DateTime.Now.AddMinutes(-2) });
                    }
                }
            }
        }
    }
}
