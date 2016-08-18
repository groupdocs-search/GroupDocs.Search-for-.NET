
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


End Class