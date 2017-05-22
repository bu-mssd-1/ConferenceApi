using System.Configuration;

namespace ConferenceWebApi
{
    public static class AppConstant
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        private static string dataProviderTypeInConfig;
        
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

                    case "xml":
                        d = DataProviderType.Xml;
                        break;

                    default:
                        d = DataProviderType.Sql;
                        break;
                }

                return d;
            }
        }
        
        /// <summary>
        /// Static constructor
        /// </summary>
        static AppConstant()
        {
            // Read from configuratio file
            dataProviderTypeInConfig = ConfigurationManager.AppSettings["dataProviderType"];
        }
    }
}