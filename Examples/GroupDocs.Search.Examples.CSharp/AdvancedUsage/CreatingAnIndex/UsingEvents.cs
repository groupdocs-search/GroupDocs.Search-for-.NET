using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.CreatingAnIndex
{
    class UsingEvents
    {
        public static void OperationFinishedEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/OperationFinishedEvent";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.OperationFinished += (sender, args) =>
            {
                // Writing operation details to the console
                Console.WriteLine("Operation finished: " + args.OperationType);
                Console.WriteLine("Message: " + args.Message);
                Console.WriteLine("Index folder: " + args.IndexFolder);
                Console.WriteLine("Time: " + args.Time);
            };

            // Indexing documents from the specified folder
            IndexingOptions options = new IndexingOptions();
            options.IsAsync = true; // Enabling asynchronous indexing mode
            index.Add(documentsFolder, options);
        }

        public static void ErrorOccurredEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/ErrorOccurredEvent";
            string documentsFolder = Utils.PasswordProtectedDocumentsPath;
            string query = "Lorem";

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.ErrorOccurred += (sender, args) =>
            {
                // Writing an error message to the console
                Console.WriteLine(args.Message);
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in the index
            SearchResult result = index.Search(query);
        }

        public static void OperationProgressChangedEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/OperationProgressChangedEvent";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.OperationProgressChanged += (sender, args) =>
            {
                Console.WriteLine("Last processed: " + args.LastDocumentPath);
                Console.WriteLine("Result: " + args.LastDocumentStatus);
                Console.WriteLine("Processed documents: " + args.ProcessedDocuments);
                Console.WriteLine("Progress percentage: " + args.ProgressPercentage);
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);
        }

        public static void OptimizationProgressChangedEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/OptimizationProgressChangedEvent";
            string[] documents = new string[]
            {
                Utils.DocumentsPath + "English.docx",
                Utils.DocumentsPath + "English.txt",
                Utils.DocumentsPath + "Lorem ipsum.docx",
                Utils.DocumentsPath + "Lorem ipsum.pdf",
                Utils.DocumentsPath + "Lorem ipsum.txt",
            };

            // Creating an index
            Index index = new Index(indexFolder);

            // Indexing documents
            index.Add(documents[0]);
            index.Add(documents[1]);
            index.Add(documents[2]);
            index.Add(documents[3]);
            index.Add(documents[4]);

            // Subscribing to the event
            index.Events.OptimizationProgressChanged += (sender, args) =>
            {
                Console.WriteLine();
                Console.WriteLine("Processed segments: " + args.ProcessedSegments);
                Console.WriteLine("Total segments: " + args.TotalSegments);
                Console.WriteLine("Progress percentage: " + args.ProgressPercentage);
            };

            index.Optimize();
        }

        public static void PasswordRequiredEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/PasswordRequiredEvent";
            string documentsFolder = Utils.PasswordProtectedDocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.PasswordRequired += (sender, args) =>
            {
                if (args.DocumentFullPath.EndsWith("English.docx", StringComparison.InvariantCultureIgnoreCase))
                {
                    args.Password = "123456";
                }
                else if (args.DocumentFullPath.EndsWith("Lorem ipsum.docx", StringComparison.InvariantCultureIgnoreCase))
                {
                    args.Password = "123456";
                }
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in the index
            string query = "Lorem OR sportsman";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void FileIndexingEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/FileIndexingEvent";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.FileIndexing += (sender, args) =>
            {
                if (args.DocumentFullPath.EndsWith("Lorem ipsum.docx", StringComparison.InvariantCultureIgnoreCase))
                {
                    args.AdditionalFields = new DocumentField[]
                    {
                        new DocumentField("Tags", "Lorem")
                    };
                }
                if (!args.DocumentFullPath.ToLowerInvariant().Contains("lorem"))
                {
                    args.SkipIndexing = true;
                }
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in the index
            string query = "Tags:lorem";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void StatusChangedEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/StatusChangedEvent";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.StatusChanged += (sender, args) =>
            {
                if (args.Status == IndexStatus.Ready || args.Status == IndexStatus.Failed)
                {
                    // A notification of the operation completion should be here
                    Console.WriteLine("Operation finished!");
                }
            };

            // Setting the flag for asynchronous indexing
            IndexingOptions options = new IndexingOptions();
            options.IsAsync = true;

            // Asynchronous indexing documents from the specified folder
            // The method terminates before the operation completes
            index.Add(documentsFolder, options);
        }

        public static void SearchPhaseCompletedEvent()
        {
            string indexFolder = @"./AdvancedUsage/CreatingAnIndex/UsingEvents/SearchPhaseCompletedEvent";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Subscribing to the event
            index.Events.SearchPhaseCompleted += (sender, args) =>
            {
                Console.WriteLine("Search phase: " + args.SearchPhase);
                Console.WriteLine("Words: " + args.Words.Length);
                for (int i = 0; i < args.Words.Length; i++)
                {
                    Console.WriteLine("\t" + args.Words[i]);
                }
                Console.WriteLine();
            };

            SearchOptions options = new SearchOptions();
            options.UseSynonymSearch = true;
            options.UseWordFormsSearch = true;
            options.FuzzySearch.Enabled = true;
            options.UseHomophoneSearch = true;
            SearchResult result = index.Search("buy", options);
        }
    }
}
