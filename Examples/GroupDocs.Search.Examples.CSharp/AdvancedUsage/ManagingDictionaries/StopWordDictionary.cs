using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class StopWordDictionary
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\ManagingDictionaries\StopWordDictionary\Index";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index from in specified folder
            Index index = new Index(indexFolder);

            if (index.Dictionaries.StopWordDictionary.Count > 0)
            {
                // Removing all words from the dictionary
                index.Dictionaries.StopWordDictionary.Clear();
            }

            // Adding stop words to the dictionary
            string[] words = new string[] { "a", "an", "the", "but", "by" };
            index.Dictionaries.StopWordDictionary.AddRange(words);

            if (index.Dictionaries.StopWordDictionary.Contains("but") &&
                index.Dictionaries.StopWordDictionary.Contains("by"))
            {
                // Removing words from the dictionary
                index.Dictionaries.StopWordDictionary.RemoveRange(new string[] { "but", "by" });
            }

            // Export words to a file
            string fileName = @".\AdvancedUsage\ManagingDictionaries\StopWordDictionary\Words.txt";
            index.Dictionaries.StopWordDictionary.ExportDictionary(fileName);

            // Import words from a file
            index.Dictionaries.StopWordDictionary.ImportDictionary(fileName);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in the index
            string query = "but";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
