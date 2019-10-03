using GroupDocs.Search.Common;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class IndexingReports
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingReports";
            string documentsFolder1 = Utils.DocumentsPath;
            string documentsFolder2 = Utils.DocumentsPath2;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents
            index.Add(documentsFolder1);
            index.Add(documentsFolder2);

            // Getting indexing reports
            IndexingReport[] reports = index.GetIndexingReports();

            // Printing information from reports to the console
            foreach (IndexingReport report in reports)
            {
                Console.WriteLine("Time: " + report.StartTime);
                Console.WriteLine("Duration: " + report.IndexingTime);
                Console.WriteLine("Documents total: " + report.TotalDocumentsInIndex);
                Console.WriteLine("Terms total: " + report.TotalTermCount);
                Console.WriteLine("Indexed documents size (MB): " + report.IndexedDocumentsSize);
                Console.WriteLine("Index size (MB): " + (report.TotalIndexSize / 1024.0 / 1024.0));
                Console.WriteLine();
            }
        }
    }
}
