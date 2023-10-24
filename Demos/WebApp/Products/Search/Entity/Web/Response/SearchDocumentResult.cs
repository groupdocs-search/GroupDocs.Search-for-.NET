namespace GroupDocs.Search.WebForms.Products.Search.Entity.Web.Response
{
    public class SearchDocumentResult
    {
        public string guid { get; set; }

        public string name { get; set; }

        public long size { get; set; }

        public int occurrences { get; set; }

        public string[] foundPhrases { get; set; }
    }
}