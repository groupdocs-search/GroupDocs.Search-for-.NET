using Newtonsoft.Json;

namespace GroupDocs.Search.WebForms.Products.Search.Entity.Web.Response
{
    public class SummarySearchResult
    {
        [JsonProperty]
        private int totalOccurences { get; set; }

        [JsonProperty]
        private int totalFiles { get; set; }

        [JsonProperty]
        private int indexedFiles { get; set; }

        [JsonProperty]
        private SearchDocumentResult[] foundFiles { get; set; }

        [JsonProperty]
        private string searchDuration { get; set; }

        public void SetTotalOccurences(int totalOccurences)
        {
            this.totalOccurences = totalOccurences;
        }

        public void SetTotalFiles(int totalFiles)
        {
            this.totalFiles = totalFiles;
        }

        public void SetIndexedFiles(int indexedFiles)
        {
            this.indexedFiles = indexedFiles;
        }

        public void SetFoundFiles(SearchDocumentResult[] foundFiles)
        {
            this.foundFiles = foundFiles;
        }

        public void SetSearchDuration(string searchDuration)
        {
            this.searchDuration = searchDuration;
        }
    }
}