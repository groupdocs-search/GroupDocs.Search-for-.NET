using GroupDocs.Search.Common;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class TextFileEncodingDetection
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\TextFileEncodingDetection";
            string documentsFolder = Utils.DocumentsUtf32Path;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.FileIndexing += (sender, args) =>
            {
                if (args.DocumentFullPath.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase))
                {
                    args.Encoding = Encodings.utf_32; // Setting encoding for each text file
                }
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in index
            string query = "eagerness";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
