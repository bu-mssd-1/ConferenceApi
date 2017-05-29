using System.Configuration;

namespace TwilioExternalAdapter
{
    public static class ProviderConstant
    {
        /// <summary>
        /// Twilio account sid
        /// </summary>
        private static string twilioAccountSid;

        /// <summary>
        /// Twilio auth token
        /// </summary>
        private static string twilioAuthToken;

        /// <summary>
        /// Twilio app sid
        /// </summary>
        private static string twilioAppSid;


        /// <summary>
        /// Gets twilio account sid
        /// </summary>
        public static string TwilioAccountSid
        {
            get
            {
                return twilioAccountSid;
            }
        }

        /// <summary>
        /// Gets twilio auth token
        /// </summary>
        public static string TwilioAuthToken
        {
            get
            {
                return twilioAuthToken;
            }
        }

        /// <summary>
        /// Gets twilio app sid
        /// </summary>
        public static string TwilioAppSid
        {
            get
            {
                return twilioAppSid;
            }
        }


        static ProviderConstant()
        {
            twilioAccountSid = ConfigurationManager.AppSettings["TwilioAccountSid"].ToString();
            twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"].ToString();
            twilioAppSid = ConfigurationManager.AppSettings["TwilioTwimlAppSid"].ToString();
        }
    }
}
