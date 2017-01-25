Module Module1

    Sub Main()

        'Uncomment to apply license
        'Utilities.ApplyLicense()

#Region "Searching"
        'Simple search, search a word
        'Searching.SimpleSearch("hydra")

        'Search term1 and term2 or term3 but not term4
        'Searching.BooleanSearch("(atirtahir AND certificate)", "(return NOT omega)")

        'Search for documents that contain a relevant word and term1, an email address or term2
        'Searching.RegexSearch("^.*turn.*$", @"development ^[A-Z0-9._%+\-|A-Z0-9._%+-]+@++[A-Z0-9.\-|A-Z0-9.-]+\.[A-Z|A-Z]{2,}$ web")

        'Search results from misspelled search query
        'Searching.FuzzySearch("return")

        'Searching for any document in index that contain word "return" in file content
        'Searching.FacetedSearch("return")

        'Searching for any document in index that contain word "readme" in file name
        'Searching.SearchFileName("readme")

        'Faceted search combine with boolean search
        'Searching.FacetedSearchWithBooleanSearch("(virtual OR comsats)","(search AND engine)")

        'Searching for documents with words one of words "remote", "virtual" or "online"
        'Searching.SynonymSearch("remote")

        'Searching.OwnExtractorOst("dropbox")

        'Searching.DetailedResults("remote")

        'Dim src As New Searching()
        'src.OpenFoundMessageUsingAsposeEmail("text")

        'Performs a Case sensitive search 
        'Searching.CaseSensitiveSearch("coat")

        'Manages Synonyms functionality
        'Searching.ManageSynonyms("text")

        'Manages Stop words dictionary
        'Searching.ManageStopWords("text")
        'Searches while disabling use of stop words
        'Searching.DisableStopWords("coat")

        'Searching Password protected document using Event arguments
        'Searching.SearchingPasswordProtectedDocsUsingEvent("sample")
        'Searching Password protected document using index.Dictionary.DocumentPasswords property
        'Searching.SearchingPasswordProtectedDocsUsingProperty("sample")
        'Searching Password protected document using both Event arguments And index.Dictionary.DocumentPasswords property
        'Searching.SearchingPasswordProtectedDocs("sample")

        'Search using Spelling Corrector
        'Searching.SpellingCorrectorUsage("strukture")
        'Manage spelling corrector
        'Searching.SpellingCorrectorManagement("strukture")


        'Adding an alias to dictionary before search
        'Searching.AddingAliasToDictionaryBeforeSearch("@s")
        'Using alias dictionary
        'Searching.UseAliasDictionary("@s")

        'Using homophone search
        'Searching.HomophoneSearchUsage("pause")
        'Manage homephone dictionary
        'Searching.HomophoneDictionaryManagement("braise")

#End Region

#Region "Indexing"

        'Indexing.LoadIndex()

        'Indexing.AddDocumentToIndex()

        'Indexing.AddDocumentToIndexAsynchronously()

        'Indexing.CreateIndexInMemory()

        'Indexing.CreateIndexInMemoryWithIndexSettings()

        'Indexing.CreateIndexOnDisk()

        'Indexing.CreateWithOverwritingExistedIndex()

        'Indexing.UpdateIndex()

        'Indexing.UpdateIndexAsynchronously()

        'Indexing.UpdateIndexInRepoAsynchronously()

        'Indexing.UpdateIndexInRepository()

        'Indexing.SubscriptionToEvents()

        'Indexing.CustomExtractor()

        'Indexing.PreventUnnecessaryFileIndex()

        'Indexing.TrackAllChanges()

        'Indexing.IndexSeparateFiles()

        'Indexing.MergingIndexWithDeltaIndexes()

        'Indexing.MergingMultipleIndexes()

        'Indexing.MergingCurrentIndexWithIndexRepository()

        'Indexing.MergingIndexWithDeltaIndexesAsync()

        'Indexing.MergingMultipleIndexesAsync()

        'Indexing.MergingCurrentIndexWithIndexRepositoryAsync()

#End Region
        Console.ReadKey()

    End Sub

End Module
