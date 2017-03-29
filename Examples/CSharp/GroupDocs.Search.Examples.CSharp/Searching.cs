using Aspose.Email.Outlook.Pst;
using GroupDocs.Search;
using GroupDocs.Search.Events;
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

        /// <summary>
        /// Creates index, 
        /// Adds documents to index 
        /// Enable fuzzy search
        /// Set similarity level from 0.0 to 1.0
        /// Do Fuzzy search
        /// </summary>
        /// <param name="searchString">Misspelled string</param>
        /// 
        public static void FuzzySearch(string searchString)
        {
            //ExStart:Fuzzysearch
            Index index = new Index(Utilities.indexPath);
            index.AddToIndex(Utilities.documentsPath);

            SearchParameters parameters = new SearchParameters();
            // turning on Fuzzy search feature
            parameters.FuzzySearch.Enabled = true;

            // set low similarity level to search for less similar words and get more results
            parameters.FuzzySearch.SimilarityLevel = 0.1;
            SearchResults lessSimilarResults = index.Search(searchString, parameters);
            Console.WriteLine("Results with less similarity level that is currently set to =" + parameters.FuzzySearch.SimilarityLevel);
            foreach (DocumentResultInfo lessSimilarResultsDoc in lessSimilarResults)
            {
                Console.WriteLine(lessSimilarResultsDoc.FileName + "\n");
            }

            // set high similarity level to search for more similar words and get less results
            parameters.FuzzySearch.SimilarityLevel = 0.9;
            SearchResults moreSimilarResults = index.Search(searchString, parameters);

            Console.WriteLine("Results with high similarity level that is currently set to =" + parameters.FuzzySearch.SimilarityLevel);
            foreach (DocumentResultInfo highSimilarityLevelDoc in moreSimilarResults)
            {
                Console.WriteLine(highSimilarityLevelDoc.FileName + "\n");
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
            parameters.FuzzySearch.SimilarityLevel = 0.2;

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
        /// Performs a case sensitive search
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static void CaseSensitiveSearch(string caseSensitiveSearchQuery)
        {
            //ExStart:CaseSensitiveSearch
            bool inMemoryIndex = false;
            bool caseSensitive = true;
            IndexingSettings settings = new IndexingSettings(inMemoryIndex, caseSensitive);

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
        static void index_ErrorHappened(object sender, Search.Events.BaseIndexArg e)
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
        public static void index_PasswordRequired(object sender, PasswordRequiredArg e)
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
            searchParams.FuzzySearch.SimilarityLevel = 0.9;

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

    }

}
