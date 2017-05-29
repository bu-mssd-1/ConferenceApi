using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System.Collections.Generic;

namespace JsonDataProviders
{
    public class LuceneIndexer
    {
        /// <summary>
        /// Lucene index directory
        /// </summary>
        private FSDirectory indexFolder;

        /// <summary>
        /// Lucene index writer
        /// </summary>
        private IndexWriter writer;

        /// <summary>
        /// Lucene analyzer
        /// </summary>
        private StandardAnalyzer analyzer;

        /// <summary>
        /// Search in fields
        /// </summary>
        private string[] searchFields = new string[] { "Id", "UserId", "ConferenceId", "VirtualPhoneNumberId", "PhoneNumber" };
        
        /// <summary>
        /// Creates a new instance of the LuceneIndexer class.
        /// </summary>
        /// <param name="folderPath">A path to index folder</param>
        public LuceneIndexer(string folderPath)
        {
            if (System.IO.Directory.Exists(folderPath))
            {
                indexFolder = FSDirectory.Open(folderPath);
            }

            analyzer = new StandardAnalyzer(Version.LUCENE_30);
            writer = new IndexWriter(indexFolder, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
        }

        /// <summary>
        /// Queries the index store
        /// </summary>
        /// <param name="query">A query</param>
        /// <returns>A search result</returns>
        public SearchResult Query(string query)
        {
            var result = default(SearchResult);

            using (var searcher = new IndexSearcher(indexFolder))
            {
                QueryParser parser = new MultiFieldQueryParser(Version.LUCENE_30, searchFields, analyzer);

                var hits = searcher.Search(parser.Parse(query), 10).ScoreDocs;

                if (hits != null)
                {
                    result = new SearchResult()
                    {
                        Query = query,
                        Hits = hits.Length,
                        Items = new List<SearchItem>()
                    };

                    foreach (var hit in hits)
                    {
                        var doc = searcher.Doc(hit.Doc);
                        result.Items.Add(new SearchItem() { Id = doc.Get("Id"), Score = hit.Score });
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Adds a document to the index store
        /// </summary>
        /// <param name="document">A document</param>
        public void AddDocumentToIndex(LuceneDocument document)
        {
            this.DeleteDocumentFromIndex(document);
            writer.AddDocument(document.Document);
        }

        /// <summary>
        /// Deletes a document from the index store
        /// </summary>
        /// <param name="document"></param>
        public void DeleteDocumentFromIndex(LuceneDocument document)
        {
            var q = new TermQuery(new Term("Id", document.Id));
            writer.DeleteDocuments(q);
        }

        /// <summary>
        /// Optimize the index
        /// </summary>
        public void Optimize()
        {
            analyzer = new StandardAnalyzer(Version.LUCENE_30);

            using (var writer = new IndexWriter(indexFolder, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
                writer.Dispose();
            }
        }
    }
}
