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
            Searching.BooleanSearch("(hail AND hydra)","(hydra NOT omega)");
            
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

            #endregion

        }
    }
}
