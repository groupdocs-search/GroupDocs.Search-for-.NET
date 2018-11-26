using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Search_for_.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uncomment to apply license
            //Utilities.ApplyLicense();

            //Use Dynabic.Metered account
            //Utilities.UseDynabicMeteredAccount();
            //Searching.ExactPhraseSearchWithHighlightedResults();
            #region Searching
            ////Simple search, search a word
            //Searching.SimpleSearch("tools");

            ////Search term1 and term2 or term3 but not term4
            //Searching.BooleanSearch("(hail AND hydra)","(hydra NOT omega)");

            ////Search for documents that contain a relevant word and term1, an email address or term2
            //Searching.RegexSearch("^.*turn.*$", @"dropbox ^[A-Z0-9._%+\-|A-Z0-9._%+-]+@++[A-Z0-9.\-|A-Z0-9.-]+\.[A-Z|A-Z]{2,}$ folder");

            ////Search results from misspelled search query
            //Searching.FuzzySearch("retur");

            //Show only best results from a fuzzy search
            //Searching.FuzzySearchBestResults("return");
            //Show only best results range from a fuzzy search
            //Searching.FuzzySearchOnlyBestResultsRange("retur");
            //Fuzzy search with consider transposition option
            //Searching.FuzzySearchConsiderTransposition("return");

            //Cancel Search Operation 
            //Searching.CancelSearchOperation("is");

            //Cancel Search Operation with time limitation
            //Searching.CancelSearchOperationWithTimeLimitation("is");

            //Search with Query as a parameter 
            //Searching.SearchWithQuery();

            ////Searching for any document in index that contain word "return" in file content
            //Searching.FacetedSearch("return");

            ////Searching for any document in index that contain word "readme" in file name
            //Searching.SearchFileName("getting");

            ////Faceted search combine with boolean search
            //Searching.FacetedSearchWithBooleanSearch("(dropbox OR comsats)","(search AND engine)");

            ////Searching for documents with words one of words "remote", "virtual" or "online"
            //Searching.SynonymSearch("online");

            //Searching.OwnExtractorOst("dropbox");

            //Searching.DetailedResults("dropbox");

            //Searching src = new Searching();
            //src.OpenFoundMessageUsingAsposeEmail("text");

            ////User warning on running Search with not supported options
            //Searching.NotSupportedOptionWarning("some search query");

            //count of total hit count of search query in found results
            //Searching.TotalHitCount("some search query");

            //search documents wih exact phrase 
            //Searching.ExactPhraseSearch("\"cost\"");

            //Get list of the words in found documents that matched the search query
            //Searching.GetMatchingWordsInRegexSearchResult("^.*co.*$");

            //Get list of the words in found documents that matched the search query
            //Searching.GetMatchingWordsInFuzzySearchResult("coat");

            //Performs a Case sensitive search 
            //Searching.CaseSensitiveSearch("COAT");

            //Manages Synonyms search
            //Searching.ManageSynonyms("big");

            //Manages Stop Word dictionary
            //Searching.ManageStopWords("three");
            //Searches while disabling use of stop words
            //Searching.DisableStopWords("coat");

            //Searching Password protected document using Event arguments
            //Searching.SearchingPasswordProtectedDocsUsingEvent("sample");
            //Searching Password protected document using index.Dictionary.DocumentPasswords property
            //Searching.SearchingPasswordProtectedDocsUsingProperty("sample");
            //Searching Password protected document using both Event arguments and index.Dictionary.DocumentPasswords property
            //Searching.SearchingPasswordProtectedDocs("sample");

            //Search using Spelling Corrector
            //Searching.SpellingCorrectorUsage("strukture");
            //Manage spelling corrector
            //Searching.SpellingCorrectorManagement("strukture");
            //Searh only best results
            //Searching.SpellingCorrectorBestResults("strukture");
            //Consider transpositions in Spelling corrector 
            //Searching.SpellingCorrectorConsiderTranspositions("strukture");
            //Shows how to use OnlyBestResultsRange property
            //Searching.SpellingCorrectorBestResultsRange("strukture");


            //Adding an alias to dictionary before search
            //Searching.AddingAliasToDictionaryBeforeSearch("@s");
            //Using alias dictionary
            //Searching.UseAliasDictionary("@s");

            //Using homophone search
            //Searching.HomophoneSearchUsage("pause");
            //Manage homephone dictionary
            //Searching.HomophoneDictionaryManagement("braise");

            //Search using Keyboard Layout Corrector
            //Use word "pause" in Russian keyboard layout as a search query
            //Searching.KeyboardLayoutCorrectorUsage("зфгыу");

            // Query with alias, ordinary term, regex and term for spelling corrector
            //Searching.UsingAllSearchFeatures("@alias term ^reg.ex зфгыу");

            //Inherits Password Dictionary from IEnumerable to make it like other dictionaries
            //Searching.InheritPasswordDictionary();

            //Performs numeric range search, here we are passing numeric range query for searching any number in range beetween 13 and 42
            //Searching.NumericRangeSearch("13~~42");

            //Performs date range search
            //This query will find all dates between beginning of 2000 year and ending of 2017 in any documents fields // (content, creation date, modification date and other). 
            //Searching.DateRangeSearch("daterange(1.1.2015~~12.31.2017)");
            //Performs date range search with faceted search

            //This query will find all dates between beginning of 2000 year and ending of 2017 only in documents content. 
            //Searching.DateRangeWithFacetedSearch("content:daterange(1.1.2000~~12.31.2017)");

            //This method allows searchigg with date range provided in ISO 8601 format
            //Searching.DateRangeISO8601Search("content:daterange(2000-10-25~~2017-01-03)");

            //This method provides the ability to set a collection of date formats for date range search.
            //Searching.DateRangeCollectionSearch("content:daterange(2000-10-25~~2017-01-03)");

            //This method is implemented to make it possible to search phrase with wildcards.
            //Searching.WildCardSearch();

            //Shows how to limit the number of search results
            //Searching.LimitSearchResults("pause");

            //Shows how to use max mistake count function as fuzzy algorithm
            //Searching.UseMaxMistakeCountFuncAsFuzzyAlgorithm("paus");
            //Shows how to use constant value of max mistake count for each term in query regardless of its length
            //Searching.UseConstMaxMistakeCount("paose");
            //Shows how to use similarity level object as fuzzy algorithm
            //Searching.UseSimilarityLevelObjAsFuzzyAlgo("paose");

            //shows how to use table discrete function as step function
            //Searching.TableDiscreteFuncAsStepFunction();
            //Shows how to use step function in fuzzy search
            //Searching.UseStepFunctionInFuzzySearch("pause");

            //get search report
            //Searching.GetSearchReport();
            //Searching.LimitSearchReport();

            //highlighted search results functionality
            //Searching.GenerateHighlightedTextSearchResults("pause");
            //Searching.GenerateHighlightedTextResultsToFile("pause");

            //Searching by parts(Chunks)
            //Searching.SearchingByParts("return");

            //Specify number of thread for searching 
            //Searching.SpecicyNumberOfThreads("return");

            //Specify searching time feild to search results
            //Searching.SpecifySearcingTime("return");

            //Searching using morphological word forms
            //Searching.SearchUsingMorphologicalWordForm();

            //Generate HTML formatted text with highlighted found words
            //Searching.GenerateHighlightedTextResultsHtml();
            #endregion

            #region Indexing

            //Indexing.LoadIndex();

            //Indexing.AddDocumentToIndex();

            //Indexing.AddDocumentToIndexAsynchronously();

            //Indexing.CreateIndexInMemory();

            //Indexing.CreateIndexInMemoryWithIndexSettings();

            //Indexing.CreateIndexOnDisk();

            //Indexing.CreateWithOverwritingExistedIndex();

            //Indexing.UpdateIndex();

            //Indexing.UpdateIndexAsynchronously();

            //Indexing.UpdateIndexInRepoAsynchronously();

            //Indexing.UpdateIndexInRepository();

            //Indexing.SubscriptionToEvents();

            //Indexing.CustomExtractor();

            //Indexing.PreventUnnecessaryFileIndex();

            //Indexing.TrackAllChanges();

            //Indexing.IndexSeparateFiles();

            //Indexing.GetIndexingProgressPercentage();

            //Indexing.CheckNeedForIndexReload();

            //Indexing.CallProgressChangedEvent();

            //Indexing.MergingIndexWithDeltaIndexes();
            //Indexing.MergingMultipleIndexes();
            //Indexing.MergingCurrentIndexWithIndexRepository();
            //Indexing.MergingIndexWithDeltaIndexesAsync();
            //Indexing.MergingMultipleIndexesAsync();
            //Indexing.MergingCurrentIndexWithIndexRepositoryAsync();

            //Indexing.AddDocsToOldIndexVersion();

            //Indexing.AddLetterstoDictionary();

            //Indexing.AccentInsensitiveIndexing();

            //Indexing.GetIndexReport();
            //Indexing.LimitIndexReport();

            //Indexing.SkipIndexingByFileName();
            //Indexing.SetFileEncoding();
            //Indexing.SetCustomTextExtractor();
            //Indexing.StatusChangedEventUsage();

            //Indexing.CacheTextOfIndexedDocsInIndex();
            //Indexing.FilterFilesDuringIndexing();

            //Indexing.AutomaticDetectEncoding();
            //Indexing.DetectEncodingSelectively();

            //Indexing.CompactIndexing();

            //Indexing.MultiThreadedIndexing();

            //Indexing.MultiThreadedIndexingAsync();

            //Indexing.IndexMetaData();

            //Indexing.BreakIndexingManually();

            //Break Update operation manually
            //Indexing.BreakUpdatingManually();

            //Break Updating with cancellation object
            //Indexing.BreakUpdatingUsingCancellationObject();

            //Break Merging Manually
            //Indexing.BreakMergingManually();

            //Break indexing with cancellation object 
            //Indexing.BreakIndexingWithCancellationObject();

            //Break Index Repository 
            //Indexing.BreakIndexRepository();

            //Break Index Repository using Cancellation Object 
            //Indexing.BreakIndexRepositoryUsingCancellationObject();

            //Get a list of indexed documents from an index
            //Indexing.GetListOfIndexedDocuments();

            //Extract Document Text from Index
            //Indexing.ExtracDocumentTextFromIndex();

            //Extract Document Text from Index to File
            //Indexing.ExtracDocumentTextToFileFromIndex();


            #endregion

            # region Business Cases

            // Create new books index, add documents and search
             BusinessCases.SearchBooks();

            // Search in existing books index
             BusinessCases.SearchBooksInExistingIndex();

            // Add documents in index
             BusinessCases.AddDocumentsInBooksIndex();

            // Update books index
             BusinessCases.UpdateBooksIndex();

            // Search in several indexes
             BusinessCases.SearchInSeveralIndexes();

            # endregion

            Console.ReadKey();
        }
    }
}
