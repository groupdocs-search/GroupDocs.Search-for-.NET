using GroupDocs.Search.WebForms.Products.Common.Entity.Web;
using Newtonsoft.Json;

namespace GroupDocs.Search.WebForms.Products.Search.Entity.Web.Request
{
    public class SearchPostedData : PostedDataEntity
    {
        [JsonProperty]
        private string query { get; set; }

        internal string GetQuery()
        {
            return this.query;
        }
    }
}