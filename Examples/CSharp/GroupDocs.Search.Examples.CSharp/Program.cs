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
            Utilities.ApplyLicense();

            #region Searching
            ////Simple search, search a word
            //Searching.SimpleSearch("tools");

            ////Search term1 and term2 or term3 but not term4
            //Searching.BooleanSearch("(hail AND hydra)","(hydra NOT omega)");

            ////Search for documents that contain a relevant word and term1, an email address or term2
            //Searching.RegexSearch("^.*turn.*$", @"dropbox ^[A-Z0-9._%+\-|A-Z0-9._%+-]+@++[A-Z0-9.\-|A-Z0-9.-]+\.[A-Z|A-Z]{2,}$ folder");

            ////Search results from misspelled search query
            //Searching.FuzzySearch("retur");

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


            //Adding an alias to dictionary before search
            //Searching.AddingAliasToDictionaryBeforeSearch("@s");
            //Using alias dictionary
            //Searching.UseAliasDictionary("@s");

            //Using homophone search
            //Searching.HomophoneSearchUsage("pause");
            //Manage homephone dictionary
            //Searching.HomophoneDictionaryManagement("braise");


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

            //Indexing.MergingIndexWithDeltaIndexes();
            //Indexing.MergingMultipleIndexes();
            //Indexing.MergingCurrentIndexWithIndexRepository();
            //Indexing.MergingIndexWithDeltaIndexesAsync();
            //Indexing.MergingMultipleIndexesAsync();
            //Indexing.MergingCurrentIndexWithIndexRepositoryAsync();

            #endregion

            Console.ReadKey();
        }
    }
}
