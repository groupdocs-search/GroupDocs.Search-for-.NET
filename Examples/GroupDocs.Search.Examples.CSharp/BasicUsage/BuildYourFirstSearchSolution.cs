using GroupDocs.Search.Common;
using GroupDocs.Search.Highlighters;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.BasicUsage
{
    class BuildYourFirstSearchSolution
    {
        public static void RunSynchronousIndexing()
        {
            string indexFolder = @".\BasicUsage\BuildYourFirstSearchSolution\SynchronousIndexing"; // Specify the path to the index folder
            string documentsFolder = Utils.DocumentsPath; // Specify the path to a folder containing documents to search

            // a) Create new index or
            // b) Open existing index
            Index index = new Index(indexFolder);

            // c) Subscribe to index events
            index.Events.ErrorOccurred += (sender, args) =>
            {
                Console.WriteLine(args.Message); // Writing error messages to the console
            };

            // d) Add files synchronously
            index.Add(documentsFolder); // Synchronous indexing documents from the specified folder

            // f) Perform search
            string query = "tincidunt"; // Specify a search query
            SearchResult result = index.Search(query); // Searching in the index

            // g) Use search results
            // Printing the result
            Console.WriteLine("Documents found: " + result.DocumentCount);
            Console.WriteLine("Total occurrences found: " + result.OccurrenceCount);
            for (int i = 0; i < result.DocumentCount; i++)
            {
                FoundDocument document = result.GetFoundDocument(i);
                Console.WriteLine("\tDocument: " + document.DocumentInfo.FilePath);
                Console.WriteLine("\tOccurrences: " + document.OccurrenceCount);
            }

            // Highlight occurrences in text
            if (result.DocumentCount > 0)
            {
                FoundDocument document = result.GetFoundDocument(0); // Getting the first found document
                string path = @".\BasicUsage\Highlighted.html";
                OutputAdapter outputAdapter = new FileOutputAdapter(OutputFormat.Html, path); // Creating the output adapter to a file
                DocumentHighlighter highlighter = new DocumentHighlighter(outputAdapter); // Creating the highlighter object
                index.Highlight(document, highlighter); // Generating output HTML formatted document with highlighted search results

                Console.WriteLine();
                Console.WriteLine("Generated HTML file can be opened with Internet browser.");
                Console.WriteLine("The file can be found by the following path:");
                Console.WriteLine(Path.GetFullPath(path));
            }
        }

        public static void RunAsynchronousIndexing()
        {
            string indexFolder = @".\BasicUsage\BuildYourFirstSearchSolution\AsynchronousIndexing"; // Specify the path to the index folder
            string documentsFolder = Utils.DocumentsPath; // Specify the path to a folder containing documents to search

            // a) Create new index or
            // b) Open existing index
            Index index = new Index(indexFolder);

            // c) Subscribe to ErrorOccurred events
            index.Events.ErrorOccurred += (sender, args) =>
            {
                Console.WriteLine(args.Message); // Writing error messages to the console
            };

            // c) Subscribe to StatusChanged event
            index.Events.StatusChanged += (sender, args) =>
            {
                if (args.Status == IndexStatus.Ready || args.Status == IndexStatus.Failed)
                {
                    // There should be a code indicating the completion of the operation
                    Console.WriteLine("Indexing completed.");
                }
            };

            // e) Add files asynchronously
            // Setting the flag for asynchronous indexing
            IndexingOptions options = new IndexingOptions();
            options.IsAsync = true;

            // Asynchronous indexing documents from the specified folder
            // The current method terminates before the operation completes
            index.Add(documentsFolder, options);
        }
    }
}
