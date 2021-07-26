using GroupDocs.Search.Results;
using Newtonsoft.Json;

namespace GroupDocs.Search.WebForms.Products.Search.Entity.Web.Response
{
    public class SearchDocumentResult
    {
        [JsonProperty]
        private string guid { get; set; }

        [JsonProperty]
        private string name { get; set; }

        [JsonProperty]
        private long size { get; set; }

        [JsonProperty]
        private int occurrences { get; set; }

        [JsonProperty]
        private string[] foundPhrases { get; set; }

        public void SetGuid(string guid)
        {
            this.guid = guid;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetSize(long size)
        {
            this.size = size;
        }

        public void SetOccurrences(int occurences)
        {
            this.occurrences = occurences;
        }

        public void SetFoundPhrases(string[] foundPhrases)
        {
            this.foundPhrases = foundPhrases;
        }
    }
}