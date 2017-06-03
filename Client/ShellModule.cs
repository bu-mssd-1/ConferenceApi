using Contracts;
using MockDataProviders;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    public class ShellModule : PublisherModule
    {
        /// <summary>
        /// A placeholders for phone numbers
        /// </summary>
        private List<string> phoneNumbers;

        

        /// <summary>
        /// Creates a new instance of the shell module
        /// </summary>
        public ShellModule()
        {
            this.phoneNumbers = this.GetMockPhoneNumbers();

            // pick the first phone number in the list to be the selected phone number
            this.CurrentlySelectedItem = this.phoneNumbers.FirstOrDefault();
        }

        

        /// <summary>
        /// Returns a list of phone numbers
        /// </summary>
        /// <returns></returns>
        private List<string> GetMockPhoneNumbers()
        {
            return ConferenceTestMockDataProvider.GetMockConferencePhoneNumbers();
        }
    }
}
