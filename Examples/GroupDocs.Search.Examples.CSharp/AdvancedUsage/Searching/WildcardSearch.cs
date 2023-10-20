using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class WildcardSearch
    {
        public static void QueryInTextForm()
        {
            string indexFolder = @"./AdvancedUsage/Searching/WildcardSearch/QueryInTextForm";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in the index
            string query1 = "m???is";
            SearchResult result1 = index.Search(query1); // Search for 'mauris', 'mollis', 'mattis', 'magnis', etc.
            string query2 = "pri?(1~7)";
            SearchResult result2 = index.Search(query2); // Search for 'private', 'principles', 'principle', etc.

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2, result2);
        }
    }
}
