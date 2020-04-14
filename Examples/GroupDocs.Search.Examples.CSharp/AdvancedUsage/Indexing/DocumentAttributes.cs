using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class DocumentAttributes
    {
        public static void ChangeAttributes()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\DocumentAttributes\ChangeAttributes";
            string documentFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Indexing documents in a document folder
            index.Add(documentFolder);

            DocumentInfo[] documents = index.GetIndexedDocuments();

            // Creating an attribute change container object
            AttributeChangeBatch batch = new AttributeChangeBatch();
            // Adding one attribute to all indexed documents
            batch.AddToAll("public");
            // Removing one attribute from one indexed document
            batch.Remove(documents[0].FilePath, "public");
            // Adding two attributes to one indexed document
            batch.Add(documents[0].FilePath, "main", "key");

            // Applying attribute changes in the index
            index.ChangeAttributes(batch);

            // Searching in the index
            SearchOptions options = new SearchOptions();
            // Creating a document filter by attribute
            options.SearchDocumentFilter = SearchDocumentFilter.CreateAttribute("main");
            string query = "length";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }

        public static void AddAttributesDuringIndexing()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\DocumentAttributes\AddAttributesDuringIndexing";
            string documentFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the FileIndexing event for adding attributes
            index.Events.FileIndexing += (sender, args) =>
            {
                if (args.DocumentFullPath.EndsWith("Lorem ipsum.pdf"))
                {
                    // Adding two attributes
                    args.Attributes = new string[] { "main", "key" };
                }
            };

            // Indexing documents in a document folder
            index.Add(documentFolder);

            // Searching in the index
            SearchOptions options = new SearchOptions();
            // Creating a document filter by attribute
            options.SearchDocumentFilter = SearchDocumentFilter.CreateAttribute("main");
            string query = "ipsum";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
