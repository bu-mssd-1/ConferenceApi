using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MockDataProviders
{
    public static class ConferenceTestMockDataProvider
    {
        private static List<ConferenceHistoryItem> mockConferenceHistory;

        /// <summary>
        /// A static list of history items for test purpose
        /// </summary>
        public static List<ConferenceHistoryItem> MockConferenceHistory
        {
            get
            {
                if (mockConferenceHistory == null)
                {
                    mockConferenceHistory = GetMockConferenceHistory();
                }

                return mockConferenceHistory;
            }
        }

        public static List<string> GetMockConferencePhoneNumbers()
        {
            var phoneNumbers = new List<string>();

            phoneNumbers.Add("2064445555");
            phoneNumbers.Add("4253338888");
            phoneNumbers.Add("9724448888");
            phoneNumbers.Add("2143339999");
            phoneNumbers.Add("9041113333");

            return phoneNumbers;
        }

        public static List<string> GetMockParticipantPhoneNumbers()
        {
            var phoneNumbers = new List<string>();

            phoneNumbers.Add("3124446666");
            phoneNumbers.Add("4258889999");
            phoneNumbers.Add("2028883333");
            phoneNumbers.Add("2109998888");

            return phoneNumbers;
        }

        public static List<string> GetMockConferences()
        {
            var conferences = new List<string>();

            conferences.Add(Guid.NewGuid().ToString());
            conferences.Add(Guid.NewGuid().ToString());
            conferences.Add(Guid.NewGuid().ToString());

            return conferences;
        }

        public static List<ConferenceHistoryItem> GetMockConferenceHistory()
        {
            var conferenceNumbers = GetMockConferencePhoneNumbers();
            var participantNumbers = GetMockParticipantPhoneNumbers();
            var conferenceIds = GetMockConferences();

            var conferenceHistoryData = new List<ConferenceHistoryItem>();

            foreach (var conf in conferenceIds)
            {
                foreach (var confNum in conferenceNumbers)
                {
                    foreach (var participant in participantNumbers)
                    {
                        conferenceHistoryData.Add(new ConferenceHistoryItem()
                        {
                            ConferenceId = conf,
                            ConferencePhoneNumber = confNum,
                            ParticipantPhoneNumber = participant,
                            Start = DateTime.Now.AddMinutes(-20),
                            End = DateTime.Now.AddMinutes(-2)
                        });
                    }
                }
            }

            return conferenceHistoryData;
        }

        public static Conference GetMockConference()
        {
            return new Conference()
            {
                ConferenceId = Guid.NewGuid().ToString(),
                ConferenceName = "Test Conference",
                ConferencePhoneNumber = GetMockConferencePhoneNumbers().FirstOrDefault(),
                Cost = 0,
                DateCreated = DateTime.Now,
                Participants = string.Join(",", GetMockParticipantPhoneNumbers()),
                ProviderId = Guid.NewGuid().ToString(),
                Status = "Completed",
                UserId = Guid.NewGuid().ToString()
            };
        }

        public static Dictionary<string, decimal> GetBillRates()
        {
            var phoneNumbers = GetMockParticipantPhoneNumbers();
            var billRates = new Dictionary<string, decimal>();
            double min = double.Parse("0.06");
            double max = double.Parse("0.24");

            var r = new Random();

            // Randomly assign bill rates for different area codes
            foreach (var p in phoneNumbers)
            {
                var areaCode = p.Substring(0, 3);
                var rate = r.NextDouble() * ((max - min)+ min);

                billRates.Add(areaCode, decimal.Parse(rate.ToString()));
            }

            return billRates;
        }
    }
}
