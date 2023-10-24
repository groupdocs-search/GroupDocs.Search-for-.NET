namespace GroupDocs.Search.WebForms.Products.Common.Config
{
    /// <summary>
    /// Server configuration
    /// </summary>
    public class ServerConfiguration
    {
        public int HttpPort { get; set; }

        public string HostAddress { get; set; }

        /// <summary>
        /// Get server configuration section of the web.config
        /// </summary>
        public ServerConfiguration()
        {
            HttpPort = 8080;
            HostAddress = "localhost";
        }
    }
}