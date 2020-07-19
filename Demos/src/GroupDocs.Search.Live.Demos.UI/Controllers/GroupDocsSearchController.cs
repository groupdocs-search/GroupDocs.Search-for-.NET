using System.Web.Http;
using System.Threading.Tasks;
using GroupDocs.Search.Live.Demos.UI.Models;
using System;
using System.IO;
using System.Collections.ObjectModel;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using GroupDocs.Search.Dictionaries;

namespace GroupDocs.Search.Live.Demos.UI.Controllers
{
	public class GroupDocsSearchController : ApiControllerBase
	{
		private Response response;
		protected async Task<Response> ProcessSearch(string folderName, ActionDelegate action)
		{
			string controllerName = "GroupDocsSearchController";
			//GroupDocs.Search.Live.Demos.UI.Models.License.SetGroupDocsSearchLicense();

			string logMsg = "ControllerName: " + controllerName + " FolderName: " + folderName;
			string guid = Guid.NewGuid().ToString();
			string indexFolder = AppSettings.WorkingDirectory + guid;

			string statusValue = "OK";
			int statusCodeValue = 200;
			folderName = AppSettings.WorkingDirectory + folderName;

			try
			{
				if (!Directory.Exists(indexFolder))
				{
					Directory.CreateDirectory(indexFolder);
				}
				action(indexFolder, folderName, "");


				try
				{
					Directory.Delete(indexFolder, true);
				}
				catch
				{ }

			}
			catch (Exception ex)
			{
				statusCodeValue = 500;
				statusValue = "500 " + ex.Message;
			}
			return await Task.FromResult(new Response
			{
				Status = statusValue,
				StatusCode = statusCodeValue,
			});
		}

		[HttpGet]
		[ActionName("SimpleSearch")]
		public async Task<Response> SimpleSearch(string documentsFolder, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
		   {
               // Create index
               Search.Index index = new Search.Index(indexFolder);

			   // Add documents to index
			   index.Add(docsFolder);

			   // using case sensitive search feature
			   SearchOptions parameters = new SearchOptions();
			   parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

			   // Search in index
			   SearchResult searchResults = index.Search(searchString, parameters);

			   // List of found files
			   foreach (FoundDocument documentResultInfo in searchResults)
			   {

				   _results.Add(string.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", searchString, documentResultInfo.OccurrenceCount, Path.GetFileName(documentResultInfo.DocumentInfo.FilePath)));
			   }

		   });
			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("BooleanSearch")]
		public async Task<Response> BooleanSearch(string documentsFolder, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                // Create index
                Search.Index index = new Search.Index(indexFolder);

				// Add documents to index
				index.Add(docsFolder);

				// using case sensitive search feature
				SearchOptions parameters = new SearchOptions();
				parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				// Search in index
				SearchResult searchResults = index.Search(searchString, parameters);

				// List of found files
				foreach (FoundDocument documentResultInfo in searchResults)
				{
					_results.Add(string.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", searchString, documentResultInfo.OccurrenceCount, Path.GetFileName(documentResultInfo.DocumentInfo.FilePath)));
					//_results.Add( string.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", secondTerm, documentResultInfo.OccurrenceCount, Path.GetFileName( documentResultInfo.FileName)));
				}

			});
			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("RegexSearch")]
		public async Task<Response> RegexSearch(string documentsFolder, string relevantKey, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                // Create index
                Search.Index index = new Search.Index(indexFolder);

				// Add documents to index
				index.Add(docsFolder);

				// using case sensitive search feature
				SearchOptions parameters = new SearchOptions();
				parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				// Search for documents where at least one word contain given regex
				SearchResult searchResults1 = index.Search(relevantKey, parameters);

				//Search for documents where present term1 or any email adress or term2
				SearchResult searchResults2 = index.Search(searchString, parameters);

				if (searchResults1.DocumentCount > 0)
				{
					// List of found files 
					_results.Add("Follwoing document(s) contain provided relevant tag: <br/>");
					foreach (FoundDocument documentResultInfo in searchResults1)
					{
						_results.Add(Path.GetFileName(documentResultInfo.DocumentInfo.FilePath) + "<br/>");
					}
				}

				if (searchResults2.DocumentCount > 0)
				{
					// List of found files
					_results.Add("Follwoing document(s) contain provided RegEx: <br/>");
					foreach (FoundDocument documentResultInfo in searchResults2)
					{
						_results.Add(Path.GetFileName(documentResultInfo.DocumentInfo.FilePath) + "<br/>");
					}
				}
			});

			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("FuzzySearch")]
		public async Task<Response> FuzzySearch(string documentsFolder, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                Search.Index index = new Search.Index(indexFolder);

				index.Add(docsFolder);

				SearchOptions parameters = new SearchOptions();
				// Turning on Fuzzy search feature
				parameters.FuzzySearch.Enabled = true;

				parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				// Set low similarity level to search for less similar words and get more results
				// This method of setting similarity level has been marked obsolete from version 17.8.0 onwards
				// parameters.FuzzySearch.SimilarityLevel = 0.1;

				// From version 17.8 onwards,this is the way to set similarity level
				parameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.1);
				SearchResult lessSimilarResults = index.Search(searchString, parameters);

				if (lessSimilarResults.DocumentCount > 0)
				{
					_results.Add("Results with less similarity level that is currently set to =" + parameters.FuzzySearch.FuzzyAlgorithm + "<br/>");
					foreach (FoundDocument lessSimilarResultsDoc in lessSimilarResults)
					{
						_results.Add(Path.GetFileName(lessSimilarResultsDoc.DocumentInfo.FilePath) + "<br/>");
					}
				}

				// set high similarity level to search for more similar words and get less results
				parameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.1);
				SearchResult moreSimilarResults = index.Search(searchString, parameters);

				if (moreSimilarResults.DocumentCount > 0)
				{
					_results.Add("Results with high similarity level that is currently set to =" + parameters.FuzzySearch.FuzzyAlgorithm + "<br/>");
					foreach (FoundDocument highSimilarityLevelDoc in moreSimilarResults)
					{
						_results.Add(Path.GetFileName(highSimilarityLevelDoc.DocumentInfo.FilePath) + "<br/>");
						//_results.Add(highSimilarityLevelDoc.FileName + "<br/>");
					}
				}

			});
			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("FacetedSearch")]
		public async Task<Response> FacetedSearch(string documentsFolder, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                // Create index
                Search.Index index = new Search.Index(indexFolder);

				// Add documents to index
				index.Add(docsFolder);

				// using case sensitive search feature
				SearchOptions parameters = new SearchOptions();
				parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				// Searching for any document in index that contain word "return" in file content
				SearchResult searchResults = index.Search(searchString, parameters);


				// List of found files
				foreach (FoundDocument documentResultInfo in searchResults)
				{
					_results.Add(string.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", searchString, documentResultInfo.OccurrenceCount, Path.GetFileName(documentResultInfo.DocumentInfo.FilePath)));
				}

			});
			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("NumericRangeSearch")]
		public async Task<Response> NumericRangeSearch(string documentsFolder, string searchString)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                Search.Index index = new Search.Index(indexFolder);
				index.Add(docsFolder);

				// Using case sensitive search feature
				//SearchOptions  parameters = new SearchOptions ();
				//parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				// Search for numbers
				SearchResult searchResults = index.Search(searchString);
				if (searchResults.DocumentCount > 0)
				{
					// List of found files
					foreach (FoundDocument documentResultInfo in searchResults)
					{
						_results.Add(string.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", searchString, documentResultInfo.OccurrenceCount, Path.GetFileName(documentResultInfo.DocumentInfo.FilePath)));
					}
				}

			});
			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("ExactPhraseSearch")]
		public async Task<Response> ExactPhraseSearch(string documentsFolder, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                // Create or load index
                Search.Index index = new Search.Index(indexFolder, true);

				index.Add(docsFolder);

				// Using case sensitive search feature
				SearchOptions parameters = new SearchOptions();
				parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				SearchResult searchResults = index.Search(searchString, parameters);

				// List of found files
				foreach (FoundDocument documentResultInfo in searchResults)
				{
					_results.Add(String.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", searchString, documentResultInfo.OccurrenceCount, Path.GetFileName(documentResultInfo.DocumentInfo.FilePath)));
				}

			});
			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("BlendedCharactersSearch")]
		public async Task<Response> BlendedCharactersSearch(string documentsFolder, string blendedcharacter, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                // Creating index
                Search.Index index = new Search.Index(indexFolder);

				// Marking hyphen as blended character
				index.Dictionaries.Alphabet.SetRange(new char[] { char.Parse(blendedcharacter) }, CharacterType.Blended);

				// Adding documents to index
				index.Add(docsFolder);

				// Using case sensitive search feature
				SearchOptions parameters = new SearchOptions();
				parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				// Searching for word 
				SearchResult results = index.Search(searchString, parameters);

				// List of found files
				foreach (FoundDocument documentResultInfo in results)
				{
					_results.Add(string.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", searchString, documentResultInfo.OccurrenceCount, Path.GetFileName(documentResultInfo.DocumentInfo.FilePath)));
				}

			});
			response.Results = _results;
			return response;
		}
		[HttpGet]
		[ActionName("WildcardSearch")]
		public async Task<Response> WildcardSearch(string documentsFolder, string searchString, string caseSensitive)
		{
			Collection<string> _results = new Collection<string>();
			response = await ProcessSearch(documentsFolder, delegate (string indexFolder, string docsFolder, string zipOutFolder)
			{
                // Creating index
                Search.Index index = new Search.Index(indexFolder);

				// Adding documents to index
				index.Add(docsFolder);

				// Using case sensitive search feature
				SearchOptions parameters = new SearchOptions();
				parameters.UseCaseSensitiveSearch = Boolean.Parse(caseSensitive);

				// Searching for words 'affect' or 'effect' in a one document with 'principal', 'principle', 'principles', or 'principally'
				SearchResult results = index.Search(searchString, parameters);

				// List of found files
				foreach (FoundDocument documentResultInfo in results)
				{
					_results.Add(string.Format("Query \"{0}\" has {1} hit count in file: {2}<br/>", searchString, documentResultInfo.OccurrenceCount, Path.GetFileName(documentResultInfo.DocumentInfo.FilePath)));
				}

			});
			response.Results = _results;
			return response;
		}
	}
}
