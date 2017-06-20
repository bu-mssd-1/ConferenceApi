using System.Configuration;

namespace ConferenceWebApi
{
    public static class AppConstant
    {
        #region Private Attributes

        /// <summary>
        /// Database connection string
        /// </summary>
        private static string dataProviderTypeInConfig;

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
        /// Website url 
        /// </summary>
        private static string externalServiceUrlPrefix;

        /// <summary>
        /// Gets data provider type
        /// </summary>
        public static DataProviderType DataProviderType
        {
            get
            {
                DataProviderType d;

                switch (dataProviderTypeInConfig.ToLower())
                {
                    case "sql":
                        d = DataProviderType.Sql;
                        break;

                    case "mock":
                        d = DataProviderType.Mock;
                        break;

                    case "json":
                        d = DataProviderType.Json;
                        break;

                    default:
                        d = DataProviderType.Sql;
                        break;
                }

                return d;
            }
        }
        
        #endregion
        
        #region Properties

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

        /// <summary>
        /// Gets the external service provider url
        /// </summary>
        public static string ExternalServiceUrlPrefix
        {
            get
            {
                return externalServiceUrlPrefix;
            }
        }

        #endregion

        /// <summary>
        /// Static constructor
        /// </summary>
        static AppConstant()
        {
            // Read from configuratio file
            dataProviderTypeInConfig = ConfigurationManager.AppSettings["dataProviderType"];

            twilioAccountSid = ConfigurationManager.AppSettings["TwilioAccountSid"].ToString();
            twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"].ToString();
            twilioAppSid = ConfigurationManager.AppSettings["TwilioTwimlAppSid"].ToString();

            externalServiceUrlPrefix = ConfigurationManager.AppSettings["ExternalServiceUrlPrefix"].ToString();
        }
    }
}