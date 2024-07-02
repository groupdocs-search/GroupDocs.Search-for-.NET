using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.Text.RegularExpressions;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class DocumentFilteringInSearchResult
    {
        public static void SettingAFilter()
        {
            string indexFolder = @"./AdvancedUsage/Searching/DocumentFilteringInSearchResult/SettingAFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();
            options.SearchDocumentFilter = SearchDocumentFilter.CreateFileExtension(".txt"); // Setting a document filter

            // Search in the index
            // Only text documents will be returned as the result of the search
            string query = "education";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }

        public static void FilePathFilters()
        {
            string indexFolder = @"./AdvancedUsage/Searching/DocumentFilteringInSearchResult/FilePathFilters";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();

            // The filter returns only files that contain the word 'Lorem' in their paths, not case sensitive
            ISearchDocumentFilter filter = SearchDocumentFilter.CreateFilePathRegularExpression("Lorem", RegexOptions.IgnoreCase);

            // Setting a document filter
            options.SearchDocumentFilter = filter;

            // Search in the index
            string query = "Advantages";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }

        public static void FileExtensionFilter()
        {
            string indexFolder = @"./AdvancedUsage/Searching/DocumentFilteringInSearchResult/FileExtensionFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();

            // This filter returns only PDF and DOCX documents
            ISearchDocumentFilter filter = SearchDocumentFilter.CreateFileExtension(".pdf", ".docx");

            // Setting a document filter
            options.SearchDocumentFilter = filter;

            // Search in the index
            string query = "ipsum";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }

        public static void AttributeFilter()
        {
            string indexFolder = @"./AdvancedUsage/Searching/DocumentFilteringInSearchResult/AttributeFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            string[] mainAttribute = new string[] { "main" };
            index.Events.FileIndexing += (sender, args) =>
            {
                if (args.DocumentFullPath.EndsWith(".txt", System.StringComparison.OrdinalIgnoreCase))
                {
                    args.Attributes = mainAttribute;
                }
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();

            // This filter returns only documents that have attribute "main"
            ISearchDocumentFilter filter = SearchDocumentFilter.CreateAttribute("main");

            // Setting a document filter
            options.SearchDocumentFilter = filter;

            // Search in the index
            string query = "ipsum OR length";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }

        public static void CombiningFilters()
        {
            // Creating an AND composite filter that returns all FB2 and EPUB documents that have the word 'Einstein' in their full paths
            ISearchDocumentFilter filter1 = SearchDocumentFilter.CreateFilePathRegularExpression("Einstein", RegexOptions.IgnoreCase);
            ISearchDocumentFilter filter2 = SearchDocumentFilter.CreateFileExtension(".fb2", ".epub");
            ISearchDocumentFilter andFilter = SearchDocumentFilter.CreateAnd(filter1, filter2);

            // Creating an OR composite filter that returns all DOC, DOCX, PDF and all documents that have the word Einstein in their full paths
            ISearchDocumentFilter filter3 = SearchDocumentFilter.CreateFilePathRegularExpression("Einstein", RegexOptions.IgnoreCase);
            ISearchDocumentFilter filter4 = SearchDocumentFilter.CreateFileExtension(".doc", ".docx", ".pdf");
            ISearchDocumentFilter orFilter = SearchDocumentFilter.CreateOr(filter3, filter4);

            // Creating a filter that returns all found documents except of TXT documents
            ISearchDocumentFilter filter5 = SearchDocumentFilter.CreateFileExtension(".txt");
            ISearchDocumentFilter notFilter = SearchDocumentFilter.CreateNot(filter5);


            string indexFolder = @"./AdvancedUsage/Searching/DocumentFilteringInSearchResult/CombiningFilters";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Creating a search options object
            SearchOptions options = new SearchOptions();

            // Setting a document filter
            options.SearchDocumentFilter = notFilter;

            // Search in the index
            string query = "ipsum";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
