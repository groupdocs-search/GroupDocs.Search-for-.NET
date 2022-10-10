using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class SeparateDataExtraction
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\SeparateDataExtraction";
            string documentPath = Utils.DocumentsPath + @"Lorem ipsum.pdf";

            // Extracting data from a document
            Extractor extractor = new Extractor();
            Document document = Document.CreateFromFile(documentPath);
            ExtractionOptions extractionOptions = new ExtractionOptions();
            extractionOptions.UseRawTextExtraction = false;
            ExtractedData extractedData = extractor.Extract(document, extractionOptions);

            //// Serializing the data
            //byte[] array = extractedData.Serialize();

            //// Deserializing the data
            //ExtractedData deserializedData = ExtractedData.Deserialize(array);

            // Creating an index
            Index index = new Index(indexFolder);

            // Indexing the data
            ExtractedData[] data = new ExtractedData[]
            {
                extractedData
            };
            index.Add(data, new IndexingOptions());

            // Searching in the index
            string query = "ipsum";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
