using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class NumericRangeSearch
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/NumericRangeSearch";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search with text query
            string query1 = "400 ~~ 4000";
            SearchResult result1 = index.Search(query1);

            // Search with object query
            SearchQuery query2 = SearchQuery.CreateNumericRangeQuery(400, 4000);
            SearchResult result2 = index.Search(query2);

            Utils.TraceResult(query1, result2);
            Utils.TraceResult(query2.ToString(), result2);
        }
    }
}
