using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class SynonymSearch
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Searching\SynonymSearch";
            string documentsFolder = Utils.DocumentsPath2;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();
            options.UseSynonymSearch = true; // Enabling synonym search

            // Search for the word 'improve'
            // In addition to the word 'improve', the words 'better' will also be found
            string query = "improve";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
