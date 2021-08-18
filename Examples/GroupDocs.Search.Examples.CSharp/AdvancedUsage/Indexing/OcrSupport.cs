using Aspose.OCR;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.IO;
using System.Reflection;
using Tesseract;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class OcrSupport
    {
        public static void UseAsposeOcrConnector()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\OcrSupport\UseAsposeOcrConnector";
            string documentsFolder = Utils.DocumentsPNG;
            string query = "water";

            // Creating an index
            Index index = new Index(indexFolder);

            // Setting the OCR indexing options
            IndexingOptions options = new IndexingOptions();
            options.OcrIndexingOptions.EnabledForSeparateImages = true;
            options.OcrIndexingOptions.EnabledForEmbeddedImages = true;
            options.OcrIndexingOptions.OcrConnector = new AsposeOcrConnector();

            // Indexing documents in a document folder
            index.Add(documentsFolder, options);

            // Searching in the index
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void UseTesseractOcrConnector()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\OcrSupport\UseTesseractOcrConnector";
            string documentsFolder = Utils.DocumentsPNG;
            string query = "water";

            // Creating an index
            Index index = new Index(indexFolder);

            // Setting the OCR indexing options
            IndexingOptions options = new IndexingOptions();
            options.OcrIndexingOptions.EnabledForSeparateImages = true;
            options.OcrIndexingOptions.EnabledForEmbeddedImages = true;
            options.OcrIndexingOptions.OcrConnector = new TesseractOcrConnector();

            // Indexing documents in a document folder
            index.Add(documentsFolder, options);

            // Searching in the index
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        // Implementing the OCR connector that uses Aspose.OCR library
        // You need to install the following package:
        // https://www.nuget.org/packages/Aspose.OCR/
        public class AsposeOcrConnector : IOcrConnector
        {
            public AsposeOcrConnector()
            {
            }

            public string Recognize(OcrContext context)
            {
                string extension = context.ImageFileExtension.ToLowerInvariant();
                if (context.ImageLocation == ImageLocation.Separate)
                {
                    switch (extension)
                    {
                        case ".gif":
                        case ".png":
                        case ".jpg":
                        case ".jpeg":
                        case ".bmp":
                        case ".tif":
                        case ".tiff":
                        case "":
                            return RecognizePrivate(context);

                        default:
                            return null;
                    }
                }
                else if (context.ImageLocation == ImageLocation.Embedded ||
                    context.ImageLocation == ImageLocation.ContainerItem)
                {
                    return RecognizePrivate(context);
                }
                else
                {
                    throw new NotSupportedException("The image type is not supported: " + context.ImageLocation);
                }
            }

            private string RecognizePrivate(OcrContext context)
            {
                MemoryStream memoryStream = new MemoryStream((int)context.ImageStream.Length);
                context.ImageStream.CopyTo(memoryStream);

                AsposeOcr asposeOcr = new AsposeOcr();
                string result = asposeOcr.RecognizeImage(memoryStream);
                return result;
            }
        }

        // Implementing the OCR connector that uses Tesseract
        // You need to install the following packages:
        // https://www.nuget.org/packages/Tesseract/
        // https://www.nuget.org/packages/Tesseract.Data.English/
        public class TesseractOcrConnector : IOcrConnector
        {
            public TesseractOcrConnector()
            {
            }

            public string Recognize(OcrContext context)
            {
                var buffer = new byte[context.ImageStream.Length];
                context.ImageStream.Read(buffer, 0, buffer.Length);

                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                path = Path.Combine(path, "tessdata");
                path = path.Replace("file:\\", "");

                using (var engine = new TesseractEngine(path, "eng", EngineMode.Default))
                using (Pix img = Pix.LoadFromMemory(buffer))
                using (Page recognizedPage = engine.Process(img))
                {
                    string recognizedText = recognizedPage.GetText();
                    return recognizedText;
                }
            }
        }
    }
}
