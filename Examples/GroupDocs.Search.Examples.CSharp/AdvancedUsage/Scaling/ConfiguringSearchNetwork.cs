using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling.Configuring;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class ConfiguringSearchNetwork
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/ConfiguringSearchNetwork/";
            // If an error occurs about using a busy network port, you need to change the value of the base port
            int basePort = 49100;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = Configure(basePath, basePort);
        }

        /// <summary>
        /// One or more nodes can be created on one server.
        /// Only one node accepts the configuration,
        /// which is automatically propagated to all nodes when the network is started.
        /// </summary>
        public static Configuration Configure(string basePath, int basePort)
        {
            string address = "127.0.0.1";
            Configuration configuration = new Configurator()
                .SetIndexSettings()
                    .SetUseStopWords(false)
                    .SetUseCharacterReplacements(false)
                    .SetTextStorageSettings(true, Compression.High)
                    .SetIndexType(IndexType.NormalIndex)
                    .SetSearchThreads(NumberOfThreads.Default)
                    .CompleteIndexSettings()
                .AddNode(0)
                    .SetTcpEndpoint(address, basePort)
                    .AddLogSink()
                    .AddIndexer(basePath + "Indexer0")
                    .AddSearcher(basePath + "Searcher0")
                    .CompleteNode()
                .AddNode(1)
                    .SetTcpEndpoint(address, basePort + 1)
                    .AddShard(basePath + "Shard1")
                    .AddExtractor(basePath + "Extractor1")
                    .CompleteNode()
                .AddNode(2)
                    .SetTcpEndpoint(address, basePort + 2)
                    .AddShard(basePath + "Shard2")
                    .AddExtractor(basePath + "Extractor2")
                    .CompleteNode()
                .AddNode(3)
                    .SetTcpEndpoint(address, basePort + 3)
                    .AddShard(basePath + "Shard3")
                    .AddExtractor(basePath + "Extractor3")
                    .CompleteNode()
                .CompleteConfiguration();
            return configuration;
        }
    }
}
