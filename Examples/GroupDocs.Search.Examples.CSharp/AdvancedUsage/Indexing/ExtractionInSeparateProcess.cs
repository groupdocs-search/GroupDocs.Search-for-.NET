using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class ExtractionInSeparateProcess
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/ExtractionInSeparateProcess";
            string documentFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            string assemblyPath = typeof(GroupDocs.Search.Extraction.Program).Assembly.Location;

            Index index = new Index(indexFolder, new IndexSettings(), true);
            index.Events.ErrorOccurred += (sender, args) =>
            {
                Console.WriteLine(args.Message);
            };
            index.Events.OperationProgressChanged += (sender, args) =>
            {
                Console.WriteLine("Processed " + args.ProcessedDocuments + " of " + args.TotalDocuments);
            };

            IndexingOptions options = new IndexingOptions();
            options.SeparateProcessOptions.ExtractInSeparateProcess = true;
            options.SeparateProcessOptions.AssemblyPath = assemblyPath;
            options.SeparateProcessOptions.Timeout = new TimeSpan(0, 1, 0);
            index.Add(documentFolder, options);

            string query = "Lorem";
            SearchResult result = index.Search(query);
            Utils.TraceResult(query, result);
        }
    }
}
