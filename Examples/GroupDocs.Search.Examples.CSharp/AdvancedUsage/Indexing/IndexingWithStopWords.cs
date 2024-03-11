using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class IndexingWithStopWords
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/IndexingWithStopWords";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index settings with disabled using of stop words
            IndexSettings settings = new IndexSettings();
            settings.UseStopWords = false;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in the index
            // Now in the index it is possible to search for the stop word 'on'
            string query = "on";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
