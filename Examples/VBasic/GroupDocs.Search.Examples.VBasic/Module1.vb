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

        'Search using Keyboard Layout Corrector
        'Use word "pause" in Russian keyboard layout as a search query
        'Searching.KeyboardLayoutCorrectorUsage("зфгыу")

        ' Query with alias, ordinary term, regex And term for spelling corrector
        'Searching.UsingAllSearchFeatures("@alias term ^reg.ex зфгыу")

        'Inherits Password Dictionary from IEnumerable to make it Like other dictionaries
        'Searching.InheritPasswordDictionary()

        'Performs numeric range search, here we are passing numeric range query for searching any number in range beetween 13 and 42
        'Searching.NumericRangeSearch("13~~42")

        'Shows how to limit the number of search results
        'Searching.LimitSearchResults("pause")

        'Shows how to use max mistake count function as fuzzy algorithm
        'Searching.UseMaxMistakeCountFuncAsFuzzyAlgorithm("paus")
        'Shows how to use constant value of max mistake count for each term in query regardless of its length
        'Searching.UseConstMaxMistakeCount("paose")
        'Shows how to use similarity level object as fuzzy algorithm
        'Searching.UseSimilarityLevelObjAsFuzzyAlgo("paose")

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

        'Indexing.AddDocsToOldIndexVersion()

#End Region
        Console.ReadKey()

    End Sub

End Module
