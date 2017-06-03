using System;
using System.Collections.Generic;

namespace MockDataProviders
{
    public static class ConferenceTestMockDataProvider
    {
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
    }
}
