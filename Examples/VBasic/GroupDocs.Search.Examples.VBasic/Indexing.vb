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
        AddHandler repository.OperationFinished, Utilities.index_OperationFinished

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
        'repository.AddToRepository(Utilities.indexPath2)
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

End Class
