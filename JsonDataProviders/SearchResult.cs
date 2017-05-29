using System.Collections.Generic;

namespace JsonDataProviders
{
    public class SearchResult
    {
        public string Query { get; set; }
        public List<SearchItem> Items { get; set;}
        public int Hits { get; set; }
    }

    public class SearchItem
    {
        public string Id { get; set; }
        public float Score { get; set; }
    }
}
