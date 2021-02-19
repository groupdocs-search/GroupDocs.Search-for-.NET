using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class DeleteIndexedDocuments
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\DeleteIndexedDocuments";
            string filePath = Utils.DocumentsPath + "English.docx";
            string query = "moment";

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing the document from stream
            DocumentLoader documentLoader = new DocumentLoader(filePath);
            Document document = Document.CreateLazy(DocumentSourceKind.Stream, documentLoader.DocumentKey, documentLoader);
            Document[] documents = new Document[] { document };
            index.Add(documents, new IndexingOptions());

            // Getting indexed documents from the index
            DocumentInfo[] indexedDocuments1 = index.GetIndexedDocuments();

            // Writing indexed documents to the console
            Console.WriteLine($"Indexed documents ({indexedDocuments1.Length}):");
            foreach (DocumentInfo info in indexedDocuments1)
            {
                Console.WriteLine("\t" + info);
            }

            // Searching in the index
            SearchResult searchResult1 = index.Search(query);
            Utils.TraceResult(query, searchResult1);

            // Deleting indexed document from the index
            string[] documentKeys = new string[] { documentLoader.DocumentKey };
            DeleteResult deleteResult = index.Delete(new UpdateOptions(), documentKeys);
            Console.WriteLine("\nDeleted documents: " + deleteResult.SuccessCount);

            // Getting indexed documents after deletion
            DocumentInfo[] indexedDocuments2 = index.GetIndexedDocuments();

            Console.WriteLine($"\nIndexed documents ({indexedDocuments2.Length}):");
            foreach (DocumentInfo info in indexedDocuments2)
            {
                Console.WriteLine("\t" + info);
            }

            // Searching in the index
            SearchResult searchResult2 = index.Search(query);
            Utils.TraceResult(query, searchResult2);
        }

        // Implementing document loader
        private class DocumentLoader : IDocumentLoader
        {
            private readonly string filePath;
            private readonly string documentKey;

            public DocumentLoader(string filePath)
            {
                this.filePath = filePath;
                documentKey = Path.GetFileName(filePath);
            }

            public string DocumentKey
            {
                get { return documentKey; }
            }

            public void CloseDocument()
            {
            }

            public Document LoadDocument()
            {
                string extension = Path.GetExtension(filePath);
                byte[] buffer = File.ReadAllBytes(filePath);
                Stream stream = new MemoryStream(buffer);
                Document document = Document.CreateFromStream(documentKey, DateTime.Now, extension, stream);
                return document;
            }
        }
    }
}
