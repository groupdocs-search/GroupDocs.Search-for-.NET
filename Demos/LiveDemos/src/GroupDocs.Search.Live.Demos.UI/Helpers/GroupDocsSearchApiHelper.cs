using GroupDocs.Search.Live.Demos.UI.Models;
using GroupDocs.Search.Live.Demos.UI.Config;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace GroupDocs.Search.Live.Demos.UI.Helpers
{
	public class GroupDocsSearchApiHelper : ApiHelperBase
	{
		private static Response CallGroupDocsSearchAppAPI( string apiName,  string documentsFolder,  Dictionary<string, string> apiParams)
		{
			Response convertResponse = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestURI = Configuration.GroupDocsAppsAPIBasePath + "api/" + "GroupDocsSearch" + "/" + apiName + "?documentsFolder=" + documentsFolder ;

				foreach (var paramValuePair in apiParams)
				{
					requestURI = requestURI + "&" + paramValuePair.Key + "=" + paramValuePair.Value;
				}
				System.Threading.Tasks.Task taskUpload = client.GetAsync(requestURI).ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						HttpResponseMessage response = task.Result;
						if (response.IsSuccessStatusCode)
						{
							convertResponse = response.Content.ReadAsAsync<Response>().Result;
						}
					}
				});
				taskUpload.Wait();
			}

			return convertResponse;
		}

		public static Response Search(string documentsFolder, string featureName,  Dictionary<string, string> apiParams)
		{
			BasePage _basePage = new BasePage();
			if (featureName == _basePage.Resources["SimpleSearch"]) 
			{
				return CallGroupDocsSearchAppAPI("SimpleSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["BooleanSearch"]) 
			{
				return CallGroupDocsSearchAppAPI("BooleanSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["RegexSearch"])
			{
				return CallGroupDocsSearchAppAPI("RegexSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["FuzzySearch"])
			{
				return CallGroupDocsSearchAppAPI("FuzzySearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["CaseSensitiveSearch"]) 
			{
				return CallGroupDocsSearchAppAPI("CaseSensitiveSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["FacetedSearch"]) 
			{
				return CallGroupDocsSearchAppAPI("FacetedSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["NumericRangeSearch"]) 
			{
				return CallGroupDocsSearchAppAPI("NumericRangeSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["ExactPhraseSearch"])
			{
				return CallGroupDocsSearchAppAPI("ExactPhraseSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["BlendedCharactersSearch"])
			{
				return CallGroupDocsSearchAppAPI("BlendedCharactersSearch", documentsFolder, apiParams);
			}
			else if (featureName == _basePage.Resources["WildcardSearch"])
			{
				return CallGroupDocsSearchAppAPI("WildcardSearch", documentsFolder, apiParams);
			}			
			else
			{
				return new Response
				{
					FileName = null,
					Status = "Search Type not found",
					StatusCode = 500
				};
			}
		}





	}
}