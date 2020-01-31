using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class IndexingOptionsProperties
    {
        public static void CancellationProperty()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingOptionsProperties\CancellationProperty";
            string documentFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Creating an instance of indexing options
            IndexingOptions options = new IndexingOptions();
            options.Cancellation = new Cancellation(); // Setting a cancellation object
            options.Cancellation.CancelAfter(3000); // Setting a time period of 3 seconds after which the indexing operation will be cancelled

            // Indexing documents from the specified folder
            index.Add(documentFolder, options);

            Utils.TraceIndexedDocuments(index);
        }

        public static void IsAsyncProperty()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingOptionsProperties\IsAsyncProperty";
            string documentFolder = Utils.DocumentsPath;

            // Creating index in the specified folder
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.StatusChanged += (sender, args) =>
            {
                if (args.Status == IndexStatus.Ready || args.Status == IndexStatus.Failed)
                {
                    // A notification of the operation completion should be here
                    Console.WriteLine("Status: " + args.Status);
                }
            };

            // Creating an instance of indexing options
            IndexingOptions options = new IndexingOptions();
            options.IsAsync = true; // Specifying the asynchronous performing of the operation

            // Indexing documents from the specified folder
            // The method will return control before the indexing operation is completed
            index.Add(documentFolder, options);
        }

        public static void ThreadsProperty()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingOptionsProperties\ThreadsProperty";
            string documentFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Creating an instance of indexing options
            IndexingOptions options = new IndexingOptions();
            options.Threads = 2; // Setting the number of indexing threads

            // Indexing documents from the specified folder
            index.Add(documentFolder, options);

            Utils.TraceIndexedDocuments(index);
        }
    }
}
