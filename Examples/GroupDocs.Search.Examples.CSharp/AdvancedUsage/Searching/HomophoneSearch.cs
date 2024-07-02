using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class HomophoneSearch
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/HomophoneSearch";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();
            options.UseHomophoneSearch = true; // Enabling homophone search

            // Search for the word 'call'
            // In addition to the word 'call', the word 'caul' will also be found
            string query = "call";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
