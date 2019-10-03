using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class HomophoneDictionary
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\ManagingDictionaries\HomophoneDictionary\Index";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index from in specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            if (index.Dictionaries.HomophoneDictionary.Count > 0)
            {
                // Removing all homophones from the dictionary
                index.Dictionaries.HomophoneDictionary.Clear();
            }

            // Adding homophones to the dictionary
            string[][] homophoneGroups = new string[][]
            {
                new string[] { "awe", "oar", "or", "ore" },
                new string[] { "aye", "eye", "i" },
                new string[] { "call", "caul" },
            };
            index.Dictionaries.HomophoneDictionary.AddRange(homophoneGroups);

            // Export homophones to a file
            string fileName = @".\AdvancedUsage\ManagingDictionaries\HomophoneDictionary\Homophones.dat";
            index.Dictionaries.HomophoneDictionary.ExportDictionary(fileName);

            // Import homophones from a file
            index.Dictionaries.HomophoneDictionary.ImportDictionary(fileName);

            // Search in the index
            string query = "caul";
            SearchOptions options = new SearchOptions();
            options.UseHomophoneSearch = true;
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
