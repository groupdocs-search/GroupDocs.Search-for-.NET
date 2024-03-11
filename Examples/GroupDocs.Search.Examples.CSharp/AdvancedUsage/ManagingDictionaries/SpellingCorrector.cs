using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class SpellingCorrector
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/ManagingDictionaries/SpellingCorrector/Index";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index from in specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            if (index.Dictionaries.SpellingCorrector.Count > 0)
            {
                // Removing all words from the dictionary
                index.Dictionaries.SpellingCorrector.Clear();
            }

            // Adding words to the dictionary
            string[] words = new string[] { "achieve", "accomplish", "attain", "expression", "reach" };
            index.Dictionaries.SpellingCorrector.AddRange(words);

            // Export words to a file
            string fileName = @"./AdvancedUsage/ManagingDictionaries/SpellingCorrector/Words.txt";
            index.Dictionaries.SpellingCorrector.ExportDictionary(fileName);

            // Import words from a file
            index.Dictionaries.SpellingCorrector.ImportDictionary(fileName);

            // Search in the index
            string query = "experssino";
            SearchOptions options = new SearchOptions();
            options.SpellingCorrector.Enabled = true;
            options.SpellingCorrector.MaxMistakeCount = 2;
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
