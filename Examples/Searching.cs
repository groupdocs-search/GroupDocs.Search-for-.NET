using Aspose.Email.Outlook.Pst;
using GroupDocs.Search;
using GroupDocs.Search.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
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
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", firstTerm, documentResultInfo.HitCount, documentResultInfo.FileName);
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", secondTerm, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
            //ExEnd:BooleanSearch
        }
        /// <summary>
        /// Allows user to search with queries as a parameter
        /// Feature is supported in version 18.1 of the API
        /// </summary>
        public static void SearchWithQuery()
        {
            //ExStart:SearchWithQuery
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            // Creating subquery 1
            SearchQuery subquery1 = SearchQuery.CreateWordQuery("is");
            subquery1.SearchParameters = new SearchParameters();
            subquery1.SearchParameters.FuzzySearch.Enabled = true;
            subquery1.SearchParameters.FuzzySearch.ConsiderTranspositions = true;
            subquery1.SearchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3);

            // Creating subquery 2
            SearchQuery subquery2 = SearchQuery.CreateNumericRangeQuery(1, 1000000);

            // Creating subquery 3
            SearchQuery subquery3 = SearchQuery.CreateRegexQuery(@"(.)\1");

            // Combining subqueries into one query
            SearchQuery query = SearchQuery.CreatePhraseSearchQuery(subquery1, subquery2, subquery3);

            // Creating search parameters object with increased capacity of results
            SearchParameters searchParameters = new SearchParameters();
            searchParameters.MaxHitCountPerTerm = 1000000;
            searchParameters.MaxTotalHitCount = 10000000;

            // Searching
            SearchResults searchResults = index.Search(query, searchParameters);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query has {0} hit count in file: {1}", documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }

            // The results may contain the following word sequences:
            // futile 12 blessed
            // father 7 excellent
            // tyre 8 assyria
            // return 147 229
            //ExEnd:SearchWithQuery
        }

        /// <summary>
        /// Cancels Search Operation with time limitation
        /// Feature is supported in version 18.1 of the API
        /// </summary>
        /// <param name="searchString"></param>
        public static void CancelSearchOperationWithTimeLimitation(string searchString)
        {
            //ExStart:CancelSearchOperationWithTimeLimitation
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            // Creating cancellation object
            Cancellation cancellation = new Cancellation();
            // Cancelling after 1 second of searching
            cancellation.CancelAfter(1000);

            // Creating search parameters object
            SearchParameters searchParameters = new SearchParameters();
            searchParameters.FuzzySearch.Enabled = true;
            searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3);

            // Searching
            SearchResults searchResults = index.Search(searchString, searchParameters, cancellation);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:CancelSearchOperationWithTimeLimitation
        }

        /// <summary>
        /// Cancels Search Operation
        /// Feature is supported in version 18.1 of the API
        /// </summary>
        /// <param name="searchString"></param>
        public static void CancelSearchOperation(string searchString)
        {

            //ExStart:CancelSearchOperation
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            // Creating cancellation object
            Cancellation cancellation = new Cancellation();
            // Imitating cancelling by request
            Thread thread = new Thread(() =>
            {
                // Cancelling after 1 second of searching
                Thread.Sleep(100000);
                cancellation.Cancel();
            });
            thread.Start();

            // Creating search parameters object
            SearchParameters searchParameters = new SearchParameters();
            searchParameters.FuzzySearch.Enabled = true;
            searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3);

            // Searching
            SearchResults searchResults = index.Search(searchString, searchParameters);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:CancelSearchOperation
        }
		/// <summary>
		/// Generate HTML formatted text with highlighted found words
		/// Feature is supported in version 18.9 of the API
		/// </summary>
		public static void GenerateHighlightedTextResultsHtml()
		{
			// Creating index
			Index index = new Index(Utilities.indexPath);

			// Subscribing to file indexing event
			index.FileIndexing += (sender, args) =>
			{
				// Setting encoding for each text file during indexing
				args.Encoding = Encodings.windows_1251;
			};

			// Adding text documents encoded in windows-1251 to index
			index.AddToIndex(Utilities.documentsPath);

			// Searching for word 'человеческий'
			SearchResults results = index.Search("pause");

			// Generating HTML formatted text with highlighted found words
			// There is no need to provide the encoding again - it is saved in the index
			string htmlText = index.HighlightInText(results[0]);
		}

		/// <summary>
		/// This example shows how to search using morphological word form 
		/// Feature is supported in version 18.7 of the API
		/// </summary>
		public static void SearchUsingMorphologicalWordForm()
		{			
			Index index = new Index(Utilities.indexPath); // Creating index
			index.AddToIndex(Utilities.documentsPath); // Indexing folder with documents
			SearchParameters parameters = new SearchParameters();
			parameters.UseWordFormsSearch = true; // Enabling word forms search
			SearchResults searchResult = index.Search("swimming", parameters); // Searching for words "swim", "swims", "swimming", "swam", "swum"
			
			if (searchResult.Count > 0)
			{
				// List of found files
				foreach (DocumentResultInfo documentResultInfo in searchResult)
				{
					Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", "swimming", documentResultInfo.HitCount, documentResultInfo.FileName);
				}
			}
			else
			{
				Console.WriteLine("No results found");
			}
		}

		/// <summary>
		/// This example shows how to specify the number of searching threads for index
		/// Feature is supported in version 18.5 of the API
		/// </summary>
		/// <param name="searchString"></param>
		public static void SpecifySearcingTime(string searchString)
        {
            string indexFolder = Utilities.indexPath;
            string documentFolder = Utilities.documentsPath;
         
            Index index = new Index(indexFolder, true);
            index.AddToIndex(documentFolder);
            SearchResults result = index.Search(searchString);

            Console.WriteLine("Searching starts: {0}\nSearching ends: {1}\tSearching time: {2}", result.StartTime, result.EndTime, result.SearchingTime);
        }

        /// <summary>
        /// This example shows how to specify the number of searching threads for index
        /// Feature is supported in version 18.5 of the API
        /// </summary>
        /// <param name="searchString"></param>
        public static void SpecicyNumberOfThreads(string searchString)
        {
            string indexFolder = Utilities.indexPath;
            string documentFolder = Utilities.documentsPath;

            IndexingSettings settings = new IndexingSettings();
            // specifying count of threads for searching
            settings.SearchingThreads = NumberOfThreads.One;

            Index index = new Index(indexFolder, true, settings);
            index.AddToIndex(documentFolder);

            // searching using specified above count of threads
            SearchResults result = index.Search(searchString);
        }

        /// This example shows how to perform the search of all chunks consistently
        /// Feature is supported in version 18.5 of the API
        /// </summary>
        /// <param name="searchString"></param>
        public static void SearchingByParts(string searchString)
        {
            string indexFolder = Utilities.indexPath;
            string documentFolder1 = Utilities.documentsPath;
            string documentFolder2 = Utilities.documentsPath2;
            string documentFolder3 = Utilities.documentsPath3;
         

            Index index = new Index(indexFolder, true);

            index.AddToIndex(documentFolder1);
            index.AddToIndex(documentFolder2);
            index.AddToIndex(documentFolder3);

            SearchParameters sp = new SearchParameters();
            sp.IsChunkSearch = true;

            SearchResults result = index.Search(searchString, sp);
            int chankCount = 1;

            while (result.NextChunkSearchToken != null)
            {
                Console.WriteLine("Document count " + chankCount + " ('" + searchString + "'): " + result.Count);
                Console.WriteLine("Occurrence count " + chankCount + " ('" + searchString + "'): " + result.TotalHitCount);

                result = index.Search(result.NextChunkSearchToken);
                chankCount++;
            }

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
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName);
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }

            // List of found files
            Console.WriteLine("Follwoing document(s) contain provided RegEx: \n");
            foreach (DocumentResultInfo documentResultInfo in searchResults2)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName);
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
            //ExEnd:Regexsearch
        }

        #region Fuzzy Searh

        public static void FuzzySearch(string searchString)
        {
            //ExStart:Fuzzysearch
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            // turning on Fuzzy search feature
            parameters.FuzzySearch.Enabled = true;

            // set low similarity level to search for less similar words and get more results
            //This method of setting similarity level has been marked obsolete from version 17.8.0 onwards
            //parameters.FuzzySearch.SimilarityLevel = 0.1;

            //From version 17.8 onwards,this is the way to set similarity level
            parameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.1);
            SearchResults lessSimilarResults = index.Search(searchString, parameters);
            Console.WriteLine("Results with less similarity level that is currently set to =" + parameters.FuzzySearch.FuzzyAlgorithm);
            foreach (DocumentResultInfo lessSimilarResultsDoc in lessSimilarResults)
            {
                Console.WriteLine(lessSimilarResultsDoc.FileName + "\n");
            }

            // set high similarity level to search for more similar words and get less results
            parameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.1);
            SearchResults moreSimilarResults = index.Search(searchString, parameters);

            Console.WriteLine("Results with high similarity level that is currently set to =" + parameters.FuzzySearch.FuzzyAlgorithm);
            foreach (DocumentResultInfo highSimilarityLevelDoc in moreSimilarResults)
            {
                Console.WriteLine(highSimilarityLevelDoc.FileName + "\n");
            }
            //ExEnd:Fuzzysearch
        }

        /// <summary>
        /// Shows how to show only best results from a fuzzy search
        /// Feature is supported in version 17.8.0 of the API
        /// </summary>
        /// <param name="searchString"></param>
        public static void FuzzySearchBestResults(string searchString)
        {
            //ExStart:FuzzySearchBestResults
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            SearchParameters searchParameters = new SearchParameters();
            // Enabling fuzzy search
            searchParameters.FuzzySearch.Enabled = true;
            // Setting maximum mistake count to 5
            searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(5);
            // Enabling OnlyBestResults option
            searchParameters.FuzzySearch.OnlyBestResults = true;

            // Searching
            SearchResults searchResults = index.Search(searchString, searchParameters);
            //ExEnd:FuzzySearchBestResults
        }

        /// <summary>
        /// Shows how to use OnlyBestResultsRange in fuzzy search
        /// Feature is supported by version 17.9.0 or greater
        /// </summary>
        /// <param name="searchString"></param>
        public static void FuzzySearchOnlyBestResultsRange(string searchString)
        {

            //ExStart:FuzzySearchOnlyBestResultsRange
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters searchParameters = new SearchParameters();
            // Enabling fuzzy search
            searchParameters.FuzzySearch.Enabled = true;
            // Setting maximum mistake count to 10
            searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(10);
            // Enabling OnlyBestResults option
            searchParameters.FuzzySearch.OnlyBestResults = true;
            // Setting best results range to 2
            searchParameters.FuzzySearch.OnlyBestResultsRange = 2;

            // Searching
            SearchResults searchResults = index.Search(searchString, searchParameters);
            // If there is no 'aaaaa' word in the index then
            // there will be found 'aaaax' - 1 mistake, 'aaaxx' - 2 mistakes, 'aaxxx' - 3 mistakes
            //ExEnd:FuzzySearchOnlyBestResultsRange
            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }

        }

        /// <summary>
        /// Shows how to consider transposition for Fuzzy search
        /// Feature is supported by version 17.9.0 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void FuzzySearchConsiderTransposition(string searchQuery)
        {
            //ExStart:FuzzySearchConsiderTransposition
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters searchParameters = new SearchParameters();
            // Enabling fuzzy search
            searchParameters.FuzzySearch.Enabled = true;
            // Setting maximum mistake count to 1
            searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);
            // Setting not to consider transposition as a single mistake
            searchParameters.FuzzySearch.ConsiderTranspositions = false;

            // Searching for word 'Mail'
            SearchResults searchResults = index.Search(searchQuery, searchParameters);
            // There will be found word 'mails' - 1 mistake, but will not be found word 'Mali' - 2 mistakes
            //ExEnd:FuzzySearchConsiderTransposition

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
        }

        /// <summary>
        /// Shows how to perform the exact phrase search and get results
        /// </summary> 
        public static void FuzzySearchWithExactPhraseSearching()
        {
            //ExStart:FuzzySearchWithExactPhraseSearching_17.12
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);

            // Creating search parameters object
            SearchParameters searchParameters = new SearchParameters();
            // Enabling fuzzy search
            searchParameters.FuzzySearch.Enabled = true;
            // Setting maximum mistake count to 1
            searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);

            // Searching for phrase 'cumulative distribution function' or phrase 'cumulative density function'
            SearchResults searchResults = index.Search("\"cumulative distribution function\" OR \"cumulative density function\"", searchParameters);

            // Displaying results
            foreach (DocumentResultInfo document in searchResults)
            {
                Console.WriteLine(document.FileName);
                foreach (DetailedResultInfo field in document.DetailedResults)
                {
                    Console.WriteLine(field.FieldName);
                    foreach (string[] phrase in field.TermSequences)
                    {
                        Console.Write("\t");
                        foreach (string word in phrase)
                        {
                            Console.Write(word + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }

            // The results may contain the following phrases:
            // cumulative distribution function
            // cumulative distribution functions
            // cumulative density function
            // cumulative density functions

            //ExEnd:FuzzySearchWithExactPhraseSearching_17.12
        }

        /// <summary>
        /// Shows how to perform search and sort results by relevance
        /// </summary> 
        public static void SearchAndSortResultsByRelevance()
        {
            //ExStart:SearchAndSortResultsByRelevance_17.12
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);

            // Creating search parameters object
            SearchParameters searchParameters = new SearchParameters();
            // Enabling fuzzy search
            searchParameters.FuzzySearch.Enabled = true;
            // Setting maximum mistake count to 1
            searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);

            // Searching for term 'database'
            // Using fuzzy search allows to find the plural form of the term 'databases'
            SearchResults searchResults = index.Search("database", searchParameters);

            // Creating and filling array for sorting
            DocumentResultInfo[] array = new DocumentResultInfo[searchResults.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = searchResults[i];
            }

            // Sorting results in array by relevance in descending order
            Array.Sort(array, new Comparer());
            //ExEnd:SearchAndSortResultsByRelevance_17.12
        }
        #endregion 

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
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
            //ExEnd:Facetedsearch
        }

        /// <summary>
        /// Gets list of the words in found documents that matched the search query
        /// </summary>
        /// <param name="searchString">Search string</param>
        /// 
        public static void GetMatchingWordsInFuzzySearchResult(string searchString)
        {
            //ExStart:GetMatchingWordsInFuzzySearchResult
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            // turning on Fuzzy search feature
            parameters.FuzzySearch.Enabled = true;

            // set low similarity level to search for less similar words and get more results
            parameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.2);

            SearchResults fuzzySearchResults = index.Search(searchString, parameters);
            foreach (DocumentResultInfo documentResultInfo in fuzzySearchResults)
            {
                Console.WriteLine("Document {0} was found with query \"{1}\"\nWords list that was found in document:", documentResultInfo.FileName, searchString);
                foreach (string term in documentResultInfo.Terms)
                {
                    Console.Write("{0}; ", term);
                }
                Console.WriteLine();
            }
            //ExEnd:GetMatchingWordsInFuzzySearchResult
        }

        /// <summary>
        /// Gets list of the words in found documents that matched the search query
        /// </summary>
        /// <param name="searchString">Search string</param>
        /// 
        public static void GetMatchingWordsInRegexSearchResult(string searchString)
        {
            //ExStart:GetMatchingWordsInRegexSearchResult
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();

            SearchResults regexSearchResults = index.Search(searchString);

            foreach (DocumentResultInfo documentResultInfo in regexSearchResults)
            {
                Console.WriteLine("Document {0} was found with query \"{1}\"\nWords list that was found in document:", documentResultInfo.FileName, regexSearchResults);
                foreach (string term in documentResultInfo.Terms)
                {
                    Console.Write("{0}; ", term);
                }
                Console.WriteLine();
            }
            //ExEnd:GetMatchingWordsInRegexSearchResult
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
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
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
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", firstTerm, documentResultInfo.HitCount, documentResultInfo.FileName);
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", secondTerm, documentResultInfo.HitCount, documentResultInfo.FileName);
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

            //index.LoadSynonyms(filepath) method is marked obsolete from version 17.05 onwards, use Import instead
            //index.LoadSynonyms(Utilities.synonymFilePath);

            //below mentioned method to load synonyms is available from version 17.05 or greater
            // Import synonyms from file. Existing synonyms are staying.
            index.Dictionaries.SynonymDictionary.Import(Utilities.synonymFilePath);

            index.AddToIndex(Utilities.documentsPath);

            // Turning on synonym search feature
            SearchParameters parameters = new SearchParameters();
            parameters.UseSynonymSearch = true;

            // searching for documents with words one of words "remote", "virtual" or "online"
            SearchResults searchResults = index.Search(searchString, parameters);

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
            //ExEnd:SynonymSearch
        }

        /// <summary>
        /// Searches documents wih exact phrase 
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void ExactPhraseSearch(string searchString)
        {
            //ExStart:ExactPhraseSearch
            // Create or load index
            Index index = new Index(Utilities.indexPath, true);

            index.AddToIndex(Utilities.documentsPath);

            SearchResults searchResults = index.Search(searchString);

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
            //ExEnd:ExactPhraseSearch
        }

        /// <summary>
        /// Shows how to generate text with highlighted results of exact phrase search
        /// </summary> 
        public static void ExactPhraseSearchWithHighlightedResults()
        {
            //ExStart:ExactPhraseSearchWithHighlightedResults_17.12
            // Create or load index
            Index index = new Index(Utilities.indexPath, true);

            index.AddToIndex(Utilities.documentsPath);

            // Searching for phrase 'cumulative distribution function'
            SearchResults results = index.Search("\"cumulative distribution function\"");

            // Generating HTML-formatted text for the first document directly to the file i.e. 'HighlightedResults.html'
            index.HighlightInText(Utilities.highlightedTextFilePath, results[0]);
            //ExEnd:ExactPhraseSearchWithHighlightedResults_17.12
        }

        /// <summary>
        /// Performs a case sensitive search
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void CaseSensitiveSearch(string caseSensitiveSearchQuery)
        {
            //ExStart:CaseSensitiveSearch
            IndexingSettings settings = new IndexingSettings();

            // Create or load index
            Index index = new Index(Utilities.indexPath, settings);

            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            parameters.UseCaseSensitiveSearch = true; // using case sensitive search feature

            SearchResults searchResults = index.Search(caseSensitiveSearchQuery, parameters);

            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", caseSensitiveSearchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:CaseSensitiveSearch
        }

        /// <summary>
        /// Performs search on numeric range
        /// This feature is supported in version 17.03 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void NumericRangeSearch(string searchQuery)
        {
            //ExStart:NumericRangeSearch
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            // Search for numbers
            SearchResults searchResults = index.Search(searchQuery);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:NumericRangeSearch
        }

        /// <summary>
        /// Shows how to use date range search
        /// This feature is supported by version 17.04 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void DateRangeSearch(string searchQuery)
        {
            //ExStart:DateRangeSearch
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            SearchResults searchResults = index.Search(searchQuery);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:DateRangeSearch
        }
        /// <summary>
        /// Shows how to use date range search in ISO 8601 format
        /// This feature is supported by version 18.1 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void DateRangeISO8601Search(string searchQuery)
        {
            //ExStart:DateRangeISO8601Search
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            SearchResults searchResults = index.Search(searchQuery);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:DateRangeISO8601Search
        }
        /// <summary>
        /// This method is implemented to make it possible to search phrase with wildcards.
        /// This feature is supported by version 18.1 or greater
        /// </summary>
    
        public static void WildCardSearch()
        {
            //ExStart:WildCardSearch
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            // Creating subquery of date range search
            SearchQuery subquery1 = SearchQuery.CreateDateRangeQuery(new DateTime(2011, 6, 17), new DateTime(2013, 1, 1));

            // Creating subquery of wildcard with number of missed words from 0 to 2
            SearchQuery subquery2 = SearchQuery.CreateWildcardQuery(0, 2);

            // Creating subquery of simple word
            SearchQuery subquery3 = SearchQuery.CreateWordQuery("birth");
            subquery3.SearchParameters = new SearchParameters();
            subquery3.SearchParameters.FuzzySearch.Enabled = true;
            subquery3.SearchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);

            // Combining subqueries into one query
            SearchQuery query = SearchQuery.CreatePhraseSearchQuery(subquery1, subquery2, subquery3);

            // Creating search parameters object with increased capacity of results
            SearchParameters searchParameters = new SearchParameters();
            searchParameters.MaxHitCountPerTerm = 1000000;
            searchParameters.MaxTotalHitCount = 10000000;

            // Searching
            SearchResults searchResults = index.Search(query, searchParameters);

            // The results may contain the following word sequences:
            // 03/29/2012 * * births
            // 29.07.2011 * birth
            // 2013-01-01 birth
            //ExEnd:WildCardSearch
        }

        /// <summary>
        /// Shows how to use date collection in range search
        /// This feature is supported by version 18.1 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void DateRangeCollectionSearch(string searchQuery)
        {
            //ExStart:DateRangeCollectionSearch
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;
            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            // Creating search parameters object
            SearchParameters searchParameters = new SearchParameters();

            // Deleting default formats
            searchParameters.DateFormats.Clear();

            // Adding format 'MM/dd/yyyy'
            DateFormatElement[] formatElements1 = new DateFormatElement[]
            {
                DateFormatElement.MonthTwoDigits,
                DateFormatElement.DateSeparator,
                DateFormatElement.DayOfMonthTwoDigits,
                DateFormatElement.DateSeparator,
                DateFormatElement.YearFourDigits,
            };
            DateFormat format1 = new DateFormat(formatElements1, "/");
            searchParameters.DateFormats.Add(format1);

            // Adding format 'dd.MM.yyyy'
            DateFormatElement[] formatElements2 = new DateFormatElement[]
            {
                DateFormatElement.DayOfMonthTwoDigits,
                DateFormatElement.DateSeparator,
                DateFormatElement.MonthTwoDigits,
                DateFormatElement.DateSeparator,
                DateFormatElement.YearFourDigits,
            };
            DateFormat format2 = new DateFormat(formatElements2, ".");
            searchParameters.DateFormats.Add(format2);

            // Searching
            SearchResults searchResults = index.Search(searchQuery, searchParameters);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:DateRangeCollectionSearch
        }
        /// <summary>
        /// Shows how to Perform date range search with faceted search
        /// This feature is supported by version 17.04 or greater
        /// </summary>
        public static void DateRangeWithFacetedSearch(string searchQuery)
        {
            //ExStart:DateRangeWithFacetedSearch
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            SearchResults searchResults = index.Search(searchQuery);
            if (searchResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in searchResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:DateRangeWithFacetedSearch
        }

        /// <summary>
        /// Shows how to implement own custom extractor for outlook document for the extension .ost and .pst files
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void OwnExtractorOst(string searchString)
        {
            //ExStart:OwnExtractorOst
            // Create or load index
            Index index = new Index(Utilities.indexPath);

            index.CustomExtractors.Add(new CustomOstPstExtractor()); // Adding new custom extractor for container document

            index.AddToIndex(Utilities.documentsPath); // Documents with "ost" and "pst" extension will be indexed using MyCustomContainerExtractor

            SearchResults searchResults = index.Search(searchString);
            //ExEnd:OwnExtractorOst
        }

        /// <summary>
        /// Shows how to implement own custom extractor for outlook document for the extension .ost and .pst files
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void DetailedResults(string searchString)
        {
            //ExStart:DetailedResultsPropertyInDocuments
            // Create or load index
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            SearchResults results = index.Search(searchString);

            foreach (DocumentResultInfo resultInfo in results)
            {
                if (resultInfo.DocumentType == DocumentType.OutlookEmailMessage)
                {
                    // for email message result info user should cast resultInfo as OutlookEmailMessageResultInfo for acessing EntryIdString property
                    OutlookEmailMessageResultInfo emailResultInfo = resultInfo as OutlookEmailMessageResultInfo;

                    Console.WriteLine("Query \"{0}\" has {1} hit count in message {2} in file {3}", searchString, emailResultInfo.HitCount, emailResultInfo.EntryIdString, emailResultInfo.FileName);
                }
                else
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file {2}", searchString, resultInfo.HitCount, resultInfo.FileName);
                }

                foreach (DetailedResultInfo detailedResult in resultInfo.DetailedResults)
                {
                    Console.WriteLine("{0}In field \"{1}\" there was found {2} hit count", "\t", detailedResult.FieldName, detailedResult.HitCount);
                }
            }
            //ExEnd:DetailedResultsPropertyInDocuments
        }
        /// <summary>
        /// Gives warnings if try to run Search with options that are not supported in index
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void NotSupportedOptionWarning(string searchString)
        {
            //ExStart:NotSupportedOptionWarning
            //create index
            Index index = new Index(Utilities.indexPath);
            // index.IndexingSettings.QuickIndexing = true;
            index.ErrorHappened += index_ErrorHappened;
            // QuickIndex ad = new QuickIndex();
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters fuzzySearchParameters = new SearchParameters();
            fuzzySearchParameters.FuzzySearch.Enabled = true;

            // Run fuzzy search
            SearchResults results = index.Search(searchString, fuzzySearchParameters);

            // Run regex search
            string regexString = @"dropbox ^[A-Z0-9._%+\-|A-Z0-9._%+-]+@++[A-Z0-9.\-|A-Z0-9.-]+\.[A-Z|A-Z]{2,}$ folder";
            SearchResults results1 = index.Search(regexString);

            SearchParameters synonymSearchParameters = new SearchParameters();
            synonymSearchParameters.UseSynonymSearch = true;

            // Run synonym search without loaded synonyms
            SearchResults results2 = index.Search(searchString, synonymSearchParameters);
            //ExEnd:NotSupportedOptionWarning

        }

        //ExStart:index_ErrorHappened
        /// <summary>
        /// Event Handler for search options not supported in index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void index_ErrorHappened(object sender, Search.Events.BaseIndexEventArgs e)
        {
            // e.Message contains corresponding message 
            //if search option is not supported
            //string notificationMessage = e.Message;
            Console.WriteLine(e.Message);
        }
        //ExEnd:index_ErrorHappened
        /// <summary>
        /// Gets total hits count
        /// </summary>
        /// <param name="searchString">string to search</param> 
        public static void GetTotalHitCount(string searchString)
        {

            //ExStart:GetTotalHitCount
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            SearchResults results = index.Search(searchString);
            Console.WriteLine("Searching with query \"{0}\" returns {1} documents with {2} total hit count", searchString, results.Count, results.TotalHitCount);
            //ExEnd:GetTotalHitCount
        }

        public void OpenFoundMessageUsingAsposeEmail(string searchString)
        {
            string myPstFile = Utilities.pathToPstFile;
            // Indexing MS Outlook storage with email messages
            Index index = new Index(Utilities.indexPath);
            index.OperationFinished += Utilities.index_OperationFinished;
            index.AddToIndex(myPstFile);

            // Searching in index
            SearchResults results = index.Search(searchString);

            // User gets all messages that qualify to search query using Aspose.Email API
            MessageInfoCollection messages = new MessageInfoCollection();
            foreach (DocumentResultInfo searchResult in results)
            {
                if (searchResult.DocumentType == DocumentType.OutlookEmailMessage)
                {
                    OutlookEmailMessageResultInfo emailResultInfo = searchResult as OutlookEmailMessageResultInfo;
                    MessageInfo message = GetEmailMessagesById(Utilities.pathToPstFile, emailResultInfo.EntryIdString);
                    if (message != null)
                    {
                        messages.Add(message);
                    }
                }
            }
        }

        private MessageInfo GetEmailMessagesById(string fileName, string fieldId)
        {
            PersonalStorage pst = PersonalStorage.FromFile(fileName, false);
            return GetEmailMessagesById(pst.RootFolder, fieldId);
        }

        private MessageInfo GetEmailMessagesById(FolderInfo folderInfo, string fieldId)
        {
            MessageInfo result = null;
            MessageInfoCollection messageInfoCollection = folderInfo.GetContents();
            foreach (MessageInfo messageInfo in messageInfoCollection)
            {
                if (messageInfo.EntryIdString == fieldId)
                {
                    result = messageInfo;
                    break;
                }
            }

            if (result == null && folderInfo.HasSubFolders)
            {
                foreach (FolderInfo subfolderInfo in folderInfo.GetSubFolders())
                {
                    result = GetEmailMessagesById(subfolderInfo, fieldId);
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Managing synonyms functionality
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void ManageSynonyms(string searchQuery)
        {
            //ExStart:ManageSynonyms
            //create or load index
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            // Clearing synonym dictionary
            index.Dictionaries.SynonymDictionary.Clear();

            // Adding synonyms
            string[] synonymGroup1 = new string[] { "big", "huge", "colossal", "massive" };
            string[] synonymGroup2 = new string[] { "fast", "agile", "quick", "rapid", "swift" };
            List<string[]> synonymGroups = new List<string[]>();
            synonymGroups.Add(synonymGroup1);
            synonymGroups.Add(synonymGroup2);
            index.Dictionaries.SynonymDictionary.AddRange(synonymGroups);

            index.Dictionaries.SynonymDictionary.Import(Utilities.synonymFilePath); // Import synonyms from file. Existing synonyms are staying.
            index.Dictionaries.SynonymDictionary.Export(Utilities.mySynonymFilePath); // Export synonyms to file

            SearchParameters parameters = new SearchParameters();
            parameters.UseSynonymSearch = true; // Turning on synonym search

            SearchResults results = index.Search(searchQuery, parameters); // Enable synonym search in parameters
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }

            //ExEnd:ManageSynonyms
        }

        #region Stop Words Functionality
        //This feature is introduced in v16.12
        /// <summary>
        /// Manage Stop Word dictionary
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void ManageStopWords(string searchQuery)
        {
            //ExStart:ManageStopWords
            //create or load index
            Index index = new Index(Utilities.indexPath);
            int stopWordsCount = index.Dictionaries.StopWordDictionary.Count; //  Get count of stop words
            index.Dictionaries.StopWordDictionary.Clear(); // Clear dictionary of stop words
            index.Dictionaries.StopWordDictionary.AddRange(new List<string>() { "one", "Two", "three" }); // Add several stop words to dictionary. Words are case insensitive.
            index.Dictionaries.StopWordDictionary.RemoveRange(new List<string>() { "one", "three" }); //  Remove stop words from dictionary. Words which are absent will be ignored.

            index.AddToIndex(Utilities.documentsPath);

            bool isTwoPresent = index.Dictionaries.StopWordDictionary.Contains("two");

            index.Dictionaries.StopWordDictionary.Import(Utilities.stopWordsFilePath); // Import stop words from file. Existing stop words are staying.
            index.Dictionaries.StopWordDictionary.Export(Utilities.exportedStopWordsFilePath); // Export stop words to file

            SearchResults results = index.Search(searchQuery);
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }

            //ExEnd:ManageStopWords
        }

        /// <summary>
        /// Disable using Stop Words
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void DisableStopWords(string searchQuery)
        {
            //ExStart:DisableStopWords
            //create or load index
            Index index = new Index(Utilities.indexPath);

            index.IndexingSettings.UseStopWords = false; // This line disables using stop words and all of the words in documents will be indexed

            index.AddToIndex(Utilities.documentsPath);
            SearchResults results = index.Search(searchQuery);
            //ExEnd:DisableStopWords
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }

        }
        #endregion

        #region Searching Password Protected Documents Functionality
        /// <summary>
        /// Uses event to set password for protected document using event argument
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void SearchingPasswordProtectedDocsUsingEvent(string searchQuery)
        {
            //ExStart:SetPasswordUsingEventArg
            Index index = new Index(Utilities.indexPath);
            index.PasswordRequired += index_PasswordRequired; // User can subscribe to PasswordRequired event to be able to specify a password
            index.AddToIndex(Utilities.documentsPath);
            SearchResults results = index.Search(searchQuery);
            //ExEnd:SetPasswordUsingEventArg
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }


        /// <summary>
        /// Sets password for protected document using Index.Dictionaries.DocumentPasswords property
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void SearchingPasswordProtectedDocsUsingProperty(string searchQuery)
        {
            //ExStart:SetPasswordUsingProperty
            Index index = new Index(Utilities.indexPath);
            index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile, "test"); // User can set passwords for some documents in this property
            index.AddToIndex(Utilities.documentsPath);
            SearchResults results = index.Search(searchQuery);
            //ExEnd:SetPasswordUsingProperty
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }



        /// <summary>
        /// Dealing with password protected documents, using both methods
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void SearchingPasswordProtectedDocs(string searchQuery)
        {
            //ExStart:SetPassword
            Index index = new Index(Utilities.indexPath);
            // User can subscribe to PasswordRequired event to be able to specify a password
            index.PasswordRequired += index_PasswordRequired;
            // User can set passwords for some documents in this property
            index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile, "test");
            index.AddToIndex(Utilities.documentsPath);
            SearchResults results = index.Search(searchQuery);
            //ExEnd:SetPassword
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        // This event will appear for every password protected document
        //ExStart:EventForPasswordRequired
        public static void index_PasswordRequired(object sender, PasswordRequiredEventArgs e)
        {
            if (e.DocumentFullName == Utilities.pathToPasswordProtectedFile)
            {
                // User should put password to Password field of event argument
                e.Password = "test";
            }
            else if (e.DocumentFullName == Utilities.pathToPasswordProtectedFile3)
            {
                // User should put password to Password field of event argument
                e.Password = "password2";
            }
        }
        //ExEnd:EventForPasswordRequired

        /// <summary>
        /// Allows to use privileges of IEnumerable for Password dictionary.
        /// This enhancement is introduced in v17.02
        /// </summary>
        public static void InheritPasswordDictionary()
        {
            //ExStart:InheritPasswordDictionary
            Index index = new Index(Utilities.indexPath);
            index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile, "test");
            index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile2, "password1");
            index.Dictionaries.DocumentPasswords.Add(Utilities.pathToPasswordProtectedFile3, "password2");

            foreach (string documentName in index.Dictionaries.DocumentPasswords)
            {
                string password = index.Dictionaries.DocumentPasswords[documentName];
            }
            //ExEnd:InheritPasswordDictionary

            //adding all these documents to index after password has been set
            index.AddToIndex(Utilities.documentsPath);
            string searchQuery = "content";
            SearchResults results = index.Search(searchQuery);
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }
        #endregion

        #region Spelling Corrector Functionality
        //This spelling correction feature is introduced in v17.01
        /// <summary>
        /// Dealing with password protected documents, using both methods
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void SpellingCorrectorUsage(string searchQuery)
        {
            //ExStart:SpellingCorrectorUsage
            //create or load index
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            // Enabling spelling corrector
            parameters.SpellingCorrector.Enabled = true;
            // The default value for maximum mistake count is 2
            parameters.SpellingCorrector.MaxMistakeCount = 1;

            // Search for misspelled term 'structure'
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:SpellingCorrectorUsage
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        /// <summary>
        /// shows how to manage spelling corrector
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void SpellingCorrectorManagement(string searchQuery)
        {
            //ExStart:SpellingCorrectorManagement
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Remove all words from spelling corrector dictionary
            index.Dictionaries.SpellingCorrector.Clear();
            // Import spelling dictionary from file. Existing words are staying.
            index.Dictionaries.SpellingCorrector.Import(Utilities.spellingDictionaryFilePath);
            string[] words = new string[] { "structure", "building", "rail", "house" };
            // Add word array to the dictionary. Words are case insensitive.
            index.Dictionaries.SpellingCorrector.AddRange(words);
            // Export spelling dictionary to file.
            index.Dictionaries.SpellingCorrector.Export(Utilities.exportedSpellingDictionaryFilePath);

            SearchParameters parameters = new SearchParameters();
            // Enabling spelling corrector
            parameters.SpellingCorrector.Enabled = true;
            // The default value for maximum mistake count is 2
            parameters.SpellingCorrector.MaxMistakeCount = 1;

            // Search for misspelled term 'structure'
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:SpellingCorrectorManagement
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        /// <summary>
        /// Shows how to get only best results in a spelling corrector search
        /// Feature is supported in version 17.8.0 of the API
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void SpellingCorrectorBestResults(string searchQuery)
        {
            //ExStart:SpellingCorrectorBestResults
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            SearchParameters searchParameters = new SearchParameters();
            // Enabling spelling correction
            searchParameters.SpellingCorrector.Enabled = true;
            // Setting maximum mistake count to 5
            searchParameters.SpellingCorrector.MaxMistakeCount = 5;
            // Enabling OnlyBestResults option
            searchParameters.SpellingCorrector.OnlyBestResults = true;

            // Searching
            SearchResults searchResults = index.Search(searchQuery, searchParameters);
            //ExEnd:SpellingCorrectorBestResults
        }

        /// <summary>
        /// Shows how to consider transposition in spelling corrector
        /// Feature is supported in version 17.9.0 of the API
        /// </summary>
        public static void SpellingCorrectorConsiderTranspositions(string searchQuery)
        {
            //ExStart:SpellingCorrectorConsiderTranspositions
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters searchParameters = new SearchParameters();
            // Enabling spelling corrector
            searchParameters.SpellingCorrector.Enabled = true;
            // Setting maximum mistake count to 1
            searchParameters.SpellingCorrector.MaxMistakeCount = 1;
            // Setting not to consider transposition as a single mistake
            searchParameters.SpellingCorrector.ConsiderTranspositions = false;

            // Searching for word 'Mail'
            SearchResults searchResults = index.Search(searchQuery, searchParameters);
            // There will be found word 'mails' - 1 mistake, but will not be found word 'Mali' - 2 mistakes.
            // Note that word 'mails' must be present both in the spelling corrector dictionary and in the index.
            //ExEnd:SpellingCorrectorConsiderTranspositions

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
        }

        /// <summary>
        /// Shows how to use OnlyBestResultsRange property
        /// Feature is supported by version 17.9.0 or greater
        /// </summary>
        public static void SpellingCorrectorBestResultsRange(string searchQuery)
        {
            //ExStart:SpellingCorrectorBestResultsRange
            // Creating index
            Index index = new Index(Utilities.indexPath);

            // Indexing
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters searchParameters = new SearchParameters();
            // Enabling spelling correction
            searchParameters.SpellingCorrector.Enabled = true;
            // Setting maximum mistake count to 10
            searchParameters.SpellingCorrector.MaxMistakeCount = 10;
            // Enabling OnlyBestResults option
            searchParameters.SpellingCorrector.OnlyBestResults = true;
            // Setting best results range to 2
            searchParameters.SpellingCorrector.OnlyBestResultsRange = 2;

            // Searching
            SearchResults searchResults = index.Search(searchQuery, searchParameters);
            // If there is no 'aaaaa' word in the spelling corrector dictionary then
            // there will be found 'aaaax' - 1 mistake, 'aaaxx' - 2 mistakes, 'aaxxx' - 3 mistakes
            // if this last three words are presented both in the spelling corrector dictionary and in the index
            //ExEnd:SpellingCorrectorBestResultsRange

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
        }

        #endregion

        #region  Alias Dictionary functionality
        //This alias dictionary feature is introduced in v17.01
        /// <summary>
        /// Adds an alias to the dictionary before search
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void AddingAliasToDictionaryBeforeSearch(string searchQuery)
        {
            //ExStart:AddingAliasToDictionaryBeforeSearch
            //Create or load index
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Add alias 's' to the dictionary
            index.Dictionaries.AliasDictionary.Add("s", "structure");
            // Search for term 'structure'
            SearchResults results = index.Search(searchQuery);
            //ExEnd:AddingAliasToDictionaryBeforeSearch
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        /// <summary>
        /// Dealing with password protected documents, using both methods
        /// </summary>
        /// <param name="searchQuery">string to search</param> 
        public static void UseAliasDictionary(string searchQuery)
        {
            //ExStart:AliasDictionaryUsage
            //Create or load Index
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Clear dictionary of aliases
            index.Dictionaries.AliasDictionary.Clear();
            // Add alias 's' to the dictionary. Alias and aliased text are case insensitive.
            index.Dictionaries.AliasDictionary.Add("s", "structure");
            // Remove alias 'x' from the dictionary. Words which are absent will be ignored.
            index.Dictionaries.AliasDictionary.Remove("x");
            // Import aliases from file. Existing aliases are staying.
            index.Dictionaries.AliasDictionary.Import(Utilities.aliasFilePath);
            // Export aliases to file
            index.Dictionaries.AliasDictionary.Export(Utilities.exportedAliasFilePath);

            // Search for term 'structure'
            SearchResults results = index.Search(searchQuery);
            //ExEnd:AliasDictionaryUsage
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }
        #endregion

        #region Homophone Dictionary Functionality
        //This homophone dictionary feature is introduced in v17.01

        /// <summary>
        /// shows how to use homophone search
        /// </summary>
        /// <param name="searchQuery">the term to be searched</param>
        public static void HomophoneSearchUsage(string searchQuery)
        {
            //ExStart:HomophoneSearchUsage
            //Create or load index
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            // Enable homophone search in parameters
            parameters.UseHomophoneSearch = true;

            // Search for "pause", "paws", "pores", "pours"
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:HomophoneSearchUsage
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }


        /// <summary>
        /// shows how to manage homophone dictionary
        /// </summary>
        /// <param name="searchQuery">The term to be searched</param>
        public static void HomophoneDictionaryManagement(string searchQuery)
        {
            //ExStart:HomophoneDictionaryManagement
            //Create or load index
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            // Clearing homophone dictionary
            index.Dictionaries.HomophoneDictionary.Clear();

            // Adding homophones
            string[] homophoneGroup1 = new string[] { "braise", "brays", "braze" };
            string[] homophoneGroup2 = new string[] { "pause", "paws", "pores", "pours" };
            List<string[]> homophoneGroups = new List<string[]>();
            homophoneGroups.Add(homophoneGroup1);
            homophoneGroups.Add(homophoneGroup2);
            index.Dictionaries.HomophoneDictionary.AddRange(homophoneGroups);

            // Import homophones from file. Existing homophones are staying.
            index.Dictionaries.HomophoneDictionary.Import(Utilities.homophonesFilePath);
            // Export homophones to file
            index.Dictionaries.HomophoneDictionary.Export(Utilities.exportedHomophonesFilePath);

            SearchParameters parameters = new SearchParameters();
            // Enable homophone search in parameters
            parameters.UseHomophoneSearch = true;

            // Search for "pause", "paws", "pores", "pours"
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:HomophoneDictionaryManagement
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        #endregion

        #region Letters Dictionary Functionality
        /// <summary>
        /// shows how to manage dictionary of letters
        /// Feature is supported in version 17.06 or greater
        /// </summary>
        public static void AddLetterstoDictionary(string searchQuery)
        {
            //ExStart:AddLetterstoDictionary
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;
            string alphabetFileName = Utilities.alphabetFilePath;

            Index index = new Index(indexFolder);

            // Clearing dictionary of letters
            index.Dictionaries.Alphabet.Clear();

            // Adding letters
            char[] letters = new char[] { '\u0141', '\u0142', '\u0143', '\u0144' };
            index.Dictionaries.Alphabet.AddRange(letters);

            // Import alphabet from file. Existing letters are staying.
            index.Dictionaries.Alphabet.Import(alphabetFileName);
            // Export alphabet to file
            index.Dictionaries.Alphabet.Export(Utilities.exportedAlphabetFilePath);

            // Indexing
            index.AddToIndex(documentsFolder);
            //ExEnd:AddLetterstoDictionary
        }

        #endregion

        #region Keyboard Layout Corrector Functionality
        //This enhancement is introduced in v17.02
        /// <summary>
        /// Shows how to use keyboard layout corrector
        /// </summary>
        /// <param name="searchQuery">The term to be searched</param>
        public static void KeyboardLayoutCorrectorUsage(string searchQuery)
        {
            //ExStart:KeyboardLayoutCorrectorUsage
            //Create or load index
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            // Enable keyboard layout correction in parameters
            parameters.KeyboardLayoutCorrector.Enabled = true;

            // Search for "pause", using "зфгыу", its equilient in Russian keyboard layout as search query 
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:KeyboardLayoutCorrectorUsage

            //display results
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        #endregion

        #region Use all search features
        //This enhancement is introduced in v17.02
        /// <summary>
        /// Shows how to enable multiple search features in a single search operation
        /// </summary>
        /// <param name="searchQuery">The term to be searched</param>
        public static void UsingAllSearchFeatures(string searchQuery)
        {
            //ExStart:UsingAllSearchFeatures
            //Create or load index
            Index index = new Index(Utilities.indexPath);
            //Add documents to index
            index.AddToIndex(Utilities.documentsPath);
            // Adding alias to dictionary
            index.Dictionaries.AliasDictionary.Add("alias", "alias subquery");
            // Adding homophones to dictionary
            index.Dictionaries.HomophoneDictionary.AddRange(new List<string[]> { new string[] { "cell", "sell" } });
            // Adding synonyms to dictionary
            index.Dictionaries.SynonymDictionary.AddRange(new List<string[]> { new string[] { "little", "small" } });

            SearchParameters searchParams = new SearchParameters();
            // Turning on layout corrector
            searchParams.KeyboardLayoutCorrector.Enabled = true;
            // Turning on spelling corrector
            searchParams.SpellingCorrector.Enabled = true;
            searchParams.SpellingCorrector.MaxMistakeCount = 1;
            // Turning on synonym search feature
            searchParams.UseSynonymSearch = true;
            // Turning on homophone search feature
            searchParams.UseHomophoneSearch = true;
            // Turning on fuzzy search feature
            searchParams.FuzzySearch.Enabled = true;
            // Turning on fuzzy search feature
            searchParams.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.9);

            // Run searching with all search features
            SearchResults results = index.Search(searchQuery, searchParams);
            //ExEnd:UsingAllSearchFeatures

            //display results
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        #endregion

        #region Implement Functions Showing Relation Between Max Mistake Count and Word Length for Fuzzy Search
        /// <summary>
        /// Shows how to use max mistake count function as fuzzy algorithm
        /// feature is supported in version 17.03 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void UseMaxMistakeCountFuncAsFuzzyAlgorithm(string searchQuery)
        {
            //ExStart:UseMaxMistakeCountFuncAsFuzzyAlgorithm
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            SearchParameters parameters = new SearchParameters();
            // Turning on fuzzy search feature
            parameters.FuzzySearch.Enabled = true;
            // Setting up fuzzy algorithm
            parameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3, new int[] { 0, 1, 1, 2 });
            // This function returns 0 when input value is 3 or less,
            // returns 1 when input value is 4 or 5,
            // and returns 2 when input value is 6 or greater.

            // Search for the query with a maximum of 2 mistakes
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:UseMaxMistakeCountFuncAsFuzzyAlgorithm

            //display results
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        /// <summary>
        /// Shows how to use constant value of max mistake count for each term in query regardless of its length
        /// feature is supported in version 17.03 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void UseConstMaxMistakeCount(string searchQuery)
        {
            //ExStart:UseConstMaxMistakeCount
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            SearchParameters parameters = new SearchParameters();
            // Turning on fuzzy search feature
            parameters.FuzzySearch.Enabled = true;
            // This function returns 2 for terms of any length
            parameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(0, new int[] { 2 });

            // Search for "discree" with a maximum of 2 mistakes
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:UseConstMaxMistakeCount

            //display results
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

        /// <summary>
        /// Shows how to use similarity level object as fuzzy algorithm
        /// feature is supported in version 17.03 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void UseSimilarityLevelObjAsFuzzyAlgo(string searchQuery)
        {
            //ExStart:UseSimilarityLevelObjAsFuzzyAlgo
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            SearchParameters parameters = new SearchParameters();
            // Turning on fuzzy search feature
            parameters.FuzzySearch.Enabled = true;
            // Setting up fuzzy algorithm
            parameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.7);

            // Search for "discree" with a maximum of 2 mistakes
            SearchResults results = index.Search(searchQuery, parameters);
            //ExEnd:UseSimilarityLevelObjAsFuzzyAlgo

            //display results
            if (results.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }
        #endregion

        /// <summary>
        /// Limits the number of search results
        /// feature is supported in version 17.03 or greater
        /// </summary>
        public static void LimitSearchResults(string searchQuery)
        {
            //ExStart:LimitSearchResults
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            SearchParameters parameters = new SearchParameters();
            // Setting the limitation of result count for each term in a query. The default value is 100000.
            parameters.MaxHitCountPerTerm = 200;
            // Setting the limitation of total result count for a query. The default value is 500000. 
            parameters.MaxTotalHitCount = 800;

            // Search for the query with limitation of 200 occurrences
            SearchResults results = index.Search(searchQuery, parameters);
            if (results.Truncated)
            {
                Console.WriteLine(results.Message);
            }
            //ExEnd:LimitSearchResults
        }

        /// <summary>
        /// Shows how to define table discrete function as step function
        /// Feature is supported in version 17.04 or greater
        /// </summary>
        public static void TableDiscreteFuncAsStepFunction()
        {
            //ExStart:TableDiscreteFuncAsStepFunction
            // Defining as table function 
            var table1 = new TableDiscreteFunction(3, new int[] { 0, 1, 1, 2, 3 });
            // Defining as step function 
            // Both of these functions return 0 when input value is 3 or less, return 1 when input value is 4 or 5, 
            // return 2 when input value is 6 and return 3 when input value is 7 or greater.
            var table2 = new TableDiscreteFunction(0, new Step(4, 1), new Step(6, 2), new Step(7, 3));
            //ExEnd:TableDiscreteFuncAsStepFunction
        }

        /// <summary>
        /// Shows how to use step function in fuzzy search
        /// Feature is supported in version 17.04 or greater
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void UseStepFunctionInFuzzySearch(string searchQuery)
        {
            //ExStart:UseStepFunctionInFuzzySearch
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);
            index.AddToIndex(documentsFolder);

            TableDiscreteFunction adaptiveDiscreteFunction = new TableDiscreteFunction(0, new Step(4, 1), new Step(5, 2), new Step(6, 3));
            // Function returns 0 mistakes for words of less than 4 characters, // 1 mistake for words of 4 characters, // 2 mistakes for words of 5 characters, // and 3 mistakes for words of 6 and more characters 
            SearchParameters adaptiveSearchParameters = new SearchParameters();
            adaptiveSearchParameters.FuzzySearch.Enabled = true;
            adaptiveSearchParameters.FuzzySearch.FuzzyAlgorithm = adaptiveDiscreteFunction;
            // Fuzzy search will allow 1 mistake for "user" word, 2 mistakes for "query" word and 3 mistakes for "search" word 
            SearchResults adaptiveResults = index.Search(searchQuery, adaptiveSearchParameters);

            //This line below shows how to define constant function
            //This function returns 2 for terms of any length
            TableDiscreteFunction constanDiscreteFunction = new TableDiscreteFunction(2);
            // Function returns 2 mistakes for word of any length
            SearchParameters constantSearchParameters = new SearchParameters();
            constantSearchParameters.FuzzySearch.Enabled = true;
            constantSearchParameters.FuzzySearch.FuzzyAlgorithm = constanDiscreteFunction;
            // Fuzzy search will allow 2 mistakes for all three words in query
            SearchResults constantResults = index.Search("user search query", constantSearchParameters);

            //display results
            if (constantResults.Count > 0)
            {
                // List of found files
                foreach (DocumentResultInfo documentResultInfo in constantResults)
                {
                    Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", searchQuery, documentResultInfo.HitCount, documentResultInfo.FileName);
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
            //ExEnd:UseStepFunctionInFuzzySearch
        }

        /// <summary>
        /// shows how to get search report
        /// Feature is supported in version 17.7 or greater
        /// </summary>
        public static void GetSearchReport()
        {
            //ExStart:GetSearchReport

            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);
            string query1 = "sample";
            SearchParameters param1 = new SearchParameters();
            string query2 = "pause";
            SearchParameters param2 = new SearchParameters();
            param2.UseHomophoneSearch = true;
            string query3 = "Sample";
            SearchParameters param3 = new SearchParameters();
            param3.UseCaseSensitiveSearch = true;
            SearchResults results1 = index.Search(query1, param1);
            SearchResults results2 = index.Search(query2, param2);
            SearchResults results3 = index.Search(query3, param3);

            // Get searching report
            SearchingReport[] report = index.GetSearchingReport();

            foreach (SearchingReport record in report)
            {
                Console.WriteLine("Searching takes {0}, {1} results was found.", record.SearchingTime, record.ResultCount);
            }
            //ExEnd:GetSearchReport
        }

        /// <summary>
        /// Shows how to limit searc report
        /// Feature is supported in version 17.8.0 of the API
        /// </summary>
        public static void LimitSearchReport()
        {
            //ExStart:LimitSearchReport
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            Index index = new Index(indexFolder);

            // Setting the maximum count of search reports
            index.IndexingSettings.MaxSearchingReportCount = 3;

            // Indexing
            index.AddToIndex(documentsFolder);

            // Running 100 of searches
            for (int i = 0; i < 100; i++)
            {
                index.Search("Query");
            }

            // Getting search report. Array contains only 3 last records.
            SearchingReport[] report = index.GetSearchingReport();

            // This code writes to console information about 3 last searches only
            foreach (SearchingReport record in report)
            {
                Console.WriteLine("Searching takes {0}, {1} results was found.", record.SearchingTime, record.ResultCount);
            }
            //ExEnd:LimitSearchReport
        }

        /// <summary>
        /// Shows how to generate highlighted text search results
        /// Feature is supported by version 17.8.0 of the API
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void GenerateHighlightedTextSearchResults(string searchQuery)
        {
            //ExStart:GenerateHighlightedTextSearchResults
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            // Searching
            SearchResults results = index.Search(searchQuery);

            // Generating HTML-formatted text for the first document in search results
            string text = index.HighlightInText(results[0]);
            //ExEnd:GenerateHighlightedTextSearchResults
        }


        /// <summary>
        /// Shows how to generate highlighted text search results directly to a file
        /// Feature is supported by version 17.8.0 of the API
        /// </summary>
        /// <param name="searchQuery"></param>
        public static void GenerateHighlightedTextResultsToFile(string searchQuery)
        {
            //ExStart:GenerateHighlightedTextResultsFile
            string indexFolder = Utilities.indexPath;
            string documentsFolder = Utilities.documentsPath;

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.AddToIndex(documentsFolder);

            // Searching
            SearchResults results = index.Search(searchQuery);

            // Generating HTML-formatted text for the first document directly to the file 'HighlightedResults.html'
            index.HighlightInText(Utilities.highlightedTextFilePath, results[0]);
            //ExEnd:GenerateHighlightedTextResultsFile
        }

        /// <summary>
        /// Feature is supported in cversion 17.9.0 or greater
        /// </summary>
        public static void UsePublicConstantsAsFieldNames(string searchQuery)
        {
            //ExStart:UsePublicConstantsAsFieldNames
            string searchQuery2 = "test";
            // creating index.
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            // searching using public constants as field names.
            SearchResults results1 = index.Search(string.Format("{0}:{1}", FieldNames.Content, searchQuery));
            SearchResults results2 = index.Search(string.Format("{0}:{1}", ExcelFieldNames.Subject, searchQuery2));
            //ExEnd:UsePublicConstantsAsFieldNames
        }
    }

}
