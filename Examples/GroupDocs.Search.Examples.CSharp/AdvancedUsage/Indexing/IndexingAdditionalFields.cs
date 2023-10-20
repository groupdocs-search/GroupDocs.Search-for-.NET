using GroupDocs.Search.Common;
using GroupDocs.Search.Results;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class IndexingAdditionalFields
    {
        public static void Run()
        {
            // Defining a dictionary containing subjects of documents
            Dictionary<string, string> subjects = new Dictionary<string, string>();
            subjects.Add(Path.GetFullPath(Path.Combine(Utils.DocumentsPath, "Lorem ipsum.pdf")).ToLowerInvariant(), "Latin");
            subjects.Add(Path.GetFullPath(Path.Combine(Utils.DocumentsPath, "English.docx")).ToLowerInvariant(), "English");
            subjects.Add(Path.GetFullPath(Path.Combine(Utils.DocumentsPath, "Lorem ipsum.docx")).ToLowerInvariant(), "Latin");
            subjects.Add(Path.GetFullPath(Path.Combine(Utils.DocumentsPath, "English.txt")).ToLowerInvariant(), "English");
            subjects.Add(Path.GetFullPath(Path.Combine(Utils.DocumentsPath, "Lorem ipsum.txt")).ToLowerInvariant(), "Latin");

            string indexFolder = @"./AdvancedUsage/Indexing/IndexingAdditionalFields";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.FileIndexing += (sender, args) =>
            {
                string subject;
                if (subjects.TryGetValue(args.DocumentFullPath.ToLowerInvariant(), out subject)) // Getting a subject for the current document
                {
                    args.AdditionalFields = new DocumentField[] // Setting additional fields for the current document
                    {
                        new DocumentField("Subject", subject)
                    };
                }
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);

            string query = "Subject: Latin";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
