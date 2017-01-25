
Public Class Indexing
    ''' <summary>
    ''' Update index
    ''' </summary>
    Public Shared Sub UpdateIndex()
        'ExStart:UpdateIndex
        ' Load index
        Dim index As New Index(Utilities.indexPath)
        index.Update()
        'ExEnd:UpdateIndex
    End Sub

    ''' <summary>
    ''' Update index repository
    ''' </summary>
    Public Shared Sub UpdateIndexInRepository()
        'ExStart:UpdateIndexInRepository
        Dim repository As New IndexRepository()
        repository.AddToRepository(Utilities.indexPath)
        repository.AddToRepository(Utilities.indexPath2)
        ' Update all indexes in repository
        repository.Update()
        'ExEnd:UpdateIndexInRepository
    End Sub

    ''' <summary>
    ''' Update index asynchronously
    ''' </summary>
    Public Shared Sub UpdateIndexAsynchronously()
        'ExStart:UpdateIndexAsynchronously
        'Load index
        Dim index As New Index(Utilities.indexPath)
        AddHandler index.OperationFinished, Utilities.index_OperationFinished
        ' Update index asynchronously
        index.UpdateAsync()
        'ExEnd:UpdateIndexAsynchronously
    End Sub

    ''' <summary>
    ''' Update index in repository asynchronously
    ''' </summary>
    Public Shared Sub UpdateIndexInRepoAsynchronously()
        'ExStart:UpdateIndexInRepoAsynchronously
        Dim repository As New IndexRepository()
        repository.AddToRepository(Utilities.indexPath)
        repository.AddToRepository(Utilities.indexPath2)

        ' Update all indexes in repository asynchronously
        repository.UpdateAsync()
        'ExEnd:UpdateIndexInRepoAsynchronously
    End Sub

    ''' <summary>
    ''' Create index in memory
    ''' </summary>
    Public Shared Sub CreateIndexInMemory()
        'ExStart:CreateIndexInMemory
        ' Create index in memory
        Dim index1 As New Index()
        ' Create index in memory using Index Repository
        Dim repository As New IndexRepository()
        Dim index2 As Index = repository.Create()
        'ExEnd:CreateIndexInMemory
    End Sub

    ''' <summary>
    ''' Create index on disk
    ''' </summary>
    Public Shared Sub CreateIndexOnDisk()
        'ExStart:CreateIndexOnDisk
        ' Create index on disk
        Dim index1 As New Index(Utilities.indexPath)
        ' Create index on disk using Index Repository
        Dim repository As New IndexRepository()
        Dim index2 As Index = repository.Create(Utilities.indexPath2)
        'ExEnd:CreateIndexOnDisk
    End Sub

    ''' <summary>
    ''' Create index in memory with index settings
    ''' </summary>
    Public Shared Sub CreateIndexInMemoryWithIndexSettings()
        'ExStart:CreateIndexInMemoryWithIndexSettings
        Dim quickIndexing As Boolean = True
        Dim settings As New IndexingSettings(quickIndexing)

        ' Create index on disk
        Dim index1 As New Index(settings)

        ' Create index on disk using Index Repository
        Dim repository As New IndexRepository()
        Dim index2 As Index = repository.Create(settings)
        'ExEnd:CreateIndexInMemoryWithIndexSettings
    End Sub

    ''' <summary>
    ''' Create with overwriting existed index
    ''' </summary>
    Public Shared Sub CreateWithOverwritingExistedIndex()
        'ExStart:CreateWithOverwritingExistedIndex
        ' Create index on disk. If Index folder is not empty it will be rewited
        Dim index1 As New Index(Utilities.indexPath, True)

        ' Create index on disk using Index Repository
        Dim repository As New IndexRepository()
        Dim index2 As Index = repository.Create(Utilities.indexPath)
        'ExEnd:CreateWithOverwritingExistedIndex
    End Sub

    ''' <summary>
    ''' Load index
    ''' </summary>
    Public Shared Sub LoadIndex()
        'ExStart:loadindex
        ' Load index
        Dim index As New Index(Utilities.indexPath)

        ' Load indexes to index repository
        Dim repository As New IndexRepository()
        repository.AddToRepository(index)
        'repository.AddToRepository(Utilities.indexPath2);
        'ExEnd:loadindex
    End Sub

    ''' <summary>
    ''' Add document to index
    ''' </summary>
    Public Shared Sub AddDocumentToIndex()
        'ExStart:AddDocumentToIndex
        ' Create index
        Dim index As New Index(Utilities.indexPath)
        ' all files from folder and its subfolders will be added to the index
        index.AddToIndex(Utilities.documentsPath)
        'ExEnd:AddDocumentToIndex
    End Sub

    ''' <summary>
    ''' Add document to index asynchronously
    ''' </summary>
    Public Shared Sub AddDocumentToIndexAsynchronously()
        'ExStart:AddDocumentToIndexAsynchronously
        ' Create index
        Dim index As New Index(Utilities.indexPath)
        AddHandler index.OperationFinished, Utilities.index_OperationFinished
        ' all files from folder and its subfolders will be added to the index
        index.AddToIndexAsync(Utilities.documentsPath)
        'ExEnd:AddDocumentToIndexAsynchronously
    End Sub

    ''' <summary>
    ''' Adds document to index with progress percentage event
    ''' </summary>
    Public Shared Sub GetIndexingProgressPercentage()
        'ExStart:GetIndexingProgressPercentage
        ' Create index
        Dim index As New Index(Utilities.indexPath, True)

        AddHandler index.OperationProgressChanged, AddressOf index_OperationProgressChanged
        ' event subscribing
        ' all files from folder and its subfolders will be added to the index
        index.AddToIndex(Utilities.documentsPath)
        'ExEnd:GetIndexingProgressPercentage
    End Sub

    Private Shared Sub index_OperationProgressChanged(sender As Object, e As GroupDocs.Search.Events.OperationProgressArg)
        Console.WriteLine("Current progress: {0}" & vbLf & "{1}", e.ProgressPercentage, e.Message)
        ' event argument contains information about the current progress of operation
    End Sub

    ''' <summary>
    ''' Subscription to events
    ''' </summary>
    Public Shared Sub SubscriptionToEvents()
        'ExStart:SubscriptionToEvents
        ' Create index in memory
        Dim index As New Index()
        AddHandler index.OperationFinished, Utilities.index_OperationFinished
        index.AddToIndexAsync(Utilities.documentsPath)
        index.UpdateAsync()
        'ExEnd:SubscriptionToEvents
    End Sub

    ''' <summary>
    ''' Custom extractor test
    ''' </summary>
    Public Shared Sub CustomExtractor()
        'ExStart:CustomExtractor
        Dim index As New Index(Utilities.indexPath)
        index.CustomExtractors.Add(New CustomFieldExtractor())

        index.AddToIndex(Utilities.documentsPath)
        'ExEnd:CustomExtractor
    End Sub


    ''' <summary>
    ''' Add PowerPoint Document to index
    ''' </summary>
    Public Shared Sub AddPowerPointDocumentToIndex()
        'ExStart:AddPowerPointDocumentToIndex
        ' Create index
        Dim index As New Index(Utilities.indexPath)
        ' all files from folder and its subfolders will be added to the index
        index.AddToIndex(Utilities.documentsPath)

        Dim results1 As SearchResults = index.Search("author:cisco")
        ' searching by author of presentation
        Dim results2 As SearchResults = index.Search("LastSavedBy:teresa")
        ' searching by person who saved presentation last time
        'ExEnd:AddPowerPointDocumentToIndex
    End Sub

    ''' <summary>
    ''' Prevents Unnecessary File Indexing
    ''' </summary>
    Public Shared Sub PreventUnnecessaryFileIndex()
        'ExStart: PreventUnnecessaryFileIndex
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Try add the same documents to index
        index.AddToIndex(Utilities.documentsPath)
        ' Already indexed files will not be reindexed.
        'ExEnd: PreventUnnecessaryFileIndex
    End Sub
    ''' <summary>
    ''' Tracks all the changes in the index folder
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub TrackAllChanges()
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Remove some documents from documents path
        ' Edit some documents in documents path
        ' Add some new documents to documents path

        index.Update()
        ' removed documents will be marked as deleted in index and will not be added to search results
        ' Edited documents will be reindexed
        ' Added documents will be added to index
    End Sub

    ''' <summary>
    ''' Indexes separate files 
    ''' </summary>
    Public Shared Sub IndexSeparateFiles()
        'ExStart:IndexSeparateFiles
        Dim index As New Index(Utilities.indexPath)
        'adding just one file to index
        index.AddToIndex(Utilities.pathToPstFile)
        'ExEnd:IndexSeparateFiles
    End Sub


#Region "Merge Indexes functionality"

    ''' <summary>
    ''' Merges index with delta indexes to improve search performance
    ''' </summary>
    Public Shared Sub MergingIndexWithDeltaIndexes()
        'ExStart:MergingIndexWithDeltaIndexes
        Dim myDocumentsFolder1 As String = Utilities.documentsPath
        Dim myDocumentsFolder2 As String = Utilities.documentsPath2

        ' Creating index
        Dim index As New Index(Utilities.indexPath, True)

        ' Adding documents to index
        index.AddToIndex(myDocumentsFolder1)

        ' Adding one more folder to index. Delta index will be created.
        index.AddToIndex(myDocumentsFolder2)

        ' Run merging
        index.Merge()
        'ExEnd:MergingIndexWithDeltaIndexes
    End Sub

    ''' <summary>
    ''' Merges several indexes
    ''' </summary>
    Public Shared Sub MergingMultipleIndexes()

        'ExStart:MergingMultipleIndexes
        ' Creating/loading first index
        Dim index1 As New Index(Utilities.indexPath)
        index1.AddToIndex(Utilities.documentsPath)

        ' Creating/loading second index
        Dim index2 As New Index(Utilities.indexPath2)
        index2.AddToIndex(Utilities.documentsPath)

        ' Merging data from index2 to index1. The index2 remains unchanged.
        index1.Merge(index2)
        'ExEnd:MergingMultipleIndexes
    End Sub

    ''' <summary>
    ''' Merges current index with index repository asyncronously
    ''' </summary>
    Public Shared Sub MergingCurrentIndexWithIndexRepository()
        'ExStart:MergingCurrentIndexWithIndexRepository
        Dim indexRepository As New IndexRepository()
        Dim index1 As Index = indexRepository.Create(Utilities.mergeIndexPath1)
        index1.AddToIndex(Utilities.documentsPath)

        Dim index2 As Index = indexRepository.Create(Utilities.mergeIndexPath2)
        index2.AddToIndex(Utilities.documentsPath2)

        Dim mainIndex As New Index(Utilities.mainMergedIndexesPath)
        mainIndex.AddToIndex(Utilities.documentsPath3)

        ' Merge data from indexes in repository to main index. After merge index repository stays unmodified.
        mainIndex.Merge(indexRepository)
        'ExEnd:MergingCurrentIndexWithIndexRepository
    End Sub

    ''' <summary>
    ''' Merges Index with delta indexes Asynchronously to improve search performance
    ''' </summary>
    Public Shared Sub MergingIndexWithDeltaIndexesAsync()
        'ExStart:MergingIndexWithDeltaIndexesAsync
        Dim myDocumentsFolder1 As String = Utilities.documentsPath
        Dim myDocumentsFolder2 As String = Utilities.documentsPath2

        ' Creating index
        Dim index As New Index(Utilities.indexPath, True)

        ' Adding documents to index
        index.AddToIndex(myDocumentsFolder1)

        ' Adding one more folder to index. Delta index will be created.
        index.AddToIndex(myDocumentsFolder2)

        ' Run merging asynchonously
        index.MergeAsync()
        'ExEnd:MergingIndexWithDeltaIndexesAsync
    End Sub

    ''' <summary>
    ''' Merges several indexes asynchronously
    ''' </summary>
    Public Shared Sub MergingMultipleIndexesAsync()

        'ExStart:MergingMultipleIndexesAsync
        ' Creating/loading first index
        Dim index1 As New Index(Utilities.mergeIndexPath1)
        index1.AddToIndex(Utilities.documentsPath)

        ' Creating/loading second index
        Dim index2 As New Index(Utilities.mergeIndexPath2)
        index2.AddToIndex(Utilities.documentsPath2)

        ' Merging data from index2 to index1. The index2 remains unchanged.
        index1.MergeAsync(index2)
        'ExEnd:MergingMultipleIndexesAsync
    End Sub

    ''' <summary>
    ''' Merges current index with index repository asyncronously
    ''' </summary>
    Public Shared Sub MergingCurrentIndexWithIndexRepositoryAsync()
        'ExStart:MergingCurrentIndexWithIndexRepositoryAsync
        Dim indexRepository As New IndexRepository()
        'Add first index to index repository
        Dim index1 As Index = indexRepository.Create(Utilities.mergeIndexPath1)
        index1.AddToIndex(Utilities.documentsPath)

        'Add secon index to index repository
        Dim index2 As Index = indexRepository.Create(Utilities.mergeIndexPath2)
        index2.AddToIndex(Utilities.documentsPath2)

        'Create/load main index
        Dim mainIndex As New Index(Utilities.mainMergedIndexesPath)
        mainIndex.AddToIndex(Utilities.documentsPath3)

        ' Merge data from indexes in repository to main index. After merge index repository stays unmodified.
        mainIndex.MergeAsync(indexRepository)
        'ExEnd:MergingCurrentIndexWithIndexRepositoryAsync
    End Sub
#End Region



End Class