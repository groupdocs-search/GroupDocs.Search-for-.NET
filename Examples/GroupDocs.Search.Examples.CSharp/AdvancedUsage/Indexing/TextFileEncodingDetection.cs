using GroupDocs.Search.Common;
using GroupDocs.Search.Results;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class TextFileEncodingDetection
    {
        public static void SetEncoding()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/TextFileEncodingDetection/SetEncoding";
            string documentsFolder = Utils.DocumentsUtf32Path;

            Utils.PrintHeaderFromPath(indexFolder);

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

        public static void ExternalEncodingDetection()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/TextFileEncodingDetection/ExternalEncodingDetection";
            string documentsFolder = Utils.DocumentsUtf32Path;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.FileIndexing += (sender, args) =>
            {
                byte[] data = File.ReadAllBytes(args.DocumentFullPath);
                UtfUnknown.DetectionResult detectionResult = UtfUnknown.CharsetDetector.DetectFromBytes(data);
                if (detectionResult.Detected != null)
                {
                    Console.WriteLine("Encoding detected: " + detectionResult.Detected.EncodingName);
                    args.Encoding = detectionResult.Detected.EncodingName;
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
