Module Module1

    Sub Main()

        'Uncomment to apply license
        'Utilities.ApplyLicense()

        '#Region "Searching"
        'Simple search, search a word
        'Searching.SimpleSearch("twist")

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

        '#End Region

        '#Region "Indexing"

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


        '#End Region

    End Sub

End Module
