using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class SearchForDifferentWordForms
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Searching\SearchForDifferentWordForms";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options instance
            SearchOptions options = new SearchOptions();
            options.UseWordFormsSearch = true; // Enabling search for word forms

            // Searching in the index
            string query = "wished";
            SearchResult result = index.Search(query, options);

            // The following words can be found:
            // wished
            // wish

            Utils.TraceResult(query, result);
        }
    }
}
