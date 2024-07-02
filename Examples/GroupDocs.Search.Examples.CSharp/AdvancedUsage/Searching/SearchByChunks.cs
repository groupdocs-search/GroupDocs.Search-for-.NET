using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class SearchByChunks
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/SearchByChunks";
            string documentsFolder1 = Utils.DocumentsPath;
            string documentsFolder2 = Utils.DocumentsPath2;
            string documentsFolder3 = Utils.DocumentsPath3;
            string query = "invitation";

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder1);
            index.Add(documentsFolder2);
            index.Add(documentsFolder3);

            // Creating a search options instance
            SearchOptions options = new SearchOptions();
            options.IsChunkSearch = true; // Enabling the search by chunks

            // Starting the search by chunks
            SearchResult result = index.Search(query, options);
            Console.WriteLine("Document count: " + result.DocumentCount);
            Console.WriteLine("Occurrence count: " + result.OccurrenceCount);

            // Continuing the search by chunks
            while (result.NextChunkSearchToken != null)
            {
                result = index.SearchNext(result.NextChunkSearchToken);
                Console.WriteLine();
                Console.WriteLine("Document count: " + result.DocumentCount);
                Console.WriteLine("Occurrence count: " + result.OccurrenceCount);
            }
        }
    }
}
