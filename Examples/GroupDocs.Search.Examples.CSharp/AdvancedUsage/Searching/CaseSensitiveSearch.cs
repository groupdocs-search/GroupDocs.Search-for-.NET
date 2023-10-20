using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class CaseSensitiveSearch
    {
        public static void QueryInTextForm()
        {
            string indexFolder = @"./AdvancedUsage/Searching/CaseSensitiveSearch/QueryInTextForm";
            string documentsFolder = Utils.DocumentsPath;

            Index index = new Index(indexFolder); // Creating index in the specified folder
            index.Add(documentsFolder); // Indexing documents from the specified folder

            SearchOptions options = new SearchOptions();
            options.UseCaseSensitiveSearch = true; // Enabling case sensitive search

            string query = "Advantages";
            SearchResult result = index.Search(query, options); // Searching

            Utils.TraceResult(query, result);
        }

        public static void QueryInObjectForm()
        {
            string indexFolder = @"./AdvancedUsage/Searching/CaseSensitiveSearch/QueryInObjectForm";
            string documentsFolder = Utils.DocumentsPath;

            Index index = new Index(indexFolder); // Creating index in the specified folder
            index.Add(documentsFolder); // Indexing documents from the specified folder

            SearchOptions options = new SearchOptions();
            options.UseCaseSensitiveSearch = true; // Enabling case sensitive search

            SearchQuery query = SearchQuery.CreateWordQuery("Advantages"); // Creating search query in object form

            SearchResult result = index.Search(query, options); // Searching

            Utils.TraceResult(query.ToString(), result);
        }
    }
}
