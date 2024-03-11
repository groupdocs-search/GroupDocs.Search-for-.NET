using GroupDocs.Search.Options;
using System;
using System.Text.RegularExpressions;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class DocumentFilteringDuringIndexing
    {
        public static void SettingAFilter()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/SettingAFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating a filter that skips documents with extensions '.doc', '.docx', '.rtf'
            IndexSettings settings = new IndexSettings();
            DocumentFilter fileExtensionFilter = DocumentFilter.CreateFileExtension(".doc", ".docx", ".rtf"); // Creating file extension filter that allows only specified extensions
            DocumentFilter invertedFilter = DocumentFilter.CreateNot(fileExtensionFilter); // Inverting file extension filter to allow all extensions except specified ones
            settings.DocumentFilter = invertedFilter;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void CreationTimeFilters()
        {
            // The first filter skips files created earlier than January 1, 2017, 00:00:00 a.m.
            DocumentFilter filter1 = DocumentFilter.CreateCreationTimeLowerBound(new DateTime(2017, 1, 1));

            // The second filter skips files created later than June 15, 2018, 00:00:00 a.m.
            DocumentFilter filter2 = DocumentFilter.CreateCreationTimeUpperBound(new DateTime(2018, 6, 15));

            // The third filter skips files created outside the range from January 1, 2017, 00:00:00 a.m. to June 15, 2018, 00:00:00 a.m.
            DocumentFilter filter3 = DocumentFilter.CreateCreationTimeRange(new DateTime(2017, 1, 1), new DateTime(2018, 6, 15));


            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/CreationTimeFilters";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            settings.DocumentFilter = filter3; // Setting the filter

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void ModificationTimeFilters()
        {
            // The first filter skips files modified earlier than January 1, 2017, 00:00:00 a.m.
            DocumentFilter filter1 = DocumentFilter.CreateModificationTimeLowerBound(new DateTime(2017, 1, 1));

            // The second filter skips files modified later than June 15, 2018, 00:00:00 a.m.
            DocumentFilter filter2 = DocumentFilter.CreateModificationTimeUpperBound(new DateTime(2018, 6, 15));

            // The third filter skips files modified outside the range from January 1, 2017, 00:00:00 a.m. to June 15, 2018, 00:00:00 a.m.
            DocumentFilter filter3 = DocumentFilter.CreateModificationTimeRange(new DateTime(2017, 1, 1), new DateTime(2018, 6, 15));


            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/ModificationTimeFilters";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            settings.DocumentFilter = filter2; // Setting the filter

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void FilePathFilters()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/FilePathFilters";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            // Creating a filter that skips files that do not contain the word 'Ipsum' in their paths
            DocumentFilter filter = DocumentFilter.CreateFilePathRegularExpression("Ipsum", RegexOptions.IgnoreCase);
            settings.DocumentFilter = filter;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void FileLengthFilters()
        {
            // The first filter skips documents less than 50 KB in length
            DocumentFilter filter1 = DocumentFilter.CreateFileLengthLowerBound(50 * 1024);

            // The second filter skips documents more than 10 MB in length
            DocumentFilter filter2 = DocumentFilter.CreateFileLengthUpperBound(10 * 1024 * 1024);

            // The third filter skips documents less than 50 KB and more than 100 KB in length
            DocumentFilter filter3 = DocumentFilter.CreateFileLengthRange(50 * 1024, 100 * 1024);


            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/FileLengthFilters";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            settings.DocumentFilter = filter3; // Setting the filter

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void FileExtensionFilter()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/FileExtensionFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            // This filter allows indexing only FB2, EPUB, and TXT files
            DocumentFilter filter = DocumentFilter.CreateFileExtension(".fb2", ".epub", ".txt");
            settings.DocumentFilter = filter; // Setting the filter

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void LogicalNotFilter()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/LogicalNotFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            DocumentFilter filter = DocumentFilter.CreateFileExtension(".htm", ".html", ".pdf");
            DocumentFilter invertedFilter = DocumentFilter.CreateNot(filter); // Inverting file extension filter to allow all extensions except of HTM, HTML, and PDF
            settings.DocumentFilter = invertedFilter;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void LogicalAndFilter()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/LogicalAndFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            DocumentFilter filter1 = DocumentFilter.CreateCreationTimeRange(new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));
            DocumentFilter filter2 = DocumentFilter.CreateFileExtension(".txt");
            DocumentFilter filter3 = DocumentFilter.CreateFileLengthUpperBound(8 * 1024 * 1024);
            DocumentFilter finalFilter = DocumentFilter.CreateAnd(filter1, filter2, filter3);
            settings.DocumentFilter = finalFilter; // Setting the filter

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }

        public static void LogicalOrFilter()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DocumentFilteringDuringIndexing/LogicalOrFilter";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            IndexSettings settings = new IndexSettings();
            DocumentFilter txtFilter = DocumentFilter.CreateFileExtension(".txt");
            DocumentFilter notTxtFilter = DocumentFilter.CreateNot(txtFilter);
            DocumentFilter bound5Filter = DocumentFilter.CreateFileLengthUpperBound(5 * 1024 * 1024);
            DocumentFilter bound10Filter = DocumentFilter.CreateFileLengthUpperBound(10 * 1024 * 1024);
            DocumentFilter txtSizeFilter = DocumentFilter.CreateAnd(txtFilter, bound5Filter);
            DocumentFilter notTxtSizeFilter = DocumentFilter.CreateAnd(notTxtFilter, bound10Filter);
            DocumentFilter finalFilter = DocumentFilter.CreateOr(txtSizeFilter, notTxtSizeFilter);
            settings.DocumentFilter = finalFilter; // Setting the filter

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents
            index.Add(documentsFolder);

            Utils.TraceIndexedDocuments(index);
        }
    }
}
