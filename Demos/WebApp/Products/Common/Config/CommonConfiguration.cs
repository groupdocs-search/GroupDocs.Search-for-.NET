using Newtonsoft.Json;

namespace GroupDocs.Search.WebForms.Products.Common.Config
{
    /// <summary>
    /// The common configuration.
    /// </summary>
    public class CommonConfiguration
    {
        [JsonProperty]
        public bool download { get; set; }

        [JsonProperty]
        public bool upload { get; set; }

        [JsonProperty]
        public bool browse { get; set; }

        [JsonProperty]
        public bool rewrite { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CommonConfiguration()
        {
            download = true;
            upload = true;
            browse = true;
            rewrite = true;
        }
    }
}
