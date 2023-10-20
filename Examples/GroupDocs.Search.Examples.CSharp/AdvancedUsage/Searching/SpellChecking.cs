using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class SpellChecking
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/SpellChecking";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options instance
            SearchOptions options = new SearchOptions();
            options.SpellingCorrector.Enabled = true; // Enabling the spelling correction
            options.SpellingCorrector.MaxMistakeCount = 1; // Setting the maximum number of mistakes
            options.SpellingCorrector.OnlyBestResults = true; // Enabling the option for only the best results of the spelling correction

            // Search for the word "houseohld" containing a spelling error
            // The word "household" will be found that differs from the search query in two transposed letters
            string query = "houseohld";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
