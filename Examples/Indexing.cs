using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Search;
using GroupDocs.Search.Events;
using System.Globalization;
using System.Threading;

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

            //From version 17.9.0 quickIndexing has been marked obsolter and removed from the API
            //These 2 lines of code are no more valid from version 17.9.0 onward
            //bool quickIndexing = true;
            //IndexingSettings settings = new IndexingSettings(quickIndexing);


            IndexingSettings settings = new IndexingSettings();

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

        static void index_OperationProgressChanged(object sender, GroupDocs.Search.Events.OperationProgressEventArgs e)
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
		/// Break indexing with cancellation object 
		/// This method is supported by version 18.7 or greater
		/// </summary>
		public static void BreakIndexingWithCancellationObject()
		{
			// Creating cancellation object
			Cancellation cancellation = new Cancellation();

			// Creating index
			Index index = new Index(Utilities.indexPath);

			// Indexing
			index.AddToIndexAsync(Utilities.documentsPath, cancellation);

			// Cancelling after 1 second of indexing
			Thread.Sleep(1000);
			cancellation.Cancel();
		}

		public static void ExtracDocumentTextToFileFromIndex()
		{
			// Creating index from existing folder
			Index index = new Index(Utilities.indexPath);

			// Getting list of indexed documents
			DocumentInfo[] documents = index.GetIndexedDocuments();

			// Extracting HTML formatted document text to a file
			index.ExtractDocumentText(Utilities.documentTextPath, documents[0], null);
		}

		/// <summary>
		/// Extract Document Text from Index
		/// This method is supported by version 18.9 or greater
		/// </summary>
		public static void ExtracDocumentTextFromIndex()
		{
			// Creating index from existing folder
			Index index = new Index(Utilities.indexPath);

			// Getting list of indexed documents
			DocumentInfo[] documents = index.GetIndexedDocuments();

			// Extracting HTML formatted document text
			string htmlText = index.ExtractDocumentText(documents[0], null);
		}

		/// <summary>
		/// Get a list of indexed documents from an index
		/// This method is supported by version 18.9 or greater
		/// </summary>
		public static void GetListOfIndexedDocuments()
		{
			// Creating index from existing folder
			Index index = new Index(Utilities.indexPath);

			// Getting list of indexed documents
			DocumentInfo[] documents = index.GetIndexedDocuments();

			// Getting items of container document
			DocumentInfo[] items = index.GetIndexedDocumentItems(documents[0]);
		}

		/// <summary>
		/// Break Index Repository using Cancellation Object
		/// This method is supported by version 18.8 or greater
		/// </summary>
		public static void BreakIndexRepositoryUsingCancellationObject()
		{
			string documentsFolder = Utilities.documentsPath;
			IndexRepository repository = new IndexRepository();
			Index index = repository.Create();
			index.AddToIndex(documentsFolder);

			Cancellation cnc = new Cancellation();

			// Updating all indexes in repository
			repository.UpdateAsync(cnc);

			// Canceling all operations in index repository
			cnc.Cancel();
		}

		/// <summary>
		/// Break Index Repository
		/// This method is supported by version 18.8 or greater
		/// </summary>
		public static void BreakIndexRepository()
		{
			string indexFolder = Utilities.indexPath;
			string documentsFolder = Utilities.documentsPath;

			IndexRepository repository = new IndexRepository();
			Index index = repository.Create(indexFolder);
			index.AddToIndexAsync(documentsFolder);

			// Breaking all processes in all indexes in repository
			repository.Break();
		}

		/// <summary>
		/// Break Merging Operation manually
		/// This method is supported by version 18.7 or greater
		/// </summary>
		public static void BreakMergingManually()
		{
			// Creating cancellation object 
			Cancellation cancellation = new Cancellation();
			// cancelation after 5 seconds
			cancellation.CancelAfter(5000);

			// Load index
			Index index = new Index(Utilities.indexPath);
			index.Merge(cancellation);

		}

		/// <summary>
		/// Break Updating Operation using cancellation object
		/// This method is supported by version 18.7 or greater
		/// </summary>
		public static void BreakUpdatingUsingCancellationObject()
		{
			
			// Creating cancellation object
			Cancellation cancellation = new Cancellation();

			// Load index
			Index index = new Index(Utilities.indexPath);

			// Updating
			index.UpdateAsync(cancellation);


			// Cancelling
			cancellation.Cancel();
		}

		/// <summary>
		/// Break Updating Operation Manually
		/// This method is supported by version 18.7 or greater
		/// </summary>
		public static void BreakUpdatingManually()
		{
			// Load index
			Index index = new Index(Utilities.indexPath);

			// Updating index
			index.UpdateAsync();

			// Breaking updating
			index.Break();

		}

		internal static void IndexMetaData()
        {
            //ExStart: IndexMetaData
            // Creating indexing settings object
            IndexingSettings settings = new IndexingSettings();
            settings.IndexType = IndexType.MetadataIndex;

            // Creating index
            Index index = new Index(Utilities.indexPath, settings);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd: IndexMetaData
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
        /// Tracks all the changes in the index folder
        /// This method is support by version 18.6 or greater
        /// </summary>
        public static void BreakIndexingManually()
        {
            try
            {
                // Creating index 
                Index index = new Index(Utilities.indexPath);
                // Subscribing on Operation Finished event  
                index.OperationFinished += Utilities.index_OperationFinished;
                // Indexing selected folder asynchronously 
                index.AddToIndexAsync(Utilities.documentsPath); 
                //
                index.Break();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void MultiThreadedIndexingAsync()
        {
            try
            {
                // Creating index
                Index index = new Index(Utilities.indexPath);

                // Indexing in 2 threads
                index.AddToIndexAsync(Utilities.documentsPath, 2);

                // User can perform a search after the completion of the indexing operation

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void MultiThreadedIndexing()
        {
            try
            {
                // Creating index
                Index index = new Index(Utilities.indexPath);

                // Indexing in 2 threads
                index.AddToIndex(Utilities.documentsPath, 2);

                // Searching
                SearchResults result = index.Search("Einstein");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }

        public static void CompactIndexing()
        {
            try
            {
                // Creating indexing settings object
                IndexingSettings indexingSettings = new IndexingSettings();
                // Setting compact index type
                indexingSettings.IndexType = IndexType.CompactIndex;

                // Creating index
                Index index = new Index(Utilities.indexPath, indexingSettings);

                // Indexing
                index.AddToIndex(Utilities.documentsPath);

                // Searching
                SearchResults result = index.Search("Einstein");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
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
        public static void AddDocsToOldIndexVersion()
        {
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

        /// <summary>
        /// shows how to get indexing report
        /// Feature is supported in version 17.7 or greater
        /// </summary>
        public static void GetIndexReport()
        {
            //ExStart:GetIndexReport
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            // Get indexing report
            IndexingReport[] report = index.GetIndexingReport();

            foreach (IndexingReport record in report)
            {
                Console.WriteLine("Indexing takes {0}, index size: {1}.", record.IndexingTime, record.TotalIndexSize);
            }

            //ExEnd:GetIndexReport
        }

        /// <summary>
        /// Shows how to perform accent insensitive indexing
        /// Feature is supported in version 17.8.0 of the API
        /// </summary>
        public static void AccentInsensitiveIndexing()
        {
            //ExStart:AccentInsensitiveIndexing
            // Enabling replacements during indexing
            var settings = new IndexingSettings();
            settings.UseCharacterReplacements = true;

            // Creating index
            Index index = new Index(Utilities.indexPath, settings);

            // Clearing dictionary of replacements
            index.Dictionaries.CharacterReplacements.Clear();

            // Adding replacements
            KeyValuePair<char, char>[] replacements = new KeyValuePair<char, char>[]
            {
                new KeyValuePair<char, char>('Ṝ', 'R'),
                new KeyValuePair<char, char>('ṝ', 'r'),
            };
            index.Dictionaries.CharacterReplacements.AddRange(replacements);

            // Import replacements from file. Existing replacements are staying.
            index.Dictionaries.CharacterReplacements.Import(Utilities.replacementsFileName);
            // Export replacements to file
            index.Dictionaries.CharacterReplacements.Export(Utilities.exportedReplacementsFileName);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:AccentInsensitiveIndexing
        }

        /// <summary>
        /// Shows how to limit index report
        /// Feature is supported in version 17.8.0 of the API
        /// </summary>
        public static void LimitIndexReport()
        {
            //ExStart:LimitIndexReport
            Index index = new Index(Utilities.indexPath);

            // Setting the maximum count of indexing reports
            index.IndexingSettings.MaxIndexingReportCount = 2;

            index.AddToIndex(Utilities.documentsPath);
            index.AddToIndex(Utilities.documentsPath2);
            index.AddToIndex(Utilities.documentsPath3);

            // Getting indexing report. Array contains only 2 last records about indexing.
            IndexingReport[] report = index.GetIndexingReport();

            // Three indexing operations were performed, but only 2 last operations will be printed on the console in this example
            foreach (IndexingReport record in report)
            {
                Console.WriteLine("Indexing takes {0}, index size: {1}.", record.IndexingTime, record.TotalIndexSize);
            }
            //ExEnd:LimitIndexReport
        }

        /// <summary>
        /// Shows how to skip indexing by file name
        /// Feature is supported in version 17.8.0 of the API
        /// </summary>
        public static void SkipIndexingByFileName()
        {
            //ExStart:SkipIndexingByFileName
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);

            // Subscrubing to event FileIndexing where we skip all files which contain 'Started' in file name
            index.FileIndexing += (sender, arg) =>
            {
                if (arg.DocumentFullName.Contains("Started"))
                {
                    arg.SkipIndexing = true;
                }
            };

            index.AddToIndex(documentsFolder);
            //ExEnd:SkipIndexingByFileName
        }

        /// <summary>
        /// Shows how to set encoding for some files
        /// Feature is supported in version 17.8.0
        /// </summary>
        public static void SetFileEncoding()
        {
            //ExStart:SetFileEncoding
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);

            // Subscrubing to event FileIndexing where we set encoding for some files
            index.FileIndexing += (sender, arg) =>
            {
                if (arg.DocumentFullName.Contains("not_english"))
                {
                    // Use GroupDocs.Search.Encodings constants to select encoding
                    arg.Encoding = GroupDocs.Search.Encodings.windows_1251;
                }
            };

            index.AddToIndex(documentsFolder);
            //ExEnd:SetFileEncoding
        }

        /// <summary>
        /// Shows how to use status changed event
        /// Feature is supported in version 17.8.0
        /// </summary>
        public static void StatusChangedEventUsage()
        {
            //ExStart:StatusChangedEventUsage
            string indexFolder = Utilities.indexPath;

            // Creating index
            Index index = new Index(indexFolder);

            IndexStatus status;
            // Subscribing to StatusChanged event
            index.StatusChanged += (sender, args) =>
            {
                status = args.Status;
            };
            //ExEnd:StatusChangedEventUsage
        }

        /// <summary>
        /// Shows how to cache text of Indexed Documents in index
        /// Feature is supported in version 17.9.0 or greater of the API
        /// </summary>
        public static void CacheTextOfIndexedDocsInIndex()
        {
            //ExStart:CacheTextOfIndexedDocsInIndex
            // Creating indexing settings object
            IndexingSettings settings = new IndexingSettings();
            // Enabling source document text caching with normal compression level
            // From version 17.10 onwards, value "High" has been added to GroupDocs.Search.Compression enumeration.
            // So in order to cache document's text with high compression level use "Compression.High"
            settings.TextStorageSettings = new TextStorageSettings(Compression.Normal);

            // Creating index
            Index index = new Index(Utilities.indexPath, settings);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:CacheTextOfIndexedDocsInIndex
        }

        /// <summary>
        /// Shows how to filter files during indexing
        /// Feature is supported in version 17.9.0 or greater of the API
        /// </summary>
        public static void FilterFilesDuringIndexing()
        {
            //ExStart:FilterFilesDuringIndexing
            // Creating indexing settings object
            IndexingSettings settings = new IndexingSettings();

            // Creating filter that only passes files from 600 KB to 1 MB in length
            DocumentFilter byLength = DocumentFilter.CreateFileLengthRange(614400, 1048576);

            // Creating filter that only passes text files
            DocumentFilter byExtension = DocumentFilter.CreateFileExtension(".txt");

            // Creating composite filter that only passes text files from 600 KB to 1 MB in length
            DocumentFilter compositeFilter = DocumentFilter.CreateConjunction(byLength, byExtension);

            // Setting filter
            settings.DocumentFilter = compositeFilter;

            // Creating index
            Index index = new Index(Utilities.indexPath, settings);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:FilterFilesDuringIndexing
        }

        /// <summary>
        /// Shows how to sutomatically detect encoding in text files
        /// Feature is supported in version 17.9.0 or greater
        /// </summary>
        public static void AutomaticDetectEncoding()
        {
            //ExStart:AutomaticDetectEncoding
            // Creating indexing settings object
            IndexingSettings settings = new IndexingSettings();
            // Enabling automatic encoding detection
            settings.AutoDetectEncoding = true;

            // Creating index
            Index index = new Index(Utilities.indexPath, settings);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:AutomaticDetectEncoding
        }

        /// <summary>
        /// Shows how to detect encoding selectively for some text files
        /// Feature is supported in version 17.9.0 or greater
        /// </summary>
        public static void DetectEncodingSelectively()
        {
            //ExStart:DetectEncodingSelectively
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Creating default encoding that is used when encoding was not detected
            Encoding defaultEncoding = Encoding.GetEncoding(Encodings.Windows_1252);

            // Subscribing to FileIndexing event
            index.FileIndexing += (sender, args) =>
            {
                // Detecting encoding only for text files located in the 'documentsPath3' folder
                string fileName = args.DocumentFullName;
                if (fileName.EndsWith(".txt", true, CultureInfo.InvariantCulture) &&
                    fileName.StartsWith(Utilities.documentsPath3))
                {
                    args.DetectEncoding(defaultEncoding, true);
                }
            };

            // Indexing
            index.AddToIndex(Utilities.documentsPath);
            //ExEnd:DetectEncodingSelectively
        }


        /// <summary>
        /// The API implements safe updating of index files to increase reliability
        /// Below example shows how to check if index should be reloaded
        /// Feature is supported in version 17.10 or greater
        /// </summary>
        public static void CheckNeedForIndexReload()
        {
            //ExStart:CheckNeedForIndexReload
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);

            // Checking the need to reload
            if (index.IndexStatus == IndexStatus.Failed)
            {
                // Reloading index
                index = new Index(Utilities.indexPath);
            }
            //ExEnd:CheckNeedForIndexReload
        }

        /// <summary>
        /// Shows how to check skipped document count and 
        /// how to get just processed document's name and processing result
        /// Feature is supported in version 17.10 or greater
        /// </summary>
        public static void CallProgressChangedEvent()
        {
            //ExStart:CallProgressChangedEvent
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;
            Index index = new Index(indexFolder);

            index.OperationProgressChanged += (sender, args) =>
            {
                Console.WriteLine(
                   "Document {0}\t{1}\nprocessed {2} of {3} (skipped: {4}\tsuccessfuly processed: {5}\nProgress: {6:F2}%\n",
                   args.LastDocumentStatus,
                   args.LastDocumentPath,
                   args.SkippedDocumentsCount + args.ProcessedDocumentsCount,
                   args.TotalDocumentsCount,
                   args.SkippedDocumentsCount,
                   args.ProcessedDocumentsCount,
                   args.ProgressPercentage);
            };
            index.AddToIndex(documentsFolder);
            //ExEnd:CallProgressChangedEvent
        }

        /// <summary>
        /// Shows how to set custom text extractor for some files
        /// Feature is supported in version 17.8.0 of the API
        /// </summary>
        public static void SetCustomTextExtractor()
        {
            //ExStart:SetCustomTextExtractor
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);

            // Subscrubing to event FileIndexing where we set custom text extractor for some files
            index.FileIndexing += (sender, arg) =>
            {
                if (arg.DocumentFullName.Contains(".txt"))
                {
                    arg.CustomExtractor = new CustomTextExtractor();
                }
            };

            index.AddToIndex(documentsFolder);
            //ExEnd:SetCustomTextExtractor
        }

        //ExStart:CustomExtractorClass
        class CustomTextExtractor : IFieldExtractor
        {
            public string[] Extensions { get { return new[] { ".txt" }; } }

            public GroupDocs.Search.FieldInfo[] GetFields(string fileName)
            {
                System.Collections.Generic.List<GroupDocs.Search.FieldInfo> fields =
                    new System.Collections.Generic.List<GroupDocs.Search.FieldInfo>();
                fields.Add(new Search.FieldInfo("content", "extracted text"));
                return fields.ToArray();
            }
        }
        //ExEnd:CustomExtractorClass
    }
}