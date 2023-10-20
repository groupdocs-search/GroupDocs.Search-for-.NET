using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class UpdateIndex
    {
        public static void UpdateIndexedDocuments()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/UpdateIndex/UpdateIndexedDocuments/Index";
            string documentFolder = @"./AdvancedUsage/Indexing/UpdateIndex/UpdateIndexedDocuments/Documents";
            string query = "son";

            // Prepare data
            Utils.CleanDirectory(documentFolder);
            Utils.CopyFiles(Utils.DocumentsPath, documentFolder);


            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            SearchResult searchResult = index.Search(query);
            Utils.TraceResult(query, searchResult);


            // Change, delete, add documents in the document folder
            // ...
            // Adding documents to indexed folder
            Utils.CopyFiles(Utils.DocumentsPath4, documentFolder);


            UpdateOptions options = new UpdateOptions();
            options.Threads = 2; // Setting the number of indexing threads
            index.Update(options); // Updating the index

            SearchResult searchResult2 = index.Search(query);
            Utils.TraceResult(query, searchResult2);
        }

        public static void UpdateIndexVersion()
        {
            string oldIndexFolder = Utils.OldIndexPath;
            string sourceIndexFolder = @"./AdvancedUsage/Indexing/UpdateIndex/UpdateIndexVersion/SourceIndex";
            string targetIndexFolder = @"./AdvancedUsage/Indexing/UpdateIndex/UpdateIndexVersion/TargetIndex";

            // Prepare data
            Utils.CleanDirectory(sourceIndexFolder);
            Utils.CleanDirectory(targetIndexFolder);
            Utils.CopyFiles(oldIndexFolder, sourceIndexFolder);


            // Creating updater
            IndexUpdater updater = new IndexUpdater();

            if (updater.CanUpdateVersion(sourceIndexFolder))
            {
                // The index of old version does not change
                VersionUpdateResult result = updater.UpdateVersion(sourceIndexFolder, targetIndexFolder);
            }

            // Loading index from target folder
            Index index = new Index(targetIndexFolder);

            // Searching in index
            string query = "eagerness";
            SearchResult searchResult = index.Search(query);

            Utils.TraceResult(query, searchResult);
        }
    }
}
