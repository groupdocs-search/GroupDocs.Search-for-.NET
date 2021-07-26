using GroupDocs.Search.Common;
using GroupDocs.Search.Highlighters;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using GroupDocs.Search.WebForms.Products.Common.Config;
using GroupDocs.Search.WebForms.Products.Common.Entity.Web;
using GroupDocs.Search.WebForms.Products.Search.Entity.Web.Request;
using GroupDocs.Search.WebForms.Products.Search.Entity.Web.Response;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroupDocs.Search.WebForms.Products.Search.Service
{
    public static class SearchService
    {
        private static Index index;

        internal static Dictionary<string, string> FileIndexingStatusDict { get; } = new Dictionary<string, string>();
        internal static Dictionary<string, string> PassRequiredStatusDict { get; } = new Dictionary<string, string>();

        private static readonly List<char> specialCharsList = new List<char>();
        private static readonly List<char> foundSpecialChars = new List<char>();

        public static SummarySearchResult Search(SearchPostedData searchRequest, GlobalConfiguration globalConfiguration)
        {
            if (index == null)
            {
                return new SummarySearchResult();
            }

            SearchOptions searchOptions = new SearchOptions();
            // Turn on fuzzy search on
            searchOptions.UseCaseSensitiveSearch = false;

            var searchQuery = searchRequest.GetQuery();
            SearchResult result;

            foreach (char specialChar in specialCharsList)
            {
                if (searchQuery.Contains(specialChar))
                {
                    foundSpecialChars.Add(specialChar);
                }
            }

            if (searchQuery.Contains(" "))
            {
                result = index.Search("\"" + searchQuery + "\"", searchOptions);
            }
            else if (foundSpecialChars.Count > 0)
            {
                foreach(char specialChar in foundSpecialChars)
                {
                    searchQuery = searchQuery.Replace(specialChar, ' ');
                }

                foundSpecialChars.Clear();
                result = index.Search("\"" + searchQuery + "\"", searchOptions);
            }
            else if (Path.HasExtension(searchQuery))
            {
                searchQuery = searchQuery.Replace(".", " ");
                result = index.Search("\"" + searchQuery + "\"", searchOptions);
            }
            else
            {
                result = index.Search(searchQuery, searchOptions);
            }

            SummarySearchResult summaryResult = new SummarySearchResult();
            List<SearchDocumentResult> foundFiles = new List<SearchDocumentResult>();

            HighlightOptions options = new HighlightOptions
            {
                TermsBefore = 5,
                TermsAfter = 5,
                TermsTotal = 10
            };

            for (int i = 0; i < result.DocumentCount; i++)
            {
                SearchDocumentResult searchDocumentResult = new SearchDocumentResult();

                FoundDocument document = result.GetFoundDocument(i);
                HtmlFragmentHighlighter highlighter = new HtmlFragmentHighlighter();
                index.Highlight(document, highlighter, options);
                FragmentContainer[] fragmentContainers = highlighter.GetResult();

                List<string> foundPhrases = new List<string>();
                for (int j = 0; j < fragmentContainers.Length; j++)
                {
                    FragmentContainer container = fragmentContainers[j];
                    string[] fragments = container.GetFragments();
                    if (fragments.Length > 0)
                    {
                        for (int k = 0; k < fragments.Length; k++)
                        {
                            foundPhrases.Add(fragments[k].Replace("<br>", ""));
                        }
                    }
                }

                searchDocumentResult.SetGuid(document.DocumentInfo.FilePath);
                searchDocumentResult.SetName(Path.GetFileName(document.DocumentInfo.FilePath));
                searchDocumentResult.SetSize(new FileInfo(document.DocumentInfo.FilePath).Length);
                searchDocumentResult.SetOccurrences(document.OccurrenceCount);
                searchDocumentResult.SetFoundPhrases(foundPhrases.ToArray());

                foundFiles.Add(searchDocumentResult);
            }

            summaryResult.SetFoundFiles(foundFiles.ToArray());
            summaryResult.SetTotalOccurences(result.OccurrenceCount);
            summaryResult.SetTotalFiles(result.DocumentCount);
            string searchDurationString = result.SearchDuration.ToString(@"ss\.ff");
            summaryResult.SetSearchDuration(searchDurationString.Equals("00.00") ? "< 1" : searchDurationString);
            summaryResult.SetIndexedFiles(Directory.GetFiles(globalConfiguration.Search.GetIndexedFilesDirectory(), "*", SearchOption.TopDirectoryOnly).Length);

            return summaryResult;
        }

        internal static void InitIndex(GlobalConfiguration globalConfiguration)
        {
            if (index == null)
            {
                string indexedFilesDirectory = globalConfiguration.Search.GetIndexedFilesDirectory();
                index = new Index(globalConfiguration.Search.GetIndexDirectory(), true);

                index.Events.OperationProgressChanged += (sender, args) =>
                {
                    if (PassRequiredStatusDict.ContainsKey(args.LastDocumentPath) &&
                        args.LastDocumentStatus.ToString() == DocumentStatus.SuccessfullyProcessed.ToString())
                    {
                        PassRequiredStatusDict.Remove(args.LastDocumentPath);
                    }

                    if (FileIndexingStatusDict.ContainsKey(args.LastDocumentPath))
                    {
                        if (args.LastDocumentStatus.ToString() == DocumentStatus.ProcessedWithError.ToString() &&
                            PassRequiredStatusDict.ContainsKey(args.LastDocumentPath))
                        {
                            FileIndexingStatusDict[args.LastDocumentPath] = "PasswordRequired";
                        }
                        else
                        {
                            FileIndexingStatusDict[args.LastDocumentPath] = args.LastDocumentStatus.ToString();
                        }
                    }
                    else
                    {
                        if (args.LastDocumentStatus.ToString() == DocumentStatus.ProcessedWithError.ToString() &&
                            PassRequiredStatusDict.ContainsKey(args.LastDocumentPath))
                        {
                            FileIndexingStatusDict.Add(args.LastDocumentPath, "PasswordRequired");
                        }
                        else
                        {
                            FileIndexingStatusDict.Add(args.LastDocumentPath, args.LastDocumentStatus.ToString());
                        }
                    }
                };

                index.Events.PasswordRequired += (sender, args) =>
                {
                    if (PassRequiredStatusDict.ContainsKey(args.DocumentFullPath))
                    {
                        PassRequiredStatusDict[args.DocumentFullPath] = "PasswordRequired";
                    }
                    else
                    {
                        PassRequiredStatusDict.Add(args.DocumentFullPath, "PasswordRequired");
                    }
                };

                index.Add(indexedFilesDirectory);

                InitSpecailCharsList();
            }
        }

        private static void InitSpecailCharsList()
        {
            IEnumerator<char> ie = index.Dictionaries.Alphabet.GetEnumerator();
            while (ie.MoveNext())
            {
                char item = ie.Current;
                specialCharsList.Add(item);
            }
        }

        internal static void AddFilesToIndex(PostedDataEntity[] postedData, GlobalConfiguration globalConfiguration)
        {
            string indexedFilesDirectory = globalConfiguration.Search.GetIndexedFilesDirectory();

            foreach (var entity in postedData)
            {
                string fileName = Path.GetFileName(entity.guid);
                string destFileName = Path.Combine(indexedFilesDirectory, fileName);

                if (!File.Exists(destFileName))
                {
                    File.Copy(entity.guid, destFileName);
                }

                if (!string.IsNullOrEmpty(entity.password))
                {
                    if (!index.Dictionaries.DocumentPasswords.Contains(entity.guid))
                    {
                        index.Dictionaries.DocumentPasswords.Add(entity.guid, entity.password);
                    }
                    else 
                    {
                        index.Dictionaries.DocumentPasswords.Remove(entity.guid);
                        index.Dictionaries.DocumentPasswords.Add(entity.guid, entity.password);
                    }
                }
            }

            index.Update(GetUpdateOptions());
            index.Optimize();
        }

        internal static void RemoveFileFromIndex(string guid)
        {
            if (File.Exists(guid))
            {
                File.Delete(guid);

                if (FileIndexingStatusDict.ContainsKey(guid)) {
                    FileIndexingStatusDict.Remove(guid);
                }
            }

            index.Update(GetUpdateOptions());
            index.Optimize();
        }

        private static UpdateOptions GetUpdateOptions()
        {
            return new UpdateOptions
            {
                Threads = 2,
                IsAsync = true
            };
        }
    }
}