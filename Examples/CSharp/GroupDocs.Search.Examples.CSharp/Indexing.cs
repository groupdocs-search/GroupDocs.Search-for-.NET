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
        /// Update index
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
        /// Update index repository
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
        /// Update index asynchronously
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
        /// Update index in repository asynchronously
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
        /// Create index in memory
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
        /// Create index on disk
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
        /// Create index in memory with index settings
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
        /// Create with overwriting existed index
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
        /// Load index
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
        /// Add document to index
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
        /// Add document to index asynchronously
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
    }
}
