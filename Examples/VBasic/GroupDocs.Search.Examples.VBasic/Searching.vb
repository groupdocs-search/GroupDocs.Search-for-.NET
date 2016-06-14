Public Class Searching

    ''' <summary>
    ''' Creates index, adds documents to index and search string in index
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub SimpleSearch(searchString As String)
        'ExStart:SimpleSearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Search in index
        Dim searchResults As SearchResults = index.Search(searchString)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.Write(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:SimpleSearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do boolean search
    ''' </summary>
    ''' <param name="firstTerm">first term to search</param>
    ''' <param name="secondTerm">second term to search</param>
    Public Shared Sub BooleanSearch(firstTerm As String, secondTerm As String)
        'ExStart:BooleanSearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Search in index
        Dim searchResults As SearchResults = index.Search(Convert.ToString(firstTerm & Convert.ToString("OR")) & secondTerm)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.Write(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:BooleanSearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do regex search
    ''' </summary>
    ''' <param name="relevantKey">single keyword</param>
    ''' <param name="regexString">regex</param>
    Public Shared Sub RegexSearch(relevantKey As String, regexString As String)
        'ExStart:Regexsearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Search for documents where at least one word contain given regex
        Dim searchResults1 As SearchResults = index.Search(relevantKey)

        'Search for documents where present term1 or any email adress or term2
        Dim searchResults2 As SearchResults = index.Search(regexString)

        ' List of found files 
        Console.WriteLine("Follwoing document(s) contain provided relevant tag: " & vbLf)
        For Each documentResultInfo As DocumentResultInfo In searchResults1
            Console.Write(documentResultInfo.FileName + vbLf)
        Next

        ' List of found files
        Console.WriteLine("Follwoing document(s) contain provided RegEx: " & vbLf)
        For Each documentResultInfo As DocumentResultInfo In searchResults2
            Console.Write(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:Regexsearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do fuzzy search
    ''' </summary>
    ''' <param name="searchString">Misspelled string</param>
    Public Shared Sub FuzzySearch(searchString As String)
        'ExStart:Fuzzysearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        parameters.UseFuzzySearch = True

        Dim searchResults As SearchResults = index.Search(searchString, parameters)

        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:Fuzzysearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do faceted search
    ''' </summary>
    ''' <param name="searchString">search string</param>
    Public Shared Sub FacetedSearch(searchString As String)
        'ExStart:Facetedsearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Searching for any document in index that contain word "return" in file content
        Dim searchResults As SearchResults = index.Search(Convert.ToString("Content:") & searchString)


        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.Write(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:Facetedsearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and searches file name that containes similar/inputted string 
    ''' </summary>
    ''' <param name="searchString">search string</param>
    Public Shared Sub SearchFileName(searchString As String)
        'ExStart:SearchFileName
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Searching for any document in index that contain search string in file name
        Dim searchResults As SearchResults = index.Search(Convert.ToString("FileName:") & searchString)


        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.Write(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:SearchFileName
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do faceted search combine with boolean search
    ''' </summary>
    ''' <param name="firstTerm">first term</param>
    ''' <param name="secondTerm">second term</param>
    Public Shared Sub FacetedSearchWithBooleanSearch(firstTerm As String, secondTerm As String)
        'ExStart:FacetedSearchWithBooleanSearch
        ' Create index
        Dim index As New Index(Utilities.indexPath)

        ' Add documents to index
        index.AddToIndex(Utilities.documentsPath)
        'Faceted search combine with boolean search
        Dim searchResults As SearchResults = index.Search(Convert.ToString((Convert.ToString("Content:") & firstTerm) + "OR Content:") & secondTerm)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.Write(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:FacetedSearchWithBooleanSearch
    End Sub

    ''' <summary>
    ''' Creates index, adds documents to index and do search on the basis of synonyms by turning synonym search true
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub SynonymSearch(searchString As String)
        'ExStart:SynonymSearch
        ' Create or load index
        Dim index As New Index(Utilities.indexPath)

        ' load synonyms
        index.LoadSynonyms(Utilities.synonymFilePath)

        index.AddToIndex(Utilities.documentsPath)

        ' Turning on synonym search feature
        Dim parameters As New SearchParameters()
        parameters.UseSynonymSearch = True

        ' searching for documents with words one of words "remote", "virtual" or "online"
        Dim searchResults As SearchResults = index.Search(searchString, parameters)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.Write(documentResultInfo.FileName + vbLf)
        Next
        'ExEnd:SynonymSearch
    End Sub

End Class
