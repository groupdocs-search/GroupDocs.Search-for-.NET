using GroupDocs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Search_for_.NET
{
    class Searching
    {
        /// <summary>
        /// Creates index, adds documents to index and search string in index
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void SimpleSearch(string searchString)
        {
            //ExStart:SimpleSearch
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Search in index
            SearchResults searchResults = index.Search(searchString);

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }
            //ExEnd:SimpleSearch
        }

        /// <summary>
        /// Creates index, adds documents to index and do boolean search
        /// </summary>
        /// <param name="firstTerm">first term to search</param>
        /// <param name="secondTerm">second term to search</param>
        public static void BooleanSearch(string firstTerm, string secondTerm)
        {
            //ExStart:BooleanSearch
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Search in index
            SearchResults searchResults = index.Search(firstTerm + "OR" + secondTerm);

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }
            //ExEnd:BooleanSearch
        }

        /// <summary>
        /// Creates index, adds documents to index and do regex search
        /// </summary>
        /// <param name="relevantKey">single keyword</param>
        /// <param name="regexString">regex</param>
        public static void RegexSearch(string relevantKey, string regexString)
        {
            //ExStart:Regexsearch
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Search for documents where at least one word contain given regex
            SearchResults searchResults1 = index.Search(relevantKey);

            //Search for documents where present term1 or any email adress or term2
            SearchResults searchResults2 = index.Search(regexString);

            // List of found files 
            Console.WriteLine("Follwoing document(s) contain provided relevant tag: \n");
            foreach (DocumentResultInfo documentResultInfo in searchResults1)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }

            // List of found files
            Console.WriteLine("Follwoing document(s) contain provided RegEx: \n");
            foreach (DocumentResultInfo documentResultInfo in searchResults2)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }
            //ExEnd:Regexsearch
        }

        /// <summary>
        /// Creates index, adds documents to index and do fuzzy search
        /// </summary>
        /// <param name="searchString">Misspelled string</param>
        public static void FuzzySearch(string searchString)
        {
            //ExStart:Fuzzysearch
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            parameters.UseFuzzySearch = true;

            SearchResults searchResults = index.Search(searchString, parameters);

            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine(documentResultInfo.FileName + "\n");
            }
            //ExEnd:Fuzzysearch
        }

        /// <summary>
        /// Creates index, adds documents to index and do faceted search
        /// </summary>
        /// <param name="searchString">search string</param>
        public static void FacetedSearch(string searchString)
        {
            //ExStart:Facetedsearch
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Searching for any document in index that contain word "return" in file content
            SearchResults searchResults = index.Search("Content:" + searchString);


            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }
            //ExEnd:Facetedsearch
        }

        /// <summary>
        /// Creates index, adds documents to index and searches file name that containes similar/inputted string 
        /// </summary>
        /// <param name="searchString">search string</param>
        public static void SearchFileName(string searchString)
        {
            //ExStart:SearchFileName
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Searching for any document in index that contain search string in file name
            SearchResults searchResults = index.Search("FileName:" + searchString);


            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }
            //ExEnd:SearchFileName
        }

        /// <summary>
        /// Creates index, adds documents to index and do faceted search combine with boolean search
        /// </summary>
        /// <param name="firstTerm">first term</param>
        /// <param name="secondTerm">second term</param>
        public static void FacetedSearchWithBooleanSearch(string firstTerm, string secondTerm)
        {
            //ExStart:FacetedSearchWithBooleanSearch
            // Create index
            Index index = new Index(Utilities.indexPath);

            // Add documents to index
            index.AddToIndex(Utilities.documentsPath);
            //Faceted search combine with boolean search
            SearchResults searchResults = index.Search("Content:" + firstTerm + "OR Content:" + secondTerm);

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }
            //ExEnd:FacetedSearchWithBooleanSearch
        }

        /// <summary>
        /// Creates index, adds documents to index and do search on the basis of synonyms by turning synonym search true
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void SynonymSearch(string searchString)
        {
            //ExStart:SynonymSearch
            // Create or load index
            Index index = new Index(Utilities.indexPath);

            // load synonyms
            index.LoadSynonyms(Utilities.synonymFilePath);

            index.AddToIndex(Utilities.documentsPath);

            // Turning on synonym search feature
            SearchParameters parameters = new SearchParameters();
            parameters.UseSynonymSearch = true;

            // searching for documents with words one of words "remote", "virtual" or "online"
            SearchResults searchResults = index.Search(searchString, parameters);

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.Write(documentResultInfo.FileName + "\n");
            }
            //ExEnd:SynonymSearch
        }
    }
}
