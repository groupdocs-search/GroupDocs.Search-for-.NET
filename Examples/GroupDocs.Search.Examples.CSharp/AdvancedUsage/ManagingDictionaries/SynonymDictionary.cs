using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class SynonymDictionary
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\ManagingDictionaries\SynonymDictionary\Index";
            string documentsFolder = Utils.DocumentsPath2;

            // Creating an index from in specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            if (index.Dictionaries.SynonymDictionary.Count > 0)
            {
                // Removing all synonyms from the dictionary
                index.Dictionaries.SynonymDictionary.Clear();
            }

            // Adding synonyms to the dictionary
            string[][] synonymGroups = new string[][]
            {
                new string[] { "achieve", "accomplish", "attain", "reach" },
                new string[] { "accept", "take", "have" },
                new string[] { "improve", "better" },
            };
            index.Dictionaries.SynonymDictionary.AddRange(synonymGroups);

            // Export synonyms to a file
            string fileName = @".\AdvancedUsage\ManagingDictionaries\SynonymDictionary\Synonyms.dat";
            index.Dictionaries.SynonymDictionary.ExportDictionary(fileName);

            // Import synonyms from a file
            index.Dictionaries.SynonymDictionary.ImportDictionary(fileName);

            // Search in the index
            string query = "better";
            SearchOptions options = new SearchOptions();
            options.UseSynonymSearch = true; // Enabling synonym search
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
