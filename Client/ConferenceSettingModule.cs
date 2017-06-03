using Contracts;
using DataModels;
using MockDataProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Client
{
    public class ConferenceSettingsModule : ModuleBase
    {
        private List<Conference> conferences;

        public override event EventHandler<EventArgs<string>> PhoneNumberChanged;

        public ConferenceSettingsModule()
        {
            this.ModuleId = Guid.NewGuid().ToString();
            this.BuildMockData();
        }

        public override void OnPhoneNumberChanged(string phoneNumber)
        {
            if (this.PhoneNumberChanged != null)
            {
                if (this.conferences != null)
                {
                    var data = this.conferences.Where(c => c.ConferencePhoneNumber == phoneNumber).ToList();
                    var jsonData = JsonConvert.SerializeObject(data);

                    this.PhoneNumberChanged(this, new EventArgs<string>(jsonData));
                }
            }
        }

        private void BuildMockData()
        {
            var conferenceNumbers = ConferenceTestMockDataProvider.GetMockConferencePhoneNumbers();
            var participants = ConferenceTestMockDataProvider.GetMockParticipantPhoneNumbers();
            var conferenceIds = ConferenceTestMockDataProvider.GetMockConferences();

            conferences = new List<Conference>();

            foreach (var conf in conferenceIds)
            {
                foreach (var confNum in conferenceNumbers)
                {
                    conferences.Add(new Conference() { ConferenceId = conf, ConferencePhoneNumber = confNum,
                        ConferenceName = "Conf " + conf, DateCreated = DateTime.Now.AddDays(-1), Participants = string.Join(",", participants) });
                }
            }
        }
    }
}
