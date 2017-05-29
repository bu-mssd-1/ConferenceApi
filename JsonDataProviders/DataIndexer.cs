using DataModels;
using System;

namespace JsonDataProviders
{
    /// <summary>
    /// A singleton data indexer
    /// </summary>
    public class DataIndexer
    {
        /// <summary>
        /// A private instance of the data inxer
        /// </summary>
        private static DataIndexer instance;

        /// <summary>
        /// So that we can lock
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// An instance of a data indexer
        /// </summary>
        private static LuceneIndexer indexer;

        /// <summary>
        /// A private constructor that ensures that we have only one instance of the DataIndexer
        /// </summary>
        private DataIndexer()
        {
            indexer = new LuceneIndexer(JsonProviderConstant.IndexFolderPath);
        }

        /// <summary>
        /// An instance of the DataIndexer
        /// </summary>
        public static DataIndexer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DataIndexer();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Queries an indexed folder
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A searchresult</returns>
        public SearchResult Query(string query)
        {
            if (indexer != null)
            {
                return indexer.Query(query);
            }

            return null;
        }

        /// <summary>
        /// Adds an object to index store
        /// </summary>
        /// <typeparam name="T">An object that inherited from BaseModel</typeparam>
        /// <param name="obj">An object that inherited from BaseModel</param>
        public void AddObjectToIndex<T>(T obj) where T : BaseModel
        {
            if (indexer != null)
            {
                var dict = ObjectToDictionary<T>.ToDictionary(obj);
                var doc = new LuceneDocument(obj.Id, dict);
                indexer.AddDocumentToIndex(doc);
            }
        }

        /// <summary>
        /// Deletes an object from index store
        /// </summary>
        /// <typeparam name="T">An object that inherited from BaseModel</typeparam>
        /// <param name="obj">An object that inherited from BaseModel</param>
        public void DeleteObjectFromIndex<T>(T obj) where T : BaseModel
        {
            if (indexer != null)
            {
                var dict = ObjectToDictionary<T>.ToDictionary(obj);
                var doc = new LuceneDocument(obj.Id, dict);
                indexer.DeleteDocumentFromIndex(doc);
            }
        }
    }
}
