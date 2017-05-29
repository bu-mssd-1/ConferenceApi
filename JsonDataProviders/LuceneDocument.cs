using Lucene.Net.Documents;
using System.Collections.Generic;

namespace JsonDataProviders
{
    public class LuceneDocument
    {
        /// <summary>
        /// A lucene document
        /// </summary>
        private Document document;

        /// <summary>
        /// Gets or sets document Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Intializes a new instance of the LuceneDocument class
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <param name="content">A dictionary</param>
        public LuceneDocument(string id, Dictionary<string, string> content)
        {
            this.Id = id;
            document = new Document();

            // Must index the Id
            document.Add(new Field("id", id, Field.Store.YES, Field.Index.ANALYZED));

            foreach (var item in content)
            {
                document.Add(new Field(item.Key, item.Value, Field.Store.YES, Field.Index.ANALYZED));
            }
        }

        /// <summary>
        /// Gets the document
        /// </summary>
        public Document Document
        {
            get
            {
                return this.document;
            }
        }
    }
}
