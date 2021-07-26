using GroupDocs.Search.WebForms.Products.Common.Config;
using GroupDocs.Search.WebForms.Products.Common.Util.Parser;
using GroupDocs.Search.WebForms.Products.Search.Util.Directory;
using Newtonsoft.Json;
using System;
using System.IO;

namespace GroupDocs.Search.WebForms.Products.Search.Config
{
    /// <summary>
    /// SearchConfiguration
    /// </summary>
    public class SearchConfiguration : CommonConfiguration
    {
        [JsonProperty]
        private string filesDirectory = "DocumentSamples/Search";

        [JsonProperty]
        private string indexDirectory = "DocumentSamples/Search/Index";

        [JsonProperty]
        private string indexedFilesDirectory = "DocumentSamples/Search/Indexed";

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchConfiguration()
        {
            YamlParser parser = new YamlParser();
            // get Search configuration section from the web.config
            dynamic configuration = parser.GetConfiguration("search");
            ConfigurationValuesGetter valuesGetter = new ConfigurationValuesGetter(configuration);

            filesDirectory = valuesGetter.GetStringPropertyValue("filesDirectory", filesDirectory);
            if (!DirectoryUtils.IsFullPath(filesDirectory))
            {
                filesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filesDirectory);
                if (!Directory.Exists(filesDirectory))
                {
                    Directory.CreateDirectory(filesDirectory);
                }
            }

            indexDirectory = valuesGetter.GetStringPropertyValue("indexDirectory", indexDirectory);
            if (!DirectoryUtils.IsFullPath(indexDirectory))
            {
                indexDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, indexDirectory);
                if (!Directory.Exists(indexDirectory))
                {
                    Directory.CreateDirectory(indexDirectory);
                }
            }

            indexedFilesDirectory = valuesGetter.GetStringPropertyValue("indexedFilesDirectory", indexedFilesDirectory);
            if (!DirectoryUtils.IsFullPath(indexedFilesDirectory))
            {
                indexedFilesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, indexedFilesDirectory);
                if (!Directory.Exists(indexedFilesDirectory))
                {
                    Directory.CreateDirectory(indexedFilesDirectory);
                }
            }
        }

        public void SetFilesDirectory(string filesDirectory)
        {
            this.filesDirectory = filesDirectory;
        }

        public string GetFilesDirectory()
        {
            return filesDirectory;
        }

        public void SetIndexDirectory(string indexDirectory)
        {
            this.indexDirectory = indexDirectory;
        }

        public string GetIndexDirectory()
        {
            return indexDirectory;
        }

        public void SetIndexedFilesDirectory(string indexedFilesDirectory)
        {
            this.indexedFilesDirectory = indexedFilesDirectory;
        }

        public string GetIndexedFilesDirectory()
        {
            return indexedFilesDirectory;
        }
    }
}