using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class BooleanSearch
    {
        public static void OperatorAnd()
        {
            string indexFolder = @".\AdvancedUsage\Searching\BooleanSearch\OperatorAnd";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search with text query
            string query1 = "comfort AND promotion";
            SearchResult result1 = index.Search(query1);

            // Search with object query
            SearchQuery wordQuery1 = SearchQuery.CreateWordQuery("comfort");
            SearchQuery wordQuery2 = SearchQuery.CreateWordQuery("promotion");
            SearchQuery andQuery = SearchQuery.CreateAndQuery(wordQuery1, wordQuery2);
            SearchResult result2 = index.Search(andQuery);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(andQuery.ToString(), result2);
        }

        public static void OperatorOr()
        {
            string indexFolder = @".\AdvancedUsage\Searching\BooleanSearch\OperatorOr";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search with text query
            string query1 = "comfort OR neque";
            SearchResult result1 = index.Search(query1);

            // Search with object query
            SearchQuery wordQuery1 = SearchQuery.CreateWordQuery("comfort");
            SearchQuery wordQuery2 = SearchQuery.CreateWordQuery("neque");
            SearchQuery orQuery = SearchQuery.CreateOrQuery(wordQuery1, wordQuery2);
            SearchResult result2 = index.Search(orQuery);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(orQuery.ToString(), result2);
        }

        public static void OperatorNot()
        {
            string indexFolder = @".\AdvancedUsage\Searching\BooleanSearch\OperatorNot";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search with text query
            string query1 = "sportsman AND NOT Kynynmound";
            SearchResult result1 = index.Search(query1);

            // Search with object query
            SearchQuery wordQuery1 = SearchQuery.CreateWordQuery("sportsman");
            SearchQuery wordQuery2 = SearchQuery.CreateWordQuery("Kynynmound");
            SearchQuery notQuery = SearchQuery.CreateNotQuery(wordQuery2);
            SearchQuery andQuery = SearchQuery.CreateAndQuery(wordQuery1, notQuery);
            SearchResult result2 = index.Search(andQuery);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(andQuery.ToString(), result2);
        }

        public static void ComplexQueries()
        {
            string indexFolder = @".\AdvancedUsage\Searching\BooleanSearch\ComplexQueries";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search with text query
            string query1 = "(sportsman AND favourable) AND NOT (Kynynmound OR Murray)";
            SearchResult result1 = index.Search(query1);

            // Search with object query
            SearchQuery word1Query = SearchQuery.CreateWordQuery("sportsman");
            SearchQuery word2Query = SearchQuery.CreateWordQuery("favourable");
            SearchQuery andQuery = SearchQuery.CreateAndQuery(word1Query, word2Query);

            SearchQuery word3Query = SearchQuery.CreateWordQuery("Kynynmound");
            SearchQuery word4Query = SearchQuery.CreateWordQuery("Murray");
            SearchQuery orQuery = SearchQuery.CreateOrQuery(word3Query, word4Query);
            SearchQuery notQuery = SearchQuery.CreateNotQuery(orQuery);

            SearchQuery rootQuery = SearchQuery.CreateAndQuery(andQuery, notQuery);
            SearchResult result2 = index.Search(rootQuery);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(rootQuery.ToString(), result2);
        }
    }
}
