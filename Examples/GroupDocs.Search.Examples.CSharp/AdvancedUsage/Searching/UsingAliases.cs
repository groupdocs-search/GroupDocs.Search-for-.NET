using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class UsingAliases
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/UsingAliases";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Adding aliases to the alias dictionary
            index.Dictionaries.AliasDictionary.Add("t", "(gravida OR promotion)");
            index.Dictionaries.AliasDictionary.Add("e", "(viverra OR farther)");

            // Search in the index
            string query = "@t OR @e";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
