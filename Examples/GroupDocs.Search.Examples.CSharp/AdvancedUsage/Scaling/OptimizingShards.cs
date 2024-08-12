using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class OptimizingShards
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/OptimizingShards/";
            // If an error occurs about using a busy network port, you need to change the value of the base port
            int basePort = 49132;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);
            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath2);

            TextSearchInNetwork.SearchAll(masterNode, "ligula", false);

            OptimizeShards(masterNode);

            TextSearchInNetwork.SearchAll(masterNode, "ligula", false);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void OptimizeShards(SearchNetworkNode node)
        {
            Console.WriteLine();
            Console.WriteLine("Optimizing shards");
            Indexer indexer = node.Indexer;
            OptimizeOptions options = new OptimizeOptions();
            indexer.Optimize(options);
        }
    }
}
