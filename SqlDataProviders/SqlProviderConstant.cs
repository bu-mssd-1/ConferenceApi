using System.Configuration;

namespace SqlDataProviders
{
    public static class SqlProviderConstant
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        private static string databaseConnectionString;
        
        /// <summary>
        /// Gets database connection string
        /// </summary>
        public static string DatabaseConnectionString
        {
            get
            {
                return databaseConnectionString;
            }
        }
        
        /// <summary>
        /// Static constructor
        /// </summary>
        static SqlProviderConstant()
        {
            // Read from configuratio file
            databaseConnectionString = ConfigurationManager.ConnectionStrings["databaseConnectionString"].ConnectionString;
        }
    }
}