using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class StoringTextOfIndexedDocuments
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/StoringTextOfIndexedDocuments";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index settings instance
            IndexSettings settings = new IndexSettings();
            settings.TextStorageSettings = new TextStorageSettings(Compression.High); // Setting high compression ratio for the index text storage

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            // Now the index contains the text of all indexed documents,
            // so the operations of getting the text of documents and highlighting occurrences are faster.

            // Searching
            string query = "Lorem";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
