using GroupDocs.Search.Common;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class SearchReports
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/SearchReports";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in index
            string query1 = "water";
            SearchResult result1 = index.Search(query1);
            string query2 = "\"Lorem ipsum\"";
            SearchResult result2 = index.Search(query2);

            // Getting search reports
            SearchReport[] reports = index.GetSearchReports();

            // Printing reports to the console
            foreach (SearchReport report in reports)
            {
                Console.WriteLine("Query: " + report.TextQuery);
                Console.WriteLine("Time: " + report.StartTime);
                Console.WriteLine("Duration: " + report.SearchDuration);
                Console.WriteLine("Documents: " + report.DocumentCount);
                Console.WriteLine("Occurrences: " + report.OccurrenceCount);
                Console.WriteLine();
            }
        }
    }
}
