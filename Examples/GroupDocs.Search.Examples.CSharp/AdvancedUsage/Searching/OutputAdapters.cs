using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class OutputAdapters
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Searching\OutputAdapters\Index";
            string documentsFolder = Utils.DocumentsPath;

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
                DocumentInfo document = documents[0];

                // Output to a file
                FileOutputAdapter fileOutputAdapter = new FileOutputAdapter(OutputFormat.Html, @".\AdvancedUsage\Searching\OutputAdapters\Text.html");
                index.GetDocumentText(document, fileOutputAdapter);

                // Output to a stream
                using (Stream stream = new MemoryStream())
                {
                    StreamOutputAdapter streamOutputAdapter = new StreamOutputAdapter(OutputFormat.Html, stream);
                    index.GetDocumentText(document, streamOutputAdapter);
                }

                // Output to a string
                StringOutputAdapter stringOutputAdapter = new StringOutputAdapter(OutputFormat.Html);
                index.GetDocumentText(document, stringOutputAdapter);
                string result = stringOutputAdapter.GetResult();
                //Console.WriteLine(result);

                // Output to a structure
                StructureOutputAdapter structureOutputAdapter = new StructureOutputAdapter(OutputFormat.PlainText);
                index.GetDocumentText(document, structureOutputAdapter);
                DocumentField[] fields = structureOutputAdapter.GetResult();
                Console.WriteLine(document.ToString());
                for (int i = 0; i < fields.Length; i++)
                {
                    DocumentField field = fields[i];
                    Console.WriteLine("\t" + field.Name);
                }
            }
        }
    }
}
