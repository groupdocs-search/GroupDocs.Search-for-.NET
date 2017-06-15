using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Search;
using GroupDocs.Search.Events;


namespace GroupDocs.Search_for_.NET
{
    class Indexing
    {
        /// <summary>
        /// Updates index
        /// </summary>
        public static void UpdateIndex()
        {
            //ExStart:UpdateIndex
            // Load index
            Index index = new Index(Utilities.indexPath);
            index.Update();
            //ExEnd:UpdateIndex
        }

        /// <summary>
        /// Updates index repository
        /// </summary>
        public static void UpdateIndexInRepository()
        {
            //ExStart:UpdateIndexInRepository
            IndexRepository repository = new IndexRepository();
            repository.AddToRepository(Utilities.indexPath);
            repository.AddToRepository(Utilities.indexPath2);
            // Update all indexes in repository
            repository.Update();
            //ExEnd:UpdateIndexInRepository
        }

        /// <summary>
        /// Updates index asynchronously
        /// </summary>
        public static void UpdateIndexAsynchronously()
        {
            //ExStart:UpdateIndexAsynchronously
            //Load index
            Index index = new Index(Utilities.indexPath);
            index.OperationFinished += Utilities.index_OperationFinished;
            // Update index asynchronously
            index.UpdateAsync();
            //ExEnd:UpdateIndexAsynchronously
        }

        /// <summary>
        /// Updates index in repository asynchronously
        /// </summary>
        public static void UpdateIndexInRepoAsynchronously()
        {
            //ExStart:UpdateIndexInRepoAsynchronously
            IndexRepository repository = new IndexRepository();
            repository.OperationFinished += Utilities.index_OperationFinished;

            repository.AddToRepository(Utilities.indexPath);
            repository.AddToRepository(Utilities.indexPath2);

            // Update all indexes in repository asynchronously
            repository.UpdateAsync();
            //ExEnd:UpdateIndexInRepoAsynchronously
        }

        /// <summary>
        /// Creates index in memory
        /// </summary>
        public static void CreateIndexInMemory()
        {
            //ExStart:CreateIndexInMemory
            // Create index in memory
            Index index1 = new Index();
            // Create index in memory using Index Repository
            IndexRepository repository = new IndexRepository();
            Index index2 = repository.Create();
            //ExEnd:CreateIndexInMemory
        }

        /// <summary>
        /// Creates index on disk
        /// </summary>
        public static void CreateIndexOnDisk()
        {
            //ExStart:CreateIndexOnDisk
            // Create index on disk
            Index index1 = new Index(Utilities.indexPath);
            // Create index on disk using Index Repository
            IndexRepository repository = new IndexRepository();
            Index index2 = repository.Create(Utilities.indexPath2);
            //ExEnd:CreateIndexOnDisk
        }

        /// <summary>
        /// Creates index in memory with index settings
        /// </summary>
        public static void CreateIndexInMemoryWithIndexSettings()
        {
            //ExStart:CreateIndexInMemoryWithIndexSettings
            bool quickIndexing = true;
            IndexingSettings settings = new IndexingSettings(quickIndexing);

            // Create index on disk
            Index index1 = new Index(settings);

            // Create index on disk using Index Repository
            IndexRepository repository = new IndexRepository();
            Index index2 = repository.Create(settings);
            //ExEnd:CreateIndexInMemoryWithIndexSettings
        }

        /// <summary>
        /// Creates with overwriting existed index
        /// </summary>
        public static void CreateWithOverwritingExistedIndex()
        {
            //ExStart:CreateWithOverwritingExistedIndex
            // Create index on disk. If Index folder is not empty it will be rewited
            Index index1 = new Index(Utilities.indexPath, true);

            // Create index on disk using Index Repository
            IndexRepository repository = new IndexRepository();
            Index index2 = repository.Create(Utilities.indexPath);
            //ExEnd:CreateWithOverwritingExistedIndex
        }

        /// <summary>
        /// Loads index
        /// </summary>
        public static void LoadIndex()
        {
            //ExStart:loadindex
            // Load index
            Index index = new Index(Utilities.indexPath);

            // Load indexes to index repository
            IndexRepository repository = new IndexRepository();
            repository.AddToRepository(index);
            //repository.AddToRepository(Utilities.indexPath2);
            //ExEnd:loadindex
        }

        /// <summary>
        /// Adds document to index
        /// </summary>
        public static void AddDocumentToIndex()
        {
            //ExStart:AddDocumentToIndex
            // Create index
            Index index = new Index(Utilities.indexPath);
            // all files from folder and its subfolders will be added to the index
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:AddDocumentToIndex
        }

        /// <summary>
        /// Adds document to index with progress percentage event
        /// </summary>
        public static void GetIndexingProgressPercentage()
        {
            //ExStart:GetIndexingProgressPercentage
            // Create index
            Index index = new Index(Utilities.indexPath, true);

            index.OperationProgressChanged += index_OperationProgressChanged; // event subscribing
            // all files from folder and its subfolders will be added to the index
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:GetIndexingProgressPercentage
        }

        static void index_OperationProgressChanged(object sender, GroupDocs.Search.Events.OperationProgressArg e)
        {
            Console.WriteLine("Current progress: {0}\n{1}", e.ProgressPercentage, e.Message); // event argument contains information about the current progress of operation
        }

        /// <summary>
        /// Adds document to index asynchronously
        /// </summary>
        public static void AddDocumentToIndexAsynchronously()
        {
            //ExStart:AddDocumentToIndexAsynchronously
            // Create index
            Index index = new Index(Utilities.indexPath);
            index.OperationFinished += Utilities.index_OperationFinished;
            // all files from folder and its subfolders will be added to the index
            index.AddToIndexAsync(Utilities.documentsPath);
            //ExEnd:AddDocumentToIndexAsynchronously
        }

        /// <summary>
        /// Subscription to events
        /// </summary>
        public static void SubscriptionToEvents()
        {
            //ExStart:SubscriptionToEvents
            // Create index in memory
            Index index = new Index();
            index.OperationFinished += Utilities.index_OperationFinished;
            index.AddToIndexAsync(Utilities.documentsPath);
            index.UpdateAsync();
            //ExEnd:SubscriptionToEvents
        }

        /// <summary>
        /// Custom extractor test
        /// </summary>
        public static void CustomExtractor()
        {
            //ExStart:CustomExtractor
            Index index = new Index(Utilities.indexPath);
            index.CustomExtractors.Add(new CustomFieldExtractor());

            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:CustomExtractor
        }


        /// <summary>
        /// Adds PowerPoint Document to index
        /// </summary>
        public static void AddPowerPointDocumentToIndex()
        {
            //ExStart:AddPowerPointDocumentToIndex
            // Create index
            Index index = new Index(Utilities.indexPath);
            // all files from folder and its subfolders will be added to the index
            index.AddToIndex(Utilities.documentsPath);

            SearchResults results1 = index.Search("author:cisco"); // searching by author of presentation
            SearchResults results2 = index.Search("LastSavedBy:teresa"); // searching by person who saved presentation last time
            //ExEnd:AddPowerPointDocumentToIndex
        }

        /// <summary>
        /// Prevents Unnecessary File Indexing
        /// </summary>
        public static void PreventUnnecessaryFileIndex()
        {
            //ExStart: PreventUnnecessaryFileIndex
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Try add the same documents to index
            index.AddToIndex(Utilities.documentsPath); // Already indexed files will not be reindexed.
            //ExEnd: PreventUnnecessaryFileIndex
        }

        /// <summary>
        /// Tracks all the changes in the index folder
        /// </summary>
        public static void TrackAllChanges()
        {
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Remove some documents from documents path
            // Edit some documents in documents path
            // Add some new documents to documents path

            index.Update();
            // removed documents will be marked as deleted in index and will not be added to search results
            // Edited documents will be reindexed
            // Added documents will be added to index
        }

        /// <summary>
        /// Indexes separate files 
        /// </summary>
        public static void IndexSeparateFiles()
        {
            //ExStart:IndexSeparateFiles
            Index index = new Index(Utilities.indexPath);
            // adding just one file to index
            index.AddToIndex(Utilities.pathToPstFile);
            //ExEnd:IndexSeparateFiles
        }

        #region Merge Indexes functionality

        /// <summary>
        /// Merges index with delta indexes to improve search performance
        /// </summary>
        public static void MergingIndexWithDeltaIndexes()
        {
            //ExStart:MergingIndexWithDeltaIndexes
            string myDocumentsFolder1 = Utilities.documentsPath;
            string myDocumentsFolder2 = Utilities.documentsPath2;

            // Creating index
            Index index = new Index(Utilities.indexPath, true);

            // Adding documents to index
            index.AddToIndex(myDocumentsFolder1);

            // Adding one more folder to index. Delta index will be created.
            index.AddToIndex(myDocumentsFolder2);

            // Run merging
            index.Merge();
            //ExEnd:MergingIndexWithDeltaIndexes
        }

        /// <summary>
        /// Merges several indexes
        /// </summary>
        public static void MergingMultipleIndexes()
        {

            //ExStart:MergingMultipleIndexes
            // Creating/loading first index
            Index index1 = new Index(Utilities.indexPath);
            index1.AddToIndex(Utilities.documentsPath);

            // Creating/loading second index
            Index index2 = new Index(Utilities.indexPath2);
            index2.AddToIndex(Utilities.documentsPath);

            // Merging data from index2 to index1. The index2 remains unchanged.
            index1.Merge(index2);
            //ExEnd:MergingMultipleIndexes
        }

        /// <summary>
        /// Merges current index with index repository asyncronously
        /// </summary>
        public static void MergingCurrentIndexWithIndexRepository()
        {
            //ExStart:MergingCurrentIndexWithIndexRepository
            IndexRepository indexRepository = new IndexRepository();
            Index index1 = indexRepository.Create(Utilities.mergeIndexPath1);
            index1.AddToIndex(Utilities.documentsPath);

            Index index2 = indexRepository.Create(Utilities.mergeIndexPath2);
            index2.AddToIndex(Utilities.documentsPath2);

            Index mainIndex = new Index(Utilities.mainMergedIndexesPath);
            mainIndex.AddToIndex(Utilities.documentsPath3);

            // Merge data from indexes in repository to main index. After merge index repository stays unmodified.
            mainIndex.Merge(indexRepository);
            //ExEnd:MergingCurrentIndexWithIndexRepository
        }

        /// <summary>
        /// Merges Index with delta indexes Asynchronously to improve search performance
        /// </summary>
        public static void MergingIndexWithDeltaIndexesAsync()
        {
            //ExStart:MergingIndexWithDeltaIndexesAsync
            string myDocumentsFolder1 = Utilities.documentsPath;
            string myDocumentsFolder2 = Utilities.documentsPath2;

            // Creating index
            Index index = new Index(Utilities.indexPath, true);

            // Adding documents to index
            index.AddToIndex(myDocumentsFolder1);

            // Adding one more folder to index. Delta index will be created.
            index.AddToIndex(myDocumentsFolder2);

            // Run merging asynchonously
            index.MergeAsync();
            //ExEnd:MergingIndexWithDeltaIndexesAsync
        }

        /// <summary>
        /// Merges several indexes asynchronously
        /// </summary>
        public static void MergingMultipleIndexesAsync()
        {

            //ExStart:MergingMultipleIndexesAsync
            // Creating/loading first index
            Index index1 = new Index(Utilities.mergeIndexPath1);
            index1.AddToIndex(Utilities.documentsPath);

            // Creating/loading second index
            Index index2 = new Index(Utilities.mergeIndexPath2);
            index2.AddToIndex(Utilities.documentsPath2);

            // Merging data from index2 to index1. The index2 remains unchanged.
            index1.MergeAsync(index2);
            //ExEnd:MergingMultipleIndexesAsync
        }

        /// <summary>
        /// Merges current index with index repository asyncronously
        /// </summary>
        public static void MergingCurrentIndexWithIndexRepositoryAsync()
        {
            //ExStart:MergingCurrentIndexWithIndexRepositoryAsync
            IndexRepository indexRepository = new IndexRepository();
            //Add first index to index repository
            Index index1 = indexRepository.Create(Utilities.mergeIndexPath1);
            index1.AddToIndex(Utilities.documentsPath);

            //Add second index to index repository
            Index index2 = indexRepository.Create(Utilities.mergeIndexPath2);
            index2.AddToIndex(Utilities.documentsPath2);

            //Create/load main index
            Index mainIndex = new Index(Utilities.mainMergedIndexesPath);
            mainIndex.AddToIndex(Utilities.documentsPath3);

            // Merge data from indexes in repository to main index. After merge index repository stays unmodified.
            mainIndex.MergeAsync(indexRepository);
            //ExEnd:MergingCurrentIndexWithIndexRepositoryAsync
        }
        #endregion

        /// <summary>
        /// adds documents to old version of the index
        /// </summary>
        public static void AddDocsToOldIndexVersion() {
            //ExStart:AddDocsToOldIndexVersion
            // This index should be exist and should have one of previous version
            string oldIndexFolder = Utilities.oldIndexFolderPath;
            string documentsFolder = Utilities.documentsPath3;

            // Load index
            Index index = new Index(oldIndexFolder);
            // Add documents to index. Index will be updated to actual version before adding new documents.
            index.AddToIndex(documentsFolder, true);
            //ExEnd:AddDocsToOldIndexVersion
        }

        
    }
}
