using System.Configuration;

namespace JsonDataProviders
{
    public static class JsonProviderConstant
    {
        /// <summary>
        /// Index folder path
        /// </summary>
        private static string indexFolderPath;

        /// <summary>
        /// Data folder path
        /// </summary>
        private static string dataFolderPath;

        /// <summary>
        /// Gets or sets the index folder path
        /// </summary>
        public static string IndexFolderPath
        {
            get
            {
                return indexFolderPath;
            }
        }

        /// <summary>
        /// Gets or sets the data folder path
        /// </summary>
        public static string DataFolderPath
        {
            get
            {
                return dataFolderPath;
            }
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static JsonProviderConstant()
        {
            indexFolderPath = ConfigurationManager.AppSettings["indexFolderPath"];
            dataFolderPath = ConfigurationManager.AppSettings["dataFolderPath"];
        }
    }
}