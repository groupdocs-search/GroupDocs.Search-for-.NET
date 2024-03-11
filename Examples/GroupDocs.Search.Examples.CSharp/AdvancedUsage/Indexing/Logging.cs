using GroupDocs.Search.Common;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
        }

        public void Error(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public void Trace(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Logging
    {
        public static void UseOfStandardFileLogger()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/Logging/UseOfStandardFileLogger";
            string documentsFolder = Utils.DocumentsPath;
            string query = "Lorem";
            string logPath = @"./AdvancedUsage/Indexing/Logging/Log.txt";

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            settings.Logger = new FileLogger(logPath, 4.0); // Specifying the path to the log file and a maximum length of 4 MB

            Index index = new Index(indexFolder, settings); // Creating or loading an index from the specified folder

            index.Add(documentsFolder); // Indexing documents from the specified folder

            SearchResult result = index.Search(query); // Search in index

            Utils.TraceResult(query, result);
        }

        public static void ImplementingCustomLogger()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/Logging/ImplementingCustomLogger";
            string documentsFolder = Utils.DocumentsPath;
            string query = "Lorem";

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            settings.Logger = new ConsoleLogger(); // Setting the custom logger

            Index index = new Index(indexFolder, settings); // Creating or loading an index from the specified folder

            index.Add(documentsFolder); // Indexing documents from the specified folder

            SearchResult result = index.Search(query); // Search in index

            Utils.TraceResult(query, result);
        }
    }
}
