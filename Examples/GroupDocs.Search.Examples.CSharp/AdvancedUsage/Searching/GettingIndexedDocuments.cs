using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class GettingIndexedDocuments
    {
        public static void GettingDocuments()
        {
            string indexFolder = @"./AdvancedUsage/Searching/GettingIndexedDocuments/GettingDocuments";
            string documentsFolder = Utils.ArchivesPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Getting list of indexed documents
            DocumentInfo[] documents = index.GetIndexedDocuments();
            for (int i = 0; i < documents.Length; i++)
            {
                DocumentInfo document = documents[i];
                Console.WriteLine(document.FilePath);
                DocumentInfo[] items = index.GetIndexedDocumentItems(document); // Getting list of document items
                for (int j = 0; j < items.Length; j++)
                {
                    DocumentInfo item = items[j];
                    Console.WriteLine("\t" + item.InnerPath);
                }
            }
        }

        public static void GettingTextOfIndexedDocuments()
        {
            string indexFolder = @"./AdvancedUsage/Searching/GettingIndexedDocuments/GettingTextOfIndexedDocuments";
            string documentsFolder = Utils.ArchivesPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index settings instance
            IndexSettings settings = new IndexSettings();
            settings.TextStorageSettings = new TextStorageSettings(Compression.High); // Enabling storage of extracted text in the index

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Getting list of indexed documents
            DocumentInfo[] documents = index.GetIndexedDocuments();

            // Getting a document text
            if (documents.Length > 0)
            {
                FileOutputAdapter outputAdapter = new FileOutputAdapter(OutputFormat.Html, @"./AdvancedUsage/Searching/GettingIndexedDocuments/Text.html");
                index.GetDocumentText(documents[0], outputAdapter);

                // Getting list of files in the archive
                DocumentInfo[] items = index.GetIndexedDocumentItems(documents[0]);
                if (items.Length > 0)
                {
                    FileOutputAdapter outputAdapter2 = new FileOutputAdapter(OutputFormat.Html, @"./AdvancedUsage/Searching/GettingIndexedDocuments/ItemText.html");
                    index.GetDocumentText(items[0], outputAdapter2);
                }
            }
        }
    }
}
