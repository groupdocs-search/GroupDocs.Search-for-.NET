using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class FuzzySearch
    {
        public static void SettingFuzzySearchAlgorithm()
        {
            string indexFolder = @"./AdvancedUsage/Searching/FuzzySearch/SettingFuzzySearchAlgorithm";
            string documentsFolder = Utils.DocumentsPath;
            string query = "nulla";

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            SearchOptions options = new SearchOptions();
            options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
            options.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.8); // Creating the fuzzy search algorithm
            // This function specifies 0 as the maximum number of mistakes for words from 1 to 4 characters.
            // It specifies 1 as the maximum number of mistakes for words from 5 to 9 characters.
            // It specifies 2 as the maximum number of mistakes for words from 10 to 14 characters. And so on.

            // Search in index
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }

        public static void SettingStepFunction()
        {
            string indexFolder = @"./AdvancedUsage/Searching/FuzzySearch/SettingStepFunction";
            string documentsFolder = Utils.DocumentsPath;
            string query = "nulla";

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            SearchOptions options = new SearchOptions();
            options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
            options.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1, new Step(5, 2), new Step(8, 3)); // Creating the fuzzy search algorithm
            // This function specifies 1 as the maximum number of mistakes for words from 1 to 4 characters.
            // It specifies 2 as the maximum number of mistakes for words from 5 to 7 characters.
            // It specifies 3 as the maximum number of mistakes for words from 8 and more characters.

            // Search in index
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
