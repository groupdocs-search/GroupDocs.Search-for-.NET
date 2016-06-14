namespace UserInterfaceExample.Models
{
    public class ViewDocumentResponse
    {
        public string documentDescription;
        public string docType;
        public string fileType;
        public string[] pageHtml;
        public string[] pageCss { get; set; }
        public bool lic { get; set; }
        public string url { get; set; }
        public string path { get; set; }
        public string name { get; set; }
    }
}