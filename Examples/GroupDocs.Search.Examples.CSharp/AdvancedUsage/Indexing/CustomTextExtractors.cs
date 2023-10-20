using GroupDocs.Search.Common;
using GroupDocs.Search.Results;
using System;
using System.Globalization;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    public class LogExtractor : IFieldExtractor
    {
        private readonly string[] extensions = new string[] { ".log" };

        public string[] Extensions
        {
            get { return extensions; }
        }

        public DocumentField[] GetFields(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            DocumentField[] fields = new DocumentField[]
            {
                new DocumentField("FileName", fileInfo.FullName),
                new DocumentField("CreationDate", fileInfo.CreationTime.ToString(CultureInfo.InvariantCulture)),
                new DocumentField("Content", ExtractContent(filePath)),
            };
            return fields;
        }

        public DocumentField[] GetFields(Stream stream)
        {
            throw new NotSupportedException();
        }

        private string ExtractContent(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return text;
        }
    }

    class CustomTextExtractors
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/CustomTextExtractors"; // Specify path to the index folder
            string documentsFolder = Utils.LogPath; // Specify path to a folder containing documents to search

            IndexSettings settings = new IndexSettings();
            settings.CustomExtractors.Add(new LogExtractor()); // Adding custom text extractor to the index settings

            Index index = new Index(indexFolder, settings); // Creating or loading an index

            index.Add(documentsFolder); // Indexing documents from the specified folder

            string query1 = "objection";
            SearchResult result1 = index.Search(query1); // Searching

            string query2 = "log";
            SearchResult result2 = index.Search(query2); // Searching

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2, result2);
        }
    }
}
