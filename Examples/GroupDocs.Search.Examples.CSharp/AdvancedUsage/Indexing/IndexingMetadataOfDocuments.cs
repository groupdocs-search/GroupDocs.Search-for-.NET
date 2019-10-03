using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class IndexingMetadataOfDocuments
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingMetadataOfDocuments";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an instance of index settings
            IndexSettings settings = new IndexSettings();
            settings.IndexType = IndexType.MetadataIndex; // Setting index type

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in the index
            string query = "English";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
