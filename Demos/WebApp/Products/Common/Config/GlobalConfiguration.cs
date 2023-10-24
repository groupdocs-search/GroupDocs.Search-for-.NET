using GroupDocs.Search.WebForms.Products.Search.Config;

namespace GroupDocs.Search.WebForms.Products.Common.Config
{
    /// <summary>
    /// Global configuration
    /// </summary>
    public class GlobalConfiguration
    {
        public ServerConfiguration Server { get; set; }
        public ApplicationConfiguration Application { get; set; }
        public CommonConfiguration Common { get; set; }
        public SearchConfiguration Search { get; set; }

        /// <summary>
        /// Get all configurations
        /// </summary>
        public GlobalConfiguration()
        {
            Server = new ServerConfiguration();
            Application = new ApplicationConfiguration();
            Common = new CommonConfiguration();
            Search = new SearchConfiguration();
        }
    }
}