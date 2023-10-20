using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml
{
    class HighlightExample
    {
        public static void Run()
        {
            string licensePath = @"E:/Licenses/Conholdate/Total/Subscription/Valid/Conholdate.Total.Product.Family.lic";

            // Setting licenses
            new Aspose.Html.License().SetLicense(licensePath);
            new GroupDocs.Viewer.License().SetLicense(licensePath);

            string basePath = @"./HighlightInHtml/HighlightExample";
            string viewerCacheFolderPath = basePath + @"/ViewerCache";
            string indexFolder = basePath + @"/Index";
            string documentsFolder = Utils.DocumentsPath;
            string query = "\"dapibus diam\" OR lorem";

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in index
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);

            // Generating HTML
            FoundDocument foundDocument = result.GetFoundDocument(0);
            IndexedFileInfo fileInfo = new IndexedFileInfo(viewerCacheFolderPath, foundDocument.DocumentInfo.FilePath);
            HighlightService highlightService = new HighlightService(fileInfo, null);

            // Highlighting in HTML
            highlightService.Highlight(foundDocument, index.Dictionaries.Alphabet);
        }
    }
}
