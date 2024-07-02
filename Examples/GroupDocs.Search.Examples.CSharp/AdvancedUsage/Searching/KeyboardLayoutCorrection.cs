using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class KeyboardLayoutCorrection
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/KeyboardLayoutCorrection";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();
            options.KeyboardLayoutCorrector.Enabled = true; // Enabling keyboard layout correction

            // Search for word 'ызщкеыьфт' gives documents containing word 'sportsman'
            string query = "ызщкеыьфт";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
