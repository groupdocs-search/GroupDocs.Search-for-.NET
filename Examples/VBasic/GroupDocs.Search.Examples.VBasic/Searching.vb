Imports Aspose.Email.Outlook.Pst
Imports GroupDocs.Search.Events

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
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
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
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", firstTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", secondTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
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
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next

        ' List of found files
        Console.WriteLine("Follwoing document(s) contain provided RegEx: " & vbLf)
        For Each documentResultInfo As DocumentResultInfo In searchResults2
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:Regexsearch
    End Sub

    ''' <summary>
    ''' Creates index, 
    ''' Adds documents to index 
    ''' Enable fuzzy search
    ''' Set similarity level from 0.0 to 1.0
    ''' Do Fuzzy search
    ''' </summary>
    ''' <param name="searchString">Misspelled string</param>
    ''' 
    Public Shared Sub FuzzySearch(searchString As String)
        'ExStart:Fuzzysearch
        Dim index As New Index(Utilities.indexPath)
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        ' turning on Fuzzy search feature
        parameters.FuzzySearch.Enabled = True

        ' set low similarity level to search for less similar words and get more results
        parameters.FuzzySearch.SimilarityLevel = 0.1
        Dim lessSimilarResults As SearchResults = index.Search(searchString, parameters)
        Console.WriteLine("Results with less similarity level that is currently set to =" + parameters.FuzzySearch.SimilarityLevel)
        For Each lessSimilarResultsDoc As DocumentResultInfo In lessSimilarResults
            Console.WriteLine(lessSimilarResultsDoc.FileName + vbLf)
        Next

        ' set high similarity level to search for more similar words and get less results
        parameters.FuzzySearch.SimilarityLevel = 0.9
        Dim moreSimilarResults As SearchResults = index.Search(searchString, parameters)

        Console.WriteLine("Results with high similarity level that is currently set to =" + parameters.FuzzySearch.SimilarityLevel)
        For Each highSimilarityLevelDoc As DocumentResultInfo In moreSimilarResults
            Console.WriteLine(highSimilarityLevelDoc.FileName + vbLf)
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
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:Facetedsearch
    End Sub

    ''' <summary>
    ''' Gets list of the words in found documents that matched the search query
    ''' </summary>
    ''' <param name="searchString">Search string</param>
    ''' 
    Public Shared Sub GetMatchingWordsInFuzzySearchResult(searchString As String)
        'ExStart:GetMatchingWordsInFuzzySearchResult
        Dim index As New Index(Utilities.indexPath)
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        ' turning on Fuzzy search feature
        parameters.FuzzySearch.Enabled = True

        ' set low similarity level to search for less similar words and get more results
        parameters.FuzzySearch.SimilarityLevel = 0.2

        Dim fuzzySearchResults As SearchResults = index.Search(searchString, parameters)
        For Each documentResultInfo As DocumentResultInfo In fuzzySearchResults
            Console.WriteLine("Document {0} was found with query ""{1}""" & vbLf & "Words list that was found in document:", documentResultInfo.FileName, searchString)
            For Each term As String In documentResultInfo.Terms
                Console.Write("{0}; ", term)
            Next
            Console.WriteLine()
        Next
        'ExEnd:GetMatchingWordsInFuzzySearchResult
    End Sub

    ''' <summary>
    ''' Gets list of the words in found documents that matched the search query
    ''' </summary>
    ''' <param name="searchString">Search string</param>
    ''' 
    Public Shared Sub GetMatchingWordsInRegexSearchResult(searchString As String)
        'ExStart:GetMatchingWordsInRegexSearchResult
        Dim index As New Index(Utilities.indexPath)
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()

        Dim regexSearchResults As SearchResults = index.Search(searchString)

        For Each documentResultInfo As DocumentResultInfo In regexSearchResults
            Console.WriteLine("Document {0} was found with query ""{1}""" & vbLf & "Words list that was found in document:", documentResultInfo.FileName, regexSearchResults)
            For Each term As String In documentResultInfo.Terms
                Console.Write("{0}; ", term)
            Next
            Console.WriteLine()
        Next
        'ExEnd:GetMatchingWordsInRegexSearchResult
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
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
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
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", firstTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", secondTerm, documentResultInfo.HitCount, documentResultInfo.FileName)
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
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:SynonymSearch
    End Sub

    ''' <summary>
    ''' Searches documents wih exact phrase 
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub ExactPhraseSearch(searchString As String)
        'ExStart:ExactPhraseSearch
        ' Create or load index
        Dim index As New Index(Utilities.indexPath, True)

        index.AddToIndex(Utilities.documentsPath)

        Dim searchResults As SearchResults = index.Search(searchString)

        ' List of found files
        For Each documentResultInfo As DocumentResultInfo In searchResults
            Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName)
        Next
        'ExEnd:ExactPhraseSearch
    End Sub

    ''' <summary>
    ''' Performs a case sensitive search
    ''' </summary>
    ''' <param name="caseSensitiveSearchQuery">string to search</param>
    Public Shared Sub CaseSensitiveSearch(caseSensitiveSearchQuery As String)
        'ExStart:CaseSensitiveSearch
        Dim inMemoryIndex As Boolean = False
        Dim caseSensitive As Boolean = True
        Dim settings As New IndexingSettings(inMemoryIndex, caseSensitive)

        ' Create or load index
        Dim index As New Index(Utilities.indexPath, settings)

        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        parameters.UseCaseSensitiveSearch = True
        ' using case sensitive search feature
        Dim searchResults As SearchResults = index.Search(caseSensitiveSearchQuery, parameters)

        If searchResults.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In searchResults
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", caseSensitiveSearchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
        'ExEnd:CaseSensitiveSearch
    End Sub


    ''' <summary>
    ''' Performs search on numeric range
    ''' This feature is supported in version 17.03 or greater
    ''' </summary>
    ''' <param name="searchQuery"></param>
    Public Shared Sub NumericRangeSearch(searchQuery As String)
        'ExStart:NumericRangeSearch
        Dim indexFolder As String = Utilities.indexPath
        Dim documentsFolder As String = Utilities.documentsPath

        Dim index As New Index(indexFolder)
        index.AddToIndex(documentsFolder)

        ' Search for numbers
        Dim searchResults As SearchResults = index.Search(searchQuery)
        If searchResults.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In searchResults
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
        'ExEnd:NumericRangeSearch
    End Sub



    ''' <summary>
    ''' Shows how to implement own custom extractor for outlook document for the extension .ost and .pst files
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub OwnExtractorOst(searchString As String)
        'ExStart:OwnExtractorOst
        ' Create or load index
        Dim index As New Index(Utilities.indexPath)

        index.CustomExtractors.Add(New CustomOstPstExtractor())
        ' Adding new custom extractor for container document
        index.AddToIndex(Utilities.documentsPath)
        ' Documents with "ost" and "pst" extension will be indexed using MyCustomContainerExtractor
        Dim searchResults As SearchResults = index.Search(searchString)
        'ExEnd:OwnExtractorOst
    End Sub

    ''' <summary>
    ''' Shows how to implement own custom extractor for outlook document for the extension .ost and .pst files
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub DetailedResults(searchString As String)
        'ExStart:DetailedResultsPropertyInDocuments
        ' Create or load index
        Dim index As New Index(Utilities.indexPath)
        index.AddToIndex(Utilities.documentsPath)

        Dim results As SearchResults = index.Search(searchString)

        For Each resultInfo As DocumentResultInfo In results
            If resultInfo.DocumentType = DocumentType.OutlookEmailMessage Then
                ' for email message result info user should cast resultInfo as OutlookEmailMessageResultInfo for acessing EntryIdString property
                Dim emailResultInfo As OutlookEmailMessageResultInfo = TryCast(resultInfo, OutlookEmailMessageResultInfo)

                Console.WriteLine("Query ""{0}"" has {1} hit count in message {2} in file {3}", searchString, emailResultInfo.HitCount, emailResultInfo.EntryIdString, emailResultInfo.FileName)
            Else
                Console.WriteLine("Query ""{0}"" has {1} hit count in file {2}", searchString, resultInfo.HitCount, resultInfo.FileName)
            End If

            For Each detailedResult As DetailedResultInfo In resultInfo.DetailedResults
                Console.WriteLine("{0}In field ""{1}"" there was found {2} hit count", vbTab, detailedResult.FieldName, detailedResult.HitCount)
            Next
        Next
        'ExEnd:DetailedResultsPropertyInDocuments
    End Sub

    ''' <summary>
    ''' Gives warnings if try to run Search with options that are not supported in index
    ''' </summary>
    ''' <param name="searchString">string to search</param>
    Public Shared Sub NotSupportedOptionWarning(searchString As String)
        'ExStart:NotSupportedOptionWarning
        'create index
        Dim index As New Index(Utilities.indexPath)
        ' index.IndexingSettings.QuickIndexing = true;
        AddHandler index.ErrorHappened, AddressOf index_ErrorHappened
        ' QuickIndex ad = new QuickIndex();
        index.AddToIndex(Utilities.documentsPath)

        Dim fuzzySearchParameters As New SearchParameters()
        fuzzySearchParameters.FuzzySearch.Enabled = True

        ' Run fuzzy search
        Dim results As SearchResults = index.Search(searchString, fuzzySearchParameters)

        ' Run regex search
        Dim regexString As String = "dropbox ^[A-Z0-9._%+\-|A-Z0-9._%+-]+@++[A-Z0-9.\-|A-Z0-9.-]+\.[A-Z|A-Z]{2,}$ folder"
        Dim results1 As SearchResults = index.Search(regexString)

        Dim synonymSearchParameters As New SearchParameters()
        synonymSearchParameters.UseSynonymSearch = True

        ' Run synonym search without loaded synonyms
        Dim results2 As SearchResults = index.Search(searchString, synonymSearchParameters)

        'ExEnd:NotSupportedOptionWarning

    End Sub

    'ExStart:index_ErrorHappened
    ''' <summary>
    ''' Event Handler for search options not supported in index
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Shared Sub index_ErrorHappened(sender As Object, e As Search.Events.BaseIndexArg)
        ' e.Message contains corresponding message 
        'if search option is not supported
        'string notificationMessage = e.Message;
        Console.WriteLine(e.Message)
    End Sub
    'ExEnd:index_ErrorHappened
    ''' <summary>
    ''' Gets total hits count
    ''' </summary>
    ''' <param name="searchString">string to search</param> 
    Public Shared Sub GetTotalHitCount(searchString As String)

        'ExStart:GetTotalHitCount
        Dim index As New Index(Utilities.indexPath)
        index.AddToIndex(Utilities.documentsPath)

        Dim results As SearchResults = index.Search(searchString)
        Console.WriteLine("Searching with query ""{0}"" returns {1} documents with {2} total hit count", searchString, results.Count, results.TotalHitCount)
        'ExEnd:GetTotalHitCount
    End Sub

    Public Sub OpenFoundMessageUsingAsposeEmail(searchString As String)
        Dim myPstFile As String = Utilities.pathToPstFile


        ' Indexing MS Outlook storage with email messages
        Dim index As New Index(Utilities.indexPath)
        AddHandler index.OperationFinished, Utilities.index_OperationFinished
        index.AddToIndex(myPstFile)

        ' Searching in index
        Dim results As SearchResults = index.Search(searchString)

        ' User gets all messages that qualify to search query using Aspose.Email API
        Dim messages As New MessageInfoCollection()
        For Each searchResult As DocumentResultInfo In results
            If searchResult.DocumentType = DocumentType.OutlookEmailMessage Then
                Dim emailResultInfo As OutlookEmailMessageResultInfo = TryCast(searchResult, OutlookEmailMessageResultInfo)
                Dim message As MessageInfo = GetEmailMessagesById(Utilities.pathToPstFile, emailResultInfo.EntryIdString)
                If message IsNot Nothing Then
                    messages.Add(message)
                End If
            End If
        Next
    End Sub

    Private Function GetEmailMessagesById(fileName As String, fieldId As String) As MessageInfo
        Dim pst As PersonalStorage = PersonalStorage.FromFile(fileName, False)
        Return GetEmailMessagesById(pst.RootFolder, fieldId)
    End Function

    Private Function GetEmailMessagesById(folderInfo As FolderInfo, fieldId As String) As MessageInfo
        Dim result As MessageInfo = Nothing
        Dim messageInfoCollection As MessageInfoCollection = folderInfo.GetContents()
        For Each messageInfo As MessageInfo In messageInfoCollection
            If messageInfo.EntryIdString = fieldId Then
                result = messageInfo
                Exit For
            End If
        Next

        If result Is Nothing AndAlso folderInfo.HasSubFolders Then
            For Each subfolderInfo As FolderInfo In folderInfo.GetSubFolders()
                result = GetEmailMessagesById(subfolderInfo, fieldId)
                If result IsNot Nothing Then
                    Exit For
                End If
            Next
        End If
        Return result
    End Function


    ''' <summary>
    ''' Managing synonyms functionality
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub ManageSynonyms(searchQuery As String)
        'ExStart:ManageSynonyms
        'create or load index
        Dim index As New Index(Utilities.indexPath)
        index.AddToIndex(Utilities.documentsPath)

        ' Clearing synonym dictionary
        index.Dictionaries.SynonymDictionary.Clear()

        ' Adding synonyms
        Dim synonymGroup1 As String() = New String() {"big", "huge", "colossal", "massive"}
        Dim synonymGroup2 As String() = New String() {"fast", "agile", "quick", "rapid", "swift"}
        Dim synonymGroups As New List(Of String())()
        synonymGroups.Add(synonymGroup1)
        synonymGroups.Add(synonymGroup2)
        index.Dictionaries.SynonymDictionary.AddRange(synonymGroups)

        index.Dictionaries.SynonymDictionary.Import(Utilities.synonymFilePath)
        ' Import synonyms from file. Existing synonyms are staying.
        index.Dictionaries.SynonymDictionary.Export(Utilities.mySynonymFilePath)
        ' Export synonyms to file
        Dim parameters As New SearchParameters()
        parameters.UseSynonymSearch = True
        ' Turning on synonym search
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        ' Enable synonym search in parameters
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If

        'ExEnd:ManageSynonyms
    End Sub



    ''' <summary>
    ''' Manage Stop Word dictionary
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub ManageStopWords(searchQuery As String)
        'ExStart:ManageStopWords
        'create or load index
        Dim index As New Index(Utilities.indexPath)
        Dim stopWordsCount As Integer = index.Dictionaries.StopWordDictionary.Count
        '  Get count of stop words
        index.Dictionaries.StopWordDictionary.Clear()
        ' Clear dictionary of stop words
        index.Dictionaries.StopWordDictionary.AddRange(New List(Of String)() From {
            "one",
            "Two",
            "three"
        })
        ' Add several stop words to dictionary. Words are case insensitive.
        index.Dictionaries.StopWordDictionary.RemoveRange(New List(Of String)() From {
            "one",
            "three"
        })
        '  Remove stop words from dictionary. Words which are absent will be ignored.
        index.AddToIndex(Utilities.documentsPath)

        Dim isTwoPresent As Boolean = index.Dictionaries.StopWordDictionary.Contains("two")

        index.Dictionaries.StopWordDictionary.Import(Utilities.stopWordsFilePath)
        ' Import stop words from file. Existing stop words are staying.
        index.Dictionaries.StopWordDictionary.Export(Utilities.exportedStopWordsFilePath)
        ' Export stop words to file
        Dim results As SearchResults = index.Search(searchQuery)
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If

        'ExEnd:ManageStopWords
    End Sub



    ''' <summary>
    ''' Disable using Stop Words
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub DisableStopWords(searchQuery As String)
        'ExStart:DisableStopWords
        'create or load index
        Dim index As New Index(Utilities.indexPath)

        index.IndexingSettings.UseStopWords = False
        ' This line disables using stop words and all of the words in documents will be indexed
        index.AddToIndex(Utilities.documentsPath)
        Dim results As SearchResults = index.Search(searchQuery)
        'ExEnd:DisableStopWords
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If

    End Sub

#Region "Searching Password Protected Documents Functionality"


    ''' <summary>
    ''' Uses event to set password for protected document using event argument
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub SearchingPasswordProtectedDocsUsingEvent(searchQuery As String)
        'ExStart:SetPasswordUsingEventArg
        Dim index As New Index(Utilities.indexPath)
        AddHandler index.PasswordRequired, AddressOf index_PasswordRequired
        ' User can subscribe to PasswordRequired event to be able to specify a password
        index.AddToIndex(Utilities.documentsPath)
        Dim results As SearchResults = index.Search(searchQuery)
        'ExEnd:SetPasswordUsingEventArg
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub


    ''' <summary>
    ''' Sets password for protected document using Index.Dictionaries.DocumentPasswords property
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub SearchingPasswordProtectedDocsUsingProperty(searchQuery As String)
        'ExStart:SetPasswordUsingProperty
        Dim index As New Index(Utilities.indexPath)
        index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile, "test")
        index.AddToIndex(Utilities.documentsPath)
        Dim results As SearchResults = index.Search(searchQuery)
        'ExEnd:SetPasswordUsingProperty
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub



    ''' <summary>
    ''' Dealing with password protected documents, using both methods
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub SearchingPasswordProtectedDocs(searchQuery As String)
        'ExStart:SetPassword
        Dim index As New Index(Utilities.indexPath)
        AddHandler index.PasswordRequired, AddressOf index_PasswordRequired
        ' User can subscribe to PasswordRequired event to be able to specify a password
        index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile, "test")
        ' User can set passwords for some documents in this property
        index.AddToIndex(Utilities.documentsPath)
        Dim results As SearchResults = index.Search(searchQuery)
        'ExEnd:SetPassword
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

    ' This event will appear for every password protected document
    'ExStart:EventForPasswordRequired
    Public Shared Sub index_PasswordRequired(sender As Object, e As PasswordRequiredArg)
        If e.DocumentFullName = Utilities.pathToPasswordProtectedFile Then

        End If
        ' User should put password to Password field of event argument
        e.Password = "test"
    End Sub
    'ExEnd:EventForPasswordRequired

    ''' <summary>
    ''' Allows to use privileges of IEnumerable for Password dictionary.
    ''' This enhancement is introduced in v17.02
    ''' </summary>
    Public Shared Sub InheritPasswordDictionary()
        'ExStart:InheritPasswordDictionary
        Dim index As New Index(Utilities.indexPath)
        index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile, "test")
        index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile2, "password1")
        index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile3, "password2")

        For Each documentName As String In index.Dictionaries.DocumentPasswords
            Dim password As String = index.Dictionaries.DocumentPasswords(documentName)
        Next
        'ExEnd:InheritPasswordDictionary

        'adding all these documents to index after password has been set
        index.AddToIndex(Utilities.documentsPath)
        Dim searchQuery As String = "content"
        Dim results As SearchResults = index.Search(searchQuery)
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

#End Region


#Region "Spelling Corrector Functionality"
    ''' <summary>
    ''' Dealing with password protected documents, using both methods
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub SpellingCorrectorUsage(searchQuery As String)
        'ExStart:SpellingCorrectorUsage
        'create or load index
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        ' Enabling spelling corrector
        parameters.SpellingCorrector.Enabled = True
        ' The default value for maximum mistake count is 2
        parameters.SpellingCorrector.MaxMistakeCount = 1

        ' Search for misspelled term 'structure'
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:SpellingCorrectorUsage
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

    ''' <summary>
    ''' shows how to manage spelling corrector
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub SpellingCorrectorManagement(searchQuery As String)
        'ExStart:SpellingCorrectorManagement
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Remove all words from spelling corrector dictionary
        index.Dictionaries.SpellingCorrector.Clear()
        ' Import spelling dictionary from file. Existing words are staying.
        index.Dictionaries.SpellingCorrector.Import(Utilities.spellingDictionaryFilePath)
        Dim words As String() = New String() {"structure", "building", "rail", "house"}
        ' Add word array to the dictionary. Words are case insensitive.
        index.Dictionaries.SpellingCorrector.AddRange(words)
        ' Export spelling dictionary to file.
        index.Dictionaries.SpellingCorrector.Export(Utilities.exportedSpellingDictionaryFilePath)

        Dim parameters As New SearchParameters()
        ' Enabling spelling corrector
        parameters.SpellingCorrector.Enabled = True
        ' The default value for maximum mistake count is 2
        parameters.SpellingCorrector.MaxMistakeCount = 1

        ' Search for misspelled term 'structure'
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:SpellingCorrectorManagement
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

#End Region

#Region "Alias Dictionary functionality"
    ''' <summary>
    ''' Adds an alias to the dictionary before search
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub AddingAliasToDictionaryBeforeSearch(searchQuery As String)
        'ExStart:AddingAliasToDictionaryBeforeSearch
        'Create or load index
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Add alias 's' to the dictionary
        index.Dictionaries.AliasDictionary.Add("s", "structure")
        ' Search for term 'structure'
        Dim results As SearchResults = index.Search(searchQuery)
        'ExEnd:AddingAliasToDictionaryBeforeSearch
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

    ''' <summary>
    ''' Dealing with password protected documents, using both methods
    ''' </summary>
    ''' <param name="searchQuery">string to search</param> 
    Public Shared Sub UseAliasDictionary(searchQuery As String)
        'ExStart:AliasDictionaryUsage
        'Create or load Index
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Clear dictionary of aliases
        index.Dictionaries.AliasDictionary.Clear()
        ' Add alias 's' to the dictionary. Alias and aliased text are case insensitive.
        index.Dictionaries.AliasDictionary.Add("s", "structure")
        ' Remove alias 'x' from the dictionary. Words which are absent will be ignored.
        index.Dictionaries.AliasDictionary.Remove("x")
        ' Import aliases from file. Existing aliases are staying.
        index.Dictionaries.AliasDictionary.Import(Utilities.aliasFilePath)
        ' Export aliases to file
        index.Dictionaries.AliasDictionary.Export(Utilities.exportedAliasFilePath)

        ' Search for term 'structure'
        Dim results As SearchResults = index.Search(searchQuery)
        'ExEnd:AliasDictionaryUsage
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub
#End Region

#Region "Homophone Dictionary Functionality"

    ''' <summary>
    ''' shows how to use homophone search
    ''' </summary>
    ''' <param name="searchQuery">the term to be searched</param>
    Public Shared Sub HomophoneSearchUsage(searchQuery As String)
        'ExStart:HomophoneSearchUsage
        'Create or load index
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        ' Enable homophone search in parameters
        parameters.UseHomophoneSearch = True

        ' Search for "pause", "paws", "pores", "pours"
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:HomophoneSearchUsage
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub


    ''' <summary>
    ''' shows how to manage homophone dictionary
    ''' </summary>
    ''' <param name="searchQuery">The term to be searched</param>
    Public Shared Sub HomophoneDictionaryManagement(searchQuery As String)
        'ExStart:HomophoneDictionaryManagement
        'Create or load index
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        ' Clearing homophone dictionary
        index.Dictionaries.HomophoneDictionary.Clear()

        ' Adding homophones
        Dim homophoneGroup1 As String() = New String() {"braise", "brays", "braze"}
        Dim homophoneGroup2 As String() = New String() {"pause", "paws", "pores", "pours"}
        Dim homophoneGroups As New List(Of String())()
        homophoneGroups.Add(homophoneGroup1)
        homophoneGroups.Add(homophoneGroup2)
        index.Dictionaries.HomophoneDictionary.AddRange(homophoneGroups)

        ' Import homophones from file. Existing homophones are staying.
        index.Dictionaries.HomophoneDictionary.Import(Utilities.homophonesFilePath)
        ' Export homophones to file
        index.Dictionaries.HomophoneDictionary.Export(Utilities.exportedHomophonesFilePath)

        Dim parameters As New SearchParameters()
        ' Enable homophone search in parameters
        parameters.UseHomophoneSearch = True

        ' Search for "pause", "paws", "pores", "pours"
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:HomophoneDictionaryManagement
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

#End Region

#Region "Keyboard Layout Corrector Functionality"
    'This enhancement is introduced in v17.02
    ''' <summary>
    ''' Shows how to use keyboard layout corrector
    ''' </summary>
    ''' <param name="searchQuery">The term to be searched</param>
    Public Shared Sub KeyboardLayoutCorrectorUsage(searchQuery As String)
        'ExStart:KeyboardLayoutCorrectorUsage
        'Create or load index
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)

        Dim parameters As New SearchParameters()
        ' Enable keyboard layout correction in parameters
        parameters.KeyboardLayoutCorrector.Enabled = True

        ' Search for "pause", using "зфгыу", its equilient in Russian keyboard layout as search query 
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:KeyboardLayoutCorrectorUsage

        'display results
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

#End Region

#Region "Use all search features"
    'This enhancement is introduced in v17.02
    ''' <summary>
    ''' Shows how to enable multiple search features in a single search operation
    ''' </summary>
    ''' <param name="searchQuery">The term to be searched</param>
    Public Shared Sub UsingAllSearchFeatures(searchQuery As String)
        'ExStart:UsingAllSearchFeatures
        'Create or load index
        Dim index As New Index(Utilities.indexPath)
        'Add documents to index
        index.AddToIndex(Utilities.documentsPath)
        ' Adding alias to dictionary
        index.Dictionaries.AliasDictionary.Add("alias", "alias subquery")
        ' Adding homophones to dictionary
        index.Dictionaries.HomophoneDictionary.AddRange(New List(Of String())() From {
            New String() {"cell", "sell"}
        })
        ' Adding synonyms to dictionary
        index.Dictionaries.SynonymDictionary.AddRange(New List(Of String())() From {
            New String() {"little", "small"}
        })

        Dim searchParams As New SearchParameters()
        ' Turning on layout corrector
        searchParams.KeyboardLayoutCorrector.Enabled = True
        ' Turning on spelling corrector
        searchParams.SpellingCorrector.Enabled = True
        searchParams.SpellingCorrector.MaxMistakeCount = 1
        ' Turning on synonym search feature
        searchParams.UseSynonymSearch = True
        ' Turning on homophone search feature
        searchParams.UseHomophoneSearch = True
        ' Turning on fuzzy search feature
        searchParams.FuzzySearch.Enabled = True
        ' Turning on fuzzy search feature
        searchParams.FuzzySearch.SimilarityLevel = 0.9

        ' Run searching with all search features
        Dim results As SearchResults = index.Search(searchQuery, searchParams)
        'ExEnd:UsingAllSearchFeatures

        'display results
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

#End Region


#Region "Implement Functions Showing Relation Between Max Mistake Count and Word Length for Fuzzy Search"
    ''' <summary>
    ''' Shows how to use max mistake count function as fuzzy algorithm
    ''' feature is supported in version 17.03 or greater
    ''' </summary>
    ''' <param name="searchQuery"></param>
    Public Shared Sub UseMaxMistakeCountFuncAsFuzzyAlgorithm(searchQuery As String)
        'ExStart:UseMaxMistakeCountFuncAsFuzzyAlgorithm
        Dim indexFolder As String = Utilities.indexPath
        Dim documentsFolder As String = Utilities.documentsPath

        Dim index As New Index(indexFolder)
        index.AddToIndex(documentsFolder)

        Dim parameters As New SearchParameters()
        ' Turning on fuzzy search feature
        parameters.FuzzySearch.Enabled = True
        ' Setting up fuzzy algorithm
        parameters.FuzzySearch.FuzzyAlgorithm = New TableDiscreteFunction(3, New Integer() {0, 1, 1, 2})
        ' This function returns 0 when input value is 3 or less,
        ' returns 1 when input value is 4 or 5,
        ' and returns 2 when input value is 6 or greater.

        ' Search for the query with a maximum of 2 mistakes
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:UseMaxMistakeCountFuncAsFuzzyAlgorithm

        'display results
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

    ''' <summary>
    ''' Shows how to use constant value of max mistake count for each term in query regardless of its length
    ''' feature is supported in version 17.03 or greater
    ''' </summary>
    ''' <param name="searchQuery"></param>
    Public Shared Sub UseConstMaxMistakeCount(searchQuery As String)
        'ExStart:UseConstMaxMistakeCount
        Dim indexFolder As String = Utilities.indexPath
        Dim documentsFolder As String = Utilities.documentsPath

        Dim index As New Index(indexFolder)
        index.AddToIndex(documentsFolder)

        Dim parameters As New SearchParameters()
        ' Turning on fuzzy search feature
        parameters.FuzzySearch.Enabled = True
        ' This function returns 2 for terms of any length
        parameters.FuzzySearch.FuzzyAlgorithm = New TableDiscreteFunction(0, New Integer() {2})

        ' Search for "discree" with a maximum of 2 mistakes
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:UseConstMaxMistakeCount

        'display results
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub

    ''' <summary>
    ''' Shows how to use similarity level object as fuzzy algorithm
    ''' feature is supported in version 17.03 or greater
    ''' </summary>
    ''' <param name="searchQuery"></param>
    Public Shared Sub UseSimilarityLevelObjAsFuzzyAlgo(searchQuery As String)
        'ExStart:UseSimilarityLevelObjAsFuzzyAlgo
        Dim indexFolder As String = Utilities.indexPath
        Dim documentsFolder As String = Utilities.documentsPath

        Dim index As New Index(indexFolder)
        index.AddToIndex(documentsFolder)

        Dim parameters As New SearchParameters()
        ' Turning on fuzzy search feature
        parameters.FuzzySearch.Enabled = True
        ' Setting up fuzzy algorithm
        parameters.FuzzySearch.FuzzyAlgorithm = New SimilarityLevel(0.7)

        ' Search for "discree" with a maximum of 2 mistakes
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        'ExEnd:UseSimilarityLevelObjAsFuzzyAlgo

        'display results
        If results.Count > 0 Then
            ' List of found files
            For Each documentResultInfo As DocumentResultInfo In results
                Console.WriteLine("Query ""{0}"" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName)
            Next
        Else
            Console.WriteLine("No results found")
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Limits the number of search results
    ''' feature is supported in version 17.03 or greater
    ''' </summary>
    Public Shared Sub LimitSearchResults(searchQuery As String)
        'ExStart:LimitSearchResults
        Dim indexFolder As String = Utilities.indexPath
        Dim documentsFolder As String = Utilities.documentsPath

        Dim index As New Index(indexFolder)
        index.AddToIndex(documentsFolder)

        Dim parameters As New SearchParameters()
        ' Setting the limitation of result count for each term in a query. The default value is 100000.
        parameters.MaxHitCountPerTerm = 200
        ' Setting the limitation of total result count for a query. The default value is 500000. 
        parameters.MaxTotalHitCount = 800

        ' Search for the query with limitation of 200 occurrences
        Dim results As SearchResults = index.Search(searchQuery, parameters)
        If results.Truncated Then
            Console.WriteLine(results.Message)
        End If
        'ExEnd:LimitSearchResults
    End Sub

End Class
