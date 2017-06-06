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
            this.conferenceHistoryData = ConferenceTestMockDataProvider.GetMockConferenceHistory();
        }
    }
}
